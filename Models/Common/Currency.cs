namespace Models.Common
{
    /// <summary>
    /// Entidad que representa a la moneda
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// LLave primaria
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre de la moneda
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Simbolo que representa la moneda
        /// </summary>
        public string Symbol { get; set; }
    }
}
