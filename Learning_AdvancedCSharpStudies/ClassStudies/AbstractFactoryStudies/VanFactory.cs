﻿namespace Learning_AdvancedCSharpStudies.ClassStudies.AbstractFactoryStudies;

/// <summary>
/// Factory for creating van vehicle parts.
/// </summary>
public sealed class VanFactory : AbstractVehicleFactory
{
    /// <inheritdoc />
    public override IBody CreateBody() => new VanBody();

    /// <inheritdoc />
    public override IChassis CreateChassis() => new VanChassis();

    /// <inheritdoc />
    public override IGlassWare CreateGlassWare() => new VanGlassWare();
}