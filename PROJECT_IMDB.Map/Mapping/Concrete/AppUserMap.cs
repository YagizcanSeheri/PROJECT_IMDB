using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJECT_IMDB.Entity.Entities;
using PROJECT_IMDB.Map.Mapping.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace PROJECT_IMDB.Map.Mapping.Concrete
{
    public class AppUserMap:BaseMap<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder) 
        {
            
            builder.Property(x => x.UserName).IsRequired(true);
            builder.Property(x => x.Password).IsRequired(true);
            builder.Property(x => x.Email).IsRequired(true);

            builder.HasMany(x => x.Likes)
               .WithOne(x => x.AppUser)
              .HasForeignKey(x => x.AppUserId);

            builder.HasMany(x => x.Comments)
               .WithOne(x => x.AppUser)
              .HasForeignKey(x => x.AppUserId);


            builder.HasMany(x => x.Films)
                .WithOne(x => x.AppUser)
                .HasForeignKey(x => x.AppUserId);
            

            base.Configure(builder);
                
        }
    }
}
