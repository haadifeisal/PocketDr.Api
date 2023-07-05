namespace PocketDr.Api.Repositories.PocketDr.Models;

public partial class Chat
{
    public Guid ChatId { get; set; }

    public Guid UserId { get; set; }

    public string CreatedAt { get; set; }

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
}
