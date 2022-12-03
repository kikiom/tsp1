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

namespace tsp1
{
    public partial class Form_bus_line : Form
    {
        public Form_bus_line()
        {
            InitializeComponent();
        }

        private void Form_bus_line_Load(object sender, EventArgs e)
        {

        }
        string conStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\zlati\Desktop\tsp1\project.accdb";
        OleDbConnection dbConnect = new OleDbConnection();



        private void button1_Click(object sender, EventArgs e)
        {

            dbConnect.ConnectionString = conStr;
            string mySelect = "Insert INTO Bus_lines ( [line],[active_bus_number] ) Values ( '"
            + textBox2.Text +"','"+textBox3.Text+ "' )";
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
            string mySelect = "UPDATE Bus_lines SET [line] = '" + textBox2.Text + "',[active_bus_number] = " + textBox3.Text +" WHERE  id = " + textBox1.Text;
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
            string mySelect = "DELETE FROM Bus_lines WHERE id=" + textBox1.Text;
            OleDbCommand dbCmd = new OleDbCommand(mySelect, dbConnect);
            dbConnect.Open();
            dbCmd.CommandText = mySelect;
            dbCmd.Connection = dbConnect;
            dbCmd.ExecuteNonQuery();
            dbConnect.Close();
        }
    }
}
