namespace CleanArchitecture.Infrastructure.Configurations;

using CleanArchitecture.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public sealed class UserConfiguration : IEntityTypeConfiguration<Users>
{
    public void Configure( EntityTypeBuilder<Users> builder )
    {
        builder.ToTable( "users" );
        builder.HasKey( us => us.Id );

        builder.Property( us => us.Name ).HasMaxLength( 200 )
            .HasConversion( us => us.Name , value => new Names( value ) );

        //convert to primitive
        builder.Property( us => us.LastName).HasMaxLength( 200  )
            .HasConversion( us => us.LastName, value => new LastNames(value));

        builder.Property(us => us.Email).HasMaxLength( 400 )
            .HasConversion(us => us.Email, value => new Emails( value ) );

        builder.HasIndex( us => us.Email ).IsUnique();
    }
}
