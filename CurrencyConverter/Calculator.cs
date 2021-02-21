using CurrencyConverter.Models;
using System;

namespace CurrencyConverter
{
    public class Calculator
    {
        public CalculatorModel FirstCurrency { get; set; }
        public CalculatorModel SecondCurrency { get; set; }

        public Calculator()
        {
            FirstCurrency = new CalculatorModel();
            SecondCurrency = new CalculatorModel();
        }

        public double CalculateFirstCurrency(int nominal, float rate)
        {
            double value = 0;
            try
            {
                SecondCurrency.Nominal = nominal;
                SecondCurrency.Rate = rate;
                value = (FirstCurrency.Amount * FirstCurrency.Nominal * SecondCurrency.Rate) / (SecondCurrency.Nominal * FirstCurrency.Rate);
            }
            catch (Exception)
            {

            }
            return value;
        }

        public double CalculateFirstCurrency(double firstCurrencyAmount)
        {
            double value = 0;
            try
            {
                FirstCurrency.Amount = firstCurrencyAmount;
                value = (FirstCurrency.Amount * FirstCurrency.Nominal * SecondCurrency.Rate) / (SecondCurrency.Nominal * FirstCurrency.Rate);
            }
            catch (Exception)
            {

            }
            return value;
        }

        public double CalculateSecondCurrency(int nominal, float rate)
        {
            double value = 0;
            try
            {
                FirstCurrency.Nominal = nominal;
                FirstCurrency.Rate = rate;
                value = (FirstCurrency.Amount * FirstCurrency.Nominal * SecondCurrency.Rate) / (SecondCurrency.Nominal * FirstCurrency.Rate);
            }
            catch (Exception)
            {

            }
            return value;
        }

        public double CalculateSecondCurrency(double secondCurrencyAmount)
        {
            double value = 0;
            try
            {
                SecondCurrency.Amount = secondCurrencyAmount;
                value = (SecondCurrency.Amount * SecondCurrency.Nominal * FirstCurrency.Rate) / (FirstCurrency.Nominal * SecondCurrency.Rate);
            }
            catch (Exception)
            {

            }
            return value;
        }
    }
}
