namespace ServiceManagerAPI.Web.Controllers
{
    using ServiceManagerAPI.Data;
    using ServiceManagerAPI.Entities.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Http;

    public class OrdersController : ApiController
    {
        private ApiContext _context = new ApiContext();

        // GET api/orders
        public IEnumerable<Order> Get()
        {
            IEnumerable<Order> orders = this._context.Orders.ToList();
            return orders;
        }

        // GET api/orders/5
        public IHttpActionResult Get(int id)
        {
            Order order = new Order();
            order = this._context.Orders.FirstOrDefault(s => s.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // POST api/orders
        [HttpPost]
        public IHttpActionResult Post(Order order)
        {
            if (ModelState.IsValid && order != null && order.OrderName != null)
            {
                this._context.Orders.Add(order);
                _context.SaveChanges();
                return Ok(order);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, order);
            }
        }

        // PUT api/orders/5
        [HttpPut]
        public IHttpActionResult Put(int id, Order order)
        {
            Order orderDb = new Order();
            orderDb = this._context.Orders.FirstOrDefault(s => s.Id == id);
            if (orderDb == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid && orderDb != null)
            {
                orderDb.OrderName = order.OrderName;
                orderDb.Description = order.Description;
                _context.SaveChanges();
                return Ok(orderDb);
            }

            return Content(HttpStatusCode.BadRequest, order);
        }

        // DELETE: api/orders/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Order order = new Order();
            order = this._context.Orders.FirstOrDefault(s => s.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            this._context.Orders.Remove(order);
            this._context.SaveChanges();
            return Ok(order);
        }
    }
}
