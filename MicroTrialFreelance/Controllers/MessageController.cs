using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using MicroTrialFreelance.Entities;

using MicroTrialFreelance.Models;
using MicroTrialFreelance.Repositories.Implements;
using MicroTrialFreelance.Repositories.Interfaces;
using MicroTrialFreelance.Services.Interfaces;
using MicroTrialFreelance.Routes;
using MicroTrialFreelance.Services.Implements;

namespace MicroTrialFreelance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly UserManager<DbUser> _userManager;
        public MessageController(IMessageService messageService, UserManager<DbUser> userManager)
        {
            _userManager = userManager;
            _messageService = messageService;
        }
        [HttpGet(MessagesRoutes.GetUserMessages)]
        public async Task<IActionResult> UserMessages(int id = -1)
        {
            DbUser user;
            if (id == -1)
                user = await _userManager.GetUserAsync(User);
            else
                user = await _userManager.FindByIdAsync(id.ToString());

            if (user != null)
            {
                var messages = _messageService.GetMessagesByUserIdAsync(user.Id);
                return Ok(messages);
            }
            return NotFound();
        }


        [HttpPost(MessagesRoutes.Add)]
        public async Task<IActionResult> Add(Message model)
        {
            try
            {
                var id = await _messageService.AddAsync(model);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost(MessagesRoutes.SetMessageRead)]
        public async Task<IActionResult> SetMessageReadAsync([FromBody] SetMessageReadModel model)
        {
            System.Collections.Generic.List<int> list = new System.Collections.Generic.List<int>();
            if (model.SetAllRead)// if setAllRead==1 then in id we sent id of user
            {
                var userMessages = await _messageService.GetMessagesByUserIdAsync(model.id);
                if (userMessages != null)
                {
                    foreach (var message in userMessages)
                    {
                        list.Add(message.Id);
                    }
                }
            }
            else// if setAllRead==0 then in id we sent id of message
                list.Add(model.id);

            try
            {
                await _messageService.SetMessagesReadAsync(list);
                return Ok();
            }catch (Exception ex) {
                return NotFound(ex);

            }
        }
          [HttpPost(SolutionsRoutes.Update)]
        public async Task<IActionResult> Update(int id, Message model)
        {
            try
            {
                var newmodel = await _messageService.UpdateAsync(id, model);

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
                await _messageService.DeleteAsync(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        public class SetMessageReadModel
        {
            public int id { get; set; }
            public bool SetAllRead { get; set; }
        }
    }
}