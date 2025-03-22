using System;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Text;

namespace CoreNT.Entities
{
    public class LogEntity
    {
        public int Id { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
        public string LogText { get; set; }
        public int LogLevel { get; set; }
        public int SupplierId { get; set; }
    }
}
