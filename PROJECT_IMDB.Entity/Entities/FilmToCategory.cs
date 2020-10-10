using System;
using System.Collections.Generic;
using System.Text;

namespace PROJECT_IMDB.Entity.Entities
{
    public class FilmToCategory : BaseEntity
    {
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int FilmId { get; set; }

        public virtual Film Film { get; set; }
    }
}
