using BusinessWithSupplier.Abstract;
using CleaningEntities;
using DACleaning.Concrete.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessWithSupplier.Concrete
{
    public class CdqManager : ICdqService
    {
        public List<City> GetCities()
        {
            using (var context = new NtxsoContext())
            {
                return context.Cities.ToList();
            }
        }

        public List<District> GetDistricts(int cityId)
        {
            using (var context = new NtxsoContext())
            {
                return context.Districts.Where(dd => dd.CityId == cityId).ToList();
            }
        }
        public List<District> GetDistricts(IEnumerable<int> distIdList)
        {
            using (var context = new NtxsoContext())
            {
                return (from dist in context.Districts.ToList()
                        join distId in distIdList
                        on dist.Id equals distId
                        select dist).ToList();
            }
        }
        public List<Quarter> GetQuarters(int districtId)
        {
            using (var context = new NtxsoContext())
            {
                return context.Quarters.Where(dd => dd.DistrictId == districtId).OrderBy(p => p.Name).ToList();
            }
        }

        public string GetCityName(int cityId)
        {
            if (cityId == 0) return "İl İsmi Yok";
            return GetCities().Where(p => p.Id == cityId).SingleOrDefault().Name;
        }

        public string GetDistrictName(int districtId)
        {
            if (districtId == 0) return "İlçe İsmi Yok";
            using (var context = new NtxsoContext())
            {
                try
                {
                    return context.Districts.Where(dd => dd.Id == districtId).SingleOrDefault().Name;

                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        public string GetQuarterName(int quarterId)
        {
            if (quarterId == 0) return "Mahalle İsmi Yok";
            using (var context = new NtxsoContext())
            {
                try
                {
                    return context.Quarters.Where(dd => dd.Id == quarterId).SingleOrDefault().Name;
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        public string GetFullAddress(CustomerDto address)
        {
            if (address.QuarterId != 0)
            {
                return string.Format("{0} {1} {2} {3}",
                address.Address,
                GetQuarterName(address.QuarterId),
                GetDistrictName(address.DistrictId),
                GetCityName(address.CityId));
            }
            else
            {
                return address.Address;
            }
        }
        public string GetFullAddress(AddressCustomer address)
        {
            if (address.QuarterId != 0)
            {
                return string.Format("{0} {1} {2} {3}",
                address.Address,
                GetQuarterName(address.QuarterId),
                GetDistrictName(address.DistrictId),
                GetCityName(address.CityId));
            }
            else
            {
                return address.Address;
            }
        }

        public void AddDistrict(District district)
        {
            using (var context = new NtxsoContext())
            {
                context.Districts.Add(district);
                context.SaveChanges();
            }
        }

        public void AddQuarter(Quarter quarter)
        {
            using (var context = new NtxsoContext())
            {
                context.Quarters.Add(quarter);
                context.SaveChanges();
            }
        }

        public Quarter GetQuarter(int quarterId)
        {
            using (var context = new NtxsoContext())
            {
                return context.Quarters.Where(p => p.Id == quarterId).SingleOrDefault();
            }
        }

        //private City[] cities = {
        //    new City{Id=0,CityName="Şehir İsmi Yok"},
        //    new City { Id = 34, CityName = "İSTANBUL" },
        //    new City{Id=35,CityName="İZMİR"}
        //};
    }
}
