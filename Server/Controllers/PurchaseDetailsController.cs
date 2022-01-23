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
    public class PurchaseDetailsController : ControllerBase
    {
        private readonly IPurchaseDetailsRepository purchaseDetailsRepository;

        public PurchaseDetailsController(IPurchaseDetailsRepository purchaseDetailsRepository)
        {
            this.purchaseDetailsRepository = purchaseDetailsRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetPurchaseDetailss()
        {
            try
            {
                return Ok(await purchaseDetailsRepository.GetPurchaseDetailss());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Retrieving data from the database.{ex}");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PurchaseDetails>> GetPurchaseDetails(int Id)
        {
            try
            {
                var result = await purchaseDetailsRepository.GetPurchaseDetails(Id);
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
        public async Task<ActionResult<PurchaseDetails>> CreatePurchaseDetails(PurchaseDetails purchaseDetails)
        {
            try
            {
                if (purchaseDetails == null)
                {
                    return BadRequest();
                }
                var CreatedPurchaseDetails = await purchaseDetailsRepository.AddPurchaseDetails(purchaseDetails);

                return CreatedAtAction(nameof(GetPurchaseDetails),
                                       new { id = CreatedPurchaseDetails.PurchaseDetailsId }, CreatedPurchaseDetails);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error adding data to the database. {ex}");
            }
        }


        [HttpPut]
        public async Task<ActionResult<PurchaseDetails>> UpdatePurchaseDetails(PurchaseDetails purchaseDetails)
        {
            try
            {
                var purchaseDetailsToUpdate = await purchaseDetailsRepository.GetPurchaseDetails(purchaseDetails.PurchaseDetailsId);

                if (purchaseDetailsToUpdate == null)
                {
                    return NotFound($"Purchase Details with the Id = {purchaseDetails.PurchaseDetailsId} Not Found");
                }

                return await purchaseDetailsRepository.UpdatePurchaseDetails(purchaseDetails);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error updating data. {ex}");
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PurchaseDetails>> DeletePurchaseDetails(int id)
        {
            try
            {
                var purchaseDetailsToDelete = await purchaseDetailsRepository.GetPurchaseDetails(id);
                if (purchaseDetailsToDelete == null)
                {
                    return NotFound($"Purchase Details with the Id = {id} Not Found");
                }
                return await purchaseDetailsRepository.DeletePurchaseDetails(id);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Deleting data. {ex}");
            }
        }
    }
}
