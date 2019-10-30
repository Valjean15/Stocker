using Models.Common;
using Repository.Store;

namespace Stocker.Controllers.Common
{
    /// <summary>
    ///     Controlador para la vista de marcas
    /// </summary>
    public class BrandController : CrudBaseController<Brand>
    {
        /// <summary>
        ///     Constructor del controlador
        /// </summary>
        /// <param name="Store">
        ///     Store de marcas
        /// </param>
        public BrandController(IStockerStore<Brand> Store) : base(Store)
        {

        }
    }
}
