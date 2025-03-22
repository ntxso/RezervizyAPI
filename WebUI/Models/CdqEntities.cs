using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class District : INameId
    {
        public int Id { get; set; }
        public int CityID { get; set; }
        public string Name { get; set; }
    }

    public class Quarter : INameId
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string Name { get; set; }
    }

    public class City : INameId
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
