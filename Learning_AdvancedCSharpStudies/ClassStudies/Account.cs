namespace Learning_AdvancedCSharpStudies.ClassStudies;

public sealed record Account(Guid Id, string Name)
{
    /// <summary>
    ///     Gets the unique identifier for the account.
    /// </summary>
    public Guid Id { get; init; } = ValidateGuid(Id, nameof(Id));

    /// <summary>
    ///     Gets the name of the account.
    /// </summary>
    public string Name { get; init; } = ValidateName(Name, nameof(Name));

    private static string ValidateName(string? name, string paramName)
    {
        return !string.IsNullOrWhiteSpace(name)
            ? name
            : throw new ArgumentException("Name cannot be null or empty", paramName);
    }

    private static Guid ValidateGuid(Guid guid, string paramName)
    {
        return guid != Guid.Empty ? guid : throw new ArgumentException("Id cannot be empty", paramName);
    }

    public override string ToString()
    {
        return $"Account(Id: {Id}, Name: {Name})";
    }
}