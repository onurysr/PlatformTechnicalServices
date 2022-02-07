using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlatformTechnicalServices.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformTechnicalServices.Data
{
    public class MyContext : IdentityDbContext<ApplicationUser, ApplicationRole,string>
    {
        public MyContext(DbContextOptions<MyContext> options):base(options)
        {

        }
    }
    
}
