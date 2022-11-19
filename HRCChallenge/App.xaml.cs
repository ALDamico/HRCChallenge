using HRCChallenge.Configuration;
using HRCChallenge.Factories;
using HRCChallenge.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace HRCChallenge
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DispatcherUnhandledException += HandleException;

            ConfigureAppServices();
        }

        private void HandleException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }

        private void ConfigureAppServices()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IConfigurationReader>(sp => new JsonConfigurationReader("Data/app-configuration.json"));

            serviceCollection.AddSingleton(sp =>
            {
                var configurationReader = sp.GetRequiredService<IConfigurationReader>();
                var vm = MainWindowViewModelFactory.GetMainWindowViewModel(configurationReader.ReadConfiguration());
                return vm;
            });

            ServiceProvider = serviceCollection.BuildServiceProvider();
            
        }

        internal ServiceProvider ServiceProvider { get; private set; }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            
        }
    }
}
