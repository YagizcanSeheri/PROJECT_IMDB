using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJECT_IMDB.Entity.Entities;
using PROJECT_IMDB.Map.Mapping.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace PROJECT_IMDB.Map.Mapping.Concrete
{
    public class CommentMap:BaseMap<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x => x.Content).HasMaxLength(400).IsRequired(true);

            
            builder.HasOne(x => x.AppUser)
               .WithMany(x => x.Comments)
               .HasForeignKey(x => x.AppUserId);

            builder.HasOne(x => x.Film)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.FilmId);
            
            base.Configure(builder);
        }
    }
}
