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
    public sealed partial class OpenFile : Page
    {

        public OpenFile()
        {
            this.InitializeComponent();
        }

        private void ButtonOpenFile_Click(object sender, RoutedEventArgs e)
        {

            //string path = Directory.GetCurrentDirectory();
            //StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(path);
            //await Launcher.LaunchFolderAsync(folder);


            //try
            //{
            //    MainPage.OpenJsonFile();
            //}
            //catch (Exception exception)
            //{
            //    ExceptionTextBlock.Text = $"Ошибка, {exception.Message}";
            //}
        }

        private void ButtonOpenLink_Click(object sender, RoutedEventArgs e)
        {
            //MainPage.OpenJsonLink();
        }
    }
}
