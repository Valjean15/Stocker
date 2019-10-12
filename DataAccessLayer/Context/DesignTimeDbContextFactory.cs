namespace DataAccessLayer.Context
{
    using System.IO;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    ///     Clase usada cuando se ejecuta un comando "dotnet ef (ef commands)" la cual construye el contexto usado por el comando.
    /// </summary>
    /// <remarks>
    ///     Con esto ganamos separar las migraciones del proyecto base.
    /// </remarks>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<StockerContext>
    {
        /// <summary>
        ///     Método que se ejecuta para contruir el contexto de base de datos cuando se ejecuta algun comendo de entity framework core.
        /// </summary>
        /// <param name="Arguments">
        ///     Lista de argumentos que recibe atravez de comando "dotnet ef (ef commands)"
        /// </param>
        /// <returns>
        ///     Regresa el contexto de base de datos a usar
        /// </returns>
        public StockerContext CreateDbContext(string[] Arguments)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var OptionsBuilder = new DbContextOptionsBuilder<StockerContext>();
            //var ConnectionString = builder.GetConnectionString("DefaultConnections");
            var ConnectionString = "Server=tcp:localhost,1433;Database=StockerDatabase;Trusted_Connection=false;MultipleActiveResultSets=true;User Id=sa;Password=SqlServer1234";
            OptionsBuilder.UseSqlServer(ConnectionString, Options => Options.MigrationsAssembly("DataAccessLayer"));
            return new StockerContext(OptionsBuilder.Options);
        }
    }
}
