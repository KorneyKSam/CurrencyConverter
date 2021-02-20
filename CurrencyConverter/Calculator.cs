using CurrencyConverter.CustomExceptions;
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
    public class Calculator
    {
        private CurrencyModel _currencyModel;
        public string BaseCurrency { get; private set; }
        public double FirstValue { get; private set; }
        public double SecondValue { get; private set; }
        public string FirstCurrency { get; private set; }
        public string SecondCurrency { get; private set; }



        public Calculator(CurrencyModel currencyModel, string baseCurrency, string firstCurrency = "RU", string secondCurrency = "USD")
        {
            _currencyModel = currencyModel;
            BaseCurrency = baseCurrency;
            FirstCurrency = firstCurrency;
            SecondCurrency = secondCurrency;
        }


        public string CalculateFirstCurrency(string firstCurrency)
        {
            FirstCurrency = firstCurrency;
            double firstRate = _currencyModel.Valute.GetValueOrDefault(FirstCurrency).Value;
            double secondRate = _currencyModel.Valute.GetValueOrDefault(SecondCurrency).Value;
            double firstMultiplicity = _currencyModel.Valute.GetValueOrDefault(FirstCurrency).Nominal;
            double secondMultiplicity = _currencyModel.Valute.GetValueOrDefault(SecondCurrency).Nominal;
            SecondValue = (FirstValue * firstMultiplicity * secondRate) / (secondMultiplicity * firstRate);
            //throw new CurrencyNotFound();
            return Convert.ToString(SecondValue);
        }

        public string CalculateSecondCurrency(string secondCurrency)
        {
            SecondCurrency = secondCurrency;
            double firstRate = _currencyModel.Valute.GetValueOrDefault(FirstCurrency).Value;
            double secondRate = _currencyModel.Valute.GetValueOrDefault(SecondCurrency).Value;
            double firstMultiplicity = _currencyModel.Valute.GetValueOrDefault(FirstCurrency).Nominal;
            double secondMultiplicity = _currencyModel.Valute.GetValueOrDefault(SecondCurrency).Nominal;
            FirstValue = (SecondValue * secondMultiplicity * firstRate) / (firstMultiplicity * secondRate);
            return Convert.ToString(FirstValue);
        }

        public string CalculateFirstValue(float firstValue)
        {
            FirstValue = firstValue;
            double firstRate = _currencyModel.Valute.GetValueOrDefault(FirstCurrency).Value;
            double secondRate = _currencyModel.Valute.GetValueOrDefault(SecondCurrency).Value;
            double firstMultiplicity = _currencyModel.Valute.GetValueOrDefault(FirstCurrency).Nominal;
            double secondMultiplicity = _currencyModel.Valute.GetValueOrDefault(SecondCurrency).Nominal;
            SecondValue = (FirstValue * firstMultiplicity * secondRate) / (secondMultiplicity * firstRate);
            return Convert.ToString(SecondValue);
        }

        public string CalculateSecondValue(float secondValue)
        {
            SecondValue = secondValue;
            double firstRate = _currencyModel.Valute.GetValueOrDefault(FirstCurrency).Value;
            double secondRate = _currencyModel.Valute.GetValueOrDefault(SecondCurrency).Value;
            double firstMultiplicity = _currencyModel.Valute.GetValueOrDefault(FirstCurrency).Nominal;
            double secondMultiplicity = _currencyModel.Valute.GetValueOrDefault(SecondCurrency).Nominal;
            FirstValue = (SecondValue * secondMultiplicity * firstRate) / (firstMultiplicity * secondRate);
            return Convert.ToString(FirstValue);
        }


    }
}
