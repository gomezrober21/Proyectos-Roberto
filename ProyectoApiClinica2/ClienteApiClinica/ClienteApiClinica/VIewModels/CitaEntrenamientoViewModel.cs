using ClienteApiClinica.Models;
using ClienteApiClinica.Repositories;
using ClienteApiClinica.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ClienteApiClinica.VIewModels
{
   public class CitaEntrenamientoViewModel: ViewModelBase
    {
        RepositoryClinica repo;
        public CitaEntrenamientoViewModel()
        {
            this.repo = new RepositoryClinica();
            this.ConsultaEntrenamiento = new ConsultaEntrenamiento();
        }

        private ConsultaEntrenamiento _ConsultaEntrenamiento { get; set; }
        public ConsultaEntrenamiento ConsultaEntrenamiento
        {
            get
            {
                return this._ConsultaEntrenamiento;
            }
            set
            {
                this._ConsultaEntrenamiento = value;
                RaisePropertyChanged(() => ConsultaEntrenamiento);
            }
        }

        public Command CrearEntrenamiento
        {
            get
            {
                return new Command(async() => {

                    await this.repo.CogerCitaEntrenamiento(ConsultaEntrenamiento.Id,
                        ConsultaEntrenamiento.Nombre, 
                        ConsultaEntrenamiento.Apellido,
                        ConsultaEntrenamiento.Fecha,
                        ConsultaEntrenamiento.Edad,
                        ConsultaEntrenamiento.Telefono);
                   await Application.Current.MainPage.DisplayAlert("Alerta", "Entrenamiento Creado", "Ok");
                });
            }
        }
    }
          

    
}
