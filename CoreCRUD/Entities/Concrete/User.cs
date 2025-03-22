using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string IdentityName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int SupplierId { get; set; }
        public bool Premium { get; set; }
        public int BackupId { get; set; }
    }
}
