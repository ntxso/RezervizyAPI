using WebUI.Models;

namespace WebUI.Services
{
    public interface IAddressService
    {
        Task<AddressModel> GetByCustomerId(int customerId);

    }
}
