using System;
using Models.Administration;
using Newtonsoft.Json.Serialization;
using Repository.Store;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DataAccess.Context;

namespace Stocker
{
    /// <summary>
    ///     Clase de inicio de la app
    /// </summary>
    public class Startup
    {
        #region Variables

        /// <summary>
        ///     Configuraciones de la app
        /// </summary>
        public IConfiguration Configuration { get; }

        #endregion

        /// <summary>
        ///     Constructor de la app de la app
        /// </summary>
        /// <param name="Configuration">
        ///     Configuraciones globales de la app
        /// </param>
        public Startup(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        /// <summary>
        ///     Configuraciones de los servicios
        /// </summary>
        /// <param name="Services">
        ///     Serviciones de la app
        /// </param>
        public void ConfigureServices(IServiceCollection Services)
        {
            #region Configuracion de Cookies del sitio

            Services.Configure<CookiePolicyOptions>(Options =>
            {
                Options.CheckConsentNeeded = Context => true;
                Options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            #endregion

            #region Configuracion de Autenticacion de usuarios

            Services
                .AddIdentity<User, IdentityRole>(
                Options =>
                {
                    // Validaciones para la contraseña
                    Options.Password.RequireNonAlphanumeric = false;
                    Options.Password.RequiredUniqueChars = 4;

                    // Validaciones para el usuario
                    Options.User.RequireUniqueEmail = true;

                    // Configuraciones para el bloqueo de usuario
                    Options.Lockout.AllowedForNewUsers = true;
                    Options.Lockout.MaxFailedAccessAttempts = 3;
                    Options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                })
                .AddEntityFrameworkStores<StockerContext>()
                .AddDefaultTokenProviders();

            Services.Configure<DataProtectionTokenProviderOptions>(Options => Options.TokenLifespan = TimeSpan.FromHours(3));
            Services.ConfigureApplicationCookie(Options => Options.LoginPath = "/Account/Login");

            #endregion

            // Configuracion de modelo MVC y forma de serializacion de la informacion
            Services
                .AddMvc()
                .AddJsonOptions(Options => Options.SerializerSettings.ContractResolver = new DefaultContractResolver())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Configuracion del contexto de uso de la aplicacion
            Services.AddDbContext<StockerContext>(Options =>
                Options
                    .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            // Configuracion de servicios a nivel de ambito
            Services.AddScoped(typeof(IStockerStore<>), typeof(StockerStore<>));
        }

        /// <summary>
        ///     Configuraciones aplicadas en tiempo de ejecucion
        /// </summary>
        /// <param name="Application">
        ///     Builder de la app
        /// </param>
        /// <param name="Environment">
        ///     Ambiente de trabajo de la app
        /// </param>
        public void Configure(IApplicationBuilder Application, IHostingEnvironment Environment)
        {
            if (Environment.IsDevelopment())
            {
                Application.UseDeveloperExceptionPage();
            }
            else
            {
                Application.UseHsts();
            }

            Application.UseHttpsRedirection();
            Application.UseMvc();

            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("index.html");
            Application.UseDefaultFiles(options);
            Application.UseStaticFiles();
        }
    }
}
