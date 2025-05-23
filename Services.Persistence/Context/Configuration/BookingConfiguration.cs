﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Services.Domain.Entities;
using Services.Domain.Enums;

namespace Services.Persistence.Context.Configuration
{
    public sealed class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable(nameof(Table.Booking), nameof(Schema.Service));
            builder.HasKey(t => t.Id);
            builder.HasIndex(t => t.WorkerId);
            builder.HasIndex(t => t.CustomerId);
            builder.HasIndex(t => t.ServiceId);
            builder.HasIndex(t => t.CreateOn);
        }
    }
}
