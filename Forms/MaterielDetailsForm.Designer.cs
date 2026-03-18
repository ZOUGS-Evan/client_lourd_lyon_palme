namespace LyonPalme.Forms
{
    partial class MaterielDetailsForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitre = new System.Windows.Forms.Label();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.lblCodeLib = new System.Windows.Forms.Label();
            this.lblCodeValeur = new System.Windows.Forms.Label();
            this.lblTypeLib = new System.Windows.Forms.Label();
            this.lblTypeValeur = new System.Windows.Forms.Label();
            this.lblMarqueLib = new System.Windows.Forms.Label();
            this.lblMarqueValeur = new System.Windows.Forms.Label();
            this.lblTailleLib = new System.Windows.Forms.Label();
            this.lblTailleValeur = new System.Windows.Forms.Label();
            this.lblEtatLib = new System.Windows.Forms.Label();
            this.lblEtatValeur = new System.Windows.Forms.Label();
            this.lblDispoLib = new System.Windows.Forms.Label();
            this.lblDispoValeur = new System.Windows.Forms.Label();
            this.lblMateriauxLib = new System.Windows.Forms.Label();
            this.lblMateriauxValeur = new System.Windows.Forms.Label();
            this.lblSaisonLib = new System.Windows.Forms.Label();
            this.lblSaisonValeur = new System.Windows.Forms.Label();
            this.lblHistoriqueTitle = new System.Windows.Forms.Label();
            this.lblHistoriqueCount = new System.Windows.Forms.Label();
            this.dgvHistorique = new System.Windows.Forms.DataGridView();
            this.colHAdherent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHDebut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHRetour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHEtat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBoutons = new System.Windows.Forms.Panel();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnFermer = new System.Windows.Forms.Button();

            this.pnlTop.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.dgvHistorique).BeginInit();
            this.pnlBoutons.SuspendLayout();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(15, 32, 65);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 55;
            this.pnlTop.Controls.Add(this.lblTitre);
            this.lblTitre.Text = "🔍  Détails du matériel";
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitre.ForeColor = System.Drawing.Color.White;
            this.lblTitre.AutoSize = true;
            this.lblTitre.Location = new System.Drawing.Point(15, 14);

            // pnlBoutons (bas)
            this.pnlBoutons.BackColor = System.Drawing.Color.FromArgb(240, 243, 250);
            this.pnlBoutons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBoutons.Height = 55;
            this.pnlBoutons.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.pnlBoutons.Controls.AddRange(new System.Windows.Forms.Control[]
                { this.btnModifier, this.btnSupprimer, this.btnFermer });

            Btn(this.btnModifier, "✏️  Modifier", 10, 8, System.Drawing.Color.FromArgb(15, 32, 65), System.Drawing.Color.White, this.btnModifier_Click);
            Btn(this.btnSupprimer, "🗑  Supprimer", 175, 8, System.Drawing.Color.FromArgb(180, 30, 30), System.Drawing.Color.White, this.btnSupprimer_Click);
            Btn(this.btnFermer, "Fermer", 420, 8, System.Drawing.Color.White, System.Drawing.Color.FromArgb(100, 110, 130), this.btnFermer_Click);
            this.btnFermer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 205, 215);

            // pnlDetails (haut gauche)
            this.pnlDetails.BackColor = System.Drawing.Color.White;
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDetails.Width = 280;
            this.pnlDetails.Padding = new System.Windows.Forms.Padding(20, 15, 10, 10);

            int y = 15;
            InfoLigne(this.lblCodeLib, "Code", this.lblCodeValeur, 20, y); y += 48;
            InfoLigne(this.lblTypeLib, "Type", this.lblTypeValeur, 20, y); y += 48;
            InfoLigne(this.lblMarqueLib, "Marque", this.lblMarqueValeur, 20, y); y += 48;
            InfoLigne(this.lblTailleLib, "Taille/Point.", this.lblTailleValeur, 20, y); y += 48;
            InfoLigne(this.lblEtatLib, "État", this.lblEtatValeur, 20, y); y += 48;
            InfoLigne(this.lblDispoLib, "Disponibilité", this.lblDispoValeur, 20, y); y += 48;
            InfoLigne(this.lblMateriauxLib, "Matériaux", this.lblMateriauxValeur, 20, y);
            this.lblMateriauxLib.Visible = false; this.lblMateriauxValeur.Visible = false; y += 48;
            InfoLigne(this.lblSaisonLib, "Saison", this.lblSaisonValeur, 20, y);
            this.lblSaisonLib.Visible = false; this.lblSaisonValeur.Visible = false;

            this.pnlDetails.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.lblCodeLib, this.lblCodeValeur, this.lblTypeLib, this.lblTypeValeur,
                this.lblMarqueLib, this.lblMarqueValeur, this.lblTailleLib, this.lblTailleValeur,
                this.lblEtatLib, this.lblEtatValeur, this.lblDispoLib, this.lblDispoValeur,
                this.lblMateriauxLib, this.lblMateriauxValeur, this.lblSaisonLib, this.lblSaisonValeur
            });

            // Zone historique (droite)
            this.lblHistoriqueTitle.Text = "Historique des prêts";
            this.lblHistoriqueTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHistoriqueTitle.ForeColor = System.Drawing.Color.FromArgb(15, 32, 65);
            this.lblHistoriqueTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHistoriqueTitle.Height = 32;
            this.lblHistoriqueTitle.Padding = new System.Windows.Forms.Padding(8, 8, 0, 0);

            this.lblHistoriqueCount.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblHistoriqueCount.ForeColor = System.Drawing.Color.Gray;
            this.lblHistoriqueCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHistoriqueCount.Height = 22;
            this.lblHistoriqueCount.Padding = new System.Windows.Forms.Padding(8, 2, 0, 0);

            // dgvHistorique
            this.dgvHistorique.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorique.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistorique.RowHeadersVisible = false;
            this.dgvHistorique.AllowUserToAddRows = false;
            this.dgvHistorique.ReadOnly = true;
            this.dgvHistorique.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorique.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorique.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvHistorique.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 243, 250);
            this.dgvHistorique.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(50, 60, 80);
            this.dgvHistorique.ColumnHeadersHeight = 34;
            this.dgvHistorique.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvHistorique.RowTemplate.Height = 28;
            this.dgvHistorique.EnableHeadersVisualStyles = false;
            this.dgvHistorique.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistorique.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
                { this.colHAdherent, this.colHDebut, this.colHFin, this.colHRetour, this.colHEtat });

            this.colHAdherent.HeaderText = "Adhérent"; this.colHAdherent.Name = "colHAdherent";
            this.colHDebut.HeaderText = "Début"; this.colHDebut.Name = "colHDebut";
            this.colHFin.HeaderText = "Fin"; this.colHFin.Name = "colHFin";
            this.colHRetour.HeaderText = "Retour"; this.colHRetour.Name = "colHRetour";
            this.colHEtat.HeaderText = "État retour"; this.colHEtat.Name = "colHEtat";

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 560);
            this.Controls.Add(this.dgvHistorique);
            this.Controls.Add(this.lblHistoriqueCount);
            this.Controls.Add(this.lblHistoriqueTitle);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.pnlBoutons);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MaterielDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Détails du matériel";
            this.Load += new System.EventHandler(this.MaterielDetailsForm_Load);

            this.pnlTop.ResumeLayout(false); this.pnlTop.PerformLayout();
            this.pnlDetails.ResumeLayout(false); this.pnlDetails.PerformLayout();
            this.pnlBoutons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.dgvHistorique).EndInit();
            this.ResumeLayout(false);
        }

        private void InfoLigne(System.Windows.Forms.Label lib, string texteLib,
                                System.Windows.Forms.Label val, int x, int y)
        {
            lib.Text = texteLib; lib.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lib.ForeColor = System.Drawing.Color.Gray; lib.AutoSize = true;
            lib.Location = new System.Drawing.Point(x, y);
            val.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            val.ForeColor = System.Drawing.Color.FromArgb(30, 40, 60);
            val.AutoSize = true; val.Location = new System.Drawing.Point(x, y + 16);
        }

        private void Btn(System.Windows.Forms.Button b, string t, int x, int y,
                         System.Drawing.Color bg, System.Drawing.Color fg,
                         System.EventHandler h)
        {
            b.Text = t; b.Font = new System.Drawing.Font("Segoe UI", 9F);
            b.Size = new System.Drawing.Size(140, 34); b.Location = new System.Drawing.Point(x, y);
            b.BackColor = bg; b.ForeColor = fg;
            b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0; b.Cursor = System.Windows.Forms.Cursors.Hand;
            b.Click += h;
        }

        private System.Windows.Forms.Panel pnlTop, pnlDetails, pnlBoutons;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label lblCodeLib, lblCodeValeur;
        private System.Windows.Forms.Label lblTypeLib, lblTypeValeur;
        private System.Windows.Forms.Label lblMarqueLib, lblMarqueValeur;
        private System.Windows.Forms.Label lblTailleLib, lblTailleValeur;
        private System.Windows.Forms.Label lblEtatLib, lblEtatValeur;
        private System.Windows.Forms.Label lblDispoLib, lblDispoValeur;
        private System.Windows.Forms.Label lblMateriauxLib, lblMateriauxValeur;
        private System.Windows.Forms.Label lblSaisonLib, lblSaisonValeur;
        private System.Windows.Forms.Label lblHistoriqueTitle, lblHistoriqueCount;
        private System.Windows.Forms.DataGridView dgvHistorique;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHAdherent, colHDebut, colHFin, colHRetour, colHEtat;
        private System.Windows.Forms.Button btnModifier, btnSupprimer, btnFermer;
    }
}