using CurrencyConverter.CustomExceptions;
using CurrencyConverter.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
        private double _firstRate;
        private double _secondRate;
        private double _firstMultiplicity;
        private double _secondMultiplicity;

        public Calculator(CurrencyModel currencyModel)
        {
            _currencyModel = currencyModel;
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

        public string Calculate(string firstCurrency, string secondCurrency, double firstValue, double secondValue)
        {
            double value = 0;
            try
            {
                double secondRate = _currencyModel.Valute.GetValueOrDefault(firstCurrency).Value;
                double secondMultiplicity = _currencyModel.Valute.GetValueOrDefault(firstCurrency).Nominal;
                double firstRate = _currencyModel.Valute.GetValueOrDefault(secondCurrency).Value;
                double firstMultiplicity = _currencyModel.Valute.GetValueOrDefault(secondCurrency).Nominal;



                value = (firstValue * firstMultiplicity * secondRate) / (secondMultiplicity * firstRate);
                //value = (secondValue * secondMultiplicity * firstRate) / (firstMultiplicity * secondRate);

            }
            catch (Exception)
            {

            }
            return Convert.ToString(value);
        }

        public string CalculateLeftTextBox(string firstCurrency, string secondCurrency, double firstValue, double secondValue)
        {
            double value = 0;
            try
            {
                double secondRate = _currencyModel.Valute.GetValueOrDefault(firstCurrency).Value;
                double secondMultiplicity = _currencyModel.Valute.GetValueOrDefault(firstCurrency).Nominal;
                double firstRate = _currencyModel.Valute.GetValueOrDefault(secondCurrency).Value;
                double firstMultiplicity = _currencyModel.Valute.GetValueOrDefault(secondCurrency).Nominal;

                //value = (firstValue * firstMultiplicity * secondRate) / (secondMultiplicity * firstRate);
                value = (secondValue * secondMultiplicity * firstRate) / (firstMultiplicity * secondRate);

            }
            catch (Exception)
            {

            }
            return Convert.ToString(value);
        }


        private void ChangeFirstCurrencyValues()
        {
            _firstRate = _currencyModel.Valute.GetValueOrDefault(FirstCurrency).Value;
            _firstMultiplicity = _currencyModel.Valute.GetValueOrDefault(FirstCurrency).Nominal;
        }


        public string Calculate(string currencyName)
        {
            double value = 0;
            if (currencyName == FirstCurrency)
            {
                value = (FirstValue * _firstMultiplicity * _secondRate) / (_secondMultiplicity * _firstRate);
            }
            else if (currencyName == SecondCurrency)
            {
                value = (SecondValue * _secondMultiplicity * _firstRate) / (_firstMultiplicity * _secondRate);
            }
            //else
            //{
            //    throw new Exception("WTF");
            //}
            return Convert.ToString(value);
        }



        public string CalculateSecondCurrency(float secondValue)
        {
            SecondValue = secondValue;
            ChangeSecondCurrencyValues();
            return Calculate(SecondCurrency);
        }


        private void ChangeSecondCurrencyValues()
        {
            _secondRate = _currencyModel.Valute.GetValueOrDefault(SecondCurrency).Value;
            _secondMultiplicity = _currencyModel.Valute.GetValueOrDefault(SecondCurrency).Nominal;
        }

        public string CalculateFirstCurrency(float firstValue)
        {
            FirstValue = firstValue;
            ChangeFirstCurrencyValues();
            return Calculate(FirstCurrency);
        }

        public string CalculateFirstCurrency(string firstCurrency)
        {
            FirstCurrency = firstCurrency;
            ChangeFirstCurrencyValues();
            return Calculate(FirstCurrency);
        }






    }
}
