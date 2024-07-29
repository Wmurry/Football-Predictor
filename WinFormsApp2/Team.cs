using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    public class Team
    {
        public string[] Grades = { "", "", "", "", "", "", "", "", "", "", "" };
        public double[] Numbers = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 , 0};
        public double Value = 0;
        public string Momentum = "Neutral";
        public int TimeZone = 0;


        SqlConnection conn = new SqlConnection("Data Source = LAPTOP-1IJP7QH2\\SQLEXPRESS;Initial Catalog=willdb;Integrated Security=true");
        
        public void GetDataFromDatabase(string name)
        {
            try
            {
                conn.Open();
                SqlCommand sc1 = new SqlCommand($"SELECT QB,RB,WR,TE,OL,DL,LB,CB,S,K,Coach,Momentum,Timezone" +
                    $" FROM Football_Teams WHERE Team_Name = '{name}'", conn);
                SqlDataReader reader;
                reader = sc1.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < 11; i++)
                    {
                        Grades[i] = reader.GetString(i);
                    }
                    Momentum = reader.GetString(11);
                    TimeZone = (int)reader.GetValue(12);
                }
                conn.Close();
            }
            catch
            {

            }
        }

        public void get_numbers()
        {
            string part = "";
            string pos = "";
            for (int i = 0; i < Grades.Length; i++)
            {
                if (i < 5)
                {
                    part = "Off";
                    switch (i)
                    {
                        case 0:
                            pos = "QB";
                            break;
                        case 1:
                            pos = "RB";
                            break;
                        case 2:
                            pos = "WR";
                            break;
                        case 3:
                            pos = "TE";
                            break;
                        case 4:
                            pos = "OL";
                            break;
                    }
                }
                if ((i < 9) && (i >= 5))
                {
                    part = "Def";
                    pos = "";
                }
                if (i == 9)
                {
                    part = "Kick";
                    pos = "";
                }
                if (i == 10)
                {
                    part = "Coach";
                    pos = "";
                }

                Numbers[i] = getteam(Grades[i], part, pos);
            }

            for (int x = 0; x < Grades.Length; x++)
            {
                if (x < 9)
                {
                    Numbers[x] = Numbers[x] * Numbers[10];
                }
            }
            momenutum();
        }


        double getteam(string grade, string teampart, string pos)
        {
            double value = 0;

            switch (grade.Trim())
            {
                case "A+":
                    switch (teampart)
                    {
                        case "Off":
                            value = 15;
                            break;
                        case "Def":
                            value = 15;
                            break;
                        case "Kick":
                            value = 6;
                            break;
                        case "Coach":
                            value = 1.6;
                            break;
                    }
                    break;
                case "A":
                    switch (teampart)
                    {
                        case "Off":
                            value = 14;
                            break;
                        case "Def":
                            value = 14;
                            break;
                        case "Kick":
                            value = 5.66;
                            break;
                        case "Coach":
                            value = 1.5;
                            break;
                    }
                    break;
                case "A-":
                    switch (teampart)
                    {
                        case "Off":
                            value = 13;
                            break;
                        case "Def":
                            value = 13;
                            break;
                        case "Kick":
                            value = 5.33;
                            break;
                        case "Coach":
                            value = 1.4;
                            break;
                    }
                    break;
                case "B+":
                    switch (teampart)
                    {
                        case "Off":
                            value = 12.5;
                            break;
                        case "Def":
                            value = 12.5;
                            break;
                        case "Kick":
                            value = 5;
                            break;
                        case "Coach":
                            value = 1.35;
                            break;
                    }
                    break;
                case "B":
                    switch (teampart)
                    {
                        case "Off":
                            value = 11.5;
                            break;
                        case "Def":
                            value = 11.5;
                            break;
                        case "Kick":
                            value = 4.66;
                            break;
                        case "Coach":
                            value = 1.25;
                            break;
                    }
                    break;
                case "B-":
                    switch (teampart)
                    {
                        case "Off":
                            value = 10.5;
                            break;
                        case "Def":
                            value = 10.5;
                            break;
                        case "Kick":
                            value = 4.33;
                            break;
                        case "Coach":
                            value = 1.15;
                            break;
                    }
                    break;
                case "C+":
                    switch (teampart)
                    {
                        case "Off":
                            value = 10;
                            break;
                        case "Def":
                            value = 10;
                            break;
                        case "Kick":
                            value = 4;
                            break;
                        case "Coach":
                            value = 1.1;
                            break;
                    }
                    break;
                case "C":
                    switch (teampart)
                    {
                        case "Off":
                            value = 9;
                            break;
                        case "Def":
                            value = 9;
                            break;
                        case "Kick":
                            value = 3.66;
                            break;
                        case "Coach":
                            value = 1;
                            break;
                    }
                    break;
                case "C-":
                    switch (teampart)
                    {
                        case "Off":
                            value = 8;
                            break;
                        case "Def":
                            value = 8;
                            break;
                        case "Kick":
                            value = 3.33;
                            break;
                        case "Coach":
                            value = 0.95;
                            break;
                    }
                    break;
                case "D+":
                    switch (teampart)
                    {
                        case "Off":
                            value = 7.5;
                            break;
                        case "Def":
                            value = 7.5;
                            break;
                        case "Kick":
                            value = 3;
                            break;
                        case "Coach":
                            value = 0.9;
                            break;
                    }
                    break;
                case "D":
                    switch (teampart)
                    {
                        case "Off":
                            value = 6.5;
                            break;
                        case "Def":
                            value = 6.5;
                            break;
                        case "Kick":
                            value = 2.66;
                            break;
                        case "Coach":
                            value = 0.85;
                            break;
                    }
                    break;
                case "D-":
                    switch (teampart)
                    {
                        case "Off":
                            value = 5.5;
                            break;
                        case "Def":
                            value = 5.5;
                            break;
                        case "Kick":
                            value = 2.33;
                            break;
                        case "Coach":
                            value = 0.8;
                            break;
                    }
                    break;
                case "F":
                    switch (teampart)
                    {
                        case "Off":
                            value = 5;
                            break;
                        case "Def":
                            value = 5;
                            break;
                        case "Kick":
                            value = 2;
                            break;
                        case "Coach":
                            value = 0.75;
                            break;
                    }
                    break;
            }

            switch (pos)
            {
                case "QB":
                    value = value * 1.3;
                    break;
                case "RB":
                    value = value * 1.15;
                    break;
                case "WR":
                    value = value * 1.2;
                    break;
                case "TE":
                    value = value * 1.10;
                    break;
                case "OL":
                    value = value * 1.25;
                    break;
            }
            return value;
        }

        public void getvalue()
        {
            double sum = 0;
            for (int i = 0; i < 5; i++)
            {
                sum = sum + Numbers[i];
            }
            sum = sum + Numbers[9];
            Value = sum;
        }

        public void momenutum()
        {
            Momentum = Momentum.Trim();

            double boost = 0;
            switch (Momentum)
            {
                case "Very Good":
                    boost = 1.3;
                    break;
                case "Good":
                    boost = 1.1;
                    break;
                case "Neutral":
                    boost = 1;
                    break;
                case "Bad":
                    boost = 0.9;
                    break;
                case "Low":
                    boost = 0.75;
                    break;
            }

            for (int x = 0; x < Grades.Length; x++)
            {
                if (x < 9)
                {
                    Numbers[x] = Numbers[x] * boost;
                }
            }
        }

        public void Away_Travel(int time)
        {
            double boost = 0;
            switch (time)
            {
                case -1:
                    boost = 1;
                    break;
                case 0:
                    boost= 0.95;
                    break;
                case 1:
                    boost = 0.9;
                    break;
                case 2:
                    boost = 0.85;
                    break;
                case 3:
                    boost = 0.8;
                    break;
                case 4:
                    boost = 0.75;
                    break;
            }

            for (int x = 0; x < Grades.Length; x++)
            {
                if (x < 9)
                {
                    Numbers[x] = Numbers[x] * boost;
                }
            }
        }
    }
}
