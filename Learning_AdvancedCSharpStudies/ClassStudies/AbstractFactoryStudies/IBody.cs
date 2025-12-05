namespace Learning_AdvancedCSharpStudies.ClassStudies.AbstractFactoryStudies;

/// <summary>
///     Represents a vehicle body component.
/// </summary>
public interface IBody
{
    /// <summary>
    ///     Gets the description of body parts.
    /// </summary>
    string BodyParts { get; }
}