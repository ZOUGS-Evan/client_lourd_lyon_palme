namespace LyonPalme.Forms
{
    partial class MaterielAddForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitre = new System.Windows.Forms.Label();
            this.pnlCarte = new System.Windows.Forms.Panel();
            this.lblCodeLib = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblMarqueLib = new System.Windows.Forms.Label();
            this.txtMarque = new System.Windows.Forms.TextBox();
            this.lblTypeLib = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.lblEtatLib = new System.Windows.Forms.Label();
            this.cboEtat = new System.Windows.Forms.ComboBox();
            this.lblPointure = new System.Windows.Forms.Label();
            this.txtPointure = new System.Windows.Forms.TextBox();
            this.lblMateriaux = new System.Windows.Forms.Label();
            this.txtMateriaux = new System.Windows.Forms.TextBox();
            this.lblTaille = new System.Windows.Forms.Label();
            this.txtTaille = new System.Windows.Forms.TextBox();
            this.lblTenuSaison = new System.Windows.Forms.Label();
            this.cboTenuSaison = new System.Windows.Forms.ComboBox();
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

            this.lblTitre.Text = "➕  Ajouter un matériel";
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitre.ForeColor = System.Drawing.Color.White;
            this.lblTitre.AutoSize = true;
            this.lblTitre.Location = new System.Drawing.Point(15, 14);

            // pnlCarte
            this.pnlCarte.BackColor = System.Drawing.Color.White;
            this.pnlCarte.Padding = new System.Windows.Forms.Padding(25, 20, 25, 20);
            this.pnlCarte.Dock = System.Windows.Forms.DockStyle.Fill;

            // Helpers
            int lx = 25, rx = 235, w = 185, lh = 22, th = 28, gap = 58;
            int y = 20;

            // Code
            Champ(this.lblCodeLib, "Code *", lx, y);
            Champ(this.txtCode, lx, y + lh, w, th);
            // Marque
            Champ(this.lblMarqueLib, "Marque *", rx, y);
            Champ(this.txtMarque, rx, y + lh, w, th);
            y += gap;

            // Type
            Champ(this.lblTypeLib, "Type *", lx, y);
            this.cboType.Location = new System.Drawing.Point(lx, y + lh);
            this.cboType.Size = new System.Drawing.Size(w, th);
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // Etat
            Champ(this.lblEtatLib, "État *", rx, y);
            this.cboEtat.Location = new System.Drawing.Point(rx, y + lh);
            this.cboEtat.Size = new System.Drawing.Size(w, th);
            this.cboEtat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEtat.Font = new System.Drawing.Font("Segoe UI", 10F);
            y += gap;

            // Pointure
            Champ(this.lblPointure, "Pointure *", lx, y);
            Champ(this.txtPointure, lx, y + lh, w, th);
            // Matériaux
            Champ(this.lblMateriaux, "Matériaux *", rx, y);
            Champ(this.txtMateriaux, rx, y + lh, w, th);
            y += gap;

            // Taille
            Champ(this.lblTaille, "Taille *", lx, y);
            Champ(this.txtTaille, lx, y + lh, w, th);
            // TenuSaison
            Champ(this.lblTenuSaison, "Saison *", rx, y);
            this.cboTenuSaison.Location = new System.Drawing.Point(rx, y + lh);
            this.cboTenuSaison.Size = new System.Drawing.Size(w, th);
            this.cboTenuSaison.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTenuSaison.Font = new System.Drawing.Font("Segoe UI", 10F);
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

            this.btnValider.Text = "✔  Ajouter";
            this.btnValider.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnValider.Size = new System.Drawing.Size(150, 38);
            this.btnValider.Location = new System.Drawing.Point(270, y - 2);
            this.btnValider.BackColor = System.Drawing.Color.FromArgb(15, 32, 65);
            this.btnValider.ForeColor = System.Drawing.Color.White;
            this.btnValider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValider.FlatAppearance.BorderSize = 0;
            this.btnValider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);

            // Ajout contrôles carte
            this.pnlCarte.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.lblCodeLib, this.txtCode, this.lblMarqueLib, this.txtMarque,
                this.lblTypeLib, this.cboType, this.lblEtatLib, this.cboEtat,
                this.lblPointure, this.txtPointure, this.lblMateriaux, this.txtMateriaux,
                this.lblTaille, this.txtTaille, this.lblTenuSaison, this.cboTenuSaison,
                this.lblMessage, this.btnAnnuler, this.btnValider
            });

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 460);
            this.Controls.Add(this.pnlCarte);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MaterielAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ajouter un matériel";
            this.Load += new System.EventHandler(this.MaterielAddForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlCarte.ResumeLayout(false);
            this.pnlCarte.PerformLayout();
            this.ResumeLayout(false);
        }

        private void Champ(System.Windows.Forms.Label lbl, string texte, int x, int y)
        {
            lbl.Text = texte;
            lbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lbl.ForeColor = System.Drawing.Color.FromArgb(50, 60, 80);
            lbl.AutoSize = true;
            lbl.Location = new System.Drawing.Point(x, y);
        }

        private void Champ(System.Windows.Forms.TextBox txt, int x, int y, int w, int h)
        {
            txt.Font = new System.Drawing.Font("Segoe UI", 10F);
            txt.Size = new System.Drawing.Size(w, h);
            txt.Location = new System.Drawing.Point(x, y);
            txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        #region Controls
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Panel pnlCarte;
        private System.Windows.Forms.Label lblCodeLib;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblMarqueLib;
        private System.Windows.Forms.TextBox txtMarque;
        private System.Windows.Forms.Label lblTypeLib;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label lblEtatLib;
        private System.Windows.Forms.ComboBox cboEtat;
        private System.Windows.Forms.Label lblPointure;
        private System.Windows.Forms.TextBox txtPointure;
        private System.Windows.Forms.Label lblMateriaux;
        private System.Windows.Forms.TextBox txtMateriaux;
        private System.Windows.Forms.Label lblTaille;
        private System.Windows.Forms.TextBox txtTaille;
        private System.Windows.Forms.Label lblTenuSaison;
        private System.Windows.Forms.ComboBox cboTenuSaison;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Button btnAnnuler;
        #endregion
    }
}