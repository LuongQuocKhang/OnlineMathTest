using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineMathTest.Context;
using OnlineMathTest.Common;
using OnlineMathTest.Context.IUnitOfWork;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.AspNetCore.Identity.UI.Services;
using OnlineMathTest.ViewModel;
using OnlineMathTest.Models.Models;
using OnlineMathTest.Interfaces;
using OnlineMathTest.Services;

namespace OnlineMathTest
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/src";
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>()
                  .AddRoles<IdentityRole>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddCors(options => options.AddPolicy("AllowAll", p => p
                                               .AllowAnyOrigin()
                                               .AllowAnyMethod()
                                               .AllowAnyHeader()));

            
            // using Microsoft.AspNetCore.Identity.UI.Services;
            //services.AddSingleton<IEmailSender, EmailSender>();

            ConfigureServiceLayer(services);
            ConfigureRepository(services);
            ConfigureContext(services);
            ConfigureMapper(services);
        }
        public void ConfigureServiceLayer(IServiceCollection services)
        {
            services.AddScoped<IMCQService, MCQService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStatisticsService, StatisticsService>();
        }
        public void ConfigureRepository(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        public void ConfigureContext(IServiceCollection services)
        {
            services.AddDbContext<Context.ApplicationDbContext>(options => options.UseSqlServer(SqlCommon.CONNECTION_STRING));
            services.AddScoped<IContext, ApplicationDbContext>();
        }
        public void ConfigureMapper(IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Mcq, MCQViewModel>();
                cfg.CreateMap<MCQViewModel, Mcq>();

                cfg.CreateMap<QuestionViewModel, Question>();
                cfg.CreateMap<Question, QuestionViewModel>();

                cfg.CreateMap<QuestionAnswer, QuestionAnswerViewModel>();
                cfg.CreateMap<QuestionAnswerViewModel, QuestionAnswer>();

                cfg.CreateMap<QuestionTypeViewModel, QuestionType>();
                cfg.CreateMap<QuestionType, QuestionTypeViewModel>();

                cfg.CreateMap<LevelViewModel, Level>();
                cfg.CreateMap<Level, LevelViewModel>();

                cfg.CreateMap<User, UserViewModel>().ForMember(x => x.Id,opt => opt.Ignore());
                cfg.CreateMap<UserViewModel, User>().ForMember(x => x.Id, opt => opt.Ignore());

                cfg.CreateMap<User, UserReturnViewModel>();
                cfg.CreateMap<UserReturnViewModel, User>();

                cfg.CreateMap<UserTest, UserTestViewModel>();
                cfg.CreateMap<UserTestViewModel, UserTest>();
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors("AllowAll");
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseHttpsRedirection();
            app.UseSpaStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                    spa.Options.StartupTimeout = TimeSpan.FromSeconds(200);
                }
            });
        }
    }
}
