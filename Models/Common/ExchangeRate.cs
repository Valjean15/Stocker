namespace Models.Common
{
    using System;

    /// <summary>
    ///     Entidad encargada de almacenar tasa de cambio entre monedas
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
        ///     LLave foranea de la entidad <see cref="Common.Currency"/>
        /// </summary>
        public int PrincipalCurrencyId { get; set; }

        /// <summary>
        ///     Llave foranea de la entidad <see cref="Common.Currency"/>
        /// </summary>
        public int CurrencyId { get; set; }

        #endregion

        #region Virtual Properties

        /// <summary>
        /// <para>
        ///     Propiedad virtual de la llave foranea de <see cref="PrincipalCurrencyId"/>
        /// </para>
        /// <para>
        ///     Indica la moneda la moneda de referencia para la tasa de cambio
        /// </para>
        /// </summary>
        public virtual Currency PrincipalCurrency { get; set; }

        /// <summary>
        /// <para>
        ///     Propiedad virtual de la llave foranea de <see cref="CurrencyId"/>
        /// </para>
        /// <para>
        ///     Indica la moneda a la cual se convierte la moneda principal
        /// </para>
        /// </summary>
        public virtual Currency Currency { get; set; }

        #endregion
    }
}
