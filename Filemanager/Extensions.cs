using Autofac;
using Filemanager.Abstractions.Interfaces.Services;
using Filemanager.Abstractions.Interfaces.ViewModels;
using Filemanager.Core;

namespace Filemanager
{
    internal static class Extensions
    {
        public static void RegisterFileManagerTypes(this ContainerBuilder builder)
        {
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainWindowViewModel>().As<IMainWindowViewModel>().SingleInstance();

            builder.RegisterType<DataService>().As<IDataService>().AutoActivate();
        }

        public static void LinkDataContexts(this ILifetimeScope scope)
        {
            var window = scope.Resolve<MainWindow>();
            var context = scope.Resolve<IMainWindowViewModel>();

            window.DataContext = context;
            window.Show();
        }
    }
}
