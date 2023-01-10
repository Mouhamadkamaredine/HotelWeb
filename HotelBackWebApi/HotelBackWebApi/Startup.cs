using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.OpenApi.Models;
using System;

using HotelBackWebApi.Models;
using Microsoft.AspNetCore.Identity;

using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using System.Data.Common;
using Hotel.reposetory;
using Hotel.sql.Operation;
using Hotel.Manager;

namespace HotelBackWebApi 
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
            var connectionString = this.Configuration.GetSection("IdentityConection").Value;
            services.AddScoped(typeof(IRoom), provider => new RoomOp(connectionString));
            services.AddScoped(typeof(IRoomNb), provider => new RoomNbOp(connectionString));
            services.AddScoped<RoomManager>();
             services.AddScoped(typeof(IBooking), provider => new BookingOp(connectionString));
            services.AddScoped<BookinManager>();
            services.AddScoped(typeof(IFacility), provider => new FacilityOp(connectionString));
            services.AddScoped<FacilityManager>();

            services.AddScoped(typeof(IHotelInfo), provider => new HotelInfoOp(connectionString));
            services.AddScoped<FacilityManager>();

            services.AddScoped(typeof(IUser), provider => new UserOp(connectionString));
            services.AddScoped<HotelInfoManager>();

           
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));
            services.AddControllers().AddNewtonsoftJson();
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddDbContext<AuthenticationContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("IdentityConection")));
            services.AddDbContext<RoomsTypeDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("IdentityConection")));


            services.AddDbContext<RoomContext>(options =>
         options.UseSqlServer(Configuration.GetConnectionString("IdentityConection")));
            services.AddDbContext<BookingContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("IdentityConection")));
            services.AddDbContext<StaffContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("IdentityConection")));


            services.AddDefaultIdentity<AplicationUser>().AddEntityFrameworkStores<AuthenticationContext>();
            services.Configure<IdentityOptions>(options => {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength=4;
            
                }
            ) ; 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIHotel", Version = "v1" });
            });

            services.AddCors();
            //Jwt Authentication

            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPIHotel v1"));
            }
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
