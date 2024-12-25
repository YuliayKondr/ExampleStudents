using ExampleDomen.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExampleInfrastructure.DbMapper;

public class ProductMap : EntityMapBase<Product>
{
    public ProductMap()
        : base("product")
    {
    }

    protected override void ConfigureMap(EntityTypeBuilder<Product> b)
    {
        b.HasKey(x => x.Id);
        b.Property(x => x.Id).HasColumnName("id");
        b.Property(x => x.Name).HasColumnName("name");
        b.Property(x => x.NameUa).HasColumnName("name_ua");
        b.Property(x => x.CategoryId).HasColumnName("category_id");

        b.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId);
    }
}