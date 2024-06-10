using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MicroTrialFreelance.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MicroTrialFreelance.Routes;
using Microsoft.EntityFrameworkCore;
using MicroTrialFreelance.Models;

namespace MicroTrialFreelance.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<DbUser> _userManager;
        private readonly SignInManager<DbUser> signInManager;
        private readonly RoleManager<DbRole> roleManager;

        public AccountController(UserManager<DbUser> userManager, SignInManager<DbUser> signInManager,
            RoleManager<DbRole> roleManager)
        {
            this._userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        [HttpPost(AccountsRoutes.Add)]
        public async Task<IActionResult> Add(DbUser model)
        { 
            try
            {

                var result = await _userManager.CreateAsync(model);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(model, "User");
                    await signInManager.SignInAsync(model, false);
                    return Ok(model);
                }
                return StatusCode(500, result.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        //[HttpGet(AccountsRoutes.Login)]
        //public async Task<IActionResult> Login(string userName, string password)
        //{
        //    try
        //    {
        //        DbUser? model = await _userManager.FindByNameAsync(userName);
        //        if (model == null)
        //            return NotFound();
        //        var result = await _userManager.CreateAsync(model);
        //        if (result.Succeeded)
        //        {
        //            await _userManager.AddToRoleAsync(model, "User");
        //            await signInManager.SignInAsync(model, false);
        //            return Ok(model);
        //        }
        //        return StatusCode(500, result.Errors);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }

        //}

        [HttpGet(AccountsRoutes.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var sols = await _userManager.Users.ToListAsync();
                return Ok(sols);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet(AccountsRoutes.Logout)]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await signInManager.SignOutAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(AccountsRoutes.Get)]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
                return NotFound();
            try
            {
                var sol = await _userManager.FindByIdAsync(id.ToString());
                if (sol == null)
                    return NotFound();
                return Ok(sol);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost(AccountsRoutes.Update)]
        public async Task<IActionResult> Update(int id, DbUser model)
        {
            try
            {
                if (await _userManager.Users.AnyAsync(p => p.Id == id))
                {
                    return NotFound();
                }
                model.Id = id;
                var result = await _userManager.UpdateAsync(model);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete(AccountsRoutes.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                DbUser? user = await _userManager.FindByIdAsync(id.ToString());
                if (user == null) return NotFound();
                await _userManager.DeleteAsync(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
