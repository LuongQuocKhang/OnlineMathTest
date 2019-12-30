using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineMathTest.Common;
using OnlineMathTest.Context.IUnitOfWork;
using OnlineMathTest.Model;
using OnlineMathTest.Models.Models;
using Role = OnlineMathTest.Model.Role;

namespace OnlineMathTest.Context
{
    public class ApplicationDbContext : IdentityDbContext, IContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Level> Level { get; set; }
        public virtual DbSet<Mcq> Mcq { get; set; }
        public virtual DbSet<Mcqquestion> Mcqquestion { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<QuestionAnswer> QuestionAnswer { get; set; }
        public virtual DbSet<QuestionType> QuestionType { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserTest> UserTest { get; set; }
        public virtual DbSet<Mcqhistory> Mcqhistory { get; set; }
        public virtual DbSet<Role> Role { get; set; }

        public DbSet<T> dbSet<T>() where T : class
        {
            return this.Set<T>();
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(SqlCommon.CONNECTION_STRING);
            }
        }
    }
}
