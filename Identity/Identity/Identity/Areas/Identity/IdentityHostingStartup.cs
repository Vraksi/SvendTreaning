﻿using System;
using Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Identity.Areas.Identity.IdentityHostingStartup))]
namespace Identity.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
               services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
               //For at roles fungere skal man have addroles<IdentityRole>() med   
               .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<ApplicationDbContext>();

               
                services.AddAuthorization(options =>
                {
                    options.AddPolicy("RequiredAuthenticatedUser", policy => {
                        policy.RequireAuthenticatedUser();
                    });
                    options.AddPolicy("RequireAdminUser", policy => {
                        policy.RequireRole("Admin");
                    });

                });
            });
        }
    }
}