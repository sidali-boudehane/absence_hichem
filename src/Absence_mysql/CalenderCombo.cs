using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Absence
{
    class CalenderCombo:ComboBox
    {
        public CalenderCombo() : base()
        {
            this.Items.Add("");
            this.Items.Add("AO");
            this.Items.Add("O");
            this.Items.Add("AA");
            this.Items.Add("A");
            this.Items.Add("CM");
            this.Items.Add("CMLD");
            this.IsEditable = false;
            this.HorizontalAlignment = HorizontalAlignment.Stretch;
            this.HorizontalContentAlignment = HorizontalAlignment.Right;
            this.VerticalAlignment = VerticalAlignment.Stretch;
            this.VerticalContentAlignment = VerticalAlignment.Center;
            this.IsDropDownOpen = false;
            this.FontSize = 8;
            
            this.Padding = new Thickness(0);
          //  ToggleButton dropDownButton = GetFirstChildOfType<ToggleButton>(this);
            // dropDownButton.IsEnabled = false;

        }
    }
}
