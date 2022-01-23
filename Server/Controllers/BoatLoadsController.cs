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
    public class BoatLoadsController : ControllerBase
    {
        private readonly IBoatLoadRepository boatLoadRepository;

        public BoatLoadsController(IBoatLoadRepository boatLoadRepository)
        {
            this.boatLoadRepository = boatLoadRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetBoatLoads()
        {
            try
            {
                return Ok(await boatLoadRepository.GetBoatLoads());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Retrieving data from the database.{ex}");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BoatLoad>> GetBoatLoad(int Id)
        {
            try
            {
                var result = await boatLoadRepository.GetBoatLoad(Id);
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
        public async Task<ActionResult<BoatLoad>> CreateBoatLoad(BoatLoad boatLoad)
        {
            try
            {
                if (boatLoad == null)
                {
                    return BadRequest();
                }
                var CreatedBoatLoad = await boatLoadRepository.AddBoatLoad(boatLoad);

                return CreatedAtAction(nameof(GetBoatLoad),
                                       new { id = CreatedBoatLoad.BoatLoadId }, CreatedBoatLoad);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error adding data to the database. {ex}");
            }
        }


        [HttpPut]
        public async Task<ActionResult<BoatLoad>> UpdateBoatLoad(BoatLoad boatLoad)
        {
            try
            {
                var boatToUpdate = await boatLoadRepository.GetBoatLoad(boatLoad.BoatLoadId);

                if (boatToUpdate == null)
                {
                    return NotFound($"Boat Load with the Id = {boatLoad.BoatLoadId} Not Found");
                }

                return await boatLoadRepository.UpdateBoatLoad(boatLoad);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error updating data. {ex}");
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<BoatLoad>> DeleteBoatLoad(int id)
        {
            try
            {
                var boatToDelete = await boatLoadRepository.GetBoatLoad(id);
                if (boatToDelete == null)
                {
                    return NotFound($"Boat Load with the Id = {id} Not Found");
                }
                return await boatLoadRepository.DeleteBoatLoad(id);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Deleting data. {ex}");
            }
        }
    }
}
