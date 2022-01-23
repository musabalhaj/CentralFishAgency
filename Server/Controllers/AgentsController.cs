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
    public class AgentsController : ControllerBase
    {
        private readonly IAgentRepository agentRepository;

        public AgentsController(IAgentRepository agentRepository)
        {
            this.agentRepository = agentRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAgents()
        {
            try
            {
                return Ok(await agentRepository.GetAgents());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Retrieving data from the database.{ex}");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Agent>> GetAgent(int Id)
        {
            try
            {
                var result = await agentRepository.GetAgent(Id);
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
        public async Task<ActionResult<Agent>> CreateAgent(Agent agent)
        {
            try
            {
                if (agent == null)
                {
                    return BadRequest();
                }
                var CreatedAgent = await agentRepository.AddAgent(agent);

                return CreatedAtAction(nameof(GetAgent),
                                       new { id = CreatedAgent.AgentId }, CreatedAgent);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error adding data to the database. {ex}");
            }
        }


        [HttpPut]
        public async Task<ActionResult<Agent>> UpdateAgent(Agent agent)
        {
            try
            {
                var agentToUpdate = await agentRepository.GetAgent(agent.AgentId);

                if (agentToUpdate == null)
                {
                    return NotFound($"Agent with the Id = {agent.AgentId} Not Found");
                }

                return await agentRepository.UpdateAgent(agent);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error updating data. {ex}");
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Agent>> DeleteAgent(int id)
        {
            try
            {
                var agentToDelete = await agentRepository.GetAgent(id);
                if (agentToDelete == null)
                {
                    return NotFound($"Agent with the Id = {id} Not Found");
                }
                return await agentRepository.DeleteAgent(id);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Deleting data. {ex}");
            }
        }
    }
}
