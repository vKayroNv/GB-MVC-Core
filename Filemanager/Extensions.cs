using Autofac;

namespace Filemanager
{
    internal static class Extensions
    {
        public static void RegisterFileManagerTypes(this ContainerBuilder builder)
        {
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainWindowViewModel>().AsSelf();
        }

        public static void LinkDataContexts(this ILifetimeScope scope)
        {
            var window = scope.Resolve<MainWindow>();
            var context = scope.Resolve<MainWindowViewModel>();

            window.DataContext = context;
            window.Show();
        }
    }
}
