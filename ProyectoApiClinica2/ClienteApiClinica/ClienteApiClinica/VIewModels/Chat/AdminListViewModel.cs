using Autofac;
using ClienteApiClinica.Helpers;
using ClienteApiClinica.Managers;
using ClienteApiClinica.Models;
using ClienteApiClinica.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace ClienteApiClinica.ViewModels.Chat
{
    class AdminListViewModel: ViewModelBase
    {
        public ObservableCollection<Usuario> AdminsConectados { get; }

        private RepositoryClinica RepositoryClinica;
        private SignalRManager signalRManager;

        public AdminListViewModel()
        {
            AdminsConectados = new ObservableCollection<Usuario>();
            RepositoryClinica = App.container.Resolve<RepositoryClinica>();
            signalRManager = App.container.Resolve<SignalRManager>();

            LoadChatList();
        }

        private void LoadChatList()
        {
            //Si hay chat guardados, se añader a la lista

            if (signalRManager.ListaMensaje.Count > 0)
            {
                signalRManager.ListaMensaje.ForEach(pair => {

                    Usuario user = new Usuario()
                    {
                        NombreUsuario = pair.Key
                    };
                    AdminsConectados.Add(user);
                });
            }

            RepositoryClinica.GetAdministradoresConectados().ContinueWith((task) =>
            {

                foreach (Usuario admin in task.Result)
                {
                    if (
                        !(
                            // Si no es el si mimos
                            (Settings.Username == admin.NombreUsuario)
                            // O
                            ||
                            //si no hay ningun chat con ese usuario ya
                            AdminsConectados.Select(u => u.NombreUsuario).Contains(admin.NombreUsuario)
                        )
                        )
                    {
                        AdminsConectados.Add(admin);
                    }
                }
            });
        }
    }
}
