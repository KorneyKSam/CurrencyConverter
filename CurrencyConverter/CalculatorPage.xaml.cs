using CurrencyConverter.CustomExceptions;
using CurrencyConverter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace CurrencyConverter
{
    public sealed partial class CalculatorPage : Page
    {
        static public CurrencyModel _currencyModel;
        private Calculator _calculator;
        public List<string> CurrencyList { get; private set; }

        public CalculatorPage()
        {
            this.InitializeComponent();
            _calculator = new Calculator(_currencyModel);
            _calculator.SetBaseCurrency("RU", "Рубль");
            CurrencyList = GetCurrencyList();
            //btnChangeValute2.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 90, 99, 195));
        }

        private List<string> GetCurrencyList()
        {
            List<string> list = new List<string>();
            foreach (var item in _currencyModel.Valute.Keys)
            {
                list.Add($"{_currencyModel.Valute.GetValueOrDefault(item).Name} ({_currencyModel.Valute.GetValueOrDefault(item).CharCode})");
            }
            return list;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBox2.IsHitTestVisible = false;
            double firstValue = TextBox1.Text != String.Empty ? Convert.ToSingle(TextBox1.Text) : 0;
            double secondValue = TextBox2.Text != String.Empty ? Convert.ToSingle(TextBox2.Text) : 0;
            var pattern = @"(?<=\().+?(?=\))";
            string firstCurrency = Convert.ToString(Regex.Match(Convert.ToString(CurrencyCombo1.SelectedValue), pattern));
            string secondCurrency = Convert.ToString(Regex.Match(Convert.ToString(CurrencyCombo2.SelectedValue), pattern));
            TextBox2.Text = _calculator.Calculate(firstCurrency, secondCurrency, firstValue, secondValue);
            TextBox2.IsHitTestVisible = true;
        }
        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox2.IsHitTestVisible = false;
            double firstValue = TextBox1.Text != String.Empty ? Convert.ToSingle(TextBox1.Text) : 0;
            double secondValue = TextBox2.Text != String.Empty ? Convert.ToSingle(TextBox2.Text) : 0;
            var pattern = @"(?<=\().+?(?=\))";
            string firstCurrency = Convert.ToString(Regex.Match(Convert.ToString(CurrencyCombo1.SelectedValue), pattern));
            string secondCurrency = Convert.ToString(Regex.Match(Convert.ToString(CurrencyCombo2.SelectedValue), pattern));
            TextBox2.Text = _calculator.Calculate(firstCurrency, secondCurrency, firstValue, secondValue);
            TextBox2.IsHitTestVisible = true;
        }

        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox1.IsHitTestVisible = false;
            double firstValue = TextBox1.Text != String.Empty ? Convert.ToSingle(TextBox1.Text) : 0;
            double secondValue = TextBox2.Text != String.Empty ? Convert.ToSingle(TextBox2.Text) : 0;
            var pattern = @"(?<=\().+?(?=\))";
            string firstCurrency = Convert.ToString(Regex.Match(Convert.ToString(CurrencyCombo1.SelectedValue), pattern));
            string secondCurrency = Convert.ToString(Regex.Match(Convert.ToString(CurrencyCombo2.SelectedValue), pattern));
            TextBox1.Text = _calculator.CalculateLeftTextBox(firstCurrency, secondCurrency, firstValue, secondValue);
            TextBox1.IsHitTestVisible = true;
        }

        //private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    TextBox1.IsHitTestVisible = false;
        //    TextBox1.Text = _calculator.CalculateSecondCurrency(Convert.ToString(CurrencyCombo2.SelectedValue));
        //    TextBox1.IsHitTestVisible = true;
        //}



        //private void TextBoxes_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        //{
        //    args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        //    args.Cancel = args.NewText.Any(c => !Char.IsNumber(c)); 
        //}
    }
}
