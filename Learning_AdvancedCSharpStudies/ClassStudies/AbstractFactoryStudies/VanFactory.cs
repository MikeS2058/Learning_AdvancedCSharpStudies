namespace Learning_AdvancedCSharpStudies.ClassStudies.AbstractFactoryStudies;

public class VanFactory : AbstractVehicleFactory
{
    public override IBody CreateBody()
    {
        return new VanBody();
    }

    public override IChassis CreateChassis()
    {
        return new VanChassis();
    }

    public override IGlassWare CreateGlassWare()
    {
        return new VanGlassWare();
    }
}