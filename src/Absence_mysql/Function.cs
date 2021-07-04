using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
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

        public static bool dbRowExiste(MySqlConnection connexion, String tablename, String columnname, String id)
        {
            try
            {

            if (id == "") return false;
            MySqlCommand cmd = connexion.CreateCommand();
            connexion.Open();
            cmd.CommandText = "select * from "+ tablename + " where " + columnname + " = @val";
            //cmd.Parameters.AddWithValue("@tabname", tablename);
            //cmd.Parameters.AddWithValue("@columnname", columnname);
            cmd.Parameters.AddWithValue("@val", id);
            cmd.Prepare();
            MySqlDataReader result = cmd.ExecuteReader();
            if (result.Read())
                {
                    connexion.Close();
                    return true;
                }
                connexion.Close();
                return false;
            }
            catch(MySqlException ex)
                {
                MessageBox.Show(ex.Message);
                connexion.Close();
                return false;
                }
            
        }

        public static bool dbRowExiste(MySqlConnection connexion, String tablename, String columnname, String id,string idUpdate)
        {
            try
            {

                if (id == "") return false;
                MySqlCommand cmd = connexion.CreateCommand();
                connexion.Open();
                cmd.CommandText = "select * from " + tablename + " where " + columnname + " = @val and " + columnname + " <> @idUpdate";
                //cmd.Parameters.AddWithValue("@tabname", tablename);
                //cmd.Parameters.AddWithValue("@columnname", columnname);
                cmd.Parameters.AddWithValue("@val", id);
                cmd.Parameters.AddWithValue("@idUpdate", idUpdate);
                cmd.Prepare();
                MySqlDataReader result = cmd.ExecuteReader();
                if (result.Read())
                {
                    connexion.Close();
                    return true;
                }
                connexion.Close();
                return false;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                connexion.Close();
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
