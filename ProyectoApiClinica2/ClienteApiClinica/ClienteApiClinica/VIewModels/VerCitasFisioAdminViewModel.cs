using ClienteApiClinica.Models;
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
    public class VerCitasFisioAdminViewModel:ViewModelBase
    {
        RepositoryClinica repo;
        public VerCitasFisioAdminViewModel()
        {
            this.repo = new RepositoryClinica();
            Task.Run(async () =>
            {
                await this.CargarCitasFisio();
            });
        }

        private ObservableCollection<ConsultaFisio> _CitasFisio;
        public ObservableCollection<ConsultaFisio> CitasFisio
        {
            get { return this._CitasFisio; }
            set
            {
                this._CitasFisio = value;
                RaisePropertyChanged(() => CitasFisio);
            }
        }

        private async Task CargarCitasFisio()
        {
            List<ConsultaFisio> citas = await this.repo.GetConsultas();
            this.CitasFisio = new ObservableCollection<ConsultaFisio>(citas);
        }


        public Command DetallesUsuario
        {
            get
            {
                return new Command(async (apuesta) =>
                {
                    //DetallesApuestaViewModel viewmodel = App.Locator.DetallesApuestaViewModel;
                    //viewmodel.Apuesta = apuesta as Apuesta;
                    //DetallesApuestasView view = new DetallesApuestasView();
                    //view.BindingContext = viewmodel;
                    //await Application.Current.MainPage.Navigation.PushModalAsync(view);
                });
            }
        }
    }
}
