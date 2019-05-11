namespace Models.Shopping
{
    using Models.Common;
    using Models.Workflow;
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     Lote de entrada de una compra 
    /// </summary>
    public class Bundle : EntityBase<int>
    {
        /// <summary>
        ///     Construtor base de la entidad
        /// </summary>
        public Bundle()
        {
            Reference = string.Empty;
            Currency = new Currency();
            State = new State();
            Items = new HashSet<BundleItem>();
        }

        /// <summary>
        ///     Descripcion de referencia del lote
        /// </summary>
        public string Reference { get; set; }

        #region Bundle Currency Values

        /// <summary>
        ///     Impuesto Local del lote de compra
        /// </summary>
        public decimal LocalTax { get; set; }

        /// <summary>
        ///     Flete Local de la compra
        /// </summary>
        public decimal LocalFreight { get; set; }

        /// <summary>
        ///     Impuesto Extranjero del lote de compra
        /// </summary>
        public decimal ForeignTax { get; set; }

        /// <summary>
        ///     Flete Extranjero de la compra
        /// </summary>
        public decimal ForeignFreight { get; set; }

        /// <summary>
        ///     Valor total de todos los productos del Lote
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        ///     Porcentaje de descuento que se aplica al lote entero
        /// </summary>
        public decimal Discount { get; set; }

        #endregion

        #region Bundle Date Values

        /// <summary>
        ///     Fecha en que se ordeno el lote
        /// </summary>
        public DateTime Order { get; set; }

        /// <summary>
        ///     Fecha en que el lote llego
        /// </summary>
        public DateTime Arrival { get; set; }

        #endregion

        #region Foreing Keys

        /// <summary>
        ///     Llave foranea de la entidad <see cref="Common.Currency"/>
        /// </summary>
        public int CurrencyId { get; set; }

        /// <summary>
        ///     Llave foranea de la entidad <see cref="Workflow.State"/>
        /// </summary>
        public int StateId { get; set; }

        #endregion

        #region Virtual Properties

        /// <summary>
        /// <para>
        ///     Propiedad virtual de la llave foranea de <see cref="CurrencyId"/>
        /// </para>
        /// <para>
        ///     Indica la moneda en que se encuntran los montos del Lote
        /// </para>
        /// </summary>
        public virtual Currency Currency { get; set; }

        /// <summary>
        /// <para>
        ///     Propiedad virtual de la llave foranea de <see cref="StateId"/>
        /// </para>
        /// <para>
        ///     Indica el estado actual del lote
        /// </para>
        /// </summary>
        public virtual State State { get; set; }

        /// <summary>
        ///     Lista de productos que pertenecen al Lote
        /// </summary>
        public virtual ICollection<BundleItem> Items { get; set; }

        #endregion
    }
}
