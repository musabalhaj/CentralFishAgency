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
    public class PurchaseOrdersController : ControllerBase
    {
        private readonly IPurchaseOrderRepository purchaseOrderRepository;

        public PurchaseOrdersController(IPurchaseOrderRepository purchaseOrderRepository)
        {
            this.purchaseOrderRepository = purchaseOrderRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetPurchaseOrders()
        {
            try
            {
                return Ok(await purchaseOrderRepository.GetPurchaseOrders());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Retrieving data from the database.{ex}");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PurchaseOrder>> GetPurchaseOrder(int Id)
        {
            try
            {
                var result = await purchaseOrderRepository.GetPurchaseOrder(Id);
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
        public async Task<ActionResult<PurchaseOrder>> CreatePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            try
            {
                if (purchaseOrder == null)
                {
                    return BadRequest();
                }
                var CreatedPurchaseOrder = await purchaseOrderRepository.AddPurchaseOrder(purchaseOrder);

                return CreatedAtAction(nameof(GetPurchaseOrder),
                                       new { id = CreatedPurchaseOrder.PurchaseOrderId }, CreatedPurchaseOrder);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error adding data to the database. {ex}");
            }
        }


        [HttpPut]
        public async Task<ActionResult<PurchaseOrder>> UpdatePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            try
            {
                var purchaseOrderToUpdate = await purchaseOrderRepository.GetPurchaseOrder(purchaseOrder.PurchaseOrderId);

                if (purchaseOrderToUpdate == null)
                {
                    return NotFound($"PurchaseOrder with the Id = {purchaseOrder.PurchaseOrderId} Not Found");
                }

                return await purchaseOrderRepository.UpdatePurchaseOrder(purchaseOrder);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error updating data. {ex}");
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PurchaseOrder>> DeletePurchaseOrder(int id)
        {
            try
            {
                var purchaseOrderToDelete = await purchaseOrderRepository.GetPurchaseOrder(id);
                if (purchaseOrderToDelete == null)
                {
                    return NotFound($"PurchaseOrder with the Id = {id} Not Found");
                }
                return await purchaseOrderRepository.DeletePurchaseOrder(id);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Deleting data. {ex}");
            }
        }
    }
}
