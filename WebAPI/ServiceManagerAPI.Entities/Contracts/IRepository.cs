namespace ServiceManagerAPI.Entities.Contracts
{
    using System.Collections.Generic;
    using System.Web.Http;

    public interface IRepository<T> where T : IEntity
    {
        IEnumerable<IEntity> Get(int id);

        //IHttpActionResult Get(int id);

        IHttpActionResult Post(T entity);

        IHttpActionResult Put(int id, T entity);

        IHttpActionResult Delete(int id);
    }
}
