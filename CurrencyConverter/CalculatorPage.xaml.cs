using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Windows.UI.Xaml.Controls;


namespace CurrencyConverter
{
    public sealed partial class CalculatorPage : Page
    {
        static public Currency _currency;
        private Calculator _calculator;
        public List<string> CurrencyList { get; private set; }

        public CalculatorPage()
        {
            this.InitializeComponent();
            _calculator = new Calculator();
            CurrencyList = _currency.GetCurrencyList();
            //btnChangeValute2.Background = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 90, 99, 195));
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBox2.IsHitTestVisible = false;
            string firstCurrency = SelectContentOfBrackets(Convert.ToString(CurrencyCombo1.SelectedValue));
            int nominal = _currency.GetNominal(firstCurrency);
            float rate = _currency.GetRate(firstCurrency);
            double value = _calculator.CalculateFirstCurrency(nominal, rate);
            TextBox2.Text = Convert.ToString(Math.Round(_calculator.CalculateFirstCurrency(nominal, rate), 6));
            TextBox2.IsHitTestVisible = true;
        }

        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBox2.IsHitTestVisible = false;
            string secondCurrency = SelectContentOfBrackets(Convert.ToString(CurrencyCombo2.SelectedValue));
            int nominal = _currency.GetNominal(secondCurrency);
            float rate = _currency.GetRate(secondCurrency);
            TextBox2.Text = Convert.ToString(Math.Round(_calculator.CalculateSecondCurrency(nominal, rate), 6));
            TextBox2.IsHitTestVisible = true;
        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox2.IsHitTestVisible = false;
            double firstValue = SetZeroIfEmpty(TextBox1.Text);
            TextBox2.Text = Convert.ToString(Math.Round(_calculator.CalculateFirstCurrency(firstValue), 6));
            TextBox2.IsHitTestVisible = true;
        }

        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox1.IsHitTestVisible = false;
            double secondValue = SetZeroIfEmpty(TextBox2.Text);
            TextBox1.Text = Convert.ToString(Math.Round(_calculator.CalculateSecondCurrency(secondValue), 6));
            TextBox1.IsHitTestVisible = true;
        }

        private string SelectContentOfBrackets(string content, string pattern = @"(?<=\().+?(?=\))")
        {
            return Convert.ToString(Regex.Match(content, pattern, RegexOptions.RightToLeft));
        }

        private double SetZeroIfEmpty(string number)
        {
            try
            {
                return Convert.ToDouble(number != String.Empty ? Convert.ToDouble(number) : 0);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private void TextBoxes_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }

        private string DeleteAllLetters(string number)
        {
            return Convert.ToString(number.Where(char.IsDigit).ToArray());
        }
    }
}
