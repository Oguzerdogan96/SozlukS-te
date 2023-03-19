using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SözlükSitesi.Data.Entities
{
    public class PostEntity : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }

        public UserEntity User { get; set; }
    }

    public class PostEntityConfiguration :BaseConfiguration<PostEntity> 
    {

        public override void Configure(EntityTypeBuilder<PostEntity> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(30);

            builder.Property(x=>x.Content).IsRequired().HasMaxLength(100);

            



            base.Configure(builder);
        }
    }
}
