using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetoAspNetMVC.Repository.Interfaces;
using ProjetoAspNetMVC.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAspNetMVC.Presentation
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
            //definir o padrão de navegação do projeto (CONTROLLER/VIEW)
            services.AddControllersWithViews();

            //capturar a connectionstring do banco de dados
            var connectionstring = Configuration.GetConnectionString("Conexao");

            //Injeção de dependencia para as classes e interfaces da camada de repositorio do sistema
            services.AddTransient<IUsuarioRepository, UsuarioRepository>
                (map => new UsuarioRepository(connectionstring));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //definir o caminho da página inicial do projeto
                endpoints.MapControllerRoute(
                    name: "default", //página inicial
                    pattern: "{controller=Account}/{action=Login}" // caminho
               );
            });
        }
    }
}
