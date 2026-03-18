namespace LyonPalme.Forms
{
    partial class GestionForm
    {
        private System.ComponentModel.IContainer components = null;

        // Nouveaux conteneurs layout
        private System.Windows.Forms.TableLayoutPanel tlpTop;
        private System.Windows.Forms.TableLayoutPanel tlpKpi;
        private System.Windows.Forms.FlowLayoutPanel flpActions;

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
            this.tlpTop = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitre = new System.Windows.Forms.Label();
            this.lblBienvenue = new System.Windows.Forms.Label();
            this.btnDeconnecter = new System.Windows.Forms.Button();

            this.pnlKpi = new System.Windows.Forms.Panel();
            this.tlpKpi = new System.Windows.Forms.TableLayoutPanel();
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
            this.flpActions = new System.Windows.Forms.FlowLayoutPanel();
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
            this.pnlRecherchePrets = new System.Windows.Forms.Panel();
            this.txtRecherchePrets = new System.Windows.Forms.TextBox();
            this.lblRecherchePrets = new System.Windows.Forms.Label();
            this.lblPretsCount = new System.Windows.Forms.Label();
            this.dgvPrets = new System.Windows.Forms.DataGridView();
            this.tabRetards = new System.Windows.Forms.TabPage();
            this.pnlRechercheRetards = new System.Windows.Forms.Panel();
            this.txtRechercheRetards = new System.Windows.Forms.TextBox();
            this.lblRechercheRetards = new System.Windows.Forms.Label();
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
            this.tlpTop.SuspendLayout();
            this.pnlKpi.SuspendLayout();
            this.tlpKpi.SuspendLayout();
            this.pnlGauche.SuspendLayout();
            this.flpActions.SuspendLayout();
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
            this.pnlTop.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.pnlTop.Controls.Add(this.tlpTop);

            // ── tlpTop (structure Header) ─────────────────────────────
            this.tlpTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTop.ColumnCount = 3;
            this.tlpTop.RowCount = 1;
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop.Controls.Add(this.lblTitre, 0, 0);
            this.tlpTop.Controls.Add(this.lblBienvenue, 1, 0);
            this.tlpTop.Controls.Add(this.btnDeconnecter, 2, 0);

            this.lblTitre.Text = "LyonPalme — Gestion du matériel";
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitre.ForeColor = System.Drawing.Color.White;
            this.lblTitre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.lblBienvenue.Text = string.Empty;
            this.lblBienvenue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBienvenue.ForeColor = System.Drawing.Color.White;
            this.lblBienvenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBienvenue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.btnDeconnecter.Text = "Déconnecter";
            this.btnDeconnecter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeconnecter.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDeconnecter.Size = new System.Drawing.Size(145, 42);
            this.btnDeconnecter.Margin = new System.Windows.Forms.Padding(0, 11, 0, 11);
            this.btnDeconnecter.BackColor = System.Drawing.Color.FromArgb(180, 30, 30);
            this.btnDeconnecter.ForeColor = System.Drawing.Color.White;
            this.btnDeconnecter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeconnecter.FlatAppearance.BorderSize = 0;
            this.btnDeconnecter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeconnecter.Click += new System.EventHandler(this.btnDeconnecter_Click);

            // ── pnlKpi ───────────────────────────────────────────────
            this.pnlKpi.BackColor = System.Drawing.Color.FromArgb(240, 243, 250);
            this.pnlKpi.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpi.Height = 90;
            this.pnlKpi.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.pnlKpi.Controls.Add(this.tlpKpi);

            // ── tlpKpi (KPI responsive) ───────────────────────────────
            this.tlpKpi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpKpi.ColumnCount = 4;
            this.tlpKpi.RowCount = 1;
            this.tlpKpi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKpi.Padding = new System.Windows.Forms.Padding(0);
            this.tlpKpi.Margin = new System.Windows.Forms.Padding(0);

            this.tlpKpi.Controls.Add(this.pnlKpiTotal, 0, 0);
            this.tlpKpi.Controls.Add(this.pnlKpiDispo, 1, 0);
            this.tlpKpi.Controls.Add(this.pnlKpiPrete, 2, 0);
            this.tlpKpi.Controls.Add(this.pnlKpiRetards, 3, 0);

            ConstruireKpi(this.pnlKpiTotal, this.lblKpiTotalLib, this.lblKpiTotal, "Total matériels", System.Drawing.Color.FromArgb(15, 32, 65));
            ConstruireKpi(this.pnlKpiDispo, this.lblKpiDispoLib, this.lblKpiDispo, "Disponibles", System.Drawing.Color.FromArgb(34, 139, 34));
            ConstruireKpi(this.pnlKpiPrete, this.lblKpiPreteLib, this.lblKpiPrete, "Prêtés", System.Drawing.Color.FromArgb(200, 100, 0));
            ConstruireKpi(this.pnlKpiRetards, this.lblKpiRetardsLib, this.lblKpiRetards, "Retards", System.Drawing.Color.FromArgb(180, 30, 30));

            // ── pnlGauche ─────────────────────────────────────────────
            this.pnlGauche.BackColor = System.Drawing.Color.FromArgb(248, 249, 252);
            this.pnlGauche.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGauche.Width = 200;
            this.pnlGauche.Padding = new System.Windows.Forms.Padding(10, 15, 10, 10);
            this.pnlGauche.Controls.Add(this.flpActions);

            // ── flpActions (nav propre) ───────────────────────────────
            this.flpActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpActions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpActions.WrapContents = false;
            this.flpActions.AutoSize = true;
            this.flpActions.Margin = new System.Windows.Forms.Padding(0);
            this.flpActions.Padding = new System.Windows.Forms.Padding(0);
            this.flpActions.Controls.Add(this.btnAjouterMateriel);
            this.flpActions.Controls.Add(this.btnNouveauPret);
            this.flpActions.Controls.Add(this.btnNouveauRetour);
            this.flpActions.Controls.Add(this.btnInventaire);
            this.flpActions.Controls.Add(this.btnActualiser);

            ConstruireBoutonNav(this.btnAjouterMateriel, "Ajouter matériel", this.btnAjouterMateriel_Click);
            ConstruireBoutonNav(this.btnNouveauPret, "Nouveau prêt", this.btnNouveauPret_Click);
            ConstruireBoutonNav(this.btnNouveauRetour, "Enregistrer retour", this.btnNouveauRetour_Click);
            ConstruireBoutonNav(this.btnInventaire, "Inventaire", this.btnInventaire_Click);
            ConstruireBoutonNavSecondaire(this.btnActualiser, "Actualiser", this.btnActualiser_Click);

            // ── pnlContenu ───────────────────────────────────────────
            this.pnlContenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenu.Padding = new System.Windows.Forms.Padding(10);
            this.pnlContenu.BackColor = System.Drawing.Color.FromArgb(240, 243, 250);
            this.pnlContenu.Controls.Add(this.tabControl);

            // ── tabControl ───────────────────────────────────────────
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tabControl.Controls.AddRange(new System.Windows.Forms.TabPage[]
                { this.tabStock, this.tabPrets, this.tabRetards });
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);

            // ── Tab Stock ────────────────────────────────────────────
            this.tabStock.Text = "Stock complet";
            this.tabStock.Padding = new System.Windows.Forms.Padding(8);
            this.tabStock.BackColor = System.Drawing.Color.White;
            this.tabStock.Controls.AddRange(new System.Windows.Forms.Control[]
                { this.dgvStock, this.pnlRechercheBar });

            this.pnlRechercheBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRechercheBar.Height = 56;
            this.pnlRechercheBar.BackColor = System.Drawing.Color.White;
            this.pnlRechercheBar.Padding = new System.Windows.Forms.Padding(10, 12, 10, 10);
            this.pnlRechercheBar.Controls.AddRange(new System.Windows.Forms.Control[]
                { this.lblRecherche, this.txtRecherche, this.lblStockCount });

            this.lblRecherche.Text = "Recherche";
            this.lblRecherche.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRecherche.ForeColor = System.Drawing.Color.FromArgb(50, 60, 80);
            this.lblRecherche.AutoSize = true;
            this.lblRecherche.Location = new System.Drawing.Point(10, 18);

            this.txtRecherche.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRecherche.Location = new System.Drawing.Point(95, 14);
            this.txtRecherche.Size = new System.Drawing.Size(380, 28);
            this.txtRecherche.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecherche.ForeColor = System.Drawing.Color.Black;              // CHANGÉ
            this.txtRecherche.Text = string.Empty;                                 // CHANGÉ
            this.txtRecherche.GotFocus -= (s, e) => { if (this.txtRecherche.ForeColor == System.Drawing.Color.Gray) { this.txtRecherche.Text = ""; this.txtRecherche.ForeColor = System.Drawing.Color.Black; } }; // CHANGÉ
            this.txtRecherche.LostFocus -= (s, e) => { if (string.IsNullOrWhiteSpace(this.txtRecherche.Text)) { this.txtRecherche.Text = "Rechercher par code, type, marque..."; this.txtRecherche.ForeColor = System.Drawing.Color.Gray; } }; // CHANGÉ
            this.txtRecherche.TextChanged += new System.EventHandler(this.txtRecherche_TextChanged);

            this.lblStockCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStockCount.ForeColor = System.Drawing.Color.Gray;
            this.lblStockCount.AutoSize = true;
            this.lblStockCount.Location = new System.Drawing.Point(490, 18);

            // dgvStock
            ConfigurerDataGridView(this.dgvStock);
            this.dgvStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colId, this.colCode, this.colType, this.colMarque,
                this.colTaille, this.colEtat, this.colDispo
            });
            this.dgvStock.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStock_CellDoubleClick);

            this.colId.Name = "colId"; this.colId.HeaderText = "ID"; this.colId.Visible = false;
            this.colCode.Name = "colCode"; this.colCode.HeaderText = "Code";
            this.colType.Name = "colType"; this.colType.HeaderText = "Type";
            this.colMarque.Name = "colMarque"; this.colMarque.HeaderText = "Marque";
            this.colTaille.Name = "colTaille"; this.colTaille.HeaderText = "Taille/Point.";
            this.colEtat.Name = "colEtat"; this.colEtat.HeaderText = "État";
            this.colDispo.Name = "colDispo"; this.colDispo.HeaderText = "Disponibilité";

            // ── Tab Prêts ─────────────────────────────────────────────
            this.tabPrets.Text = "Prêts en cours";
            this.tabPrets.Padding = new System.Windows.Forms.Padding(8);
            this.tabPrets.BackColor = System.Drawing.Color.White;
            this.tabPrets.Controls.AddRange(new System.Windows.Forms.Control[]
                { this.dgvPrets, this.pnlRecherchePrets });

            this.pnlRecherchePrets.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRecherchePrets.Height = 56;
            this.pnlRecherchePrets.BackColor = System.Drawing.Color.White;
            this.pnlRecherchePrets.Padding = new System.Windows.Forms.Padding(10, 12, 10, 10);
            this.pnlRecherchePrets.Controls.AddRange(new System.Windows.Forms.Control[]
                { this.lblRecherchePrets, this.txtRecherchePrets, this.lblPretsCount });

            this.lblRecherchePrets.Text = "Recherche";
            this.lblRecherchePrets.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRecherchePrets.ForeColor = System.Drawing.Color.FromArgb(50, 60, 80);
            this.lblRecherchePrets.AutoSize = true;
            this.lblRecherchePrets.Location = new System.Drawing.Point(10, 18);

            this.txtRecherchePrets.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRecherchePrets.Location = new System.Drawing.Point(95, 14);
            this.txtRecherchePrets.Size = new System.Drawing.Size(380, 28);
            this.txtRecherchePrets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecherchePrets.ForeColor = System.Drawing.Color.Black;         // CHANGÉ
            this.txtRecherchePrets.Text = string.Empty;                            // CHANGÉ
            this.txtRecherchePrets.GotFocus -= (s, e) => { if (this.txtRecherchePrets.ForeColor == System.Drawing.Color.Gray) { this.txtRecherchePrets.Text = ""; this.txtRecherchePrets.ForeColor = System.Drawing.Color.Black; } }; // CHANGÉ
            this.txtRecherchePrets.LostFocus -= (s, e) => { if (string.IsNullOrWhiteSpace(this.txtRecherchePrets.Text)) { this.txtRecherchePrets.Text = "Rechercher par adhérent, code, marque..."; this.txtRecherchePrets.ForeColor = System.Drawing.Color.Gray; } }; // CHANGÉ
            this.txtRecherchePrets.TextChanged += new System.EventHandler(this.txtRecherchePrets_TextChanged);

            this.lblPretsCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPretsCount.ForeColor = System.Drawing.Color.Gray;
            this.lblPretsCount.AutoSize = true;
            this.lblPretsCount.Location = new System.Drawing.Point(490, 18);

            ConfigurerDataGridView(this.dgvPrets);
            this.dgvPrets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colPretId, this.colPretAdherent, this.colPretCode,
                this.colPretMarque, this.colPretDate, this.colPretJours
            });

            this.colPretId.Name = "colPretId"; this.colPretId.HeaderText = "ID"; this.colPretId.Visible = false;
            this.colPretAdherent.Name = "colPretAdherent"; this.colPretAdherent.HeaderText = "Adhérent";
            this.colPretCode.Name = "colPretCode"; this.colPretCode.HeaderText = "Code";
            this.colPretMarque.Name = "colPretMarque"; this.colPretMarque.HeaderText = "Marque";
            this.colPretDate.Name = "colPretDate"; this.colPretDate.HeaderText = "Début";
            this.colPretJours.Name = "colPretJours"; this.colPretJours.HeaderText = "Durée";

            // ── Tab Retards ───────────────────────────────────────────
            this.tabRetards.Text = "Retards";
            this.tabRetards.Padding = new System.Windows.Forms.Padding(8);
            this.tabRetards.BackColor = System.Drawing.Color.White;
            this.tabRetards.Controls.AddRange(new System.Windows.Forms.Control[]
                { this.dgvRetards, this.pnlRechercheRetards });

            this.pnlRechercheRetards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRechercheRetards.Height = 56;
            this.pnlRechercheRetards.BackColor = System.Drawing.Color.White;
            this.pnlRechercheRetards.Padding = new System.Windows.Forms.Padding(10, 12, 10, 10);
            this.pnlRechercheRetards.Controls.AddRange(new System.Windows.Forms.Control[]
                { this.lblRechercheRetards, this.txtRechercheRetards, this.lblRetardsCount });

            this.lblRechercheRetards.Text = "Recherche";
            this.lblRechercheRetards.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRechercheRetards.ForeColor = System.Drawing.Color.FromArgb(50, 60, 80);
            this.lblRechercheRetards.AutoSize = true;
            this.lblRechercheRetards.Location = new System.Drawing.Point(10, 18);

            this.txtRechercheRetards.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRechercheRetards.Location = new System.Drawing.Point(95, 14);
            this.txtRechercheRetards.Size = new System.Drawing.Size(380, 28);
            this.txtRechercheRetards.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRechercheRetards.ForeColor = System.Drawing.Color.Black;       // CHANGÉ
            this.txtRechercheRetards.Text = string.Empty;                          // CHANGÉ
            this.txtRechercheRetards.GotFocus -= (s, e) => { if (this.txtRechercheRetards.ForeColor == System.Drawing.Color.Gray) { this.txtRechercheRetards.Text = ""; this.txtRechercheRetards.ForeColor = System.Drawing.Color.Black; } }; // CHANGÉ
            this.txtRechercheRetards.LostFocus -= (s, e) => { if (string.IsNullOrWhiteSpace(this.txtRechercheRetards.Text)) { this.txtRechercheRetards.Text = "Rechercher par adhérent, code, marque, type..."; this.txtRechercheRetards.ForeColor = System.Drawing.Color.Gray; } }; // CHANGÉ
            this.txtRechercheRetards.TextChanged += new System.EventHandler(this.txtRechercheRetards_TextChanged);

            this.lblRetardsCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRetardsCount.ForeColor = System.Drawing.Color.FromArgb(180, 30, 30);
            this.lblRetardsCount.AutoSize = true;
            this.lblRetardsCount.Location = new System.Drawing.Point(490, 18);

            ConfigurerDataGridView(this.dgvRetards);
            this.dgvRetards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRetards.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colRetAdherent, this.colRetCode, this.colRetMarque,
                this.colRetDate, this.colRetJours, this.colRetType
            });

            this.colRetAdherent.Name = "colRetAdherent"; this.colRetAdherent.HeaderText = "Adhérent";
            this.colRetCode.Name = "colRetCode"; this.colRetCode.HeaderText = "Code";
            this.colRetMarque.Name = "colRetMarque"; this.colRetMarque.HeaderText = "Marque";
            this.colRetDate.Name = "colRetDate"; this.colRetDate.HeaderText = "Début";
            this.colRetJours.Name = "colRetJours"; this.colRetJours.HeaderText = "Jours";
            this.colRetType.Name = "colRetType"; this.colRetType.HeaderText = "Type retard";

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
            this.tlpTop.ResumeLayout(false);
            this.pnlKpi.ResumeLayout(false);
            this.tlpKpi.ResumeLayout(false);
            this.pnlGauche.ResumeLayout(false);
            this.flpActions.ResumeLayout(false);
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
                           System.Drawing.Color couleur)
        {
            pnl.BackColor = System.Drawing.Color.White;
            pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            pnl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            pnl.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);

            lblLib.Text = libelle;
            lblLib.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblLib.ForeColor = System.Drawing.Color.Gray;
            lblLib.AutoSize = true;
            lblLib.Location = new System.Drawing.Point(0, 0);

            lblVal.Text = "—";
            lblVal.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            lblVal.ForeColor = couleur;
            lblVal.AutoSize = true;
            lblVal.Location = new System.Drawing.Point(0, 20);

            pnl.Controls.Add(lblLib);
            pnl.Controls.Add(lblVal);
        }

        private void ConstruireBoutonNav(System.Windows.Forms.Button btn,
                                          string texte,
                                          System.EventHandler handler)
        {
            btn.Text = texte;
            btn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btn.Width = 178;
            btn.Height = 42;
            btn.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            btn.BackColor = System.Drawing.Color.FromArgb(15, 32, 65);
            btn.ForeColor = System.Drawing.Color.White;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(22, 45, 90);
            btn.Click += handler;
        }

        private void ConstruireBoutonNavSecondaire(System.Windows.Forms.Button btn,
                                          string texte,
                                          System.EventHandler handler)
        {
            btn.Text = texte;
            btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            btn.Width = 178;
            btn.Height = 32;
            btn.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            btn.BackColor = System.Drawing.Color.White;
            btn.ForeColor = System.Drawing.Color.FromArgb(100, 110, 130);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 205, 215);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(240, 243, 250);
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
            dgv.EnableHeadersVisualStyles = false;
            dgv.MultiSelect = false;

            dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 243, 250);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(50, 60, 80);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(240, 243, 250);
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(50, 60, 80);
            dgv.ColumnHeadersHeight = 36;

            dgv.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgv.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(55, 60, 70);
            dgv.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;

            dgv.RowTemplate.Height = 30;
            dgv.GridColor = System.Drawing.Color.FromArgb(230, 235, 245);
            dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
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
        private System.Windows.Forms.Panel pnlRecherchePrets;
        private System.Windows.Forms.TextBox txtRecherchePrets;
        private System.Windows.Forms.Label lblRecherchePrets;
        private System.Windows.Forms.Label lblPretsCount;
        private System.Windows.Forms.DataGridView dgvPrets;

        private System.Windows.Forms.TabPage tabRetards;
        private System.Windows.Forms.Panel pnlRechercheRetards;
        private System.Windows.Forms.TextBox txtRechercheRetards;
        private System.Windows.Forms.Label lblRechercheRetards;
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