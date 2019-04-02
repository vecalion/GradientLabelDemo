using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradientLabelDemo.Extensions;
using Xamarin.Forms;

namespace GradientLabelDemo
{
    public partial class MainPage : ContentPage
    {
        Random randonGen = new Random();

        public MainPage()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            for (int i = 0; i < 50; i++)
            {
                await Task.WhenAll(
                label.ColorTo("a1", label.TextColor1, GetRandomColor(), c => label.TextColor1 = c, 200),
                label.ColorTo("a2", label.TextColor2, GetRandomColor(), c => label.TextColor2 = c, 200));
            }
        }

        Color GetRandomColor()
        {
            return Color.FromRgb(randonGen.Next(255), randonGen.Next(255), randonGen.Next(255));
        }
    }
}
