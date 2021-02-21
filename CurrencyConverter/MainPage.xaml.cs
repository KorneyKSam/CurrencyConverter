using CurrencyConverter.CustomExceptions;
using CurrencyConverter.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CurrencyConverter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public CurrencyModel _currencyModel;

        public MainPage()
        {
            this.InitializeComponent();
            ConvertJsonLink();
            CalculatorPage._currencyModel = _currencyModel;
            Frame.Navigate(typeof(CalculatorPage));          
        }

        private void burgerButton_Click(object sender, RoutedEventArgs e)
        {
            SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ItemOpenFile.IsSelected) Frame.Navigate(typeof(OpenFile));
            if (ItemSaveFile.IsSelected) Frame.Navigate(typeof(SaveFile));
            if (ItemCalculator.IsSelected) Frame.Navigate(typeof(CalculatorPage));
        }



        public CurrencyModel ConvertJsonFile(string directory = "daily_json.js")
        {
            CurrencyModel currencyModel = new CurrencyModel();
            if (File.Exists(directory))
                currencyModel = JsonConvert.DeserializeObject<CurrencyModel>(File.ReadAllText(directory));
            else throw new FileJsonNotFound();
            return currencyModel;
        }

        public void ConvertJsonLink(string link = "https://www.cbr-xml-daily.ru/daily_json.js")
        {
            //CurrencyModel currencyModel = new CurrencyModel();
            string json = new WebClient().DownloadString(link);
            _currencyModel = JsonConvert.DeserializeObject<CurrencyModel>(json);
            //return currencyModel;
        }

        public string SaveToJsonFile(CurrencyModel currencyModel, string path)
        {
            string saveMessage;
            //try
            //{
            //    using (FileStream fs = File.Create(path))
            //    {
            //        byte[] info = new UTF8Encoding(true).GetBytes("Текст одинаковый");
            //        fs.Write(info, 0, info.Length);
            //    }
            //}
            //catch (Exception exception)
            //{
            //    return exception.Message;
            //}

            //FileStream fs = new FileStream(path, FileMode.Create);

            //File.Create(path);
            File.WriteAllText("daily_json.js", JsonConvert.SerializeObject(_currencyModel));

            saveMessage = "successfully";
            return saveMessage;
        }


    }
}
