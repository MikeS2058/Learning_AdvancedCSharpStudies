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
    /// <returns>A tuple containing body, chassis, and glassware parts.</returns>
    public static (string BodyParts, string ChassisParts, string GlassWareParts) GetVehicleParts(
        AbstractVehicleFactory factory)
    {
        string body = factory.CreateBody().BodyParts;
        string chassis = factory.CreateChassis().ChassisParts;
        string glass = factory.CreateGlassWare().GlassWareParts;
        return (body, chassis, glass);
    }
}