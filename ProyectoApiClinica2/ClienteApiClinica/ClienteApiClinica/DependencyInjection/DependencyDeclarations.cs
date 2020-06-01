using Autofac;
using ClienteApiClinica.Managers;
using ClienteApiClinica.Repositories;
using ClienteApiClinica.VIewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteApiClinica.DependencyInjection
{
    public class DependencyDeclarations
    {

        public IContainer container;

        public DependencyDeclarations()
        {
            this.RegisterDependencies();
        }


        public void RegisterDependencies()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<RepositoryClinica>();
            builder.RegisterType<LogOutViewModel>();
            builder.RegisterType<SignalRManager>().SingleInstance();

            this.container = builder.Build();
        }
        public LogOutViewModel logOutViewModel
        {
            get
            {
                return this.container.Resolve<LogOutViewModel>();
            }
        }
    }
}
