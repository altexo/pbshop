namespace pbshop_web.Models
{
    public class TaskModel
    {
        public int id {get;set;}
        public int workshop_id {get;set;}
        public int employee_id {get;set;} 
        public int tools_id {set;get;}
        public int task_states_id {set;get;}
        public string description {set;get;}
        // public ToolModel tools {set;get;}
        public EmployeeModel employee {set;get;}
        public ToolModel tool {set;get;}
        public TaskStateModel task_state {set;get;}


    }
    public class DescriptionTaskModel {
        public int id {set;get;}
        public string description {set;get;}
         public string task_state {set;get;}
    }

    public class CreateTaskModel
    {
        public int workshop_id {get;set;}
        // public int employee_id {get;set;} 
        // public int tools_id {set;get;}
        public string description {set;get;}
        public int task_states_id {set;get;}


        public int task_media_id {set;get;}

        
    }


    
}