using System;
using System.Collections.Generic;
using System.Text;
using EntityManyToManyTest.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EntityManyToManyTest.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
        }

        public DbSet<ClassName> ClassNames { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<ClassNameTopic> ClassNameTopics { get; set; }
        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.Entity<ClassNameTopic>().HasKey(sc => new {sc.ClassNameId, sc.TopicId});
        }
    }

}
