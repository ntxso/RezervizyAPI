using System;
using System.Collections.Generic;
using System.Text;

namespace CoreNT.Utilities
{
    public class StaticVariables
    {
        public static string ApiUrlRoot = "https://inci42koltukyikama.com";

        static string localStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ntxsoChiaPcIst;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static string turhostStr = "server=mssql07.turhost.com; initial catalog=ntxs6308_ntxsocom; User ID=ntxso; Password=138181.Nt";
        static string ozkula35 = "server=.\\MSSQLSERVER2019; initial catalog=ntx2504m; User ID=ntxso; Password=3~20trgS";
        static string ozkula42 = "server=.\\MSSQLSERVER2019; initial catalog=inci42vt; User ID=adaminqx; Password=138181.Nt";

        public static string CurrentConnection
        {
            get
            {
                return localStr;
            }
        }


        public static TimeSpan[] TSList = new TimeSpan[]
        {
            TimeSpan.FromMinutes(5)     ,//0
                TimeSpan.FromMinutes(10)    ,
                TimeSpan.FromMinutes(15)    ,
                TimeSpan.FromMinutes(30)    ,
                TimeSpan.FromMinutes(60)    ,
                TimeSpan.FromHours(2)       ,
                TimeSpan.FromHours(4)       ,//6
                TimeSpan.FromHours(8)       ,
                TimeSpan.FromHours(12)      ,
                TimeSpan.FromHours(24)      ,//9
                TimeSpan.FromDays(3)        ,
                TimeSpan.FromDays(7)        ,
                TimeSpan.FromDays(30)       ,
                TimeSpan.FromDays(60)       ,
                TimeSpan.FromDays(90)       ,//14
        };

    }

    public enum TSTypeEnum
    {
        _5m,//0
        _10m,
        _15m,
        _30m,
        _1h,
        _2h,
        _4h,//6
        _8h,
        _12h,
        _1d,//9
        _3d,
        _7d,
        _30d,
        _60d,
        _90d,//14
        Undefined
    }
}
