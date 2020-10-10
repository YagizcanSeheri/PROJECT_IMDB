using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROJECT_IMDB.Entity.Entities;
using PROJECT_IMDB.Map.Mapping.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace PROJECT_IMDB.Map.Mapping.Concrete
{
    public class FilmToCategoryMap:BaseMap<FilmToCategory>
    {
        public override void Configure(EntityTypeBuilder<FilmToCategory> builder)
        {
            
            builder.HasKey(x => new { x.FilmId, x.CategoryId });
            base.Configure(builder);
        }
    }
}
