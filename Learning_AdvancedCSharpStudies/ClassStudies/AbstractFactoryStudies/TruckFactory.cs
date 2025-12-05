namespace Learning_AdvancedCSharpStudies.ClassStudies.AbstractFactoryStudies;

/// <summary>
/// Factory for creating truck vehicle parts.
/// </summary>
public sealed class TruckFactory : AbstractVehicleFactory
{
    /// <inheritdoc />
    public override IBody CreateBody() => new TruckBody();

    /// <inheritdoc />
    public override IChassis CreateChassis() => new TruckChassis();

    /// <inheritdoc />
    public override IGlassWare CreateGlassWare() => new TruckGlassWare();
}