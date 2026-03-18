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
    /// </summary>
    public partial class PretForm : Form
    {
        private readonly Gestion _gestion = Gestion.getInstance();
        private readonly DBInterface _db = new DBInterface();

        private List<AdherentDTO> _adherents;
        private List<MaterielDTO> _materiels;

        public PretForm()
        {
            InitializeComponent();
        }

        private void PretForm_Load(object sender, EventArgs e)
        {
            dtpDateDebut.Value = DateTime.Today;
            dtpDateDebut.MaxDate = DateTime.Today;

            ChargerAdherents();
            ChargerMateriels();
        }

        private void ChargerAdherents()
        {
            try
            {
                _adherents = _gestion.GetAdherents();
                cboAdherent.Items.Clear();
                foreach (AdherentDTO a in _adherents)
                    cboAdherent.Items.Add(a.Nom + " " + a.Prenom + " (" + (a.Role ?? "—") + ")");
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
                // Charger uniquement les matériels disponibles
                List<MaterielDTO> tous = _gestion.GetStock();
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

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (!Valider()) return;

            try
            {
                int idAdherent = _adherents[cboAdherent.SelectedIndex].Id;
                int idMateriel = _materiels[cboMateriel.SelectedIndex].Id;

                int nextId = _db.GetNextId("Pret");
                _db.EnregistrerPret(nextId, idMateriel, idAdherent, dtpDateDebut.Value.Date);

                AfficherSucces("Prêt enregistré avec succès !");
                ChargerMateriels(); // Actualiser la liste des dispo
                cboMateriel.SelectedIndex = -1;
                cboAdherent.SelectedIndex = -1;
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

        private void cboMateriel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMateriel.SelectedIndex < 0) return;
            MaterielDTO m = _materiels[cboMateriel.SelectedIndex];
            lblInfoMateriel.Text = m.TypeMateriel + " — " + m.Marque +
                " | Taille : " + (m.TailleOuPointure ?? "—") +
                " | État : " + m.Etat;
        }

        private bool Valider()
        {
            if (cboAdherent.SelectedIndex < 0)
            { AfficherErreur("Sélectionnez un adhérent."); cboAdherent.Focus(); return false; }
            if (cboMateriel.SelectedIndex < 0)
            { AfficherErreur("Sélectionnez un matériel."); cboMateriel.Focus(); return false; }
            lblMessage.Text = string.Empty;
            return true;
        }

        private void AfficherErreur(string msg)
        { lblMessage.Text = msg; lblMessage.ForeColor = System.Drawing.Color.Crimson; }

        private void AfficherSucces(string msg)
        { lblMessage.Text = msg; lblMessage.ForeColor = System.Drawing.Color.ForestGreen; }
    }
}