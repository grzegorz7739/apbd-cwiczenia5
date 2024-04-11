using RestApi.Models;

namespace RestApi.Database;

public class MockDb
{
    public List<Animal> Animals { get; set; } = new List<Animal>();
    public List<Visit> Visits { get; set; }  = new List<Visit>();

    public MockDb()
    {
        Animals.Add(new Animal(1,"Jurek","Kategoria","czerwony",32.0));
        Animals.Add(new Animal(2,"Marek","Kategoria","czerwony",32.0));
        Animals.Add(new Animal(3,"Krzysiek","Kategoria","czerwony",32.0));
        Animals.Add(new Animal(4,"Krystian","Kategoria","czerwony",32.0));
    }
    
}