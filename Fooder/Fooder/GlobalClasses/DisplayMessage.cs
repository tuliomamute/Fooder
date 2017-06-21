using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fooder.GlobalClasses
{
    /// <summary>
    /// Classe para exibição de mensagens
    /// </summary>
    public static class DisplayMessage
    {
        //Exibição de alerta
        public static void DisplayMessageAlert(string titulo, string mensagem)
        {
            App.Current.MainPage.DisplayAlert(titulo, mensagem, "OK");

        }

        //Exibição de mensagem de confirmação
        public async static Task<bool> DisplayQuestionAlert(string titulo, string mensagem, string textosim, string textonao)
        {
            return await App.Current.MainPage.DisplayAlert(titulo, mensagem, textosim, textonao);
        }

    }
}
