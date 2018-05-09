namespace ServiceManagerAPI.Web.Controllers
{
    using ServiceManagerAPI.Data;
    using ServiceManagerAPI.Entities.Contracts;
    using ServiceManagerAPI.Entities.Models;
    using ServiceManagerAPI.Web.Managers;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Http;

    public class CustomersController : ApiController
    {
        private ApiContext _context = new ApiContext();

        // GET api/customers
        //[Route("api/customers")]
        public IEnumerable<Customer> Get()
        {
            IEnumerable<Customer> customers = this._context.Customers.ToList();
            return customers;
        }

        // GET api/customers/5
        //[ActionName("GetCustomer")]
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = new Customer();
            customer = this._context.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // POST api/customers
        [HttpPost]
        public IHttpActionResult Post(Customer customer)
        {
            if (ModelState.IsValid && customer != null && customer.CustomerName != null)
            {
                this._context.Customers.Add(customer);
                _context.SaveChanges();
                return Ok(customer);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, customer);
            }
        }

        // PUT api/customers/5
        [HttpPut]
        public IHttpActionResult Put(int id, Customer customer)
        {
            Customer customerDb = new Customer();
            customerDb = this._context.Customers.FirstOrDefault(c => c.Id == id);
            if (customerDb == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid && customerDb != null)
            {
                customerDb.CustomerName = customer.CustomerName;
                _context.SaveChanges();
                return Ok(customerDb);
            }

            return Content(HttpStatusCode.BadRequest, customer);
        }

        // DELETE: api/customers/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Customer customer = new Customer();
            customer = this._context.Customers.FirstOrDefault(s => s.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            this._context.Customers.Remove(customer);
            this._context.SaveChanges();
            return Ok(customer);
        }

        [HttpGet]
        // GET: api/customers/5/GetCustomerOrders
        [Route("api/customers/{customerId?}/GetCustomerOrders")]
        public IEnumerable<IEntity> GetCustomerOrders()
        {
            int customerId = 0;
            var fragment = Url.Request.RequestUri.Segments[3].Remove(1);
            bool isParsed = int.TryParse(fragment, out customerId);
            Repository<Order> serviceManager = new Repository<Order>();
            var services = serviceManager.Get(customerId);
            return services;
        }

        [HttpPost]
        // POST: api/customers/5/CreateCustomerOrder
        public IHttpActionResult CreateCustomerOrder(Order order)
        {
            Repository<Order> serviceManager = new Repository<Order>();
            var response = serviceManager.Post(order);
            return Ok(response);
        }
    }
}
