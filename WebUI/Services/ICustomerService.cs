using WebUI.Models;
using System.Threading.Tasks;

namespace WebUI.Services
{
    public interface ICustomerService
    {
        Task<CustomerModel[]> GetCustomers(int supplierId);
        Task<CustomerModel[]> GetCustomersByName(string name);
        Task<CustomerModel[]> GetCustomersByPhone(string phone);
        Task<CustomerDtoModel[]> GetCustomersDto(int supplierId);

    }
}
