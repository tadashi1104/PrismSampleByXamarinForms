using Prism;
using Prism.Ioc;
using PrismSampleByXamarinForms.ViewModels;
using PrismSampleByXamarinForms.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PrismSampleByXamarinForms.Services;
using Prism.Unity;

namespace PrismSampleByXamarinForms
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync("LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<InputCreditInfoAPage, InputCreditInfoAPageViewModel>();

            containerRegistry.Register<ICommonApiService, CommonApiService>();
            containerRegistry.Register<ILoginPageService, LoginPageService>();
        }
    }
}
