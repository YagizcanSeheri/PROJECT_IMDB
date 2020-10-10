using System;
using System.Collections.Generic;
using System.Text;

namespace PROJECT_IMDB.Entity.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }

        public int FilmId { get; set; }
        public Film Film { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
