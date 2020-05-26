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
                return new Command(() =>
                {
                    if (NombreUsuario == "adealba")
                    {
                        Settings.Role = "administrador";
                    }
                    var jObjecte = this.repo.GetToken(NombreUsuario, Password);
                    Settings.ObtenerToken = jObjecte.ToString();
                    if (Navigation != null)
                    {
                        Navigation.PopAsync();
                    }

                });
            }
        }
    }
}
