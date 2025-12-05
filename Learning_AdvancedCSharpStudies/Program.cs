// See https://aka.ms/new-console-template for more information

using Learning_AdvancedCSharpStudies.ClassStudies.AbstractFactoryStudies;
using static Learning_AdvancedCSharpStudies.ClassStudies.AbstractFactoryStudies.VehiclePartsHelper;

AnsiConsole.Markup($"[bold blue]Hello Mike! My name is Skynet. Instead of this crazy coding " +
                   $"stuff, let's play a nice game of chess or thermonuclear war.[/]\n");

AnsiConsole.MarkupLine("[yellow]Example 1: Text Prompt[/]");


List<string> vehicle = AnsiConsole.Prompt(
    new MultiSelectionPrompt<string>()
        .Title("[green]Select the vehicle you want parts for:[/]")
        .Required()
        .PageSize(3)
        .InstructionsText("[grey](Press [blue]<space>[/] to toggle, [green]<enter>[/] to accept)[/]")
        .AddChoices("Car", "Truck", "Van"));

AnsiConsole.MarkupLine($"Selected vehicle: [cyan]{string.Join(", ", vehicle)}[/]");

// Get vehicle parts only for the vehicles the user selected
List<(string, string, string)> selectedParts = vehicle
    .Select(v => v switch
    {
        "Car" => GetVehicleParts(new CarFactory()),
        "Truck" => GetVehicleParts(new TruckFactory()),
        "Van" => GetVehicleParts(new VanFactory()),
        _ => ("No Body Parts", "No Chassis Parts", "No GlassWare Parts")
    })
    .ToList();

(List<string> BodyParts, List<string> ChassisParts, List<string> GlassWareParts) result = (
    BodyParts: selectedParts.Select(p => p.Item1).ToList(),
    ChassisParts: selectedParts.Select(p => p.Item2).ToList(),
    GlassWareParts: selectedParts.Select(p => p.Item3).ToList()
);

AnsiConsole.Markup($"[bold red]{string.Join(", ", result.BodyParts)}[/]\n");


List<string> game = AnsiConsole.Prompt(
    new MultiSelectionPrompt<string>()
        .Title("[green]Select what game you want to play with me:[/]")
        .Required()
        .PageSize(8)
        .InstructionsText("[grey](Press [blue]<space>[/] to toggle, [green]<enter>[/] to accept)[/]")
        .AddChoices("Chess", "Checkers", "Global Pandemic", "Thermonuclear War", "Yahtzee", "Go"));

AnsiConsole.MarkupLine($"Selected Game: [cyan]{string.Join(", ", game)}[/]");
AnsiConsole.MarkupLine("[yellow]Good choice. Starting thermonuclear war now...[/]");