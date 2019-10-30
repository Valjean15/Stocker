namespace Models.Sale
{
    using System;

    /// <summary>
    ///     Representa las cuotas de una ventas
    /// </summary>
    public class SaleQuota : EntityBase<int>
    {
        /// <summary>
        ///     Valor de la cuota
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        ///     Indica si la cuota ya esta pagada
        /// </summary>
        public bool Paid { get; set; }

        /// <summary>
        ///     Fecha en que se realizara el pago
        /// </summary>
        public DateTime PaymentDate { get; set; }

        /// <summary>
        ///     Fecha en la que se realiza pago de la cuota
        /// </summary>
        public DateTime? PaidDate { get; set; }

        #region Foreing Keys

        /// <summary>
        ///     Llave foranea de la entidad <see cref="Sale"/>
        /// </summary>
        public int SaleId { get; set; }

        #endregion

        #region Virtual Properties

        /// <summary>
        /// <para>
        ///     Propiedad virtual de la llave foranea de <see cref="SaleId"/>
        /// </para>
        /// <para>
        ///     Indica a que venta pertenece la cuota
        /// </para>
        /// </summary>
        public virtual Sale Sale { get; set; }

        #endregion
    }
}
