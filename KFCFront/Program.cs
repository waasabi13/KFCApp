using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KFCFront
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            OpenFileDialog jsonFileDialog = new OpenFileDialog();
            jsonFileDialog.Filter = "JSON Files|*.json";
            if (jsonFileDialog.ShowDialog() != DialogResult.OK)
            {
                Application.Exit();
                return;
            }
            Application.Run(new FrontForm(jsonFileDialog.FileName));
        }
    }
}
