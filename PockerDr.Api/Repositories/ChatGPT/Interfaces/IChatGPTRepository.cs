namespace PockerDr.Api.Repositories.ChatGPT.Interfaces
{
    public interface IChatGPTRepository
    {
        Task<string> ChatGPT(string input);
    }
}
