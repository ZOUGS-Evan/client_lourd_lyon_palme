using System;
using System.Windows.Forms;

namespace LyonPalme.Forms
{
    /// <summary>
    /// Auteur      : R. Fonseca
    /// Date        : 11/03/2026
    /// Description : Formulaire d'alerte générique (succès, erreur, confirmation).
    ///               Remplace les MessageBox standard pour un rendu cohérent.
    /// </summary>
    public partial class AlertForm : Form
    {
        public enum TypeAlerte { Succes, Erreur, Avertissement, Information }

        private readonly TypeAlerte _type;

        public AlertForm(string message, TypeAlerte type = TypeAlerte.Information, string titre = null)
        {
            InitializeComponent();
            _type = type;

            lblMessage.Text = message;

            switch (type)
            {
                case TypeAlerte.Succes:
                    lblIcone.Text = "✅";
                    this.Text = titre ?? "Succès";
                    pnlTop.BackColor = System.Drawing.Color.FromArgb(34, 139, 34);
                    lblTitre.Text = titre ?? "Succès";
                    break;
                case TypeAlerte.Erreur:
                    lblIcone.Text = "❌";
                    this.Text = titre ?? "Erreur";
                    pnlTop.BackColor = System.Drawing.Color.FromArgb(180, 30, 30);
                    lblTitre.Text = titre ?? "Erreur";
                    break;
                case TypeAlerte.Avertissement:
                    lblIcone.Text = "⚠️";
                    this.Text = titre ?? "Avertissement";
                    pnlTop.BackColor = System.Drawing.Color.FromArgb(200, 100, 0);
                    lblTitre.Text = titre ?? "Avertissement";
                    break;
                default:
                    lblIcone.Text = "ℹ️";
                    this.Text = titre ?? "Information";
                    pnlTop.BackColor = System.Drawing.Color.FromArgb(15, 32, 65);
                    lblTitre.Text = titre ?? "Information";
                    break;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // ── Méthodes statiques utilitaires ───────────────────────────

        public static void Succes(string message, System.Windows.Forms.IWin32Window owner = null)
        {
            new AlertForm(message, TypeAlerte.Succes).ShowDialog(owner);
        }

        public static void Erreur(string message, System.Windows.Forms.IWin32Window owner = null)
        {
            new AlertForm(message, TypeAlerte.Erreur).ShowDialog(owner);
        }

        public static void Avertissement(string message, System.Windows.Forms.IWin32Window owner = null)
        {
            new AlertForm(message, TypeAlerte.Avertissement).ShowDialog(owner);
        }

        public static void Info(string message, System.Windows.Forms.IWin32Window owner = null)
        {
            new AlertForm(message, TypeAlerte.Information).ShowDialog(owner);
        }
    }
}