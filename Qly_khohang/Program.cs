using System;
using System.Windows.Forms;

namespace Qly_Khohang
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
        }
    }
}
//taskkill / IM Qly_Khohang.exe / F
//taskkill / F / IM Qly_Khohang.exe
