using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Oracle.DataAccess.Client;  using Oracle.DataAccess.Types;
using System.Text.RegularExpressions;

namespace Absence
{
    class Function
    {
        public static String emtyFields(Panel container, String[] exception)
        {
            String message = "";
            foreach (object child in container.Children)
            {
                String childname = "";
                String childContent = "";
                if (child is FrameworkElement && child is TextBox)
                {
                    childname = (child as FrameworkElement).Name;
                    childContent = (child as TextBox).Text;
                    if (!exception.Contains(childname) && childContent == "")
                        message += "- " + childname + " vide \n";
                }

            }
            return message;
        }

        /*****************/

        public static bool dbRowExiste(Connexion connexion, String tablename, String columnname, String id)
        {
            try
            {
            connexion.open();
            if (id == "") return false;
            OracleCommand cmd = connexion.CreateCommand();
            
            cmd.CommandText = "select * from "+ tablename + " where " + columnname + " = :val";
            //cmd.Parameters.Add(new OracleParameter("tabname", tablename);
            //cmd.Parameters.Add(new OracleParameter("columnname", columnname);
            cmd.Parameters.Add(new OracleParameter(":val", id));
            cmd.Prepare();
            OracleDataReader result = cmd.ExecuteReader();
            if (result.Read())
                {
                    // //connexion.close();
                    return true;
                }
                //connexion.close();
                return false;
            }
            catch(OracleException ex)
                {
                MessageBox.Show(ex.Message);
                //connexion.close();
                return false;
                }
            
        }

        public static bool dbRowExiste(Connexion connexion, String tablename, String columnname, String id,string idUpdate)
        {
            try
            {

                if (id == "") return false;
                OracleCommand cmd = connexion.CreateCommand();
                connexion.open();
                cmd.CommandText = "select * from " + tablename + " where " + columnname + " = :val and " + columnname + " <> :idUpdate";
                //cmd.Parameters.Add(new OracleParameter("tabname", tablename);
                //cmd.Parameters.Add(new OracleParameter("columnname", columnname);
                cmd.Parameters.Add(new OracleParameter(":val", id));
                cmd.Parameters.Add(new OracleParameter(":idUpdate", idUpdate));
                cmd.Prepare();
                OracleDataReader result = cmd.ExecuteReader();
                if (result.Read())
                {
                    //connexion.close();
                    return true;
                }
                //connexion.close();
                return false;
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
                //connexion.close();
                return false;
            }

        }

        public static bool isNumber(String number)
        {
            int i;

            return int.TryParse(number, out i);
        }

        public static bool isDate(int year,int month,int day)
        {
            try {
                new DateTime(year, month,day);
            }
            catch
            {
                return false;
            }
                return true;
        }
        public static bool isAlphaNumeric(String str)
        {
            Regex r = new Regex("^[a-zA-Z0-9]*$");
            if (r.IsMatch(str))
                return true;

                return false;
        }
        public static bool isAlpha(String str)
        {
            Regex r = new Regex("^[a-zA-Z]*$");
            if (r.IsMatch(str))
                return true;

            return false;
        }
    }
}
