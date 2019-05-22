using System.Collections.Generic;

namespace pbshop_web.Models
{
    public class WorkshopRecordStateModel
    {
        public int id {set;get;}
        public string state {set; get;}
    }
        public class WorkshopRecordWithClientModel 
        {
        public int wr_id {set;get;}
        public int client_id {set;get;}
        public int workshop_record_sate_id {set;get;}

        public List<Client> clients {set;get;}
    }
}