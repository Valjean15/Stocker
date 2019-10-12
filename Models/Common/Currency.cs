namespace Models.Common
{
    using System.Collections.Generic;

    /// <summary>
    ///     Entidad que representa a la moneda
    /// </summary>
    public class Currency : EntityBase<int>
    {
        /// <summary>
        ///     Construtor base de la entidad
        /// </summary>
        public Currency()
        {
            Name = string.Empty;
            Symbol = string.Empty;
        }

        /// <summary>
        ///  Nombre de la moneda
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Simbolo que representa la moneda
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        ///     Indica si es la moneda principal
        /// </summary>
        public bool Principal { get; set; }

        #region Virtual Properties

        /// <summary>
        ///     Tasas de cambios asociadas a esta moneda
        /// </summary>
        public virtual ICollection<ExchangeRate> ExchangesRates { get; set; }

        #endregion 
    }
}
