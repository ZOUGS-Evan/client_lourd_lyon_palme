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
    /// Description : Formulaire d'enregistrement d'un nouveau prêt.
    ///               Une date de fin prévue optionnelle peut être définie :
    ///               si elle est dépassée sans retour, le prêt est considéré en retard.
    ///               Sans date de fin, la règle des 30 jours s'applique.
    /// </summary>
    public partial class PretForm : Form
    {
        private List<AdherentDTO> _adherents;
        private List<MaterielDTO> _materiels;

        public PretForm()
        {
            InitializeComponent();
        }

        private void PretForm_Load(object sender, EventArgs e)
        {
            // Date début
            dtpDateDebut.Value   = DateTime.Today;
            dtpDateDebut.MaxDate = DateTime.Today;

            // Date fin prévue — désactivée par défaut
            chkDateFin.Checked = false;
            dtpDateFin.Enabled = false;
            dtpDateFin.Value   = DateTime.Today.AddDays(30);
            dtpDateFin.MinDate = DateTime.Today.AddDays(1);

            lblInfoDateFin.Text = "Sans date de fin, le retard est calculé après 30 jours.";

            ChargerAdherents();
            ChargerMateriels();
        }

        // ── Gestion du checkbox date de fin ──────────────────────────

        private void chkDateFin_CheckedChanged(object sender, EventArgs e)
        {
            dtpDateFin.Enabled = chkDateFin.Checked;

            lblInfoDateFin.Text = chkDateFin.Checked
                ? "Le prêt sera en retard si non retourné avant cette date."
                : "Sans date de fin, le retard est calculé après 30 jours.";
        }

        private void dtpDateDebut_ValueChanged(object sender, EventArgs e)
        {
            // La date de fin ne peut pas être avant la date de début
            dtpDateFin.MinDate = dtpDateDebut.Value.AddDays(1);
            if (dtpDateFin.Value <= dtpDateDebut.Value)
                dtpDateFin.Value = dtpDateDebut.Value.AddDays(30);
        }

        // ── Chargement des données ────────────────────────────────────

        private void ChargerAdherents()
        {
            try
            {
                _adherents = DBInterface.GetAdherents();
                cboAdherent.Items.Clear();
                foreach (AdherentDTO a in _adherents)
                    cboAdherent.Items.Add(a.Nom + " " + a.Prenom +
                        (!string.IsNullOrEmpty(a.Role) ? " (" + a.Role + ")" : ""));
            }
            catch (Exception ex)
            {
                AfficherErreur("Erreur chargement adhérents : " + ex.Message);
            }
        }

        private void ChargerMateriels()
        {
            try
            {
                List<MaterielDTO> tous = DBInterface.GetStock();
                _materiels = new List<MaterielDTO>();
                cboMateriel.Items.Clear();

                foreach (MaterielDTO m in tous)
                {
                    if (m.Disponibilite == "Disponible" && m.Etat != "Hors service")
                    {
                        _materiels.Add(m);
                        cboMateriel.Items.Add(
                            m.Code + " — " + m.TypeMateriel + " " + m.Marque +
                            (m.TailleOuPointure != null ? " (" + m.TailleOuPointure + ")" : ""));
                    }
                }

                lblDispoCount.Text = _materiels.Count + " matériel(s) disponible(s)";
            }
            catch (Exception ex)
            {
                AfficherErreur("Erreur chargement matériels : " + ex.Message);
            }
        }

        // ── Affichage info matériel sélectionné ───────────────────────

        private void cboMateriel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMateriel.SelectedIndex < 0) return;
            MaterielDTO m = _materiels[cboMateriel.SelectedIndex];
            lblInfoMateriel.Text =
                m.TypeMateriel + " — " + m.Marque +
                " | Taille : " + (m.TailleOuPointure ?? "—") +
                " | État : " + m.Etat;
        }

        // ── Validation & enregistrement ───────────────────────────────

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (!Valider()) return;
            try
            {
                int idAdherent = _adherents[cboAdherent.SelectedIndex].Id;
                int idMateriel = _materiels[cboMateriel.SelectedIndex].Id;
                int nextId     = DBInterface.GetNextId("Pret");

                DateTime? dateFin = chkDateFin.Checked
                    ? dtpDateFin.Value.Date
                    : (DateTime?)null;

                DBInterface.EnregistrerPret(nextId, idMateriel, idAdherent,
                                            dtpDateDebut.Value.Date, dateFin);

                string msg = "Prêt enregistré avec succès !";
                if (dateFin.HasValue)
                    msg += "  Retour prévu le " + dateFin.Value.ToString("dd/MM/yyyy") + ".";

                AfficherSucces(msg);
                ChargerMateriels();
                cboMateriel.SelectedIndex = -1;
                cboAdherent.SelectedIndex = -1;
                lblInfoMateriel.Text      = string.Empty;
                chkDateFin.Checked        = false;
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
            if (cboAdherent.SelectedIndex < 0)
            { AfficherErreur("Sélectionnez un adhérent."); cboAdherent.Focus(); return false; }

            if (cboMateriel.SelectedIndex < 0)
            { AfficherErreur("Sélectionnez un matériel."); cboMateriel.Focus(); return false; }

            if (chkDateFin.Checked && dtpDateFin.Value.Date <= dtpDateDebut.Value.Date)
            {
                AfficherErreur("La date de fin prévue doit être postérieure à la date de début.");
                dtpDateFin.Focus();
                return false;
            }

            lblMessage.Text = string.Empty;
            return true;
        }

        private void AfficherErreur(string msg)
        { lblMessage.Text = msg; lblMessage.ForeColor = System.Drawing.Color.Crimson; }

        private void AfficherSucces(string msg)
        { lblMessage.Text = msg; lblMessage.ForeColor = System.Drawing.Color.ForestGreen; }
    }
}