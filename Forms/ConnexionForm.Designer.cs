namespace LyonPalme.Forms
{
	partial class ConnexionForm
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
			this.pnlFond = new System.Windows.Forms.Panel();
			this.pnlCarte = new System.Windows.Forms.Panel();
			this.lblTitre = new System.Windows.Forms.Label();
			this.lblSousTitre = new System.Windows.Forms.Label();
			this.lblSeparateur = new System.Windows.Forms.Label();
			this.lblLogin = new System.Windows.Forms.Label();
			this.txtLogin = new System.Windows.Forms.TextBox();
			this.lblMdp = new System.Windows.Forms.Label();
			this.txtMdp = new System.Windows.Forms.TextBox();
			this.chkAfficherMdp = new System.Windows.Forms.CheckBox();
			this.btnConnecter = new System.Windows.Forms.Button();
			this.btnQuitter = new System.Windows.Forms.Button();
			this.lblMessage = new System.Windows.Forms.Label();
			this.lblVersion = new System.Windows.Forms.Label();
			this.pnlFond.SuspendLayout();
			this.pnlCarte.SuspendLayout();
			this.SuspendLayout();

			// ── pnlFond (fond bleu marine) ───────────────────────────
			this.pnlFond.BackColor = System.Drawing.Color.FromArgb(15, 32, 65);
			this.pnlFond.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlFond.Controls.Add(this.pnlCarte);
			this.pnlFond.Controls.Add(this.lblVersion);

			// ── pnlCarte (carte blanche centrée) ────────────────────
			this.pnlCarte.BackColor = System.Drawing.Color.White;
			this.pnlCarte.Size = new System.Drawing.Size(380, 420);
			this.pnlCarte.Location = new System.Drawing.Point(135, 70);
			this.pnlCarte.Controls.Add(this.lblTitre);
			this.pnlCarte.Controls.Add(this.lblSousTitre);
			this.pnlCarte.Controls.Add(this.lblSeparateur);
			this.pnlCarte.Controls.Add(this.lblLogin);
			this.pnlCarte.Controls.Add(this.txtLogin);
			this.pnlCarte.Controls.Add(this.lblMdp);
			this.pnlCarte.Controls.Add(this.txtMdp);
			this.pnlCarte.Controls.Add(this.chkAfficherMdp);
			this.pnlCarte.Controls.Add(this.btnConnecter);
			this.pnlCarte.Controls.Add(this.btnQuitter);
			this.pnlCarte.Controls.Add(this.lblMessage);

			// ── lblTitre ─────────────────────────────────────────────
			this.lblTitre.Text = "🤿  LyonPalme";
			this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 20F,
										System.Drawing.FontStyle.Bold);
			this.lblTitre.ForeColor = System.Drawing.Color.FromArgb(15, 32, 65);
			this.lblTitre.AutoSize = true;
			this.lblTitre.Location = new System.Drawing.Point(85, 30);

			// ── lblSousTitre ─────────────────────────────────────────
			this.lblSousTitre.Text = "Gestion du matériel";
			this.lblSousTitre.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.lblSousTitre.ForeColor = System.Drawing.Color.Gray;
			this.lblSousTitre.AutoSize = true;
			this.lblSousTitre.Location = new System.Drawing.Point(118, 72);

			// ── lblSeparateur ────────────────────────────────────────
			this.lblSeparateur.BackColor = System.Drawing.Color.FromArgb(220, 225, 235);
			this.lblSeparateur.Size = new System.Drawing.Size(320, 1);
			this.lblSeparateur.Location = new System.Drawing.Point(30, 105);

			// ── lblLogin ─────────────────────────────────────────────
			this.lblLogin.Text = "Identifiant";
			this.lblLogin.Font = new System.Drawing.Font("Segoe UI", 9F,
										System.Drawing.FontStyle.Bold);
			this.lblLogin.ForeColor = System.Drawing.Color.FromArgb(50, 60, 80);
			this.lblLogin.AutoSize = true;
			this.lblLogin.Location = new System.Drawing.Point(30, 125);

			// ── txtLogin ─────────────────────────────────────────────
			this.txtLogin.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.txtLogin.Size = new System.Drawing.Size(320, 30);
			this.txtLogin.Location = new System.Drawing.Point(30, 147);
			this.txtLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtLogin.MaxLength = 100;
			this.txtLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(
											this.txtLogin_KeyDown);

			// ── lblMdp ───────────────────────────────────────────────
			this.lblMdp.Text = "Mot de passe";
			this.lblMdp.Font = new System.Drawing.Font("Segoe UI", 9F,
										System.Drawing.FontStyle.Bold);
			this.lblMdp.ForeColor = System.Drawing.Color.FromArgb(50, 60, 80);
			this.lblMdp.AutoSize = true;
			this.lblMdp.Location = new System.Drawing.Point(30, 195);

			// ── txtMdp ───────────────────────────────────────────────
			this.txtMdp.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.txtMdp.Size = new System.Drawing.Size(320, 30);
			this.txtMdp.Location = new System.Drawing.Point(30, 217);
			this.txtMdp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtMdp.UseSystemPasswordChar = true;
			this.txtMdp.MaxLength = 256;
			this.txtMdp.KeyDown += new System.Windows.Forms.KeyEventHandler(
												   this.txtMdp_KeyDown);

			// ── chkAfficherMdp ───────────────────────────────────────
			this.chkAfficherMdp.Text = "Afficher le mot de passe";
			this.chkAfficherMdp.Font = new System.Drawing.Font("Segoe UI", 8.5F);
			this.chkAfficherMdp.ForeColor = System.Drawing.Color.Gray;
			this.chkAfficherMdp.AutoSize = true;
			this.chkAfficherMdp.Location = new System.Drawing.Point(30, 255);
			this.chkAfficherMdp.CheckedChanged += new System.EventHandler(
													   this.chkAfficherMdp_CheckedChanged);

			// ── btnConnecter ─────────────────────────────────────────
			this.btnConnecter.Text = "Se connecter";
			this.btnConnecter.Font = new System.Drawing.Font("Segoe UI", 10F,
											System.Drawing.FontStyle.Bold);
			this.btnConnecter.Size = new System.Drawing.Size(320, 42);
			this.btnConnecter.Location = new System.Drawing.Point(30, 285);
			this.btnConnecter.BackColor = System.Drawing.Color.FromArgb(15, 32, 65);
			this.btnConnecter.ForeColor = System.Drawing.Color.White;
			this.btnConnecter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnConnecter.FlatAppearance.BorderSize = 0;
			this.btnConnecter.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnConnecter.Click += new System.EventHandler(this.btnConnecter_Click);

			// ── btnQuitter ───────────────────────────────────────────
			this.btnQuitter.Text = "Quitter";
			this.btnQuitter.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnQuitter.Size = new System.Drawing.Size(320, 32);
			this.btnQuitter.Location = new System.Drawing.Point(30, 337);
			this.btnQuitter.BackColor = System.Drawing.Color.White;
			this.btnQuitter.ForeColor = System.Drawing.Color.FromArgb(100, 110, 130);
			this.btnQuitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnQuitter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 205, 215);
			this.btnQuitter.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);

			// ── lblMessage ───────────────────────────────────────────
			this.lblMessage.Text = string.Empty;
			this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 8.5F);
			this.lblMessage.ForeColor = System.Drawing.Color.Crimson;
			this.lblMessage.Size = new System.Drawing.Size(320, 36);
			this.lblMessage.Location = new System.Drawing.Point(30, 378);
			this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

			// ── lblVersion ───────────────────────────────────────────
			this.lblVersion.Text = "v1.0 — 2026";
			this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(80, 100, 130);
			this.lblVersion.AutoSize = true;
			this.lblVersion.Location = new System.Drawing.Point(280, 510);

			// ── ConnexionForm ─────────────────────────────────────────
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(650, 560);
			this.Controls.Add(this.pnlFond);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = true;
			this.Name = "ConnexionForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "LyonPalme — Connexion";
			this.Load += new System.EventHandler(this.ConnexionForm_Load);
			this.pnlFond.ResumeLayout(false);
			this.pnlCarte.ResumeLayout(false);
			this.pnlCarte.PerformLayout();
			this.ResumeLayout(false);
		}

		#endregion

		// ── Contrôles ────────────────────────────────────────────────
		private System.Windows.Forms.Panel pnlFond;
		private System.Windows.Forms.Panel pnlCarte;
		private System.Windows.Forms.Label lblTitre;
		private System.Windows.Forms.Label lblSousTitre;
		private System.Windows.Forms.Label lblSeparateur;
		private System.Windows.Forms.Label lblLogin;
		private System.Windows.Forms.TextBox txtLogin;
		private System.Windows.Forms.Label lblMdp;
		private System.Windows.Forms.TextBox txtMdp;
		private System.Windows.Forms.CheckBox chkAfficherMdp;
		private System.Windows.Forms.Button btnConnecter;
		private System.Windows.Forms.Button btnQuitter;
		private System.Windows.Forms.Label lblMessage;
		private System.Windows.Forms.Label lblVersion;
	}
}