namespace Learning_AdvancedCSharpStudies.ClassStudies.AbstractFactoryStudies;

/// <summary>
///     Factory for creating van vehicle parts.
/// </summary>
public sealed class VanFactory : AbstractVehicleFactory
{
    /// <inheritdoc />
    public override IBody CreateBody()
    {
        return new VanBody();
    }

    /// <inheritdoc />
    public override IChassis CreateChassis()
    {
        return new VanChassis();
    }

    /// <inheritdoc />
    public override IGlassWare CreateGlassWare()
    {
        return new VanGlassWare();
    }
}