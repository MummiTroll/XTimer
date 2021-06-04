using System.Windows.Controls;
using System.Windows;

namespace Timer2
{
    public class MyLabel : Label
    {
        public MyLabel()
        {
            Width = 100;
            Height = 22;
            FontSize = 11;
            VerticalContentAlignment = VerticalAlignment.Center;
            HorizontalContentAlignment = HorizontalAlignment.Left;
            HorizontalAlignment = HorizontalAlignment.Center;
            VerticalAlignment = VerticalAlignment.Top;
            Margin = new Thickness(5, 0, 0, 0);
        }
    }
}