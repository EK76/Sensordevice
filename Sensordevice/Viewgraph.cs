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

        bool openForm = false;
        public static string setString, setColumn;
        public static int setColor;
        void dateView()
        {
            this.Size = new Size(835, 620);
            listBoxShowTopics.Visible = false;
            chartView.Series[0].Points.Clear();
            MySqlConnection conn = new MySqlConnection(FormMain.connString);
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
            this.Size = new Size(1085, 620);
            listBoxShowTopics.Visible = true;
            chartView.Series[0].Points.Clear();
            MySqlConnection conn = new MySqlConnection(FormMain.connString);
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
                if (index == 0)
                {
                    chartView.Series[0].Points[index].Color = Color.Green;
                }
                if (index == 1)
                {
                    chartView.Series[0].Points[index].Color = Color.Yellow;
                }
                if (index == 2)
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
            }
        }

        private void radioButtonShowTopics_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonShowTopics.Checked)
            {
                topicView();
            }
        }

        private void chartView_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            string setValue = "";
            ;
            if (choice == 1)
            {
                if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
                {
                    var dataPoint = e.HitTestResult.Series.Points[e.HitTestResult.PointIndex];
                    setValue = string.Format("{0}", FormLogs.listDates[(int)dataPoint.XValue -1], dataPoint.YValues[0]);
                    setString = "select * from loginfo where datecreated like '" + setValue + "%';";
                    setColumn = "Date " + setValue + "is selected";
                    openForm = true;
                    setColor = 4;
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
                    var dataPoint = e.HitTestResult.Series.Points[e.HitTestResult.PointIndex];
                    setValue = string.Format("{0}", dataPoint.XValue, dataPoint.YValues[0]);
                    setString = "select * from loginfo where infocode = '" + (Convert.ToInt32(setValue) - 1) + "';";
                    setColumn = "Infocode " + (Convert.ToInt32(setValue) - 1) + " is selected";
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
    }

}