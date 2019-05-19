namespace Models.Common
{
    using System;

    /// <summary>
    ///     Entidad encargada de almacenar tasa de cambio entre monedas
    /// </summary>
    public class ExchangeRate : EntityBase<int>
    {
        /// <summary>
        ///      Construtor base de la entidad
        /// </summary>
        public ExchangeRate()
        {
        }

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
        ///     LLave foranea de la entidad <see cref="Currency"/>
        /// </summary>
        /// 
        public int PrincipalCurrencyId { get; set; }

        /// <summary>
        ///     Llave foranea de la entidad <see cref="Currency"/>
        /// </summary>
        public int CurrencyId { get; set; }

        #endregion
    }
}
