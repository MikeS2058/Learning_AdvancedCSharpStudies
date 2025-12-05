namespace Learning_AdvancedCSharpStudies.ClassStudies.BuilderPatternStudies;

#region VehicleClasses

public interface IVehicle
{
    string VehicleType { get; }
    IReadOnlyList<string> VehicleFeatures { get; init; }
}

public abstract class VehicleBase : IVehicle
{
    public abstract string VehicleType { get; }
    public abstract IReadOnlyList<string> VehicleFeatures { get; init; }

    protected static string[] ValidateFeatures(string[] features)
    {
        ArgumentNullException.ThrowIfNull(features);
        return features.Length == 0 ?
            throw new ArgumentException("Car must have at least one feature.", nameof(features)) : features;
    }

    public override string ToString()
    {
        return $"{VehicleType} with features: {string.Join(", ", VehicleFeatures)}";
    }
}

public class Van(string[] features) : VehicleBase
{
    public override string VehicleType => "Van";
    public override IReadOnlyList<string> VehicleFeatures { get; init; } = ValidateFeatures(features);
}

public class Car(string[] features) : VehicleBase
{
    public override string VehicleType => "Car";
    public override IReadOnlyList<string> VehicleFeatures { get; init; } = ValidateFeatures(features);
}

#endregion

#region DirectorClasses

/// <summary>
/// Abstract director that orchestrates the construction process (VehicleDirector in UML).
/// Composes VehicleBuilder via field (dashed arrow in UML).
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
    /// Build() method from UML diagram that orchestrates construction.
    /// </summary>
    public abstract IVehicle Build();
}

/// <summary>
/// Concrete director for car construction (CarDirector in UML).
/// </summary>
public class CarDirector : VehicleDirector
{
    public CarDirector(VehicleBuilder builder) : base(builder)
    {
        if (builder is not CarBuilder)
        {
            throw new ArgumentException("Builder must be a CarBuilder", nameof(builder));
        }
    }

    public override IVehicle Build()
    {
        var features = new List<string>(6)
        {
            _builder.BuildBody(),
            _builder.BuildChassis(),
            _builder.BuildBoot(),
            _builder.BuildPassengerArea(),
            _builder.BuildReinforcedStorageArea(),
            _builder.BuildWindows()
        };
        return new Car(features.ToArray());
    }
}

/// <summary>
/// Concrete director for van construction (VanDirector in UML).
/// </summary>
public class VanDirector : VehicleDirector
{
    public VanDirector(VehicleBuilder builder) : base(builder)
    {
        if (builder is not VanBuilder)
        {
            throw new ArgumentException("Builder must be a VanBuilder", nameof(builder));
        }
    }

    public override IVehicle Build()
    {
        var features = new List<string>(4)
        {
            _builder.BuildBody(),
            _builder.BuildChassis(),
            _builder.BuildReinforcedStorageArea(),
            _builder.BuildWindows()
        };
        return new Van(features.ToArray());
    }
}

#endregion

#region BuilderClasses

/// <summary>
/// Abstract builder defining the interface for creating vehicle parts (VehicleBuilder in UML).
/// </summary>
public abstract class VehicleBuilder
{
    public virtual string BuildBody() => string.Empty;

    public virtual string BuildChassis() => string.Empty;

    public virtual string BuildBoot() => string.Empty;

    public virtual string BuildPassengerArea() => string.Empty;

    public virtual string BuildWindows() => string.Empty;

    public virtual string BuildReinforcedStorageArea() => string.Empty;
}

/// <summary>
/// Concrete builder for car parts (CarBuilder in UML).
/// </summary>
public class CarBuilder : VehicleBuilder
{
    public override string BuildBody() => "Car Body Built";

    public override string BuildChassis() => "Car Chassis Built";

    public override string BuildBoot() => "Car Boot Built";

    public override string BuildPassengerArea() => "Car Passenger Area Built";

    public override string BuildReinforcedStorageArea() => "Car Reinforced Storage Area Built";

    public override string BuildWindows() => "Car Windows Built";
}

/// <summary>
/// Concrete builder for van parts (VanBuilder in UML).
/// </summary>
public class VanBuilder : VehicleBuilder
{
    public override string BuildBody() => "Van Body Built";

    public override string BuildChassis() => "Van Chassis Built";

    public override string BuildReinforcedStorageArea() => "Van Reinforced Storage Area Built";

    public override string BuildWindows() => "Van Windows Built";
}

#endregion

#region ClientClasses

/// <summary>
/// Client code that uses director to build a car (CarClient in UML).
/// </summary>
public class CarClient
{
    public void BuildCar()
    {
        var builder = new CarBuilder();
        var director = new CarDirector(builder);
        var car = director.Build();
        Console.WriteLine(car);
    }
}

/// <summary>
/// Client code that uses director to build a van (VanClient in UML).
/// </summary>
public class VanClient
{
    public void BuildVan()
    {
        var builder = new VanBuilder();
        var director = new VanDirector(builder);
        var van = director.Build();
        Console.WriteLine(van);
    }
}

#endregion