namespace Learning_AdvancedCSharpStudies.ClassStudies.AbstractFactoryStudies;

public abstract class AbstractVehicleFactory
{
    public abstract IBody CreateBody();
    public abstract IChassis CreateChassis();
    public abstract IGlassWare CreateGlassWare();
}