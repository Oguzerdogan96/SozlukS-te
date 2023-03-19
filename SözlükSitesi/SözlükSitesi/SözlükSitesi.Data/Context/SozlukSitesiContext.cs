using Microsoft.EntityFrameworkCore;
using SözlükSitesi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SözlükSitesi.Data.Context
{
    public class SozlukSitesiContext :DbContext
    {
        public SozlukSitesiContext(DbContextOptions<SozlukSitesiContext> options) :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());

            modelBuilder.ApplyConfiguration(new PostEntityConfiguration());


            base.OnModelCreating(modelBuilder);
        }


        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<UserEntity> Users { get; set; }
    }
}
