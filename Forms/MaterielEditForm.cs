using LyonPalme.DataAccess;
using System;
using System.Windows.Forms;

namespace LyonPalme.Forms
{
    /// <summary>
    /// Auteur      : R. Fonseca
    /// Date        : 11/03/2026
    /// Description : Formulaire de modification d'un matériel existant.
    /// </summary>
    public partial class MaterielEditForm : Form
    {
        private readonly MaterielDTO _dto;

        public MaterielEditForm(MaterielDTO dto)
        {
            InitializeComponent();
            _dto = dto;
        }

        private void MaterielEditForm_Load(object sender, EventArgs e)
        {
            cboEtat.Items.AddRange(new string[] { "Bon etat", "Use", "Hors service" });

            // Pré-remplir les champs communs
            txtCode.Text = _dto.Code;
            // Afficher le libellé de la marque (ici _dto.Marque contient l'id)
            txtMarque.Text = DBInterface.GetMarqueLibelle(_dto.Marque);
            int etatIdx = cboEtat.Items.IndexOf(_dto.Etat);
            cboEtat.SelectedIndex = etatIdx >= 0 ? etatIdx : 0;
            lblTypeValeur.Text = _dto.TypeMateriel;

            // Champs spécifiques
            bool isMono = _dto.TypeMateriel == "Monopalme";
            bool isTuba = _dto.TypeMateriel == "Tuba_frontal";
            bool isComb = _dto.TypeMateriel == "Combinaison";

            lblTailleLib.Visible = isTuba || isComb;
            txtTaille.Visible = isTuba || isComb;
            lblPointureLib.Visible = isMono;
            txtPointure.Visible = isMono;
            lblMateriauxLib.Visible = isMono;
            txtMateriaux.Visible = isMono;
            lblSaisonLib.Visible = isComb;
            cboSaison.Visible = isComb;

            if (isMono)
            {
                txtPointure.Text = _dto.TailleOuPointure ?? "";
                txtMateriaux.Text = _dto.Materiaux ?? "";
            }
            else if (isTuba || isComb)
            {
                txtTaille.Text = _dto.TailleOuPointure ?? "";
            }

            if (isComb)
            {
                cboSaison.Items.AddRange(new string[] { "Ete", "Hiver" });
                int saisonIdx = cboSaison.Items.IndexOf(_dto.TenuSaison ?? "Ete");
                cboSaison.SelectedIndex = saisonIdx >= 0 ? saisonIdx : 0;
            }
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (!Valider()) return;
            try
            {
                int? pointure = null;
                string taille = null;
                string materiaux = null;
                string saison = null;

                if (_dto.TypeMateriel == "Monopalme")
                {
                    if (int.TryParse(txtPointure.Text.Trim(), out int p)) pointure = p;
                    materiaux = txtMateriaux.Text.Trim();
                }
                else if (_dto.TypeMateriel == "Tuba_frontal" || _dto.TypeMateriel == "Combinaison")
                {
                    taille = txtTaille.Text.Trim();
                    if (_dto.TypeMateriel == "Combinaison" && cboSaison.SelectedItem != null)
                        saison = cboSaison.SelectedItem.ToString();
                }

                // Convertir le libellé saisi en id de marque (crée pas de nouvelle marque ici)
                int? marqueId = DBInterface.GetMarqueIdByLibelle(txtMarque.Text.Trim());
                if (!marqueId.HasValue)
                    throw new Exception("Marque inconnue : créez-la d'abord dans la table Marque.");

                DBInterface.ModifierMateriel(
                    _dto.Id,
                    txtCode.Text.Trim().ToUpper(),
                    marqueId.Value,
                    cboEtat.SelectedItem.ToString(),
                    pointure, materiaux, taille, saison);

                AfficherSucces("Matériel modifié avec succès.");
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

            if (_dto.TypeMateriel == "Monopalme" && string.IsNullOrWhiteSpace(txtMateriaux.Text))
            { AfficherErreur("Les matériaux sont obligatoires."); txtMateriaux.Focus(); return false; }

            lblMessage.Text = string.Empty;
            return true;
        }

        private void AfficherErreur(string msg)
        { lblMessage.Text = msg; lblMessage.ForeColor = System.Drawing.Color.Crimson; }

        private void AfficherSucces(string msg)
        { lblMessage.Text = msg; lblMessage.ForeColor = System.Drawing.Color.ForestGreen; }
    }
}