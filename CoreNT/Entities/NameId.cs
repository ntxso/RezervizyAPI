using CoreNT.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreNT.Entities
{
    public class NameId : INameId
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
