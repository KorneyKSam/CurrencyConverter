using CurrencyConverter.CustomExceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
            _calculator = new Calculator(_currencyModel, "RU");
            CurrencyList = GetCurrencyList();
            CurrencyList.Add("RU");

            //btnChangeValute2.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 90, 99, 195));
        }

        private List<string> GetCurrencyList()
        {
            return _currencyModel.Valute.Keys.ToList();
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBox2.Text = _calculator.CalculateFirstCurrency(Convert.ToString(CurrencyCombo1.SelectedValue));
        }

        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBox1.Text = _calculator.CalculateSecondCurrency(Convert.ToString(CurrencyCombo2.SelectedValue));
        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            float firstValue = TextBox1.Text != String.Empty ? Convert.ToSingle(TextBox1.Text) : 0;
            TextBox2.Text = _calculator.CalculateFirstValue(firstValue);
        }

        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            float secondValue = TextBox2.Text != String.Empty ? Convert.ToSingle(TextBox2.Text) : 0;
            TextBox1.Text = _calculator.CalculateSecondValue(secondValue);
        }

        private void UpdateValues()
        {
            TextBox1.Text = Convert.ToString(_calculator.FirstValue);
            TextBox2.Text = Convert.ToString(_calculator.SecondValue);
            CurrencyCombo1.SelectedValue = Convert.ToString(_calculator.FirstCurrency);
            CurrencyCombo2.SelectedValue = Convert.ToString(_calculator.SecondCurrency);
        }

        private void TextBoxes_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }
    }
}
