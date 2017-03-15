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
    public abstract class IconBase : UserControl
    {
        #region Image
        
        private Image _Image;

        public Image Image => _Image ?? (_Image = GetImage());

        public virtual Image GetImage()
        {
            return FindLogicalChildren<Image>(this).FirstOrDefault();
        }

        #endregion

        public static IEnumerable<T> FindLogicalChildren<T>(DependencyObject dependencyObject) where T : DependencyObject
        {
            if(dependencyObject != null)
            {
                foreach(var rawChild in LogicalTreeHelper.GetChildren(dependencyObject))
                {
                    if(rawChild is DependencyObject)
                    {
                        var child = (DependencyObject)rawChild;

                        if(child is T)
                        {
                            yield return (T)child;
                        }
                        else
                        {
                            foreach(T childOfChild in FindLogicalChildren<T>(child))
                            {
                                yield return childOfChild;
                            }
                        }
                    }
                    else
                    {
                    }
                }
            }
        }

        #region Drawings

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
        
        #endregion
    }
}
