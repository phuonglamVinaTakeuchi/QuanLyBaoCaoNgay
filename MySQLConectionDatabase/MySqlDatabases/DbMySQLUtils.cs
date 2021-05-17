using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLConnectionDatabase.MySqlDatabases
{
    public class DbMySQLUtils
    {
        public static MySqlConnection GetDbConection(string host,int port,string database,string username,string password)
        {
            var conectionString = "Server=" + host + ";Database=" + database + ";port=" + port + ";User Id=" + username + ";password=" + password;
            var conection = new MySqlConnection(conectionString);
            return conection;
        }
    }
}
