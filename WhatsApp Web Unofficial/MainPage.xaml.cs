﻿using System;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WhatsApp_Web_Unofficial
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        [DllImport("urlmon.dll", CharSet = CharSet.Ansi)]
        private static extern int UrlMkSetSessionOption(int dwOption, string pBuffer, int dwBufferLength, int dwReserved);
        const int URLMON_OPTION_USERAGENT = 0x10000001;

        public MainPage()
        {
            this.InitializeComponent();
            titleBar.BackgroundColor = new Color() { A = 255, R = 54, G = 60, B = 116 };

        }

        public void ChangeUserAgent(string Agent)
        {
            UrlMkSetSessionOption(URLMON_OPTION_USERAGENT, Agent, Agent.Length, 0);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        { 
            ChangeUserAgent("Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36");
            webView1.Navigate(new Uri("http://web.whatsapp.com/", UriKind.Absolute));
        }

        #region Custom title bar 
        CustomTitleBar customTitleBar = null;
        public void AddCustomTitleBar()
        {
            if (customTitleBar == null)
            {
                customTitleBar = new CustomTitleBar();
                customTitleBar.EnableControlsInTitleBar(areControlsInTitleBar);
                UIElement mainContent = this.Content;
                this.Content = null;
                customTitleBar.SetPageContent(mainContent);
                this.Content = customTitleBar;
            }
        }
        public void RemoveCustomTitleBar()
        {
            if (customTitleBar != null)
            { 
                this.Content = customTitleBar.SetPageContent(null);
                customTitleBar = null;
            }
        }
        bool areControlsInTitleBar = false;
        public bool AreControlsInTitleBar
        {
            get
            {
                return areControlsInTitleBar;
            }
            set
            {
                areControlsInTitleBar = value;
                if (customTitleBar != null)
                {
                    customTitleBar.EnableControlsInTitleBar(value);
                }
            }
        }
        #endregion

    }
}
