using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProNatur_Biomarkt_GmbH
{
    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Responsible for Loading the entry screen
            //Application.Run(new LoadingScreen());
            //Application.Run(new ProductsScreen());
            Application.Run(new InvoiceScreen());
            //Application.Run(new LoadingScreen());
        }
    }
}
