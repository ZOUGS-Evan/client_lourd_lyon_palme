namespace LyonPalme.Forms
{
    partial class InventaireForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitre = new System.Windows.Forms.Label();
            this.pnlTotaux = new System.Windows.Forms.Panel();
            this.pnlKpiTotal = new System.Windows.Forms.Panel();
            this.lblKpiTotalLib = new System.Windows.Forms.Label();
            this.lblTotalTotal = new System.Windows.Forms.Label();
            this.pnlKpiDispo = new System.Windows.Forms.Panel();
            this.lblKpiDispoLib = new System.Windows.Forms.Label();
            this.lblTotalDispo = new System.Windows.Forms.Label();
            this.pnlKpiPrete = new System.Windows.Forms.Panel();
            this.lblKpiPreteLib = new System.Windows.Forms.Label();
            this.lblTotalPrete = new System.Windows.Forms.Label();
            this.pnlContenu = new System.Windows.Forms.Panel();
            this.lblLignesCount = new System.Windows.Forms.Label();
            this.dgvInventaire = new System.Windows.Forms.DataGridView();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTaille = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDispo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBas = new System.Windows.Forms.Panel();
            this.btnActualiser = new System.Windows.Forms.Button();
            this.btnFermer = new System.Windows.Forms.Button();

            this.pnlTop.SuspendLayout();
            this.pnlTotaux.SuspendLayout();
            this.pnlContenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvInventaire).BeginInit();
            this.pnlBas.SuspendLayout();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(15, 32, 65);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 55;
            this.pnlTop.Controls.Add(this.lblTitre);
            this.lblTitre.Text = "📋  Inventaire du stock";
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitre.ForeColor = System.Drawing.Color.White;
            this.lblTitre.AutoSize = true;
            this.lblTitre.Location = new System.Drawing.Point(15, 14);

            // pnlTotaux (KPIs)
            this.pnlTotaux.BackColor = System.Drawing.Color.FromArgb(240, 243, 250);
            this.pnlTotaux.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTotaux.Height = 90;
            this.pnlTotaux.Controls.AddRange(new System.Windows.Forms.Control[]
                { this.pnlKpiTotal, this.pnlKpiDispo, this.pnlKpiPrete });

            Kpi(this.pnlKpiTotal, this.lblKpiTotalLib, this.lblTotalTotal,
                "Total", System.Drawing.Color.FromArgb(15, 32, 65), 15, 9);
            Kpi(this.pnlKpiDispo, this.lblKpiDispoLib, this.lblTotalDispo,
                "Disponibles", System.Drawing.Color.FromArgb(34, 139, 34), 295, 9);
            Kpi(this.pnlKpiPrete, this.lblKpiPreteLib, this.lblTotalPrete,
                "Prêtés", System.Drawing.Color.FromArgb(200, 100, 0), 575, 9);

            // pnlBas
            this.pnlBas.BackColor = System.Drawing.Color.FromArgb(240, 243, 250);
            this.pnlBas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBas.Height = 55;
            this.pnlBas.Controls.AddRange(new System.Windows.Forms.Control[]
                { this.btnActualiser, this.btnFermer });

            this.btnActualiser.Text = "🔄  Actualiser";
            this.btnActualiser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnActualiser.Size = new System.Drawing.Size(130, 34);
            this.btnActualiser.Location = new System.Drawing.Point(15, 11);
            this.btnActualiser.BackColor = System.Drawing.Color.FromArgb(220, 230, 245);
            this.btnActualiser.ForeColor = System.Drawing.Color.FromArgb(15, 32, 65);
            this.btnActualiser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualiser.FlatAppearance.BorderSize = 0;
            this.btnActualiser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualiser.Click += new System.EventHandler(this.btnActualiser_Click);

            this.btnFermer.Text = "Fermer";
            this.btnFermer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFermer.Size = new System.Drawing.Size(120, 34);
            this.btnFermer.Location = new System.Drawing.Point(730, 11);
            this.btnFermer.BackColor = System.Drawing.Color.White;
            this.btnFermer.ForeColor = System.Drawing.Color.FromArgb(100, 110, 130);
            this.btnFermer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFermer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 205, 215);
            this.btnFermer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);

            // pnlContenu
            this.pnlContenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenu.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.pnlContenu.Controls.Add(this.dgvInventaire);
            this.pnlContenu.Controls.Add(this.lblLignesCount);

            this.lblLignesCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLignesCount.Height = 26;
            this.lblLignesCount.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLignesCount.ForeColor = System.Drawing.Color.Gray;
            this.lblLignesCount.Padding = new System.Windows.Forms.Padding(3, 5, 0, 0);

            // dgvInventaire
            this.dgvInventaire.BackgroundColor = System.Drawing.Color.White;
            this.dgvInventaire.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInventaire.RowHeadersVisible = false;
            this.dgvInventaire.AllowUserToAddRows = false;
            this.dgvInventaire.ReadOnly = true;
            this.dgvInventaire.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventaire.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventaire.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvInventaire.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 243, 250);
            this.dgvInventaire.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(50, 60, 80);
            this.dgvInventaire.ColumnHeadersHeight = 36;
            this.dgvInventaire.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvInventaire.RowTemplate.Height = 30;
            this.dgvInventaire.EnableHeadersVisualStyles = false;
            this.dgvInventaire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventaire.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
                { this.colType, this.colTaille, this.colTotal, this.colDispo, this.colPrete });

            this.colType.HeaderText = "Type"; this.colType.Name = "colType";
            this.colTaille.HeaderText = "Taille/Pointure"; this.colTaille.Name = "colTaille";
            this.colTotal.HeaderText = "Total"; this.colTotal.Name = "colTotal";
            this.colDispo.HeaderText = "Disponibles"; this.colDispo.Name = "colDispo";
            this.colPrete.HeaderText = "Prêtés"; this.colPrete.Name = "colPrete";

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 580);
            this.Controls.Add(this.pnlContenu);
            this.Controls.Add(this.pnlBas);
            this.Controls.Add(this.pnlTotaux);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "InventaireForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inventaire du stock";
            this.Load += new System.EventHandler(this.InventaireForm_Load);

            this.pnlTop.ResumeLayout(false); this.pnlTop.PerformLayout();
            this.pnlTotaux.ResumeLayout(false);
            this.pnlContenu.ResumeLayout(false);
            this.pnlBas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvInventaire).EndInit();
            this.ResumeLayout(false);
        }

        private void Kpi(System.Windows.Forms.Panel pnl, System.Windows.Forms.Label lib,
                         System.Windows.Forms.Label val, string texte,
                         System.Drawing.Color couleur, int x, int y)
        {
            pnl.BackColor = System.Drawing.Color.White;
            pnl.Size = new System.Drawing.Size(265, 72);
            pnl.Location = new System.Drawing.Point(x, y);
            lib.Text = texte; lib.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lib.ForeColor = System.Drawing.Color.Gray; lib.AutoSize = true;
            lib.Location = new System.Drawing.Point(12, 10);
            val.Text = "—"; val.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            val.ForeColor = couleur; val.AutoSize = true;
            val.Location = new System.Drawing.Point(12, 28);
            pnl.Controls.Add(lib); pnl.Controls.Add(val);
        }

        private System.Windows.Forms.Panel pnlTop, pnlTotaux, pnlContenu, pnlBas;
        private System.Windows.Forms.Label lblTitre, lblLignesCount;
        private System.Windows.Forms.Panel pnlKpiTotal, pnlKpiDispo, pnlKpiPrete;
        private System.Windows.Forms.Label lblKpiTotalLib, lblTotalTotal;
        private System.Windows.Forms.Label lblKpiDispoLib, lblTotalDispo;
        private System.Windows.Forms.Label lblKpiPreteLib, lblTotalPrete;
        private System.Windows.Forms.DataGridView dgvInventaire;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType, colTaille, colTotal, colDispo, colPrete;
        private System.Windows.Forms.Button btnActualiser, btnFermer;
    }
}