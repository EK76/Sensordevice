using CameraDevice;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Sensordevice
{
    public partial class FormLogscolumn : Form
    {
        public FormLogscolumn()
        {
            InitializeComponent();
        }
        MySqlConnection conn = new MySqlConnection(FormMain.connString);
        int itemCount = 0;
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Logscolumn_Load(object sender, EventArgs e)
        {
            labelHead.Text = FormViewgraph.setColumn;

            switch(FormViewgraph.setColor)
            {
                case 1:
                    listViewColumn.ForeColor = Color.Green;
                    break;
                case 2:
                    listViewColumn.ForeColor = Color.Yellow;
                    break;
                case 3:
                    listViewColumn.ForeColor = Color.Red;
                    break;
                case 4:
                    listViewColumn.ForeColor = Color.Blue;
                    break;
            }


            try
            {
                conn.Open();
                Clipboard.SetText(FormViewgraph.setString);
                MySqlCommand command = new MySqlCommand(FormViewgraph.setString, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listViewColumn.Items.Add(new ListViewItem(new string[] { reader.GetString("logtext").ToString(), reader.GetInt32("infocode").ToString(), reader.GetString("comment").ToString(), reader.GetDateTime("datecreated").ToString("dd-MM-yyyy HH:mm") }));
                    itemCount++;

                }
                conn.Close();
                toolStripStatusLabelRows.Text = "Number of rows: " + itemCount.ToString();
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message);
            }
        }
    }
}
