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
    public partial class TabbedPage5 : TabbedPage
    {
        private int attempts = 0;
        public TabbedPage5()
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
            attempts++;
            bool correctlvl = true;
            Editor[] editors1 = new Editor[23] { L5T1Line1Edit1, L5T1Line1Edit2, L5T1Line1Edit3, L5T1Line1Edit4, L5T1Line1Edit5, L5T1Line1Edit6,
                L5T1Line1Edit7, L5T1Line1Edit8, L5T1Line1Edit9, L5T1Line1Edit10, L5T1Line1Edit11, L5T1Line1Edit12, L5T1Line1Edit13, 
                L5T1Line1Edit14, L5T1Line1Edit15, L5T1Line1Edit16, L5T1Line1Edit17, L5T1Line1Edit18, L5T1Line1Edit19, L5T1Line1Edit20, 
                L5T1Line1Edit21, L5T1Line1Edit22, L5T1Line1Edit23 };
            Editor[] editors2 = new Editor[23] { L5T1Line2Edit1, L5T1Line2Edit2, L5T1Line2Edit3, L5T1Line2Edit4, L5T1Line2Edit5, L5T1Line2Edit6,
                L5T1Line2Edit7, L5T1Line2Edit8, L5T1Line2Edit9, L5T1Line2Edit10, L5T1Line2Edit11, L5T1Line2Edit12, L5T1Line2Edit13,
                L5T1Line2Edit14, L5T1Line2Edit15, L5T1Line2Edit16, L5T1Line2Edit17, L5T1Line2Edit18, L5T1Line2Edit19, L5T1Line2Edit20,
                L5T1Line2Edit21, L5T1Line2Edit22, L5T1Line2Edit23 };
            Editor[] editors3 = new Editor[23] { L5T1Line3Edit1, L5T1Line3Edit2, L5T1Line3Edit3, L5T1Line3Edit4, L5T1Line3Edit5, L5T1Line3Edit6,
                L5T1Line3Edit7, L5T1Line3Edit8, L5T1Line3Edit9, L5T1Line3Edit10, L5T1Line3Edit11, L5T1Line3Edit12, L5T1Line3Edit13,
                L5T1Line3Edit14, L5T1Line3Edit15, L5T1Line3Edit16, L5T1Line3Edit17, L5T1Line3Edit18, L5T1Line3Edit19, L5T1Line3Edit20,
                L5T1Line3Edit21, L5T1Line3Edit22, L5T1Line3Edit23 };
            int[] nums1 = new int[23];
            int[] nums2 = new int[23];
            int[] nums3 = new int[23];
            try
            {
                for (int i = 0; i < 23; ++i)
                {
                    nums1[i] = Convert.ToInt32(editors1[i].Text);
                    nums2[i] = Convert.ToInt32(editors2[i].Text);
                    nums3[i] = Convert.ToInt32(editors3[i].Text);
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Mistake", ex.Message.ToString(), "OK");
            }
            int[] correcttask1 = new int[23] { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6 };
            int[] correcttask2 = new int[23] { 3, 3, 3, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 16, 16, 16, 16, 16 };
            int[] correcttask3 = new int[23] { 3, 3, 3, 8, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 18, 18, 18 };
            for (int i = 0; i < 23; ++i)
            {
                if (correcttask1[i] != nums1[i] || correcttask2[i] != nums2[i] || correcttask3[i] != nums3[i])
                {
                    correctlvl = false;
                }
            }
            if (correctlvl)
            {
                correct(Lblforouttask1L5);
            }
            else
            {
                uncorrect(Lblforouttask1L5);
            }
            if (attempts > 4)
            {
                attempts = 0;
                this.CurrentPage = this.Children[0];
            }
        }
    }
}