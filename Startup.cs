using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_netcore_and_ef.Data;
using api_netcore_and_ef.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace api_netcore_and_ef
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(); 
            //Compactação
            services.AddResponseCompression();
            //Um escopo por requisição
            services.AddScoped<StoreDataContext, StoreDataContext>();
            //varios escopos por requisição 
            services.AddTransient<ProductRepository, ProductRepository>();
            //adicionando Swagger
            services.AddSwaggerGen(x=>{
                x.SwaggerDoc("v1", new Info{Title= "api_netcore_ande_ef", Version= "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseMvc();

            app.UseResponseCompression();

            app.UseSwagger();

            app.UseSwaggerUI(c=>{

                c.SwaggerEndpoint("/swagger/v1/swagger.json","My_Api_v1");
                
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("AOôoo Mundão Véio e sem porteraaa!");
            });
        }
    }
}
