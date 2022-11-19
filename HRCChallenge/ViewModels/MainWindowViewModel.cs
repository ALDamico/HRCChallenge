using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRCChallenge.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            AvailableMatrixSizes = new ObservableCollection<MatrixSizeViewModel>();
            ValidationErrors = new ObservableCollection<object>();
        }
        public ObservableCollection<MatrixSizeViewModel> AvailableMatrixSizes { get; }
        private string serviceEndpoint;
        public string ServiceEndpoint
        {
            get { return serviceEndpoint; }
            set
            {
                serviceEndpoint = value;
                OnPropertyChanged(nameof(ServiceEndpoint));
            }
        }

        private int numberOfSides;
        public int NumberOfSides
        {
            get => numberOfSides;
            set
            {
                numberOfSides = value;
                
                matrix = new DataTable();
                for (int i = 0; i < numberOfSides; i++)
                {
                    matrix.Columns.Add(new DataColumn("Col" + (i + 1), typeof(int)));
                }

                for (int i = 0; i < numberOfSides; i++)
                {
                    matrix.Rows.Add();
                }
                OnPropertyChanged(nameof(NumberOfSides));
                OnPropertyChanged(nameof(Matrix));
            }
        }
        private DataTable matrix;
        public ObservableCollection<object> ValidationErrors { get; }

        public DataTable Matrix
        {
            get => matrix;
           
        }
    }
}
