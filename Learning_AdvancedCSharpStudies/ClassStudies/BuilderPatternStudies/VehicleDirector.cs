namespace Learning_AdvancedCSharpStudies.ClassStudies.BuilderPatternStudies;

#region VehicleClasses

public interface IVehicle
{
    public string VehicleType { get; }
}

public class Van : IVehicle
{
    public string VehicleType => "Van";
}

public class Car : IVehicle
{
    public string VehicleType => "Car";
}

#endregion

#region DirectorClasses

public abstract class VehicleDirector : VehicleBuilder
{
    public abstract void Build();
}

public class CarDirector : VehicleDirector
{
    public override void Build()
    {
        BuildBody();
        BuildChassis();
    }

    protected override void BuildBody()
    {
        throw new NotImplementedException();
    }

    protected override void BuildChassis()
    {
        throw new NotImplementedException();
    }
}

public class VanDirector : VehicleDirector
{
    public override void Build()
    {
        BuildBody();
        BuildChassis();
    }

    protected override void BuildBody()
    {
        throw new NotImplementedException();
    }

    protected override void BuildChassis()
    {
        throw new NotImplementedException();
    }
}

#endregion

#region BuilderClasses

public abstract class VehicleBuilder
{
    public IVehicle? Vehicle { get; private set; }
    protected abstract void BuildBody();
    protected abstract void BuildChassis();
}

public class CarBuilder : VehicleBuilder
{
    protected override void BuildBody()
    {
        //Todo: Implement Car Body Building Logic
        throw new NotImplementedException();
    }

    protected override void BuildChassis()
    {
        //todo: Implement Car Chassis Building Logic
        throw new NotImplementedException();
    }
}

public class VanBuilder : VehicleBuilder
{
    protected override void BuildBody()
    {
        //Todo: Implement Van Body Building Logic
        throw new NotImplementedException();
    }

    protected override void BuildChassis()
    {
        //Todo: Implement Van Chassis Building Logic
        throw new NotImplementedException();
    }
}

#endregion

#region ClientClasses

public class CarClient
{
}

public class VanClient
{
}

#endregion