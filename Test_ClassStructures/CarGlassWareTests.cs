using Learning_AdvancedCSharpStudies.ClassStudies.AbstractFactoryStudies;

namespace Test_ClassStructures;

public class CarGlassWareTests
{
    [Fact]
    public void CarGlassWare_Implements_IGlassWare()
    {
        // Act
        IGlassWare glassWare = new CarGlassWare();

        // Assert
        glassWare.Should().NotBeNull();
        glassWare.Should().BeOfType<CarGlassWare>();
    }

    [Fact]
    public void GlassWareParts_Returns_CarGlassParts()
    {
        // Arrange
        CarGlassWare sut = new();

        // Act
        string parts = sut.GlassWareParts;

        // Assert
        parts.Should().Be("Car Glass Parts");
    }
}