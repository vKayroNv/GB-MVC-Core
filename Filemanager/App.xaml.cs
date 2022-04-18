using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Autofac;

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
