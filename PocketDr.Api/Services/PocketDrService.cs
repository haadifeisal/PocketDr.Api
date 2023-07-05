using PocketDr.Api.DataTransferObjects.Configuration;
using PocketDr.Api.Repositories.ChatGPT.Interfaces;
using PocketDr.Api.Repositories.PocketDr.Interfaces;
using PocketDr.Api.Repositories.PocketDr.Models;
using PocketDr.Api.Services.Interfaces;

namespace PocketDr.Api.Services
{
    public class PocketDrService : IPocketDrService
    {
        private readonly IPocketDrRepository _pocketDrRepository;
        private readonly IChatGPTRepository _chatGPTRepository;

        public PocketDrService(IPocketDrRepository pocketDrRepository, IChatGPTRepository chatGPTRepository)
        {
            _pocketDrRepository = pocketDrRepository;
            _chatGPTRepository = chatGPTRepository;
        }

        public async Task<List<Chat>> GetChats(Guid userId)
        {
            var chats = await _pocketDrRepository.GetChats(userId);

            return chats;
        }

        public async Task<Chat> GetChat(Guid chatId)
        {
            var chat = await _pocketDrRepository.GetChat(chatId);

            return chat;
        }

        public async Task<Message> GetMessage(Guid messageId)
        {
            var message = await _pocketDrRepository.GetMessage(messageId);

            return message;
        }

        public async Task<Message> CreateMessage(Guid chatId, MessageRequestDTO messageRequestDTO)
        {
            var message = await _pocketDrRepository.CreateMessage(chatId, messageRequestDTO.Sender, messageRequestDTO.Text);

            return message;
        }

        public async Task<Message> CreateChatGptMessage(Guid messageId)
        {
            var message = await GetMessage(messageId);

            string chatGptResponse = await _chatGPTRepository.ChatGPT(message.Text);

            var createdMessage = await _pocketDrRepository.CreateMessage(message.ChatId, "chatgpt", chatGptResponse);

            return createdMessage;
        }

    }
}
