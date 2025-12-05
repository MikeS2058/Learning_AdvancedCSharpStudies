namespace Learning_AdvancedCSharpStudies.ClassStudies.AbstractFactoryStudies;

/// <summary>
/// Factory for creating car vehicle parts.
/// </summary>
public sealed class CarFactory : AbstractVehicleFactory
{
    /// <inheritdoc />
    public override IBody CreateBody() => new CarBody();

    /// <inheritdoc />
    public override IChassis CreateChassis() => new CarChassis();

    /// <inheritdoc />
    public override IGlassWare CreateGlassWare() => new CarGlassWare();
}