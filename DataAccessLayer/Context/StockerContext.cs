namespace DataAccessLayer.Context
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    ///     Contexto utilizado para comunicacion con la BD
    /// </summary>
    partial class StockerContext : DbContext
    {
        /// <summary>
        ///     Constructor base del contexto
        /// </summary>
        /// <param name="options">
        ///     Opciones de configuracion del contexto
        /// </param>
        public StockerContext(DbContextOptions<StockerContext> options) : base(options)
        {
        }
    }
}
