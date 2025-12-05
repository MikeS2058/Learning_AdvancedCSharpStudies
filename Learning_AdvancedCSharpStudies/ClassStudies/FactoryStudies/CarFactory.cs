namespace Learning_AdvancedCSharpStudies.ClassStudies.FactoryStudies;

using CompanyVehicles;

/// <summary>
/// Concrete factory for creating car vehicles.
/// Implements the factory method pattern to create different car types.
/// </summary>
public class CarFactory : VehicleFactory
{
    /// <summary>
    /// Builds a default car (Saloon).
    /// </summary>
    /// <returns>A new Saloon car instance.</returns>
    public override IVehicle Build()
    {
        return new Saloon();
    }

    /// <summary>
    /// Selects and builds a specific car type based on the provided type name.
    /// </summary>
    /// <param name="vehicleType">The type of car to create (Saloon, Coupe, or Sport).</param>
    /// <returns>A new car instance of the specified type, or <see langword="null"/> if type is not recognized.</returns>
    public override IVehicle? SelectVehicle(string vehicleType)
    {
        return vehicleType.ToLower() switch
        {
            "saloon" => new Saloon(),
            "coupe" => new Coupe(),
            "sport" => new Sport(),
            _ => null
        };
    }
}