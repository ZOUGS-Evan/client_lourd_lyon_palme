namespace LyonPalme.Forms
{
    partial class RetourForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitre = new System.Windows.Forms.Label();
            this.pnlCarte = new System.Windows.Forms.Panel();
            this.lblPretLib = new System.Windows.Forms.Label();
            this.cboPret = new System.Windows.Forms.ComboBox();
            this.lblPretsCount = new System.Windows.Forms.Label();
            this.lblInfoPret = new System.Windows.Forms.Label();
            this.lblRetard = new System.Windows.Forms.Label();
            this.lblEtatLib = new System.Windows.Forms.Label();
            this.cboEtat = new System.Windows.Forms.ComboBox();
            this.lblDateLib = new System.Windows.Forms.Label();
            this.dtpDateRetour = new System.Windows.Forms.DateTimePicker();
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
            this.lblTitre.Text = "📥  Enregistrer un retour";
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitre.ForeColor = System.Drawing.Color.White;
            this.lblTitre.AutoSize = true;
            this.lblTitre.Location = new System.Drawing.Point(15, 14);

            // pnlCarte
            this.pnlCarte.BackColor = System.Drawing.Color.White;
            this.pnlCarte.Dock = System.Windows.Forms.DockStyle.Fill;

            int x = 25, w = 390, y = 20;

            // Prêt en cours
            L(this.lblPretLib, "Prêt en cours *", x, y);
            this.cboPret.Location = new System.Drawing.Point(x, y + 22);
            this.cboPret.Size = new System.Drawing.Size(w, 28);
            this.cboPret.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPret.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPret.SelectedIndexChanged += new System.EventHandler(this.cboPret_SelectedIndexChanged);

            this.lblPretsCount.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPretsCount.ForeColor = System.Drawing.Color.Gray;
            this.lblPretsCount.AutoSize = true;
            this.lblPretsCount.Location = new System.Drawing.Point(x, y + 53);

            this.lblInfoPret.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblInfoPret.ForeColor = System.Drawing.Color.FromArgb(15, 32, 65);
            this.lblInfoPret.Size = new System.Drawing.Size(w, 22);
            this.lblInfoPret.Location = new System.Drawing.Point(x, y + 72);

            this.lblRetard.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRetard.ForeColor = System.Drawing.Color.Crimson;
            this.lblRetard.AutoSize = true;
            this.lblRetard.Location = new System.Drawing.Point(x, y + 94);
            this.lblRetard.Visible = false;
            y += 120;

            // État
            L(this.lblEtatLib, "État du matériel au retour *", x, y);
            this.cboEtat.Location = new System.Drawing.Point(x, y + 22);
            this.cboEtat.Size = new System.Drawing.Size(w, 28);
            this.cboEtat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEtat.Font = new System.Drawing.Font("Segoe UI", 10F);
            y += 65;

            // Date retour
            L(this.lblDateLib, "Date de retour *", x, y);
            this.dtpDateRetour.Location = new System.Drawing.Point(x, y + 22);
            this.dtpDateRetour.Size = new System.Drawing.Size(200, 28);
            this.dtpDateRetour.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDateRetour.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            y += 65;

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

            this.btnValider.Text = "✔  Enregistrer";
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
                this.lblPretLib, this.cboPret, this.lblPretsCount,
                this.lblInfoPret, this.lblRetard,
                this.lblEtatLib, this.cboEtat,
                this.lblDateLib, this.dtpDateRetour,
                this.lblMessage, this.btnAnnuler, this.btnValider
            });

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 460);
            this.Controls.Add(this.pnlCarte);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RetourForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enregistrer un retour";
            this.Load += new System.EventHandler(this.RetourForm_Load);
            this.pnlTop.ResumeLayout(false); this.pnlTop.PerformLayout();
            this.pnlCarte.ResumeLayout(false); this.pnlCarte.PerformLayout();
            this.ResumeLayout(false);
        }

        private void L(System.Windows.Forms.Label lbl, string t, int x, int y)
        { lbl.Text = t; lbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); lbl.ForeColor = System.Drawing.Color.FromArgb(50, 60, 80); lbl.AutoSize = true; lbl.Location = new System.Drawing.Point(x, y); }

        private System.Windows.Forms.Panel pnlTop, pnlCarte;
        private System.Windows.Forms.Label lblTitre, lblPretLib, lblPretsCount;
        private System.Windows.Forms.Label lblInfoPret, lblRetard, lblEtatLib, lblDateLib, lblMessage;
        private System.Windows.Forms.ComboBox cboPret, cboEtat;
        private System.Windows.Forms.DateTimePicker dtpDateRetour;
        private System.Windows.Forms.Button btnValider, btnAnnuler;
    }
}