using WebUI.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Net;
using Blazored.LocalStorage;
using System.Xml.Linq;

namespace WebUI.Services
{
    public class CustomerService : ICustomerService
    {
        private HttpClient _httpClient;
        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        public async Task<CustomerModel[]> GetCustomers(int supplierId)
        {
            //return await _httpClient.GetFromJsonAsync<CustomerModel[]>(Constants.Constants.ApiUrl+"customer/getall");
            var result = await _httpClient.GetFromJsonAsync<CustomerModel[]>(Constants.Constants.ApiUrl + "customer/getall?supplierid=" + supplierId);
            return result;
        }

        public async Task<CustomerDtoModel[]> GetCustomersDto(int supplierId)
        {
            //return await _httpClient.GetFromJsonAsync<CustomerModel[]>(Constants.Constants.ApiUrl+"customer/getall");
            var result = await _httpClient.GetFromJsonAsync<CustomerDtoModel[]>(Constants.Constants.ApiUrl + "customer/getlistdto?supplierid=" + supplierId);
            return result;
        }

        public async Task<CustomerModel[]> GetCustomersByName(string name)
        {
            return await _httpClient.GetFromJsonAsync<CustomerModel[]>(Constants.Constants.ApiUrl + "customer/getbyname?name=" + name);
        }

        public async Task<CustomerModel[]> GetCustomersByPhone(string phone)
        {
            return await _httpClient.GetFromJsonAsync<CustomerModel[]>(Constants.Constants.ApiUrl + "customer/getbyname?name=" + phone);
        }
        public async Task<bool> UpdateCustomer(CustomerModel customer)
        {
            var result = await _httpClient.PostAsJsonAsync<CustomerModel>(Constants.Constants.ApiUrl+"customer/update", customer);
            var response = result.StatusCode;
            return true;
        }
    }
}
