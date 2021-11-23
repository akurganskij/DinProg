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
    public partial class TabbedPage4 : TabbedPage
    {
        private int[] attempts = new int[] { 0, 0 };
        public TabbedPage4()
        {
            InitializeComponent();
        }

        private void correct(Label label)
        {
            label.Text = "Завдання виконано правильно!";
            label.TextColor = Color.Green;
        }

        private void uncorrect(Label label)
        {
            label.Text = "Спробуйте ще раз";
            label.TextColor = Color.Red;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            attempts[0]++;
            bool correctlvl = true;
            Editor[] editors = new Editor[6] { edit1l4t1, edit2l4t1, edit3l4t1, edit4l4t1, edit5l4t1, edit6l4t1 };
            int[] nums = new int[6];
            try
            {
                for (int i = 0; i < 6; ++i) nums[i] = Convert.ToInt32(editors[i].Text);
            }
            catch (Exception ex)
            {
                DisplayAlert("Mistake", ex.Message.ToString(), "OK");
            }
            int[] correcttask = new int[] { 1, 2, 2, 2, 3, 3 };
            for(int i = 0; i < 6; ++i)
            {
                if(correcttask[i] != nums[i])
                {
                    correctlvl = false;
                }
            }
            if (correctlvl) 
            {
                correct(Lblforoutputl4t1);
            }
            else
            {
                uncorrect(Lblforoutputl4t1);
            }
            if(attempts[0] > 4)
            {
                attempts[0] = 0;
                this.CurrentPage = this.Children[0];
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}