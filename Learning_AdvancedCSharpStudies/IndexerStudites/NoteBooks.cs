namespace Learning_AdvancedCSharpStudies.IndexerStudites;

public class NoteBooks
{
    private readonly string[] _notebooks = new string[1000];

    public string this[int index]
    {
        get => _notebooks[index];
        set => _notebooks[index] = value;
    }
}