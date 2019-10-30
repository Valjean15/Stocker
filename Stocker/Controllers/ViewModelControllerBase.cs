using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Mapper.Base;
using Microsoft.AspNetCore.Mvc;
using Models.Interfaces;
using Repository.Store;

namespace Stocker.Controllers
{
    /// <summary>
    ///     Controlador el cual interactura con view models
    /// </summary>
    /// <typeparam name="TViewModel">
    ///     View model a interactuar
    /// </typeparam>
    [Route("api/[controller]"), ApiController]
    public class ViewModelControllerBase<TViewModel, TEntity> : ControllerBase
        where TViewModel : IViewModel<TEntity>
        where TEntity: class, IEntityBase<int>
    {
        #region Variables

        /// <summary>
        ///     Store de la entidad a interactuar
        /// </summary>
        protected readonly IStockerStore<TEntity> Store;

        #endregion

        /// <summary>
        ///     Controlador de la entidad
        /// </summary>
        /// <param name="Store"></param>
        public ViewModelControllerBase(IStockerStore<TEntity> Store)
        {
            this.Store = Store;
        }

        /// <summary>
        ///     Realiza operacion post de una entidad
        /// </summary>
        /// <param name="viewModel">
        ///     Entidad a guardar
        /// </param>
        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TViewModel viewModel)
        {
            var model = viewModel.ToModel();
            if (model is null) NotFound();

            await Store.CreateAsync(model, CancellationToken.None);
            return Ok(viewModel);
        }

        /// <summary>
        ///     Realiza operacion put de una entidad
        /// </summary>
        /// <param name="id">
        ///     Id de la entidad
        /// </param>
        /// <param name="viewModel">
        ///     Entidad a actualizar
        /// </param>
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put(int id, [FromBody] TViewModel viewModel)
        {
            var model = viewModel.ToModel();
            if (model is null) NotFound();

            if (!model.Id.Equals(id)) return NotFound();

            var entityExist = Store.Items.Any(entity => entity.Id == id);
            if (!entityExist) return NotFound();

            await Store.UpdateAsync(model, CancellationToken.None);
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
