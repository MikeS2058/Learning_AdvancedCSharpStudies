﻿namespace Learning_AdvancedCSharpStudies.ClassStudies.AbstractFactoryStudies;

/// <summary>
/// Represents the chassis parts for a car vehicle.
/// </summary>
public sealed record CarChassis : IChassis
{
    /// <summary>
    /// Gets the description of car chassis parts.
    /// </summary>
    public string ChassisParts { get; init; } = "Car Chassis Parts";
}