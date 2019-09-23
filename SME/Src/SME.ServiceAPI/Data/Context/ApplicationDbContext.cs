using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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


        //Db First
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
          
            //Generate Id


            string loginUserId = "";
            var httpContextAccessor = this.GetService<IHttpContextAccessor>();
            var claims = httpContextAccessor?.HttpContext.User.Claims.ToList();
            if (claims.Count > 0)
            {
                loginUserId = claims.Where(x => x.Type == "UserId").First().Value;
            }
            else
            {
                loginUserId = "USER000001";
            }
            ChangeTracker.DetectChanges();


            foreach (var item in ChangeTracker.Entries().Where(s => s.State == EntityState.Modified || s.State == EntityState.Added))
            {

                var entity = item.Entity;
                Type EntityType = entity.GetType();

                if (item.State == EntityState.Added)
                {
                    object keyGenerated = "";
                    string keyColumn = "";// ModelKeyFactory.GetKey(EntityType.Name);
                    if (keyColumn != null && keyColumn.Length > 0)
                    {
                        PropertyInfo pInfoCreatedOn = EntityType.GetProperty("CreatedOn");
                        if (pInfoCreatedOn != null)
                            pInfoCreatedOn.SetValue(entity, DateTime.Now, new object[0]);
                        PropertyInfo pInfoCreatedBy = EntityType.GetProperty("CreatedBy");
                        if (pInfoCreatedBy != null)
                            pInfoCreatedBy.SetValue(entity, loginUserId, new object[0]);


                        PropertyInfo pInfoObjectType = EntityType.GetProperty("ObjectType");
                        if (pInfoObjectType != null && pInfoObjectType.GetValue(entity).ToString().Length > 0)
                        {
                            keyGenerated = GenerateKey(pInfoObjectType.GetValue(entity).ToString());
                        }
                        else
                        {
                            keyGenerated = GenerateKey(EntityType.Name);
                        }
                        PropertyInfo pInfoPrimaryKey = EntityType.GetProperty(keyColumn);

                        switch (pInfoPrimaryKey.PropertyType.Name)
                        {
                            case "Int32":
                                pInfoPrimaryKey.SetValue(entity, Convert.ToInt32(keyGenerated));
                                break;
                            case "String":
                                pInfoPrimaryKey.SetValue(entity, Convert.ToString(keyGenerated));
                                break;
                            default:
                                break;
                        }

                    }
                    PropertyInfo pInfoModifiedOn = EntityType.GetProperty("ModifiedOn");
                    if (pInfoModifiedOn != null)
                        pInfoModifiedOn.SetValue(entity, DateTime.Now, new object[0]);
                    PropertyInfo pInfoModifiedBy = EntityType.GetProperty("ModifiedBy");
                    if (pInfoModifiedBy != null)
                        pInfoModifiedBy.SetValue(entity, loginUserId, new object[0]);

                }
            }



            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }


        private object GenerateKey(string EntityType)
        {
            object keyValue = "";


            using (var command = base.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "EXEC [SP_GENERATE_KEY] '" + EntityType + "'";
                base.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        keyValue = result[0];
                    }
                }
            }
            return keyValue;
        }

    }

}
