using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnBlazor.Server.Data.ServiceInterface;
using LearnBlazor.Shared.DataTransferObject;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearnBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatGroupController : ControllerBase
    {
        private readonly IChatGroupService _chatGroupService;

        public ChatGroupController(IChatGroupService chatGroupService)
        {
            _chatGroupService = chatGroupService;
        }

        // GET: api/<ChatGroupController>
        [HttpGet]
        public async Task<IEnumerable<ChatGroupDTO>> Get()
        {
            return await _chatGroupService.ListChatGroupsAsync();
        }

        // GET api/<ChatGroupController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ChatGroupController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ChatGroupController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ChatGroupController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
