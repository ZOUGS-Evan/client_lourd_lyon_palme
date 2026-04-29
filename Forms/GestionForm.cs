using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using LyonPalme.DataAccess;
using LyonPalme.Models;

namespace LyonPalme.Forms
{
    public partial class GestionForm : Form
    {
        private static readonly Color COULEUR_PRIMAIRE = Color.FromArgb(15, 32, 65);
        private static readonly Color COULEUR_DISPO = Color.FromArgb(198, 239, 206);
        private static readonly Color COULEUR_PRETE = Color.FromArgb(255, 199, 206);
        private static readonly Color COULEUR_HORS_SERVICE = Color.FromArgb(235, 235, 235);
        private static readonly Color COULEUR_SELECTION_FONCE = Color.FromArgb(55, 60, 70);
        private static readonly Color COULEUR_SELECTION_TEXTE = Color.White;

        private readonly Gestion _gestion = Gestion.getInstance();

        private const string RECHERCHE_PLACEHOLDER = "Rechercher par code, type, marque...";
        private const string RECHERCHE_PRETS_PLACEHOLDER = "Rechercher par adherent, code, marque...";
        private const string RECHERCHE_RETARDS_PLACEHOLDER = "Rechercher par adherent, code, marque, type...";

        public GestionForm()
        {
            InitializeComponent();
        }

        private void GestionForm_Load(object sender, EventArgs e)
        {
            lblBienvenue.Text = "Bonjour, " + _gestion.UtilisateurConnecte.Prenom +
                                " " + _gestion.UtilisateurConnecte.Nom + "  |  " +
                                DateTime.Now.ToString("dddd dd MMMM yyyy");

            dgvStock.CellPainting += dgv_CellPainting_HeaderTriBleu;
            dgvPrets.CellPainting += dgv_CellPainting_HeaderTriBleu;
            dgvRetards.CellPainting += dgv_CellPainting_HeaderTriBleu;

            dgvStock.Sorted += dgv_Sorted_RafraichirEntete;
            dgvPrets.Sorted += dgv_Sorted_RafraichirEntete;
            dgvRetards.Sorted += dgv_Sorted_RafraichirEntete;

            InitialiserGrille(dgvStock);
            InitialiserGrille(dgvPrets);
            InitialiserGrille(dgvRetards);

            AppliquerStyleSelection(dgvStock);
            AppliquerStyleSelection(dgvPrets);
            AppliquerStyleSelection(dgvRetards);

            ChargerStock();
            ChargerPretsEnCours();
            ChargerRetards();
            MettreAJourCompteurs();

            ClearSelectionAll();
            HookClearSelectionOnClick(this);
        }

        private static void AppliquerStyleSelection(DataGridView dgv)
        {
            if (dgv == null) return;
            dgv.DefaultCellStyle.SelectionBackColor = COULEUR_SELECTION_FONCE;
            dgv.DefaultCellStyle.SelectionForeColor = COULEUR_SELECTION_TEXTE;
        }

        private void InitialiserGrille(DataGridView dgv)
        {
            if (dgv == null) return;
            dgv.Leave += delegate { dgv.ClearSelection(); };
            dgv.MouseDown += (s, ev) =>
            {
                DataGridView.HitTestInfo hit = dgv.HitTest(ev.X, ev.Y);
                if (hit.Type != DataGridViewHitTestType.Cell) dgv.ClearSelection();
            };
        }

        private void ClearSelectionAll()
        {
            if (dgvStock != null) dgvStock.ClearSelection();
            if (dgvPrets != null) dgvPrets.ClearSelection();
            if (dgvRetards != null) dgvRetards.ClearSelection();
        }

        private void dgv_Sorted_RafraichirEntete(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null) return;
            if (dgv.SortedColumn != null)
                dgv.SortedColumn.HeaderCell.SortGlyphDirection = dgv.SortOrder;
            dgv.Invalidate();
        }

        private void dgv_CellPainting_HeaderTriBleu(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null) return;
            if (e.RowIndex != -1 || e.ColumnIndex < 0) return;

            e.Paint(e.CellBounds, DataGridViewPaintParts.All);

            if (dgv.SortedColumn == null || dgv.SortedColumn.Index != e.ColumnIndex)
            { e.Handled = true; return; }

            SortOrder order = dgv.SortOrder;
            if (order == SortOrder.None) { e.Handled = true; return; }

            Rectangle r = e.CellBounds;
            int size = 10;
            int paddingRight = 10;
            int cx = r.Right - paddingRight - (size / 2);
            int cy = r.Top + (r.Height / 2);

            Point p1, p2, p3;
            if (order == SortOrder.Ascending)
            {
                p1 = new Point(cx - size / 2, cy + size / 3);
                p2 = new Point(cx + size / 2, cy + size / 3);
                p3 = new Point(cx, cy - size / 2);
            }
            else
            {
                p1 = new Point(cx - size / 2, cy - size / 3);
                p2 = new Point(cx + size / 2, cy - size / 3);
                p3 = new Point(cx, cy + size / 2);
            }

            using (SolidBrush b = new SolidBrush(COULEUR_PRIMAIRE))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillPolygon(b, new Point[] { p1, p2, p3 });
                e.Graphics.SmoothingMode = SmoothingMode.Default;
            }
            e.Handled = true;
        }

        // ── Chargement données ───────────────────────────────────────

        private void ChargerStock()
        {
            try
            {
                List<MaterielDTO> stock = _gestion.GetStock();
                RemplirDgvStock(stock);
                lblStockCount.Text = stock.Count + " materiel(s)";
                dgvStock.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement stock : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemplirDgvStock(List<MaterielDTO> materiels)
        {
            dgvStock.Rows.Clear();
            foreach (MaterielDTO m in materiels)
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

                // "Prete" sans accent — cohérent avec vue_disponibilite
                if (m.Disponibilite == "Prete")
                    dgvStock.Rows[idx].DefaultCellStyle.BackColor = COULEUR_PRETE;
                else if (m.Etat == "Hors service")
                    dgvStock.Rows[idx].DefaultCellStyle.BackColor = COULEUR_HORS_SERVICE;
                else
                    dgvStock.Rows[idx].DefaultCellStyle.BackColor = COULEUR_DISPO;
            }
            dgvStock.ClearSelection();
        }

        private void RafraichirStockSelonRecherche()
        {
            string terme = txtRecherche.Text == null ? string.Empty : txtRecherche.Text.Trim();
            bool placeholderActif = (txtRecherche.ForeColor == Color.Gray) ||
                                    (terme == RECHERCHE_PLACEHOLDER);

            if (placeholderActif || string.IsNullOrEmpty(terme))
            { ChargerStock(); return; }

            try
            {
                List<MaterielDTO> resultats = _gestion.RechercherMateriel(terme);
                RemplirDgvStock(resultats);
                lblStockCount.Text = resultats.Count + " materiel(s)";
            }
            catch { }
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
                        dgvPrets.Rows[idx].DefaultCellStyle.BackColor = COULEUR_PRETE;
                }

                lblPretsCount.Text = prets.Count + " pret(s) en cours";
                dgvPrets.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement prets : " + ex.Message,
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
                    int idx = dgvRetards.Rows.Add(
                        r.Nom + " " + r.Prenom,
                        r.Code,
                        r.Marque,
                        r.DateDebut.ToString("dd/MM/yyyy"),
                        r.DateFin.HasValue ? r.DateFin.Value.ToString("dd/MM/yyyy") : "Aucune",
                        r.JoursRetard + " jour(s)"
                    );
                    dgvRetards.Rows[idx].DefaultCellStyle.BackColor = COULEUR_PRETE;
                }

                lblRetardsCount.Text = retards.Count + " retard(s)";
                lblRetardsCount.ForeColor = retards.Count > 0 ? Color.Crimson : Color.ForestGreen;
                dgvRetards.ClearSelection();
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

        // ── Événements UI ────────────────────────────────────────────

        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {
            RafraichirStockSelonRecherche();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabStock)
                RafraichirStockSelonRecherche();
            ClearSelectionAll();
        }

        private static bool PlaceholderActif(TextBox txt, string placeholder)
        {
            if (txt == null) return true;
            string t = txt.Text == null ? string.Empty : txt.Text.Trim();
            return (txt.ForeColor == Color.Gray) ||
                   string.Equals(t, placeholder, StringComparison.OrdinalIgnoreCase);
        }

        private static bool LigneContient(DataGridViewRow row, string terme)
        {
            if (row == null || row.IsNewRow) return false;
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.Value == null) continue;
                if (cell.Value.ToString().IndexOf(terme, StringComparison.OrdinalIgnoreCase) >= 0)
                    return true;
            }
            return false;
        }

        private void FiltrerDgv(DataGridView dgv, string terme)
        {
            if (dgv == null) return;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;
                row.Visible = string.IsNullOrEmpty(terme) || LigneContient(row, terme);
            }
        }

        private void txtRecherchePrets_TextChanged(object sender, EventArgs e)
        {
            if (PlaceholderActif(txtRecherchePrets, RECHERCHE_PRETS_PLACEHOLDER))
            { FiltrerDgv(dgvPrets, string.Empty); return; }
            FiltrerDgv(dgvPrets, txtRecherchePrets.Text.Trim());
            dgvPrets.ClearSelection();
        }

        private void txtRechercheRetards_TextChanged(object sender, EventArgs e)
        {
            if (PlaceholderActif(txtRechercheRetards, RECHERCHE_RETARDS_PLACEHOLDER))
            { FiltrerDgv(dgvRetards, string.Empty); return; }
            FiltrerDgv(dgvRetards, txtRechercheRetards.Text.Trim());
            dgvRetards.ClearSelection();
        }

        private void btnAjouterMateriel_Click(object sender, EventArgs e)
        {
            new MaterielAddForm().ShowDialog(this);
            RafraichirStockSelonRecherche();
            MettreAJourCompteurs();
            ClearSelectionAll();
        }

        private void btnNouveauPret_Click(object sender, EventArgs e)
        {
            new PretForm().ShowDialog(this);
            RafraichirStockSelonRecherche();
            ChargerPretsEnCours();
            MettreAJourCompteurs();
            ClearSelectionAll();
        }

        private void btnNouveauRetour_Click(object sender, EventArgs e)
        {
            new RetourForm().ShowDialog(this);
            RafraichirStockSelonRecherche();
            ChargerPretsEnCours();
            MettreAJourCompteurs();
            ClearSelectionAll();
        }

        private void btnInventaire_Click(object sender, EventArgs e)
        {
            new InventaireForm().ShowDialog(this);
            ClearSelectionAll();
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            txtRecherche.Clear();
            txtRecherchePrets.Clear();
            txtRechercheRetards.Clear();

            ChargerStock();
            ChargerPretsEnCours();
            ChargerRetards();
            MettreAJourCompteurs();
            ClearSelectionAll();
        }

        private void dgvStock_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int idMateriel = (int)dgvStock.Rows[e.RowIndex].Cells["colId"].Value;
            MaterielDTO dto = _gestion.GetDetailsMateriel(idMateriel);
            if (dto == null) return;

            new MaterielDetailsForm(dto).ShowDialog(this);

            RafraichirStockSelonRecherche();
            ChargerPretsEnCours();
            MettreAJourCompteurs();
            ClearSelectionAll();
        }

        private void btnDeconnecter_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vous deconnecter ?", "Deconnexion",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _gestion.Deconnecter();
                Close();
            }
        }

        private void GestionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _gestion.Deconnecter();
        }

        private void HookClearSelectionOnClick(Control root)
        {
            if (root == null) return;
            root.MouseDown += (s, ev) =>
            {
                Control c = s as Control;
                if (c == null) { ClearSelectionAll(); return; }
                Control parent = c;
                while (parent != null)
                {
                    if (parent is DataGridView) return;
                    parent = parent.Parent;
                }
                ClearSelectionAll();
            };
            foreach (Control child in root.Controls)
                HookClearSelectionOnClick(child);
        }
    }
}