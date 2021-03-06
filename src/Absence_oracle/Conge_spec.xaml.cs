using System;
using System.Collections.Generic;
using System.Data;
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
    /// Logique d'interaction pour Conge_spec.xaml
    /// </summary>
    public partial class Conge_spec : Window
    {
        Connexion connexion;
        string matricule;
        string name;
        string errorMessage;
        string[] absence = { "AA", "AO", "A", "O" };
        string[] conge_spec = { "CM", "CMLD", "CA" };
        int id;
        public Conge_spec(string matricule,string name)
        {
            InitializeComponent();
            this.matricule = matricule;
            this.name = name;
            nom.Text = name;

            connexion = new Connexion();
            fill_table();
            errorMessage = "";
            id = -1;
        }

        private void fill_table()
        {
            absenceTable.SelectedIndex = -1;
            absenceTable.SelectionChanged -= absence_SelectionChanged;
            absenceTable.ItemsSource = null;
            absenceTable.Items.Clear();
            connexion.open();
            // string query = @"SELECT matricule,nom,prenom,code_affect,affectation,code_fonct,fonction from element where etat='ACTIF'";

            string query = @"SELECT id,type,TO_char(date_debut, 'DD-MON-RRRR') date_debut,TO_char(date_fin, 'DD-MON-RRRR') date_fin  from conge_spec where matricule=:matricule order by date_debut desc";

            OracleCommand myCommand = connexion.CreateCommand(query);
            myCommand.Parameters.Add(new OracleParameter(":matricule", matricule));
            myCommand.Prepare();
            OracleDataAdapter MyAdapter = new OracleDataAdapter();
            MyAdapter.SelectCommand = myCommand;
            DataTable dTable = new DataTable();
            MyAdapter.Fill(dTable);
           // globalTable = dTable;
            absenceTable.ItemsSource = dTable.DefaultView;
            //connexion.close();
           absenceTable.SelectionChanged += absence_SelectionChanged;
        }
        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void editer(object sender, RoutedEventArgs e)
        {
           // int i = 0;
            string value = type_absence.Text;

            errorMessage = absence_conflet();


                if (date_debut.DisplayDate > date_fin.DisplayDate)
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
                commande = connexion.CreateCommand();
                commande.CommandText = @"update conge_spec set type=:type,date_debut=:date1,date_fin=:date2 where id=:id";
                commande.Parameters.Add(new OracleParameter(":type", type_absence.Text));
                commande.Parameters.Add(new OracleParameter(":date1", date_debut.DisplayDate));
                commande.Parameters.Add(new OracleParameter(":date2", date_fin.DisplayDate));
                commande.Parameters.Add(new OracleParameter(":id", id));
                commande.Prepare();
                commande.ExecuteNonQuery();

            id = -1;
            fill_table();
            MessageBox.Show("fait");
            //connexion.close();
        }

        private void supprimer(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("supprimer "+ getCell(1) +" entre"+getCell(2)+" et "+ getCell(3), "confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                connexion.open();
                OracleCommand commande;
                commande = connexion.CreateCommand();
                commande.CommandText = @"delete from conge_spec where id=:id";
                commande.Parameters.Add(new OracleParameter(":id", id));
                commande.Prepare();
                commande.ExecuteNonQuery();
                fill_table();
                id = -1;
                //connexion.close();
            }
        }

        private void absence_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

            id = int.Parse( getCell(0) );
            //form.IsEnabled = true;
           // MessageBox.Show(id.ToString());
            type_absence.SelectedValue = getCell(1);
            type_absence.Text = getCell(1);

            date_debut.Text = getCell(2);
            date_debut.DisplayDate = DateTime.Parse(getCell(2));

            date_fin.Text = getCell(3);
            date_fin.DisplayDate = DateTime.Parse(getCell(3));
            }catch{
                id = -1;
                return;
            }

        }

        private String getCell(int i)
        {
            var index = absenceTable.Items.IndexOf(absenceTable.CurrentItem);
            if (index < absenceTable.Items.Count && index > -1)
            {
                var rowGrid = (DataGridRow)absenceTable.ItemContainerGenerator.ContainerFromIndex(index);
                var row = (DataRowView)rowGrid.DataContext;
                object[] obj = row.Row.ItemArray;
                return obj[i].ToString();
            }

            return "";
        }



        string absence_conflet()
        {
            string errorMessage = "";
            //int i = 0;
            string value = type_absence.Text;

            connexion.open();
            if (conge_spec.Contains(value))
            {
                String req = "select type,date_absence from absence where  (absence.date_absence >= :date1 and absence.date_absence <= :date2) and matricule=:mat and id<>:id";
                OracleCommand cmd = connexion.CreateCommand(req);
                cmd.Parameters.Add(new OracleParameter(":date1", date_debut.DisplayDate));
                cmd.Parameters.Add(new OracleParameter(":date2", date_fin.DisplayDate));
                cmd.Parameters.Add(new OracleParameter(":mat", matricule));
                cmd.Parameters.Add(new OracleParameter(":id", id));
                cmd.Prepare();
                OracleDataReader result = cmd.ExecuteReader();
                if (result.Read())
                {
                    errorMessage += result["type"].ToString() + " le " + result[1].ToString() + " deja existe \n";
                }

                result.Close();
                // 2020-11-26  2020 - 11 - 29   _  2020-11-22  2020 - 11 - 27  _  2020-11-27  2020 - 11 - 28  _  2020-11-28  2020 - 11 - 30
                req = @"select type,date_debut,date_fin from conge_spec 
                                where ((date_debut <= :date2 and date_debut >= :date1) or (date_fin <= :date2 and date_fin >= :date1) or (date_fin >= :date2 and date_debut <= :date1))
                                and matricule=:mat and id<>:id";
                cmd = connexion.CreateCommand(req);
                cmd.Parameters.Add(new OracleParameter(":date1", date_debut.DisplayDate));
                cmd.Parameters.Add(new OracleParameter(":date2", date_fin.DisplayDate));
                cmd.Parameters.Add(new OracleParameter(":mat", matricule));
                cmd.Parameters.Add(new OracleParameter(":id", id));
                cmd.Prepare();
                result = cmd.ExecuteReader();
                if (result.Read())
                {
                    errorMessage += result["type"].ToString() + " de " + result["date_debut"].ToString() + " à " + result["date_fin"].ToString() + " deja existe \n";
                }
            }


            //connexion.close();
            return errorMessage;
        }
    }
}
