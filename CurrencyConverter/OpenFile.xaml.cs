using Newtonsoft.Json;
using System;
using System.IO;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace CurrencyConverter
{
    public sealed partial class OpenFile : Page
    {
        static public Currency _currency;
        public OpenFile()
        {
            this.InitializeComponent();
        }

        private async void FileOpenPicker()
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            openPicker.FileTypeFilter.Add(".json");

            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                MessageTextBox.Text = $"Открыт файл {file.Path}";
                string path = Path.GetFullPath(file.Path);
                path = path.Replace(@"\\", @"\");
                _currency.OpenJsonFile(path);
            }
            else
            {
                MessageTextBox.Text = "Отмена";
            }
        }

        private void ButtonOpenLink_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonOpenFile_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker();
        }
    }
}
