using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Icons8.UI
{
    public abstract class IconControl : UserControl
    {
        public virtual Image GetIconImage()
        {
            return (Image)VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(this, 0), 0), 0);
        }

        private Image _Image;

        public Image Image => _Image ?? (_Image = GetIconImage());

        private Drawing[] _Drawings;

        public Drawing[] Drawings => _Drawings ?? (_Drawings = GetDrawings(DrawingImage));

        public DrawingImage DrawingImage => (DrawingImage)Image.Source;

        public static Drawing[] GetDrawings(DrawingImage drawingImage)
        {
            if(drawingImage == null) return new Drawing[0];

            if(drawingImage.Drawing is DrawingGroup)
            {
                return GetDrawings(drawingImage.Drawing as DrawingGroup);
            }
            else if(drawingImage.Drawing is GeometryDrawing)
            {
                return GetDrawings(drawingImage.Drawing as DrawingGroup);
            }
            else
            {
            }

            return null;
        }

        public static Drawing[] GetDrawings(DrawingGroup drawingGroup)
        {
            if(drawingGroup == null) return new Drawing[0];

            var colors = new List<Color>();

            var drawings = new List<Drawing>();

            foreach(var drawing in drawingGroup.Children)
            {
                if(drawing is DrawingGroup)
                {
                     drawings.AddRange(GetDrawings(drawing as DrawingGroup));
                }
                else if(drawing is GeometryDrawing)
                {
                    drawings.Add(drawing as GeometryDrawing);
                }
                else
                {

                }
            }

            return drawings.ToArray();
        }
    }
}
