using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using MyFirstProject.Api.Configuration;
using MyFirstProject.Api.Middleware;
using MyFirstProject.Api.Logging;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using MyFirstProject.Infra.IoC;
using MyFirstProject.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System;

namespace MyFirstProject.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // SERVICOS DA API
            services.WebApiConfig();

            services.AddDbContext<MyFirstProjectContext>();

            // services.AddDbContext<MyFirstProjectContext>(options =>
            //     options.UseSqlServer(
            //         Configuration.GetConnectionString("MyFirstProjectDbBase"),
            //          c => c.EnableRetryOnFailure( // RETRY EM CASO DE FALHA DE CONEXAO
            //          maxRetryCount: 2, // QTD DE TENTATIVAS
            //          maxRetryDelay: TimeSpan.FromSeconds(5), // QTD SEGUNDOS PARA A PROXIMA TENTATIVA
            //          errorNumbersToAdd: null) // ERROS ADICIONAIS (DEIXADO O PADRAO NULL)
            //          .MigrationsHistoryTable("migration-history"))); // ALTERANDO NOME DA TABELA DE MIGRAÇÃO));

            services.RegisterServices();

            services.AddMediatR(typeof(Startup));

            // SERVICOS DO SWAGGER
            services.AddSwaggerConfig();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
        IApiVersionDescriptionProvider provider, ILoggerFactory loggerFactory)
        {
            // AMBIENTE DEV
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // MIDDLEWARE PARA EXCEÇÃO GLOBAL
            app.UseMiddleware<ExceptionMiddleware>();

            // LOG CUSTOMIZADO
            loggerFactory.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration
            {
                LogLevel = LogLevel.Information
            }));

            app.UseRouting();

            // HABILITA O CORS (Cross-Origin Resource Sharing)
            // IMPLEMENTADO PELO NAVEGADOR
            // UM SITE POSSA ACESSAR RECURSOS DE OUTRO SITE
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // AUTENTICACAO E AUTORIZACAO
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // CONFIGURA O SWAGGER SEPARANDO POR VERSOES
            app.UseSwaggerConfig(provider);
        }
    }
}
