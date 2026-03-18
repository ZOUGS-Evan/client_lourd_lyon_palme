namespace LyonPalme.Forms
{
    partial class GestionForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitre = new System.Windows.Forms.Label();
            this.lblBienvenue = new System.Windows.Forms.Label();
            this.btnDeconnecter = new System.Windows.Forms.Button();

            this.pnlKpi = new System.Windows.Forms.Panel();
            this.pnlKpiTotal = new System.Windows.Forms.Panel();
            this.lblKpiTotalLib = new System.Windows.Forms.Label();
            this.lblKpiTotal = new System.Windows.Forms.Label();
            this.pnlKpiDispo = new System.Windows.Forms.Panel();
            this.lblKpiDispoLib = new System.Windows.Forms.Label();
            this.lblKpiDispo = new System.Windows.Forms.Label();
            this.pnlKpiPrete = new System.Windows.Forms.Panel();
            this.lblKpiPreteLib = new System.Windows.Forms.Label();
            this.lblKpiPrete = new System.Windows.Forms.Label();
            this.pnlKpiRetards = new System.Windows.Forms.Panel();
            this.lblKpiRetardsLib = new System.Windows.Forms.Label();
            this.lblKpiRetards = new System.Windows.Forms.Label();

            this.pnlGauche = new System.Windows.Forms.Panel();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnAjouterMateriel = new System.Windows.Forms.Button();
            this.btnNouveauPret = new System.Windows.Forms.Button();
            this.btnNouveauRetour = new System.Windows.Forms.Button();
            this.btnInventaire = new System.Windows.Forms.Button();
            this.btnActualiser = new System.Windows.Forms.Button();

            this.pnlContenu = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabStock = new System.Windows.Forms.TabPage();
            this.pnlRechercheBar = new System.Windows.Forms.Panel();
            this.txtRecherche = new System.Windows.Forms.TextBox();
            this.lblRecherche = new System.Windows.Forms.Label();
            this.lblStockCount = new System.Windows.Forms.Label();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.tabPrets = new System.Windows.Forms.TabPage();
            this.lblPretsCount = new System.Windows.Forms.Label();
            this.dgvPrets = new System.Windows.Forms.DataGridView();
            this.tabRetards = new System.Windows.Forms.TabPage();
            this.lblRetardsCount = new System.Windows.Forms.Label();
            this.dgvRetards = new System.Windows.Forms.DataGridView();

            // Colonnes dgvStock
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMarque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTaille = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEtat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDispo = new System.Windows.Forms.DataGridViewTextBoxColumn();

            // Colonnes dgvPrets
            this.colPretId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPretAdherent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPretCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPretMarque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPretDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPretJours = new System.Windows.Forms.DataGridViewTextBoxColumn();

            // Colonnes dgvRetards
            this.colRetAdherent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRetCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRetMarque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRetDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRetJours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRetType = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlTop.SuspendLayout();
            this.pnlKpi.SuspendLayout();
            this.pnlGauche.SuspendLayout();
            this.pnlContenu.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabStock.SuspendLayout();
            this.tabPrets.SuspendLayout();
            this.tabRetards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvPrets).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvRetards).BeginInit();
            this.SuspendLayout();

            // ── pnlTop ───────────────────────────────────────────────
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(15, 32, 65);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 65;
            this.pnlTop.Controls.AddRange(new System.Windows.Forms.Control[]
                { this.lblTitre, this.lblBienvenue, this.btnDeconnecter });

            this.lblTitre.Text = "🤿  LyonPalme — Gestion du matériel";
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitre.ForeColor = System.Drawing.Color.White;
            this.lblTitre.AutoSize = true;
            this.lblTitre.Location = new System.Drawing.Point(15, 18);

            this.lblBienvenue.Text = string.Empty;
            this.lblBienvenue.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblBienvenue.ForeColor = System.Drawing.Color.FromArgb(180, 200, 230);
            this.lblBienvenue.AutoSize = true;
            this.lblBienvenue.Location = new System.Drawing.Point(400, 22);

            this.btnDeconnecter.Text = "⏻  Déconnecter";
            this.btnDeconnecter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDeconnecter.Size = new System.Drawing.Size(130, 32);
            this.btnDeconnecter.Location = new System.Drawing.Point(1060, 16);
            this.btnDeconnecter.BackColor = System.Drawing.Color.FromArgb(180, 40, 40);
            this.btnDeconnecter.ForeColor = System.Drawing.Color.White;
            this.btnDeconnecter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeconnecter.FlatAppearance.BorderSize = 0;
            this.btnDeconnecter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeconnecter.Click += new System.EventHandler(this.btnDeconnecter_Click);

            // ── pnlKpi (bande de KPIs sous le header) ───────────────
            this.pnlKpi.BackColor = System.Drawing.Color.FromArgb(240, 243, 250);
            this.pnlKpi.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpi.Height = 90;
            this.pnlKpi.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.pnlKpi.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.pnlKpiTotal, this.pnlKpiDispo,
                this.pnlKpiPrete, this.pnlKpiRetards
            });

            ConstruireKpi(this.pnlKpiTotal, this.lblKpiTotalLib, this.lblKpiTotal, "Total matériels", System.Drawing.Color.FromArgb(15, 32, 65), 15, 8);
            ConstruireKpi(this.pnlKpiDispo, this.lblKpiDispoLib, this.lblKpiDispo, "Disponibles", System.Drawing.Color.FromArgb(34, 139, 34), 295, 8);
            ConstruireKpi(this.pnlKpiPrete, this.lblKpiPreteLib, this.lblKpiPrete, "Prêtés", System.Drawing.Color.FromArgb(200, 100, 0), 575, 8);
            ConstruireKpi(this.pnlKpiRetards, this.lblKpiRetardsLib, this.lblKpiRetards, "Retards", System.Drawing.Color.FromArgb(180, 30, 30), 855, 8);

            // ── pnlGauche (barre de navigation) ─────────────────────
            this.pnlGauche.BackColor = System.Drawing.Color.FromArgb(248, 249, 252);
            this.pnlGauche.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGauche.Width = 200;
            this.pnlGauche.Padding = new System.Windows.Forms.Padding(10, 15, 10, 10);
            this.pnlGauche.Controls.Add(this.pnlActions);

            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActions.AutoSize = true;
            this.pnlActions.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.btnAjouterMateriel,
                this.btnNouveauPret,
                this.btnNouveauRetour,
                this.btnInventaire,
                this.btnActualiser
            });

            ConstruireBoutonNav(this.btnAjouterMateriel, "➕  Ajouter matériel", 0, this.btnAjouterMateriel_Click);
            ConstruireBoutonNav(this.btnNouveauPret, "📤  Nouveau prêt", 50, this.btnNouveauPret_Click);
            ConstruireBoutonNav(this.btnNouveauRetour, "📥  Enregistrer retour", 100, this.btnNouveauRetour_Click);
            ConstruireBoutonNav(this.btnInventaire, "📋  Inventaire", 150, this.btnInventaire_Click);
            ConstruireBoutonNav(this.btnActualiser, "🔄  Actualiser", 220, this.btnActualiser_Click);
            this.btnActualiser.BackColor = System.Drawing.Color.FromArgb(220, 230, 245);

            // ── pnlContenu ───────────────────────────────────────────
            this.pnlContenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenu.Padding = new System.Windows.Forms.Padding(10);
            this.pnlContenu.Controls.Add(this.tabControl);

            // ── tabControl ───────────────────────────────────────────
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tabControl.Controls.AddRange(new System.Windows.Forms.TabPage[]
                { this.tabStock, this.tabPrets, this.tabRetards });

            // ── Tab Stock ────────────────────────────────────────────
            this.tabStock.Text = "📦  Stock complet";
            this.tabStock.Padding = new System.Windows.Forms.Padding(5);
            this.tabStock.Controls.AddRange(new System.Windows.Forms.Control[]
                { this.dgvStock, this.pnlRechercheBar });

            this.pnlRechercheBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRechercheBar.Height = 45;
            this.pnlRechercheBar.BackColor = System.Drawing.Color.White;
            this.pnlRechercheBar.Padding = new System.Windows.Forms.Padding(5, 8, 5, 5);
            this.pnlRechercheBar.Controls.AddRange(new System.Windows.Forms.Control[]
                { this.lblRecherche, this.txtRecherche, this.lblStockCount });

            this.lblRecherche.Text = "🔍";
            this.lblRecherche.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblRecherche.AutoSize = true;
            this.lblRecherche.Location = new System.Drawing.Point(5, 10);

            this.txtRecherche.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRecherche.Size = new System.Drawing.Size(300, 28);
            this.txtRecherche.Location = new System.Drawing.Point(30, 8);
            this.txtRecherche.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecherche.ForeColor = System.Drawing.Color.Gray;
            this.txtRecherche.Text = "Rechercher par code, type, marque...";
            this.txtRecherche.GotFocus += (s, e) => { if (this.txtRecherche.ForeColor == System.Drawing.Color.Gray) { this.txtRecherche.Text = ""; this.txtRecherche.ForeColor = System.Drawing.Color.Black; } };
            this.txtRecherche.LostFocus += (s, e) => { if (string.IsNullOrWhiteSpace(this.txtRecherche.Text)) { this.txtRecherche.Text = "Rechercher par code, type, marque..."; this.txtRecherche.ForeColor = System.Drawing.Color.Gray; } };
            this.txtRecherche.TextChanged += new System.EventHandler(this.txtRecherche_TextChanged);

            this.lblStockCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStockCount.ForeColor = System.Drawing.Color.Gray;
            this.lblStockCount.AutoSize = true;
            this.lblStockCount.Location = new System.Drawing.Point(345, 12);

            // dgvStock
            ConfigurerDataGridView(this.dgvStock);
            this.dgvStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colId, this.colCode, this.colType, this.colMarque,
                this.colTaille, this.colEtat, this.colDispo
            });
            this.dgvStock.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStock_CellDoubleClick);

            this.colId.Name = "colId"; this.colId.HeaderText = "ID"; this.colId.Width = 40; this.colId.Visible = false;
            this.colCode.Name = "colCode"; this.colCode.HeaderText = "Code"; this.colCode.Width = 110;
            this.colType.Name = "colType"; this.colType.HeaderText = "Type"; this.colType.Width = 130;
            this.colMarque.Name = "colMarque"; this.colMarque.HeaderText = "Marque"; this.colMarque.Width = 110;
            this.colTaille.Name = "colTaille"; this.colTaille.HeaderText = "Taille/Point."; this.colTaille.Width = 100;
            this.colEtat.Name = "colEtat"; this.colEtat.HeaderText = "État"; this.colEtat.Width = 110;
            this.colDispo.Name = "colDispo"; this.colDispo.HeaderText = "Disponibilité"; this.colDispo.Width = 110;

            // ── Tab Prêts ─────────────────────────────────────────────
            this.tabPrets.Text = "📤  Prêts en cours";
            this.tabPrets.Padding = new System.Windows.Forms.Padding(5);
            this.tabPrets.Controls.AddRange(new System.Windows.Forms.Control[]
                { this.dgvPrets, this.lblPretsCount });

            this.lblPretsCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPretsCount.Height = 30;
            this.lblPretsCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPretsCount.ForeColor = System.Drawing.Color.Gray;
            this.lblPretsCount.Padding = new System.Windows.Forms.Padding(5, 8, 0, 0);

            ConfigurerDataGridView(this.dgvPrets);
            this.dgvPrets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colPretId, this.colPretAdherent, this.colPretCode,
                this.colPretMarque, this.colPretDate, this.colPretJours
            });

            this.colPretId.Name = "colPretId"; this.colPretId.HeaderText = "ID"; this.colPretId.Width = 40; this.colPretId.Visible = false;
            this.colPretAdherent.Name = "colPretAdherent"; this.colPretAdherent.HeaderText = "Adhérent"; this.colPretAdherent.Width = 200;
            this.colPretCode.Name = "colPretCode"; this.colPretCode.HeaderText = "Code"; this.colPretCode.Width = 110;
            this.colPretMarque.Name = "colPretMarque"; this.colPretMarque.HeaderText = "Marque"; this.colPretMarque.Width = 110;
            this.colPretDate.Name = "colPretDate"; this.colPretDate.HeaderText = "Début"; this.colPretDate.Width = 110;
            this.colPretJours.Name = "colPretJours"; this.colPretJours.HeaderText = "Durée"; this.colPretJours.Width = 100;

            // ── Tab Retards ───────────────────────────────────────────
            this.tabRetards.Text = "⚠️  Retards";
            this.tabRetards.Padding = new System.Windows.Forms.Padding(5);
            this.tabRetards.Controls.AddRange(new System.Windows.Forms.Control[]
                { this.dgvRetards, this.lblRetardsCount });

            this.lblRetardsCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRetardsCount.Height = 30;
            this.lblRetardsCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRetardsCount.Padding = new System.Windows.Forms.Padding(5, 8, 0, 0);

            ConfigurerDataGridView(this.dgvRetards);
            this.dgvRetards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRetards.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colRetAdherent, this.colRetCode, this.colRetMarque,
                this.colRetDate, this.colRetJours, this.colRetType
            });

            this.colRetAdherent.Name = "colRetAdherent"; this.colRetAdherent.HeaderText = "Adhérent"; this.colRetAdherent.Width = 200;
            this.colRetCode.Name = "colRetCode"; this.colRetCode.HeaderText = "Code"; this.colRetCode.Width = 110;
            this.colRetMarque.Name = "colRetMarque"; this.colRetMarque.HeaderText = "Marque"; this.colRetMarque.Width = 110;
            this.colRetDate.Name = "colRetDate"; this.colRetDate.HeaderText = "Début"; this.colRetDate.Width = 110;
            this.colRetJours.Name = "colRetJours"; this.colRetJours.HeaderText = "Jours"; this.colRetJours.Width = 90;
            this.colRetType.Name = "colRetType"; this.colRetType.HeaderText = "Type retard"; this.colRetType.Width = 200;

            // ── GestionForm ───────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 720);
            this.MinimumSize = new System.Drawing.Size(1100, 680);
            this.Controls.Add(this.pnlContenu);
            this.Controls.Add(this.pnlGauche);
            this.Controls.Add(this.pnlKpi);
            this.Controls.Add(this.pnlTop);
            this.Name = "GestionForm";
            this.Text = "LyonPalme — Gestion du matériel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GestionForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GestionForm_FormClosed);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlKpi.ResumeLayout(false);
            this.pnlGauche.ResumeLayout(false);
            this.pnlContenu.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabStock.ResumeLayout(false);
            this.tabPrets.ResumeLayout(false);
            this.tabRetards.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvPrets).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvRetards).EndInit();
            this.ResumeLayout(false);
        }

        // ── Helpers Designer ─────────────────────────────────────────

        private void ConstruireKpi(System.Windows.Forms.Panel pnl,
                                   System.Windows.Forms.Label lblLib,
                                   System.Windows.Forms.Label lblVal,
                                   string libelle,
                                   System.Drawing.Color couleur,
                                   int x, int y)
        {
            pnl.BackColor = System.Drawing.Color.White;
            pnl.Size = new System.Drawing.Size(265, 72);
            pnl.Location = new System.Drawing.Point(x, y);

            lblLib.Text = libelle;
            lblLib.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblLib.ForeColor = System.Drawing.Color.Gray;
            lblLib.AutoSize = true;
            lblLib.Location = new System.Drawing.Point(12, 10);

            lblVal.Text = "—";
            lblVal.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            lblVal.ForeColor = couleur;
            lblVal.AutoSize = true;
            lblVal.Location = new System.Drawing.Point(12, 28);

            pnl.Controls.Add(lblLib);
            pnl.Controls.Add(lblVal);
        }

        private void ConstruireBoutonNav(System.Windows.Forms.Button btn,
                                          string texte, int top,
                                          System.EventHandler handler)
        {
            btn.Text = texte;
            btn.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            btn.Size = new System.Drawing.Size(178, 40);
            btn.Location = new System.Drawing.Point(0, top);
            btn.BackColor = System.Drawing.Color.FromArgb(15, 32, 65);
            btn.ForeColor = System.Drawing.Color.White;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.Click += handler;
        }

        private void ConfigurerDataGridView(System.Windows.Forms.DataGridView dgv)
        {
            dgv.BackgroundColor = System.Drawing.Color.White;
            dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 243, 250);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(50, 60, 80);
            dgv.ColumnHeadersHeight = 36;
            dgv.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgv.RowTemplate.Height = 30;
            dgv.GridColor = System.Drawing.Color.FromArgb(230, 235, 245);
            dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.EnableHeadersVisualStyles = false;
            dgv.MultiSelect = false;
        }

        #endregion

        // ── Contrôles ────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label lblBienvenue;
        private System.Windows.Forms.Button btnDeconnecter;

        private System.Windows.Forms.Panel pnlKpi;
        private System.Windows.Forms.Panel pnlKpiTotal;
        private System.Windows.Forms.Label lblKpiTotalLib;
        private System.Windows.Forms.Label lblKpiTotal;
        private System.Windows.Forms.Panel pnlKpiDispo;
        private System.Windows.Forms.Label lblKpiDispoLib;
        private System.Windows.Forms.Label lblKpiDispo;
        private System.Windows.Forms.Panel pnlKpiPrete;
        private System.Windows.Forms.Label lblKpiPreteLib;
        private System.Windows.Forms.Label lblKpiPrete;
        private System.Windows.Forms.Panel pnlKpiRetards;
        private System.Windows.Forms.Label lblKpiRetardsLib;
        private System.Windows.Forms.Label lblKpiRetards;

        private System.Windows.Forms.Panel pnlGauche;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnAjouterMateriel;
        private System.Windows.Forms.Button btnNouveauPret;
        private System.Windows.Forms.Button btnNouveauRetour;
        private System.Windows.Forms.Button btnInventaire;
        private System.Windows.Forms.Button btnActualiser;

        private System.Windows.Forms.Panel pnlContenu;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabStock;
        private System.Windows.Forms.Panel pnlRechercheBar;
        private System.Windows.Forms.TextBox txtRecherche;
        private System.Windows.Forms.Label lblRecherche;
        private System.Windows.Forms.Label lblStockCount;
        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.TabPage tabPrets;
        private System.Windows.Forms.Label lblPretsCount;
        private System.Windows.Forms.DataGridView dgvPrets;
        private System.Windows.Forms.TabPage tabRetards;
        private System.Windows.Forms.Label lblRetardsCount;
        private System.Windows.Forms.DataGridView dgvRetards;

        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMarque;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTaille;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEtat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDispo;

        private System.Windows.Forms.DataGridViewTextBoxColumn colPretId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPretAdherent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPretCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPretMarque;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPretDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPretJours;

        private System.Windows.Forms.DataGridViewTextBoxColumn colRetAdherent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRetCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRetMarque;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRetDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRetJours;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRetType;
    }
}