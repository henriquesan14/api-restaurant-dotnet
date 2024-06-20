﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Core.Entities;

namespace Restaurant.Infra.Mappings
{
    public class CommonOrderMapping : IEntityTypeConfiguration<CommonOrder>
    {
        public void Configure(EntityTypeBuilder<CommonOrder> builder)
        {
            builder.ToTable("Orders");

            // Relacionamento com Table
            builder.HasOne(co => co.Table)
                   .WithMany(co => co.Orders)
                   .HasForeignKey(co => co.TableId)
                   .IsRequired();

            // Relacionamento com Employee
            builder.HasOne(co => co.Employee)
                   .WithMany()
                   .HasForeignKey(co => co.EmployeeId)
                   .IsRequired();
        }
    }
}
