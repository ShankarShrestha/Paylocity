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
using Newtonsoft.Json.Serialization;
using API.Interface;
using API.Repository;

namespace API
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
            //Enable CORS
            services.AddCors(
                options =>
                {
                    options.AddPolicy(
                        name: "AllowOrigin",
                        builder => { 
                            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); 
                        });
                });
            

            //JSON Serializer
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                    .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            
            services.AddControllers();

            //services.AddMvc().AddNewtonsoftJson(o => o.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver()); ;
            services.AddControllers().AddJsonOptions(options =>
                                                {
                                                    options.JsonSerializerOptions
                                                        .PropertyNamingPolicy = null;
                                                });


            //For Dependency Injection Life cycle
            services.AddScoped<IEmployeeDependentSeperator, EmployeeDependentSeperator>();
            services.AddScoped<IDeductionCalculation, DeductionCalculation>();

            //services.AddSingleton<IEmployeeDependentSeperator, EmployeeDependentSeperator>();
            //services.AddSingleton<IDeductionCalculation, DeductionCalculation>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowOrigin");

            //app.UseMvc();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}
