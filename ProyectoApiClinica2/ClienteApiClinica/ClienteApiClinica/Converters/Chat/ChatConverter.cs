using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ClienteApiClinica.Converters.Chat
{
    class ChatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType.Equals(typeof(Color)))
            {
                if (parameter as String == "BackgroundColor")
                {
                    return (bool)value ? Color.Green : Color.White;

                }
                else if(parameter as String == "TextColor") { 
                    return (bool) value?Color.White:Color.DarkSlateGray;

                }

                //No parameter specified
                throw new Exception("No parameter specified");
            }
            else if(targetType.Equals(typeof(LayoutOptions)))
            {
                return (bool) value?LayoutOptions.Start:LayoutOptions.End;
            }
            throw new Exception("No type behavior found ");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
