using Microsoft.Extensions.DependencyInjection;
using RootFinder.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RootFinder
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IServiceProvider m_serviceProvider;

        public static IServiceProvider ServiceProvider
        {
            get 
            {
                if(m_serviceProvider == null)
                    m_serviceProvider = InitServices().BuildServiceProvider();

                return m_serviceProvider;
            }
        }

        private static IServiceCollection InitServices()
        { 
            var services = new ServiceCollection();

            services.AddSingleton<MainWindowViewModel>();

            services.AddSingleton(c =>
            {
                var viewModel = c.GetRequiredService<MainWindowViewModel>();

                var window = new MainWindow();

                viewModel.OnDrawPlotButtonPressedEvent += window.DrawButtonPressed;


                window.Closed += (object s, EventArgs e) =>
                {
                    viewModel.OnDrawPlotButtonPressedEvent -= window.DrawButtonPressed;
                };
                window.DataContext = viewModel;
                viewModel.Dispatcher = window.Dispatcher;

                return window;
            });

            return services;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var window = ServiceProvider.GetRequiredService<MainWindow>();

            window.Show();
        }
    }
}
