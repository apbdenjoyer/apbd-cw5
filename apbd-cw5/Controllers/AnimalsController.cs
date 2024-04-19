using System.Data;
using apbd_cw5.Models;
using Microsoft.AspNetCore.Mvc;

namespace apbd_cw5.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnimalsController : ControllerBase
{
    public static readonly List<Animal> _animals = new() { };


    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(_animals);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = _animals.FirstOrDefault(animal => animal.ID == id);
        if (animal == null)
        {
            return NotFound($"Animal with id {id} was not found.");
        }

        return Ok(animal);
    }

    [HttpPost]
    public IActionResult AddAnimal(Animal animal)
    {
        _animals.Add(animal);
        return Created();
    }

    [HttpPut("{id:int}")]
    public IActionResult EditAnimal(int id, Animal editedAnimal)
    {
        var animal = _animals.FirstOrDefault(animal => animal.ID == id);
        if (animal == null)
        {
            return NotFound($"Animal with id {id} was not found.");
        }

        _animals.Remove(animal);
        _animals.Add(editedAnimal);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animal = _animals.FirstOrDefault(animal => animal.ID == id);
        if (animal == null)
        {
            return NotFound($"Animal with id {id} was not found.");
        }

        _animals.Remove(animal);
        return Ok();
    }
}