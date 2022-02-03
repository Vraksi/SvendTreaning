using Identity.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity
{
    public class Startup
    {
        readonly string test = "test";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("IdentityServer")));
            services.AddDbContext<WebshopContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("FastfoodServer")));
            
            // adding cors policy so that front end and bakcend can talk to eachother
            services.AddCors(options =>
            {
                options.AddPolicy(name: test,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200")
                                      // Should be explained but should be able to just google the definition
                                        .AllowAnyHeader()
                                        .AllowCredentials();
                                  });
            });
            // Requires the user to be authenticated for them to able to use the database
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequiredAuthenticatedUser", policy => {
                    policy.RequireAuthenticatedUser();
                });
                //options.AddPolicy("A", policy => policy.AddAuthenticationSchemes("Admin"));
            });
            // samesite is for using setting cookie policy,
            // none means thirdparty cookies are accepted.
            // lax means just first party cookies
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "Doom";
                options.Cookie.SameSite = SameSiteMode.None;
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();
      
            app.UseRouting();
            //needed for the cors policy to take effect.
            app.UseCors(test);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
