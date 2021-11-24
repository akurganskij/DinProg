using DinProg.ViewModels;
using DinProg.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DinProg
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        Page1 page1 = new Page1();
        TabbedPage1 tpage1 = new TabbedPage1();
        TabbedPage2 tpage2 = new TabbedPage2();
        TabbedPage3 tpage3 = new TabbedPage3();
        TabbedPage4 tpage4 = new TabbedPage4();
        TabbedPage5 tpage5 = new TabbedPage5();
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(page1);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(tpage1);
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(tpage2);
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            Navigation.PushAsync(tpage3);
        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {
            Navigation.PushAsync(tpage4);
        }

        private void Button_Clicked_5(object sender, EventArgs e)
        {
            Navigation.PushAsync(tpage5);
        }
    }
}
