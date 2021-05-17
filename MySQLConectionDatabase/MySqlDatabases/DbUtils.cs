using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLConnectionDatabase.MySqlDatabases
{
    public static class DbUtils
    {
        public static MySqlConnection GetDbConnection()
        {
            string host = "127.0.0.1";
            int port = 3306;
            var databasename = "vinatakeuchimanager";
            var userName = "root";
            string password = "";
            return DbMySQLUtils.GetDbConection(host, port, databasename, userName, password);
        }
    }
}
