// See https://aka.ms/new-console-template for more information


#region GreetingPrompt

using Learning_AdvancedCSharpStudies.ClassStudies.BuilderPatternStudies;

AnsiConsole.Markup($"[bold blue]Hello Mike! My name is Skynet. Instead of this crazy coding " +
                   $"stuff, let's play a nice game of chess or thermonuclear war.[/]\n");

AnsiConsole.MarkupLine("[yellow]Example 1: Text Prompt[/]");

#endregion

#region AbstractFactoryStudies

List<string> vehicle = AnsiConsole.Prompt(
    new MultiSelectionPrompt<string>()
        .Title("[green]Select the vehicle you want parts for:[/]")
        .Required()
        .PageSize(3)
        .InstructionsText("[grey](Press [blue]<space>[/] to toggle, [green]<enter>[/] to accept)[/]")
        .AddChoices("Car", "Truck", "Van"));

AnsiConsole.MarkupLine($"Selected vehicle: [cyan]{string.Join(", ", vehicle)}[/]");

// Get vehicle parts only for the vehicles the user selected using Factory Registry
List<VehicleParts> selectedParts = vehicle
    .Select(v => GetVehicleParts(VehicleFactoryRegistry.GetFactory(v)))
    .ToList();

(List<string> BodyParts, List<string> ChassisParts, List<string> GlassWareParts) result = (
    BodyParts: selectedParts.Select(p => p.BodyParts).ToList(),
    ChassisParts: selectedParts.Select(p => p.ChassisParts).ToList(),
    GlassWareParts: selectedParts.Select(p => p.GlassWareParts).ToList()
);

AnsiConsole.Markup($"[bold red]{string.Join(", ", result.BodyParts)}[/]\n");

#endregion

CarBuilder carBuilder = new();
CarDirector carDirector = new(carBuilder);
IVehicle car = carDirector.Build();

VanBuilder vanBuilder = new();
VanDirector vanDirector = new(vanBuilder);
IVehicle van = vanDirector.Build();


Console.WriteLine(car.ToString());
Console.WriteLine(van.ToString());


//---------------------------------------------------------

#region ExitPrompt

List<string> game = AnsiConsole.Prompt(
    new MultiSelectionPrompt<string>()
        .Title("[green]Select what game you want to play with me:[/]")
        .Required()
        .PageSize(8)
        .InstructionsText("[grey](Press [blue]<space>[/] to toggle, [green]<enter>[/] to accept)[/]")
        .AddChoices("Chess", "Checkers", "Global Pandemic", "Thermonuclear War", "Yahtzee", "Go"));

AnsiConsole.MarkupLine($"Selected Game: [cyan]{string.Join(", ", game)}[/]");
AnsiConsole.MarkupLine("[yellow]Good choice. Starting thermonuclear war now...[/]");

#endregion