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
    /// Logique d'interaction pour AjouterClient.xaml
    /// </summary>
    public partial class AjouterAbsence : Window
    {
        Connexion connexion;
        string errorMessage = "";
        string[] absence = { "AA", "AO","A","O"};
        string[] conge_spec = { "CM", "CMLD","CA" };
        public AjouterAbsence()
        {
            InitializeComponent();
            connexion = new Connexion();
            date_debut.DisplayDate = DateTime.Today;
            date_debut.Text = DateTime.Today.ToString();
            date_fin.DisplayDate = DateTime.Today.AddDays(1);
            date_fin.Text = DateTime.Today.AddDays(1).ToString();

            init();
        }
        void init()
        {


        }
        private void minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ajouter(object sender, RoutedEventArgs e)
        {
            int i = 0;
            string value = type_absence.Text;

            errorMessage = absence_conflet();

            if (nom.Text=="")
                errorMessage += "- element n'existe pas dans la base \n";

            if (absence.Contains(value))
                if (!Function.isNumber(nbr_jour.Text))
                errorMessage += "- nbr de jours  n'est pas valide \n";

            if (conge_spec.Contains(value))
                if (date_debut.DisplayDate>date_fin.DisplayDate)
                errorMessage += "- verifier les dates \n";
            
            if (type_absence.Items.IndexOf(type_absence.SelectedItem) ==-1)
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
                while (i<int.Parse(nbr_jour.Text))
                {
                    commande = connexion.CreateCommand();
                    commande.CommandText = @"insert into absence (MATRICULE, TYPE, DATE_ABSENCE) values (:matricule,:type,:date_val)";
                    commande.Parameters.Add(new OracleParameter(":matricule", matricule.Text));
                    commande.Parameters.Add(new OracleParameter(":type", type_absence.Text));
                    commande.Parameters.Add(new OracleParameter(":date_val", OracleDbType.Date)).Value = date_debut.DisplayDate.AddDays(i);
                    commande.Prepare();
                    commande.ExecuteNonQuery();
                    i++;
                }
            if (conge_spec.Contains(value))
            {
                commande = connexion.CreateCommand();
                commande.CommandText = @"insert into conge_spec (MATRICULE, TYPE, DATE_DEBUT, DATE_FIN) values (:matricule,:type,:date1,:date2)";
                commande.Parameters.Add(new OracleParameter(":matricule", matricule.Text));
                commande.Parameters.Add(new OracleParameter(":type", type_absence.Text));
                commande.Parameters.Add(new OracleParameter(":date1", OracleDbType.Date)).Value = date_debut.DisplayDate;
                commande.Parameters.Add(new OracleParameter(":date2", OracleDbType.Date)).Value = date_fin.DisplayDate;
                commande.Prepare();
                commande.ExecuteNonQuery();
            }


            MessageBox.Show("fait");
            //connexion.close();
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
                    cmd.Parameters.Add(new OracleParameter(":date_val", OracleDbType.Date)).Value= date_debut.DisplayDate.AddDays(i);
                    cmd.Parameters.Add(new OracleParameter(":mat", matricule.Text));
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
                    cmd.Parameters.Add(new OracleParameter(":date_val", OracleDbType.Date)).Value= date_debut.DisplayDate.AddDays(i);
                    cmd.Parameters.Add(new OracleParameter(":mat", matricule.Text));
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
                cmd.Parameters.Add(new OracleParameter(":date1", OracleDbType.Date)).Value= date_debut.DisplayDate;
                cmd.Parameters.Add(new OracleParameter(":date2", OracleDbType.Date)).Value= date_fin.DisplayDate;
                cmd.Parameters.Add(new OracleParameter(":mat", matricule.Text));
                cmd.Prepare();
                OracleDataReader result = cmd.ExecuteReader();
                if (result.Read())
                {
                    errorMessage += result["type"].ToString() + " le " + result[1].ToString() + " deja existe \n";
                    i = int.Parse(nbr_jour.Text);
                }

                result.Close();
                // 2020-11-26  2020 - 11 - 29   _  2020-11-22  2020 - 11 - 27  _  2020-11-27  2020 - 11 - 28  _  2020-11-28  2020 - 11 - 30
                req = @"select type,DATE_FORMAT(date_debut,'%Y-%m-%d') date_debut,DATE_FORMAT(date_fin,'%Y-%m-%d') date_fin from conge_spec 
                                where ((date_debut <= :date2 and date_debut >= :date1) or (date_fin <= :date2 and date_fin >= :date1) or (date_fin >= :date2 and date_debut <= :date1))
                                and matricule=:mat";
                cmd = connexion.CreateCommand(req);
                cmd.Parameters.Add(new OracleParameter(":date1", OracleDbType.Date)).Value = date_debut.DisplayDate;
                cmd.Parameters.Add(new OracleParameter(":date2", OracleDbType.Date)).Value = date_fin.DisplayDate;
                cmd.Parameters.Add(new OracleParameter(":mat", matricule.Text));
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
        private void modifierDate(object sender, SelectionChangedEventArgs e)
        {
            date_fin.SelectedDate = date_debut.SelectedDate.Value.AddMonths(1);
            date_fin.Text = date_debut.SelectedDate.Value.AddMonths(1).ToString();
        }


        private void filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            MessageBox.Show(matricule.Text);
        }

        private void type_absence_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(type_absence.SelectedItem == null) return;
            string value = type_absence.SelectedItem.ToString();
            value = value.Substring(value.Length-2,2).Trim();
            //MessageBox.Show(value);
            if(value== "AO" || value == "O" || value == "AA" || value == "A")
            {
                nbr_jour.Visibility = Visibility.Visible;
                date_fin.Visibility = Visibility.Collapsed;
            }
            if (value == "CM" || value == "LD")
            {
                nbr_jour.Visibility = Visibility.Collapsed;
                date_fin.Visibility = Visibility.Visible;
            }
            
        }

        /*
        private void matricule_TextInput(object sender, KeyEventArgs e)
        {
            string mat = matricule.Text;
           // for(int i=0;i<matricule.Items.Count;i++)
           if(matricule.Items.Count>0)
                matricule.Items.Clear();
            
                matricule.IsDropDownOpen = true;

            if (mat.Count() > 2)
            {
                connexion.open();
                String req = "select matricule from element where matricule like :filtre limit 5";
                OracleCommand cmd = connexion.CreateCommand(req);
                cmd.Parameters.Add(new OracleParameter("filtre", "%" + mat + "%");
                cmd.Prepare();
                OracleDataReader result = cmd.ExecuteReader();
                while (result.Read())
                    matricule.Items.Add(result[0].ToString());

                //connexion.close();
            }
        }
*/
        private void textInput(object sender, TextCompositionEventArgs e)
        {
            MessageBox.Show("ok");
        }




        private void matricule_changed(object sender, TextChangedEventArgs e)
        {
            string mat = matricule.Text;
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
       
    }
}
