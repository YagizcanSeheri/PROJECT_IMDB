
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJECT_IMDB.Entity.Entities;
using PROJECT_IMDB.Map.Mapping.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace PROJECT_IMDB.Map.Mapping.Concrete
{
    public class FilmMap:BaseMap<Film>
    {
        public override void Configure(EntityTypeBuilder<Film> builder)
        {
            
            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.Content).IsRequired(true);
            builder.Property(x => x.Image).IsRequired(true);
            builder.Property(x => x.VideoUrl).IsRequired(true);
            
            builder.HasMany(x => x.FilmToCategories).WithOne(x => x.Film).HasForeignKey(x => x.FilmId);

            builder.HasMany(x => x.Likes)
               .WithOne(x => x.Film)
              .HasForeignKey(x => x.FilmId)
              .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            builder.HasMany(x => x.Comments)
               .WithOne(x => x.Film)
              .HasForeignKey(x => x.FilmId)
              .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            builder.HasOne(X => X.AppUser)
                .WithMany(x => x.Films)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}
