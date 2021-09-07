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
using System.Text;
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
            //faz a adi��o dos controllers
            services.AddControllers();
            //transformando chave criada para bts
            var key = Encoding.ASCII.GetBytes(Settings.Secret)
            //aqui ficaria m�todo do token (autentica��o)




            //informa para a aplica��o a exist�ncia de um context
            // services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
            //Conex�o com o BD
            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("connectionString")));

            //Configura��o para fechamento de conex�o com o banco
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

            //uso de autentica��o
            app.UseAuthentication();

            //uso de autoriza��es
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //faz mapeamento dos controllers
                endpoints.MapControllers();
            });
        }
    }
}
