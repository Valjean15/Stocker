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
        /// <param name="ViewModel">
        ///     Entidad a guardar
        /// </param>
        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TViewModel ViewModel)
        {
            var Model = ViewModel.ToModel();
            if (Model is null) NotFound();

            await Store.CreateAsync(Model, CancellationToken.None);
            return Ok(ViewModel);
        }

        /// <summary>
        ///     Realiza operacion put de una entidad
        /// </summary>
        /// <param name="Id">
        ///     Id de la entidad
        /// </param>
        /// <param name="ViewModel">
        ///     Entidad a actualizar
        /// </param>
        [HttpPut("{Id}")]
        public virtual async Task<IActionResult> Put(int Id, [FromBody] TViewModel ViewModel)
        {
            var Model = ViewModel.ToModel();
            if (Model is null) NotFound();

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
