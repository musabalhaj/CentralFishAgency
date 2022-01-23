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
    public class PurchaseBatchsController : ControllerBase
    {
        private readonly IPurchaseBatchRepository purchaseBatchRepository;

        public PurchaseBatchsController(IPurchaseBatchRepository purchaseBatchRepository)
        {
            this.purchaseBatchRepository = purchaseBatchRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetPurchaseBatchs()
        {
            try
            {
                return Ok(await purchaseBatchRepository.GetPurchaseBatchs());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Retrieving data from the database.{ex}");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PurchaseBatch>> GetPurchaseBatch(int Id)
        {
            try
            {
                var result = await purchaseBatchRepository.GetPurchaseBatch(Id);
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
        public async Task<ActionResult<PurchaseBatch>> CreatePurchaseBatch(PurchaseBatch purchaseBatch)
        {
            try
            {
                if (purchaseBatch == null)
                {
                    return BadRequest();
                }
                var CreatedPurchaseBatch = await purchaseBatchRepository.AddPurchaseBatch(purchaseBatch);

                return CreatedAtAction(nameof(GetPurchaseBatch),
                                       new { id = CreatedPurchaseBatch.PurchaseBatchId }, CreatedPurchaseBatch);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error adding data to the database. {ex}");
            }
        }


        [HttpPut]
        public async Task<ActionResult<PurchaseBatch>> UpdatePurchaseBatch(PurchaseBatch purchaseBatch)
        {
            try
            {
                var purchaseBatchToUpdate = await purchaseBatchRepository.GetPurchaseBatch(purchaseBatch.PurchaseBatchId);

                if (purchaseBatchToUpdate == null)
                {
                    return NotFound($"Purchase Batch with the Id = {purchaseBatch.PurchaseBatchId} Not Found");
                }

                return await purchaseBatchRepository.UpdatePurchaseBatch(purchaseBatch);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error updating data. {ex}");
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PurchaseBatch>> DeletePurchaseBatch(int id)
        {
            try
            {
                var purchaseBatchToDelete = await purchaseBatchRepository.GetPurchaseBatch(id);
                if (purchaseBatchToDelete == null)
                {
                    return NotFound($"Purchase Batch with the Id = {id} Not Found");
                }
                return await purchaseBatchRepository.DeletePurchaseBatch(id);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Deleting data. {ex}");
            }
        }
    }
}
