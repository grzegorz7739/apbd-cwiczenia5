using System.Collections;
using System.Globalization;
using RestApi.Database;
using RestApi.Models;

namespace RestApi.Endpoints;

public static class VisitEndpoints
{
    public static void MapVisitsEndpoints(this WebApplication app)
    {
        var AnimalsList = new MockDb().Animals;
        var Visits = new MockDb().Visits;
        app.MapGet("visits/{id}", (int id) =>
        {
            var AnimalToFind = AnimalsList.Find(x => x.Id.Equals(id));
            if (AnimalToFind == null)
            {
                return Results.NotFound($"Nie ma zwierzaka o id {id}");
            }
            List<Visit> AnimalVisits = new List<Visit>();
            foreach (var v in Visits)
            {
                if (v.Animal.Id == AnimalToFind.Id )
                {
                    AnimalVisits.Add(v);
                }
            }

            return Results.Ok(AnimalVisits);
        });
        app.MapPost("visit/add/{id}", (int id,Visit visit) =>
        {
            var AnimalToVisit = AnimalsList.Find(x => x.Id.Equals(id));
            if (AnimalToVisit == null)
            {
                return Results.NotFound($"Nie ma zwierzaka o id {id}");
            }
            visit.Animal = AnimalToVisit;
            Visits.Add(visit);
            return Results.Ok("Added");
        });
    }
}