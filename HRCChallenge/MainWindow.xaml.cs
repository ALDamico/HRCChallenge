using HRCChallenge.Validation;
using HRCChallenge.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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

        private MainWindowViewModel GetViewModel()
        {
            return DataContext as MainWindowViewModel;
        }

        private void calculateDeterminantButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = GetViewModel();
            if (!viewModel.CanCallWebService())
            {
                MessageBox.Show("Unable to calculate determinant");
                return;
            }
            viewModel.CalculateDeterminant();
        }

        private void filterValuesButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = GetViewModel();
            if (!viewModel.CanCallWebService())
            {
                MessageBox.Show("Unable to filter values");
                return;
            }

            viewModel.FilterValues();
        }

        private void CopyCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = false;
            var viewModel = GetViewModel();
            viewModel.ClearCopyBuffer();
        }

        private void CopyCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            
        }

        private void PasteCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            var viewModel = GetViewModel();

            var firstX = dataGrid.Items.IndexOf(dataGrid.SelectedCells.First().Item);
            var firstY = dataGrid.SelectedCells.First().Column.DisplayIndex;

            var lastX = dataGrid.Items.IndexOf(dataGrid.SelectedCells.Last().Item);
            var lastY = dataGrid.SelectedCells.Last().Column.DisplayIndex;
            viewModel.PasteRows(firstX, firstY, lastX, lastY);

            
            
        }

        private void PasteCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void mainWindowDataGrid_CopyingRowClipboardContent(object sender, DataGridRowClipboardEventArgs e)
        {
            var viewModel = GetViewModel();
            
            viewModel.AddRowToCopyBuffer(e.ClipboardRowContent, e.StartColumnDisplayIndex, e.EndColumnDisplayIndex);

            Debug.WriteLine("Called");

        }

        public static readonly RoutedUICommand customCopyCommand = new RoutedUICommand();

        private void mainWindowDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void mainWindowDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            var selectedCells = dataGrid.SelectedCells;
            if (selectedCells.Count > 1)
            {
                var editedTextBox = e.EditingElement as TextBox;
                if (editedTextBox != null)
                {
                    var value = editedTextBox.Text;
                    foreach (var cell in selectedCells)
                    {
                        var columnIndexToUpdate = cell.Column.DisplayIndex;
                        var dataRowView = cell.Item as DataRowView;
                        var dataRow = dataRowView.Row as DataRow;

                        dataRow[columnIndexToUpdate] = Convert.ToInt32(value);
                    }
                }
            }
        }

        private void mainWindowDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            var viewModel = GetViewModel();
            if (e.AddedCells.Count > 1)
            {
                viewModel.UpdateSelectedCells(e.AddedCells);
                return;
            }

            viewModel.UpdateSelectedCells(null);
        }
    }
}
