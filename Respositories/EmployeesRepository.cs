using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using pbshop_web.Models;

namespace pbshop_web.Respositories
{
    public class EmployeesRepository
    {
         public static string GetConnectionString(){
            return Startup.ConnectionString;
        }
        internal List<EmployeeModel> LeerTodos()
        {
            var lista = new List<EmployeeModel>();
            var cmd = new MySqlCommand("SELECT id, name, lastName, phone FROM employees");
            using (var conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    using(var reader = cmd.ExecuteReader()){
                        while (reader.Read())
                        {
                            lista.Add(ParseEmployee(reader));
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }
            }
            return lista;
        }

        internal EmployeeModel LeerPorId(int id)
        {
            var lista = new List<EmployeeModel>();
            var cmd = new MySqlCommand("SELECT id, name, lastName, phone FROM employees WHERE id = @id");
            cmd.Parameters.AddWithValue("@id", id);
            using (var conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    using(var reader = cmd.ExecuteReader()){
                        if (reader.Read())
                        {
                            return ParseEmployee(reader);
                        }

                    }
                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }
            }
            return null;
        }

        internal void Crear(CreateEmployeeModel nuevo)
        {
            var cmd = new MySqlCommand("INSERT INTO employees (name, lastName, phone) VALUES (@name, @lastName, @phone)");
            cmd.Parameters.AddWithValue("@name", nuevo.name);
            cmd.Parameters.AddWithValue("@lastName", nuevo.lastName);
            cmd.Parameters.AddWithValue("@phone", nuevo.phone);
           
            
            using (var conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    
                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }
            }
         
        }

        internal void Update(EmployeeModel updated)
        {
            var cmd = new MySqlCommand("UPDATE employees SET name = @name, lastName = @lastName, phone = @phone WHERE id = @id");
            cmd.Parameters.AddWithValue("@id", updated.id);
            cmd.Parameters.AddWithValue("@name", updated.name);
            cmd.Parameters.AddWithValue("@lastName", updated.lastName);
            cmd.Parameters.AddWithValue("@phone", updated.phone);
           
            
            using (var conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                   
                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }
                
            }
        }

        internal bool verifyPhone(string phone)
        {
            string registerPhone;
            var cmd = new MySqlCommand("SELECT phone FROM employees where phone = @phone");
            cmd.Parameters.AddWithValue("@phone", phone);
            using (var conn = new MySqlConnection("server=k3xio06abqa902qt.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;port=3306;database=aeacqkuf3fr8uq8t;user=ss7z1t6oys987shb;password=nw473umt2r9yu41d"))
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    // cmd.ExecuteNonQuery();
                    using(var reader = cmd.ExecuteReader()){
                    if (reader.Read())
                        {
                            registerPhone = (string)reader["phone"];
                            if (registerPhone == phone)
                                {
                                    return false;
                                }
                        }
                    }
                  
                    return true;
                    //return true;
                }
                catch (System.Exception)
                {
                    
                    throw;
                }
            }
        }


        internal void Delete(int id)
        {
            var cmd = new MySqlCommand("DELETE FROM employees WHERE id = @id ");
            cmd.Parameters.AddWithValue("@id", id);
            using (var conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                   
                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }
             
            }
        }

        private static EmployeeModel ParseEmployee(MySqlDataReader reader)
        {
            var c = new EmployeeModel();
            c.id = (int)(long)reader["id"];
            c.name = (string)reader["name"];
            c.lastName = (string)reader["lastName"];
            c.phone = (string)reader["phone"];
            return c;
        }
    }
}