using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_Tservice
{
    public class dbConnection
    {
        //public static String sBDatos = "CIGE_MELACONFORT";
        //public static String cn = @"Data Source=LAPTOP-7LG4PTUE\SQLEXPRESS2014;Initial Catalog=CIGE_MELACONFORT;User ID=sa;Password=nic";
        public static String sBDatos = "canvia";
        public static String cn = @"Data Source=DESKTOP-AUAUT0S\SQLEXPRESS2019,1433;Initial Catalog=canvia;User ID=sa;Password=rrzj";

        public static DataTable ConsulSql(string sql)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(cn);

            SqlCommand cmd = new SqlCommand(sql, connection);
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
                else
                {
                    connection.Open();
                }

                dt.Load(cmd.ExecuteReader());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
    }
}
