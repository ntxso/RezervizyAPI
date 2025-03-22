using CoreNT.Entities;
using CoreNT.Utilities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CoreNT.Initialize
{
    public class InitializeTables
    {
        private string[] tables;
        private List<string> resultStrList;
        private SqlBase sqlBase;
        public InitializeTables()
        {
            var buildDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = buildDir + @"\Tables.txt";
            string result = File.ReadAllText(filePath);
            tables = result.Split(";");

            StringValue sqlConn = new StringValue(ConfigTest.CurrentConnection);
            sqlBase = new SqlBase(sqlConn);
            resultStrList = new List<string>();
        }

        public void Initialize()
        {
            foreach (var createTable in tables)
            {
                var result = sqlBase.QueryExecute(createTable);
                if (result.Success)
                {
                    resultStrList.Add("Başarılı: " + result.Message);
                }
                else
                {
                    resultStrList.Add("Hata: " + result.Message);
                }
                break;
            }
        }

        public string GetToken()
        {
            var buildDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = buildDir + @"\Token.txt";
            try
            {
                return File.ReadAllText(filePath);
            }
            catch
            {
                return string.Empty;
            }
        }
        public void SetToken(string token)
        {
            var buildDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = buildDir + @"\Token.txt";
            File.WriteAllText(filePath, token);
        }

        public string[] Tables { get { return tables; } }
        public string[] InfoList { get { return resultStrList.ToArray(); } }
    }
}
