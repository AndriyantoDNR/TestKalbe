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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using orderapi.Models;
using Swashbuckle.AspNetCore.Swagger;
using ItemMasterMagentoApi.Models;
using Microsoft.OpenApi.Models;
using ItemMasterMagentoApi.BusinessServices;
using BackEndKalbeFarm.BusinessServices;

namespace ItemMasterMagentoApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
       
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<mscontext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("Microservices_STG")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.Configure<AuthLogin>(Configuration.GetSection("AuthLogin"));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("kalbefarmaapi", new OpenApiInfo { Title = "Item Master API", Version = "v1" });
            });
            //services.AddTransient<RepositoryItemMasterOddo, ItemMasterOddo>();
            services.AddTransient<RepositoryTestKalbeFarma, TestKalbeFarma>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/kalbefarmaapi/swagger.json", "Item Master API V1.0.0");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
