using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

namespace TestFramework.OpenCart
{
    public class ApiView
    {
        public string Host { get; set; }
        public string File { get; set; }
        public string Key { get; set; }
        public string Username{ get; set; }

    }
    public class UserView
    {
        public string FName { get; set; }
        public string SName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public bool Subscribe { get; set; }

    }
    class Reader
    {
        private readonly string FULL_PATH_TO_FILE;
        
        public Reader(string path)
        {
            FULL_PATH_TO_FILE = path;
        }
        public List<UserView> ReadUsers()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using (var reader = new StreamReader(FULL_PATH_TO_FILE))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<UserView>();
                return records.ToList();
            }
        }
        public List<ApiView> ReadApis()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using (var reader = new StreamReader(FULL_PATH_TO_FILE))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<ApiView>();
                return records.ToList();
            }
        }
    }
}
