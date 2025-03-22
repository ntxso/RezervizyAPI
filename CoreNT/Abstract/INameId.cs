using System;
using System.Collections.Generic;
using System.Text;

namespace CoreNT.Abstract
{
    public interface INameId
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
