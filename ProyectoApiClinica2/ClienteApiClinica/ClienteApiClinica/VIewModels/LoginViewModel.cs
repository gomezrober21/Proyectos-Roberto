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
using System.Linq;
using FisioXamarin.Views;
using ClienteApiClinica.Views;

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
        public String MensajeLogin { get; set; }
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
                        Settings.Username = this.NombreUsuario;
                        Settings.ObtenerToken = jObjecte.Token;
                        App.locator.container.Resolve<SignalRManager>().StartConnection();
                        await Application.Current.MainPage.DisplayAlert("Alerta", "Usuario Logeado", "Ok");
                        MessagingCenter.Send(this, "EventoLog");
                        
                        if (Navigation != null)
                        {
                            //bool PagRegistro = Navigation.NavigationStack.Any(p => p is PaginaRegistro);
                            List<Page> lista = Navigation.NavigationStack.ToList();
                            if (lista.Count>1)
                            {
                                Page penultima = lista.ElementAt(lista.Count - 2);
                                //Navigation.PopToRootAsync();
                                PaginaRegistro pagina = new PaginaRegistro();
                                //var item = Navigation.NavigationStack.Count;
                                //var pl = Navigation.NavigationStack.ElementAt(item - 1);
                                if (penultima.GetType() == typeof(PaginaRegistro))
                                {
                                    await Navigation.PopToRootAsync();
                                }
                                else
                                {
                                    await Navigation.PopAsync();
                                }
                            }
                            else
                            {
                                await Navigation.PopAsync();
                            }

                        }
                       
                    }
                    else
                    {
                        
                        MensajeLogin = "Usuario y Password incorrectos";
                        RaisePropertyChanged(() => MensajeLogin);
                    }
                });
            }
        }
    }
}
