using Microsoft.VisualBasic;
using WebUI.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Net;

namespace WebUI.Services
{
    public class AuthService : IAuthService
    {
        HttpClient _httpClient;
        ILocalStorageService _localStorageService;
        readonly string _apiUrl;

        public bool IsSuccesLogin { get; set; } = false;
        public bool IsSetLocalStorage { get; set; } = false;
        public bool IsSetAuthHeader { get; set; } = false;
        public AuthService(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
            _httpClient = httpClient;
            _apiUrl = Constants.Constants.ApiUrl;
        }
        public async Task<UserWithToken> Login(LoginModel loginModel)
        {
            var response = await _httpClient.PostAsJsonAsync(_apiUrl + "auth/loginwithuser", loginModel);
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                await Logout();
                return new UserWithToken()
                {
                    Token = "UserOrPassWrong"
                };
            }
            else
            {
                var result = response.Content.ReadFromJsonAsync<UserWithToken>();
                await _localStorageService.SetItemAsync("token", result.Result.Token);
                await _localStorageService.SetItemAsync("supplierid", result.Result.SupplierId);
                await _localStorageService.SetItemAsync("email", result.Result.Email);
                IsSetAuthHeader = await SetAuthorizationHeader();
                IsSuccesLogin = true;
                IsSetLocalStorage = true;
                return result.Result;
            }

        }

        public async Task Logout()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", string.Empty);
  
            await _localStorageService.RemoveItemAsync("token");
            await _localStorageService.RemoveItemAsync("supplierid");
            await _localStorageService.RemoveItemAsync("email");
            IsSuccesLogin = false;
            IsSetAuthHeader= false;
            IsSetLocalStorage = false;
        }

        public async Task<bool> SetAuthorizationHeader()
        {
            if (!_httpClient.DefaultRequestHeaders.Contains("Authorization"))
            {
                var token = await _localStorageService.GetItemAsync<string>("token");
                if (string.IsNullOrEmpty(token))
                {
                    return false;
                }
                else
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    return true;
                }
            }
            return true;
        }
    }
}
