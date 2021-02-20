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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CurrencyConverter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SaveFile : Page
    {
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
