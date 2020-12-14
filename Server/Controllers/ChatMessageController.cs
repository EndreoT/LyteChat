using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnBlazor.Server.Data.ServiceInterface;
using LearnBlazor.Shared.Communication;
using LearnBlazor.Shared.DataTransferObject;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearnBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatMessageController : ControllerBase
    {
        private readonly IChatMessageService _chatMessageService;
        public ChatMessageController(IChatMessageService chatMessageService)
        {
            _chatMessageService = chatMessageService;
        }

        // GET: api/<ChatMessageController>/66f6cf51-4054-4440-9ebd-135ee0d5f73c
        [HttpGet("{groupUuid}")]
        public async Task<IEnumerable<ChatMessageDTO>> ListMessagesForGroupAsync(string groupUuid)
        {
            IEnumerable<ChatMessageDTO> messages;
            bool parseSuccess = Guid.TryParse(groupUuid, out Guid guid);
            if (parseSuccess)
            {
                messages = await _chatMessageService.ListMessagesForGroupAsync(guid);
            }
            else
            {
                messages = Array.Empty<ChatMessageDTO>();
            }
            return messages;
        }


        // POST api/<ChatMessageController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ChatMessageController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ChatMessageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
