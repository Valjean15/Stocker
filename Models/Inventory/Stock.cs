﻿using Models.Common;
using Models.Workflow;
using System.Collections.Generic;

namespace Models.Inventory
{
    /// <summary>
    /// Hace referencia a un inventario
    /// </summary>
    public class Stock
    {
        /// <summary>
        /// Llave primaria
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del inventario
        /// </summary>
        public string Name { get; set; }

        #region Foreing Keys

        /// <summary>
        /// Llave foranea de la entidad <see cref="Common.Store"/>
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// Llave foranea de la entidad <see cref="Workflow.State"/>
        /// </summary>
        public int StateId { get; set; }

        #endregion

        #region Virtual Properties

        /// <summary>
        /// <para>Propiedad virtual de la llave foranea de <see cref="StoreId"/></para>
        /// <para>Inidica la sucursal donde se encuentra este inventario</para>
        /// </summary>
        public virtual Store Store { get; set; }

        /// <summary>
        /// <para>Propiedad virtual de la llave foranea de <see cref="StateId"/></para>
        /// <para>Indica el estado actual del inventario</para>
        /// </summary>
        public virtual State State { get; set; }

        /// <summary>
        /// Items asociados al almacen
        /// </summary>
        public virtual ICollection<StockItem> Items { get; set; }

        #endregion
    }
}
