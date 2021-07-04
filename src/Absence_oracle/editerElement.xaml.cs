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
    /// Logique d'interaction pour editerElement.xaml
    /// </summary>
    public partial class editerElement : Window
    {
        Connexion connexion;
        string errorMessage = "";
        string mat;
        public editerElement(string mat)
        {
            InitializeComponent();
            connexion = new Connexion();
            this.mat = mat;
            fillField();
        }

        void fillField()
        {
            string fonct, affect;
            connexion.open();
            String req = "select * from element where matricule=:mat";
            OracleCommand cmd =connexion.CreateCommand(req);
            cmd.Parameters.Add(new OracleParameter(":mat", mat));
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            OracleDataReader result = cmd.ExecuteReader();
            if (result.Read())
            {
                matricule.Text = mat;
                nom.Text = result["nom"].ToString();
                adresse.Text = result["adresse"].ToString();
                etat.Text = result["etat"].ToString();
                affect = result["code_affect"].ToString();
                fonct = result["code_fonct"].ToString();
                result.Close();
                code_affect.SelectedText = affect;
                code_fonct.SelectedText= fonct;
            }

            //connexion.close();
        }
        /*
               void fill_affect()
                {
                    connexion.open();
                    String req = "select distinct code from affectation";
                    OracleCommand cmd =connexion.CreateCommand(req);
                    cmd.Prepare();
                    OracleDataReader result = cmd.ExecuteReader();
                    while (result.Read())
                        code_affect.Items.Add(result[0].ToString());

                    //connexion.close();
                }
                void fill_fonct()
                {
                    connexion.open();
                    String req = "select distinct code from fonction";
                    OracleCommand cmd =connexion.CreateCommand(req);
                    cmd.Prepare();
                    OracleDataReader result = cmd.ExecuteReader();
                    while (result.Read())
                        code_fonct.Items.Add(result[0].ToString());

                    //connexion.close();
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
        


        private void code_affect_textchanged(object sender, TextChangedEventArgs e)
        {
            connexion.open();
            String req = "select designation from affectation where code=:code";
            OracleCommand cmd =connexion.CreateCommand(req);
            cmd.Parameters.Add(new OracleParameter(":code", code_affect.Text));
            cmd.Prepare();
            OracleDataReader result = cmd.ExecuteReader();
            if (result.Read())
                affectation.Text = result[0].ToString();
            else affectation.Text = "";
            //connexion.close();
        }

        private void code_fonct_textchanged(object sender, TextChangedEventArgs e)
        {
            connexion.open();
            String req = "select designation from fonction where code=:code";
            OracleCommand cmd =connexion.CreateCommand(req);
            cmd.Parameters.Add(new OracleParameter(":code", code_fonct.Text));
            cmd.Prepare();
            OracleDataReader result = cmd.ExecuteReader();
            if (result.Read())
                fonction.Text = result[0].ToString();
            else fonction.Text = "";
            //connexion.close();
        }

        private void editer_element(object sender, RoutedEventArgs e)
        {
            if (Function.dbRowExiste(connexion, "element", "matricule", matricule.Text, mat))
                errorMessage += "-  le matricule existe déja \n";
            if (matricule.Text == "" || nom.Text == "" || fonction.Text == "" || affectation.Text == "")
                errorMessage += "-  remplir les champs \n";
            if (errorMessage != "")
            {
                MessageBox.Show(errorMessage);
                errorMessage = "";
                //connexion.close();
                return;
            }

            connexion.open();
            OracleCommand commande = connexion.CreateCommand();
           // commande.CommandText = @"update element set matricule=:matricule1,nom=:nom,code_affect=:code_affect,code_fonct=:code_fonct,etat=:etat,adresse=:adresse where matricule=:matricule2";
            commande.CommandText = @"update element set matricule=:matricule1,nom=:nom,code_affect=:code_affect,code_fonct=:code_fonct,etat=:etat,adresse=:adresse where matricule=:matricule2";
            commande.Parameters.Add(new OracleParameter(":matricule1", matricule.Text));
            commande.Parameters.Add(new OracleParameter(":nom", nom.Text));
            commande.Parameters.Add(new OracleParameter(":code_affect", code_affect.Text));
            commande.Parameters.Add(new OracleParameter(":code_fonct", code_fonct.Text));
            commande.Parameters.Add(new OracleParameter(":adresse", adresse.Text));
            commande.Parameters.Add(new OracleParameter(":etat", etat.Text));
            commande.Parameters.Add(new OracleParameter(":matricule2", mat));
            commande.Prepare();
            commande.ExecuteNonQuery();
            //connexion.close();
            MessageBox.Show("fait");
        }
    }
}
