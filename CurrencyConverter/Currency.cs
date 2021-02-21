using CurrencyConverter.CustomExceptions;
using CurrencyConverter.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class Currency
    {
        public string BaseCurrency { get; private set; }
        private CurrencyModel _currencyModel;

        public Currency(string link = "https://www.cbr-xml-daily.ru/daily_json.js")
        {
            OpenJsonLink(link);
        }


        public void SetBaseCurrency(string baseCurrency, string nameBaseCurrency)
        {
            BaseCurrency = baseCurrency;
            var valute = new Valute()
            {
                CharCode = BaseCurrency,
                ID = "R00000",
                Name = nameBaseCurrency,
                Nominal = 1,
                NumCode = 0,
                Previous = 1,
                Value = 1
            };
            _currencyModel.Valute.Add(BaseCurrency, valute);
        }

        public List<string> GetCurrencyList()
        {
            List<string> list = new List<string>();
            foreach (var item in _currencyModel.Valute.Keys)
            {
                list.Add($"{_currencyModel.Valute.GetValueOrDefault(item).Name} ({_currencyModel.Valute.GetValueOrDefault(item).CharCode})");
            }
            return list;
        }

        public int GetNominal(string currencyCode)
        {
            return _currencyModel.Valute.GetValueOrDefault(currencyCode).Nominal;
        }

        public float GetRate(string currencyCode)
        {
            return _currencyModel.Valute.GetValueOrDefault(currencyCode).Value;
        }

        public void OpenJsonFile(string directory = "daily_json.js")
        {
            if (File.Exists(directory))
                _currencyModel = JsonConvert.DeserializeObject<CurrencyModel>(File.ReadAllText(directory));
            else throw new FileJsonNotFound();
        }

        public void OpenJsonLink(string link)
        {
            string jsonFromLink = new WebClient().DownloadString(link);
            _currencyModel = JsonConvert.DeserializeObject<CurrencyModel>(jsonFromLink);
        }

        public string SaveToJsonFile(CurrencyModel currencyModel, string path)
        {
            string saveMessage;
            //try
            //{
            //    using (FileStream fs = File.Create(path))
            //    {
            //        byte[] info = new UTF8Encoding(true).GetBytes("Текст одинаковый");
            //        fs.Write(info, 0, info.Length);
            //    }
            //}
            //catch (Exception exception)
            //{
            //    return exception.Message;
            //}

            //FileStream fs = new FileStream(path, FileMode.Create);

            //File.Create(path);
            File.WriteAllText("daily_json.js", JsonConvert.SerializeObject(_currencyModel));

            saveMessage = "successfully";
            return saveMessage;
        }


    }
}
