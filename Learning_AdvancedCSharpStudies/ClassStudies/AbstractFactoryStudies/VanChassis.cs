namespace Learning_AdvancedCSharpStudies.ClassStudies.AbstractFactoryStudies;

/// <summary>
///     Represents the chassis parts for a van vehicle.
/// </summary>
public sealed record VanChassis : IChassis
{
    /// <summary>
    ///     Gets the description of van chassis parts.
    /// </summary>
    public string ChassisParts { get; init; } = "Van Chassis Parts";
}