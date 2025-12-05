namespace Learning_AdvancedCSharpStudies.ClassStudies.AbstractFactoryStudies;

/// <summary>
///     Registry for managing vehicle factory instances.
///     Provides centralized factory selection and eliminates switch statements in client code.
/// </summary>
public static class VehicleFactoryRegistry
{
    private static readonly Dictionary<string, AbstractVehicleFactory> _factories = new()
    {
        ["Car"] = new CarFactory(),
        ["Truck"] = new TruckFactory(),
        ["Van"] = new VanFactory()
    };

    /// <summary>
    ///     Gets all available vehicle types.
    /// </summary>
    public static IEnumerable<string> AvailableVehicleTypes => _factories.Keys;

    /// <summary>
    ///     Gets a factory for the specified vehicle type.
    /// </summary>
    /// <param name="vehicleType">The type of vehicle (Car, Truck, Van).</param>
    /// <returns>The corresponding vehicle factory.</returns>
    /// <exception cref="ArgumentException">Thrown when vehicle type is not recognized.</exception>
    public static AbstractVehicleFactory GetFactory(string vehicleType)
    {
        if (_factories.TryGetValue(vehicleType, out AbstractVehicleFactory? factory)) return factory;

        throw new ArgumentException($"Unknown vehicle type: {vehicleType}", nameof(vehicleType));
    }
}