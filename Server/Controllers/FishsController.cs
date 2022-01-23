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
    public class FishsController : ControllerBase
    {
        private readonly IFishRepository fishRepository;

        public FishsController(IFishRepository fishRepository)
        {
            this.fishRepository = fishRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetFishs()
        {
            try
            {
                return Ok(await fishRepository.GetFishs());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Retrieving data from the database.{ex}");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Fish>> GetFish(int Id)
        {
            try
            {
                var result = await fishRepository.GetFish(Id);
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
        public async Task<ActionResult<Fish>> CreateFish(Fish fish)
        {
            try
            {
                if (fish == null)
                {
                    return BadRequest();
                }
                var CreatedFish = await fishRepository.AddFish(fish);

                return CreatedAtAction(nameof(GetFish),
                                       new { id = CreatedFish.FishId }, CreatedFish);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error adding data to the database. {ex}");
            }
        }


        [HttpPut]
        public async Task<ActionResult<Fish>> UpdateFish(Fish fish)
        {
            try
            {
                var fishToUpdate = await fishRepository.GetFish(fish.FishId);

                if (fishToUpdate == null)
                {
                    return NotFound($"Fish with the Id = {fish.FishId} Not Found");
                }

                return await fishRepository.UpdateFish(fish);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error updating data. {ex}");
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Fish>> DeleteFish(int id)
        {
            try
            {
                var fishToDelete = await fishRepository.GetFish(id);
                if (fishToDelete == null)
                {
                    return NotFound($"Fish with the Id = {id} Not Found");
                }
                return await fishRepository.DeleteFish(id);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Deleting data. {ex}");
            }
        }

    }
}
