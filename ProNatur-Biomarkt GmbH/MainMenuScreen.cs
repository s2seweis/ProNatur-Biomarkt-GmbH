using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProNatur_Biomarkt_GmbH
{
    public partial class MainMenuScreen : Form
    {
        public MainMenuScreen()
        {
            InitializeComponent();

            // Automatische Skalierung deaktivieren
            this.AutoScaleMode = AutoScaleMode.None;

            // Fester Randstil, um Größenänderungen zu verhindern
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Fenstergröße explizit festlegen
            this.Width = 800;
            this.Height = 600;

            // Verhindern, dass das Fenster maximiert wird
            this.MaximizeBox = false;
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            ProductsScreen productsScreen = new ProductsScreen();
            productsScreen.Show();

            this.Hide();
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            // Hier kannst du den Code einfügen, der ausgeführt werden soll,
            // wenn der Button "Rechnung" geklickt wird. Zum Beispiel:
            InvoiceScreen invoiceScreen = new InvoiceScreen();
            invoiceScreen.Show();

            this.Hide();
        }

    }
}
