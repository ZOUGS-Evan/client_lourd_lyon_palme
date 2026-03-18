using System;
using System.Windows.Forms;

namespace LyonPalme
{
    /// <summary>
    /// Auteur      : R. Fonseca
    /// Date        : 11/03/2026
    /// Description : Point d'entrée de l'application LyonPalme.
    ///               Initialise l'application Windows Forms et
    ///               lance la fenêtre de connexion.
    /// </summary>
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.ConnexionForm());
        }
    }
}