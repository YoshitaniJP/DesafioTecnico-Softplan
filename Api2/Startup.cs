using Domain.Interfaces;
using Domain.Services;
using Infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Polly;
using System;
using System.Net.Http;
using Polly.Extensions.Http;
using AutoMapper;

namespace Api2
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
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddHttpClient<ICalculaJurosService, CalculaJurosService>(options => {
                options.BaseAddress = new Uri(Configuration["AppSettings:Url_ApiTaxaJuros"]);
            }).AddPolicyHandler(GetRetryPolicy());

            
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Api Calcula Juros",
                        Version = "v1",
                        Description = "Api que calcula juros",
                        Contact = new OpenApiContact
                        {
                            Name = "Erick Jose de Souza",
                            Email = "yoshitani.jpo@gmail.com"
                        }
                    });
            });
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Calcula Juros V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(10));
        }
    }
}
