using AutoMapper;
using PocketDr.Api.Repositories.PocketDr.Models;

namespace PocketDr.Api.DataTransferObjects.Configuration
{
    public class MapConfiguration : Profile
    {
        public MapConfiguration()
        {
            CreateMap<Chat, ChatResponseDTO>();
            CreateMap<Message, MessageResponseDTO>();

            CreateMap<MessageRequestDTO, Message>();
        }
    }
}
