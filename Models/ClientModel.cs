namespace pbshop_web.Models
{
    public class Client{

        public int id {get;set;}
        public string name {get; set;}
        public string lastName {get; set;}
        public string phone {get;set;}
        public string email {get;set;}

    }

    public class CreateClientModel
    {
        public string name {get; set;}
        public string lastName {get; set;}
        public string phone {get;set;}
        public string email {get;set;}
    }


}