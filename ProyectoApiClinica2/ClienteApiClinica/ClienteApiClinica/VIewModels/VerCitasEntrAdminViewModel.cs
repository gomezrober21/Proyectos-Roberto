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
    public class VerCitasEntrAdminViewModel: ViewModelBase
    {
        RepositoryClinica repo;
        public VerCitasEntrAdminViewModel()
        {
            this.repo = new RepositoryClinica();
            Task.Run(async () =>
            {
                await this.CargarCitasEntrenamiento();
            });
        }

        private ObservableCollection<ConsultaEntrenamiento> _CitasEntrPersonal;
        public ObservableCollection<ConsultaEntrenamiento> CitasEntrPersonal
        {
            get { return this._CitasEntrPersonal; }
            set
            {
                this._CitasEntrPersonal = value;
                RaisePropertyChanged(() => CitasEntrPersonal);
            }
        }

        private async Task CargarCitasEntrenamiento()
        {
            List<ConsultaEntrenamiento> citas = await this.repo.GetConsultasEntrenamiento();
            this.CitasEntrPersonal = new ObservableCollection<ConsultaEntrenamiento>(citas);
        }

        public Command DetallesCitaFisio
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
