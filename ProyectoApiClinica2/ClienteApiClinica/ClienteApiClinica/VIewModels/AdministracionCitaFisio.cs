using ClienteApiClinica.Models;
using ClienteApiClinica.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ClienteApiClinica.VIewModels
{
    //CLASE PARA COGER CITA DESDE ADMINISTRACION
    public class AdministracionCitaFisio
    {
        public ConsultaFisio Cita { get; set; }
        RepositoryClinica RepositoryClinica;
        public AdministracionCitaFisio()
        {
            this.RepositoryClinica = new RepositoryClinica();
            this.Cita = new ConsultaFisio();
        }

        public Command InsertCita
        {
            get
            {
                return new Command(() => {

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
