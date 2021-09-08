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
    class GameEntity
    {
       
        public UIElement UIElement { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
