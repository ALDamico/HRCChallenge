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

                Task.Run(InitMatrix);
                OnPropertyChanged(nameof(NumberOfSides));
            }
        }
        private DataTable matrix;
        public ObservableCollection<object> ValidationErrors { get; }

        public DataTable Matrix
        {
            get => matrix;
        }

        private async Task<bool> InitMatrix()
        {
            matrix = new DataTable();
            for (int i = 0; i < numberOfSides; i++)
            {
                matrix.Columns.Add(new DataColumn("Col" + (i + 1), typeof(int)));
            }
            var randomGenerator = new Random();
            for (int i = 0; i < numberOfSides; i++)
            {
                
                var randomValues = new object[numberOfSides];
                for (int j = 0; j < numberOfSides; j++)
                {
                    randomValues[j] = randomGenerator.Next() % 10;
                }
               
                matrix.Rows.Add(randomValues);
            }
            OnPropertyChanged(nameof(Matrix));
            return await Task.FromResult(true);
        }
    }
}
