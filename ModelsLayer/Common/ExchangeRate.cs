namespace Models.Common
{
    using System;

    /// <summary>
    ///     Entidad encargada de almacenar tasa de cambio entre monedas.
    ///     <para>
    ///         Se maneja una moneda principal la cual, todas las tasas de cambio estan en funcion
    ///         a la moneda principal.
    ///     </para>
    /// </summary>
    public class ExchangeRate : EntityBase<int>
    {
        /// <summary>
        ///     Fecha de la tasa de cambio
        /// </summary>
        public DateTime ChangeRateDate { get; set; }

        /// <summary>
        ///     Tasa de venta de la moneda principal a la moneda destino
        /// </summary>
        public decimal SaleRate { get; set; }

        /// <summary>
        ///     Tasa de compra de la moneda destino a la moneda principal
        /// </summary>
        public decimal PurchaseRate { get; set; }

        #region Foreing Keys

        /// <summary>
        ///     Llave foranea de la entidad <see cref="Currency"/>
        /// </summary>
        public int CurrencyId { get; set; }

        #endregion

        #region Virtual Properties

        /// <summary>
        ///     Moneda de la cual pertenece la tasa de cambio
        /// </summary>
        public virtual Currency Currency { get; set; }

        #endregion
    }
}
