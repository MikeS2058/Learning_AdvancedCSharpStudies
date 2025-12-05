namespace Learning_AdvancedCSharpStudies.ClassStudies.FactoryStudies;

using CompanyVehicles;

/// <summary>
/// Concrete factory for creating van vehicles.
/// Implements the factory method pattern to create different van types.
/// </summary>
public class VanFactory : VehicleFactory
{
    /// <summary>
    /// Builds a default van (BoxVan).
    /// </summary>
    /// <returns>A new BoxVan instance.</returns>
    public override IVehicle Build()
    {
        return new BoxVan();
    }

    /// <summary>
    /// Selects and builds a specific van type based on the provided type name.
    /// </summary>
    /// <param name="vehicleType">The type of van to create (BoxVan or Pickup).</param>
    /// <returns>A new van instance of the specified type, or <see langword="null"/> if type is not recognized.</returns>
    public override IVehicle? SelectVehicle(string vehicleType)
    {
        return vehicleType.ToLower() switch
        {
            "boxvan" => new BoxVan(),
            "pickup" => new Pickup(),
            _ => null
        };
    }
}