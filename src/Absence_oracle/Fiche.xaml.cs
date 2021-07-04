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
using Oracle.DataAccess.Client;  using Oracle.DataAccess.Types;

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
        string errorMessage = "";
        public Fiche(String mat)
        {

            //this.Width = SystemParameters.PrimaryScreenWidth - 20;
            InitializeComponent();
            this.matricule = mat;
            connexion = new Connexion();
            for (int i = 1962; i <= DateTime.Today.Year+4; i++)
                years.Items.Add(i.ToString());
            years.Text = DateTime.Today.Year.ToString();


            date_debut_form.DisplayDate = DateTime.Today;
            date_debut_form.Text = DateTime.Today.ToString();
            date_fin_form.DisplayDate = DateTime.Today.AddDays(1);
            date_fin_form.Text = DateTime.Today.AddDays(1).ToString();

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
            string req = @"SELECT type, EXTRACT(DAY FROM  date_absence) as day, EXTRACT(MONTH FROM  date_absence) as month
                            FROM absence WHERE matricule=:mat and EXTRACT(YEAR FROM  date_absence)=:year";
            OracleCommand cmd = connexion.CreateCommand(req);
            cmd.Parameters.Add(new OracleParameter(":mat", this.matricule));
            long yr = long.Parse(years.Text);
            cmd.Parameters.Add(new OracleParameter(":year", OracleDbType.Long)).Value= yr;
            cmd.Prepare();
            OracleDataReader result = cmd.ExecuteReader();
            while (result.Read())
            {
                jours[result.GetInt32(1) - 1, result.GetInt32(2) - 1].SelectedValue = result["type"].ToString();
                jours[result.GetInt32(1) - 1, result.GetInt32(2) - 1].Text = result["type"].ToString();
                count[result["type"].ToString()]++;
            }
            result.Close();
            DateTime date_debut,date_fin;
            req = @"SELECT type, EXTRACT(DAY FROM  date_debut) as day, EXTRACT(MONTH FROM  date_debut) month, EXTRACT(YEAR FROM  date_debut) year,
                                    EXTRACT(DAY FROM  date_fin) as day2, EXTRACT(MONTH FROM  date_fin) month2, EXTRACT(YEAR FROM  date_fin) as year2 FROM conge_spec WHERE matricule=:mat and (EXTRACT(YEAR FROM  date_debut)=:year or EXTRACT(YEAR FROM  date_fin)=:year)";
            cmd = connexion.CreateCommand(req);
            cmd.Parameters.Add(new OracleParameter(":mat", this.matricule));
            cmd.Parameters.Add(new OracleParameter(":year", OracleDbType.Long)).Value= yr;
            cmd.Prepare();
            result = cmd.ExecuteReader();
            while (result.Read())
            {
                date_debut = new DateTime(result.GetInt16(3), result.GetInt16(2), result.GetInt16(1));
                date_fin = new DateTime(result.GetInt16(6), result.GetInt16(5), result.GetInt16(4));
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
                //jours[result.GetInt32("day") - 1, result.GetInt32("month") - 1].SelectedValue = result["type"].ToString();
            }
            ao.Content = (count["AO"] + count["O"]/2).ToString();
            aa.Content = (count["AA"] + count["A"] / 2).ToString();
            cm.Content = count["CM"].ToString();
            //connexion.close();
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
            update_stat();
        }
        private void update_stat()
        {
            string value = "";
            string date = "";
            string type = "";
            int nbr_jours = 0;
            DateTime date_debut = new DateTime(), date_fin = new DateTime();
            OracleCommand commande = connexion.CreateCommand();
            commande.BindByName = true;


            connexion.open();

            commande.CommandText = @"delete from absence where matricule=:matricule and EXTRACT(YEAR FROM  date_absence)=:year";
            commande.Parameters.Add(new OracleParameter(":year", OracleDbType.Long)).Value = long.Parse(years.Text);
            commande.Parameters.Add(new OracleParameter(":matricule", matricule));
            commande.Prepare();
            connexion.insert(commande);


            for (int i = 1; i < 13; i++)
                for (int j = 1; j < 32; j++)
                {
                    if (Function.isDate(int.Parse(years.Text), i, j))
                    {

                        value = jours[j - 1, i - 1].Text;

                        if (absence.Contains(value))
                        {
                            try
                            {
                                date = years.Text + "-" + i.ToString() + "-" + j.ToString();
                                DateTime date2 = new DateTime(int.Parse(years.Text), i, j);
                                commande = connexion.CreateCommand();
                                commande.CommandText = @"insert into absence(MATRICULE, TYPE, DATE_ABSENCE) values(:matricule,:type,:date_abs)";
                                commande.Parameters.Add(new OracleParameter(":matricule", matricule));
                                commande.Parameters.Add(new OracleParameter(":type", value.ToUpper()));
                                commande.Parameters.Add(new OracleParameter(":date_abs", OracleDbType.Date)).Value = date2;
                                commande.Prepare();
                                commande.ExecuteNonQuery();

                            }
                            catch (OracleException o)
                            {
                                MessageBox.Show(o.Message);
                            }
                        }

                        if (conge_spec.Contains(value))
                        {
                            if (type == "") { type = value; date_debut = new DateTime(int.Parse(years.Text), i, j); nbr_jours = 0; }
                            else
                            {


                                if (type == value) nbr_jours++;
                                else
                                {

                                    date_fin = date_debut.Date.AddDays(nbr_jours);
                                    commande = connexion.CreateCommand();
                                    commande.CommandText = @"insert into conge_spec (MATRICULE, TYPE, DATE_DEBUT, DATE_FIN)
                                                                 values (:matricule,:type,:date1,:date2)";
                                    commande.Parameters.Add(new OracleParameter(":matricule", matricule));
                                    commande.Parameters.Add(new OracleParameter(":type", type));
                                    commande.Parameters.Add(new OracleParameter(":date1", OracleDbType.Date)).Value = date_debut.Date;
                                    commande.Parameters.Add(new OracleParameter(":date2", OracleDbType.Date)).Value = date_fin.Date;
                                    commande.Prepare();
                                    connexion.insert(commande);
                                    type = value; nbr_jours = 0;
                                }
                            }

                        }
                        else if (type != "")
                        {
                            date_fin = date_debut.Date.AddDays(nbr_jours);
                            commande = connexion.CreateCommand();
                            commande.CommandText = @"insert into conge_spec (MATRICULE, TYPE, DATE_DEBUT, DATE_FIN) values (:matricule,:type,:date1,:date2)";

                            commande.Parameters.Add(new OracleParameter(":matricule", matricule));
                            commande.Parameters.Add(new OracleParameter(":type", type));
                            commande.Parameters.Add(new OracleParameter(":date1", OracleDbType.Date)).Value = date_debut.Date;
                            commande.Parameters.Add(new OracleParameter(":date2", OracleDbType.Date)).Value = date_fin.Date;
                            commande.Prepare();
                            connexion.insert(commande);
                            type = ""; nbr_jours = 0;
                        }

                    }
                }
            //connexion.close();
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

        private void close_container(object sender, RoutedEventArgs e)
        {
            form_container.Visibility = Visibility.Hidden;
            shadow_container.Visibility = Visibility.Hidden;
            open_container.Visibility = Visibility.Visible;
        }

        private void ajouter_absence(object sender, RoutedEventArgs e)
        {
            int i = 0;
            string value = type_absence.Text;

            errorMessage = absence_conflet();

            if (nom.Text == "")
                errorMessage += "- element n'existe pas dans la base \n";

            if (absence.Contains(value))
                if (!Function.isNumber(nbr_jour.Text))
                    errorMessage += "- nbr de jours  n'est pas valide \n";

            if (conge_spec.Contains(value))
                if (date_debut_form.DisplayDate > date_fin_form.DisplayDate)
                    errorMessage += "- verifier les dates \n";

            if (type_absence.Items.IndexOf(type_absence.SelectedItem) == -1)
                errorMessage += "- type d'absence non valide \n";

            if (errorMessage != "")
            {
                MessageBox.Show(errorMessage);
                errorMessage = "";
                //connexion.close();
                return;
            }
            connexion.open();
            OracleCommand commande;
            if (absence.Contains(value))
                while (i < int.Parse(nbr_jour.Text))
                {
                    commande = connexion.CreateCommand();
                    commande.CommandText = @"insert into absence (MATRICULE, TYPE, DATE_ABSENCE) values (:matricule,:type,:date_val)";
                    commande.Parameters.Add(new OracleParameter(":matricule", matricule_form.Text));
                    commande.Parameters.Add(new OracleParameter(":type", type_absence.Text));
                    commande.Parameters.Add(new OracleParameter(":date_val", OracleDbType.Date)).Value = date_debut_form.DisplayDate.AddDays(i);
                    commande.Prepare();
                    commande.ExecuteNonQuery();
                    i++;
                }
            if (conge_spec.Contains(value))
            {
                commande = connexion.CreateCommand();
                commande.CommandText = @"insert into conge_spec (MATRICULE, TYPE, DATE_DEBUT, DATE_FIN) values (:matricule,:type,:date1,:date2)";
                commande.Parameters.Add(new OracleParameter(":matricule", matricule_form.Text));
                commande.Parameters.Add(new OracleParameter(":type", type_absence.Text));
                commande.Parameters.Add(new OracleParameter(":date1", OracleDbType.Date)).Value = date_debut_form.DisplayDate;
                commande.Parameters.Add(new OracleParameter(":date2", OracleDbType.Date)).Value = date_fin_form.DisplayDate;
                commande.Prepare();
                commande.ExecuteNonQuery();
            }


            MessageBox.Show("fait");
            if (matricule == matricule_form.Text) {
                fill();
            }
            //connexion.close();

        }

        private void matricule_changed(object sender, TextChangedEventArgs e)
        {

            string mat = matricule_form.Text;
            if (mat.Count() > 4)
            {

                connexion.open();
                String req = "select nom,affectation.designation from element,affectation where element.code_affect=affectation.code and matricule = :mat";
                OracleCommand cmd = connexion.CreateCommand(req);
                cmd.Parameters.Add(new OracleParameter(":mat", mat));
                cmd.Prepare();
                OracleDataReader result = cmd.ExecuteReader();
                if (result.Read())
                {
                    nom.Text = result[0].ToString();
                    affectation.Text = result[1].ToString();
                }
                else
                {

                    nom.Text = "";
                    affectation.Text = "";
                }

                //connexion.close();
            }
        }

        private void type_absence_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (type_absence.SelectedItem == null) return;
            string value = type_absence.SelectedItem.ToString();
            value = value.Substring(value.Length - 2, 2).Trim();
            //MessageBox.Show(value);
            if (value == "AO" || value == "O" || value == "AA" || value == "A")
            {
                nbr_jour.Visibility = Visibility.Visible;
                date_fin_form.Visibility = Visibility.Collapsed;
            }
            if (value == "CM" || value == "LD")
            {
                nbr_jour.Visibility = Visibility.Collapsed;
                date_fin_form.Visibility = Visibility.Visible;
            }
        }

        private void open_container_click(object sender, RoutedEventArgs e)
        {
            shadow_container.Visibility = Visibility.Visible;
            form_container.Visibility = Visibility.Visible;
            open_container.Visibility = Visibility.Hidden;
            matricule_form.Text = matricule;
        }
        string absence_conflet()
        {
            string errorMessage = "";
            int i = 0;
            string value = type_absence.Text;

            connexion.open();

            if (absence.Contains(value))
            {
                while (i < int.Parse(nbr_jour.Text))
                {
                    String req = "select type,date_absence from absence where date_absence = :date_val and matricule=:mat";
                    OracleCommand cmd = connexion.CreateCommand(req);
                    cmd.Parameters.Add(new OracleParameter(":date_val", OracleDbType.Date)).Value= date_debut_form.DisplayDate.AddDays(i);
                    cmd.Parameters.Add(new OracleParameter(":mat", matricule_form.Text));
                    cmd.Prepare();
                    OracleDataReader result = connexion.select(cmd);
                    if (result!=null && result.Read())
                    {
                        errorMessage += result["type"].ToString() + " le " + result["date_absence"].ToString() + " deja existe \n";
                    }
                    result.Close();
                    i++;

                }

                while (i < int.Parse(nbr_jour.Text))
                {
                    String req = "select type,date_debut,date_fin from conge_spec where (date_debut >= :date_val or date_fin <= :date_val) and matricule=:mat";
                    OracleCommand cmd = connexion.CreateCommand(req);
                    cmd.Parameters.Add(new OracleParameter(":date_val", OracleDbType.Date)).Value= date_debut_form.DisplayDate.AddDays(i);
                    cmd.Parameters.Add(new OracleParameter(":mat", matricule_form.Text));
                    cmd.Prepare();
                    OracleDataReader result = cmd.ExecuteReader();
                    if (result.Read())
                    {
                        errorMessage += result["type"].ToString() +" de "+ result["date_debut"].ToString() + " à " + result["date_fin"].ToString() +" deja existe \n";
                        i = int.Parse(nbr_jour.Text);
                    }
                    i++;
                }
                
            }
            else 
            if (conge_spec.Contains(value))
            {
                String req = "select type,date_absence from absence where  (absence.date_absence >= :date1 and absence.date_absence <= :date2) and matricule=:mat";
                OracleCommand cmd = connexion.CreateCommand(req);
                cmd.Parameters.Add(new OracleParameter(":date1", OracleDbType.Date)).Value = date_debut_form.DisplayDate;
                cmd.Parameters.Add(new OracleParameter(":date2", OracleDbType.Date)).Value = date_fin_form.DisplayDate;
                cmd.Parameters.Add(new OracleParameter(":mat", matricule_form.Text));
                cmd.Prepare();
                OracleDataReader result = cmd.ExecuteReader();
                if (result.Read())
                {
                    errorMessage += result["type"].ToString() + " le " + result[1].ToString() + " deja existe \n";
                    i = int.Parse(nbr_jour.Text);
                }

                result.Close();
                // 2020-11-26  2020 - 11 - 29   _  2020-11-22  2020 - 11 - 27  _  2020-11-27  2020 - 11 - 28  _  2020-11-28  2020 - 11 - 30
                req = @"select type,date_debut date_debut,date_fin date_fin from conge_spec 
                                where ((date_debut <= :date2 and date_debut >= :date1) or (date_fin <= :date2 and date_fin >= :date1) or (date_fin >= :date2 and date_debut <= :date1))
                                and matricule=:mat";
                cmd = connexion.CreateCommand(req);
                cmd.Parameters.Add(new OracleParameter(":date1", OracleDbType.Date)).Value= date_debut_form.DisplayDate;
                cmd.Parameters.Add(new OracleParameter(":date2", OracleDbType.Date)).Value= date_fin_form.DisplayDate;
                cmd.Parameters.Add(new OracleParameter(":mat", matricule_form.Text));
                cmd.Prepare();
                result = cmd.ExecuteReader();
                if (result.Read())
                {
                    errorMessage += result["type"].ToString() + " de " + result["date_debut"].ToString() + " à " + result["date_fin"].ToString() + " deja existe \n";
                    i = int.Parse(nbr_jour.Text);
                }
            }


            //connexion.close();
            return errorMessage;
        }

}
}
    
