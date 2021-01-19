using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueCounter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //if (AppStartup.AlreadyRegistered())
            //{
            //    Application.Run(new Main());
            //    return;
            //}
            var reg = new CounterRegistration();
            Application.Run(reg);

            if (reg.DialogResult == DialogResult.Yes)
            {
                Application.Run(new Main());
            }
        }
    }
}
