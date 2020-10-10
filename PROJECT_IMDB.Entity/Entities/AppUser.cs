using System;
using System.Collections.Generic;
using System.Text;

namespace PROJECT_IMDB.Entity.Entities
{
    public enum Role
    {
        Admin = 1,
        Member = 2,
        Visitor = 3
    }
    public class AppUser : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }

        public ICollection<Film> Films { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Comment> Comments { get; set; }


    }
}
