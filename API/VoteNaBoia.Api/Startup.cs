using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using VoteNaBoia.BLL;
using VoteNaBoia.BLL.Infra;
using VoteNaBoia.DAL;
using VoteNaBoia.DAL.DataBaseContext;
using VoteNaBoia.DAL.Infra;

namespace VoteNaBoia.Api
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
            //CONTEXTO
            services.AddScoped<VoteNaBoiaDbContext>();
            //REPOSITÓRIO
            services.AddScoped<IRestauranteRepository, RestauranteRepository>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();
            services.AddScoped<ITurmaAlunoRepository, TurmaAlunoRepository>();
            services.AddScoped<IPeriodoRepository, PeriodoRepository>();
            services.AddScoped<IPeriodoDiarioRepository, PeriodoDiarioRepository>();
            services.AddScoped<IPeriodoResultadoRepository, PeriodoResultadoRepository>();
            services.AddScoped<IVotoSemanalRepository, VotoSemanalRepository>();
            services.AddScoped<IVotoDiarioRepository, VotoDiarioRepository>();

            //BLL
            services.AddScoped<IRestauranteBLL, RestauranteBLL>();
            services.AddScoped<IAlunoBLL, AlunoBLL>();
            services.AddScoped<ITurmaBLL, TurmaBLL>();
            services.AddScoped<ITurmaAlunoBLL, TurmaAlunoBLL>();
            services.AddScoped<IPeriodoBLL, PeriodoBLL>();
            services.AddScoped<IPeriodoDiarioBLL, PeriodoDiarioBLL>();
            services.AddScoped<IPeriodoResultadoBLL, PeriodoResultadoBLL>();
            services.AddScoped<IVotoSemanalBLL, VotoSemanalBLL>();
            services.AddScoped<IVotoDiarioBLL, VotoDiarioBLL>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(builder => builder
                                    .AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
