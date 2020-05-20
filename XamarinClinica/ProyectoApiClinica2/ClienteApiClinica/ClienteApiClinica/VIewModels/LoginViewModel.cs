using ClienteApiClinica.Repositories;
using ClienteApiClinica.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ClienteApiClinica.Helpers;

namespace ClienteApiClinica.VIewModels
{
    public class LoginViewModel : ViewModelBase
    {
        RepositoryClinica repo;
        public LoginViewModel()
        {
            this.repo = new RepositoryClinica();
            NombreUsuario = Settings.Username;
            Password = Settings.Password;
        }
        public String NombreUsuario { get; set; }
        public String Password { get; set; }
        public ICommand ComandoLogin
        {
            get
            {
                return new Command(() =>
                {

                    var  jObject = this.repo.GetToken(NombreUsuario, Password);
                    Settings.ObtenerToken = jObject.ToString();

                });
            }
        }
    }
}
