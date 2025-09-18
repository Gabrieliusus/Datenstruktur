namespace Common;

public class Person
{
    public int Id { get; set; }
    private string _geschlecht = string.Empty;
    public string Name { get; set; } = string.Empty;

    public string Geschlecht
    {
        get => _geschlecht;
        set
        {
            if (value is not ("männlich" or "weiblich" or "Männlich" or "Weiblich"))
                throw new ArgumentException("Ungültiges Geschlecht eingegeben!");
            _geschlecht = value;
        }
    }

    public DateTime Geburtstag { get; set; }
    public int Alter => DateTime.Today.Year - Geburtstag.Year;

    public Person(DateTime geburtstag, string geschlecht, string name)
    {
        Geburtstag = geburtstag;
        Geschlecht = geschlecht;
        Name = name;
    }

    public override string ToString() => $"Name: {Name}, Alter: {Alter}, Geschlecht: {Geschlecht}";
}
