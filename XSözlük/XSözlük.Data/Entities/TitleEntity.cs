using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSözlük.Data.Entities
{
    public class TitleEntity : BaseEntity
    {
        public string Title { get; set; }
        
        List<EntryEntity> Entries { get; set; }
    }
    public class TitleEntityConfiguration : BaseConfiguration<TitleEntity>
    {
        public override void Configure(EntityTypeBuilder<TitleEntity> builder)
        {

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(30);

            
                

            base.Configure(builder);
        }
    }
}
