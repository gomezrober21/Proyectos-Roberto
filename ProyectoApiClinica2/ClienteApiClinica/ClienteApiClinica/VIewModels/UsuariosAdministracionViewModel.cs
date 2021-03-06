﻿using ClienteApiClinica.Models;
using ClienteApiClinica.Repositories;
using ClienteApiClinica.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ClienteApiClinica.VIewModels
{
    public class UsuariosAdministracionViewModel: ViewModelBase
    {
        RepositoryClinica repo;
        public UsuariosAdministracionViewModel()
        {
            this.repo = new RepositoryClinica();
            Task.Run(async () =>
            {
                await this.CargarUsuarios();
            });
        }

        private ObservableCollection<Usuario> _Usuarios;
        public ObservableCollection<Usuario> Usuarios
        {
            get { return this._Usuarios; }
            set
            {
                this._Usuarios = value;
                RaisePropertyChanged(() => Usuarios);
            }
        }

        private async Task CargarUsuarios()
        {
            List<Usuario> users = await this.repo.GetUsuarios();
            this.Usuarios = new ObservableCollection<Usuario>(users);
        }

        public Command EliminarUsuario
        {
            get
            {
                return new Command(async (nombreusu) =>
                {
                    await repo.EliminarUsuario(nombreusu as String);
                    await Application.Current.MainPage.DisplayAlert("Alerta", "Usuario eliminada", "Ok");
                    this.CargarUsuarios();
                });
            }
        }
    }
}
