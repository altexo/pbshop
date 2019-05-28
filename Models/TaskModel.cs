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