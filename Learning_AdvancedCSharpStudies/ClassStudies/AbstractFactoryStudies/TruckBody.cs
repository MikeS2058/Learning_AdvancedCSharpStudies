namespace Learning_AdvancedCSharpStudies.ClassStudies.AbstractFactoryStudies;

/// <summary>
///     Represents the body parts for a truck vehicle.
/// </summary>
public sealed record TruckBody : IBody
{
    /// <summary>
    ///     Gets the description of truck body parts.
    /// </summary>
    public string BodyParts { get; init; } = "Truck Body Parts";
}