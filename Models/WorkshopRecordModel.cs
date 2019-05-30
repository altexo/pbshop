using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pbshop_web.Models
{
    public class WorkshopRecordModel{
        public int id {set;get;}
        public int client_id {set;get;}
        public int workshop_record_sate_id {set;get;}
        public Client client {set;get;}
        public WorkshopRecordStateModel workshop_record_sate {set;get;}
        public VehicleModel vehicle {set;get;}

    }

    // public class WorkShopRecordAndTasksModel
    // {
    //     public int id {set;get;}
    //     public int client_id {set;get;}
    //     public int workshop_record_sate_id {set;get;}
    //     public Client client {set;get;}
    //     public WorkshopRecordStateModel workshop_record_sate {set;get;}
    //     public VehicleModel vehicle {set;get;}

    //     public List<TaskModel> tasks {set;get;}
    // }
    public class CreateWorkShopModel {

        public VehicleModel vehicle {set;get;}
        public int client_id {set;get;}
        public int workshop_record_sate_id {set;get;}
        public List<TaskModel> tasks {set;get;}
    }



}