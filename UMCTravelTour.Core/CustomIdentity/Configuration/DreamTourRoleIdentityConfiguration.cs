using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.Core.CustomIdentity.Configuration
{
    public class DreamTourRoleIdentityConfiguration : IEntityTypeConfiguration<DreamTourRole>
    {
        public void Configure(EntityTypeBuilder<DreamTourRole> builder)
        {
            builder.Property(u => u.Description).HasColumnType("ntext");
        }
    }
}
