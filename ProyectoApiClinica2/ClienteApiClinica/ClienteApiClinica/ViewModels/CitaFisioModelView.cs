using ClienteApiClinica.Helpers;
using ClienteApiClinica.Models;
using ClienteApiClinica.Repositories;
using ClienteApiClinica.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ClienteApiClinica.ViewModels
{
    public class CitaFisioModelView:ViewModelBase
    {
        public ConsultaFisio Cita { get; set; }
        RepositoryClinica RepositoryClinica;
        public CitaFisioModelView()
        {
            this.RepositoryClinica = new RepositoryClinica();
            this.Cita = new ConsultaFisio();
        }

        public Command InsertCita
        {
            get
            {
                return new Command(  () => {
                    
                    RepositoryClinica.CogerCitaFisio(
                        id: Cita.Id,
                        nombre: Cita.Nombre,
                        apellido: Cita.Apellido,
                        fecha: Cita.Fecha,
                        edad: Cita.Edad,
                        direccion: Cita.Direccion,
                        telefono: Cita.Telefono);
                });
            }
        }

        
    }
}
