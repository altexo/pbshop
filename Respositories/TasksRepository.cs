using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using pbshop_web.Models;

namespace pbshop_web.Respositories
{
    public class TasksRepository
    {
        public static string GetConnectionString(){
            return Startup.ConnectionString;
        }
        internal List<DescriptionTaskModel> GetTasksById(int id)
        {
            var lista = new List<DescriptionTaskModel>();
            var cmd = new MySqlCommand("SELECT t.id, t.description, ts.state FROM tasks t INNER JOIN task_states ts on t.task_states_id = ts.id WHERE t.workshop_records_id = @id");
            cmd.Parameters.AddWithValue("@id", id);
            using (var conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    using(var reader = cmd.ExecuteReader()){
                        while (reader.Read())
                        {
                            lista.Add(ParseTasks(reader));
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

        private DescriptionTaskModel ParseTasks(MySqlDataReader reader)
        {
            var tasks = new DescriptionTaskModel();
            tasks.id = (int)(long)reader["id"];
            tasks.description = (string)reader["description"];
            tasks.task_state = (string)reader["state"];
            return tasks;
        }
    }
}