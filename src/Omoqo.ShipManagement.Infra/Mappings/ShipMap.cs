using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Omoqo.ShipManagement.Domain.Ships.Models;
using Omoqo.Shared.Support.EntityMethodsExtensions;

namespace Omoqo.ShipManagement.Infra.Mappings
{
    internal class ShipMap : IEntityTypeConfiguration<Ship>
    {
        public void Configure(EntityTypeBuilder<Ship> builder)
        {
            builder.ToTable("ship");
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(d => d.Name)
                .HasColumnName("name").IsVarchar(100).IsRequired();

            builder.Property(d => d.Length)
                .HasColumnName("length").IsRequired().HasColumnType("INT");

            builder.Property(d => d.Width)
                .HasColumnName("width").IsRequired().HasColumnType("INT");

            builder.Property(d => d.Code)
                .HasColumnName("code").IsVarchar(12).IsRequired().HasComment("Format: AAAA-1111-A1");
        }
    }
}