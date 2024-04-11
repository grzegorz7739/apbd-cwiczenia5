namespace RestApi.Models;

public class Animal
{
    public int Id{ get; set; }
    public string Name { get; set; }
    public string Kategoria { get; set; }
    public double Masa { get; set; }
    public string KolorSiersci { get; set; }
    public Animal(int id, string name, string kategoria, string kolorSiersci, double masa)
    {
        Id = id;
        Name = name;
        Kategoria = kategoria;
        KolorSiersci = kolorSiersci;
        Masa = masa;
    }
    
    
}