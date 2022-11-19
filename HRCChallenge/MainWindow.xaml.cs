using HRCChallenge.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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

namespace HRCChallenge
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as App;
            var mainWindowViewModel = app.ServiceProvider.GetRequiredService<MainWindowViewModel>();
            DataContext = mainWindowViewModel;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var sides = (int) e.AddedItems[0];
            //ReinitDataGrid(sides);
        }

        private void ReinitDataGrid(int sides)
        {
            mainWindowDataGrid.Columns.Clear();
            

            for (int i = 0; i < sides; i++)
            {
                //mainWindowDataGrid.Columns.Add(new DataGridTextColumn());
            }
        }
    }
}
