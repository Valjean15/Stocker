namespace DataAccess.Context
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models.Administration;

    /// <summary>
    ///     Contexto utilizado para comunicacion con la BD
    /// </summary>
    public partial class StockerContext : IdentityDbContext<User>
    {
        /// <summary>
        ///     Constructor base del contexto
        /// </summary>
        /// <param name="options">
        ///     Opciones de configuracion del contexto
        /// </param>
        public StockerContext(DbContextOptions<StockerContext> options) : base(options) { }
    }
}
