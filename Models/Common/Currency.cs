namespace Models.Common
{
    /// <summary>
    ///     Entidad que representa a la moneda
    /// </summary>
    public class Currency : EntityBase<int>
    {
        /// <summary>
        ///  Nombre de la moneda
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Simbolo que representa la moneda
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        ///     Indica si la moneda principal
        /// </summary>
        public bool Principal { get; set; }
    }
}
