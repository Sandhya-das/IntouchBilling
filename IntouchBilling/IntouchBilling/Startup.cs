using IntouchBilling.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IntouchBilling.Data;

namespace IntouchBilling
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
            services.AddRazorPages();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<IDapperService, DapperService>();
            services.AddTransient<IBillingRepository, BillingRepository>();
            services.AddTransient<IReportRepository, ReportRepository>();
            services.AddDbContext<IntouchBillingContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("IntouchBillingContext")));
            services.AddSession();
            //services.AddMvc().AddRazorPagesOptions(options =>
            //{
            //    options.Conventions.AddPageRoute("/Login", "");
            //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
            //DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            //defaultFilesOptions.DefaultFileNames.Clear();
            //defaultFilesOptions.DefaultFileNames.Add("Login.cshtml");
            ////Setting the Default Files
            //app.UseDefaultFiles(defaultFilesOptions);
            ////Adding Static Files Middleware to serve the static files
            //app.UseStaticFiles();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Request handled by the terminating middleware");
            //});

        }
    }
}
