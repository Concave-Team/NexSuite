using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace NexSuite
{
    public class CloseableTab : TabItem
    {
        CloseableHeader closeableTabHeader;
        public string Title
        {
            set
            {
                ((CloseableHeader)this.Header).Label_TabText.Content = value;
            }
        }

        protected override void OnSelected(RoutedEventArgs e)
        {
            base.OnSelected(e);
            ((CloseableHeader)this.Header).Button_Exit.Visibility = Visibility.Visible;
        }

        protected override void OnUnselected(RoutedEventArgs e)
        {
            base.OnUnselected(e);
            ((CloseableHeader)this.Header).Button_Exit.Visibility = Visibility.Hidden;
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            ((CloseableHeader)this.Header).Button_Exit.Visibility = Visibility.Visible;
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            if (!this.IsSelected)
            {
                ((CloseableHeader)this.Header).Button_Exit.Visibility = Visibility.Hidden;
            }
        }

        // Button MouseEnter - When the mouse is over the button - change color to Red
        void button_close_MouseEnter(object sender, MouseEventArgs e)
        {
            ((CloseableHeader)this.Header).Button_Exit.Foreground = Brushes.Red;
        }
        // Button MouseLeave - When mouse is no longer over button - change color back to black
        void button_close_MouseLeave(object sender, MouseEventArgs e)
        {
            ((CloseableHeader)this.Header).Button_Exit.Foreground = Brushes.Black;
        }
        // Button Close Click - Remove the Tab - (or raise
        // an event indicating a "CloseTab" event has occurred)
        void button_close_Click(object sender, RoutedEventArgs e)
        {
            ((TabControl)this.Parent).Items.Remove(this);
        }
        // Label SizeChanged - When the Size of the Label changes
        // (due to setting the Title) set position of button properly
        void label_TabTitle_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
        }

        public CloseableTab()
        {
            // Create an instance of the usercontrol
            closeableTabHeader = new CloseableHeader();
            // Assign the usercontrol to the tab header
            this.Header = closeableTabHeader;

            closeableTabHeader.Button_Exit.MouseEnter +=
            new MouseEventHandler(button_close_MouseEnter);
            closeableTabHeader.Button_Exit.MouseLeave +=
               new MouseEventHandler(button_close_MouseLeave);
            closeableTabHeader.Button_Exit.Click +=
               new RoutedEventHandler(button_close_Click);
            closeableTabHeader.Label_TabText.SizeChanged +=
               new SizeChangedEventHandler(label_TabTitle_SizeChanged);
        }
    }
}
