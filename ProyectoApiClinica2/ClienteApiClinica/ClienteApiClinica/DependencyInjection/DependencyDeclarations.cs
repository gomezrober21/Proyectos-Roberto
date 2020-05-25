using Autofac;
using ClienteApiClinica.Managers;
using ClienteApiClinica.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteApiClinica.DependencyInjection
{
    static class DependencyDeclarations
    {

        public static IContainer BuildContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<RepositoryClinica>();
            builder.RegisterType<SignalRManager>().SingleInstance();

            return builder.Build();

        }

    }
}
