namespace Learning_AdvancedCSharpStudies.RecordStudies;

/// <summary>
/// Represents an immutable account with a unique identifier and name.
/// </summary>
public sealed record Account
{
    /// <summary>
    /// Gets the unique identifier for the account.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets the name of the account.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Account"/> record.
    /// </summary>
    /// <param name="id">The unique identifier for the account.</param>
    /// <param name="name">The name of the account.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="id"/> is <see cref="Guid.Empty"/>.
    /// </exception>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="name"/> is <see langword="null"/> or whitespace.
    /// </exception>
    public Account(Guid id, string name)
    {
        Id = ValidateGuid(id, nameof(id));
        Name = ValidateName(name, nameof(name));
    }

    private static string ValidateName(string? name, string paramName)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(name, paramName);
        return name!;
    }

    private static Guid ValidateGuid(Guid guid, string paramName) =>
        guid != Guid.Empty
            ? guid
            : throw new ArgumentException("Id cannot be empty", paramName);

    /// <summary>
    /// Returns a string representation of the account.
    /// </summary>
    /// <returns>A string containing the account's ID and name.</returns>
    public override string ToString() => $"Account(Id: {Id}, Name: {Name})";
}