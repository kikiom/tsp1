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
    public partial class Form_business : Form
    {
        public Form_business()
        {
            InitializeComponent();
        }
        string conStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\zlati\Desktop\tsp1\project.accdb";
        OleDbConnection dbConnect = new OleDbConnection();



        private void button1_Click(object sender, EventArgs e)
        {

            dbConnect.ConnectionString = conStr;
            string mySelect = "Insert INTO Business ( [name],[adress],[phone] ) Values ( '"
            + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "' )";
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
            string mySelect = "UPDATE Business SET [name] =   '" + textBox2.Text + "',[adress] = '" + textBox3.Text + "',[phone] = '" + textBox4.Text + "' WHERE  id = " + textBox1.Text;
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
            string mySelect = "DELETE FROM Business WHERE id=" + textBox1.Text;
            OleDbCommand dbCmd = new OleDbCommand(mySelect, dbConnect);
            dbConnect.Open();
            dbCmd.CommandText = mySelect;
            dbCmd.Connection = dbConnect;
            dbCmd.ExecuteNonQuery();
            dbConnect.Close();
        }
    }
}
