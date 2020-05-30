using ClienteApiClinica.Repositories;
using ClienteApiClinica.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ClienteApiClinica.Helpers;
using Autofac;
using ClienteApiClinica.Managers;
using ClienteApiClinica.Models;

namespace ClienteApiClinica.VIewModels
{
    public class LoginViewModel : ViewModelBase
    {
        RepositoryClinica repo;
        public LoginViewModel()
        {
            //this.repo = App.container.Resolve<RepositoryClinica>();

            this.repo = new RepositoryClinica();

            NombreUsuario = Settings.Username;
            Password = Settings.Password;
        }
        public String NombreUsuario { get; set; }
        public String Password { get; set; }
        public INavigation Navigation { get; set; }
        public ICommand ComandoLogin
        {
            get
            {
                return new Command(async() =>
                {
                   
                    InformacionDeLogin jObjecte = await this.repo.GetToken(NombreUsuario, Password);

                    if (jObjecte != null)
                    {
                        Settings.Role = jObjecte.Rol;
                        Settings.ObtenerToken = jObjecte.Token;
                        if (Navigation != null)
                        {

                            await  Navigation.PopAsync();
                        }

                        MessagingCenter.Send(this, "EventoLog");
                    }

                });
            }
        }
    }
}
