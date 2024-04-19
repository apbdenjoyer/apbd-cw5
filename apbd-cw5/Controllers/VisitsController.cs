using apbd_cw5.Models;
using Microsoft.AspNetCore.Mvc;

namespace apbd_cw5.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VisitsController : ControllerBase
{
    private static readonly List<Visit> Visits = new() { };

    [HttpGet("{id:int}")]
    public IActionResult GetVisits(int id)
    {
        var visitsForThisAnimal = new List<Visit>();
        for (var index = 0; index < Visits.Count; index++)
        {
            var visit = Visits[index];
            if (visit.AnimalID == id)
            {
                visitsForThisAnimal.Add(visit);
            }
        }

        if (visitsForThisAnimal.Count == 0)
        {
            return NotFound($"No visits for animal with id {id}.");
        }

        return Ok(visitsForThisAnimal);
    }

    [HttpPost]
    public IActionResult AddVisit(Visit visit)
    {
        foreach (var animal in AnimalsController._animals)
        {
            if (animal.ID == visit.AnimalID)
            {
                Visits.Add(visit);
                return Created();
                
            }

        }

        return NotFound($"Animal with ID {visit.AnimalID} not in database - cannot add a visit.");
    }
}