# Factory Pattern Implementation - Vehicle Factory

## Overview

Implementation of the Factory Method pattern for creating vehicle instances. This demonstrates the Gang of Four (GoF) Factory Method design pattern.

## Class Structure

```
VehicleFactory (abstract)
    ↑
    ├── CarFactory (concrete)
    │       Creates: Saloon, Coupe, Sport
    │
    └── VanFactory (concrete)
            Creates: BoxVan, Pickup
```

## Components

### VehicleFactory (Abstract Base Class)

**Purpose**: Defines the factory method interface for creating vehicles.

**Methods**:
- `Build()` - Abstract method that creates a default vehicle
- `SelectVehicle(string vehicleType)` - Abstract method that creates a specific vehicle type

**Location**: `ClassStudies/FactoryStudies/VehicleFactory.cs`

### CarFactory (Concrete Factory)

**Purpose**: Creates car-type vehicles (Saloon, Coupe, Sport).

**Methods**:
- `Build()` - Returns a new Saloon (default car)
- `SelectVehicle(string vehicleType)` - Creates car based on type:
  - `"saloon"` → `Saloon`
  - `"coupe"` → `Coupe`
  - `"sport"` → `Sport`
  - Other → `null`

**Location**: `ClassStudies/FactoryStudies/CarFactory.cs`

### VanFactory (Concrete Factory)

**Purpose**: Creates van-type vehicles (BoxVan, Pickup).

**Methods**:
- `Build()` - Returns a new BoxVan (default van)
- `SelectVehicle(string vehicleType)` - Creates van based on type:
  - `"boxvan"` → `BoxVan`
  - `"pickup"` → `Pickup`
  - Other → `null`

**Location**: `ClassStudies/FactoryStudies/VanFactory.cs`

## UML Diagram Mapping

The implementation follows the second UML diagram with:

```
<<interface>>
IVehicle
    ↑
AbstractVehicle
    ↑
    ├── AbstractCar ←── Saloon, Coupe, Sport
    └── AbstractVan ←── BoxVan, Pickup

VehicleFactory
    ↑
    ├── CarFactory ----builds---→ Saloon, Coupe, Sport
    └── VanFactory ----builds---→ BoxVan, Pickup
```

## Design Pattern Benefits

### 1. **Encapsulation of Object Creation**
- Vehicle creation logic is centralized in factory classes
- Clients don't need to know concrete class names

### 2. **Open/Closed Principle**
- Easy to add new vehicle types without modifying existing code
- New factories can be added by extending `VehicleFactory`

### 3. **Single Responsibility**
- Factories handle only object creation
- Vehicle classes handle only vehicle behavior

### 4. **Polymorphism**
- All factories return `IVehicle` interface
- Allows treating different vehicles uniformly

## Usage Examples

### Example 1: Using Build() Method
```csharp
// Create default car (Saloon)
VehicleFactory carFactory = new CarFactory();
IVehicle car = carFactory.Build();
car.Paint(); // Output: Painting the Saloon Silver

// Create default van (BoxVan)
VehicleFactory vanFactory = new VanFactory();
IVehicle van = vanFactory.Build();
van.Paint(); // Output: Painting the Box Van White
```

### Example 2: Using SelectVehicle() Method
```csharp
// Create specific car type
CarFactory carFactory = new CarFactory();
IVehicle? sport = carFactory.SelectVehicle("sport");
sport?.Paint(); // Output: Painting the Sport car Yellow

// Create specific van type
VanFactory vanFactory = new VanFactory();
IVehicle? pickup = vanFactory.SelectVehicle("pickup");
pickup?.Paint(); // Output: Painting the Pickup Black
```

### Example 3: Factory Polymorphism
```csharp
// Array of factories
VehicleFactory[] factories = { new CarFactory(), new VanFactory() };

// Build default vehicles from each factory
foreach (VehicleFactory factory in factories)
{
    IVehicle vehicle = factory.Build();
    Console.WriteLine($"Built: {vehicle.GetType().Name}");
    vehicle.Paint();
}
```

### Example 4: Type Selection with User Input
```csharp
CarFactory carFactory = new CarFactory();
string userChoice = "coupe"; // Could come from user input

IVehicle? selectedCar = carFactory.SelectVehicle(userChoice);
if (selectedCar != null)
{
    Console.WriteLine($"Engine: {selectedCar.Engine}");
    Console.WriteLine($"Colour: {selectedCar.Colour}");
    selectedCar.Paint();
}
else
{
    Console.WriteLine("Invalid car type selected.");
}
```

## Implementation Details

### Pattern Type
**Factory Method Pattern** (GoF)

### Key Features
- Abstract base factory defines the interface
- Concrete factories implement creation logic
- Two methods per factory: default creation and type-specific selection
- Case-insensitive vehicle type matching
- Returns nullable `IVehicle?` for invalid types

### Namespace
`Learning_AdvancedCSharpStudies.ClassStudies.FactoryStudies`

### Dependencies
- Uses: `CompanyVehicles` namespace
- Creates: `IVehicle`, `AbstractCar`, `AbstractVan` and their implementations

## Files Created

1. **VehicleFactory.cs** - Abstract base factory
2. **CarFactory.cs** - Concrete car factory
3. **VanFactory.cs** - Concrete van factory

## Build Status

✅ **Solution builds successfully**
- No compilation errors
- No warnings
- All factory methods properly implement abstract base

## Design Notes

### Why Two Methods?

**`Build()`**
- Simple factory method for default vehicle
- No parameters required
- Always returns a valid vehicle

**`SelectVehicle(string vehicleType)`**
- Allows runtime vehicle type selection
- More flexible for user-driven scenarios
- Returns `null` for invalid types

### String Matching Strategy
- Uses `ToLower()` for case-insensitive matching
- Pattern matching with switch expression (C# 8+)
- Returns `null` for unrecognized types (default case)

## Extension Points

### Adding New Vehicle Types
To add a new car type (e.g., "Hatchback"):

1. Create `Hatchback.cs` in `CompanyVehicles`
2. Update `CarFactory.SelectVehicle()`:
   ```csharp
   return vehicleType.ToLower() switch
   {
       "saloon" => new Saloon(),
       "coupe" => new Coupe(),
       "sport" => new Sport(),
       "hatchback" => new Hatchback(), // Add here
       _ => null
   };
   ```

### Adding New Factory Types
To add a new factory (e.g., "TruckFactory"):

1. Create `TruckFactory.cs`
2. Extend `VehicleFactory`
3. Implement `Build()` and `SelectVehicle()` methods
4. Create corresponding truck vehicle classes

## Testing Recommendations

When implementing tests, consider:

1. **Factory Creation Tests**
   - Verify each factory creates correct default vehicle
   - Test all vehicle types through `SelectVehicle()`

2. **Null Handling Tests**
   - Test invalid vehicle types return `null`
   - Test empty string input
   - Test null parameter handling

3. **Case Insensitivity Tests**
   - Verify "SPORT", "Sport", "sport" all work

4. **Polymorphism Tests**
   - Verify factories can be used through base class reference
   - Test all returned vehicles implement `IVehicle`

5. **Integration Tests**
   - Verify created vehicles have correct properties
   - Test `Paint()` method on factory-created vehicles

## Relation to Other Patterns

This implementation could be combined with:

- **Abstract Factory** - For creating families of related vehicles
- **Builder Pattern** - For complex vehicle configuration
- **Prototype Pattern** - For cloning vehicle instances
- **Singleton** - To ensure only one factory instance per type

## References

- Location: `Learning_AdvancedCSharpStudies/ClassStudies/FactoryStudies/`
- Vehicle Classes: `CompanyVehicles/` subdirectory
- Migration History: `docs/INHERITANCE_MIGRATION_SUMMARY.md`