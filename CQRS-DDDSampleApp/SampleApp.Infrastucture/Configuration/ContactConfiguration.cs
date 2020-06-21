using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp.Infrastucture.Configuration
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FullName).HasMaxLength(255);
            builder.Property(c => c.Email).HasMaxLength(255);
            builder.Property(c => c.PhoneNumber).HasMaxLength(255);
            builder.Property(c => c.Address).HasMaxLength(255);
        }
    }
}
