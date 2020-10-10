using System;
using System.Collections.Generic;
using System.Text;

namespace PROJECT_IMDB.Entity.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }

        public int FilmId { get; set; }
        public virtual Film Film { get; set; }

        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
