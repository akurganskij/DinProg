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
    public partial class TabbedPage2 : TabbedPage
    {
        public TabbedPage2()
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
        private void DragGestureRecognizer_DragStarting(object sender, DragStartingEventArgs e)
        {
            var frame = (sender as Element)?.Parent as Frame;
            var label = (frame.Content as Label);
            e.Data.Properties.Add("text", label.Text);
        }

        private void DropGestureRecognizer_Drop(object sender, DropEventArgs e)
        {
            var data = e.Data.Properties["text"].ToString();
            var frame = (sender as Element)?.Parent as Frame;
            var label = (frame.Content) as Label;
            label.Text = data;
            label.HorizontalTextAlignment = TextAlignment.Center;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Frame[] frames = new Frame[5] {dndframe1, dndframe2, dndframe3, dndframe4, dndframe5 };
            Label[] lbs = new Label[5];
            for (int i = 0; i < 5; ++i) lbs[i] = (frames[i].Content) as Label;
            bool a, b;
            a = lbs[0].Text == "F(n)" && ((lbs[1].Text == "F(n-1)" && lbs[2].Text == "2") || (lbs[2].Text == "F(n-1)" && lbs[1].Text == "2"));
            b = (lbs[3].Text == "F(1)" && lbs[4].Text == "3");
            if (a && b)
            {
                correct(T1Label);
            }
            else
            {
                uncorrect(T1Label);
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Editor[] edits = new Editor[5] { T2L1Edit1, T2L1Edit2, T2L1Edit3, T2L1Edit4, T2L1Edit5 };
            int[] nums = new int[5];
            try
            {
                for (int i = 0; i < 5; ++i)
                {
                    nums[i] = Convert.ToInt32(edits[i].Text);
                }
            }
            catch(Exception ex)
            {
                DisplayAlert("Uncorrect input", "Input Number", "OK");
            }
            int[] correctnum = new [] { 19, 13, 9, 1, 3 };
            bool a = true; 
            for (int i = 0; i < 5; ++i) a = a && nums[i] == correctnum[i];
            if (a)
            {
                correct(T2Label);
            }
            else
            {
                uncorrect(T2Label);
            }
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Entry[] ents = new Entry[2] { T3Entry1, T3Entry2 };
            string[] strs = new string[2] { ents[0].Text, ents[1].Text };
            bool a;
            strs[0] = strs[0].Replace(" ", "");
            strs[1] = strs[1].Replace(" ", "");
            a = (strs[0] == "n-1" && strs[1] == "n-2") || (strs[1] == "n-1" && strs[0] == "n-2"); 
            if (a)
            {
                correct(T3Label);
            }
            else
            {
                uncorrect(T3Label);
            }
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {

        }
    }
}