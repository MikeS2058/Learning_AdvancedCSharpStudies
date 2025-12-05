namespace Learning_AdvancedCSharpStudies.ClassStudies.AbstractFactoryStudies;

/// <summary>
///     Represents the glassware parts for a van vehicle.
/// </summary>
public sealed record VanGlassWare : IGlassWare
{
    /// <summary>
    ///     Gets the description of van glassware parts.
    /// </summary>
    public string GlassWareParts { get; init; } = "Van Glass Parts";
}