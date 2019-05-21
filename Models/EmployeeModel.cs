namespace pbshop_web.Models
{
    public class EmployeeModel
    {


        public int id {set;get;}
        public string name {set;get;}
        public string lastName{set;get;}
        public string phone {set;get;}
    }

    public class CreateEmployeeModel{

        public string name {set;get;}
        public string lastName{set;get;}
        public string phone {set;get;}
    }
}