namespace BerlinClockWpfApp
{
    using System.Windows;

    using Autofac;

    using BerlinClockWpfApp.ViewModel;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Methods

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var containerBuilder = new Autofac.ContainerBuilder();
            containerBuilder.RegisterType<MainViewModel>().As<IMainViewModel>();
            containerBuilder.RegisterType<MainWindow>().AsSelf();

            var container = containerBuilder.Build();
            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }

        #endregion
    }
}