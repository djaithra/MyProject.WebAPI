using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MyProject.Security.Auth;
using MyProject.WebAPI;

namespace MyProject
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
            var key = "This is my test Key for application";
            services.AddControllers();
            services.ConfigureAuthentication(key);
            services.ConfigureSqlServerContext(Configuration);

            services.AddSingleton<IJwtAuthenticationManager>(new JwtAuthenticationManager(key));           
            //services.AddSingleton<IJwtAuthenticationManager,JwtAuthenticationManager>();
            services.AddSingleton<ITokenManager,TokenManager>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseExceptionHandler(config =>
            //{
            //    config.Run(async context =>
            //    {
            //        context.Response.StatusCode = 500;
            //        context.Response.ContentType = "application/json";
            //        var error = context.Features.Get<IExceptionHandlerFeature>();
            //        if (error != null)
            //        {
            //            var ex = error.Error;
            //            await context.Response.WriteAsync(new ErrorModel()
            //            {
            //                StatusCode = 500,
            //                ErrorMessage = ex.Message
            //            }.ToString()); 
            //        }
            //    });
            //});
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}