using DinProg.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace DinProg.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}