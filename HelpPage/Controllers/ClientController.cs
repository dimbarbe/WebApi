using HelpPage.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace HelpPage.Controllers
{
    public class ClientController : ApiController
    {
        private AppContext db = new AppContext();

        /// <summary>
        /// Get all clients
        /// </summary>
        /// <returns>List of clients</returns>
        public IQueryable<Client> GetClients()
        {
            return db.Clients;
        }

        /// <summary>
        /// Get a client by Id
        /// </summary>
        /// <param name="id">Client id</param>
        /// <returns>One Client</returns>
        [ResponseType(typeof(Client))]
        public IHttpActionResult GetClient(int id)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        /// <summary>
        /// Update a Client
        /// </summary>
        /// <param name="id">Client id</param>
        /// <param name="client">Client to be updated</param>
        /// <returns>>Operation result</returns>
        public IHttpActionResult PutClient(int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.ClientId)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Create a new Client
        /// </summary>
        /// <param name="client">Object Client</param>
        /// <returns>Operation result</returns>
        [ResponseType(typeof(Client))]
        public IHttpActionResult PostClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clients.Add(client);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = client.ClientId }, client);
        }

        /// <summary>
        /// Delete a client by id
        /// </summary>
        /// <param name="id">Client id</param>
        /// <returns>Operation result</returns>
        [ResponseType(typeof(Client))]
        public IHttpActionResult DeleteClient(int id)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            db.Clients.Remove(client);
            db.SaveChanges();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(int id)
        {
            return db.Clients.Count(e => e.ClientId == id) > 0;
        }
    }
}