namespace Learning_AdvancedCSharpStudies.ClassStudies.AbstractFactoryStudies;

/// <summary>
/// Represents a vehicle chassis component.
/// </summary>
public interface IChassis
{
    /// <summary>
    /// Gets the description of chassis parts.
    /// </summary>
    string ChassisParts { get; }
}