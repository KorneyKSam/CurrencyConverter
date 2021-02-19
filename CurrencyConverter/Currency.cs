using CurrencyConverter.CustomExceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class Currency
    {
        private Rootobject _rootobject;

        public void OpenJsonFile(string directory = "daily_json.js")
        {
            if (File.Exists(directory))
                _rootobject = JsonConvert.DeserializeObject<Rootobject>(File.ReadAllText("daily_json.js"));
            else throw new FileJsonNotFound();
        }

        public string SaveJsonFile(string directory, string fileName)
        {
            string saveMessage;

            if (File.Exists(directory + fileName))
            {

            }
            else
            {
                File.Create(fileName);
            }
            File.WriteAllText("daily_json.js", JsonConvert.SerializeObject(directory));
            saveMessage = "successfully";
            return saveMessage;
        }

    }
}
