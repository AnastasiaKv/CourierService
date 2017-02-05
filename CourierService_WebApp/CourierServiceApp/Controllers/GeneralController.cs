using DAL.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CourierServiceApp.Controllers
{
    public class GeneralController<TEntity> : ApiController where TEntity : class, new()
    {
        [HttpGet]
        public IEnumerable<TEntity> Get()
        {
            return DBManager.UnitOfWork.GetRepository<TEntity>().Get();
        }

        [HttpGet]
        public IHttpActionResult Get(Guid id)
        {
            TEntity entity = DBManager.UnitOfWork.GetRepository<TEntity>().GetByID(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPost]
        public IHttpActionResult Post(TEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DBManager.UnitOfWork.GetRepository<TEntity>().Insert(entity);
            DBManager.UnitOfWork.GetRepository<TEntity>().Save();

            return Ok(entity);
        }

        [HttpPut]
        public IHttpActionResult Put(TEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DBManager.UnitOfWork.GetRepository<TEntity>().Update(entity);
            DBManager.UnitOfWork.GetRepository<TEntity>().Save();

            return Ok(entity);
        }
        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
        {
            TEntity entity = DBManager.UnitOfWork.GetRepository<TEntity>().GetByID(id);
            if (entity == null)
            {
                return NotFound();
            }
            DBManager.UnitOfWork.GetRepository<TEntity>().Delete(entity);
            DBManager.UnitOfWork.GetRepository<TEntity>().Save();

            return Ok(entity);
        }
    }
}

