namespace Learning_AdvancedCSharpStudies.ClassStudies.AbstractFactoryStudies;

/// <summary>
///     Represents the glassware parts for a truck vehicle.
/// </summary>
public sealed record TruckGlassWare : IGlassWare
{
    /// <summary>
    ///     Gets the description of truck glassware parts.
    /// </summary>
    public string GlassWareParts { get; init; } = "Truck Glass Parts";
}