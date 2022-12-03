using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace tsp1
{
    internal class Load_data
    {
        string conStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\zlati\Desktop\tsp1\project.accdb";
        OleDbConnection dbConnect = new OleDbConnection();

        private void Lines_load(object sender, EventArgs e)
        {
            dbConnect.ConnectionString = conStr;
            string mySelect = "select * from lines_q";
            dbConnect.Open();
            OleDbCommand dbCmd = new OleDbCommand(mySelect, dbConnect);
            dbCmd.CommandText = mySelect;
            dbCmd.Connection = dbConnect;
            OleDbDataReader reader = dbCmd.ExecuteReader();
            while (reader.Read())
            {
                //comboBox2.Items.Add(reader["active_bus_number"]);
            }
            dbConnect.Close();
        }


        private DataTable Zone_load()
        {
            /* dbConnect.ConnectionString = conStr;
             string mySelect = "select * from zone_q";
             dbConnect.Open();
             OleDbCommand dbCmd = new OleDbCommand(mySelect, dbConnect);
             dbCmd.CommandText = mySelect;
             dbCmd.Connection = dbConnect;
             OleDbDataReader reader = dbCmd.ExecuteReader();

             dbConnect.Close();
             return reader;*/
            string mySelect = "select * from lines_q";
            dbConnect.ConnectionString = conStr;
            dbConnect.Open();
            OleDbDataAdapter adapt = new OleDbDataAdapter(mySelect, dbConnect);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            dbConnect.Close();
            return dt;
        }

        private void Type_load(object sender, EventArgs e)
        {
            dbConnect.ConnectionString = conStr;
            string mySelect = "select * from type_q";
            dbConnect.Open();
            OleDbCommand dbCmd = new OleDbCommand(mySelect, dbConnect);
            dbCmd.CommandText = mySelect;
            dbCmd.Connection = dbConnect;
            OleDbDataReader reader = dbCmd.ExecuteReader();
            while (reader.Read())
            {
                //comboBox1.Items.Add(reader["time"] + " мин");
            }
            dbConnect.Close();
        }
    }
}
