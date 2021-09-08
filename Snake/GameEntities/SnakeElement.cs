using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snake.GameEntities
{
    class SnakeElement : GameEntity
    {
        public SnakeElement(int size)
        {
            Rectangle rect = new Rectangle();
            rect.Width = size;
            rect.Height = size;
            rect.Fill = Brushes.Green;
            UIElement = rect;
        }
        public bool isHead { get; set; }
    }
}
