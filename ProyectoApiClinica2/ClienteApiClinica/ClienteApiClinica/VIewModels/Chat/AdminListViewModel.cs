using ClienteApiClinica.Models;
using ClienteApiClinica.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ClienteApiClinica.VIewModels.Chat
{
    class AdminListViewModel: ViewModelBase
    {
        public ObservableCollection<Usuario> AdminsConectados { get; }

        private RepositoryClinica RepositoryClinica;

        public AdminListViewModel(RepositoryClinica repositoryClinica)
        {
            AdminsConectados = new ObservableCollection<Usuario>();
            RepositoryClinica = repositoryClinica;

           repositoryClinica.GetAdministradoresConectados().ContinueWith((task)=>
            {
                
                foreach (Usuario admin in task.Result)
                {
                    AdminsConectados.Add(admin);
                }
            });
        }
    }
}
