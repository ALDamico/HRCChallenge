using HRCChallenge.Configuration;
using HRCChallenge.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRCChallenge.Factories
{
    internal static class MainWindowViewModelFactory
    {
        public static MainWindowViewModel GetMainWindowViewModel(AppConfiguration configuration)
        {
            var viewModel = new MainWindowViewModel();
            foreach (var matrixSize in configuration.MatrixSizes)
            {
                viewModel.AvailableMatrixSizes.Add(matrixSize);
            }
            viewModel.ServiceEndpoint = configuration.WebServiceEndpoint;
            return viewModel;
        }
    }
}
