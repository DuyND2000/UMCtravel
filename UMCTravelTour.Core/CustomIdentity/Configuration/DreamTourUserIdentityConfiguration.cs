using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UMCTravelTour.Core.CustomIdentity.Configuration
{
    public class DreamTourUserIdentityConfiguration : IEntityTypeConfiguration<DreamTourUser>
    {
        public void Configure(EntityTypeBuilder<DreamTourUser> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(255);
            builder.Property(u => u.LastName).HasMaxLength(255);
        }
    }
}
