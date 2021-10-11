using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DinProg
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        TabbedPage1 tabpage1 = new TabbedPage1();
        TabbedPage2 tabpage2 = new TabbedPage2();
        TabbedPage3 tabpage3 = new TabbedPage3();
        TabbedPage4 tabpage4 = new TabbedPage4();
        TabbedPage5 tabpage5 = new TabbedPage5();
        TabbedPage6 tabpage6 = new TabbedPage6();
        TabbedPage7 tabpage7 = new TabbedPage7();
        TabbedPage8 tabpage8 = new TabbedPage8();
        TabbedPage9 tabpage9 = new TabbedPage9();
        TabbedPage10 tabpage10 = new TabbedPage10();
        TabbedPage11 tabpage11 = new TabbedPage11();
        TabbedPage12 tabpage12 = new TabbedPage12();
        public Page1()
        {
            InitializeComponent();
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(tabpage1);
        }

        private void Button2_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(tabpage2);
        }

        private void Button3_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(tabpage3);
        }

        private void Button4_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(tabpage4);
        }
        private void Button5_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(tabpage5);
        }
        private void Button6_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(tabpage6);
        }
        private void Button7_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(tabpage7);
        }
        private void Button8_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(tabpage8);
        }
        private void Button9_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(tabpage9);
        }
        private void Button10_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(tabpage10);
        }
        private void Button11_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(tabpage11);
        }
        private void Button12_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(tabpage12);
        }
    }
}