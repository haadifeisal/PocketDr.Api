﻿using Microsoft.AspNetCore.Mvc;
using PockerDr.Api.Repositories.ChatGPT.Interfaces;

namespace PockerDr.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PocketDrController : ControllerBase
    {
        private readonly IChatGPTRepository _chatGPTRepository;
        public PocketDrController(IChatGPTRepository chatGPTRepository)
        {
            _chatGPTRepository = chatGPTRepository;
        }

        [HttpPost]
        public async Task<IActionResult> GetDepartments([FromBody] string input)
        {
            var output = await _chatGPTRepository.ChatGPT(input);

            return Ok(output);
        }
    }
}
