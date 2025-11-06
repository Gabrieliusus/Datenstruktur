namespace Common;

public class Person
{
    public DateTime Geburtsdatum { get; }
    public string Geschlecht { get; }
    public string Name { get; }

    public Person(DateTime geburtsdatum, string geschlecht, string name)
    {
        Geburtsdatum = geburtsdatum;
        Geschlecht = geschlecht;
        Name = name;
    }

    public override string ToString() => $"{Name} ({Geschlecht}, {Geburtsdatum:dd.MM.yyyy})";
}
