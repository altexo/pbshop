using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using MySql.Data.MySqlClient;
using MySql;
using System.Threading.Tasks;

namespace pbshop_web.Respositories
{
    public class ClientsRepository : IClientsRepository
    {
       // string connStr;
        // public ClientsRepository(string connectionStr){
        //     connStr = connectionStr;
        // }
        string connStr = "server=localhost;port=3306;database=mydb;user=root;password=";
        public async Task<bool> Actualizar(ClientsEntity actualizado)
        {
            var cmd = new MySqlCommand("UPDATE clients SET name = @name, lastName = @lastName, phone = @phone, email = @email WHERE id = @id");
            cmd.Parameters.AddWithValue("@id", actualizado.id);
            cmd.Parameters.AddWithValue("@name", actualizado.name);
            cmd.Parameters.AddWithValue("@lastName", actualizado.lastName);
            cmd.Parameters.AddWithValue("@phone", actualizado.phone);
            cmd.Parameters.AddWithValue("@email", actualizado.email);
            
            using (var conn = new MySqlConnection(connStr))
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }
                return false;
            }
        }

        public async Task<bool> Borrar(int id)
        {
            var cmd = new MySqlCommand("DELETE FROM clients WHERE id = @id ");
            cmd.Parameters.AddWithValue("@id", id);
            using (var conn = new MySqlConnection(connStr))
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }
                return false;
            }
        }

        public async Task<bool> Guardar(ClientsEntity nuevo)
        {
            var cmd = new MySqlCommand("INSERT INTO clients (name, lastName, phone, email) VALUES (@name, @lastName, @phone, @email)");
            cmd.Parameters.AddWithValue("@name", nuevo.name);
            cmd.Parameters.AddWithValue("@lastName", nuevo.lastName);
            cmd.Parameters.AddWithValue("@phone", nuevo.phone);
            cmd.Parameters.AddWithValue("@email", nuevo.email);
            
            using (var conn = new MySqlConnection(connStr))
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }
            }
            return false;

        }

        public ClientsEntity LeerPorId(int id)
        {
            var lista = new List<ClientsEntity>();
            var cmd = new MySqlCommand("SELECT id, name, lastName, phone, email FROM clients WHERE id = @id");
            cmd.Parameters.AddWithValue("@id", id);
            using (var conn = new MySqlConnection(connStr))
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    using(var reader = cmd.ExecuteReader()){
                        if (reader.Read())
                        {
                            return ParseClient(reader);
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


        public List<ClientsEntity> LeerTodos()
        {
            var lista = new List<ClientsEntity>();
            var cmd = new MySqlCommand("SELECT id, name, lastName, phone, email FROM clients");
            using (var conn = new MySqlConnection(connStr))
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    using(var reader = cmd.ExecuteReader()){
                        while (reader.Read())
                        {
                            lista.Add(ParseClient(reader));
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



        private static ClientsEntity ParseClient(MySqlDataReader reader)
        {
            var c = new ClientsEntity();
            c.id = (int)(long)reader["id"];
            c.name = (string)reader["name"];
            c.lastName = (string)reader["lastName"];
            c.phone = (string)reader["phone"];
            c.email = (string)reader["email"];
            return c;
        }
    }
}