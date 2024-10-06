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
    public partial class LoadingScreen : Form
    {
        private int loadingBarValue;

        public LoadingScreen()
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

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            loadingbarTimer.Start();
        }

        private void loadingbarTimer_Tick(object sender, EventArgs e)
        {
            loadingBarValue += 1;

            lblLoadingProgress.Text = loadingBarValue.ToString() + "%";
            loadingProgressbar.Value = loadingBarValue;

            if (loadingBarValue >= loadingProgressbar.Maximum)
            {
                loadingbarTimer.Stop();

                // Nach dem Laden das Hauptmenü anzeigen
                MainMenuScreen mainMenuScreen = new MainMenuScreen();
                mainMenuScreen.Show();

                this.Hide();
            }
        }
    }
}
