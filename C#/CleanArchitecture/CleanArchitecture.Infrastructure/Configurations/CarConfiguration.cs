namespace CleanArchitecture.Infrastructure.Configurations;

using CleanArchitecture.Domain.Cars;
using CleanArchitecture.Domain.Entities.Cars;
using CleanArchitecture.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public sealed class CarConfiguration : IEntityTypeConfiguration<Cars>
{
    public void Configure( EntityTypeBuilder<Cars> builder )
    {
        builder.ToTable( "cars" );
        builder.HasKey( car => car.Id );

        builder.OwnsOne( car => car.Address );

        builder.Property( car => car.Model ).HasMaxLength( 200 )
               .HasConversion( model => model!.Model, value => new Models( value ) );

        builder.Property( car => car.Vin ).HasMaxLength( 500 )
               .HasConversion( vins => vins!.Vin, vins => new Vins( vins ) );

        builder.OwnsOne( car => car.Price, pricebuilder =>
        {
            pricebuilder.Property( currency => currency.CurrencyType )
               .HasConversion( type => type.Code, code => CurrencyTypes.FromCode( code ) );
        } );

        builder.OwnsOne(car => car.Maintenance, priceBuilder =>
        {
            priceBuilder.Property( currency => currency.CurrencyType )
               .HasConversion( type => type.Code, code => CurrencyTypes.FromCode( code ) );
        });

        builder.Property<uint>( "version" ).IsRowVersion(); //Para la concurrencia
    }
}
