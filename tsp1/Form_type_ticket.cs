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
    public partial class Form_type_ticket : Form
    {
        public Form_type_ticket()
        {
            InitializeComponent();
        }

        private void Form_type_ticket_Load(object sender, EventArgs e)
        {

        }
        string conStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\zlati\Desktop\tsp1\project.accdb";
        OleDbConnection dbConnect = new OleDbConnection();



        private void button1_Click(object sender, EventArgs e)
        {

            dbConnect.ConnectionString = conStr;
            string mySelect = "Insert INTO Type_ticket ( [time],[price] ) Values ( '"
            + textBox2.Text + "','" + textBox3.Text + "' )";
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
            string mySelect = "UPDATE Type_ticket SET [time] = '" + textBox2.Text + "',[price] = '" + textBox3.Text  + "' WHERE  id = " + textBox1.Text;
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
            string mySelect = "DELETE FROM Type_ticket WHERE id=" + textBox1.Text;
            OleDbCommand dbCmd = new OleDbCommand(mySelect, dbConnect);
            dbConnect.Open();
            dbCmd.CommandText = mySelect;
            dbCmd.Connection = dbConnect;
            dbCmd.ExecuteNonQuery();
            dbConnect.Close();
        }
    }
}
