using GenCode128;
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace tsp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        string conStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\zlati\Desktop\tsp1\project.accdb";
        OleDbConnection dbConnect = new OleDbConnection();

        private void Lines_load(object sender, EventArgs e)
        {
            dbConnect.ConnectionString = conStr;
            string mySelect = "select * from Bus_lines";
            dbConnect.Open();
            OleDbCommand dbCmd = new OleDbCommand(mySelect, dbConnect);
            dbCmd.CommandText = mySelect;
            dbCmd.Connection = dbConnect;
            OleDbDataReader reader = dbCmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox2.Items.Add(reader["active_bus_number"]);
            }
            dbConnect.Close();
        }


        private void Zone_load(object sender, EventArgs e)
        {
            dbConnect.ConnectionString = conStr;
            string mySelect = "select * from Zones";
            dbConnect.Open();
            OleDbCommand dbCmd = new OleDbCommand(mySelect, dbConnect);
            dbCmd.CommandText = mySelect;
            dbCmd.Connection = dbConnect;
            OleDbDataReader reader = dbCmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox4.Items.Add(reader["zone"]);
            }
            dbConnect.Close();
        }

        private void Type_load(object sender, EventArgs e)
        {
            dbConnect.ConnectionString = conStr;
            string mySelect = "select * from Type_ticket";
            dbConnect.Open();
            OleDbCommand dbCmd = new OleDbCommand(mySelect, dbConnect);
            dbCmd.CommandText = mySelect;
            dbCmd.Connection = dbConnect;
            OleDbDataReader reader = dbCmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["time"]);//+" мин");
            }
            dbConnect.Close();
        }

        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Lines_load(sender, e);
            Zone_load(sender, e);
            Type_load(sender, e);
            comboBox3.Items.Add("1 lv.");
            comboBox3.Items.Add("1,5 lv.");
            comboBox3.Items.Add("2 lv.");
        }
        public static string textout = "";
        public static Image myimg = null;
        private void button1_Click(object sender, EventArgs e)
        {

            if (label4.Text == ("Price "+comboBox3.Text)) {

                Business business = new Business();
                Zones zones = new Zones();
                Lines lines = new Lines();
                Type_ticket type_Ticket = new Type_ticket();

                string mySelect = "select * from Business where id =1";
                dbConnect.ConnectionString = conStr;
                dbConnect.Open();
                OleDbCommand dbCmd = new OleDbCommand(mySelect, dbConnect);
                dbCmd.CommandText = mySelect;
                dbCmd.Connection = dbConnect;
                OleDbDataReader reader = dbCmd.ExecuteReader();
                while (reader.Read())
                {
                    business.id = reader["id"].ToString();
                    business.name = reader["name"].ToString();
                    business.adress = reader["adress"].ToString();
                    business.phone = reader["phone"].ToString();
                }
                dbConnect.Close();
                string code = RandomString(12);
                try
                {
                    myimg = Code128Rendering.MakeBarcodeImage(code, int.Parse(2.ToString()), true);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, this.Text);
                }


                DateTime time_start = DateTime.Now;
                DateTime time_end;
                time_end = time_start.AddMinutes(Int32.Parse(comboBox1.Text));

                string id_zone = readinfo("select * from Zones where [zone] = '"+comboBox4.Text+"'");
                string id_line = readinfo("select * from Bus_lines where [active_bus_number] = '" + comboBox2.Text + "'");
                string id_time = readinfo("select * from Type_ticket where [time] = " + comboBox1.Text + "");

                textout = "Barcode : " + code +
                        "\nLine : " + comboBox2.Text +
                        "\nZone : " + comboBox4.Text +
                        "\nTime start : " + time_start +
                        "\nTime ends : " + time_end +
                        "\nFirm : " + business.name +
                        "\nAdress : " + business.adress +
                        "\nPhone : " + business.phone;

                dbConnect.ConnectionString = conStr;
                try
                {
                    dbConnect.Open();
                    string mySelect1 = "Insert INTO Purchase ( [barcod], issued_at, expire_at, type_ticket_id, zone_id, line_id, business_id) Values ( '"
                            + code +"', '"+time_start+"','"+ time_end+"','" + id_time + "','" + id_zone + "','" + id_line + "','" +business.id+ "' )";
                    OleDbCommand dbCmd1 = new OleDbCommand(mySelect1, dbConnect);
                    dbCmd1.CommandText = mySelect1;
                    dbCmd1.Connection = dbConnect;
                    dbCmd1.ExecuteNonQuery();
                    
                }
                catch (Exception)
                {
                    System.Windows.Forms.MessageBox.Show("idiot");
                }
                finally { dbConnect.Close(); }


                Form2 form2 = new Form2();
                form2.Show();

            }
            else
            {
                System.Windows.Forms.MessageBox.Show("wrong price");
            }
        }

        private void queryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_query form3 = new Form_query();
            form3.Show();
        }

        private void zoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_zone form_Zone = new Form_zone();
            form_Zone.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string price = null;
            string mySelect = "select * from Type_ticket where [time] = " + comboBox1.Text ;
            dbConnect.ConnectionString = conStr;
            dbConnect.Open();
            OleDbCommand dbCmd = new OleDbCommand(mySelect, dbConnect);
            dbCmd.CommandText = mySelect;
            dbCmd.Connection = dbConnect;
            OleDbDataReader reader = dbCmd.ExecuteReader();
            while (reader.Read())
            {
                price = reader["price"].ToString();
            }
            dbConnect.Close();
            label4.Text = "Price " + price.ToString() + " lv.";
        }
        private string readinfo(string mySelect)
        {
            string id =null;
            dbConnect.ConnectionString = conStr;
            dbConnect.Open();
            OleDbCommand dbCmd = new OleDbCommand(mySelect, dbConnect);
            dbCmd.CommandText = mySelect;
            dbCmd.Connection = dbConnect;
            OleDbDataReader reader = dbCmd.ExecuteReader();
            while (reader.Read())
            {
                id = reader["id"].ToString();
            }
            dbConnect.Close();
            return id;
        }

        private void typeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_type_ticket form_Type_Ticket = new Form_type_ticket();
            form_Type_Ticket.Show();
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_bus_line form_Bus_Line = new Form_bus_line();
            form_Bus_Line.Show();
        }

        private void busToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_business form_Business = new Form_business();
            form_Business.Show();
        }
    }
}

