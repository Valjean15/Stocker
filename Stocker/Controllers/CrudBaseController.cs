using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Models.Interfaces;
using Repository.Store;

namespace Stocker.Controllers
{
    /// <summary>
    ///     Controlador base para crud de entidades
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Tipo de la entidad a interacturar
    /// </typeparam>
    [Route("api/[controller]"), ApiController]
    public abstract class CrudBaseController<TEntity> : ControllerBase
        where TEntity : class, IEntityBase<int>
    {
        #region Variables

        /// <summary>
        ///     Store de la entidad
        /// </summary>
        protected readonly IStockerStore<TEntity> Store;

        #endregion

        /// <summary>
        ///     Controlador base
        /// </summary>
        /// <param name="Store">
        ///     Store de la entidad
        /// </param>
        protected CrudBaseController(IStockerStore<TEntity> Store)
        {
            this.Store = Store;
        }

        /// <summary>
        ///     Obtiene todos los elementos de la entidad
        /// </summary>
        [HttpGet]
        public virtual IActionResult Get() => Ok(Store.Items);
        
        /// <summary>
        ///     Obtiene una entidad por id
        /// </summary>
        /// <param name="id">
        ///     Id del item
        /// </param>
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            var entity = await Store.FindByKey(id, CancellationToken.None);
            if (entity is null) return NotFound();

            return Ok(entity);
        }

        /// <summary>
        ///     Realiza operacion post de una entidad
        /// </summary>
        /// <param name="entity">
        ///     Entidad a guardar
        /// </param>
        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TEntity entity)
        {
            await Store.CreateAsync(entity, CancellationToken.None);
            return Ok(entity);
        }

        /// <summary>
        ///     Realiza operacion put de una entidad
        /// </summary>
        /// <param name="id">
        ///     Id de la entidad
        /// </param>
        /// <param name="entity">
        ///     Entidad a actualizar
        /// </param>
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put(int id, [FromBody] TEntity entity)
        {
            if (!entity.Id.Equals(id)) return NotFound();

            var entityExist = Store.Items.Any(entity => entity.Id == id);
            if (!entityExist) return NotFound();

            await Store.UpdateAsync(entity, CancellationToken.None);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var entity = await Store.FindByKey(id, CancellationToken.None);
            if (entity is null) return NotFound();

            await Store.DeleteAsync(entity, CancellationToken.None);
            return Ok();
        }
    }
}
