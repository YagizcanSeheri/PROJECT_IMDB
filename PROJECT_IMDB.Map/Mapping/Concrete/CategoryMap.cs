using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJECT_IMDB.Entity.Entities;
using PROJECT_IMDB.Map.Mapping.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace PROJECT_IMDB.Map.Mapping.Concrete
{
    public class CategoryMap:BaseMap<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            
            builder.Property(x => x.Name);

            builder.HasMany(x => x.FilmToCategories)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);

            base.Configure(builder);
        }
    }
}
