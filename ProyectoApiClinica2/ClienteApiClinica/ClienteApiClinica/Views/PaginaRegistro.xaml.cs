using ClienteApiClinica.UtilitiesValidators;
using ClienteApiClinica.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FisioXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaRegistro : ContentPage
    {
        public PaginaRegistro()
        {
            InitializeComponent();
            BontonRegistrar.IsEnabled = false;
            
        }

       

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
       {
            if (RegexUtilities.IsEmailValid(Email.Text))
            {
                ErrorEmail.Text = "";
               
            }
            else
            {
                ErrorEmail.IsVisible = true;
                ErrorEmail.Text = "Email inválido";
            }
            isFormValid();
        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (RegexUtilities.IsPasswordValid(Password.Text))
            {
                ErrorPassword.Text = "";
                
            }
            else
            {
                ErrorPassword.IsVisible = true;
                ErrorPassword.Text = "Debe contener 1 número,\n" + "1 minúscula,\n" + "1 mayúscula,\n" +"longitud 8 a 15";
            }
            isFormValid();
        }

        private void NombreUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (RegexUtilities.IsNickNameValid(NombreUsuario.Text))
            {
                ErrorNombreUsuario.Text = "";
              
            }
            else
            {
                ErrorNombreUsuario.IsVisible = true;
                ErrorNombreUsuario.Text = "Entre 2 a 30 caracteres";
            }
            isFormValid();
        }

        private void Nombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (RegexUtilities.IsNameValid(Nombre.Text))
            {
                ErrorNombre.Text = "";
              
            }
            else
            {
                ErrorNombre.IsVisible = true;
                ErrorNombre.Text = "No contener símbolos ni números";
            }
            isFormValid();
        }

        private void Apellido_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (RegexUtilities.IsLastName(Apellido.Text))
            {
                ErrorApellido.Text = "";
                


            }
            else
            {
                ErrorApellido.IsVisible = true;
                ErrorApellido.Text = "No contener símbolos ni números";
            }
            isFormValid();
        }

        private void Edad_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (RegexUtilities.IsRangeAge(Edad.Text))
            {
                ErrorEdad.Text = "";
                
            }
            else
            {
                ErrorEdad.IsVisible = true;
                ErrorEdad.Text = "Rango entre 17 a 120";
            }
            isFormValid();
        }

        private void Telefono_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (RegexUtilities.IsPhoneValid(Telefono.Text))
            {
                ErrorTelefono.Text = "";
            }
            else
            {
                ErrorTelefono.IsVisible = true;
                ErrorTelefono.Text = "Debe contener 9 números";
            }
            isFormValid();
        }

        private void botonValidator_Clicked(object sender, EventArgs e)
        {


          
        }
        private void  isFormValid()
        {

            if (RegexUtilities.IsEmailValid(Email.Text)
                    && RegexUtilities.IsPasswordValid(Password.Text)
                    && RegexUtilities.IsNickNameValid(NombreUsuario.Text)
                    && RegexUtilities.IsNameValid(Nombre.Text)
                    && RegexUtilities.IsLastName(Apellido.Text)
                    && RegexUtilities.IsRangeAge(Edad.Text)
                    && RegexUtilities.IsPhoneValid(Telefono.Text))
            {
                BontonRegistrar.IsEnabled = true;

                BontonRegistrar.BackgroundColor = Color.Green;
            }
            else
            {
                BontonRegistrar.IsEnabled = false;
                BontonRegistrar.BackgroundColor = Color.Gray;
            }
        }
    }
}