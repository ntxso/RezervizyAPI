using BusinessWithSupplier.Abstract;
using CoreNT.Entities;
using CoreNT.Utilities;
using DACleaning.Concrete.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessWithSupplier.Concrete
{
    public class LoggingBusiness : ILoggingServices
    {
        public void Add(LogEntity log)
        {
            try
            {
                string str = ConfigTest.CurrentConnection;
                string sttr = StaticVariables.CurrentConnection;
                if (log.LogText.Length > 254)
                {
                    log.LogText = log.LogText.Substring(0, 254);
                }
                using (var context = new NtxsoContext())
                {
                    context.LogCleaning.Add(log);
                    context.SaveChanges();
                }
            }
            catch
            {


            }

        }

        public void Delete(LogEntity log)
        {
            using (var context = new NtxsoContext())
            {
                context.LogCleaning.Remove(log);
                context.SaveChanges();
            }
        }

        public void DeleteHistory(DateTime time)
        {
            using (var context = new NtxsoContext())
            {
                var result = context.LogCleaning.Where(p => p.Time < time);
                context.LogCleaning.RemoveRange(result);
                context.SaveChanges();
            }
        }

        public LogEntity GetFromId(int id)
        {
            using (var context = new NtxsoContext())
            {
                return context.LogCleaning.Where(p => p.Id == id).SingleOrDefault();
            }
        }

        public List<LogEntity> GetLogs(DateTime? time)
        {
            using (var context = new NtxsoContext())
            {
                if (time == null)
                {
                    return context.LogCleaning.ToList();
                }
                else
                {
                    return context.LogCleaning.Where(p => p.Time >= time).ToList();
                }
            }
        }

        public void Update(LogEntity log)
        {
            using (var context = new NtxsoContext())
            {
                context.LogCleaning.Update(log);
                context.SaveChanges();
            }
        }
    }
}
