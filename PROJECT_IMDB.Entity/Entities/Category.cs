using System;
using System.Collections.Generic;
using System.Text;

namespace PROJECT_IMDB.Entity.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }


        public virtual ICollection<FilmToCategory> FilmToCategories { get; set; }
    }
}
