using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LyonPalme.DataAccess;
using LyonPalme.Models;

namespace LyonPalme.Forms
{
    /// <summary>
    /// Auteur      : R. Fonseca
    /// Date        : 11/03/2026
    /// Description : Tableau de bord principal.
    ///               Affiche le stock, les prêts en cours et les retards.
    ///               Donne accès à toutes les fonctionnalités de l'application.
    /// </summary>
    public partial class GestionForm : Form
    {
        // ── Référence métier ─────────────────────────────────────────
        private readonly Gestion _gestion = Gestion.getInstance();

        // ── Constructeur ─────────────────────────────────────────────
        public GestionForm()
        {
            InitializeComponent();
        }

        // ── Chargement ───────────────────────────────────────────────
        private void GestionForm_Load(object sender, EventArgs e)
        {
            // Afficher le nom du responsable connecté
            lblBienvenue.Text = "Bonjour, " + _gestion.UtilisateurConnecte.Prenom +
                                " " + _gestion.UtilisateurConnecte.Nom + "  |  " +
                                DateTime.Now.ToString("dddd dd MMMM yyyy");

            ChargerStock();
            ChargerPretsEnCours();
            ChargerRetards();
            MettreAJourCompteurs();
        }

        // ── Chargement des données ────────────────────────────────────

        private void ChargerStock()
        {
            try
            {
                List<MaterielDTO> stock = _gestion.GetStock();
                dgvStock.Rows.Clear();

                foreach (MaterielDTO m in stock)
                {
                    int idx = dgvStock.Rows.Add(
                        m.Id,
                        m.Code,
                        m.TypeMateriel,
                        m.Marque,
                        m.TailleOuPointure ?? "—",
                        m.Etat,
                        m.Disponibilite
                    );

                    // Colorer selon disponibilité
                    if (m.Disponibilite == "Prêté")
                        dgvStock.Rows[idx].DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
                    else if (m.Etat == "Hors service")
                        dgvStock.Rows[idx].DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
                    else
                        dgvStock.Rows[idx].DefaultCellStyle.BackColor = Color.FromArgb(235, 255, 235);
                }

                lblStockCount.Text = stock.Count + " matériel(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement stock : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChargerPretsEnCours()
        {
            try
            {
                List<PretEnCoursDTO> prets = _gestion.GetPretsEnCours();
                dgvPrets.Rows.Clear();

                foreach (PretEnCoursDTO p in prets)
                {
                    int jours = (DateTime.Today - p.DateDebut).Days;
                    int idx = dgvPrets.Rows.Add(
                        p.IdPret,
                        p.Nom + " " + p.Prenom,
                        p.Code,
                        p.Marque,
                        p.DateDebut.ToString("dd/MM/yyyy"),
                        jours + " jour(s)"
                    );

                    if (jours > 30)
                        dgvPrets.Rows[idx].DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 220);
                }

                lblPretsCount.Text = prets.Count + " prêt(s) en cours";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement prêts : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChargerRetards()
        {
            try
            {
                List<RetardDTO> retards = _gestion.Historique.GetRetards();
                dgvRetards.Rows.Clear();

                foreach (RetardDTO r in retards)
                {
                    dgvRetards.Rows.Add(
                        r.Nom + " " + r.Prenom,
                        r.Code,
                        r.Marque,
                        r.DateDebut.ToString("dd/MM/yyyy"),
                        r.JoursDepuisDebut + " jour(s)",
                        r.TypeRetard
                    );
                }

                lblRetardsCount.Text = retards.Count + " retard(s)";
                lblRetardsCount.ForeColor = retards.Count > 0
                    ? Color.Crimson : Color.ForestGreen;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement retards : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MettreAJourCompteurs()
        {
            try
            {
                List<InventaireDTO> inventaire = _gestion.Inventaire.GetInventaireComplet();
                int total = 0, dispo = 0, prete = 0;
                foreach (InventaireDTO i in inventaire)
                {
                    total += i.Total;
                    dispo += i.Disponibles;
                    prete += i.Pretes;
                }

                lblKpiTotal.Text = total.ToString();
                lblKpiDispo.Text = dispo.ToString();
                lblKpiPrete.Text = prete.ToString();
                lblKpiRetards.Text = dgvRetards.Rows.Count.ToString();
            }
            catch { }
        }

        // ── Recherche stock ──────────────────────────────────────────

        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string terme = txtRecherche.Text.Trim();
                List<MaterielDTO> resultats = string.IsNullOrEmpty(terme)
                    ? _gestion.GetStock()
                    : _gestion.RechercherMateriel(terme);

                dgvStock.Rows.Clear();
                foreach (MaterielDTO m in resultats)
                {
                    int idx = dgvStock.Rows.Add(
                        m.Id, m.Code, m.TypeMateriel, m.Marque,
                        m.TailleOuPointure ?? "—", m.Etat, m.Disponibilite);

                    if (m.Disponibilite == "Prêté")
                        dgvStock.Rows[idx].DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
                    else if (m.Etat == "Hors service")
                        dgvStock.Rows[idx].DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
                    else
                        dgvStock.Rows[idx].DefaultCellStyle.BackColor = Color.FromArgb(235, 255, 235);
                }
            }
            catch { }
        }

        // ── Boutons Navigation ───────────────────────────────────────

        private void btnAjouterMateriel_Click(object sender, EventArgs e)
        {
            MaterielAddForm form = new MaterielAddForm();
            form.ShowDialog(this);
            ChargerStock();
            MettreAJourCompteurs();
        }

        private void btnNouveauPret_Click(object sender, EventArgs e)
        {
            PretForm form = new PretForm();
            form.ShowDialog(this);
            ChargerStock();
            ChargerPretsEnCours();
            MettreAJourCompteurs();
        }

        private void btnNouveauRetour_Click(object sender, EventArgs e)
        {
            RetourForm form = new RetourForm();
            form.ShowDialog(this);
            ChargerStock();
            ChargerPretsEnCours();
            MettreAJourCompteurs();
        }

        private void btnInventaire_Click(object sender, EventArgs e)
        {
            InventaireForm form = new InventaireForm();
            form.ShowDialog(this);
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            txtRecherche.Clear();
            ChargerStock();
            ChargerPretsEnCours();
            ChargerRetards();
            MettreAJourCompteurs();
        }

        // ── Double-clic sur le stock → détails/édition ───────────────

        private void dgvStock_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int idMateriel = (int)dgvStock.Rows[e.RowIndex].Cells["colId"].Value;
            MaterielDTO dto = _gestion.GetDetailsMateriel(idMateriel);
            if (dto == null) return;

            MaterielDetailsForm form = new MaterielDetailsForm(dto);
            form.ShowDialog(this);
            ChargerStock();
            ChargerPretsEnCours();
            MettreAJourCompteurs();
        }

        // ── Déconnexion ──────────────────────────────────────────────

        private void btnDeconnecter_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Voulez-vous vous déconnecter ?",
                "Déconnexion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                _gestion.Deconnecter();
                this.Close();
            }
        }

        // ── Fermeture ────────────────────────────────────────────────

        private void GestionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _gestion.Deconnecter();
        }
    }
}