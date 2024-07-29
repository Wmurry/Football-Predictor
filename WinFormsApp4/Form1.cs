using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;

namespace WinFormsApp4
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
                        BasecomboBox.Items.Add(reader.GetString(i));
                    }
                }
                conn.Close();
            }
            catch
            {

            }
        }


        public int combobox_search(ComboBox combo, string str)
        {
            for (int i = 0; combo.Items.Count > 0; i++)
            {
                if (combo.Items[i].ToString() == str.Trim())
                {
                    return i;
                }
            }
            return -2;
        }


        public int timesearch(int str)
        {
            return str - 1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand sc = new SqlCommand($"Select (Team_Name),City,Coach,Timezone,QB,RB,WR,TE,OL,DL,LB,CB,S,K,Momentum from Football_Teams Where (Team_Name) = '{BasecomboBox.Text}'", conn);
                SqlDataReader reader;
                reader = sc.ExecuteReader();
                DataTable dt = new DataTable();
                while (reader.Read())
                {
                    TeamtextBox.Text = reader.GetString(0);
                    CitytextBox.Text = reader.GetString(1);
                    CoachcomboBox.SelectedIndex = combobox_search(CoachcomboBox, reader.GetString(2));
                    TimezonecomboBox.SelectedIndex = timesearch((int)reader.GetValue(3));
                    QBcomboBox.SelectedIndex = combobox_search(QBcomboBox, reader.GetString(4));
                    RBcomboBox.SelectedIndex = combobox_search(RBcomboBox, reader.GetString(5));
                    WRcomboBox.SelectedIndex = combobox_search(WRcomboBox, reader.GetString(6));
                    TEcomboBox.SelectedIndex = combobox_search(TEcomboBox, reader.GetString(7));
                    OLcomboBox.SelectedIndex = combobox_search(OLcomboBox, reader.GetString(8));
                    DLcomboBox.SelectedIndex = combobox_search(DLcomboBox, reader.GetString(9));
                    LBcomboBox.SelectedIndex = combobox_search(LBcomboBox, reader.GetString(10));
                    CBcomboBox.SelectedIndex = combobox_search(CBcomboBox, reader.GetString(11));
                    ScomboBox.SelectedIndex = combobox_search(ScomboBox, reader.GetString(12));
                    KcomboBox.SelectedIndex = combobox_search(KcomboBox, reader.GetString(13));
                    MomcomboBox.SelectedIndex = combobox_search(MomcomboBox, reader.GetString(14));
                }
                TeamtextBox.Enabled = true;
                CitytextBox.Enabled = true;
                CoachcomboBox.Enabled = true;
                TimezonecomboBox.Enabled = true;
                QBcomboBox.Enabled = true;
                RBcomboBox.Enabled = true;
                WRcomboBox.Enabled = true;
                TEcomboBox.Enabled = true;
                OLcomboBox.Enabled = true;
                DLcomboBox.Enabled = true;
                LBcomboBox.Enabled = true;
                CBcomboBox.Enabled = true;
                ScomboBox.Enabled = true;
                KcomboBox.Enabled = true;
                MomcomboBox.Enabled = true;
                button1.Visible = true;
                conn.Close();
            }
            catch
            {

            }
        }

        bool pre_editor()
        {
            if ((TeamtextBox.Text == "") || (TeamtextBox.Text == null))
            {
                string box_msg = "The team must have a name";
                string box_title = "Error";
                MessageBox.Show(box_msg, box_title, MessageBoxButtons.OK);
                return false;
            }
            if ((CitytextBox.Text == "") || (CitytextBox.Text == null))
            {
                string box_msg = "The team must have a city";
                string box_title = "Error";
                MessageBox.Show(box_msg, box_title, MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void editor()
        {
            string command = $"UPDATE Football_Teams " +
                $"SET Team_Name = '{TeamtextBox.Text}'," +
                $"City = '{CitytextBox.Text}'," +
                $"Timezone = {TimezonecomboBox.SelectedIndex + 1}," +
                $"QB = '{QBcomboBox.Text}'," +
                $"RB = '{RBcomboBox.Text}'," +
                $"WR = '{WRcomboBox.Text}'," +
                $"TE = '{TEcomboBox.Text}'," +
                $"OL = '{OLcomboBox.Text}'," +
                $"LB = '{LBcomboBox.Text}'," +
                $"CB = '{CBcomboBox.Text}'," +
                $"S = '{ScomboBox.Text}'," +
                $"K = '{KcomboBox.Text}'," +
                $"Momentum = '{MomcomboBox.Text}'" +
                $"Where (Team_Name) = '{BasecomboBox.Text}'";
            try
            {
                conn.Open();
                SqlCommand sc = new SqlCommand(command, conn);
                SqlDataReader reader;
                reader = sc.ExecuteReader();
                conn.Close();
                ReadtextBox.Text = command;
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pre_editor())
            {
                DialogResult d;
                string box_msg = "Do you want to save these changes";
                string box_msg2 = "The changes have been saved";
                string box_title = "Save";
                d = MessageBox.Show(box_msg, box_title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    editor();
                    MessageBox.Show(box_msg2, box_title, MessageBoxButtons.OK);
                }
            }
        }
    }
}