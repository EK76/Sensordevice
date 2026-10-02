using MySql.Data.MySqlClient;
using Sensordevice;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CameraDevice
{
    public partial class FormLogs : Form
    {
        public FormLogs()
        {
            InitializeComponent();
        }

        string checkString, selectedItem, checkItem, compareString;
        int selectedTopic, counterItems = 0, indexItemm, countRows;
        int infoCode, indexStatus;
        bool answer;
        public static List<string> listDates = new List<string>();
        public static List<string> listTopics = new List<string>();
        void countLog(string textLog, string currentSelection)
        {
            MySqlConnection conn = new MySqlConnection(FormMain.connString);
            conn.Open();
            MySqlCommand command = new MySqlCommand(currentSelection, conn);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            toolStripStatusLabelSelection.Text = textLog + reader["numbers"].ToString();
            conn.Close();
        }

        void logsColor(int infoCode, int indexStatus)
        {
            try
            {
                switch (infoCode)
                {
                    case 0:
                        listViewLogs.Items[indexStatus].ForeColor = Color.Green;
                        break;
                    case 1:
                        listViewLogs.Items[indexStatus].ForeColor = Color.Yellow;
                        break;
                    case 2:
                        listViewLogs.Items[indexStatus].ForeColor = Color.Red;
                        break;
                }
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message);

            }
        }

        void showStatus()
        {
            MySqlConnection conn = new MySqlConnection(FormMain.connString);

            comboBoxSelection.Items.Clear();
            comboBoxDate.Items.Clear();
            listDates.Clear();
            listTopics.Clear();
            try
            {
                conn.Open();
                checkString = "select * from loginfo order by datecreated desc;";
                Clipboard.SetText(checkString);
                MySqlCommand command = new MySqlCommand(checkString, conn);
                MySqlDataReader reader = command.ExecuteReader();
                indexStatus = 0;
                while (reader.Read())
                {
                    listViewLogs.Items.Add(new ListViewItem(new string[] { reader.GetString("logtext").ToString(), reader.GetInt32("infocode").ToString(), reader.GetString("comment").ToString(), reader.GetDateTime("datecreated").ToString("dd-MM-yyyy HH:mm") }));
                    infoCode = reader.GetInt32("infocode");
                    logsColor(infoCode, indexStatus);
                    indexStatus++;
                }
                conn.Close();
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message);
            }

            try
            {
                conn.Open();
                checkString = "select distinct infocode as 'infocode' from loginfo order by infocode;";
                Clipboard.SetText(checkString);
                MySqlCommand command = new MySqlCommand(checkString, conn);
                MySqlDataReader reader = command.ExecuteReader();
                comboBoxSelection.Items.Add("All items");
                while (reader.Read())
                {
                    comboBoxSelection.Items.Add(reader.GetInt32("infocode").ToString());
                    listTopics.Add(reader.GetInt32("infocode").ToString());
                }
                conn.Close();
            }
            catch (Exception i)
            {
                MessageBox.Show("Error: " + i.Message);
            }

            try
            {
                conn.Open();
                checkString = "select distinct left(datecreated, instr(datecreated,' ')) as 'datecreated' from loginfo;";
                Clipboard.SetText(checkString);
                MySqlCommand command = new MySqlCommand(checkString, conn);
                MySqlDataReader reader = command.ExecuteReader();
                comboBoxDate.Items.Add("All items");
                while (reader.Read())
                {
                    comboBoxDate.Items.Add(reader.GetString("datecreated").ToString());
                    listDates.Add(reader.GetString("datecreated").ToString());
                }
                conn.Close();
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message);
            }

            countLog("Total logs :", "select count(*) as 'numbers' from loginfo;");
            try
            {
                conn.Open();
                checkString = "select * from loginfo order by datecreated asc limit 1;";
                MySqlCommand command2 = new MySqlCommand(checkString, conn);
                MySqlDataReader reader2 = command2.ExecuteReader();
                reader2.Read();
                labelDateStart.Text = "Start date: " + reader2["datecreated"].ToString();
                conn.Close();
            }
            catch
            {
                labelDateStart.Text = "Start date: ";
            }

            try
            {
                conn.Open();
                checkString = "select * from loginfo order by datecreated desc limit 1;";
                MySqlCommand command3 = new MySqlCommand(checkString, conn);
                MySqlDataReader reader3 = command3.ExecuteReader();
                reader3.Read();
                labelDateEnd.Text = "End date: " + reader3["datecreated"].ToString();
                conn.Close();
            }
            catch
            {
                labelDateEnd.Text = "End date: ";
            }

            comboBoxSelection.Text = "";
            comboBoxDate.Text = "";
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormLogs_Load(object sender, EventArgs e)
        {
            showStatus();
        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(FormMain.connString);

            if (comboBoxSelection.SelectedItem == "All items")
            {
                try
                {
                    listViewLogs.Items.Clear();
                    conn.Open();
                    checkString = "select * from loginfo order by datecreated desc;";
                    Clipboard.SetText(checkString);
                    MySqlCommand command = new MySqlCommand(checkString, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    indexStatus = 0;
                    while (reader.Read())
                    {
                        listViewLogs.Items.Add(new ListViewItem(new string[] { reader.GetString("logtext").ToString(), reader.GetInt32("infocode").ToString(), reader.GetString("comment").ToString(), reader.GetDateTime("datecreated").ToString("dd-MM-yyyy HH:mm") }));
                        infoCode = reader.GetInt32("infocode");
                        logsColor(infoCode, indexStatus);
                        indexStatus++;
                    }
                    conn.Close();
                }
                catch (Exception i)
                {
                    MessageBox.Show(i.Message);
                }
                countLog("Total logs :", "select count(*) as 'numbers' from loginfo;");
                deleteToolStripMenuItem.Enabled = false;
            }
            else
            {
                try
                {
                    listViewLogs.Items.Clear();
                    conn.Open();
                    checkString = "select * from loginfo where infocode = '" + comboBoxSelection.SelectedItem + "'order by datecreated desc;";
                    Clipboard.SetText(checkString);
                    MySqlCommand command = new MySqlCommand(checkString, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    indexStatus = 0;
                    while (reader.Read())
                    {
                        listViewLogs.Items.Add(new ListViewItem(new string[] { reader.GetString("logtext").ToString(), reader.GetInt32("infocode").ToString(), reader.GetString("comment").ToString(), reader.GetDateTime("datecreated").ToString("dd-MM-yyyy HH:mm") }));
                        infoCode = reader.GetInt32("infocode");
                        logsColor(infoCode, indexStatus);
                        indexStatus++;
                    }
                    conn.Close();
                }
                catch (Exception i)
                {
                    MessageBox.Show(i.Message);
                }
                countLog("Numbers for selected item: ", "select count(*) as 'numbers' from loginfo where infocode = '" + comboBoxSelection.SelectedItem + "';");
                selectedItem = comboBoxSelection.SelectedItem.ToString();
                selectedTopic = 1;
                deleteToolStripMenuItem.Enabled = true;
            }
        }

        private void comboBoxDate_SelectedValueChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(FormMain.connString);
            if (comboBoxDate.SelectedItem == "All items")
            {
                try
                {
                    listViewLogs.Items.Clear();
                    conn.Open();
                    checkString = "select * from loginfo order by datecreated desc;";
                    Clipboard.SetText(checkString);
                    MySqlCommand command = new MySqlCommand(checkString, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    indexStatus = 0;
                    while (reader.Read())
                    {
                        listViewLogs.Items.Add(new ListViewItem(new string[] { reader.GetString("logtext").ToString(), reader.GetInt32("infocode").ToString(), reader.GetString("comment").ToString(), reader.GetDateTime("datecreated").ToString("dd-MM-yyyy HH:mm") }));
                        infoCode = reader.GetInt32("infocode");
                        logsColor(infoCode, indexStatus);
                        indexStatus++;
                    }
                    conn.Close();
                }
                catch (Exception i)
                {
                    MessageBox.Show(i.Message);
                }
                countLog("Total logs :", "select count(*) as 'numbers' from loginfo;");
                deleteToolStripMenuItem.Enabled = false;
            }
            else
            {
                try
                {
                    listViewLogs.Items.Clear();
                    conn.Open();
                    checkString = "select * from loginfo where datecreated like '" + comboBoxDate.SelectedItem + "%'order by datecreated desc;";
                    Clipboard.SetText(checkString);
                    MySqlCommand command = new MySqlCommand(checkString, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    indexStatus = 0;
                    while (reader.Read())
                    {
                        listViewLogs.Items.Add(new ListViewItem(new string[] { reader.GetString("logtext").ToString(), reader.GetInt32("infocode").ToString(), reader.GetString("comment").ToString(), reader.GetDateTime("datecreated").ToString("dd-MM-yyyy HH:mm") }));
                        infoCode = reader.GetInt32("infocode");
                        logsColor(infoCode, indexStatus);
                        indexStatus++;
                    }
                    conn.Close();
                }
                catch (Exception i)
                {
                    MessageBox.Show(i.Message);
                }
                countLog("Numbers for selected item: ", "select count(*) as 'numbers' from loginfo where datecreated like '" + comboBoxDate.SelectedItem + "%';");
                selectedItem = comboBoxDate.SelectedItem.ToString();
                selectedTopic = 2;
                deleteToolStripMenuItem.Enabled = true;
            }
        }

        private void backupLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = "";
            SaveFileDialog saveContent = new SaveFileDialog();

            saveContent.Title = "Save Data";
            saveContent.Filter = "Backup log (.log) | *.log";

            try
            {
                if (saveContent.ShowDialog() == DialogResult.OK)
                {
                    filename = saveContent.FileName.ToString();
                    if (filename != "")
                    {
                        using (StreamWriter sw = new StreamWriter(filename))
                        {
                            foreach (ListViewItem item in listViewLogs.Items)
                            {
                                sw.WriteLine("{0}{1}", item.SubItems[0].Text + "  ", item.SubItems[1].Text);
                            }
                        }
                        MessageBox.Show("File " + filename + " is susccessfully saved!", "Camera Device");
                    }
                }
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void graphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormViewgraph viewgraph = new FormViewgraph();
            viewgraph.ShowDialog();
        }

        private void boldTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (boldTextToolStripMenuItem.Checked)
            {
                boldTextToolStripMenuItem.Checked = false;
                listViewLogs.Font = new Font(listViewLogs.Font, FontStyle.Regular);
            }
            else
            {
                boldTextToolStripMenuItem.Checked = true;
                listViewLogs.Font = new Font(listViewLogs.Font, FontStyle.Bold);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are sure to delete these selected logs?", "Sensor Device", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MySqlConnection conn = new MySqlConnection(FormMain.connString);
                conn.Open();
                if (selectedTopic == 1)
                {
                    checkString = "delete from loginfo where logtext like '%" + selectedItem + "%';";
                }
                else
                {
                    checkString = "delete from loginfo where datecreated like '%" + selectedItem + "%';";
                }

                Clipboard.SetText(checkString);
                MySqlCommand command = new MySqlCommand(checkString, conn);
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                conn.Close();
                deleteToolStripMenuItem.Enabled = false;
                listViewLogs.Items.Clear();
                showStatus();
            }
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void infoCodeStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("0 = Information \n1 = Warning \n2 = Error", "Sensor Device");
        }
    }
}

