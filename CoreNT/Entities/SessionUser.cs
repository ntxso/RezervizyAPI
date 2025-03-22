using CoreNT.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreNT.Entities
{
    public class SessionUser : ISessionUser
    {
        public int UserId { get; set; } = 0;
        public string Name { get; set; } = "default";
        public string IdentityName { get; set; } = "identity";
        public string[] Claims { get; set; } = new string[0];
        public int SupplierId { get; set; } = 1;

        public List<NameId> Terminals { get; set; }
        public bool Premium { get; set; }
        

    }
}
