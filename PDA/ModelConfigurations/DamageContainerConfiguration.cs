using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PDA.Models;

namespace PDA.ModelConfigurations
{
    public class DamageContainerConfiguration : IEntityTypeConfiguration<DamageContainer>
    {
        public void Configure(EntityTypeBuilder<DamageContainer> builder)
        {
            builder.HasKey(c => new { c.ContainerId, c.DamageId });
        }
    }
}
