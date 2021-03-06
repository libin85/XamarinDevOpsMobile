﻿using XamarinDevOpsDemo.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using XF = Xamarin.Forms;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinDevOpsDemo
{
    public partial class App : Application
    {
        public App()
        {
            MobileCenter.Start($"android={Helpers.Constants.MobileCenterAppKey_Android};ios={Helpers.Constants.MobileCenterAppKey_iOS}",
                typeof(Analytics), typeof(Crashes));

            InitializeComponent();

            SetMainPage();
        }

        public static void SetMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new ItemsPage())
                    {
                        Title = "Browse",
                        Icon = XF.Device.OnPlatform("tab_feed.png",null,null)
                    },
                    new NavigationPage(new SessionDataPage())
                    {
                        Title = "Session",
                        Icon = XF.Device.OnPlatform("tab_feed.png",null,null)
                    }
                    ,new NavigationPage(new WebViewPage())
                    {
                        Title = "WebView",
                        Icon = XF.Device.OnPlatform("tab_about.png",null,null)
                    }
                    ,new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = XF.Device.OnPlatform("tab_about.png",null,null)
                    },
                }
            };
        }
    }
}
