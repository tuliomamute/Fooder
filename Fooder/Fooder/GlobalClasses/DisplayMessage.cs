using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooder.GlobalClasses
{
    public static class DisplayMessage
    {
        public static void DisplayMessageAlert(string titulo, string mensagem)
        {
            App.Current.MainPage.DisplayAlert(titulo, mensagem, "OK");

        }

    }
}
