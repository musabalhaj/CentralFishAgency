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
    public class ReportsController : ControllerBase
    {
        private readonly IReportRepository reportRepository;

        public ReportsController(IReportRepository reportRepository)
        {
            this.reportRepository = reportRepository;
        }

        [HttpGet("{boatLoadReport}")]
        public async Task<ActionResult<IEnumerable<BoatLoad>>> BoatLoadReport(int boatId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var result = await reportRepository.BoatLoadReport(boatId, fromDate.Date, toDate.Date);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error Geting Data From The Database.");
            }
        }

        [HttpGet("{purchaseOrderReport}/{status}")]
        public async Task<ActionResult<IEnumerable<PurchaseOrder>>> PurchaseOrderReport(Status status)
        {
            try
            {
                var result = await reportRepository.PurchaseOrderReport(status);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error Geting Data From The Database.");
            }
        }



        [Route("~/api/Reports/RequestedDeliveredReport")]
        public async Task<ActionResult<IEnumerable<PurchaseOrder>>> RequestedDeliveredReport(Status status, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var result = await reportRepository.RequestedDeliveredReport(status, fromDate.Date, toDate.Date);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error Geting Data From The Database.");
            }
        }

        [Route("~/api/Reports/fishQuantityReport")]
        public async Task<ActionResult<IEnumerable<PurchaseOrder>>> FishQuantityReport(int month)
        {
            try
            {
                var result = await reportRepository.FishQuantityReport(month);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error Geting Data From The Database.");
            }
        }

        [Route("~/api/Reports/fishBoatReport")]
        public async Task<ActionResult<IEnumerable<BoatLoad>>> FishBoatReport(int fishId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var result = await reportRepository.FishBoatReport(fishId, fromDate.Date, toDate.Date);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error Geting Data From The Database.");
            }
        }


        [Route("~/api/Reports/batchDistribution")]
        public async Task<ActionResult<IEnumerable<PurchaseBatch>>> BatchDistribution(int batchId)
        {
            try
            {
                var result = await reportRepository.BatchDistribution(batchId);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Error Geting Data From The Database.");
            }
        }




    }
}
