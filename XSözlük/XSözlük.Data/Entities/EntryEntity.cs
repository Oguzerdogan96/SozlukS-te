using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSözlük.Data.Entities
{
    public class EntryEntity : BaseEntity
    {
        public string Entry { get; set; }
        public int TitleId { get; set; }
        public int UserId { get; set; }
        public TitleEntity Title { get; set; }
        public UserEntity User { get; set; }
    }

    public class EntryEntityConfiguration : BaseConfiguration<EntryEntity>
    {
        public override void Configure(EntityTypeBuilder<EntryEntity> builder)
        {

            builder.Property(x => x.Entry)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.TitleId)
                .IsRequired();

            builder.Property(x => x.UserId)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
