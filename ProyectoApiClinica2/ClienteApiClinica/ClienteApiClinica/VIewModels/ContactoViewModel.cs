using ClienteApiClinica.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ClienteApiClinica.VIewModels
{
   public class ContactoViewModel: ViewModelBase
    {

        public ICommand ClickCommand
        {
            get
            {
                return new Command((url) => {

                    //Launcher.TryOpenAsync(new System.Uri(url as String));
                    Launcher.OpenAsync(new System.Uri(url as String));

                });
            }

        }
    }
}
