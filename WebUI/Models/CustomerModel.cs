using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public int BackupId { get; set; }
    }

    public class CustomerDtoModel
    {
        public int CustomerId { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int QuarterId { get; set; }
        public string Address { get; set; }
    }

    public class CustomerNoteViewModel
    {
        public int NoteId { get; set; }
        public int CustomerId { get; set; }
        public string Note { get; set; }
    }
}
