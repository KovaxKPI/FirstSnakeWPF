using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snake.GameEntities
{
    class Apple : GameEntity
    {
        public Apple(int size)
        {
            Ellipse rect = new Ellipse();
            rect.Width = size;
            rect.Height = size;
            rect.Fill = Brushes.Red;
            UIElement = rect;
        }
        public override bool Equals(object obj)
        {
            Apple apple = obj as Apple;
            if(apple != null)
            {
                return X == apple.X && Y == apple.Y;
            }
            else
            {
                return false;
            }
            
        }
    }
}
