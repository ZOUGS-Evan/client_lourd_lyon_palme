using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LyonPalme.DataAccess;
using LyonPalme.Models;

namespace LyonPalme.Forms
{
    public partial class MaterielDetailsForm : Form
    {
        private readonly MaterielDTO _dto;

        public MaterielDetailsForm(MaterielDTO dto)
        {
            InitializeComponent();
            _dto = dto;
        }

        private void MaterielDetailsForm_Load(object sender, EventArgs e)
        {
            AfficherDetails();
            ChargerHistorique();
        }

        private void AfficherDetails()
        {
            lblCodeValeur.Text = _dto.Code;
            lblTypeValeur.Text = _dto.TypeMateriel;
            lblMarqueValeur.Text = _dto.Marque;
            lblTailleValeur.Text = _dto.TailleOuPointure ?? "—";
            lblEtatValeur.Text = _dto.Etat;
            lblDispoValeur.Text = _dto.Disponibilite;

            lblDispoValeur.ForeColor = _dto.Disponibilite == "Disponible"
                ? Color.ForestGreen : Color.Crimson;

            btnSupprimer.Enabled = _dto.Disponibilite == "Disponible";

            if (!string.IsNullOrEmpty(_dto.Materiaux))
            { lblMateriauxLib.Visible = true; lblMateriauxValeur.Visible = true; lblMateriauxValeur.Text = _dto.Materiaux; }

            if (!string.IsNullOrEmpty(_dto.TenuSaison))
            { lblSaisonLib.Visible = true; lblSaisonValeur.Visible = true; lblSaisonValeur.Text = _dto.TenuSaison; }
        }

        private void ChargerHistorique()
        {
            try
            {
                List<HistoriqueDTO> hist = DBInterface.GetHistoriqueMateriel(_dto.Id);
                dgvHistorique.Rows.Clear();

                foreach (HistoriqueDTO h in hist)
                {
                    int idx = dgvHistorique.Rows.Add(
                        h.Nom + " " + h.Prenom,
                        h.DateDebut.ToString("dd/MM/yyyy"),
                        h.DateFin.HasValue ? h.DateFin.Value.ToString("dd/MM/yyyy") : "En cours",
                        h.DateRetour.HasValue ? h.DateRetour.Value.ToString("dd/MM/yyyy") : "—",
                        h.EtatRetour ?? "—"
                    );

                    if (!h.DateFin.HasValue)
                        dgvHistorique.Rows[idx].DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
                }

                lblHistoriqueCount.Text = hist.Count + " prêt(s) au total";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            new MaterielEditForm(_dto).ShowDialog(this);

            MaterielDTO u = DBInterface.GetDetailsMateriel(_dto.Id);
            if (u != null)
            {
                lblCodeValeur.Text = u.Code;
                lblMarqueValeur.Text = u.Marque;
                lblEtatValeur.Text = u.Etat;
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Supprimer " + _dto.Code + " ?", "Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                DBInterface.SupprimerMateriel(_dto.Id);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}