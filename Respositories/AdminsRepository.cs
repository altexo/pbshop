using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using MySql.Data.MySqlClient;
using MySql;
using System.Threading.Tasks;
using pbshop_web.Models;

namespace pbshop_web.Respositories
{
    public class AdminsRepository
    {
           public static string GetConnectionString(){
            return Startup.ConnectionString;
        }

        internal AdminModel Login(AdminModel admin)
        {
            var userAdmin = new AdminModel();
            var cmd = new MySqlCommand("SELECT id, name, lastName, userName, password, fcm_token FROM admins WHERE userName = @userName AND password = @password");
            cmd.Parameters.AddWithValue("@userName", admin.userName);
            cmd.Parameters.AddWithValue("@password", admin.password);

            using (var conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.Connection.OpenAsync();
                    using(var reader = cmd.ExecuteReader()){
                        if (reader.Read())
                        {
                            return ParseAdmin(reader);
                        }

                    }
                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }
            }
            return null;
           // return admin;
        }

        private AdminModel ParseAdmin(MySqlDataReader reader)
        {
            var a = new AdminModel();
            a.userName = (string)reader["userName"];
            a.id = (int)(long)reader["id"];
            a.name = (string)reader["name"];
            a.lastName = (string)reader["lastName"];

            return a;
        }
    }
}