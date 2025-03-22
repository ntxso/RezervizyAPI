namespace WebUI.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int QuarterId { get; set; }
        public string Address { get; set; }
    }
}
