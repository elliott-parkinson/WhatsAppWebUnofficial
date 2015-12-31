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
using System.Runtime.InteropServices;
using Windows.UI;
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WhatsApp_Web_Unofficial
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            var appView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
            var titleBar = appView.TitleBar;

            titleBar.ButtonForegroundColor = Colors.White;
            titleBar.ButtonBackgroundColor = Color.FromArgb(1, 0, 150, 136);
            titleBar.BackgroundColor = Color.FromArgb(1, 0, 150, 136);
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage( HttpMethod.Post, new Uri("http://web.whatsapp.com/") );
            httpRequestMessage.Headers.Append("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36");

            webView1.NavigateWithHttpRequestMessage(httpRequestMessage);
        }
    }
}
