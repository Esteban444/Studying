namespace CleanArchitecture.Infrastructure.Configurations;

using CleanArchitecture.Domain.Cars;
using CleanArchitecture.Domain.Entities.Rentals;
using CleanArchitecture.Domain.Entities.Users;
using CleanArchitecture.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public sealed class RentalConfiguration : IEntityTypeConfiguration<Rentals>
{
    public void Configure( EntityTypeBuilder<Rentals> builder )
    {
        builder.ToTable("rentals");
        builder.HasKey( al => al.Id );

        builder.OwnsOne( al => al.Price, priceBuilder =>
        {
            priceBuilder.Property( currency => currency.CurrencyType )
                .HasConversion(type => type.Code, code => CurrencyTypes.FromCode(code));
        });

        builder.OwnsOne( al => al.Maintenance, priceBuilder =>
        {
            priceBuilder.Property( currency => currency.CurrencyType)
                .HasConversion(type => type.Code, code => CurrencyTypes.FromCode( code ) );
        });

        builder.OwnsOne( al => al.Accesories, priceBuilder =>
        {
            priceBuilder.Property( currency => currency.CurrencyType )
                .HasConversion( type => type.Code, code => CurrencyTypes.FromCode( code ) );
        });

        builder.OwnsOne( al => al.TotalPrice, priceBuilder =>
        {
            priceBuilder.Property( currency => currency.CurrencyType )
                .HasConversion( type => type.Code, code => CurrencyTypes.FromCode( code ) );
        });

        builder.OwnsOne( al => al.DateRange );

        builder.HasOne<Cars>().WithMany().HasForeignKey( al => al.CarId );

        builder.HasOne<Users>().WithMany().HasForeignKey( al => al.UserId );
    }
}
