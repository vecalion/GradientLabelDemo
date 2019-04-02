using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GradientLabelDemo.Extensions
{
    public static class ViewExtensions
    {
        public static Task<bool> ColorTo(this VisualElement self, string name, Color fromColor, Color toColor, Action<Color> callback, uint length = 250, Easing easing = null)
        {
            Color transform(double t) =>
              Color.FromRgba(fromColor.R + t * (toColor.R - fromColor.R),
                             fromColor.G + t * (toColor.G - fromColor.G),
                             fromColor.B + t * (toColor.B - fromColor.B),
                             fromColor.A + t * (toColor.A - fromColor.A));

            return ColorAnimation(self, name, transform, callback, length, easing);
        }

        public static void CancelAnimation(this VisualElement self, string name)
        {
            self.AbortAnimation(name);
        }

        static Task<bool> ColorAnimation(VisualElement element, string name, Func<double, Color> transform, Action<Color> callback, uint length, Easing easing)
        {
            easing = easing ?? Easing.Linear;
            var taskCompletionSource = new TaskCompletionSource<bool>();

            element.Animate<Color>(name, transform, callback, 16, length, easing, (v, c) => taskCompletionSource.SetResult(c));

            return taskCompletionSource.Task;
        }
    }
}
