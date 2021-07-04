using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Absence
{
    /// <summary>
    /// Logique d'interaction pour Fiche.xaml
    /// </summary>
    public partial class Fiche : Window
    {
        Connexion connexion;
        private CalenderCombo[,] jours;
        private String matricule;
        string[] absence = { "AA", "AO", "A", "O" };
        string[] conge_spec = { "CM", "CMLD", "CA" };
        public Fiche(String mat)
        {

            //this.Width = SystemParameters.PrimaryScreenWidth - 20;
            InitializeComponent();
            this.matricule = mat;
            connexion = new Connexion();
            for (int i = 1962; i <= DateTime.Today.Year+4; i++)
                years.Items.Add(i.ToString());
            years.Text = DateTime.Today.Year.ToString();
            draw();
             fill();
        }

        private void fill()
        {
            IDictionary<string, float> count = new Dictionary<string, float>();
            foreach (string type in absence) count[type] = 0;
            foreach (string type in conge_spec) count[type] = 0;

            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 31; j++)
                    if (Function.isDate(int.Parse(years.Text), i+1, j+1))
                        jours[j, i].Text = "";


            connexion.open();
            MySqlCommand cmd = new MySqlCommand("SELECT type, DAY(date_absence) as day, MONTH(date_absence) as month FROM absence WHERE matricule=@mat and YEAR(date_absence)=@year", connexion.getConnexion());
            cmd.Parameters.AddWithValue("@mat", this.matricule);
            int yr = int.Parse(years.Text);
            cmd.Parameters.AddWithValue("@year", yr);
            cmd.Prepare();
            MySqlDataReader result = cmd.ExecuteReader();
            while (result.Read())
            {
                jours[result.GetUInt32("day") - 1, result.GetUInt32("month") - 1].SelectedValue = result["type"].ToString();
                jours[result.GetUInt32("day") - 1, result.GetUInt32("month") - 1].Text = result["type"].ToString();
                count[result["type"].ToString()]++;
            }
            result.Close();
            DateTime date_debut,date_fin;
            cmd = new MySqlCommand(@"SELECT type, DAY(date_debut) as day, MONTH(date_debut) month, YEAR(date_debut) year,
                                    DAY(date_fin) as day2, MONTH(date_fin) month2, YEAR(date_fin) as year2 FROM conge_spec WHERE matricule=@mat and (YEAR(date_debut)=@year or YEAR(date_fin)=@year)", connexion.getConnexion());
            cmd.Parameters.AddWithValue("@mat", this.matricule);
            cmd.Parameters.AddWithValue("@year", yr);
            cmd.Prepare();
            result = cmd.ExecuteReader();
            while (result.Read())
            {
                date_debut = new DateTime(result.GetInt16("year"), result.GetUInt16("month"), result.GetUInt16("day"));
                date_fin = new DateTime(result.GetInt16("year2"), result.GetUInt16("month2"), result.GetUInt16("day2"));
                while (date_debut <= date_fin)
                {
                    if(date_debut.Year == yr)
                    {
                        jours[date_debut.Day - 1, date_debut.Month - 1].SelectedValue = result["type"].ToString();
                        jours[date_debut.Day - 1, date_debut.Month - 1].IsEnabled=false;
                        count[result["type"].ToString()]++;
                    }
                        date_debut = date_debut.Date.AddDays(1);
                }
                //jours[result.GetUInt32("day") - 1, result.GetUInt32("month") - 1].SelectedValue = result["type"].ToString();
            }
            ao.Content = (count["AO"] + count["O"]/2).ToString();
            aa.Content = (count["AA"] + count["A"] / 2).ToString();
            cm.Content = count["CM"].ToString();
            connexion.close();
        }

        private void draw()
        {
           // if (DateTime.IsLeapYear(int.Parse(years.te))) MessageBox.Show("yes") ;
            calender.RowDefinitions.Clear();
            calender.ColumnDefinitions.Clear();
            calender.Children.Clear();
            jours = new CalenderCombo[31, 12]; // contient le tableau de jours

            ColumnDefinition gridCol1 = new ColumnDefinition();
            gridCol1.Width = new GridLength(2, GridUnitType.Star);

            calender.ColumnDefinitions.Add(gridCol1);

            for (int i = 0; i < 31; i++)
            {
                ColumnDefinition gridCol = new ColumnDefinition();
                gridCol.Width = new GridLength(1, GridUnitType.Star);
                calender.ColumnDefinitions.Add(gridCol);
            }


            // Create Rows
            for (int i = 0; i < 13; i++)
            {
                RowDefinition gridRow = new RowDefinition();
                gridRow.Height = new GridLength(40); // GridLength(45);
                calender.RowDefinitions.Add(gridRow);
            }


            // Add days(column) header

            CalenderHeader txtBlock1 = new CalenderHeader("M/J");
            Grid.SetRow(txtBlock1, 0);
            Grid.SetColumn(txtBlock1, 0);
            calender.Children.Add(txtBlock1);


            for (int i = 1; i < 32; i++)
            {
                CalenderHeader txtBlock = new CalenderHeader(i.ToString());
                Grid.SetRow(txtBlock, 0);
                Grid.SetColumn(txtBlock, i);
                calender.Children.Add(txtBlock);
            }

            // Add mois(row) header
            for (int i = 1; i < 13; i++)
            {
                CalenderHeader txtBlock = new CalenderHeader(i.ToString());
                Grid.SetRow(txtBlock, i);
                Grid.SetColumn(txtBlock, 0);
                calender.Children.Add(txtBlock);
            }
            
            for (int i = 1; i < 13; i++)
                for (int j = 1; j < 32; j++)
                {
                    if(Function.isDate(int.Parse(years.Text),i,j))
                    {
                    CalenderCombo absenceType = new CalenderCombo();
                    jours[j - 1, i - 1] = absenceType;
                    Grid.SetRow(absenceType, i);
                    Grid.SetColumn(absenceType, j);
                    calender.Children.Add(absenceType);
                    }
                }
            
        }

        private void updateDate_Click(object sender, RoutedEventArgs e)
        {
            draw();
            fill();
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            string value = "";
            string date="";
            string type = "";
            int nbr_jours = 0;
            DateTime date_debut=new DateTime(),date_fin= new DateTime();
            connexion.open();

            MySqlCommand commande = connexion.CreateCommand();
            commande.CommandText = @"delete from absence where matricule=@matricule and YEAR(date_absence)=@year";
            commande.Parameters.AddWithValue("@year", years.Text);
            commande.Parameters.AddWithValue("@matricule", matricule);
            commande.Prepare();
            commande.ExecuteNonQuery();

            /*
            MySqlCommand commande = connexion.CreateCommand();
            commande.CommandText = @"update conge_spec set date_debut=@date where matricule=@matricule and YEAR(date_debut)=@year and YEAR(date_fin)>@year";
            commande.Parameters.AddWithValue("@date", new DateTime(int.Parse(years.Text) + 1,1,1));
            commande.Parameters.AddWithValue("@year", years.Text);
            commande.Parameters.AddWithValue("@matricule", matricule);
            commande.Prepare();
            commande.ExecuteNonQuery();

            commande = connexion.CreateCommand();
            commande.CommandText = @"update conge_spec set date_fin=@date where matricule=@matricule and YEAR(date_fin)=@year and YEAR(date_debut)<@year";
            commande.Parameters.AddWithValue("@date", new DateTime(int.Parse(years.Text),1,1));
            commande.Parameters.AddWithValue("@year", years.Text);
            commande.Parameters.AddWithValue("@matricule", matricule);
            commande.Prepare();
            commande.ExecuteNonQuery();

            commande = connexion.CreateCommand();
                commande.CommandText = @"delete from conge_spec where matricule=@matricule and (YEAR(date_debut)=@year and YEAR(date_fin))";
                commande.Parameters.AddWithValue("@year", years.Text);
                commande.Parameters.AddWithValue("@matricule", matricule);
                commande.Prepare();
                commande.ExecuteNonQuery();

        */

            for (int i = 1; i < 13; i++)
                for (int j = 1; j < 32; j++)
                {
                    if (Function.isDate(int.Parse(years.Text), i, j))
                    {

                        value = jours[j - 1, i - 1].Text;

                        if(absence.Contains(value))
                            {
                                date= years.Text+"-"+i.ToString()+"-"+j.ToString();
                                commande=connexion.CreateCommand();
                                commande.CommandText = @"insert into absence value(null,@matricule,@type,@date)";
                                commande.Parameters.AddWithValue("@matricule", matricule);
                                commande.Parameters.AddWithValue("@type", value.ToUpper());
                                commande.Parameters.AddWithValue("@date", date);
                                commande.Prepare();
                                commande.ExecuteNonQuery();
                            }

                       if (conge_spec.Contains(value))
                            {
                                if (type == "") { type = value; date_debut=new DateTime(int.Parse(years.Text),i,j); nbr_jours = 0; }
                                else
                                {
                            

                                    if (type == value) nbr_jours++;
                                    else
                                    {
                                
                                        date_fin = date_debut.Date.AddDays(nbr_jours);
                                        commande = connexion.CreateCommand();
                                        commande.CommandText = @"insert into conge_spec values (null,@matricule,@type,@date1,@date2)";
                                        commande.Parameters.AddWithValue("@matricule", matricule);
                                        commande.Parameters.AddWithValue("@type", type);
                                        commande.Parameters.AddWithValue("@date1", date_debut.Date);
                                        commande.Parameters.AddWithValue("@date2", date_fin.Date);
                                        commande.Prepare();
                                        commande.ExecuteNonQuery();
                                        type = value;  nbr_jours = 0;
                                    }
                                }

                            }
                    else if (type != "")
                            {
                            date_fin = date_debut.Date.AddDays(nbr_jours);
                            commande = connexion.CreateCommand();
                            commande.CommandText = @"insert into conge_spec values (null,@matricule,@type,@date1,@date2)";
                            commande.Parameters.AddWithValue("@matricule", matricule);
                            commande.Parameters.AddWithValue("@type", type);
                            commande.Parameters.AddWithValue("@date1", date_debut.Date);
                            commande.Parameters.AddWithValue("@date2", date_fin.Date);
                            commande.Prepare();
                            commande.ExecuteNonQuery();
                            type = ""; nbr_jours = 0; 
                    }

                }
            }
            connexion.close();
            fill();

        }

        private void minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
