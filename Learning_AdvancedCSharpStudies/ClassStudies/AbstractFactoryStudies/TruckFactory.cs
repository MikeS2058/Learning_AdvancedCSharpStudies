namespace Learning_AdvancedCSharpStudies.ClassStudies.AbstractFactoryStudies;

/// <summary>
///     Factory for creating truck vehicle parts.
/// </summary>
public sealed class TruckFactory : AbstractVehicleFactory
{
    /// <inheritdoc />
    public override IBody CreateBody()
    {
        return new TruckBody();
    }

    /// <inheritdoc />
    public override IChassis CreateChassis()
    {
        return new TruckChassis();
    }

    /// <inheritdoc />
    public override IGlassWare CreateGlassWare()
    {
        return new TruckGlassWare();
    }
}