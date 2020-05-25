using Autofac;
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

            return builder.Build();

        }

    }
}
