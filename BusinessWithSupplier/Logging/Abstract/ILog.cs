using CoreNT.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessWithSupplier.Logging.Abstract
{
    public interface ILog
    {
        void Log(LogEntity log);
        LogEntity GetFromId(int id);
        List<LogEntity> GetList(DateTime? dateTime);
        void SetAcceptedLogLevel(int Level);
    }
}
