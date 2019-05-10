namespace Models.Enums
{
    /// <summary>
    ///     Tipo de item, esto dice en que tan accesible es un item
    /// </summary>
    public enum StockType
    {
        /// <summary>
        ///     Indica el item no se encuentra en alguna sucursal
        /// </summary>
        Virtual = 1,

        /// <summary>
        ///     Indica que el item se encuentra disponible en alguna sucursal
        /// </summary>
        Physical = 2
    }
}
