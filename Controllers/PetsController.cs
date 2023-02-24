using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetsController(ApplicationContext context) {
            _context = context;
        }

    [HttpGet]
    public IEnumerable<Pet> GetPets()
    {
        return _context.Pets
            // Include the `petOwner` property
            // which is a list of `PetOwner` objects
            // .NET will do a JOIN for us!
            .Include(pet => pet.petOwner);
    }

    [HttpPost]
    public Pet Post(Pet pet)
    {
        // Tell the DB context about our new pet object
        _context.Add(pet);
        // ...and save the pet object to the database
        _context.SaveChanges();
        // Respond back with the created pet object
        return pet;
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        // Find the pet, by ID
        Pet pet = _context.Pets.Find(id);
        // Tell the DB that we want to remove this bread
        _context.Pets.Remove(pet);
        // ...and save the changes to the database
        _context.SaveChanges();
    }




    }
}
