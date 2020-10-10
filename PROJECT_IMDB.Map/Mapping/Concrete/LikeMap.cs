using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJECT_IMDB.Entity.Entities;
using PROJECT_IMDB.Map.Mapping.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace PROJECT_IMDB.Map.Mapping.Concrete
{
    public class LikeMap:BaseMap<Like>
    {
        public override void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.HasOne(x => x.AppUser)
                .WithMany(x => x.Likes)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            builder.HasOne(x => x.Film)
                .WithMany(x => x.Likes)
                .HasForeignKey(x => x.FilmId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}
