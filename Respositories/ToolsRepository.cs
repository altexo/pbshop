using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using pbshop_web.Models;

namespace pbshop_web.Respositories
{
    public class ToolsRepository
    {
        public static string GetConnectionString(){
            return Startup.ConnectionString;
        }
        internal List<ToolModel> LeerTodos()
        {
            var lista = new List<ToolModel>();
            var cmd = new MySqlCommand("SELECT id, toolName FROM tools");
            using (var conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    using(var reader = cmd.ExecuteReader()){
                        while (reader.Read())
                        {
                            lista.Add(ParseTool(reader));
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

        internal ToolModel LeerPorId(int id)
        {
            var lista = new List<ToolModel>();
            var cmd = new MySqlCommand("SELECT id, toolName FROM tools WHERE id = @id");
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
                            return ParseTool(reader);
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

        internal void Crear(ToolModel nuevo)
        {
            var cmd = new MySqlCommand("INSERT INTO tools (toolName) VALUES (@toolName)");
            cmd.Parameters.AddWithValue("@toolName", nuevo.toolName);
           
           
            
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

        internal void Update(ToolModel updated)
        {
            var cmd = new MySqlCommand("UPDATE tools SET toolName = @toolName WHERE id = @id");
            cmd.Parameters.AddWithValue("@id", updated.id);
            cmd.Parameters.AddWithValue("@toolname", updated.toolName);
           
           
            
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

       

        internal void Delete(int id)
        {
            var cmd = new MySqlCommand("DELETE FROM tools WHERE id = @id ");
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

        private static ToolModel ParseTool(MySqlDataReader reader)
        {
            var c = new ToolModel();
            c.id = (int)(long)reader["id"];
            c.toolName = (string)reader["toolName"];
            return c;
        }
    }
}