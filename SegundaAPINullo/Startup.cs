using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SegundaAPINullo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegundaAPINullo
{
    public class Startup
    {
        public Startup (IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //faz a adição dos controllers
            services.AddControllers();
            //informa para a aplicação a existência de um context
            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
            //Configuração para fechamento de conexão com o banco
            services.AddScoped<DataContext, DataContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //redirecionamento de https
            app.UseHttpsRedirection();

            //uso de rotas
            app.UseRouting();

            //uso de autorizações
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //faz mapeamento dos controllers
                endpoints.MapControllers();
            });
        }
    }
}
