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
            attempts[1]++;
            bool correctlvl = true;
            Editor[] editors1 = new Editor[11] { edit1l4t2, edit2l4t2, edit3l4t2, edit4l4t2, edit5l4t2, edit11l4t2, edit12l4t2, edit13l4t2, edit14l4t2, edit15l4t2, edit16l4t2 };
            Editor[] editors2 = new Editor[11] { edit6l4t2, edit7l4t2, edit8l4t2, edit9l4t2, edit10l4t2, edit17l4t2, edit18l4t2, edit19l4t2, edit20l4t2, edit21l4t2, edit22l4t2 };
            int[] nums1 = new int[11];
            int[] nums2 = new int[11];
            try
            {
                for (int i = 0; i < 11; ++i)
                {
                    nums1[i] = Convert.ToInt32(editors1[i].Text);
                    nums2[i] = Convert.ToInt32(editors2[i].Text);
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Mistake", ex.Message.ToString(), "OK");
            }
            int[] correcttask1 = new int[11] { 4, 2, 14, 0, 2, 2, 8, 14, 18, 10, 4};
            int[] correcttask2 = new int[11] { 1, 1, 2, 1, 2, 2, 3, 4, 5, 4, 3 };
            for (int i = 0; i < 6; ++i)
            {
                if (correcttask1[i] != nums1[i] || correcttask2[i] != nums2[i])
                {
                    correctlvl = false;
                }
            }
            if (correctlvl)
            {
                correct(Lblforoutputl4t2);
            }
            else
            {
                uncorrect(Lblforoutputl4t2);
            }
            if (attempts[1] > 4)
            {
                attempts[1] = 0;
                this.CurrentPage = this.Children[0];
            }
        }
    }
}