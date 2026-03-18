namespace LyonPalme.Forms
{
    partial class MaterielEditForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitre = new System.Windows.Forms.Label();
            this.pnlCarte = new System.Windows.Forms.Panel();
            this.lblTypeFixLib = new System.Windows.Forms.Label();
            this.lblTypeValeur = new System.Windows.Forms.Label();
            this.lblCodeLib = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblMarqueLib = new System.Windows.Forms.Label();
            this.txtMarque = new System.Windows.Forms.TextBox();
            this.lblEtatLib = new System.Windows.Forms.Label();
            this.cboEtat = new System.Windows.Forms.ComboBox();
            this.lblPointureLib = new System.Windows.Forms.Label();
            this.txtPointure = new System.Windows.Forms.TextBox();
            this.lblMateriauxLib = new System.Windows.Forms.Label();
            this.txtMateriaux = new System.Windows.Forms.TextBox();
            this.lblTailleLib = new System.Windows.Forms.Label();
            this.txtTaille = new System.Windows.Forms.TextBox();
            this.lblSaisonLib = new System.Windows.Forms.Label();
            this.cboSaison = new System.Windows.Forms.ComboBox();
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
            this.lblTitre.Text = "✏️  Modifier un matériel";
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitre.ForeColor = System.Drawing.Color.White;
            this.lblTitre.AutoSize = true;
            this.lblTitre.Location = new System.Drawing.Point(15, 14);

            // pnlCarte
            this.pnlCarte.BackColor = System.Drawing.Color.White;
            this.pnlCarte.Dock = System.Windows.Forms.DockStyle.Fill;

            int lx = 25, rx = 235, w = 185, gap = 58, y = 20;

            // Type (lecture seule)
            L(this.lblTypeFixLib, "Type", lx, y);
            this.lblTypeValeur.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTypeValeur.ForeColor = System.Drawing.Color.FromArgb(15, 32, 65);
            this.lblTypeValeur.AutoSize = true;
            this.lblTypeValeur.Location = new System.Drawing.Point(lx, y + 22);
            y += gap;

            // Code / Marque
            L(this.lblCodeLib, "Code *", lx, y); T(this.txtCode, lx, y + 22, w);
            L(this.lblMarqueLib, "Marque *", rx, y); T(this.txtMarque, rx, y + 22, w);
            y += gap;

            // Etat
            L(this.lblEtatLib, "État *", lx, y);
            this.cboEtat.Location = new System.Drawing.Point(lx, y + 22);
            this.cboEtat.Size = new System.Drawing.Size(w, 28);
            this.cboEtat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEtat.Font = new System.Drawing.Font("Segoe UI", 10F);
            y += gap;

            // Spécifiques
            L(this.lblPointureLib, "Pointure *", lx, y); T(this.txtPointure, lx, y + 22, w);
            L(this.lblMateriauxLib, "Matériaux *", rx, y); T(this.txtMateriaux, rx, y + 22, w);
            L(this.lblTailleLib, "Taille *", lx, y); T(this.txtTaille, lx, y + 22, w);
            L(this.lblSaisonLib, "Saison *", rx, y);
            this.cboSaison.Location = new System.Drawing.Point(rx, y + 22);
            this.cboSaison.Size = new System.Drawing.Size(w, 28);
            this.cboSaison.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSaison.Font = new System.Drawing.Font("Segoe UI", 10F);
            y += gap;

            // Message
            this.lblMessage.Size = new System.Drawing.Size(395, 30);
            this.lblMessage.Location = new System.Drawing.Point(lx, y);
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            y += 38;

            // Boutons
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAnnuler.Size = new System.Drawing.Size(120, 34);
            this.btnAnnuler.Location = new System.Drawing.Point(lx, y);
            this.btnAnnuler.BackColor = System.Drawing.Color.White;
            this.btnAnnuler.ForeColor = System.Drawing.Color.FromArgb(100, 110, 130);
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 205, 215);
            this.btnAnnuler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);

            this.btnValider.Text = "✔  Enregistrer";
            this.btnValider.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnValider.Size = new System.Drawing.Size(160, 38);
            this.btnValider.Location = new System.Drawing.Point(260, y - 2);
            this.btnValider.BackColor = System.Drawing.Color.FromArgb(15, 32, 65);
            this.btnValider.ForeColor = System.Drawing.Color.White;
            this.btnValider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValider.FlatAppearance.BorderSize = 0;
            this.btnValider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);

            this.pnlCarte.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.lblTypeFixLib, this.lblTypeValeur,
                this.lblCodeLib, this.txtCode, this.lblMarqueLib, this.txtMarque,
                this.lblEtatLib, this.cboEtat,
                this.lblPointureLib, this.txtPointure, this.lblMateriauxLib, this.txtMateriaux,
                this.lblTailleLib, this.txtTaille, this.lblSaisonLib, this.cboSaison,
                this.lblMessage, this.btnAnnuler, this.btnValider
            });

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 430);
            this.Controls.Add(this.pnlCarte);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MaterielEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modifier un matériel";
            this.Load += new System.EventHandler(this.MaterielEditForm_Load);
            this.pnlTop.ResumeLayout(false); this.pnlTop.PerformLayout();
            this.pnlCarte.ResumeLayout(false); this.pnlCarte.PerformLayout();
            this.ResumeLayout(false);
        }

        private void L(System.Windows.Forms.Label lbl, string t, int x, int y)
        { lbl.Text = t; lbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold); lbl.ForeColor = System.Drawing.Color.FromArgb(50, 60, 80); lbl.AutoSize = true; lbl.Location = new System.Drawing.Point(x, y); }

        private void T(System.Windows.Forms.TextBox txt, int x, int y, int w)
        { txt.Font = new System.Drawing.Font("Segoe UI", 10F); txt.Size = new System.Drawing.Size(w, 28); txt.Location = new System.Drawing.Point(x, y); txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; }

        private System.Windows.Forms.Panel pnlTop, pnlCarte;
        private System.Windows.Forms.Label lblTitre, lblTypeFixLib, lblTypeValeur;
        private System.Windows.Forms.Label lblCodeLib, lblMarqueLib, lblEtatLib;
        private System.Windows.Forms.Label lblPointureLib, lblMateriauxLib, lblTailleLib, lblSaisonLib;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtCode, txtMarque, txtPointure, txtMateriaux, txtTaille;
        private System.Windows.Forms.ComboBox cboEtat, cboSaison;
        private System.Windows.Forms.Button btnValider, btnAnnuler;
    }
}