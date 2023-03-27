using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XSözlük.Data.Entities;

namespace XSözlük.Data.Context
{
    public class XSozlukContext :DbContext
    {
        public XSozlukContext(DbContextOptions<XSozlukContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());

            modelBuilder.ApplyConfiguration(new TitleEntityConfiguration());

            modelBuilder.ApplyConfiguration(new EntryEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TitleEntity> Titles { get; set; }
        public DbSet<EntryEntity> Entries { get; set; }
    }
}
