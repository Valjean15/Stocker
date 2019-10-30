using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Stocker
{
    /// <summary>
    ///     Clase de entrada del programa
    /// </summary>
    public class Program
    {
        /// <summary>
        ///     Metodo inical del programa
        /// </summary>
        /// <param name="args">
        ///     Argumentos de la aplicacion
        /// </param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        ///     Punto de entrada para la creacion del ambiente de la aplicacion
        /// </summary>
        /// <param name="args">
        ///     Argumentos
        /// </param>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
