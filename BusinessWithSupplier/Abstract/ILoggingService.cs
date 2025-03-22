using CoreNT.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessWithSupplier.Abstract
{
    public interface ILoggingServices
    {
        List<LogEntity> GetLogs(DateTime? time);
        LogEntity GetFromId(int id);
        void Add(LogEntity log);
        void Update(LogEntity log);
        void Delete(LogEntity log);
        void DeleteHistory(DateTime time);
    }
}
