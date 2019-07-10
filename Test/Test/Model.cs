using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Test
{
    class AppContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=data.db");
        }
    }

    class BaseEntity
    {
        public string Id { get; set; }
    }

    class Project : BaseEntity
    {
        public string Type { get; set; }
        public string Path { get; set; }
    }

    class ProjectType: BaseEntity
    {
        public string Name { get; set; }
    }
}
