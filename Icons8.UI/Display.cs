using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Icons8.UI;

namespace Icons8
{
    public static class Display
    {
        #region Color

        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.RegisterAttached("Color", typeof(Color), typeof(MonochromeIcon),
                new FrameworkPropertyMetadata(MonochromeIcon.DefaultColor, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(ColorChanged)));

        private static void ColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as MonochromeIcon).FillColor((Color)e.NewValue);
        }

        public static void SetColor(UIElement element, Color value)
        {
            element.SetValue(ColorProperty, value);
        }

        public static Color GetColor(UIElement element)
        {
            return (Color)element.GetValue(ColorProperty);
        }

        #endregion
    }
}
