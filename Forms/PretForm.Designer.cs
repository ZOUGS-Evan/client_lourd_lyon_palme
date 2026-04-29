namespace LyonPalme.Forms
{
    partial class PretForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitre = new System.Windows.Forms.Label();
            this.pnlCarte = new System.Windows.Forms.Panel();
            this.lblAdherentLib = new System.Windows.Forms.Label();
            this.cboAdherent = new System.Windows.Forms.ComboBox();
            this.lblMaterielLib = new System.Windows.Forms.Label();
            this.cboMateriel = new System.Windows.Forms.ComboBox();
            this.lblDispoCount = new System.Windows.Forms.Label();
            this.lblInfoMateriel = new System.Windows.Forms.Label();
            this.lblDateLib = new System.Windows.Forms.Label();
            this.dtpDateDebut = new System.Windows.Forms.DateTimePicker();
            // ── Nouveaux contrôles ──
            this.chkDateFin = new System.Windows.Forms.CheckBox();
            this.dtpDateFin = new System.Windows.Forms.DateTimePicker();
            this.lblInfoDateFin = new System.Windows.Forms.Label();
            // ────────────────────────
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnValider = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlCarte.SuspendLayout();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(15, 32, 65);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 55;
            this.pnlTop.Controls.Add(this.lblTitre);
            this.lblTitre.Text = "Enregistrer un pret";
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitre.ForeColor = System.Drawing.Color.White;
            this.lblTitre.AutoSize = true;
            this.lblTitre.Location = new System.Drawing.Point(15, 14);

            // pnlCarte
            this.pnlCarte.BackColor = System.Drawing.Color.White;
            this.pnlCarte.Dock = System.Windows.Forms.DockStyle.Fill;

            int x = 25, w = 390, y = 20;

            // Adherent
            L(this.lblAdherentLib, "Adherent *", x, y);
            this.cboAdherent.Location = new System.Drawing.Point(x, y + 22);
            this.cboAdherent.Size = new System.Drawing.Size(w, 28);
            this.cboAdherent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAdherent.Font = new System.Drawing.Font("Segoe UI", 10F);
            y += 65;

            // Materiel
            L(this.lblMaterielLib, "Materiel disponible *", x, y);
            this.cboMateriel.Location = new System.Drawing.Point(x, y + 22);
            this.cboMateriel.Size = new System.Drawing.Size(w, 28);
            this.cboMateriel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMateriel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboMateriel.SelectedIndexChanged += new System.EventHandler(this.cboMateriel_SelectedIndexChanged);

            this.lblDispoCount.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDispoCount.ForeColor = System.Drawing.Color.Gray;
            this.lblDispoCount.AutoSize = true;
            this.lblDispoCount.Location = new System.Drawing.Point(x, y + 52);

            this.lblInfoMateriel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblInfoMateriel.ForeColor = System.Drawing.Color.FromArgb(15, 32, 65);
            this.lblInfoMateriel.Size = new System.Drawing.Size(w, 22);
            this.lblInfoMateriel.Location = new System.Drawing.Point(x, y + 70);
            y += 105;

            // Date debut
            L(this.lblDateLib, "Date du pret *", x, y);
            this.dtpDateDebut.Location = new System.Drawing.Point(x, y + 22);
            this.dtpDateDebut.Size = new System.Drawing.Size(200, 28);
            this.dtpDateDebut.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDateDebut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateDebut.ValueChanged += new System.EventHandler(this.dtpDateDebut_ValueChanged);
            y += 65;

            // ── Date de fin prevue (optionnelle) ────────────────────

            this.chkDateFin.Text = "Definir une date de retour prevue";
            this.chkDateFin.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.chkDateFin.ForeColor = System.Drawing.Color.FromArgb(50, 60, 80);
            this.chkDateFin.AutoSize = true;
            this.chkDateFin.Location = new System.Drawing.Point(x, y);
            this.chkDateFin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkDateFin.CheckedChanged += new System.EventHandler(this.chkDateFin_CheckedChanged);
            y += 28;

            this.dtpDateFin.Location = new System.Drawing.Point(x, y);
            this.dtpDateFin.Size = new System.Drawing.Size(200, 28);
            this.dtpDateFin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDateFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFin.Enabled = false;
            y += 30;

            this.lblInfoDateFin.Size = new System.Drawing.Size(w, 20);
            this.lblInfoDateFin.Location = new System.Drawing.Point(x, y);
            this.lblInfoDateFin.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblInfoDateFin.ForeColor = System.Drawing.Color.FromArgb(100, 110, 130);
            y += 30;

            // ────────────────────────────────────────────────────────

            // Message
            this.lblMessage.Size = new System.Drawing.Size(w, 30);
            this.lblMessage.Location = new System.Drawing.Point(x, y);
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            y += 38;

            // Boutons
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAnnuler.Size = new System.Drawing.Size(120, 34);
            this.btnAnnuler.Location = new System.Drawing.Point(x, y);
            this.btnAnnuler.BackColor = System.Drawing.Color.White;
            this.btnAnnuler.ForeColor = System.Drawing.Color.FromArgb(100, 110, 130);
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 205, 215);
            this.btnAnnuler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);

            this.btnValider.Text = "Enregistrer";
            this.btnValider.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnValider.Size = new System.Drawing.Size(160, 38);
            this.btnValider.Location = new System.Drawing.Point(255, y - 2);
            this.btnValider.BackColor = System.Drawing.Color.FromArgb(15, 32, 65);
            this.btnValider.ForeColor = System.Drawing.Color.White;
            this.btnValider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValider.FlatAppearance.BorderSize = 0;
            this.btnValider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);

            this.pnlCarte.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.lblAdherentLib,  this.cboAdherent,
                this.lblMaterielLib,  this.cboMateriel,  this.lblDispoCount, this.lblInfoMateriel,
                this.lblDateLib,      this.dtpDateDebut,
                this.chkDateFin,      this.dtpDateFin,   this.lblInfoDateFin,
                this.lblMessage,      this.btnAnnuler,   this.btnValider
            });

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, y + 105);
            this.Controls.Add(this.pnlCarte);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PretForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enregistrer un pret";
            this.Load += new System.EventHandler(this.PretForm_Load);
            this.pnlTop.ResumeLayout(false); this.pnlTop.PerformLayout();
            this.pnlCarte.ResumeLayout(false); this.pnlCarte.PerformLayout();
            this.ResumeLayout(false);
        }

        private void L(System.Windows.Forms.Label lbl, string t, int x, int y)
        {
            lbl.Text = t;
            lbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lbl.ForeColor = System.Drawing.Color.FromArgb(50, 60, 80);
            lbl.AutoSize = true;
            lbl.Location = new System.Drawing.Point(x, y);
        }

        private System.Windows.Forms.Panel pnlTop, pnlCarte;
        private System.Windows.Forms.Label lblTitre, lblAdherentLib, lblMaterielLib;
        private System.Windows.Forms.Label lblDispoCount, lblInfoMateriel, lblDateLib, lblMessage;
        private System.Windows.Forms.Label lblInfoDateFin;
        private System.Windows.Forms.ComboBox cboAdherent, cboMateriel;
        private System.Windows.Forms.DateTimePicker dtpDateDebut;
        private System.Windows.Forms.DateTimePicker dtpDateFin;
        private System.Windows.Forms.CheckBox chkDateFin;
        private System.Windows.Forms.Button btnValider, btnAnnuler;
    }
}