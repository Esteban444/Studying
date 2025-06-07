namespace CleanArchitecture.Infrastructure.Configurations;

using CleanArchitecture.Domain.Cars;
using CleanArchitecture.Domain.Entities.Comments;
using CleanArchitecture.Domain.Entities.Rentals;
using CleanArchitecture.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal sealed class reviewConfiguration : IEntityTypeConfiguration<Comments>
{
    public void Configure( EntityTypeBuilder<Comments> builder )
    {
        builder.ToTable( "comments" );
        builder.HasKey( co => co.Id );

        //convert to primitive
        builder.Property( co => co.Rating )
            .HasConversion( ra => ra.Value, value =>  Rating.Create( value ).Value );

        builder.Property ( co => co.Comment ).HasMaxLength( 200 )
            .HasConversion( co => co.comment, comment => new Comment( comment ) );
        
        builder.HasOne<Cars>().WithMany().HasForeignKey( co => co.CarId );

        builder.HasOne<Rentals>().WithMany().HasForeignKey( co => co.RentalId );

        builder.HasOne<Users>().WithMany().HasForeignKey( co => co.UserId );
    }
}
