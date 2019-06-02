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

        internal TaskContentModel TasksContent()
        {
            var taskContent = new TaskContentModel();
            var taskStatesList = new List<TaskStateModel>();
            var employeesList = new List<EmployeeModel>();
            var toolsList = new List<ToolModel>();
            var toolStatesList = new List<ToolStateModel>();

           
        
            using (var conn = new MySqlConnection(GetConnectionString()))
            {
                try
                {
                    MySqlCommand myCommand = conn.CreateCommand();
                    conn.Open();
                    myCommand.Connection = conn;

                    myCommand.CommandText = "SELECT id, state FROM task_states";
                    using(var reader = myCommand.ExecuteReader()){
                        while (reader.Read())
                        {
                            taskStatesList.Add(ParseTaskStates(reader));
                        }
                    }

                    
                    myCommand.CommandText = "SELECT id, name, lastName FROM employees";
                    using(var reader = myCommand.ExecuteReader()){
                        while (reader.Read())
                        {
                            employeesList.Add(ParseEmployees(reader));
                        }
                    }

                    myCommand.CommandText = "SELECT id, toolName FROM tools";
                    using(var reader = myCommand.ExecuteReader()){
                        while (reader.Read())
                        {
                            toolsList.Add(ParseTools(reader));
                        }
                    }

                    myCommand.CommandText = "SELECT id,state FROM tool_states";
                    using(var reader = myCommand.ExecuteReader()){
                        while (reader.Read())
                        {
                            toolStatesList.Add(ParseToolStates(reader));
                        }
                    }
                    taskContent.employees = employeesList;
                    taskContent.states = taskStatesList;
                    taskContent.tool_states = toolStatesList;
                    taskContent.tools = toolsList;

                    return taskContent;
                }
                catch (System.Exception ex)
                {
                    
                    throw ex;
                }
                return null;
            }
        }

        internal bool UpdateTaskStates(TaskModel task)
        {
            var cmd = new MySqlCommand("UPDATE tasks SET task_states_id = @task_states_id, tool_states_id = @tool_states_id, tools_id = @tools_id, employees_id = @employee_id WHERE id = @id");
            cmd.Parameters.AddWithValue("@task_states_id", task.task_states_id);
            cmd.Parameters.AddWithValue("@tool_states_id", task.tool_states_id);
            cmd.Parameters.AddWithValue("@tools_id", task.tools_id);
            cmd.Parameters.AddWithValue("@employee_id", task.employee_id);
            cmd.Parameters.AddWithValue("@id", task.id);

            using (var conn = new MySqlConnection(GetConnectionString()))
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
                    return false;
                    throw ex;
                }
                 
            }
        }

        internal TaskModel GetTaskById(int id)
        {
            var cmd = new MySqlCommand("SELECT id, description,task_states_id, tools_id, tool_states_id, employees_id, workshop_records_id FROM tasks WHERE id = @id");
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
                            return ParseTask(reader);
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

        private ToolStateModel ParseToolStates(MySqlDataReader reader)
        {
            var states = new ToolStateModel();
            states.id = (int)reader["id"];
            states.state = (string)reader["state"];
            return states;
        }
        private ToolModel ParseTools(MySqlDataReader reader)
        {
            var tools = new ToolModel();
            tools.id = (int)(long)reader["id"];
            tools.toolName = (string)reader["toolName"];

            return tools;
        }
        private EmployeeModel ParseEmployees(MySqlDataReader reader)
        {
            var employees = new EmployeeModel();
            employees.id = (int)(long)reader["id"];
            employees.name = (string)reader["name"];
            employees.lastName = (string)reader["lastName"];
            return employees;
        }
        private TaskStateModel ParseTaskStates(MySqlDataReader reader)
        {
            var states = new TaskStateModel();
            states.id = (int)reader["id"];
            states.state = (string)reader["state"];
            return states;
        }
        private TaskModel ParseTask(MySqlDataReader reader)
        {
            var task = new TaskModel();
            task.id = (int)(long)reader["id"];
            task.description = (string)reader["description"];
            if(!Convert.IsDBNull(reader["employees_id"])){ 
                 task.employee_id = (int)(long)reader["employees_id"];
            }       
            if(!Convert.IsDBNull(reader["task_states_id"])){ 
                task.task_states_id = (int)reader["task_states_id"];
            }
            if(!Convert.IsDBNull(reader["tools_id"])){ 
                task.tools_id = (int)(long)reader["tools_id"];
            }
            if(!Convert.IsDBNull(reader["tool_states_id"])){ 
                task.tool_states_id = (int)reader["tool_states_id"];
            }
            
            
            return task;
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