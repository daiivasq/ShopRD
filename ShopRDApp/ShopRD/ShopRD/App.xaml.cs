using Prism.Ioc;
using Refit;
using ShopRD.ViewModels;
using ShopRD.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopRD
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<AddAddressPage, AddAddressPageViewModel >();
            containerRegistry.RegisterForNavigation<AddPaymetnsPage,AddPaymentsPageViewModel >();
            containerRegistry.RegisterForNavigation<CarPage,CarPageViewModel >();
            containerRegistry.RegisterForNavigation<CatalogPage,CatalogPageViewModel >();
            containerRegistry.RegisterForNavigation<CheckoutPage, CheckoutPageViewModel>();
            containerRegistry.RegisterForNavigation<DetailOrdersTrackingPage,DetailOrdersTrackingPageViewModel >();
            containerRegistry.RegisterForNavigation <FavoritesPage,FavoritesPageViewModel > ();
            containerRegistry.RegisterForNavigation <FeedbacksPage,FeedbacksPageViewModel > ();
            containerRegistry.RegisterForNavigation <ForgotPassword,ForgotPasswordPageViewModel > ();
            containerRegistry.RegisterForNavigation <HomePage,HomePageViewModel > ();
            containerRegistry.RegisterForNavigation <ListAddressPage,ListAddressPageViewModel > ();
            containerRegistry.RegisterForNavigation <ListPaymentsPage,ListPaymentsPageViewModel > ();
            containerRegistry.RegisterForNavigation <LoginPage,LoginPageViewModel > ();
            containerRegistry.RegisterForNavigation <OrdersPage,OrdesPageViewModel > ();
            containerRegistry.RegisterForNavigation <ProductDetailPage,ProductDetailPageViewModel > ();
            containerRegistry.RegisterForNavigation <RegisterPage,RegisterPageViewModel > ();
            containerRegistry.RegisterForNavigation <ResetPasswordPage,ResetPasswordPageViewModel > ();


        }
    }
}
