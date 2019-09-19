using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SME.ServiceAPI.Common.Entities;
using SME.ServiceAPI.Common.Idenitity;

namespace SME.ServiceAPI.Data.Context
{
    public partial class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Branch>(BranchMap);
            builder.Entity<Branch>(CustomerMap);
         

            base.OnModelCreating(builder);
        }


      
        public async Task SaveAsync()
        {
           await base.SaveChangesAsync();
        }




    }
}
