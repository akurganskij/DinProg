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
    }
}
