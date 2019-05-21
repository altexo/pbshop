using System.Collections.Generic;

namespace pbshop_web.Models
{
    public class WorkshopRecordModel{
        public int id {set;get;}
        public int client_id {set;get;}
        public int workshop_record_sate_id {set;get;}

    }
        public class WorkshopRecordWithClientModel : Client
        {
        public int wr_id {set;get;}
        public int client_id {set;get;}
        public int workshop_record_sate_id {set;get;}

        public List<Client> clients {set;get;}
    }

}