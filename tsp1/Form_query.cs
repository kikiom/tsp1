using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace tsp1
{
    public partial class Form_query : Form
    {
        public Form_query()
        {
            InitializeComponent();
        }
        string conStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\zlati\Desktop\tsp1\project.accdb";
        OleDbConnection dbConnect = new OleDbConnection();

        private void button1_Click(object sender, EventArgs e)
        {
            string mySelect = "select * from Query1 " ;
            DisplayData(mySelect);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mySelect = "select * from Query2 ";
            DisplayData(mySelect);
        }

        private void DisplayData(string mySelect)
        {
            
            dbConnect.ConnectionString = conStr;
            dbConnect.Open();
            OleDbDataAdapter adapt = new OleDbDataAdapter(mySelect, dbConnect);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dbConnect.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string mySelect = "select * from Query3 ";
            DisplayData(mySelect);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string mySelect = "select * from Query5 ";
            DisplayData(mySelect);
            chart1.Series.Clear();

            // Set palette
            chart1.Palette = ChartColorPalette.EarthTones;

            // Set title
            chart1.Titles.Add("Bus Prihod");

            List<string> list_line = new List<string>();
            List<double> ints= new List<double>();
            dbConnect.ConnectionString = conStr;
            string mySelect1 = "Select * from Query5";
            dbConnect.Open();
            OleDbCommand dbCmd = new OleDbCommand(mySelect1, dbConnect);
            dbCmd.CommandText = mySelect;
            dbCmd.Connection = dbConnect;
            OleDbDataReader reader = dbCmd.ExecuteReader();
            while (reader.Read())
            {
                list_line.Add( reader["active_bus_number"].ToString() );
                ints.Add(double.Parse( reader["SumOfprice"].ToString() ) );
            }

            dbConnect.Close();
            string[] seriesArray = list_line.ToArray();
            double[] pointsArray = ints.ToArray();
            // Add series.
            for (int i = 0; i < seriesArray.Length; i++)
            {
                Series series = chart1.Series.Add(seriesArray[i]);
                series.Points.Add(pointsArray[i]);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string mySelect = "select * from Query4 ";
            DisplayData(mySelect);
        }
    }
}
