using Microsoft.AspNetCore.Http.HttpResults;
using RestApi.Database;
using RestApi.Models;

namespace RestApi.Endpoints;

public static class AnimalEndpoints
{
    public static void MapAnimalEndpoints(this WebApplication app)
    {
        var AnimalsList = new MockDb().Animals;
        app.MapGet("animals", () =>
        {
            var AnimalsList = new MockDb().Animals;
            return Results.Ok(AnimalsList );
        });
        app.MapGet("animals/{id}", (int id) =>
        {
            var result = AnimalsList.Find(x => x.Id.Equals(id));
            if (result == null)
            {
                return Results.NotFound($"Nie ma zwierzaka o id {id}");
            }

            return Results.Ok(result);
        });
        app.MapPost("animals/create", (Animal animal) =>
        {
            AnimalsList.Add(animal);
            return Results.Created();
        });
        app.MapPut("animals/edit/{id}", (int id, Animal animal) =>
        {
            var animalEdit = AnimalsList.Find(x => x.Id.Equals(id));

            if (animalEdit == null)
            {
                return Results.NotFound($"Nie ma zwierzaka o id {id}");
            }

            AnimalsList.Remove(animalEdit);
            AnimalsList.Add(animal);
            return Results.Ok("Edited");
        });
        app.MapDelete("animals/delete/{id}", (int id) =>
        {
            AnimalsList.Remove(AnimalsList.Find(x => x.Id.Equals(id)) ?? throw new InvalidOperationException());
            return Results.Ok(AnimalsList);
        });




    }
}