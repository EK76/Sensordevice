using CameraDevice;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Mysqlx.Session;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sensordevice
{
    public partial class FormGraph : Form
    {
        public FormGraph()
        {
            InitializeComponent();
        }

        int addPoint, point = 0;
        string addNewValue, addFormatDate2, checkString;
        DateTime addFormatDate;
        decimal convertValue;
        List<decimal> listSum = new List<decimal>();
        List<decimal> listSum2 = new List<decimal>();
        List<string> newListTemp = new List<string>();
        List<string> newListHum = new List<string>();
        List<string> newListDate = new List<string>();
        HashSet<string> listDates = new HashSet<string>();
        bool setDate = false;
        MySqlConnection conn = new MySqlConnection(FormMain.connString);

        void allDates()
        {
            chartTemp.Series[0].Points.Clear();
            chartHum.Series[0].Points.Clear();
            chartTemp.Update();
            try
            {
                chartTemp.Update();
                chartTemp.Series[0].LegendText = "Temperature";
                chartTemp.ChartAreas[0].AxisY.Title = "Celsius";
                chartTemp.ChartAreas[0].AxisY.Minimum = -40;
                chartTemp.ChartAreas[0].AxisY.Maximum = 40;
                chartTemp.ChartAreas[0].AxisY.Interval = 10;
                chartTemp.ChartAreas[0].AxisY.MinorGrid.Interval = chartTemp.ChartAreas[0].AxisY.Interval / 2;
                chartTemp.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
                addPoint = 0;

                foreach (var addValue in FormMain.listTemp)
                {
                    addNewValue = addValue;
                    var removeChars = new string[] { "°", "C", "%", "h", "P", "A", "a" };
                    foreach (var rc in removeChars)
                    {
                        addNewValue = addNewValue.Replace(rc, string.Empty);
                    }
                    convertValue = decimal.Parse(addNewValue);

                    chartTemp.Series[0].Points.AddXY(addPoint, convertValue);
                    listSum.Add(convertValue);
                    addPoint++;
                }
            }

            catch (Exception message)
            {
                MessageBox.Show(message.ToString());
            }

     

            chartHum.Update();
            try
            {
                chartHum.Update();
                chartHum.Series[0].LegendText = "Humidity";
                chartHum.ChartAreas[0].AxisY.Title = "%";
                chartHum.ChartAreas[0].AxisY.Minimum = 0;
                chartHum.ChartAreas[0].AxisY.Maximum = 100;
                chartHum.ChartAreas[0].AxisY.Interval = 10;
                chartHum.ChartAreas[0].AxisY.MinorGrid.Interval = chartHum.ChartAreas[0].AxisY.Interval / 2;
                chartHum.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
                addPoint = 0;

                foreach (var addValue in FormMain.listHum)
                {
                    addNewValue = addValue;
                    var removeChars = new string[] { "°", "C", "%", "h", "P", "A", "a" };
                    foreach (var rc in removeChars)
                    {
                        addNewValue = addNewValue.Replace(rc, string.Empty);
                    }
                    convertValue = decimal.Parse(addNewValue);

                    chartHum.Series[0].Points.AddXY(addPoint, convertValue);
                    listSum2.Add(convertValue);
                    addPoint++;
                }
            }
            catch (Exception message)
            {
                MessageBox.Show(message.ToString());
            }
            labelRows.Text = "Number of rows: " + addPoint;
            labelMedium.Text = "Medium value: " + Math.Round(listSum.Average(), 1) + " °C " + Math.Round(listSum2.Average(), 1) + " %";
            labelMin.Text = "Min value: " + listSum.Min() + " °C " + listSum2.Min() + " %";
            labelMax.Text = "Max value: " + listSum.Max() + " °C " + listSum2.Min() + " %";
            labelStartDate.Text = "Start date " + FormMain.listDate.First();
            labelEndDate.Text = "End date " + FormMain.listDate.Last();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartTemp.Series[0].MarkerStyle = MarkerStyle.Circle;
            chartHum.Series[0].MarkerStyle = MarkerStyle.Circle;
            chartTemp.Series[0].MarkerSize = 16;
            chartHum.Series[0].MarkerSize = 16;
            chartTemp.Series[0].BorderColor = Color.Black;
            chartHum.Series[0].BorderColor = Color.Black;
            circleToolStripMenuItem.Checked = true;
            triangleToolStripMenuItem.Checked = false;
            squareToolStripMenuItem.Checked = false;
            starToolStripMenuItem.Checked = false;
            noneToolStripMenuItem.Checked = false;
        }

        private void triangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartTemp.Series[0].MarkerStyle = MarkerStyle.Triangle;
            chartHum.Series[0].MarkerStyle = MarkerStyle.Triangle;
            circleToolStripMenuItem.Checked = false;
            triangleToolStripMenuItem.Checked = true;
            squareToolStripMenuItem.Checked = false;
            starToolStripMenuItem.Checked = false;
            noneToolStripMenuItem.Checked = false;
        }

        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartTemp.Series[0].MarkerStyle = MarkerStyle.Square;
            chartHum.Series[0].MarkerStyle = MarkerStyle.Square;
            circleToolStripMenuItem.Checked = false;
            triangleToolStripMenuItem.Checked = false;
            squareToolStripMenuItem.Checked = true;
            starToolStripMenuItem.Checked = false;
            noneToolStripMenuItem.Checked = false;
        }

        private void starToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartTemp.Series[0].MarkerStyle = MarkerStyle.Star5;
            chartHum.Series[0].MarkerStyle = MarkerStyle.Star5;
            circleToolStripMenuItem.Checked = false;
            triangleToolStripMenuItem.Checked = false;
            squareToolStripMenuItem.Checked = false;
            starToolStripMenuItem.Checked = true;
            noneToolStripMenuItem.Checked = false;
        }

        private void markerColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.AllowFullOpen = true;
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                chartTemp.Series[0].MarkerColor = colorDialog1.Color;
                chartTemp.Series[0].BorderColor = colorDialog1.Color;
                chartTemp.Series[0].Color = colorDialog1.Color;
                chartHum.Series[0].MarkerColor = colorDialog1.Color;
                chartHum.Series[0].BorderColor = colorDialog1.Color;
                chartHum.Series[0].Color = colorDialog1.Color;
            }
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartTemp.Series[0].MarkerSize = 10;
            chartHum.Series[0].MarkerSize = 10;
            chartTemp.Series[0].MarkerStyle = MarkerStyle.Circle;
            chartHum.Series[0].MarkerStyle = MarkerStyle.Circle;
            chartTemp.Series[0].MarkerColor = Color.Black;
            chartTemp.Series[0].BorderColor = Color.Black;
            chartTemp.Series[0].Color = Color.Black;
            chartHum.Series[0].MarkerColor = Color.Black;
            chartHum.Series[0].BorderColor = Color.Black;
            chartHum.Series[0].Color = Color.Black;
            circleToolStripMenuItem.Checked = true;
            triangleToolStripMenuItem.Checked = false;
            squareToolStripMenuItem.Checked = false;
            starToolStripMenuItem.Checked = false;
            noneToolStripMenuItem.Checked = false;
            trackBarMarkerSize.Value = 10;
            chartTemp.Series[0].BorderWidth = 2;
            chartHum.Series[0].BorderWidth = 2;
            smallToolStripMenuItem.Checked = true;
            mediumToolStripMenuItem.Checked = false;
            largeToolStripMenuItem.Checked = false;
            labelTrackSize.Text = "Marker size: 10";
        }

        private void FormGraph_Load(object sender, EventArgs e)
        {
            Title showTemp = chartTemp.Titles.Add("Humidity");
            showTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15f, FontStyle.Bold);
            Title showHum = chartHum.Titles.Add("Temperature");
            showHum.Font = new System.Drawing.Font("Microsoft Sans Serif", 15f, FontStyle.Bold);

            allDates();
            addPoint = 0;
      

            foreach (var addValue in FormMain.listDate)
            {
                if (DateTime.TryParse(addValue.ToString(), out addFormatDate))
                {
                    addFormatDate2 = addFormatDate.ToString("yyyy-MM-dd");
                    if (listDates.Add(addFormatDate2))
                    {
                        toolStripComboBoxChosenDay.Items.Add(addFormatDate2);
                    }
                }
            }
        }

        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartTemp.Series[0].MarkerStyle = MarkerStyle.None;
            chartHum.Series[0].MarkerStyle = MarkerStyle.None;
            circleToolStripMenuItem.Checked = false;
            triangleToolStripMenuItem.Checked = false;
            squareToolStripMenuItem.Checked = false;
            starToolStripMenuItem.Checked = false;
            noneToolStripMenuItem.Checked = true;
        }

        private void chartTemp_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            var showValue = chartTemp.HitTest(e.X, e.Y);
            if ((e.HitTestResult.ChartElementType == ChartElementType.DataPoint))
            {
                var dataPoint = e.HitTestResult.Series.Points[e.HitTestResult.PointIndex];
                point = showValue.PointIndex;
                if (setDate == true)
                {
                    e.Text = string.Format("Date: {0}\n" + "Temperature" + ": {1} " + " °C", newListDate[(int)dataPoint.XValue], dataPoint.YValues[0]);
                    labelInfo.Text = string.Format("Date: {0}\n" + "Temperature" + ": {1} " + " °C", newListDate[(int)dataPoint.XValue], dataPoint.YValues[0]);
                }
                else
                {
                    e.Text = string.Format("Date: {0}\n" + "Temperature" + ": {1} " + " °C", FormMain.listDate[(int)dataPoint.XValue], dataPoint.YValues[0]);
                    labelInfo.Text = string.Format("Date: {0}\n" + "Temperature" + ": {1} " + " °C", FormMain.listDate[(int)dataPoint.XValue], dataPoint.YValues[0]);
                }
            }
            else
            {
                labelInfo.Text = "";
            }

        }

        private void chartHum_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            var showValue = chartHum.HitTest(e.X, e.Y);
            if ((e.HitTestResult.ChartElementType == ChartElementType.DataPoint))
            {
                var dataPoint = e.HitTestResult.Series.Points[e.HitTestResult.PointIndex];
                point = showValue.PointIndex;
                if (setDate == true)
                {
                   e.Text = string.Format("Date: {0}\n" + "Humitidy" + ": {1} " + " %", newListDate[(int)dataPoint.XValue], dataPoint.YValues[0]);
                   labelInfo.Text = string.Format("Date: {0}\n" + "Humitidy" + ": {1} " + " %", newListDate[(int)dataPoint.XValue], dataPoint.YValues[0]);
                }
                else
                {
                   e.Text = string.Format("Date: {0}\n" + "Humitidy" + ": {1} " + " %", FormMain.listDate[(int)dataPoint.XValue], dataPoint.YValues[0]);
                   labelInfo.Text = string.Format("Date: {0}\n" + "Humitidy" + ": {1} " + " %", FormMain.listDate[(int)dataPoint.XValue], dataPoint.YValues[0]);
                }
            }
            else
            {
                labelInfo.Text = "";
            }
        }

        private void temperatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (MemoryStream mStream = new MemoryStream())
            {
                chartTemp.SaveImage(mStream, ChartImageFormat.Bmp);
                Bitmap chartImage = new Bitmap(mStream);
                Clipboard.SetImage(chartImage);
            }
            MessageBox.Show("Temperature chart diagram copied!");

        }

        private void humitidyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (MemoryStream mStream = new MemoryStream())
            {
                chartHum.SaveImage(mStream, ChartImageFormat.Bmp);
                Bitmap chartImage = new Bitmap(mStream);
                Clipboard.SetImage(chartImage);
            }
            MessageBox.Show("Humitidy chart diagram copied!");
        }

        private void temperatureToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "png Image|*.png|jpeg Image|*.jpg";
            saveFileDialog.Title = "Save Chart As Image File";
            saveFileDialog.FileName = "tempchart";

            DialogResult result = saveFileDialog.ShowDialog();
            saveFileDialog.RestoreDirectory = true;

            if (result == DialogResult.OK && saveFileDialog.FileName != "")
            {
                try
                {
                    if (saveFileDialog.CheckPathExists)
                    {
                        if (saveFileDialog.FilterIndex == 2)
                        {
                            chartTemp.SaveImage(saveFileDialog.FileName, ChartImageFormat.Jpeg);
                        }
                        else if (saveFileDialog.FilterIndex == 1)
                        {
                            chartTemp.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Given Path does not exist");
                    }
                }
                catch (Exception d)
                {
                    MessageBox.Show(d.Message);
                }
            }
        }

        private void humitidyToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "png Image|*.png|jpeg Image|*.jpg";
            saveFileDialog.Title = "Save Chart As Image File";
            saveFileDialog.FileName = "humchart";

            DialogResult result = saveFileDialog.ShowDialog();
            saveFileDialog.RestoreDirectory = true;

            if (result == DialogResult.OK && saveFileDialog.FileName != "")
            {
                try
                {
                    if (saveFileDialog.CheckPathExists)
                    {
                        if (saveFileDialog.FilterIndex == 2)
                        {
                            chartHum.SaveImage(saveFileDialog.FileName, ChartImageFormat.Jpeg);
                        }
                        else if (saveFileDialog.FilterIndex == 1)
                        {
                            chartHum.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Given Path does not exist");
                    }
                }
                catch (Exception d)
                {
                    MessageBox.Show(d.Message);

                }
            }
        }

        private void trackBarMarkerSize_Scroll(object sender, EventArgs e)
        {
            chartTemp.Series[0].MarkerSize = trackBarMarkerSize.Value;
            chartHum.Series[0].MarkerSize = trackBarMarkerSize.Value;
            labelTrackSize.Text = "Marker size: " + trackBarMarkerSize.Value;
        }

        private void trackBarMarkerSize_MouseHover(object sender, EventArgs e)
        {

        }

        private void trackBarMarkerSize_MouseMove(object sender, MouseEventArgs e)
        {
            toolTipTrackSize.SetToolTip(trackBarMarkerSize, trackBarMarkerSize.Value.ToString());
        }

        private void largeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartTemp.Series[0].BorderWidth = 7;
            chartHum.Series[0].BorderWidth = 7;
            smallToolStripMenuItem.Checked = false;
            mediumToolStripMenuItem.Checked = false;
            largeToolStripMenuItem.Checked = true;
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartTemp.Series[0].BorderWidth = 4;
            chartHum.Series[0].BorderWidth = 4;
            smallToolStripMenuItem.Checked = false;
            mediumToolStripMenuItem.Checked = true;
            largeToolStripMenuItem.Checked = false;
        }

        private void smallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartTemp.Series[0].BorderWidth = 2;
            chartHum.Series[0].BorderWidth = 2;
            smallToolStripMenuItem.Checked = true;
            mediumToolStripMenuItem.Checked = false;
            largeToolStripMenuItem.Checked = false;
        }

        private void toolStripComboBoxChosenDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            chartTemp.Series[0].Points.Clear();
            chartHum.Series[0].Points.Clear();
            newListTemp.Clear();
            newListHum.Clear();
            newListDate.Clear();
            listSum.Clear();
            listSum2.Clear();
            refreshToolStripMenuItem.Enabled = true;
            setDate = true;

            DateTime convertDate = DateTime.Parse(toolStripComboBoxChosenDay.SelectedItem.ToString());
            labelStartDate.Text = "Choosen date " + convertDate.ToString("dd.MM.yyyy");
            labelEndDate.Visible = false;
            conn.Open();
            checkString = "select * from sensorlog where datecreated like '" + toolStripComboBoxChosenDay.SelectedItem.ToString() + "%'";
            Clipboard.SetText(checkString);
            MySqlCommand command = new MySqlCommand(checkString, conn);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                newListTemp.Add(reader.GetDecimal("temp").ToString());
                newListHum.Add(reader.GetDecimal("hum").ToString());
                newListDate.Add(reader.GetDateTime("datecreated").ToString("dd.MM.yyyy HH:mm"));
            }

            conn.Close();
            chartTemp.Update();
            try
            {
                chartTemp.Update();
                chartTemp.Series[0].LegendText = "Temperature";
                chartTemp.ChartAreas[0].AxisY.Title = "Celsius";
                chartTemp.ChartAreas[0].AxisY.Minimum = -40;
                chartTemp.ChartAreas[0].AxisY.Maximum = 40;
                chartTemp.ChartAreas[0].AxisY.Interval = 10;
                chartTemp.ChartAreas[0].AxisY.MinorGrid.Interval = chartTemp.ChartAreas[0].AxisY.Interval / 2;
                chartTemp.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
                addPoint = 0;

                foreach (var addValue in newListTemp)
                {
                    addNewValue = addValue;
                    var removeChars = new string[] { "°", "C", "%", "h", "P", "A", "a" };
                    foreach (var rc in removeChars)
                    {
                        addNewValue = addNewValue.Replace(rc, string.Empty);
                    }
                    convertValue = decimal.Parse(addNewValue);

                    chartTemp.Series[0].Points.AddXY(addPoint, convertValue);
                    listSum.Add(convertValue);
                    addPoint++;
                }
            }

            catch (Exception message)
            {
                MessageBox.Show(message.ToString());
            }

            chartHum.Update();
            try
            {
                chartHum.Update();
                chartHum.Series[0].LegendText = "Humidity";
                chartHum.ChartAreas[0].AxisY.Title = "%";
                chartHum.ChartAreas[0].AxisY.Minimum = 0;
                chartHum.ChartAreas[0].AxisY.Maximum = 100;
                chartHum.ChartAreas[0].AxisY.Interval = 10;
                chartHum.ChartAreas[0].AxisY.MinorGrid.Interval = chartHum.ChartAreas[0].AxisY.Interval / 2;
                chartHum.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
                addPoint = 0;

                foreach (var addValue in newListHum)
                {
                    addNewValue = addValue;
                    var removeChars = new string[] { "°", "C", "%", "h", "P", "A", "a" };
                    foreach (var rc in removeChars)
                    {
                        addNewValue = addNewValue.Replace(rc, string.Empty);
                    }
                    convertValue = decimal.Parse(addNewValue);

                    chartHum.Series[0].Points.AddXY(addPoint, convertValue);
                    listSum2.Add(convertValue);
                    addPoint++;
                }
            }
            catch (Exception message)
            {
                MessageBox.Show(message.ToString());
            }

            labelRows.Text = "Number of rows: " + addPoint;
            labelMedium.Text = "Medium value: " + Math.Round(listSum.Average(), 1) + " °C " + Math.Round(listSum2.Average(), 1) + " %";
            labelMin.Text = "Min value: " + listSum.Min() + " °C " + listSum2.Min() + " %";
            labelMax.Text = "Max value: " + listSum.Max() + " °C " + listSum2.Min() + " %";
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshToolStripMenuItem.Enabled = false;
            setDate = false;
            allDates();
        }
    }
}

