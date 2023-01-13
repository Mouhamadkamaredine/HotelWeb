using Hotel.Manager;
using Hotel.reposetory;
using Hotel.sql.Operation;
using HotelBackWebApi.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace HotelUserWeb
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
            var connectionString = this.Configuration.GetSection("IdentityConection").Value;
            services.AddScoped(typeof(IRoom), provider => new RoomOp(connectionString));
         
            services.AddScoped<RoomManager>();

            services.AddScoped(typeof(IFacility), provider => new FacilityOp(connectionString));

            services.AddScoped<FacilityManager>();
            services.AddScoped(typeof(IHotelInfo), provider => new HotelInfoOp(connectionString));

            services.AddScoped<HotelInfoManager>();
            services.AddControllers().AddNewtonsoftJson();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddDbContext<AuthenticationContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("IdentityConection")));
          

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIHotel", Version = "v1" });
            });

            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPIHotel v1"));
                app.UseAuthentication();
                app.UseCors(builder =>
         builder.WithOrigins(Configuration["ApplicationSettings:Client_URL"].ToString()).AllowAnyHeader().AllowAnyMethod());
                app.UseAuthentication();
                app.UseRouting();

                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

                app.Use(async (ctx, next) =>
                {
                    await next();
                    if (ctx.Response.StatusCode == 204)
                    {
                        ctx.Response.ContentLength = 0;
                    }
                });

                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
            }

        }


        }
}
