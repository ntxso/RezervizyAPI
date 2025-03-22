using Blazored.LocalStorage;
using WebUI.Models;

namespace WebUI.Services
{
    public class UserControlBase
    {
        public int SupplierId { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public bool IsLoggedIn { get; set; }
        public int CtorCount { get { return countCtorRun; } }
        public bool FirstRun { get; set; } = false;
        private static int countCtorRun = 0;

        private ILocalStorageService _localStorageService;
        private IAuthService _authService;
        public UserControlBase(ILocalStorageService localStorageService, IAuthService authService)
        {
            this._localStorageService = localStorageService;
            _authService = authService;
            IsLoggedIn = false;

            countCtorRun++;
        }

        public async Task<bool> CheckUser()
        {
            FirstRun= true;
            countCtorRun++;
            if (!IsLoggedIn)
            {
                if (await _authService.SetAuthorizationHeader())//kayıt var usercontrol boş
                {
                    SupplierId = await _localStorageService.GetItemAsync<int>("supplierid");
                    Email = await _localStorageService.GetItemAsync<string>("email");
                    Token = await _localStorageService.GetItemAsync<string>("token");
                    return (IsLoggedIn = true);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        
    }
}
