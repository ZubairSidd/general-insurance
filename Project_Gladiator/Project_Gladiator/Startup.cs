using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Project_Gladiator.Data;
using Project_Gladiator.Repositery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Gladiator
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
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("StudentConnection")));
            services.AddScoped<IUserRepositery, UserRepositery>();
            services.AddScoped<IClaimRepositery, ClaimRepositery>();

            services.AddScoped<IDetailsRepositery, DetailsRepositery>();


            services.AddScoped<IPaymentRepositery, PaymentsRepositery>();

            services.AddScoped<IPlan_DetailsRepositery,Plan_DetailsRepositery>();
            services.AddScoped<IPurchaseRepositery,PurchaseRepositery>();
            services.AddScoped<IRenewalRepositery, RenewalRepositery>();
            services.AddCors(options =>
            {
                options.AddPolicy("angularApplication", (builder) =>
                {
                    builder.WithOrigins("http://localhost:4200").AllowAnyOrigin()
                    .AllowAnyHeader()
                    .WithMethods("GET", "POST", "PUT", "DELETE")
                    .WithExposedHeaders("*");
                });
            });
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
            app.UseCors("angularApplication");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
