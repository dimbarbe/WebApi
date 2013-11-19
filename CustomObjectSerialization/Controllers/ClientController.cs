using CustomObjectSerialization.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace CustomObjectSerialization.Controllers
{
    public class ClientController : ApiController
    {
        private readonly List<Client> clients = new List<Client>(){
            new Client(){ ClientId = 1, Name = "Julio", LastName = "Avellaneda", City  = "Bogotá", Password = "123456"},
            new Client(){ ClientId = 1, Name = "Juan", LastName = "Ruiz", City  = "Bogotá", Password = "123456"}
        };
            
        /// <summary>
        /// Retorna listado de clientes
        /// </summary>
        public IEnumerable<Client> GetClients()
        {
            return clients;
        }
    }
}
