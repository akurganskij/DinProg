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
    public partial class TabbedPage3 : TabbedPage
    {
        private static int m1 = 5, n1 = 5;
        private bool[,] T1matrix = new bool[5, 5];
        private int[,] T1nums = new int[5, 5];
        private Frame[,] frames = new Frame[m1, n1];
        Frame prevfrm = new Frame(), imfrm,tempframe = new Frame();
        private Tuple<int, int> T1lastcoords;
        private int T1res =0;
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

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

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
                if (T1lastcoords.Item1 == a.Item1) T1LabelforOutput.Text += "F";
                if (T1lastcoords.Item2 == a.Item2) T1LabelforOutput.Text += "R";
                if (a.Item2 > 0) T1matrix[a.Item1, a.Item2 - 1] = true;
                if (a.Item1 < 4) T1matrix[a.Item1 + 1, a.Item2] = true;
                T1lastcoords = a;
            }
        }
    }
}