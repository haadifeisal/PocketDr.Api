namespace PocketDr.Api.DataTransferObjects
{
    public class ChatResponseDTO
    {
        public Guid ChatId { get; set; }

        public Guid UserId { get; set; }

        public string CreatedAt { get; set; }

        public List<MessageResponseDTO> Messages { get; set; }
    }
}
