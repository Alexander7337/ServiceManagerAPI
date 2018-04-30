namespace ServiceManagerAPI.Web.Managers
{
    using ServiceManagerAPI.Data;
    using ServiceManagerAPI.Entities.Contracts;
    using ServiceManagerAPI.Entities.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    public class Repository<T> : ApiController, IRepository<T> where T : IEntity
    {
        private ApiContext _context = new ApiContext();

        public IHttpActionResult Delete(int id)
        {
            IEntity entity = null;
            if (typeof(T) == typeof(Customer))
            {
                entity = this._context.Customers.FirstOrDefault(e => e.Id == id);
            }
            else if(typeof(T) == typeof(Order))
            {
                entity = this._context.Orders.FirstOrDefault(e => e.Id == id);
            }
            else if (typeof(T) == typeof(Employee))
            {
                entity = this._context.Employees.FirstOrDefault(e => e.Id == id);
            }
            else if (typeof(T) == typeof(Service))
            {
                entity = this._context.Employees.FirstOrDefault(e => e.Id == id);
            }

            if (entity == null)
            {
                return NotFound();
            }

            this._context.Set(typeof(T)).Remove(entity);
            this._context.SaveChanges();
            return Ok(entity);
        }

        //IEnumerable<Service> services = this._context.Services.ToList();
        //    return services;
        public IEnumerable<IEntity> Get()
        {
            IEnumerable<IEntity> entities = new List<IEntity>();
            if (typeof(T) == typeof(Customer))
            {
                entities = this._context.Customers.ToList();
            }
            else if (typeof(T) == typeof(Order))
            {
                entities = this._context.Orders.ToList();
            }
            else if (typeof(T) == typeof(Employee))
            {
                entities = this._context.Employees.ToList();
            }
            else if (typeof(T) == typeof(Service))
            {
                entities = this._context.Services.ToList();
            }

            return entities;
        }

        public IHttpActionResult Get(int id)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult Post(T entity)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult Put(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}