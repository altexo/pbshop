using System.Collections.Generic;
using pbshop_web.Models;

namespace pbshop_web.Respositories
{
 
    public interface IWorkShopRecordRepository
    {
         WorkshopRecordModel LeerPorId(int id);
        List<WorkShopRecordsEntity> LeerTodos();
        // Task<bool> Guardar(ClientsEntity nuevo);
        // Task<bool> Actualizar (ClientsEntity actualizado);
        // Task<bool> Borrar(int id);
    }

    public class WorkShopRecordsEntity{
        public int id {set;get;}
        public int client_id {set;get;}
        public int workshop_record_sate_id {set;get;}

        public Client client {set;get;}
        public WorkshopRecordStateModel workshop_record_sate {set;get;}
    }
    
}