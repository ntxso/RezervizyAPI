using System;
using System.Collections.Generic;
using System.Text;

namespace CoreNT.Abstract
{
    public interface ISessionUser
    {
        int UserId { get; set; }
        string Name { get; set; }
        string IdentityName { get; set; }
        string[] Claims { get; set; }
        int SupplierId { get; set; }
    }
}
