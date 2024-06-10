using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using MicroTrialFreelance.Entities;

using MicroTrialFreelance.Models;
using MicroTrialFreelance.Repositories.Implements;
using MicroTrialFreelance.Repositories.Interfaces;

using MicroTrialFreelance.Data;
using StackExchange.Redis;
using System.Text.Json;
using MicroTrialFreelance.Routes;
using MicroTrialFreelance.Services.Interfaces;
using MicroTrialFreelance.Services.Implements;
using Microsoft.Extensions.Caching.Distributed;

namespace MicroTrialFreelance.Controllers
{
    [ApiController]
    public class SolutionController : ControllerBase
    {
        private readonly ISolutionService _solutionService;
        private readonly UserManager<DbUser> userManager;
        private readonly IMessageRepository messageRepository;
        private readonly IConnectionMultiplexer redis;

        public SolutionController(
            IMessageRepository messageRepository,
            UserManager<DbUser> userManager,
            ISolutionService solutionService,
            IConnectionMultiplexer redis
        )
        {
            _solutionService = solutionService;
            this.userManager = userManager;
            this.messageRepository = messageRepository;
            this.redis = redis;
        }

        [HttpGet(SolutionsRoutes.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                    var sols = await _solutionService.GetAllAsync();
                    return Ok(sols);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet(SolutionsRoutes.Get)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                    var sol = await _solutionService.FindByIdAsync(id);
                    if (sol == null)
                        return NotFound();
                    return Ok(sol);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(SolutionsRoutes.GetUserSolutions)]
        public async Task<IActionResult> GetUserSolutions(int id)
        {
            if (id == 0)
                return NotFound();
            try
            {
                
                    DbUser user = await userManager.FindByIdAsync(id.ToString());

                    if (user != null)
                    {
                        var solutions = await _solutionService.GetSolutionsByUserIdAsync(user.Id);

                        return Ok(solutions);
                    }
                    return NotFound("user not found");
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(SolutionsRoutes.GetOrderSolutions)]
        public async Task<IActionResult> GetOrderSolutions(int id)
        {
            if (id == 0)
                return NotFound();
            try
            {

                    DbUser user = await userManager.FindByIdAsync(id.ToString());

                    if (user != null)
                    {
                        var solutions = await _solutionService.GetSolutionsByOrderIdAsync(user.Id);
                        return Ok(solutions);
                    }
                    return NotFound("user not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost(SolutionsRoutes.Add)]
        public async Task<IActionResult> Add(Solution model)
        {
            try
            {
                var id = await _solutionService.AddAsync(model);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost(SolutionsRoutes.Update)]
        public async Task<IActionResult> Update(int id, Solution model)
        {
            try
            {
                var newmodel = await _solutionService.UpdateAsync(id,model);


                //var cacheKey = $"{SolutionRoutes.Get}/{id}";
                //var db = redis.GetDatabase();
                //var cachedData = await db.StringGetAsync(cacheKey);

                //if (!cachedData.IsNullOrEmpty)
                //{
                    //await db.StringSetAsync(cacheKey, JsonSerializer.Serialize(newmodel), TimeSpan.FromMinutes(1)); // Set expiration as needed
                //}

                return Ok(newmodel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete(SolutionsRoutes.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _solutionService.DeleteAsync(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
