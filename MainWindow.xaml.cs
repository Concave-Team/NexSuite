using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NexSuite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SolidColorBrush _BGColor { get { return new SolidColorBrush(Color.FromRgb(51, 51, 51)); } }
        public StringBuilder ErrorStream = new StringBuilder();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            Directory.CreateDirectory("logs");
            ErrorStream.AppendLine("Initializing Process...");
            CloseableTab _SPTabItem = new CloseableTab();
            _SPTabItem.Name = "StartPageTab";
            _SPTabItem.Title = "Start Page";
            TextAreaTabControl.Items.Add(_SPTabItem);
            _SPTabItem.Focus();

            TextAreaTabControl.SelectionChanged += CTabSelectedCallback;
        }

        private void CTabSelectedCallback(object sender, SelectionChangedEventArgs e)
        {
            if (TextAreaTabControl.SelectedItem is CloseableTab)
            {
                var tab = (CloseableTab)TextAreaTabControl.SelectedItem;
                if (tab.Name == "StartPageTab")
                {
                    tab.Content = new StartPageControl();
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            File.WriteAllText("logs/log-" + DateTimeOffset.Now.ToString() + ".txt", ErrorStream.ToString());
        }
    }
}
