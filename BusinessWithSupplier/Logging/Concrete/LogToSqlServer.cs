using BusinessWithSupplier.Abstract;
using BusinessWithSupplier.Constants;
using BusinessWithSupplier.Logging.Abstract;
using CoreNT.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessWithSupplier.Logging.Concrete
{
    public class LogToSqlServer : ILog
    {
        /// <summary>
        /// Ctor
        /// </summary>
        private ILoggingServices _loging;
        private int acceptedLogLevel;
        public LogToSqlServer(ILoggingServices logging) 
        {
            _loging = logging;
            acceptedLogLevel = Settings.LOGACCEPTLEVEL;
        }
        

        
        public LogEntity GetFromId(int id)
        {
            return _loging.GetFromId(id);
        }

        public List<LogEntity> GetList(DateTime? dateTime)
        {
            return _loging.GetLogs(dateTime);
        }

        public void Log(LogEntity log)
        {
            if (log.LogLevel >= acceptedLogLevel)
            {
                _loging.Add(log);
            }
        }
        public void SetAcceptedLogLevel(int level)
        {
            acceptedLogLevel = level;
        }
    }
}
