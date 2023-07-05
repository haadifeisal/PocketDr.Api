using Microsoft.EntityFrameworkCore;
using PocketDr.Api.DataTransferObjects.Configuration;
using PocketDr.Api.Repositories.PocketDr.Interfaces;
using PocketDr.Api.Repositories.PocketDr.Models;

namespace PocketDr.Api.Repositories.PocketDr
{
    public class PocketDrRepository : IPocketDrRepository
    {
        private readonly PocketDrContext _pocketDrContext;

        public PocketDrRepository(PocketDrContext pocketDrContext)
        {
            _pocketDrContext = pocketDrContext;
        }

        public async Task<List<Chat>> GetChats(Guid userId)
        {
            var chats = await _pocketDrContext.Chats.AsNoTracking().Include(x => x.Messages)
                .Where(x => x.UserId == userId).OrderBy(x => x.CreatedAt).ToListAsync();

            return chats;
        }

        public async Task<Chat> GetChat(Guid chatId)
        {
            var chat = await _pocketDrContext.Chats.AsNoTracking().Include(x => x.Messages)
                .OrderBy(x => x.CreatedAt).FirstOrDefaultAsync(x => x.ChatId == chatId);

            return chat;
        }

        public async Task<Message> GetMessage(Guid messageId)
        {
            var message = await _pocketDrContext.Messages.AsNoTracking().FirstOrDefaultAsync(x => x.MessageId == messageId);

            return message;
        }

        public async Task<Message> CreateMessage(Guid chatId, string sender, string text)
        {
            var message = new Message
            {
                MessageId = Guid.NewGuid(),
                ChatId = chatId,
                Sender = sender,
                Text = text,
                CreatedAt = DateTime.Now.ToString("yyyyMMddHHmmssffff")
            };

            await _pocketDrContext.Messages.AddAsync(message);

            if(await _pocketDrContext.SaveChangesAsync() == 1)
            {
                return await GetMessage(message.MessageId);
            }

            return null;
        }

    }
}
