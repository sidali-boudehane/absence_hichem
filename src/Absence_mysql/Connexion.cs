using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;

namespace Absence
{
    public class Connexion
    {
        string conn_str;
        MySqlConnection connexion;
        MySqlCommand req;

        public Connexion()
        {
            conn_str = "Server=localhost;Port=3306;Database=absence;Username=root;Password=;CharSet=utf8;Convert Zero Datetime=True";
            connexion = new MySqlConnection(conn_str);
            req = connexion.CreateCommand();
        }

        public Connexion(string server, string port, string database, string username, string password)
        {
            conn_str = "Server=" + server + ";Port=" + port + ";Database=" + database + ";Username=" + username + ";Password=" + password + ";";
            connexion = new MySqlConnection(conn_str);
            req = connexion.CreateCommand();
        }
        /**********************************/
        public void insert(string sql_req)
        {
            req.CommandText = sql_req;
            try
            {
                connexion.Open();
            }
            catch 
            {
                MessageBox.Show("connexion echoué");
                return;
            }
            req.ExecuteNonQuery();
            connexion.Close();
        }
        /**********************************/
        public MySqlDataReader select(string sql_req)
        {
            MySqlDataReader rd;
            req.CommandText = sql_req;
            try
            {
                connexion.Close();
                connexion.Open();
            }
            catch 
            {
                MessageBox.Show("connexion echoué");
                return null;
            }
            
            rd = req.ExecuteReader();
           // connexion.Close();
            return rd;
        }
        /**********************************/
        public DataTable fillTable(string query)
        {
            MySqlCommand myCommand = new MySqlCommand(query, this.connexion);
            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
            MyAdapter.SelectCommand = myCommand;
            DataTable dTable = new DataTable();
            MyAdapter.Fill(dTable);
            return dTable;
        }
        /**********************************/
        public MySqlConnection getConnexion()
        {
            return this.connexion;
        }
        /**********************************/
        public MySqlCommand CreateCommand()
        {
            return connexion.CreateCommand();
        }
        /**********************************/

        public void open()
        {
            if (connexion.State == System.Data.ConnectionState.Closed)
                connexion.Open();
        }
        /**********************************/
        public void close()
        {
            if (connexion.State == System.Data.ConnectionState.Open)
            connexion.Close();
        }
        /**********************************/
        //public void show_result(DataGridView datagrid ,string sql_req)
        //{
        //    req.CommandText = sql_req;
        //    MySqlDataAdapter sda = new MySqlDataAdapter();
        //    sda.SelectCommand = req;
        //    DataTable dbdataset = new DataTable();
        //    sda.Fill(dbdataset);
        //    BindingSource bind = new BindingSource();
        //    bind.DataSource = dbdataset;
        //    datagrid.DataSource = bind;
        //    sda.Update(dbdataset);

        //}
        /**********************************/
    }
}
