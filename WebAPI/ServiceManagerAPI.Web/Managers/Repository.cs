﻿namespace ServiceManagerAPI.Web.Managers
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
        
        public IEnumerable<IEntity> Get(int id)
        {
            IEnumerable<IEntity> entities = new List<IEntity>();
            if (typeof(T) == typeof(Customer))
            {
                entities = this._context.Customers.ToList();
            }
            else if (typeof(T) == typeof(Order))
            {
                entities = this._context.Orders.Where(i => i.Customer.Id == id).ToList();
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

        //public IHttpActionResult Get(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public IHttpActionResult Post(T type)
        {
            dynamic entity = null;
            if (typeof(T) == typeof(Customer))
            {
                entity = type as Customer;
                this._context.Customers.Add(entity);
            }
            else if (typeof(T) == typeof(Order))
            {
                entity = type as Order;
                this._context.Orders.Add(entity);
            }
            else if (typeof(T) == typeof(Employee))
            {
                entity = type as Employee;
                this._context.Employees.Add(entity);
            }
            else if (typeof(T) == typeof(Service))
            {
                entity = type as Service;
                this._context.Services.Add(entity);
            }

            return entity;
        }

        public IHttpActionResult Put(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}