using Microsoft.EntityFrameworkCore;
using PROJECT_IMDB.Entity.Entities;
using PROJECT_IMDB.Map.Mapping.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace PROJECT_IMDB.DAL.Context
{
    public class ProjectContext:DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Like> Likes { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<FilmToCategory> FilmToCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new FilmMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new LikeMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new FilmToCategoryMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
