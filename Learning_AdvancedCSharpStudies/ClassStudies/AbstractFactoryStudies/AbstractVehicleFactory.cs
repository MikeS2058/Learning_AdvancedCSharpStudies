namespace Learning_AdvancedCSharpStudies.ClassStudies.AbstractFactoryStudies;

/// <summary>
///     Abstract factory for creating families of related vehicle parts.
///     Implements the Gang of Four Abstract Factory pattern.
/// </summary>
public abstract class AbstractVehicleFactory
{
    /// <summary>
    ///     Creates a body part appropriate for the vehicle type.
    /// </summary>
    /// <returns>A vehicle body implementation.</returns>
    public abstract IBody CreateBody();

    /// <summary>
    ///     Creates a chassis part appropriate for the vehicle type.
    /// </summary>
    /// <returns>A vehicle chassis implementation.</returns>
    public abstract IChassis CreateChassis();

    /// <summary>
    ///     Creates glassware appropriate for the vehicle type.
    /// </summary>
    /// <returns>A vehicle glassware implementation.</returns>
    public abstract IGlassWare CreateGlassWare();
}