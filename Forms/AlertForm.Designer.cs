namespace LyonPalme.Forms
{
    partial class AlertForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblIcone = new System.Windows.Forms.Label();
            this.lblTitre = new System.Windows.Forms.Label();
            this.pnlCarte = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlCarte.SuspendLayout();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(15, 32, 65);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 55;
            this.pnlTop.Controls.AddRange(new System.Windows.Forms.Control[]
                { this.lblIcone, this.lblTitre });

            this.lblIcone.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblIcone.AutoSize = true;
            this.lblIcone.Location = new System.Drawing.Point(12, 10);

            this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitre.ForeColor = System.Drawing.Color.White;
            this.lblTitre.AutoSize = true;
            this.lblTitre.Location = new System.Drawing.Point(50, 15);

            // pnlCarte
            this.pnlCarte.BackColor = System.Drawing.Color.White;
            this.pnlCarte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCarte.Padding = new System.Windows.Forms.Padding(25, 20, 25, 15);
            this.pnlCarte.Controls.AddRange(new System.Windows.Forms.Control[]
                { this.lblMessage, this.btnOk });

            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(40, 50, 70);
            this.lblMessage.Size = new System.Drawing.Size(360, 80);
            this.lblMessage.Location = new System.Drawing.Point(25, 20);
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.btnOk.Text = "OK";
            this.btnOk.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOk.Size = new System.Drawing.Size(120, 38);
            this.btnOk.Location = new System.Drawing.Point(265, 115);
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(15, 32, 65);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 220);
            this.Controls.Add(this.pnlCarte);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlertForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alert";
            this.pnlTop.ResumeLayout(false); this.pnlTop.PerformLayout();
            this.pnlCarte.ResumeLayout(false); this.pnlCarte.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop, pnlCarte;
        private System.Windows.Forms.Label lblIcone, lblTitre, lblMessage;
        private System.Windows.Forms.Button btnOk;
    }
}