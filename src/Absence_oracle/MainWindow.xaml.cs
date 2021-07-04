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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Oracle.DataAccess.Client;  using Oracle.DataAccess.Types;

namespace Absence
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Connexion connexion;
        DataTable globalTable;
        public MainWindow()
        {
            InitializeComponent();
            connexion = new Connexion();
            fill_table();
           // if (Function.isDate(2020, 11, 30)) MessageBox.Show("not ok");
        }

        private void fill_table()
        {
            personTable.SelectedIndex = -1;
            personTable.SelectionChanged -= person_SelectionChanged;
            personTable.ItemsSource = null;
            personTable.Items.Clear();
            connexion.open();
            // string query = @"SELECT distinct matricule,nom,prenom,code_affect,affectation,code_fonct,fonction from element where etat='ACTIF'";

            string query = @"SELECT distinct matricule,nom,code_affect,affectation.designation affectation,code_fonct,adresse
                                from element left  join affectation on element.Code_Affect=affectation.code
                                where (etat='ACTIF' or etat='CMLD')  order BY code_affect";
           
            OracleCommand myCommand = connexion.CreateCommand(query);

            OracleDataAdapter MyAdapter = new OracleDataAdapter();
            MyAdapter.SelectCommand = myCommand;
            DataTable dTable = new DataTable();
            MyAdapter.Fill(dTable);
            globalTable = dTable;
            personTable.ItemsSource = globalTable.DefaultView;
            //connexion.close();
            personTable.SelectionChanged += person_SelectionChanged;
        }



        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
         new Fiche(getCell(0)).Show();
        }

        private void AddPerson_Click(object sender, RoutedEventArgs e)
        {
            new ajouterElement().Show();
        }

        private void minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void refresh_click(object sender, RoutedEventArgs e)
        {
            fill_table();
        }

        private void set_info(int row)
        {

            nom.Text = getCell(1,row) + " " + getCell(2, row);
            code_affectation.Text = getCell(5, row);
            affectation.Text = getCell(6, row);
            setImage(getCell(0, row));
        }

        private void person_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Info();
        }

        void Info()
        {
            nom.Text = "Nom : " + getCell(1);
            code_affectation.Text = "Code affectation : " + getCell(2);
            affectation.Text = "Affectation : " + getCell(3);
            setImage(getCell(0));

            code_fonction.Text = "Code fonction : " + getCell(4);

            connexion.open();
            String req = "select distinct designation from fonction where code=:code";
            OracleCommand cmd = new OracleCommand(req, connexion.getConnexion());
            cmd.Parameters.Add(new OracleParameter("code", getCell(4)));
            cmd.Prepare();
            OracleDataReader result = cmd.ExecuteReader();
            if (result.Read())
                fonction.Text = "Fonction : " + result[0].ToString();

            //connexion.close();
        }
        void Info(int row)
        {
            nom.Text = "Nom : " + getCell(1,row);
            code_affectation.Text = "Code affectation : " + getCell(2,row);
            affectation.Text = "Affectation : " + getCell(3, row);
            setImage(getCell(0));

            code_fonction.Text = "Code fonction : " + getCell(4);

            connexion.open();
            String req = "select distinct designation from fonction where code=:code";
            OracleCommand cmd = new OracleCommand(req, connexion.getConnexion());
            cmd.Parameters.Add(new OracleParameter("code", getCell(4, row)));
            cmd.Prepare();
            OracleDataReader result = cmd.ExecuteReader();
            if (result.Read())
                fonction.Text = "Fonction : " + result[0].ToString();

            //connexion.close();
        }
        private String getCell(int i)
        {
            var index = personTable.Items.IndexOf(personTable.CurrentItem);
            if (index < personTable.Items.Count && index>-1)
            {
                var rowGrid = (DataGridRow)personTable.ItemContainerGenerator.ContainerFromIndex(index);
                var row = (DataRowView)rowGrid.DataContext;
                object[] obj = row.Row.ItemArray;
                return obj[i].ToString();
            }
           
            return "";

        }

        private String getCell(int column, int row)
        {
            var index = personTable.Items.IndexOf(personTable.Items[row]);
            if (index < personTable.Items.Count && index > -1)
            {
                var rowGrid = (DataGridRow)personTable.ItemContainerGenerator.ContainerFromIndex(index);
                var rowData = (DataRowView)rowGrid.DataContext;
                object[] obj = rowData.Row.ItemArray;
                return obj[column].ToString();
            }

            return "";

        }

        private void setImage(string matricule)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            if (System.IO.File.Exists(path + "photo\\" + matricule + ".jpg"))
                path += "photo\\" + matricule + ".jpg";
            else
                path += "photo\\default_M.png";
            Uri resourceUri = new Uri(path, UriKind.Absolute);
            photo.Source = new BitmapImage(resourceUri);
        }

        private void Button_Editer(object sender, RoutedEventArgs e)
        {
            new editerElement(getCell(0)).Show();
        }

        private void filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (filter.Text.Count() > 3) // if you want filter by affect set this to 1 and not add limit in query
            {

                personTable.SelectionChanged -= person_SelectionChanged;
                connexion.open();
                personTable.ItemsSource = null;
                personTable.Items.Clear();
                /*  string query = @"SELECT matricule, nom, prenom, nom_ar, prenom_ar, code_affect, affectation, code_fonct,fonction from element where etat = 'ACTIF' 
                                  and 
                                  (matricule like :filter or 
                                   UPPER(concat(nom,' ',prenom)) like :filter or
                                   UPPER(concat(nom_ar,' ',prenom_ar)) like :filter or
                                   code_affect like :filter or
                                   affectation like :filter or
                                   code_fonct like :filter or
                                   fonction like :filter
                                  ) limit 5";
                                  */
                                  

                string query = @"SELECT distinct matricule,nom,code_affect,affectation.designation affectation,code_fonct,adresse
                                from element left  join affectation on element.Code_Affect=affectation.code
                                where (etat='ACTIF' or etat='CMLD')
                                and
                                (UPPER(matricule) like :filter or 
                                 UPPER(nom) like :filter or
                                 UPPER(code_affect) like :filter or
                                 UPPER(affectation.designation) like :filter or
                                 UPPER(code_fonct) like :filter or
                                 UPPER(adresse) like :filter
                                ) order BY code_affect FETCH NEXT 10 ROWS ONLY";
                

                OracleCommand myCommand = connexion.CreateCommand(query);
                myCommand.Parameters.Add(new OracleParameter("filter", "%" + filter.Text.ToUpper() + "%"));

                myCommand.Prepare();

                OracleDataAdapter MyAdapter = new OracleDataAdapter();
                MyAdapter.SelectCommand = myCommand;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                personTable.ItemsSource = dTable.DefaultView;
                personTable.SelectionChanged += person_SelectionChanged;
            }
            else
                personTable.ItemsSource = globalTable.DefaultView;


            //connexion.close();
        }

        private void absence_Click(object sender, RoutedEventArgs e)
        {
            new AjouterAbsence().Show();
        }

        private void Conge_spec(object sender, RoutedEventArgs e)
        {
            new Conge_spec(getCell(0), getCell(1)).Show();
        }

        private void Archive_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            new Archive(this).Show();
        }

        private void fiche_click(object sender, RoutedEventArgs e)
        {
            new Fiche(getCell(0)).Show();
        }

        private void supprimer_element(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("vous allez supprimer l'element :  " +getCell(1), "confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                connexion.open();
                OracleCommand commande;
                commande = connexion.CreateCommand();
                commande.CommandText = @"delete from element where matricule=:matricule";
                commande.Parameters.Add(new OracleParameter(":matricule", getCell(0)));
                commande.Prepare();
                commande.ExecuteNonQuery();
                fill_table();
                //connexion.close();
            }
        }
    }
}
