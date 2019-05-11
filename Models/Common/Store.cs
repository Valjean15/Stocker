namespace Models.Common
{
    using Models.Inventory;
    using System.Collections.Generic;

    /// <summary>
    ///     Entida representa una sucursal o lugar 
    /// </summary>
    public class Store : EntityBase<int>
    {
        /// <summary>
        ///     Constructor base de la entidad
        /// </summary>
        public Store()
        {
            Name = string.Empty;
            Stocks = new HashSet<Stock>();
        }

        /// <summary>
        ///     Nombre de la sucursal
        /// </summary>
        public string Name { get; set; }

        #region Virtual Properties

        /// <summary>
        ///     Inventarios asociados a la sucursal
        /// </summary>
        public virtual ICollection<Stock> Stocks { get; set; }

        #endregion
    }
}
