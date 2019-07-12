using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hockey
{
    static class WorkWithMessage
    {
        /// <summary>
        /// Метод для вывода сообщения в MessageBox
        /// </summary>
        /// <param name="text">Строка для вывода</param>
        /// <returns>Выводит MessageBox</returns>
        public static void MessageBoxShow(string text)
        {
            MessageBox.Show(text);
        } 
    }
}
