namespace Learning_AdvancedCSharpStudies.ClassStudies.AbstractFactoryStudies;

/// <summary>
///     Represents the glassware parts for a car vehicle.
/// </summary>
public sealed record CarGlassWare : IGlassWare
{
    /// <summary>
    ///     Gets the description of car glassware parts.
    /// </summary>
    public string GlassWareParts { get; init; } = "Car Glass Parts";
}