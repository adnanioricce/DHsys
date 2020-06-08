using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DAL.DataMappings
{
    public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {       
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {            
            builder.Property(p => p.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);
            builder.Property(p => p.CreatedAt)
                   .IsRequired()
                   .HasDefaultValue(DateTimeOffset.UtcNow)
                   .ValueGeneratedOnAdd();
            builder.Property(p => p.LastUpdatedOn)
                .IsRequired()
                .HasDefaultValue(DateTimeOffset.UtcNow)
                .ValueGeneratedOnUpdate();
        }
    }
}
