using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        // / GET /api/bakers
        [HttpGet]
        public IEnumerable<PetOwner> GetAll()
        {
            // Look ma, no SQL queries!
            return _context.PetOwners;
        }


        [HttpGet("{id}")]
        public ActionResult<PetOwner> GetById(int id) {
            Console.WriteLine("GET /api/petOwners/:id request received");
            PetOwner petOwner =  _context.PetOwners
                .SingleOrDefault(petOwner => petOwner.id == id);
            
            // Return a `404 Not Found` if the petOwner doesn't exist
            if(petOwner is null) {
                return NotFound();
                // res.sendStatus(404);
            }
            return petOwner;
        }

    // POST /api/bakers
    [HttpPost]
    public PetOwner Post(PetOwner petOwner) 
    {
        _context.Add(petOwner);
        _context.SaveChanges();

        return petOwner;
    }
    }
}
