using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1;
using Sensordevice;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Runtime.InteropServices.Marshalling.IIUnknownCacheStrategy;

namespace CameraDevice
{
    public partial class FormViewgraph : Form
    {
        public FormViewgraph()
        {
            InitializeComponent();
        }

        List<int> dateCounts = new List<int>();
        List<int> topicCounts = new List<int>();
        int dateNumbers, topicNumbers, count, checkCount, index, index2, point = 0, choice = 1;
        string checkString, showColumn;
        MySqlConnection conn = new MySqlConnection(FormMain.connString);
        bool openForm = false;
        public static string setString, setColumn;
        public static int setColor;

        bool showStatus = false;
        void dateView()
        {
            chartView.Series[0].ChartType = SeriesChartType.Column;
            buttonShowStatus.Text = "View as pie";
            showStatus = true;
            chartView.Series[0].Points.Clear();
            dateNumbers = FormLogs.listDates.Count;
            dateCounts.Clear();

            for (int index = 0; index < dateNumbers; index++)
            {
                conn.Open();
                checkString = "select count(*) from loginfo where datecreated like '" + FormLogs.listDates[index] + "%'";
                MySqlCommand command = new MySqlCommand(checkString, conn);
                count = Convert.ToInt32(command.ExecuteScalar());
                conn.Close();
                dateCounts.Add(count);
                checkCount++;
                conn.Close();
            }

            index = 0;
            index2 = 1;

            foreach (var addValue in dateCounts)
            {
                chartView.Series[0].Points.AddXY(index2, addValue);
                chartView.Series[0].Points[index].Label = addValue.ToString();
                chartView.Series[0].Points[index].AxisLabel = FormLogs.listDates[index].ToString();
                index++;
                index2++;
            }
            choice = 1;
        }

        void topicView()
        {
            chartView.Series[0].Points.Clear();
            topicNumbers = FormLogs.listTopics.Count;
            topicCounts.Clear();
            for (int index = 0; index < topicNumbers; index++)
            {
                conn.Open();
                checkString = "select count(*) from loginfo where infocode = '" + FormLogs.listTopics[index] + "';";
                MySqlCommand command = new MySqlCommand(checkString, conn);
                count = Convert.ToInt32(command.ExecuteScalar());
                conn.Close();
                topicCounts.Add(count);
                checkCount++;
            }

            index = 0;
            index2 = 1;

            foreach (var addValue in topicCounts)
            {
                chartView.Series[0].Points.AddXY(index2, addValue);
                chartView.Series[0].Points[index].Label = addValue.ToString();
                chartView.ChartAreas[0].AxisX.Interval = 1;
                chartView.Series[0].Points[index].AxisLabel = index2.ToString();
                chartView.Series[0].Points[index].AxisLabel = FormLogs.listTopics[index];
                if (FormLogs.listTopics[index] == "0")
                {
                    chartView.Series[0].Points[index].Color = Color.Green;
                }
                if (FormLogs.listTopics[index] == "1")
                {
                    chartView.Series[0].Points[index].Color = Color.Yellow;
                }
                if (FormLogs.listTopics[index] == "2")
                {
                    chartView.Series[0].Points[index].Color = Color.Red;
                }
                index++;
                index2++;
            }
            choice = 2;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Viewgraph_Load(object sender, EventArgs e)
        {
            dateView();
        }
        private void radioButtonShowDates_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonShowDates.Checked)
            {
                dateView();
                buttonShowStatus.Visible = false;
            }
        }

        private void radioButtonShowTopics_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonShowTopics.Checked)
            {
                topicView();
                buttonShowStatus.Visible = true;
            }
        }

        private void chartView_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            string setValue = "";

            if (choice == 1)
            {
                if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
                {
                    var dataPoint = e.HitTestResult.Series.Points[e.HitTestResult.PointIndex];
                    setValue = string.Format("{0}", FormLogs.listDates[(int)dataPoint.XValue - 1], dataPoint.YValues[0]);
                    setString = "select * from loginfo where datecreated like '" + setValue + "%';";
                    setColumn = "Date " + setValue + "is selected";
                    openForm = true;
                    setColor = 3;
                }
                else
                {
                    openForm = false;
                }
            }
            else
            {
                if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
                {
                    HitTestResult result = chartView.HitTest(e.X, e.Y);
                    if (result.PointIndex >= 0)
                    {
                        setValue = chartView.Series[0].Points[result.PointIndex].AxisLabel;

                    }
                    setString = "select * from loginfo where infocode = '" + (Convert.ToInt32(setValue)) + "';";
                    setColumn = "Infocode " + (Convert.ToInt32(setValue)) + " is selected";
                    setColor = Convert.ToInt32(setValue);
                    openForm = true;
                }
                else
                {
                    openForm = false;
                }
            }
        }

        private void chartView_Click(object sender, EventArgs e)
        {
            if (openForm)
            {
                FormLogscolumn logsColumn = new FormLogscolumn();
                logsColumn.ShowDialog();
            }
        }

        private void buttonShowStatus_Click(object sender, EventArgs e)
        {
           if (showStatus)
           {
              chartView.Series[0].ChartType = SeriesChartType.Pie;
              buttonShowStatus.Text = "View as column";
              showStatus = false;
           }
           else
           {
              chartView.Series[0].ChartType = SeriesChartType.Column;
              buttonShowStatus.Text = "View as pie";
              showStatus= true;
              index = 0;
           }
        }
    }

}