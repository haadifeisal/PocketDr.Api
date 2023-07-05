using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PocketDr.Api.DataTransferObjects;
using PocketDr.Api.DataTransferObjects.Configuration;
using PocketDr.Api.Repositories.ChatGPT.Interfaces;
using PocketDr.Api.Repositories.PocketDr.Models;
using PocketDr.Api.Services.Interfaces;
using System;

namespace PocketDr.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PocketDrController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IChatGPTRepository _chatGPTRepository;
        private readonly IPocketDrService _pocketDrService;

        public PocketDrController(IMapper mapper, IChatGPTRepository chatGPTRepository, IPocketDrService pocketDrService)
        {
            _mapper = mapper;
            _chatGPTRepository = chatGPTRepository;
            _pocketDrService = pocketDrService;
        }

        [HttpGet]
        public async Task<IActionResult> GetChats()
        {
            var userId = Guid.Parse("d195ece6-e293-11ed-b5ea-0242ac120002");
            var chats = await _pocketDrService.GetChats(userId);

            if (!chats.Any())
            {
                return NoContent();
            }

            if(chats == null)
            {
                return NotFound();
            }

            var mappedResult = _mapper.Map<List<ChatResponseDTO>>(chats);

            return Ok(mappedResult);
        }

        [HttpGet("{chatId}")]
        public async Task<IActionResult> GetChat([FromRoute] Guid chatId)
        {
            var chat = await _pocketDrService.GetChat(chatId);

            if (chat == null)
            {
                return NotFound();
            }

            var mappedResult = _mapper.Map<ChatResponseDTO>(chat);

            return Ok(mappedResult);
        }

        [HttpGet("message/{messageId}")]
        public async Task<IActionResult> GetMessage([FromRoute] Guid messageId)
        {
            var message = await _pocketDrService.GetMessage(messageId);

            if (message == null)
            {
                return NotFound();
            }

            var mappedResult = _mapper.Map<MessageResponseDTO>(message);

            return Ok(mappedResult);
        }

        [HttpPost("{chatId}")]
        public async Task<IActionResult> CreateMessage([FromRoute] Guid chatId, [FromBody] MessageRequestDTO messageRequestDTO)
        {
            var message = await _pocketDrService.CreateMessage(chatId, messageRequestDTO);

            if (message == null)
            {
                return BadRequest();
            }

            return Ok(message);
        }

        [HttpPost("chatgpt/{messageId}")]
        public async Task<IActionResult> CreateMessage([FromRoute] Guid messageId)
        {
            var message = await _pocketDrService.CreateChatGptMessage(messageId);

            if (message == null)
            {
                return BadRequest();
            }

            return Ok(message);
        }
    }
}
