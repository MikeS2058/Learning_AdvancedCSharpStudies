namespace Learning_AdvancedCSharpStudies.ClassStudies.AbstractFactoryStudies;

public class TruckFactory : AbstractVehicleFactory
{
    public override IBody CreateBody()
    {
        return new TruckBody();
    }

    public override IChassis CreateChassis()
    {
        return new TruckChassis();
    }

    public override IGlassWare CreateGlassWare()
    {
        return new TruckGlassWare();
    }
}