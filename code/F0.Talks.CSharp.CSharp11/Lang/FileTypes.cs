namespace F0.Talks.CSharp.CSharp11.Lang;

public class FileTypes : IFileScopedInterface
{
    public string MyMethod()
    {
        return new FileLocalType().Text;
    }
}

file class FileLocalType
{
    public FileLocalType()
    {
        Text = Nested.Name;
    }

    public string Text { get; init; }

    internal class Nested
    {
        public const string Name = "@0x_F0";
    }
}

file interface IFileScopedInterface
{
    string MyMethod();
}
