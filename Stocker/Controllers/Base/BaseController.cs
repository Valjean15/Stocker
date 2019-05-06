using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sis.DAL.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stocker.Controllers.Base
{
    public class BaseController<TContext, TEntity> : ControllerBase 
        where TEntity : class
        where TContext : DbContext, new ()
    {
        /// <summary>
        /// Repositorio base
        /// </summary>
        protected BaseRepository<TEntity> Repository;

        /// <summary>
        /// Contexto de consultas
        /// </summary>
        public TContext Context;

        /// <summary>
        /// Constructor base
        /// </summary>
        public BaseController()
        {
            Context = new TContext();
            Repository = new BaseRepository<TEntity>(Context);
        }

        /// <summary>
        /// Obtiene todos los datos
        /// </summary>
        public virtual ActionResult<IEnumerable<TEntity>> Get() => Ok(Repository.GetAll());

        /// <summary>
        /// Obtiene una entidad por ID
        /// </summary>
        /// <param name="id">Id de la entidad</param>
        public virtual ActionResult<IEnumerable<TEntity>> Get(int id)
        {
            var record = Repository.FindByKey(id);
            return record == null 
                ? (ActionResult<IEnumerable<TEntity>>)NoContent() 
                : (ActionResult<IEnumerable<TEntity>>)Ok(record);
        }

        /// <summary>
        /// Obtiene todos los datos paginados
        /// </summary>
        /// <param name="page">Numero de pagina</param>
        /// <param name="start">Inicio de registros</param>
        /// <param name="limit">Numero de registros</param>
        public virtual ActionResult<IEnumerable<TEntity>> Get(int page, int start, int limit)
        {
            try
            {
                var list = Repository.GetAll().OrderBy(p => "Id").Skip(start).Take(limit);
                return Ok(list.ToList());
            }
            catch (InvalidOperationException)
            {
                var list = Repository.GetAll().Skip((page - 1) * limit).Take(limit);
                return Ok(list);
            }
        }

        /// <summary>
        /// Realiza guardado de una entidad
        /// </summary>
        /// <param name="entity">Entidad a guardar/param>
        public virtual ActionResult Post(TEntity entity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Repository.Add(entity);
            Repository.Save();

            return Ok(entity);
        }

        /// <summary>
        /// Realiza actualizacion de una entidad
        /// </summary>
        /// <param name="id">Id de la entidad</param>
        /// <param name="entity">Entidad</param>
        public virtual ActionResult Put(int id, TEntity entity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Repository.Edit(entity);
            Repository.Save();

            return Ok(entity);
        }

        /// <summary>
        /// Elimina entidad por id
        /// </summary>
        /// <param name="id">Id de la entidad</param>
        /// <returns></returns>
        public virtual ActionResult Delete(int id)
        {
            var entity = Repository.FindByKey(id);
            if (entity == null)
                return NotFound();

            Repository.Delete(entity);
            Repository.Save();

            return Ok(entity);
        }
    }
}
