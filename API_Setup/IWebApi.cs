namespace SecretClientTasksBackend.API_Setup
{
    public interface IWebApi
    {
        void Register(WebApplication app);
    }

    public interface IWebApiAsync
    {
        Task RegisterAsync(WebApplication app);
    }
}
