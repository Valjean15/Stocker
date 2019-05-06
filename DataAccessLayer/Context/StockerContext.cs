using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context
{
    /// <summary>
    /// Contexto utilizado para comunicacion con la BD
    /// </summary>
    class StockerContext : DbContext
    {
        /// <summary>
        /// Constructor base del contexto
        /// </summary>
        /// <param name="options">Opciones del contexto</param>
        public StockerContext(DbContextOptions<StockerContext> options) : base(options)
        {
        }
    }
}
