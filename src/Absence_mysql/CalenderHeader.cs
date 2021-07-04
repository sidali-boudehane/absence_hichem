using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Absence
{
    class CalenderHeader:Label
    {
        public CalenderHeader(String text) : base(){
            this.Content = text;
            this.FontSize = 12;
            this.FontWeight = FontWeights.Bold;
            this.Foreground = new SolidColorBrush(Colors.White);
            this.Background = new SolidColorBrush(Color.FromRgb(0,0x78,0xD7)); 
            this.VerticalAlignment = VerticalAlignment.Stretch;
            this.VerticalContentAlignment = VerticalAlignment.Center;
            this.HorizontalContentAlignment = HorizontalAlignment.Center;
        }
    }
}
