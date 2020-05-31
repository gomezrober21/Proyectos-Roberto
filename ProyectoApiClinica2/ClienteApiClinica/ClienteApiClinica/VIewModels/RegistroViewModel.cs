
﻿using ClienteApiClinica.Repositories;
using System;

using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ClienteApiClinica.Helpers;
using System.ComponentModel;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace ClienteApiClinica.ViewModels
{
 public  class RegistroViewModel: ViewModelBase
    {

        RepositoryClinica repo;
       public RegistroViewModel()
        {
            this.repo = new RepositoryClinica();
        }
       
      
        public String Email { get; set; }
        
        public String Contrasena { get; set; }       
        public String NombreUsuario { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public int Edad { get; set; }
        public int Telefono { get; set; }
        public String Mensaje { get; set; }
        public ICommand ComandoRegistro
        {
            get
            {
                return new Command( ()  =>
                {
                    
                    var insertado =   this.repo.RegistrarUsuario(NombreUsuario, Contrasena, Nombre, Apellido, Edad, Telefono, Email);

                    
                    Mensaje = "Es incorecto";
                    
                    Settings.Username = NombreUsuario;
                    Settings.Password = Contrasena;
                    Application.Current.MainPage.DisplayAlert("Alerta", "Usuario Registrado"
                        , "OK");

                });
            }
        }

        public bool HasErrors => throw new NotImplementedException();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }
    }
}
