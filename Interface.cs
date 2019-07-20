using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;
using System.Windows;

namespace ByteArithmetic
{
    class InterfaceClass
    {
        Thickness MarginGrid = new Thickness();
        public Grid ExG = new Grid();
        public void MarginLag(int L, int R, int B, int T)
        {
            //Выравнивание GRID
            MarginGrid.Left = L;
            MarginGrid.Right = R;
            MarginGrid.Bottom = B;
            MarginGrid.Top = T;
            ExG.Margin = (MarginGrid);
        }
    }
}