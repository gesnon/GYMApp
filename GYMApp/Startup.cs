using GYMApp.Services.Services;
using GYMDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYMApp
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GYMApp", Version = "v1" });
            });

            services.AddDbContext<ContextDB>(options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=GYMDB;Trusted_Connection=true")); // эта строка новая, добавляется при подключении БД

            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IMeasurementService, MeasurementService>();
            services.AddTransient<ITrainerService, TrainerService>();
            services.AddTransient<IReviewService, ReviewService>();
            services.AddTransient<IExerciseService, ExerciseService>();
            services.AddTransient<IRoutineService, RoutineService>();
            services.AddTransient<IRoutineExerciseService, RoutineExerciseService>();
            services.AddTransient<ITrainingDayService, TrainingDayService>();
            services.AddTransient<ITrainingWeekService, TrainingWeekService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GYMApp v1"));
            }

            app.UseHttpsRedirection();
            app.UseCors(c => c.AllowAnyOrigin());
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
