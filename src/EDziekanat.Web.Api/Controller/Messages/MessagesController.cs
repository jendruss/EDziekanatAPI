using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDziekanat.Application.Messages;
using EDziekanat.Application.Messages.Dto;

namespace EDziekanat.Web.Api.Controller.Messages
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }



        [HttpGet]
        public IActionResult GetConversation(Guid userId, Guid deansOfficeId)
        {
            var messages = _messageService.GetAllMessagesForThisConversation(userId,deansOfficeId);

            if (messages == null)
            {
                return NotFound();
            }

            return Ok(messages);
        }

        [HttpPost]
        public IActionResult SendMessage([FromBody] MessageDto messageDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Errors = "Model is invalid" });
            }

            try
            {
                _messageService.AddMessage(messageDto);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok();
        }
    }
}
