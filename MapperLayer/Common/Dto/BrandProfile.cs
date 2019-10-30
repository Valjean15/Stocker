using Mapper.Base;

namespace Mapper.Common.Dto
{
    /// <summary>
    ///     Dto de perfil de una marca
    /// </summary>
    public class BrandProfile : IModelDto
    {
        /// <summary>
        ///     Id de la marca
        /// </summary>
        public int BrandId { get; set; }

        /// <summary>
        ///     Nombre de la marca
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        ///     Numero total de productos asociados
        /// </summary>
        public int TotalProducts { get; set; }

        /// <summary>
        ///     Numero de ventas asociadas
        /// </summary>
        public int SalesCounts { get; set; }

        /// <summary>
        ///     Total de dinero generado por ventas
        /// </summary>
        public decimal TotalSales { get; set; }

        /// <summary>
        ///     Numero de inventarios asociados con la marca
        /// </summary>
        public int InventoriesCounts { get; set; }

        /// <summary>
        ///     Total de dinero en inventario por producto
        /// </summary>
        public int TotalInventories { get; set; }

        /// <summary>
        ///     Numero de compras asociadas a esta marca
        /// </summary>
        public int BundlesCounts { get; set; }

        /// <summary>
        ///     Total de dinero invertido en esta marca
        /// </summary>
        public decimal TotalBundles { get; set; }
    }
}
