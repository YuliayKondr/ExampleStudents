using ExampleDomen.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExampleInfrastructure.DbMapper;

public class CategoryMap : EntityMapBase<Category>
{
    public CategoryMap()
        : base("category")
    {
    }

    protected override void ConfigureMap(EntityTypeBuilder<Category> b)
    {
        b.HasKey(x => x.Id);
        b.Property(x => x.Id).HasColumnName("id");
        b.Property(x => x.Name).HasColumnName("name");
        b.Property(x => x.NameUa).HasColumnName("name_ua");
    }
}