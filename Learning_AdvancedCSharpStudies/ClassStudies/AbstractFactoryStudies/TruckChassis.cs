namespace Learning_AdvancedCSharpStudies.ClassStudies.AbstractFactoryStudies;

/// <summary>
/// Represents the chassis parts for a truck vehicle.
/// </summary>
public sealed record TruckChassis : IChassis
{
    /// <summary>
    /// Gets the description of truck chassis parts.
    /// </summary>
    public string ChassisParts { get; init; } = "Truck Chassis Parts";
}