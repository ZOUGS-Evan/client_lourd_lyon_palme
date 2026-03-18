using System;
using System.Windows.Forms;
using LyonPalme.Models;

namespace LyonPalme.Forms
{
    /// <summary>
    /// Auteur      : R. Fonseca
    /// Date        : 11/03/2026
    /// Description : Formulaire de connexion.
    ///               Sécurise l'accès à l'application en demandant
    ///               un identifiant et un mot de passe au responsable matériel.
    /// </summary>
    public partial class ConnexionForm : Form
    {
        // ── Constantes ───────────────────────────────────────────────

        private const int MAX_TENTATIVES = 3;

        // ── État ─────────────────────────────────────────────────────

        private int _tentatives = 0;

        // ── Constructeur ─────────────────────────────────────────────

        public ConnexionForm()
        {
            InitializeComponent();
        }

        // ── Événements ───────────────────────────────────────────────

        private void ConnexionForm_Load(object sender, EventArgs e)
        {
            txtLogin.Focus();
        }

        /// <summary>Tenter la connexion au clic sur "Se connecter".</summary>
        private void btnConnecter_Click(object sender, EventArgs e)
        {
            TenterConnexion();
        }

        /// <summary>Permettre la connexion via la touche Entrée.</summary>
        private void txtMdp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                TenterConnexion();
        }

        private void txtLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtMdp.Focus();
        }

        /// <summary>Afficher/masquer le mot de passe.</summary>
        private void chkAfficherMdp_CheckedChanged(object sender, EventArgs e)
        {
            txtMdp.UseSystemPasswordChar = !chkAfficherMdp.Checked;
        }

        /// <summary>Quitter l'application.</summary>
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // ── Logique métier ───────────────────────────────────────────

        /// <summary>
        /// Valide les champs, tente la connexion via Gestion,
        /// ouvre GestionForm si succès, bloque après 3 échecs.
        /// </summary>
        private void TenterConnexion()
        {
            // Validation des champs
            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                AfficherErreur("Veuillez saisir votre identifiant.");
                txtLogin.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMdp.Text))
            {
                AfficherErreur("Veuillez saisir votre mot de passe.");
                txtMdp.Focus();
                return;
            }

            // Désactiver le bouton pendant la tentative
            btnConnecter.Enabled = false;
            lblMessage.Text = "Connexion en cours...";
            lblMessage.ForeColor = System.Drawing.Color.Gray;
            Application.DoEvents();

            try
            {
                bool succes = Gestion.getInstance().Connecter(
                    txtLogin.Text.Trim(),
                    txtMdp.Text
                );

                if (succes)
                {
                    // Succès → ouvrir GestionForm
                    OuvrirGestionForm();
                }
                else
                {
                    _tentatives++;
                    int restantes = MAX_TENTATIVES - _tentatives;

                    if (_tentatives >= MAX_TENTATIVES)
                    {
                        // Bloquer l'accès
                        AfficherErreur("Accès bloqué après " + MAX_TENTATIVES +
                                       " tentatives échouées.");
                        btnConnecter.Enabled = false;
                        txtLogin.Enabled = false;
                        txtMdp.Enabled = false;
                        chkAfficherMdp.Enabled = false;
                    }
                    else
                    {
                        AfficherErreur("Identifiant ou mot de passe incorrect. " +
                                       restantes + " tentative(s) restante(s).");
                        txtMdp.Clear();
                        txtMdp.Focus();
                        btnConnecter.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                AfficherErreur("Erreur de connexion : " + ex.Message);
                btnConnecter.Enabled = true;
            }
        }

        private void OuvrirGestionForm()
        {
            GestionForm gestionForm = new GestionForm();
            gestionForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            gestionForm.Show();
        }

        private void AfficherErreur(string message)
        {
            lblMessage.Text = message;
            lblMessage.ForeColor = System.Drawing.Color.Crimson;
        }
    }
}