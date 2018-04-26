namespace ServiceManagerAPI.Web.Controllers
{
    using ServiceManagerAPI.Data;
    using ServiceManagerAPI.Entities.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Http;

    public class ServicesController : ApiController
    {
        private ApiContext _context = new ApiContext();

        // GET api/services
        public IEnumerable<Service> Get()
        {
            IEnumerable<Service> services = this._context.Services.ToList();
            return services;
        }

        // GET api/services/5
        public IHttpActionResult Get(int id)
        {
            Service service = new Service();
            service = this._context.Services.FirstOrDefault(s => s.Id == id);
            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }

        // POST api/services
        [HttpPost]
        public IHttpActionResult Post(Service service)
        {
            if (ModelState.IsValid && service != null && service.ServiceName != null)
            {
                this._context.Services.Add(service);
                _context.SaveChanges();
                return Ok(service);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, service);
            }
        }

        // PUT api/services/5
        [HttpPut]
        public IHttpActionResult Put(int id, Service service)
        {
            Service serviceDb = new Service();
            serviceDb = this._context.Services.FirstOrDefault(s => s.Id == id);
            if (serviceDb == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid && service != null)
            {
                serviceDb.ServiceName = service.ServiceName;
                serviceDb.Description = service.Description;
                _context.SaveChanges();
                return Ok(serviceDb);
            }
            
            return Content(HttpStatusCode.BadRequest, service);
        }

        // DELETE: api/services/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Service service = new Service();
            service = this._context.Services.FirstOrDefault(s => s.Id == id);
            if (service == null)
            {
                return NotFound();
            }
            this._context.Services.Remove(service);
            this._context.SaveChanges();
            return Ok(service);
        }
    }
}
