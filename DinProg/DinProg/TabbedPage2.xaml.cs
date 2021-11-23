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
        private int[] attempts = new int[6] { 0, 0, 0, 0, 0, 0 };
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
            attempts[0]++;
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
            if(attempts[0] > 4)
            {
                attempts[0] = 0;
                this.CurrentPage = this.Children[0];
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            attempts[1]++;
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
                DisplayAlert("Некоректний ввод", "Введіть число", "OK");
            }
            int[] correctnum = new [] { 6, 4, 6, 1, 3 };
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
            if (attempts[1] > 4)
            {
                attempts[1] = 0;
                this.CurrentPage = this.Children[0];
            }
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            attempts[2]++;
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
            if (attempts[2] > 4)
            {
                attempts[2] = 0;
                this.CurrentPage = this.Children[0];
            }
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            attempts[3]++;
            int[] correctnums = new int[] { 1, 0, 3, 1, 2, 5 };
            Editor[] edits = new Editor[6] { T4Edit1, T4Edit2, T4Edit3, T4Edit4, T4Edit5, T4Edit6 };
            int[] answ = new int[6];
            try
            {
                for (int i = 0; i < 6; ++i) answ[i] = Convert.ToInt32(edits[i].Text);
            }
            catch(Exception ex)
            {
                DisplayAlert("Некоректний ввод", "Введіть число", "ОК");
            }
            bool a = true;
            for (int i = 0; i < 6; ++i) a = a && correctnums[i] == answ[i];
            if (a)
            {
                correct(T4Label);
            }
            else
            {
                uncorrect(T4Label);
            }
            if (attempts[3] > 4)
            {
                attempts[3] = 0;
                this.CurrentPage = this.Children[0];
            }
        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {
            attempts[4]++;
            int[] correctnums = new int[] {0, 4, 9, 13, 12, 16, 18, 32, 24};
            Editor[] edits = new Editor[] { T5Edit1, T5Edit2, T5Edit3, T5Edit4, T5Edit5, T5Edit6, T5Edit7, T5Edit8, T5Edit9 };
            int[] answ = new int[9];
            try
            {
                for (int i = 0; i < 9; ++i) answ[i] = Convert.ToInt32(edits[i].Text);
            }
            catch (Exception ex)
            {
                DisplayAlert("Некоректний ввод", "Введіть число", "ОК");
            }
            bool a = true;
            for (int i = 0; i < 9; ++i) a = a && correctnums[i] == answ[i];
            if (a)
            {
                correct(T5Label);
            }
            else
            {
                uncorrect(T5Label);
            }
            if (attempts[4] > 4)
            {
                attempts[4] = 0;
                this.CurrentPage = this.Children[0];
            }
        }

        private void Button_Clicked_5(object sender, EventArgs e)
        {
            attempts[5]++;
            Button[] btns = new Button[] {T6button1, T6button2, T6button3, T6button4, T6button5, T6button6, T6button7,
            T6button8, T6button9, T6button10};
            bool[] correctansw = new bool[] {true, false, false, true, false, true, false, true, false, true };
            bool[] answ = new bool[10];
            for (int i = 0; i < 10; ++i) 
                if (btns[i].BackgroundColor == Color.Yellow) answ[i] = true; 
                else answ[i] = false;
            bool a = true;
            for (int i = 0; i < 10; ++i) a = a && correctansw[i] == answ[i];
            if (a)
            {
                correct(T6Label);
            }
            else
            {
                uncorrect(T6Label);
            }
            if (attempts[5] > 4)
            {
                attempts[5] = 0;
                this.CurrentPage = this.Children[0];
            }
        }

        private void T6button_Clicked(object sender, EventArgs e)
        {
            if ((sender as Button).BackgroundColor == Color.LightGray) (sender as Button).BackgroundColor = Color.Yellow;
            else (sender as Button).BackgroundColor = Color.LightGray;
        }
    }
}