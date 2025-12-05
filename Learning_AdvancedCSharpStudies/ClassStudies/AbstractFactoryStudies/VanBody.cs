namespace Learning_AdvancedCSharpStudies.ClassStudies.AbstractFactoryStudies;

/// <summary>
///     Represents the body parts for a van vehicle.
/// </summary>
public sealed record VanBody : IBody
{
    /// <summary>
    ///     Gets the description of van body parts.
    /// </summary>
    public string BodyParts { get; init; } = "Van Body Parts";
}