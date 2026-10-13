using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sensordevice
{
    public partial class FormModifyTable : Form
    {
        public FormModifyTable()
        {
            InitializeComponent();
        }

        MySqlConnection conn = new MySqlConnection(FormMain.connString);
        string checkString, newStartDate, newEndDate, currentDate, firstDate;
        public static string temp, hum, id, createDate;
        int counterItems;
        List<int> deleteRows = new List<int>();
        public static bool checkOnce = false;
        DateTime startDate, endDate, currentDate2;
        void showTable()
        {  

            counterItems = 0;
            conn.Open();
            checkString = "select id, temp, hum, datecreated from sensorlog order by datecreated desc";
            MySqlCommand command2 = new MySqlCommand(checkString, conn);
            MySqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                counterItems++;

                if (counterItems == 1)
                {
                    listViewTable.Items.Clear();
                }
                listViewTable.Items.Add(new ListViewItem(new string[] { reader2.GetDecimal("id").ToString(), reader2.GetDecimal("temp").ToString() + " °C", reader2.GetDecimal("hum").ToString() + " %", reader2.GetDateTime("datecreated").ToString("dd-MM-yyyy HH:mm") }));
            }
            conn.Close();
            toolStripStatusLabelRows.Text = "Number of rows: " + counterItems.ToString();
            if (counterItems == 0)
            {
                MessageBox.Show("The search gave no result!", "Ken's Sensor Devicecle.");
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Modifytable_Load(object sender, EventArgs e)
        {
            currentDate = DateTime.Now.ToString("dd-MM-yyyy");
            currentDate2 = DateTime.ParseExact(currentDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            dateTimePickerStartDate.MaxDate = currentDate2;
            dateTimePickerEndDate.MaxDate = currentDate2;
            conn.Open();
            checkString = "select datecreated from sensorlog limit 1";
            MySqlCommand command2 = new MySqlCommand(checkString, conn);
            MySqlDataReader reader2 = command2.ExecuteReader();
            reader2.Read();
            firstDate = reader2.GetDateTime("datecreated").ToString("dd-MM-yyyy");
            dateTimePickerStartDate.MinDate = DateTime.ParseExact(firstDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            conn.Close();
            showTable();
        }

        private void allItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showTable();
        }

        private void dateTimePickerStartDate_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerEndDate.MinDate = dateTimePickerStartDate.Value;
            dateTimePickerEndDate.Enabled = true;
        }

        private void dateTimePickerEndDate_CloseUp(object sender, EventArgs e)
        {
            startDate = dateTimePickerStartDate.Value;
            endDate = dateTimePickerEndDate.Value;
            endDate = endDate.AddDays(1);

            newStartDate = startDate.ToString("yyyy-MM-dd");
            newEndDate = endDate.ToString("yyyy-MM-dd");
            try
            {

                counterItems = 0;
                conn.Open();
                checkString = "select id, temp, hum, datecreated from sensorlog where datecreated between '" + newStartDate + "' and '" + newEndDate + "';";
                Clipboard.SetText(checkString);
                MySqlCommand command = new MySqlCommand(checkString, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    counterItems++;
                    if (counterItems == 1)
                    {
                        listViewTable.Items.Clear();
                    }
                    listViewTable.Items.Add(new ListViewItem(new string[] { reader.GetDecimal("id").ToString(), reader.GetDecimal("temp").ToString() + " °C", reader.GetDecimal("hum").ToString() + " %", reader.GetDateTime("datecreated").ToString("dd-MM-yyyy HH:mm") }));
                }
                conn.Close();
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message);
            }
            toolStripStatusLabelRows.Text = "Number of rows: " + counterItems.ToString();
            if (counterItems == 0)
            {
                MessageBox.Show("The search was not result!");
            }
        }

        private void modifyRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifyRow modifyRow = new ModifyRow();
            modifyRow.ShowDialog();
        }

        private void listViewTable_DoubleClick(object sender, EventArgs e)
        {
            ModifyRow modifyRow = new ModifyRow();
            modifyRow.ShowDialog();
        }

        private void listViewTable_Click(object sender, EventArgs e)
        {
            temp = listViewTable.SelectedItems[0].SubItems[1].Text.Replace(" °C", "");
            hum = listViewTable.SelectedItems[0].SubItems[2].Text.Replace(" %", "");
            id = listViewTable.SelectedItems[0].SubItems[0].Text;
            createDate = listViewTable.SelectedItems[0].SubItems[3].Text;
            if (listViewTable.SelectedItems.Count == 1)
            {
                modifyRowToolStripMenuItem.Enabled = true;
            }
            else
            {
                modifyRowToolStripMenuItem.Enabled = false;
            }
            if (listViewTable.SelectedItems.Count >= 1)
            {
                deleteRowsToolStripMenuItem.Enabled = true;
            }
            else
            {
                deleteRowsToolStripMenuItem.Enabled = false;
            }
        }

        private void FormModifyTable_Activated(object sender, EventArgs e)
        {
            if (checkOnce == true)
            {
                showTable();
                checkOnce = false;
            }
        }

        private void deleteRowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the selected rows?", "Sensor Device", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {


                foreach (ListViewItem item in listViewTable.SelectedItems)
                {
                    if (item.Selected)
                    {
                        deleteRows.Add(int.Parse(item.SubItems[0].Text));
                    }
                }

                foreach (int item2 in deleteRows)
                {
                    try
                    {
                        conn.Open();
                        checkString = "delete from sensorlog where id = " + item2;
                        MySqlCommand command = new MySqlCommand(checkString, conn);
                        MySqlDataReader reader = command.ExecuteReader();
                        conn.Close();
                    }
                    catch (Exception i)
                    {
                        MessageBox.Show(i.Message);
                    }
                }
                showTable();
                deleteRows.Clear();
            }
        }
    }
}
