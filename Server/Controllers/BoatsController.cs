using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectX.Server.Interfaces;
using ProjectX.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectX.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoatsController : ControllerBase
    {
        private readonly IBoatRepository boatRepository;

        public BoatsController(IBoatRepository boatRepository)
        {
            this.boatRepository = boatRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetBoats()
        {
            try
            {
                return Ok(await boatRepository.GetBoats());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Retrieving data from the database.{ex}");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Boat>> GetBoat(int Id)
        {
            try
            {
                var result = await boatRepository.GetBoat(Id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Retrieving data from the database. {ex}");
            }
        }


        [HttpPost]
        public async Task<ActionResult<Boat>> CreateBoat(Boat boat)
        {
            try
            {
                if (boat == null)
                {
                    return BadRequest();
                }
                var CreatedBoat = await boatRepository.AddBoat(boat);

                return CreatedAtAction(nameof(GetBoat),
                                       new { id = CreatedBoat.BoatId }, CreatedBoat);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error adding data to the database. {ex}");
            }
        }


        [HttpPut]
        public async Task<ActionResult<Boat>> UpdateBoat(Boat boat)
        {
            try
            {
                var boatToUpdate = await boatRepository.GetBoat(boat.BoatId);

                if (boatToUpdate == null)
                {
                    return NotFound($"Boat with the Id = {boat.BoatId} Not Found");
                }

                return await boatRepository.UpdateBoat(boat);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error updating data. {ex}");
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Boat>> DeleteBoat(int id)
        {
            try
            {
                var boatToDelete = await boatRepository.GetBoat(id);
                if (boatToDelete == null)
                {
                    return NotFound($"Boat with the Id = {id} Not Found");
                }
                return await boatRepository.DeleteBoat(id);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Deleting data. {ex}");
            }
        }
    }
}
