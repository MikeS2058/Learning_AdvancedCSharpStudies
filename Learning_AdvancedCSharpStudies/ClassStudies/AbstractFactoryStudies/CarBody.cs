namespace Learning_AdvancedCSharpStudies.ClassStudies.AbstractFactoryStudies;

/// <summary>
///     Represents the body parts for a car vehicle.
/// </summary>
public sealed record CarBody : IBody
{
    /// <summary>
    ///     Gets the description of car body parts.
    /// </summary>
    public string BodyParts { get; init; } = "Car Body Parts";
}