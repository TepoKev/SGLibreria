using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SGLibreria.Models;

namespace SGLibreria
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddDbContext<AppDbContext>();


            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = System.TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            /*
            app.Use(
                async (context, next) =>
                {
                    int? IdUsuario = context.Session.GetInt32("IdUsuario");
                    string path = context.Request.Path;
                    //poner punto de interrupcion aqui si se entra en un bucle infinito
                    //intenta acceder a una ruta fuera de /welcome, 
                    //entonces debe ser inmediatamente redirigido al login
                    if (IdUsuario == null && !path.StartsWith("/Welcome/"))
                    {
                        context.Response.Redirect("/Welcome/Login");
                        await next.Invoke();
                    }
                    else if (IdUsuario != null && path.StartsWith("/Welcome/"))
                    {
                        //permitir cerrar sesion en esta ruta
                        if (path == "/Welcome/Logout")
                        {
                            await next.Invoke();
                        }
                        else //no puede acceder a ninguna pagina dentro de /welcome si ya inicio sesion
                        {
                            context.Response.Redirect("/Index");
                            await next.Invoke();
                        }
                    }
                    else
                    {
                        await next.Invoke();
                    }
                }
            );
            */
            app.UseMvc();
        }
    }
}