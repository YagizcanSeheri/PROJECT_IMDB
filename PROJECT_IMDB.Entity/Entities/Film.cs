using Microsoft.AspNetCore.Http;
using PROJECT_IMDB.Entity.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PROJECT_IMDB.Entity.Entities
{
    public class Film : BaseEntity
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public string VideoUrl { get; set; }
        public string Image { get; set; }

        [NotMapped]
        [FileExtansion]
        public IFormFile ImageUpload { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public ICollection<FilmToCategory> FilmToCategories { get; set; }

        public ICollection<Like> Likes { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
