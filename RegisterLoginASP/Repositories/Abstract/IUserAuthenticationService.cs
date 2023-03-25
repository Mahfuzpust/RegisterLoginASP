using RegisterLoginASP.Models.DTO;

namespace RegisterLoginASP.Repositories.Abstract
{
    public interface IUserAuthenticationService
    {
        Task<Status> LoginAsync(LoginModel model);
        Task<Status> LogoutAsync();
        Task<Status> RegistrationAsync(RegistrationModel model);

    }
}
