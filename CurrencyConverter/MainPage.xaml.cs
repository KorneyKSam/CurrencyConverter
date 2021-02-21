using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace CurrencyConverter
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Currency currency = new Currency();
            currency.SetBaseCurrency("RU", "Российский рубль");
            CalculatorPage._currency = currency;
            OpenFile._currency = currency;
            SaveFile._currency = currency;
            Frame.Navigate(typeof(CalculatorPage));          
        }

        private void BurgerButton_Click(object sender, RoutedEventArgs e)
        {
            SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ItemOpenFile.IsSelected) Frame.Navigate(typeof(OpenFile));
            if (ItemSaveFile.IsSelected) Frame.Navigate(typeof(SaveFile));
            if (ItemCalculator.IsSelected) Frame.Navigate(typeof(CalculatorPage));
        }

    }
}
