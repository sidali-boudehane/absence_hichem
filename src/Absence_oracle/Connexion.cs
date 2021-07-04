using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Absence
{
    class Connexion
    {
        OracleConnection connexion;

        public Connexion()
        {
            string host = "127.0.0.1:1521";
            string dbname = "absence";
            string username = "abdou";
            string password = "123";
            string oradb = "Data Source="+host+"/"+dbname+";User Id="+username+";Password="+password+";";
            connexion = new OracleConnection(oradb);
        }
        public OracleConnection getConnexion()
        {
            return this.connexion;
        }        
        /**********************************/
        public OracleCommand CreateCommand()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connexion;
            cmd.CommandType = CommandType.Text;
            cmd.BindByName = true;
            return cmd;
        }
        /**********************************/
        public OracleCommand CreateCommand(string query)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connexion;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.BindByName = true;
            return cmd;
        }
        /**********************************/
        public OracleParameter CreateParam(string paramname, OracleDbType type,Object val)
        {
            OracleParameter param = new OracleParameter("id", type);
            param.Value = val;

            return param;
        }
        /**********************************/
        public void insert(OracleCommand cmd)
        {
            try
            {

            cmd.ExecuteNonQuery();
            }catch(OracleException o)
                {
                    //MessageBox.Show(o.Message);
                }
        }
        /**********************************/
        public OracleDataReader select(OracleCommand cmd)
        {
            try
            {

               return cmd.ExecuteReader();
            }
            catch (OracleException o)
            {
                //MessageBox.Show(o.Message);
                return null;
            }
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
                connexion.Dispose();
        }

    }
}
