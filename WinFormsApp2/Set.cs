using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

    public class Set
    {

    public void connect()
    {
        string connstring = "Data Source = LAPTOP-1IJP7QH2\\SQLEXPRESS;Initial Catalog=willdb;Integrated Security=true";
        SqlConnection con = new SqlConnection(connstring);
        con.Open();
        string query = "Select * from Football_Teams";
        SqlCommand cmd = new SqlCommand(query,con);
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read()) 
        { 
            string output = "Output = "+reader.GetValue(0)+"-"+reader.GetValue(1) + "-" + reader.GetValue(2);
            Console.WriteLine(output);
        }
    }

    public double[] clash(double[] yourteam, double[] otherteam)
    {
        yourteam[0] = yourteam[0] + (otherteam[5]/2);
        yourteam[1] = yourteam[1] + otherteam[7] + (otherteam[5]/4);
        yourteam[2] = yourteam[2] + otherteam[6];
        yourteam[3] = yourteam[3] + otherteam[7];
        yourteam[4] = yourteam[4] + otherteam[5];

        return yourteam;
    }

    public double value(double[] yourteam)
    {
        double sum = 0;
        for(int i = 0; i < 5; i++) 
        { 
            sum = sum + yourteam[i];
        }
        sum = sum + yourteam[8];
        return sum; 
    }

    public double[] get_numb(string[] grades, double[] numb)
    {
        string part = "";
        string pos = "";
        for (int i = 0; i < grades.Length; i++)
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
            if ((i < 8) && (i >= 5)) 
            {
                part = "Def";
                pos = "";
            }
            if (i == 8)
            {
                part = "Kick";
                pos = "";
            }
            if (i == 9)
            {
                part = "Coach";
                pos = "";
            }

            numb[i] = getteam(grades[i], part, pos);
        }

        for (int x = 0; x < grades.Length; x++)
        {
            if (x < 8)
            { 
                numb[x] = numb[x] * numb[9];
            }
        }

        return numb;
    }


    public double momenutum(double sum, string teampart)
    {
           double value = 0;
           switch (teampart)
           {
              case "Very Good":
                 value = 1.3;
                 break;
              case "Good":
                  value = 1.1;
                  break;
              case "Neutral":
                  value = 1;
                  break;
              case "Bad":
                  value = 0.9;
                  break;
              case "Low":
                  value = 0.75;
                  break;
                }
           return sum * value;
    }


    public double Away_Travel(double sum, int time)
    {
        double value = 0;
           switch (time)
           {
              case 0:
                value = 0.95;
                break;
              case 1:
                value = 0.9;
                break;
              case 2:
                value = 0.85;
                break;
              case 3:
                value = 0.8;
                break;
           }        
        return sum * value;
    }

            double getteam(string grade, string teampart, string pos)
            {
                double value = 0;

                switch (grade)
                {
                    case "A+":
                        switch (teampart)
                        {
                            case "Off":
                                value = 9;
                                break;
                            case "Def":
                                value = -7;
                                break;
                            case "Kick":
                                value = 3.5;
                                break;
                            case "Coach":
                                value = 2.4;
                                break;
                        }
                        break;
                    case "A":
                        switch (teampart)
                        {
                            case "Off":
                                value = 8;
                                break;
                            case "Def":
                                value = -6;
                                break;
                            case "Kick":
                                value = 3;
                                break;
                            case "Coach":
                                value = 2.2;
                                break;
                        }
                        break;
                    case "A-":
                        switch (teampart)
                        {
                            case "Off":
                                value = 7;
                                break;
                            case "Def":
                                value = -5;
                                break;
                            case "Kick":
                                value = 2.5;
                                break;
                            case "Coach":
                                value = 2.0;
                                break;
                        }
                        break;
                    case "B+":
                        switch (teampart)
                        {
                            case "Off":
                                value = 5;
                                break;
                            case "Def":
                                value = -4;
                                break;
                            case "Kick":
                                value = 2;
                                break;
                            case "Coach":
                                value = 1.8;
                                break;
                        }
                        break;
                    case "B":
                        switch (teampart)
                        {
                            case "Off":
                                value = 4;
                                break;
                            case "Def":
                                value = -3;
                                break;
                            case "Kick":
                                value = 1.5;
                                break;
                            case "Coach":
                                value = 1.6;
                                break;
                        }
                        break;
                    case "B-":
                        switch (teampart)
                        {
                            case "Off":
                                value = 3;
                                break;
                            case "Def":
                                value = -2;
                                break;
                            case "Kick":
                                value = 1;
                                break;
                            case "Coach":
                                value = 1.4;
                                break;
                        }
                        break;
                    case "C+":
                        switch (teampart)
                        {
                            case "Off":
                                value = 1;
                                break;
                            case "Def":
                                value = -1;
                                break;
                            case "Kick":
                                value = 0.5;
                                break;
                            case "Coach":
                                value = 1.2;
                                break;
                        }
                        break;
                    case "C":
                        switch (teampart)
                        {
                            case "Off":
                                value = 0;
                                break;
                            case "Def":
                                value = 0;
                                break;
                            case "Kick":
                                value = 0;
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
                                value = -1;
                                break;
                            case "Def":
                                value = 1;
                                break;
                            case "Kick":
                                value = -0.5;
                                break;
                            case "Coach":
                                value = 0.9;
                                break;
                        }
                        break;
                    case "D+":
                        switch (teampart)
                        {
                            case "Off":
                                value = -3;
                                break;
                            case "Def":
                                value = 2;
                                break;
                            case "Kick":
                                value = -1;
                                break;
                            case "Coach":
                                value = 0.8;
                                break;
                        }
                        break;
                    case "D":
                        switch (teampart)
                        {
                            case "Off":
                                value = -4;
                                break;
                            case "Def":
                                value = 3;
                                break;
                            case "Kick":
                                value = -1.5;
                                break;
                            case "Coach":
                                value = 0.7;
                                break;
                        }
                        break;
                    case "D-":
                        switch (teampart)
                        {
                            case "Off":
                                value = -5;
                                break;
                            case "Def":
                                value = 4;
                                break;
                            case "Kick":
                                value = -2;
                                break;
                            case "Coach":
                                value = 0.6;
                                break;
                        }
                        break;
                    case "F":
                        switch (teampart)
                        {
                            case "Off":
                                value = -7;
                                break;
                            case "Def":
                                value = 5;
                                break;
                            case "Kick":
                                value = -2.5;
                                break;
                            case "Coach":
                                value = 0.5;
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
        }
    

