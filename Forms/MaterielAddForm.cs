using LyonPalme.DataAccess;
using System;
using System.Windows.Forms;

namespace LyonPalme.Forms
{
    /// <summary>
    /// Auteur      : R. Fonseca
    /// Date        : 11/03/2026
    /// Description : Formulaire d'ajout d'un nouveau matériel.
    /// </summary>
    public partial class MaterielAddForm : Form
    {
        public MaterielAddForm()
        {
            InitializeComponent();
        }

        private void MaterielAddForm_Load(object sender, EventArgs e)
        {
            cboType.Items.AddRange(new string[] { "Monopalme", "Tuba_frontal", "Combinaison", "Lunette" });
            cboType.SelectedIndex = 0;

            cboEtat.Items.AddRange(new string[] { "Bon etat", "Use", "Hors service" });
            cboEtat.SelectedIndex = 0;

            cboTenuSaison.Items.AddRange(new string[] { "Ete", "Hiver" });
            cboTenuSaison.SelectedIndex = 0;

            MettreAJourChampsSpecifiques();
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            MettreAJourChampsSpecifiques();
        }

        /// <summary>Affiche ou masque les champs selon le type sélectionné.</summary>
        private void MettreAJourChampsSpecifiques()
        {
            string type = cboType.SelectedItem != null ? cboType.SelectedItem.ToString() : "";
            bool isMono = type == "Monopalme";
            bool isTubaComb = type == "Tuba_frontal" || type == "Combinaison";
            bool isComb = type == "Combinaison";

            lblPointure.Visible = isMono;
            txtPointure.Visible = isMono;
            lblMateriaux.Visible = isMono;
            txtMateriaux.Visible = isMono;

            lblTaille.Visible = isTubaComb;
            txtTaille.Visible = isTubaComb;

            lblTenuSaison.Visible = isComb;
            cboTenuSaison.Visible = isComb;
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (!Valider()) return;
            try
            {
                string type = cboType.SelectedItem.ToString();
                int nextId = DBInterface.GetNextId("Materiel");

                string taille = (type == "Tuba_frontal" || type == "Combinaison") ? txtTaille.Text.Trim() : null;
                string materiaux = type == "Monopalme" ? txtMateriaux.Text.Trim() : null;
                string saison = type == "Combinaison" ? cboTenuSaison.SelectedItem.ToString() : null;

                int? pointure = null;
                if (type == "Monopalme" && int.TryParse(txtPointure.Text.Trim(), out int p))
                    pointure = p;

                DBInterface.AjouterMateriel(
                    nextId,
                    txtCode.Text.Trim().ToUpper(),
                    txtMarque.Text.Trim(),
                    cboEtat.SelectedItem.ToString(),
                    type, pointure, materiaux, taille, saison);

                AfficherSucces("Matériel " + txtCode.Text.Trim().ToUpper() + " ajouté avec succès.");
                ResetFormulaire();
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
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            { AfficherErreur("Le code est obligatoire."); txtCode.Focus(); return false; }

            if (string.IsNullOrWhiteSpace(txtMarque.Text))
            { AfficherErreur("La marque est obligatoire."); txtMarque.Focus(); return false; }

            string type = cboType.SelectedItem != null ? cboType.SelectedItem.ToString() : "";

            if (type == "Monopalme")
            {
                if (string.IsNullOrWhiteSpace(txtMateriaux.Text))
                { AfficherErreur("Les matériaux sont obligatoires pour une Monopalme."); txtMateriaux.Focus(); return false; }
                if (string.IsNullOrWhiteSpace(txtPointure.Text))
                { AfficherErreur("La pointure est obligatoire pour une Monopalme."); txtPointure.Focus(); return false; }
            }
            else if (type == "Tuba_frontal" || type == "Combinaison")
            {
                if (string.IsNullOrWhiteSpace(txtTaille.Text))
                { AfficherErreur("La taille est obligatoire pour ce type."); txtTaille.Focus(); return false; }
            }

            lblMessage.Text = string.Empty;
            return true;
        }

        private void ResetFormulaire()
        {
            txtCode.Clear();
            txtMarque.Clear();
            txtPointure.Clear();
            txtMateriaux.Clear();
            txtTaille.Clear();
            cboType.SelectedIndex = 0;
            cboEtat.SelectedIndex = 0;
            txtCode.Focus();
        }

        private void AfficherErreur(string msg)
        { lblMessage.Text = msg; lblMessage.ForeColor = System.Drawing.Color.Crimson; }

        private void AfficherSucces(string msg)
        { lblMessage.Text = msg; lblMessage.ForeColor = System.Drawing.Color.ForestGreen; }
    }
}