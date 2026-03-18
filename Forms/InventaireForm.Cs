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
    /// Description : Affiche l'inventaire complet du stock par type et taille.
    /// </summary>
    public partial class InventaireForm : Form
    {
        private readonly Inventaire _inventaire = new Inventaire();

        public InventaireForm()
        {
            InitializeComponent();
        }

        private void InventaireForm_Load(object sender, EventArgs e)
        {
            ChargerInventaire();
        }

        private void ChargerInventaire()
        {
            try
            {
                List<InventaireDTO> lignes = _inventaire.GetInventaireComplet();
                dgvInventaire.Rows.Clear();

                int totalTotal = 0, totalDispo = 0, totalPrete = 0;

                foreach (InventaireDTO inv in lignes)
                {
                    int idx = dgvInventaire.Rows.Add(
                        inv.TypeMateriel,
                        inv.TailleOuPointure ?? "—",
                        inv.Total,
                        inv.Disponibles,
                        inv.Pretes
                    );

                    totalTotal += inv.Total;
                    totalDispo += inv.Disponibles;
                    totalPrete += inv.Pretes;

                    // Colorier selon disponibilité
                    if (inv.Pretes == inv.Total)
                        dgvInventaire.Rows[idx].DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
                    else if (inv.Disponibles == inv.Total)
                        dgvInventaire.Rows[idx].DefaultCellStyle.BackColor = Color.FromArgb(235, 255, 235);
                }

                // Totaux
                lblTotalTotal.Text = totalTotal.ToString();
                lblTotalDispo.Text = totalDispo.ToString();
                lblTotalPrete.Text = totalPrete.ToString();
                lblTotalDispo.ForeColor = Color.ForestGreen;
                lblTotalPrete.ForeColor = totalPrete > 0
                    ? Color.FromArgb(200, 100, 0) : Color.Gray;

                lblLignesCount.Text = lignes.Count + " ligne(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            ChargerInventaire();
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}   