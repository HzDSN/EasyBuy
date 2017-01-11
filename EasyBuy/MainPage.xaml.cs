using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System.Profile;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace EasyBuy
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int SearchEngine = 1;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mySplit.IsPaneOpen = true;
            Grid.SetColumn(webView, 2);
            Grid.SetColumnSpan(webView, 1);
            Grid.SetColumn(textBlock, 2);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mySplit.IsPaneOpen = false;
            Grid.SetColumn(webView, 0);
            Grid.SetColumnSpan(webView, 3);
            Grid.SetColumn(textBlock, 0);
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (IsAcceptReturn)
            {
                SearchEngine = 1;
                mySplit.IsPaneOpen = false;
                webView.Visibility = Windows.UI.Xaml.Visibility.Visible;
                if (textBox.Text != "在此输入搜索的东西，按回车结束")
                {
                    //if (!IsAcceptReturn)
                    //{
                       // webView.Navigate(new Uri("https://s.taobao.com/search?q=" + textBox.Text));
                    //}
                   // else
                    //{
                        webView.Navigate(new Uri("https://s.m.taobao.com/h5?q=" + textBox.Text));
                    //}
                }
            }
            else
            {
                SearchEngine = 1;
                //mySplit.IsPaneOpen = false;
                webView.Visibility = Windows.UI.Xaml.Visibility.Visible;
                if (textBox.Text != "在此输入搜索的东西，按回车结束")
                {
                    //if (!IsAcceptReturn)
                    //{
                   webView.Navigate(new Uri("https://s.taobao.com/search?q=" + textBox.Text));
                    //}
                    // else
                    //{
                    //webView.Navigate(new Uri("https://s.m.taobao.com/h5?q=" + textBox.Text));
                    //}
                }
            }
                
        }

        private void TextBlock_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            //https://www.amazon.cn/s?field-keywords=test
            SearchEngine = 2;
            if (IsAcceptReturn) mySplit.IsPaneOpen = false;
            webView.Visibility = Windows.UI.Xaml.Visibility.Visible;
            if (textBox.Text != "在此输入搜索的东西，按回车结束")
            {
                webView.Navigate(new Uri("https://www.amazon.cn/s?field-keywords=" + textBox.Text));
            }
        }

        private void textBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            //textBox.Text = Convert.ToInt32(e.Key).ToString();
            if(Convert.ToInt32(e.Key) == 13)
            {
                if(SearchEngine==1)
                {
                    TextBlock_Tapped();
                }
                else
                {
                    TextBlock_Tapped_1();
                }
            }
        }

        private void TextBlock_Tapped()
        {
            if (IsAcceptReturn)
            {
                SearchEngine = 1;
                mySplit.IsPaneOpen = false;
                webView.Visibility = Windows.UI.Xaml.Visibility.Visible;
                if (textBox.Text != "在此输入搜索的东西，按回车结束")
                {
                    //if (!IsAcceptReturn)
                    //{
                    // webView.Navigate(new Uri("https://s.taobao.com/search?q=" + textBox.Text));
                    //}
                    // else
                    //{
                    webView.Navigate(new Uri("https://s.m.taobao.com/h5?q=" + textBox.Text));
                    //}
                }
            }
            else
            {
                SearchEngine = 1;
                mySplit.IsPaneOpen = false;
                webView.Visibility = Windows.UI.Xaml.Visibility.Visible;
                if (textBox.Text != "在此输入搜索的东西，按回车结束")
                {
                    //if (!IsAcceptReturn)
                    //{
                    webView.Navigate(new Uri("https://s.taobao.com/search?q=" + textBox.Text));
                    //}
                    // else
                    //{
                    //webView.Navigate(new Uri("https://s.m.taobao.com/h5?q=" + textBox.Text));
                    //}
                }
            }
        }

        private void TextBlock_Tapped_1()
        {
            //https://www.amazon.cn/s?field-keywords=test
            SearchEngine = 2;
            if (IsAcceptReturn) mySplit.IsPaneOpen = false;
            webView.Visibility = Windows.UI.Xaml.Visibility.Visible;
            if (textBox.Text != "在此输入搜索的东西，按回车结束")
            {
                webView.Navigate(new Uri("https://www.amazon.cn/s?field-keywords=" + textBox.Text));
            }
        }

        public bool IsAcceptReturn
        {
            get
            {
                return AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile";
            }
        }
    }
}

