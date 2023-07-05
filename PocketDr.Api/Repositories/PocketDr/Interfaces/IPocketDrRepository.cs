using PocketDr.Api.Repositories.PocketDr.Models;

namespace PocketDr.Api.Repositories.PocketDr.Interfaces
{
    public interface IPocketDrRepository
    {
        Task<List<Chat>> GetChats(Guid userId);
        Task<Chat> GetChat(Guid chatId);
        Task<Message> GetMessage(Guid messageId);
        Task<Message> CreateMessage(Guid chatId, string sender, string text);
    }
}
