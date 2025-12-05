namespace Learning_AdvancedCSharpStudies.ClassStudies.AbstractFactoryStudies;

/// <summary>
///     Factory for creating car vehicle parts.
/// </summary>
public sealed class CarFactory : AbstractVehicleFactory
{
    /// <inheritdoc />
    public override IBody CreateBody()
    {
        return new CarBody();
    }

    /// <inheritdoc />
    public override IChassis CreateChassis()
    {
        return new CarChassis();
    }

    /// <inheritdoc />
    public override IGlassWare CreateGlassWare()
    {
        return new CarGlassWare();
    }
}