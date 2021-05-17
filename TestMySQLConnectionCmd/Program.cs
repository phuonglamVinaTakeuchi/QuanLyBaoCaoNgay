using MySql.Data.MySqlClient;
using MySQLConnectionDatabase.MySqlDatabases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMySQLConnectionCmd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geting Connection ...");
            var mySQLConnection = DbUtils.GetDbConnection();
            try
            {
                mySQLConnection.Open();
                //QueryEmployee(mySQLConnection);
                //InsertEmployee(mySQLConnection);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error:" + e.Message);
            }
            finally
            {
                mySQLConnection.Close();
                mySQLConnection.Dispose();
            }

            var mySQLCommand = mySQLConnection.CreateCommand();
            mySQLCommand.CommandText = 


            Console.ReadLine();
        }

        private static void QueryEmployee(MySqlConnection connection)
        {
            var sqlString = "Select * FROM employee";
            var sqlCmd = new MySqlCommand();
            sqlCmd.Connection = connection;
            sqlCmd.CommandText = sqlString;

            using(var reader =  sqlCmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        var empIdIndex = reader.GetOrdinal("id");
                        var empId = Convert.ToInt64(reader.GetValue(empIdIndex));
                        var nameIndex = reader.GetOrdinal("name"); ;
                        var name = reader.GetValue(nameIndex);

                        Console.WriteLine($"Employee Id: {empId}, Employee Name: {name}");
                    }
                }
            }
        }
        private static void InsertEmployee(MySqlConnection connection)
        {
            // cac cau truy van update delete thuc hien tuong tu chi thay doi cau truy van sql
            string sql = "INSERT INTO employee(role_id,job_position_id,department_id,name,user_name,passwords,email)" +
                                            " VALUES(@roleId,@jobPosition,@deparment,@name,@userName,@password,@email); ";
            var sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = sql;

            MySqlParameter roleParam = new MySqlParameter("@roleId", MySqlDbType.Int32);
            roleParam.Value = 2;
            sqlCommand.Parameters.Add(roleParam);
            sqlCommand.Parameters.Add("@jobPosition", MySqlDbType.Int32).Value = 3;
            sqlCommand.Parameters.Add("@deparment", MySqlDbType.Int32).Value = 6;
            sqlCommand.Parameters.Add("@name", MySqlDbType.String).Value = "Ngo Quoc Hung Anh";
            sqlCommand.Parameters.Add("@userName", MySqlDbType.String).Value = "HungAnh_takeuchi";
            sqlCommand.Parameters.Add("@password", MySqlDbType.String).Value = "87906";
            sqlCommand.Parameters.Add("@email", MySqlDbType.String).Value = "hunganh@VinaTakeuchi.com";

            var rowCount = sqlCommand.ExecuteNonQuery();
            Console.WriteLine("Row Count afflected = " + rowCount);
        }
    }
}
