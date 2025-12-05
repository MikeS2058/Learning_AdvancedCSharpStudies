namespace Learning_AdvancedCSharpStudies.ClassStudies.FactoryStudies;

using CompanyVehicles;

/// <summary>
/// Abstract base factory for creating vehicles.
/// Defines the factory method pattern for vehicle creation.
/// </summary>
public abstract class VehicleFactory
{
    /// <summary>
    /// Factory method to build a vehicle.
    /// Must be implemented by concrete factories.
    /// </summary>
    /// <returns>A new vehicle instance.</returns>
    public abstract IVehicle Build();

    /// <summary>
    /// Template method that allows selecting and building a specific vehicle type.
    /// </summary>
    /// <param name="vehicleType">The type of vehicle to create.</param>
    /// <returns>A new vehicle instance of the specified type, or <see langword="null"/> if type is not supported.</returns>
    public abstract IVehicle? SelectVehicle(string vehicleType);
}