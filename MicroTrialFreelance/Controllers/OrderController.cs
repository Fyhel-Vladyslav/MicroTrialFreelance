using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using MicroTrialFreelance.Entities;
using MicroTrialFreelance.Models;
using MicroTrialFreelance.Repositories.Interfaces;
using MicroTrialFreelance.Services.Interfaces;
using MicroTrialFreelance.Routes;
using MicroTrialFreelance.Services.Implements;

namespace MicroTrialFreelance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<DbUser> userManager;
        public OrderController(IOrderService orderService, UserManager<DbUser> userManager)
        {
            this.userManager = userManager;
            _orderService = orderService;
        }


        [HttpGet(OrdersRoutes.GetAll)]
        public async Task<IActionResult> GetAll()
        {

            try
            {
                var solutions = await _orderService.GetAllAsync();

                return Ok(solutions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(OrdersRoutes.Get)]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
                return NotFound();
            try
            {
                var solutions = await _orderService.FindByIdAsync(id);

                return Ok(solutions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(OrdersRoutes.GetUserOrders)]
        public async Task<IActionResult> GetUserOrders(int id)
        {
            if (id == 0)
                return NotFound();
            try
            {

                DbUser user = await userManager.FindByIdAsync(id.ToString());

                if (user != null)
                {
                    var solutions = await _orderService.GetOrdersByUserIdAsync(user.Id);

                    return Ok(solutions);
                }
                return NotFound("user not found");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        //[AllowAnonymous]
        //[HttpPost]
        //public IActionResult Search(string request)
        //{
        //    var orders = preOrderRepository.SearchByName(request);
        //    return View("OrdersList", orders);
        //}

        [HttpPost(OrdersRoutes.Add)]
        public async Task<IActionResult> Add(Order model)
        {
            try
            {
                var id = await _orderService.AddAsync(model);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost(SolutionsRoutes.Update)]
        public async Task<IActionResult> Update(int id, Order model)
        {
            try
            {
                var newmodel = await _orderService.UpdateAsync(id, model);

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
                await _orderService.DeleteAsync(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
