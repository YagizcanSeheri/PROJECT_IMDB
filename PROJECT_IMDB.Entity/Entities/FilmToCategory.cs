using System;
using System.Collections.Generic;
using System.Text;

namespace PROJECT_IMDB.Entity.Entities
{
    public class FilmToCategory : BaseEntity
    {
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int FilmId { get; set; }

        public Film Film { get; set; }
    }
}
