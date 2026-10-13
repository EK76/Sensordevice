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

namespace Sensordevice
{
    public partial class ModifyRow : Form
    {
        public ModifyRow()
        {
            InitializeComponent();
        }
        MySqlConnection conn = new MySqlConnection(FormMain.connString);
        string checkString, convertTemp, convertHum;
        int idRow;

        private void FormModifyRow_Load(object sender, EventArgs e)
        {
            textBoxTemp.Text = FormModifyTable.temp;
            textBoxHum.Text = FormModifyTable.hum;
            idRow = int.Parse(FormModifyTable.id);
            labelID.Text = "ID: " + idRow.ToString();
            labelDate.Text = "Date: " + FormModifyTable.createDate;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            convertTemp = textBoxTemp.Text.Replace(',', '.');
            convertHum = textBoxHum.Text.Replace(',', '.');
            try
            {


                conn.Open();
                checkString = "update sensorlog set temp = " + convertTemp + ", hum = " + convertHum + " where id = " + idRow;
                Clipboard.SetText(checkString);
                MySqlCommand command = new MySqlCommand(checkString, conn);
                MySqlDataReader reader = command.ExecuteReader();
                conn.Close();
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message);
            }
            Close();
            FormModifyTable.checkOnce = true;
        }
    }
}
