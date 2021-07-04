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
    /// Logique d'interaction pour ajouterElement.xaml
    /// </summary>
    public partial class ajouterElement : Window
    {
        Connexion connexion;
        string errorMessage = "";
        public ajouterElement()
        {
            InitializeComponent();
            connexion = new Connexion();
           // fill_affect();
           // fill_fonct();
        }
/*
       void fill_affect()
        {
            connexion.open();
            String req = "select distinct code from affectation";
            MySqlCommand cmd = new MySqlCommand(req, connexion.getConnexion());
            cmd.Prepare();
            MySqlDataReader result = cmd.ExecuteReader();
            while (result.Read())
                code_affect.Items.Add(result[0].ToString());

            connexion.close();
        }
        void fill_fonct()
        {
            connexion.open();
            String req = "select distinct code from fonction";
            MySqlCommand cmd = new MySqlCommand(req, connexion.getConnexion());
            cmd.Prepare();
            MySqlDataReader result = cmd.ExecuteReader();
            while (result.Read())
                code_fonct.Items.Add(result[0].ToString());

            connexion.close();
        }
        */
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
            /* verifier les chomps vide */
            if (nom.Text == "")
                errorMessage += "- veuillez remplir le nom et le prenom \n";

            /* afficher le message d'erreur */
            if (errorMessage != "")
            {
                MessageBox.Show(errorMessage);
                errorMessage = "";
                return;
            }
            connexion.open();
            MySqlCommand commande = connexion.CreateCommand();
            commande.CommandText = @"insert into client values (null,@nom,@prenom,@tele,@tele2,@adresse)";
            commande.Parameters.AddWithValue("@nom", nom.Text);
            commande.Parameters.AddWithValue("@adresse", adresse.Text);
            // commande.Parameters.AddWithValue("@date_expiration", visa_expiration.DisplayDate);
            commande.Prepare();
            commande.ExecuteNonQuery();
            connexion.close();
        }


        private void code_affect_textchanged(object sender, TextChangedEventArgs e)
        {
            connexion.open();
            String req = "select designation from affectation where code=@code";
            MySqlCommand cmd = new MySqlCommand(req, connexion.getConnexion());
            cmd.Parameters.AddWithValue("@code", code_affect.Text);
            cmd.Prepare();
            MySqlDataReader result = cmd.ExecuteReader();
            if (result.Read())
                affectation.Text = result[0].ToString();
            else affectation.Text = "";

            connexion.close();
        }

        private void code_fonct_textchanged(object sender, TextChangedEventArgs e)
        {
            connexion.open();
            String req = "select designation from fonction where code=@code";
            MySqlCommand cmd = new MySqlCommand(req, connexion.getConnexion());
            cmd.Parameters.AddWithValue("@code", code_fonct.Text);
            cmd.Prepare();
            MySqlDataReader result = cmd.ExecuteReader();
            if (result.Read())
                fonction.Text = result[0].ToString();
            else fonction.Text = "";

            connexion.close();
        }

        private void ajouter_element(object sender, RoutedEventArgs e)
        {
            if(Function.dbRowExiste(connexion.getConnexion(),"element","matricule",matricule.Text))
                errorMessage += "-  le matricule existe déja \n";
            if (matricule.Text=="" || nom.Text == "" || fonction.Text == "" || affectation.Text == "")
                errorMessage += "-  remplir les champs \n";
            if (errorMessage != "")
            {
                MessageBox.Show(errorMessage);
                errorMessage = "";
                connexion.getConnexion().Close();
                return;
            }

            connexion.open();
            MySqlCommand commande = connexion.CreateCommand();
            commande.CommandText = @"insert into element values (@matricule,@nom,@code_affect,@code_fonct,@etat,@adresse)";
            commande.Parameters.AddWithValue("@matricule", matricule.Text);
            commande.Parameters.AddWithValue("@nom", nom.Text);
            commande.Parameters.AddWithValue("@code_affect", code_affect.Text);
            commande.Parameters.AddWithValue("@code_fonct", code_fonct.Text);
            commande.Parameters.AddWithValue("@adresse", adresse.Text);
            commande.Prepare();
            commande.ExecuteNonQuery();
            connexion.close();
            MessageBox.Show("fait");
        }
    }
}
