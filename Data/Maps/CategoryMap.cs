using api_netcore_and_ef.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_netcore_and_ef.Data.Maps
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(x=>x.Id);
            builder.Property(x=> x.Title).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
        }
    }
}