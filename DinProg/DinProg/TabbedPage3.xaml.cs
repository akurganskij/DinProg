using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Timers;

namespace DinProg
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPage3 : TabbedPage
    {
        private static int m1 = 5, n1 = 5;
        private bool[,] T1matrix = new bool[5, 5];
        private int[,] T1nums = new int[5, 5];
        private Frame[,] frames = new Frame[m1, n1];
        private Frame prevfrm = new Frame(), imfrm,tempframe = new Frame();
        private Tuple<int, int> T1lastcoords;
        private int T1res =0;
        private bool T1Attemptres = false;
        private static System.Timers.Timer aTimer;
        public TabbedPage3()
        {
            InitializeComponent();
            grid_generator(5, 5);
            T1lastcoords = new Tuple<int, int>(-1, -1);
        }

        private void grid_generator(int m, int n)
        {
            DropGestureRecognizer[,] Drop = new DropGestureRecognizer[m, n];
            Image img = new Image()
            {
                Source = "mouseL3T1.png",
                HeightRequest = 30
            };
            var Drag = new DragGestureRecognizer
            {
                CanDrag = true

            };
            Drag.DragStarting += DragGestureRecognizer_DragStarting;
            img.GestureRecognizers.Add(Drag);
            Task1Grid.Children.Add(img, 0, n-1);
            
            for(int i = 0; i < m; ++i)
            {
                for(int j = 0; j < n; ++j)
                {
                    Drop[i,j] = new DropGestureRecognizer
                    {
                        AllowDrop = true
                    };
                    Drop[i,j].Drop += DropGestureRecognizer_Drop;
                    T1matrix[i, j] = false;
                    Random rnd = new Random();
                    T1nums[i, j] = rnd.Next(1, 35);
                    string lbl = T1nums[i,j].ToString();
                    frames[i, j] = new Frame
                    {                        
                        Content = new Label() { Text = lbl }
                    };
                    frames[i, j].GestureRecognizers.Add(Drop[i,j]);
                    Task1Grid.Children.Add(frames[i,j], i + 1, j);
                }
            }
            T1matrix[0, n - 1] = true;
        }
        private int T1result()
        {
            int[,] temp = new int[m1, n1];
            int a;
            for(int i = 0; i < m1; ++i)
            {
                for(int j = n1 - 1; j >= 0; --j)
                {
                    if (i == 0 && j == n1 - 1) temp[i, j] = T1nums[i, j];
                    else if (i == 0) temp[i, j] = temp[i, j + 1] + T1nums[i, j];
                    else if (j == n1-1) temp[i, j] = temp[i - 1, j] + T1nums[i, j];
                    else temp[i, j] = Math.Max(temp[i - 1, j], temp[i, j + 1]) + T1nums[i, j];
                }
            }
            a = temp[m1-1, 0];
            return a;
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
            int res = T1result();
            if (Convert.ToInt32(T1LabelforSum.Text) == res)
            {
                correct(T1Result);
                T1Attemptres = true;
            }
            else uncorrect(T1Result);
            prevfrm.Content = tempframe.Content;
            for (int i = 0; i < 5; ++i)
                for (int j = 0; j < 5; ++j)
                    T1matrix[i, j] = false;
            T1matrix[0, n1 - 1] = true;
            T1res = 0;
            T1LabelforSum.Text = "";
            T1LabelforOutput.Text = "";
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            if (T1Attemptres == false) Button_Clicked(sender, e);
            if(T1Attemptres == true)
            {
                T1Attemptres = false;
                Random rnd = new Random();
                n1 = rnd.Next(2, 5);
                m1 = rnd.Next(2, 5);
                T1res = 0;
                T1LabelforSum.Text = "";
                T1LabelforOutput.Text = "";
                Task1Grid.Children.Clear();
                grid_generator(m1, n1);
                T1Result.Text = "";
            }
        }

        private void DragGestureRecognizer_DragStarting(object sender, DragStartingEventArgs e)
        {
            var image = (sender as Element)?.Parent as Image;
            e.Data.Properties.Add("Image", image);
        }
        private Tuple<int, int> frmfromtable (Frame frm)
        {
            for(int i = 0; i < m1; ++i)
            {
                for(int j = 0; j < n1; ++j)
                {
                    if(frm.Id.ToString() == frames[i, j].Id.ToString())
                    {
                        return new Tuple<int, int> (i, j);
                    }
                }
            }
            return new Tuple<int, int>(-1, -1);
        }
        async private void DropGestureRecognizer_Drop(object sender, DropEventArgs e)
        {
            var frm = (sender as Element)?.Parent as Frame;
            Tuple<int, int> a = frmfromtable(frm);
            if (T1matrix[a.Item1, a.Item2] == true)
            {
                T1res += Convert.ToInt32((frm.Content as Label).Text);
                T1LabelforSum.Text = T1res.ToString();
                ImageSource img = await e.Data.GetImageAsync();
                prevfrm.Content = tempframe.Content;
                prevfrm = frm;
                tempframe.Content = frm.Content;
                imfrm = new Frame
                {
                    Content = new Image()
                    {
                        Source = img,
                        WidthRequest = 50,
                    }
                };
                frm.Content = imfrm.Content;
                for (int i = 0; i < 5; ++i)
                    for (int j = 0; j < 5; ++j)
                        T1matrix[i, j] = false;
                if (a.Item1 == 0 && a.Item2==n1-1)
                {
                    T1Result.Text = "";
                }
                if (T1lastcoords.Item1 == a.Item1) T1LabelforOutput.Text += "F";
                if (T1lastcoords.Item2 == a.Item2) T1LabelforOutput.Text += "R";
                if (a.Item2 > 0) T1matrix[a.Item1, a.Item2 - 1] = true;
                if (a.Item1 < 4) T1matrix[a.Item1 + 1, a.Item2] = true;
                T1lastcoords = a;
            }
        }
    }
}