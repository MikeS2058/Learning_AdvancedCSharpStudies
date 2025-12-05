namespace Learning_AdvancedCSharpStudies.ClassStudies.BuilderPatternStudies;

#region DirectorClasses

/// <summary>
///     Abstract director that orchestrates the construction process (VehicleDirector in UML).
///     Composes VehicleBuilder via field (dashed arrow in UML).
/// </summary>
public abstract class VehicleDirector
{
    protected readonly VehicleBuilder _builder;

    protected VehicleDirector(VehicleBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        _builder = builder;
    }

    /// <summary>
    ///     Build() method from UML diagram that orchestrates construction.
    /// </summary>
    public abstract IVehicle Build();
}

#endregion