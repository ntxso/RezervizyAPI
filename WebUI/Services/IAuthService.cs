using WebUI.Models;
using System.Threading.Tasks;

namespace WebUI.Services
{
    public interface IAuthService
    {
        Task<UserWithToken> Login(LoginModel loginViewModel);
        Task Logout();
        bool IsSuccesLogin { get; }
        Task<bool> SetAuthorizationHeader();
    }
}
