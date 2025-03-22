using CleaningEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessWithSupplier.Abstract
{
    public interface ICdqService
    {
        List<City> GetCities();
        List<District> GetDistricts(int cityId);
        List<District> GetDistricts(IEnumerable<int> DistIdList);
        List<Quarter> GetQuarters(int districtId);
        string GetCityName(int cityId);
        string GetDistrictName(int districtId);
        string GetQuarterName(int quarterId);
        string GetFullAddress(CustomerDto address);
        string GetFullAddress(AddressCustomer address);

        void AddDistrict(District district);
        void AddQuarter(Quarter quarter);
        Quarter GetQuarter(int quarterId);
    }
}
