using ClienteApiClinica.Models;
using ClienteApiClinica.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ClienteApiClinica.VIewModels
{
    //CLASE PARA COGER CITA DESDE ADMINISTRACION
    public class AdministracionCitaEntr
    {
        public ConsultaEntrenamiento Cita { get; set; }
        RepositoryClinica RepositoryClinica;
        public AdministracionCitaEntr()
        {
            this.RepositoryClinica = new RepositoryClinica();
            this.Cita = new ConsultaEntrenamiento();
        }

        public Command InsertCitaEntr
        {
            get
            {
                return new Command(() => {

                    RepositoryClinica.CogerCitaEntrenamiento(
                        id: Cita.Id,
                        nombre: Cita.Nombre,
                        apellido: Cita.Apellido,
                        fecha: Cita.Fecha,
                        edad: Cita.Edad,
                        telefono: Cita.Telefono);
                     Application.Current.MainPage.DisplayAlert("Alerta", "Entrenamiento Creado", "Ok");
                });
            }
        }


    }
}
