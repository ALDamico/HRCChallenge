using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    }
}
