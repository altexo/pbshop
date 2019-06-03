using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using pbshop_web.Models;

namespace pbshop_web.Respositories
{
    public class WorkShopRecordRepository
    {
        public static string GetConnectionString(){
            return Startup.ConnectionString;
        }

        internal List<WorkshopRecordModel> LeerTodos()
        {
            var lista = new List<WorkshopRecordModel>();
            var cmd = new MySqlCommand("SELECT wr.id, wr.client_id, ws.id as workshop_state_id, ws.state, c.email, c.name, c.lastName, c.phone, v.brand, v.model, v.year, v.serial, DATE(v.created_at) as created_at FROM workshop_records wr INNER JOIN workshop_record_states ws on wr.workshop_record_state_id = ws.id INNER JOIN clients c on wr.client_id = c.id INNER JOIN vehicles v on v.id = wr.vehicle_id");
           //var cmd = new MySqlCommand("SELECT workshop_records.id as we_id, workshop_record_states.id as ws_id, workshop_record_states.state, workshop_records.workshop_record_sate_id, workshop_records.clients_id FROM workshop_records INNER JOIN workshop_record_states on workshop_records.workshop_record_states_id = workshop_record_states.id");
            using (var conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    using(var reader = cmd.ExecuteReader()){
                        while (reader.Read())
                        {
                            lista.Add(ParseWorkShopRecords(reader));
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

        internal UpdateWorkshopRecordModel ChangeState(UpdateWorkshopRecordModel workshop)
        {
            // var w = new WorkshopRecordModel();
            var cmd = new MySqlCommand("UPDATE workshop_records SET workshop_record_state_id = @workshop_record_state_id WHERE id = @id");
            cmd.Parameters.AddWithValue("@workshop_record_state_id", workshop.workshop_record_sate_id);
            cmd.Parameters.AddWithValue("@id", workshop.id);
             using (var conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    return GetFCM(workshop);

                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }
                
            }

        }
        private UpdateWorkshopRecordModel GetFCM(UpdateWorkshopRecordModel workshop){
            var cmd = new MySqlCommand("SELECT fcm_token FROM admins WHERE job_titles_id = 3");
            using (var conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    using(var reader = cmd.ExecuteReader()){
                        if (reader.Read())
                        {
                            workshop.fcm = (string)reader["fcm_token"];
                            return workshop;
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

        // internal WorkShopRecordAndTasksModel DetailedWorkshop(int id)
        // {
        //     var workshopWithTasks = new WorkShopRecordAndTasksModel();
        //     var workshop = new WorkshopRecordModel();
        //     var tasks = new List<TaskModel>();
        //     var cmdWorkShop = new MySqlCommand("SELECT wr.id, wr.client_id, ws.state, c.email, c.name, c.lastName, c.phone, v.brand, v.model, v.year FROM workshop_records wr INNER JOIN workshop_record_states ws on wr.workshop_record_state_id = ws.id INNER JOIN clients c on wr.client_id = c.id INNER JOIN vehicles v on v.id = wr.vehicle_id WHERE wr.id = @id");
        //     cmdWorkShop.Parameters.AddWithValue("@id", id);

        //     using (var conn = new MySqlConnection(GetConnectionString()))
        //     {
        //         try
        //         {
        //             cmdWorkShop.Connection = conn;
        //             cmdWorkShop.Connection.Open();
        //             using(var reader = cmdWorkShop.ExecuteReader()){
        //                 if (reader.Read())
        //                 {
        //                     workshop = ParseWorkShopRecords(reader);
        //                 }

        //             }
        //         }
        //         catch (Exception ex)
        //         {

        //             throw ex;
        //         }
        //     }
        //     return null;
        // }



        internal List<WorkshopRecordModel> GetWorkshopsByState(int id)
        {
            var lista = new List<WorkshopRecordModel>();
            var cmd = new MySqlCommand("SELECT wr.id, wr.client_id, ws.id as workshop_state_id,ws.state, c.email, c.name, c.lastName, c.phone, v.brand, v.model, v.year, v.serial, DATE(v.created_at) as created_at FROM workshop_records wr INNER JOIN workshop_record_states ws on wr.workshop_record_state_id = ws.id INNER JOIN clients c on wr.client_id = c.id INNER JOIN vehicles v on v.id = wr.vehicle_id WHERE ws.id = @id");
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
                            lista.Add(ParseWorkShopRecords(reader));
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

        internal async Task<bool> CreateNew(CreateWorkShopModel workshop)
        {
           
            using (var conn = new MySqlConnection(GetConnectionString()))
            {
                MySqlCommand myCommand = conn.CreateCommand();
                MySqlTransaction myTrans;
                   // Start a local transaction
                await conn.OpenAsync();
                myTrans = conn.BeginTransaction();
                // Must assign both transaction object and connection
                // to Command object for a pending local transaction
                myCommand.Connection = conn;
                myCommand.Transaction = myTrans;

                try
                {
                    myCommand.CommandText = "INSERT INTO vehicles (serial, model, brand, year, created_at) VALUES (@serial , @model, @brand, @year, NOW())";
                    myCommand.Parameters.AddWithValue("@serial", workshop.vehicle.serial);
                    myCommand.Parameters.AddWithValue("@model", workshop.vehicle.model);
                    myCommand.Parameters.AddWithValue("@brand", workshop.vehicle.brand);
                    myCommand.Parameters.AddWithValue("@year", workshop.vehicle.year);
                    await myCommand.ExecuteNonQueryAsync();
                    long vehicleId = myCommand.LastInsertedId;

                    myCommand.CommandText = "INSERT INTO workshop_records (client_id, workshop_record_state_id, vehicle_id) VALUES (@client_id, @workshop_record_state_id, @vehicle_id)";
                    myCommand.Parameters.AddWithValue("@client_id", workshop.client_id);
                    myCommand.Parameters.AddWithValue("@workshop_record_state_id", workshop.workshop_record_sate_id);
                    myCommand.Parameters.AddWithValue("@vehicle_id", vehicleId);
                    await myCommand.ExecuteNonQueryAsync();
                    long workshopRecordId = myCommand.LastInsertedId;

                    myCommand.CommandText = "INSERT INTO tasks (description, workshop_records_id, task_states_id) VALUES (@description, @workshop_records_id, @task_states_id)";
                    myCommand.Parameters.AddWithValue("@description", "");
                    myCommand.Parameters.AddWithValue("@workshop_records_id", 0);
                    myCommand.Parameters.AddWithValue("@task_states_id", 0);

                    
                    foreach (var task in workshop.tasks)
                    {
                       myCommand.Parameters["@description"].Value = task.description;
                       myCommand.Parameters["@workshop_records_id"].Value = workshopRecordId;
                       myCommand.Parameters["@task_states_id"].Value = 1;
                       await myCommand.ExecuteNonQueryAsync();   
                     
                    }
                    
                    myTrans.Commit();
                    Console.WriteLine("Both records are written to database.");
                    return true;
                }
                catch(Exception e)
                {
                    try
                    {
                        myTrans.Rollback();
                    }
                    catch (MySqlException ex)
                    {
                        if (myTrans.Connection != null)
                        {
                            Console.WriteLine("An exception of type " + ex.GetType() +
                            " was encountered while attempting to roll back the transaction.");
                            Console.WriteLine(ex);
                            return false;
                        }
                    }

                    Console.WriteLine("An exception of type " + e.GetType() +
                    " was encountered while inserting the data.");
                    Console.WriteLine("Neither record was written to database.");
                    Console.WriteLine(e);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
           

          
        }

        internal WorkshopRecordModel LeerPorId(int id)
        {
            var lista = new WorkshopRecordModel();
            var cmd = new MySqlCommand("SELECT wr.id, wr.client_id, ws.id as workshop_state_id, ws.state, c.email, c.name, c.lastName, c.phone, v.brand, v.serial,v.model, v.year, v.created_at FROM workshop_records wr INNER JOIN workshop_record_states ws on wr.workshop_record_state_id = ws.id INNER JOIN clients c on wr.client_id = c.id INNER JOIN vehicles v on v.id = wr.vehicle_id WHERE wr.id = @id");
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
                            return ParseWorkShopRecords(reader);
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
  
        private WorkshopRecordModel ParseWorkShopRecords(MySqlDataReader reader)
        {
            try
            {
                var w = new WorkshopRecordModel();
                var state = new WorkshopRecordStateModel();
                var c = new Client();
                var v = new VehicleModel();

                w.id = (int)(long)reader["id"];
                w.client_id = (int)(long)reader["client_id"];
                
                c.email = (string)reader["email"];
                c.name = (string)reader["name"];
                c.lastName = (string)reader["lastName"];
                c.phone = (string)reader["phone"];

                state.state = (string)reader["state"];
                state.id = (int)reader["workshop_state_id"];

                v.model = (string)reader["model"];
                v.brand = (string)reader["brand"];
                v.year = (int)reader["year"];
                v.serial = (string)reader["serial"];
                v.created_at = reader["created_at"].ToString();
                w.vehicle = v;
                w.client = c;
                w.workshop_record_sate = state;
                return w;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        
        }
    }
}