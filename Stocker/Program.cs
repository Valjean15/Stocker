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
        /// <param name="Arguments">
        ///     Argumentos de la aplicacion
        /// </param>
        public static void Main(string[] Arguments)
        {
            CreateWebHostBuilder(Arguments).Build().Run();
        }

        /// <summary>
        ///     Punto de entrada para la creacion del ambiente de la aplicacion
        /// </summary>
        /// <param name="Arguments">
        ///     Argumentos
        /// </param>
        public static IWebHostBuilder CreateWebHostBuilder(string[] Arguments) =>
            WebHost.CreateDefaultBuilder(Arguments)
                .UseStartup<Startup>();
    }
}
