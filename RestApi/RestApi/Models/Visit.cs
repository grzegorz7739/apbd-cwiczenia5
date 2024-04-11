using System.Runtime.InteropServices.JavaScript;

namespace RestApi.Models;

public class Visit
{
    public string DateTime { get; set; }
    public Animal Animal { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }

    public Visit(String dateTime, string description,Animal animal,double price)
    {
        Description = description;
        Price = price;
        DateTime = dateTime;
        Animal = animal;
    }

    public override string ToString()
    {
        return String.Format("Name: {0}, Type: {1}, Cost: {2}, UserName: {3}", DateTime, Animal, Price, Description);
    }
}