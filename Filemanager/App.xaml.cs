using Autofac;
using System.Windows;

namespace Filemanager
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var builder = new ContainerBuilder();

            builder.RegisterFileManagerTypes();

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                scope.LinkDataContexts();
            }
        }
    }
}
