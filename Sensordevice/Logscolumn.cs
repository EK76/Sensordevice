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
        int itemCount = 0, indexStatus = 0, setColor2;
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Logscolumn_Load(object sender, EventArgs e)
        {
            labelHead.Text = FormViewgraph.setColumn;
            MySqlConnection conn = new MySqlConnection(FormMain.connString);
            switch (FormViewgraph.setColor)
            {
                case 0:
                    listViewColumn.ForeColor = Color.Green;
                    break;
                case 1:
                    listViewColumn.ForeColor = Color.Yellow;
                    break;
                case 2:
                    listViewColumn.ForeColor = Color.Red;
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
                    setColor2 = reader.GetInt32("infocode");
                    if (FormViewgraph.setColor == 3)
                    {

                        setColor2 = reader.GetInt32("infocode");
                        if (setColor2 == 0)
                        {

                            listViewColumn.Items.Add(new ListViewItem(new string[] { reader.GetString("logtext").ToString(), reader.GetInt32("infocode").ToString(), reader.GetDateTime("datecreated").ToString("dd-MM-yyyy HH:mm") }));
                            listViewColumn.Items[indexStatus].ForeColor = Color.Green;
                        }
                        else if (setColor2 == 1)
                        {

                            listViewColumn.Items.Add(new ListViewItem(new string[] { reader.GetString("logtext").ToString(), reader.GetInt32("infocode").ToString(), reader.GetDateTime("datecreated").ToString("dd-MM-yyyy HH:mm") }));
                            listViewColumn.Items[indexStatus].ForeColor = Color.Yellow;
                        }
                        else if (setColor2 == 2)
                        {
                            listViewColumn.Items.Add(new ListViewItem(new string[] { reader.GetString("logtext").ToString(), reader.GetInt32("infocode").ToString(), reader.GetDateTime("datecreated").ToString("dd-MM-yyyy HH:mm") }));
                            listViewColumn.Items[indexStatus].ForeColor = Color.Red;
                        }
                        indexStatus++;

                    }

                    else
                    {
                        listViewColumn.Items.Add(new ListViewItem(new string[] { reader.GetString("logtext").ToString(), reader.GetInt32("infocode").ToString(), reader.GetDateTime("datecreated").ToString("dd-MM-yyyy HH:mm") }));
                    }
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
