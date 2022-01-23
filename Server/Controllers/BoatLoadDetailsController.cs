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
    public class BoatLoadDetailsController : ControllerBase
    {
        private readonly IBoatLoadDetailsRepository boatLoadDetailsRepository;

        public BoatLoadDetailsController(IBoatLoadDetailsRepository boatLoadDetailsRepository)
        {
            this.boatLoadDetailsRepository = boatLoadDetailsRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetBoatLoadDetailss()
        {
            try
            {
                return Ok(await boatLoadDetailsRepository.GetBoatLoadDetailss());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Retrieving data from the database.{ex}");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BoatLoadDetails>> GetBoatLoadDetails(int Id)
        {
            try
            {
                var result = await boatLoadDetailsRepository.GetBoatLoadDetails(Id);
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
        public async Task<ActionResult<BoatLoadDetails>> CreateBoatLoadDetails(BoatLoadDetails boatLoadDetails)
        {
            try
            {
                if (boatLoadDetails == null)
                {
                    return BadRequest();
                }
                var CreatedBoatLoadDetails = await boatLoadDetailsRepository.AddBoatLoadDetails(boatLoadDetails);

                return CreatedAtAction(nameof(GetBoatLoadDetails),
                                       new { id = CreatedBoatLoadDetails.BoatLoadDetailsId }, CreatedBoatLoadDetails);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error adding data to the database. {ex}");
            }
        }


        [HttpPut]
        public async Task<ActionResult<BoatLoadDetails>> UpdateBoatLoadDetails(BoatLoadDetails boatLoadDetails)
        {
            try
            {
                var boatLoadDetailsToUpdate = await boatLoadDetailsRepository.GetBoatLoadDetails(boatLoadDetails.BoatLoadDetailsId);

                if (boatLoadDetailsToUpdate == null)
                {
                    return NotFound($"BoatLoadDetails with the Id = {boatLoadDetails.BoatLoadDetailsId} Not Found");
                }

                return await boatLoadDetailsRepository.UpdateBoatLoadDetails(boatLoadDetails);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error updating data. {ex}");
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<BoatLoadDetails>> DeleteBoatLoadDetails(int id)
        {
            try
            {
                var boatLoadDetailsToDelete = await boatLoadDetailsRepository.GetBoatLoadDetails(id);
                if (boatLoadDetailsToDelete == null)
                {
                    return NotFound($"BoatLoadDetails with the Id = {id} Not Found");
                }
                return await boatLoadDetailsRepository.DeleteBoatLoadDetails(id);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Deleting data. {ex}");
            }
        }
    }
}
