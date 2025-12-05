namespace Learning_AdvancedCSharpStudies.ClassStudies.AbstractFactoryStudies;

public class CarFactory : AbstractVehicleFactory
{
    public override IBody CreateBody()
    {
        return new CarBody();
    }

    public override IChassis CreateChassis()
    {
        return new CarChassis();
    }

    public override IGlassWare CreateGlassWare()
    {
        return new CarGlassWare();
    }
}