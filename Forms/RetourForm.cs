using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LyonPalme.DataAccess;
using LyonPalme.Models;

namespace LyonPalme.Forms
{
    /// <summary>
    /// Auteur      : R. Fonseca
    /// Date        : 11/03/2026
    /// Description : Formulaire d'enregistrement d'un retour de matériel.
    /// </summary>
    public partial class RetourForm : Form
    {
        private readonly DBInterface _db = new DBInterface();
        private readonly Gestion _gestion = Gestion.getInstance();
        private List<PretEnCoursDTO> _prets;

        public RetourForm()
        {
            InitializeComponent();
        }

        private void RetourForm_Load(object sender, EventArgs e)
        {
            dtpDateRetour.Value = DateTime.Today;
            dtpDateRetour.MaxDate = DateTime.Today;

            cboEtat.Items.AddRange(Retour.EtatsPossibles);
            cboEtat.SelectedIndex = 0;

            ChargerPretsEnCours();
        }

        private void ChargerPretsEnCours()
        {
            try
            {
                _prets = _gestion.GetPretsEnCours();
                cboPret.Items.Clear();

                foreach (PretEnCoursDTO p in _prets)
                {
                    int jours = (DateTime.Today - p.DateDebut).Days;
                    cboPret.Items.Add(
                        "#" + p.IdPret + " — " + p.Nom + " " + p.Prenom +
                        " / " + p.Code + " " + p.Marque +
                        " (depuis " + jours + "j)");
                }

                lblPretsCount.Text = _prets.Count + " prêt(s) en cours";

                if (_prets.Count == 0)
                    AfficherErreur("Aucun prêt en cours à ce jour.");
            }
            catch (Exception ex)
            {
                AfficherErreur("Erreur : " + ex.Message);
            }
        }

        private void cboPret_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPret.SelectedIndex < 0) return;

            PretEnCoursDTO p = _prets[cboPret.SelectedIndex];
            int jours = (DateTime.Today - p.DateDebut).Days;

            lblInfoPret.Text = "Adhérent : " + p.Nom + " " + p.Prenom +
                               " | Matériel : " + p.Code + " " + p.Marque +
                               " | Début : " + p.DateDebut.ToString("dd/MM/yyyy") +
                               " (" + jours + " jour(s))";

            if (jours > 30)
            {
                lblInfoPret.ForeColor = System.Drawing.Color.Crimson;
                lblRetard.Visible = true;
                lblRetard.Text = "⚠ Prêt en retard de " + (jours - 30) + " jour(s)";
            }
            else
            {
                lblInfoPret.ForeColor = System.Drawing.Color.FromArgb(15, 32, 65);
                lblRetard.Visible = false;
            }
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (!Valider()) return;

            try
            {
                int idPret = _prets[cboPret.SelectedIndex].IdPret;
                int nextId = _db.GetNextId("Retour");

                _db.EnregistrerRetour(nextId, idPret,
                    cboEtat.SelectedItem.ToString(),
                    dtpDateRetour.Value.Date);

                AfficherSucces("Retour enregistré avec succès !");
                ChargerPretsEnCours();
                cboPret.SelectedIndex = -1;
                cboEtat.SelectedIndex = 0;
                lblInfoPret.Text = string.Empty;
                lblRetard.Visible = false;
            }
            catch (Exception ex)
            {
                AfficherErreur("Erreur : " + ex.Message);
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Valider()
        {
            if (cboPret.SelectedIndex < 0)
            { AfficherErreur("Sélectionnez un prêt."); cboPret.Focus(); return false; }
            if (cboEtat.SelectedIndex < 0)
            { AfficherErreur("Sélectionnez l'état du matériel."); cboEtat.Focus(); return false; }
            lblMessage.Text = string.Empty;
            return true;
        }

        private void AfficherErreur(string msg)
        { lblMessage.Text = msg; lblMessage.ForeColor = System.Drawing.Color.Crimson; }

        private void AfficherSucces(string msg)
        { lblMessage.Text = msg; lblMessage.ForeColor = System.Drawing.Color.ForestGreen; }
    }
}