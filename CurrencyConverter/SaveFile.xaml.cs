using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace CurrencyConverter
{
    public sealed partial class SaveFile : Page
    {
        static public Currency _currency;
        public SaveFile()
        {
            this.InitializeComponent();
        }

        private void ButtonJsonSave_Click(object sender, RoutedEventArgs e)
        {
            //_currency.SaveJsonFile(Directory.GetCurrentDirectory() + "\\" + "daily_json.js");
            //MainPage.SaveJsonFile(@"D:\\daily_json.txt");
        }
    }
}
