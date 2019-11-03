using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Models.Interfaces;
using Repository.Store;
using Proxy.Base;
using Proxy.ErrorHandler;

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
            this.Store = (IStockerStore<TEntity>)Store.Decorate<ErrorHandler>();
        }

        /// <summary>
        ///     Obtiene todos los elementos de la entidad
        /// </summary>
        [HttpGet]
        public virtual IActionResult Get() => Ok(Store.Items);
        
        /// <summary>
        ///     Obtiene una entidad por id
        /// </summary>
        /// <param name="Id">
        ///     Id del item
        /// </param>
        [HttpGet("{Id}")]
        public virtual async Task<IActionResult> Get(int Id)
        {
            var Model = await Store.FindByKey(Id, CancellationToken.None);
            if (Model is null) return NotFound();

            return Ok(Model);
        }

        /// <summary>
        ///     Realiza operacion post de una entidad
        /// </summary>
        /// <param name="Model">
        ///     Entidad a guardar
        /// </param>
        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TEntity Model)
        {
            await Store.CreateAsync(Model, CancellationToken.None);
            return Ok(Model);
        }

        /// <summary>
        ///     Realiza operacion put de una entidad
        /// </summary>
        /// <param name="Id">
        ///     Id de la entidad
        /// </param>
        /// <param name="Model">
        ///     Entidad a actualizar
        /// </param>
        [HttpPut("{Id}")]
        public virtual async Task<IActionResult> Put(int Id, [FromBody] TEntity Model)
        {
            if (!Model.Id.Equals(Id)) return NotFound();

            var Exist = Store.Items.Any(Model => Model.Id == Id);
            if (!Exist) return NotFound();

            await Store.UpdateAsync(Model, CancellationToken.None);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{Id}")]
        public virtual async Task<IActionResult> Delete(int Id)
        {
            var Model = await Store.FindByKey(Id, CancellationToken.None);
            if (Model is null) return NotFound();

            await Store.DeleteAsync(Model, CancellationToken.None);
            return Ok();
        }
    }
}
