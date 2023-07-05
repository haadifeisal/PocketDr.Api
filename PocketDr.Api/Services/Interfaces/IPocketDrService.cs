using PocketDr.Api.DataTransferObjects.Configuration;
using PocketDr.Api.Repositories.PocketDr.Models;

namespace PocketDr.Api.Services.Interfaces
{
    public interface IPocketDrService
    {
        Task<List<Chat>> GetChats(Guid userId);
        Task<Chat> GetChat(Guid chatId);
        Task<Message> GetMessage(Guid messageId);
        Task<Message> CreateMessage(Guid chatId, MessageRequestDTO messageRequestDTO);
        Task<Message> CreateChatGptMessage(Guid messageId);
    }
}
