using FeriasCo.Cortex.Entidades;
using FeriasCo.Cortex.Interfaces;
using FeriasCo.Cortex.Interfaces.Repositorios;
using FeriasCo.Cortex.Servicos;
using FeriasCo.Cortex.Validadores;
using FeriasCo.Mock.Repositorio.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FeriasCo.WebApi
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
            services.AddScoped<IQuartoRepositorio, QuartoRepositorio>();
            services.AddScoped<QuartoServico>();

            services.AddSingleton<IValidador<Reserva>, ReservaValidador>();
            services.AddScoped<IReservaRepositorio, ReservaRepositorio>();
            services.AddScoped<IReservaResumoRepositorio, ReservaResumoRepositorio>();
            services.AddScoped<IQuartoRepositorio, QuartoRepositorio>();
            services.AddScoped<ReservaServico>();

            services.AddControllers();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ferias & Co API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
