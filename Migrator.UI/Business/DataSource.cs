using Migrator.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrator.UI.Business
{
    public class DataSource
    {
        private const string DataPath = "data.json";
        public List<Solution> Solutions { get; set; } = new List<Solution>();

        private void ReadData() 
        {
            var isDataExists = File.Exists(DataPath);
            if (!isDataExists)
            {
                CreateData();
                return;
            }

            var dataJson = File.ReadAllText(DataPath);
            Solutions = JsonConvert.DeserializeObject<List<Solution>>(dataJson);
        }

        private void CreateData()
        {
            Solutions = new List<Solution>();
            SaveData();
        }

        public void SaveData()
        {
            var dataJson = JsonConvert.SerializeObject(Solutions);
            File.WriteAllText(DataPath, dataJson);
        }

        public DataSource()
        {
            ReadData();
        }
    }
}
