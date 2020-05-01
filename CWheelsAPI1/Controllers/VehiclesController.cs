using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CWheelsAPI1.Data;
using CWheelsAPI1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CWheelsAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {

        private CWheelsDbContext _cWheelsDbContext;

        public VehiclesController(CWheelsDbContext cWheelsDbContext)
        {
            _cWheelsDbContext = cWheelsDbContext;
        }

        // GET: api/Vehicles
        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_cWheelsDbContext.Vehicles);

        }

        // GET: api/Vehicles/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var vehicle = _cWheelsDbContext.Vehicles.Find(id);

            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }

        [HttpGet("[action]/{id}")]
        public int Test(int ID)
        {
            return ID;
        }

        // POST: api/Vehicles
        [HttpPost]
        public IActionResult Post([FromBody] Vehicle vehicle)
        {
            _cWheelsDbContext.Vehicles.Add(vehicle);
            _cWheelsDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Vehicles/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Vehicle vehicle)
        {
            var enitity = _cWheelsDbContext.Vehicles.Find(id);

            if (enitity == null)
            {
                return NotFound("We could find no record of this ID");
            }
            else
            {
                enitity.Title = vehicle.Title;
                enitity.Price = vehicle.Price;
                enitity.Color = vehicle.Color;
                _cWheelsDbContext.SaveChanges();
                return Ok("Record Updated Succesfully");
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           var vehicle =  _cWheelsDbContext.Vehicles.Find(id);
            
            if (vehicle == null)
            {
                return NotFound("No record found against this ID");
            }
            else
            {
                _cWheelsDbContext.Vehicles.Remove(vehicle);
                _cWheelsDbContext.SaveChanges();
                return Ok("Record Deleted.");
            }
        }
    }
}
