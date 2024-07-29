using System.Data;
using System.Data.SqlClient;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source = LAPTOP-1IJP7QH2\\SQLEXPRESS;Initial Catalog=willdb;Integrated Security=true");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand sc = new SqlCommand("Select (Team_Name) from Football_Teams", conn);
                SqlDataReader reader;
                reader = sc.ExecuteReader();
                DataTable dt = new DataTable();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        comboBox1.Items.Add(reader.GetString(i));
                        comboBox2.Items.Add(reader.GetString(i));
                    }
                }
                conn.Close();
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int error = 0;

            if ((comboBox1.Text == null) || (comboBox1.Text == ""))
            {
                MessageBox.Show("You need to pick a away team");
                error = 1;
            }
            if ((comboBox2.Text == null) || (comboBox2.Text == ""))
            {
                MessageBox.Show("You need to pick a home team");
                error = 2;
            }
            if (comboBox1.Text == comboBox2.Text)
            {
                MessageBox.Show("A team cannot face themselves");
                error = 3;
            }
            if (error == 0)
            {
                works();
            }
        }

        private void works()
        {
            Team Away = new Team();
            Team Home = new Team();

            Away.GetDataFromDatabase(comboBox1.Text);
            Home.GetDataFromDatabase(comboBox2.Text);

            Away.get_numbers();
            Home.get_numbers();
            if (checkBox2.Checked == false)
            {
                if (checkBox1.Checked == true)
                {
                    Away.Away_Travel(Math.Abs(Home.TimeZone - Away.TimeZone) + 1);
                }
                else
                {
                    Away.Away_Travel(Math.Abs(Home.TimeZone - Away.TimeZone));
                }
            }
            else
            {
                Away.Away_Travel(-1);
            }
            Away.Numbers = clash(Away.Numbers, Home.Numbers);
            Home.Numbers = clash(Home.Numbers, Away.Numbers);
            Away.getvalue();
            Home.getvalue();

            if (Away.Value > Home.Value)
            {
                MessageBox.Show($"{comboBox1.Text} Wins");
            }
            if (Away.Value < Home.Value)
            {
                MessageBox.Show($"{comboBox2.Text} Wins");
            }
            if (Away.Value == Home.Value)
            {
                MessageBox.Show("Tie Game");
            }
        }

        public double[] clash(double[] yourteam, double[] otherteam)
        {
            yourteam[0] = yourteam[0] - (otherteam[5] / 4) - (otherteam[6] / 8) - (otherteam[7] / 8) - (otherteam[8] / 4);
            yourteam[1] = yourteam[1] - (otherteam[7] / 2) - (otherteam[5] / 4);
            yourteam[2] = yourteam[2] - (otherteam[6] / 2) - (otherteam[8] / 4);
            yourteam[3] = yourteam[3] - (otherteam[7] / 2) - (otherteam[8] / 4);
            yourteam[4] = yourteam[4] - (otherteam[5] / 2) - (otherteam[6] / 4);

            return yourteam;
        }

    }
}