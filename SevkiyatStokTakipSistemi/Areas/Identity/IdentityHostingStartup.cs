﻿using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SevkiyatStokTakipSistemi.Data;

[assembly: HostingStartup(typeof(SevkiyatStokTakipSistemi.Areas.Identity.IdentityHostingStartup))]
namespace SevkiyatStokTakipSistemi.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            
        }
    }
}