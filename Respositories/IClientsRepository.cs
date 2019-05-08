using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pbshop_web.Respositories
{
    public interface IClientsRepository
    {
        ClientsEntity LeerPorId(int id);
        List<ClientsEntity> LeerTodos();
        Task<bool> Guardar(ClientsEntity nuevo);
        Task<bool> Actualizar (ClientsEntity actualizado);
        Task<bool> Borrar(int id);
    }

    public class ClientsEntity{
        public int id {get;set;}
        public string name {get; set;}
        public string lastName {get; set;}
        public string phone {get;set;}
        public string email {get;set;}

        // internal object ToList()
        // {
        //     throw new NotImplementedException();
        // }
    }
}