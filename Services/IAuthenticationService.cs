namespace Ingenium.Materiaalbeheer.ClientApp.Services
{
    public interface IAuthenticationService
    {
        Task<string> GetToken();
    }
}
