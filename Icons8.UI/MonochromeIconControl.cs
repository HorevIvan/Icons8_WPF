using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Icons8.UI
{
    public abstract class MonochromeIconControl : IconControl
    {
        public virtual void FillColor(Color color)
        {
            foreach(var drawing in Drawings)
            {
                FillColor(drawing, color);
            }
        }

        private void FillColor(Drawing drawing, Color color)
        {
            if(drawing is GeometryDrawing)
            {
                FillColor(drawing as GeometryDrawing, color);
            }
            else
            {
            }
        }

        private void FillColor(GeometryDrawing drawing, Color color)
        {
            if(drawing.Brush != null)
            {
                drawing.Brush = FillColor(drawing.Brush, color);
            }

            if(drawing.Pen != null)
            {
                drawing.Pen = FillColor(drawing.Pen, color);
            }
        }

        private Pen FillColor(Pen pen, Color color)
        {
            var brush = FillColor(pen.Brush, color);

            return new Pen(brush, pen.Thickness);
        }

        private Brush FillColor(Brush brush, Color color)
        {
            if(brush is SolidColorBrush)
            {
                return new SolidColorBrush(color);
            }
            else
            {
                return brush;
            }
        }
    }
}
