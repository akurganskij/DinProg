using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DinProg.Models;

namespace DinProg
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPage1 : TabbedPage
    {
        public TabbedPage1()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            int res = 0;
            if (task1.IsChecked) res++;
            if (task2.IsChecked) res++;
            if (task3.IsChecked) res++;
            if (task4.IsChecked) res++;
            if (task5.IsChecked) res++;
            if (res == 5)
            {
                ResLabel.Text = "Усі завдання виконано правильно!";
                ResLabel.TextColor = Color.Green;
            }
            else
            {
                ResLabel.Text = "Спробуйте ще раз";
                ResLabel.TextColor = Color.Red;
            }
        }
    }
}