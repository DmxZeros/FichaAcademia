using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using FichaAcademia.AcessoDados;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Rotativa.AspNetCore;
using FichaAcademia.AcessoDados.Interfaces;
using FichaAcademia.AcessoDados.Repositorios;

namespace FichaAcademia
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
            services.AddControllersWithViews();

            services.AddDbContext<Contexto>(opcoes => opcoes.UseSqlServer(Configuration.GetConnectionString("Conexao")));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<ICategoriaExercicioRepositorio,CategoriaExercicioRepositorio>();
            services.AddTransient<IAdministradorRepositorio, AdministradorRepositorio>();
            services.AddTransient<IExercicioRepositorio, ExercicioRepositorio>();
            services.AddTransient<IProfessorRepositorio, ProfessorRepositorio>();
            services.AddTransient<IObjetivoRepositorio, ObjetivoRepositorio>();
            services.AddTransient<IAlunoRepositorio, AlunoRepositorio>();
            services.AddTransient<IFichaRepositorio, FichaRepositorio>();
            services.AddTransient<IListaExercicioRepositorio, ListaExercicioRepositorio>();

            //a sessao tera duracao de 1 hora
            services.AddSession(opcoes =>
            {
                opcoes.IdleTimeout = TimeSpan.FromHours(1);
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opcoes => 
            {
                opcoes.LoginPath = "/Administradores/Login";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();
            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            RotativaConfiguration.Setup(env);


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Administradores}/{action=Login}/{id?}");

                //pattern: "{controller=CategoriasExercicios}/{action=Index}/{id?}");
            });
        }
    }
}
