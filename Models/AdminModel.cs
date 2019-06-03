namespace pbshop_web.Models
{
    public class AdminModel
    {
        public int id {set;get;}
        public string name {set;get;}
        public string lastName  {set;get;}
        public string userName {set;get;}
        public string password {set;get;}
        public string fcm_token {set;get;}
        public int job_titles_id {set;get;}

    }

    public class LoginAdminModel
    {
        public string userName{set;get;}
        public string password {set;get;}
        public string fcm_token {set;get;}
    }
}