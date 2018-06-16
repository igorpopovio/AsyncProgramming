using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace AsyncProgramming
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int count;
        private void ShortTaskButton_Click(object sender, RoutedEventArgs e)
        {
            ShortTaskTextBlock.Text = $"{++count}";
        }

        private async void LongTaskButton_Click(object sender, RoutedEventArgs e)
        {
            LongTaskButton.IsEnabled = false;
            LongTaskTextBlock.Text = "Starting long tasks";

            var firstLongTask = Task.Run(() =>
            {
                Thread.Sleep(1000);
                return "first";
            });

            var secondLongTask = Task.Run(() =>
            {
                Thread.Sleep(2000);
                return "second";
            });

            var thirdLongTask = Task.Run(() =>
            {
                Thread.Sleep(500);
                return "third";
            });

            var results = await Task.WhenAll(firstLongTask, secondLongTask, thirdLongTask);

            LongTaskButton.IsEnabled = true;
            LongTaskTextBlock.Text = "Completed " + string.Join(", ", results) + " tasks";
        }
    }
}
