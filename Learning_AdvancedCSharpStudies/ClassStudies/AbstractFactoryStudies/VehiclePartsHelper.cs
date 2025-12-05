namespace Learning_AdvancedCSharpStudies.ClassStudies.AbstractFactoryStudies;

/// <summary>
///     Helper for retrieving vehicle parts from a vehicle factory.
/// </summary>
public static class VehiclePartsHelper
{
    /// <summary>
    ///     Gets the body, chassis, and glassware parts for a given vehicle factory.
    /// </summary>
    /// <param name="factory">The vehicle factory.</param>
    /// <returns>A <see cref="VehicleParts" /> record containing body, chassis, and glassware part descriptions.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="factory" /> is <see langword="null" />.</exception>
    public static VehicleParts GetVehicleParts(AbstractVehicleFactory factory)
    {
        ArgumentNullException.ThrowIfNull(factory);

        return new VehicleParts(
            factory.CreateBody().BodyParts,
            factory.CreateChassis().ChassisParts,
            factory.CreateGlassWare().GlassWareParts
        );
    }
}

/// <summary>
///     Represents a collection of vehicle parts.
/// </summary>
/// <param name="BodyParts">The body part description.</param>
/// <param name="ChassisParts">The chassis part description.</param>
/// <param name="GlassWareParts">The glassware part description.</param>
public record VehicleParts(string BodyParts, string ChassisParts, string GlassWareParts);