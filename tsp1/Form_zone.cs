using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace tsp1
{
    public partial class Form_zone : Form
    {
        public Form_zone()
        {
            InitializeComponent();
        }
        string conStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\zlati\Desktop\tsp1\project.accdb";
        OleDbConnection dbConnect = new OleDbConnection();



        private void button1_Click(object sender, EventArgs e)
        {

            dbConnect.ConnectionString = conStr;
            string mySelect = "Insert INTO Zones ( [zone] ) Values ( '"
            +  textBox2.Text + "' )";
            OleDbCommand dbCmd = new OleDbCommand(mySelect, dbConnect);
            dbConnect.Open();
            dbCmd.CommandText = mySelect;
            dbCmd.Connection = dbConnect;
            dbCmd.ExecuteNonQuery();
            dbConnect.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dbConnect.ConnectionString = conStr;
            string mySelect = "UPDATE Zones SET [zone] = '" + textBox2.Text + "' WHERE  id = " + textBox1.Text;
            OleDbCommand dbCmd = new OleDbCommand(mySelect, dbConnect);
            dbConnect.Open();
            dbCmd.CommandText = mySelect;
            dbCmd.Connection = dbConnect;
            dbCmd.ExecuteNonQuery();
            dbConnect.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dbConnect.ConnectionString = conStr;
            string mySelect = "DELETE FROM Zones WHERE id=" + textBox1.Text;
            OleDbCommand dbCmd = new OleDbCommand(mySelect, dbConnect);
            dbConnect.Open();
            dbCmd.CommandText = mySelect;
            dbCmd.Connection = dbConnect;
            dbCmd.ExecuteNonQuery();
            dbConnect.Close();
        }
    }
}
