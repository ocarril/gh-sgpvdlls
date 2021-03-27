namespace CROM.Seguridad.Login
{
    partial class ucAddress
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pHost = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblHost = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.btnReconectar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pHost.SuspendLayout();
            this.SuspendLayout();
            // 
            // pHost
            // 
            this.pHost.Controls.Add(this.label5);
            this.pHost.Controls.Add(this.lblHost);
            this.pHost.Controls.Add(this.txtHost);
            this.pHost.Location = new System.Drawing.Point(4, 27);
            this.pHost.Name = "pHost";
            this.pHost.Size = new System.Drawing.Size(281, 88);
            this.pHost.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Ejemplo : www.cromsystem.com.pe";
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(13, 30);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(35, 13);
            this.lblHost.TabIndex = 11;
            this.lblHost.Text = "Host :";
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(54, 26);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(218, 20);
            this.txtHost.TabIndex = 10;
            // 
            // btnReconectar
            // 
            this.btnReconectar.Image = global::CROM.Seguridad.Login.Properties.Resources.SSI_Connect;
            this.btnReconectar.Location = new System.Drawing.Point(58, 135);
            this.btnReconectar.Name = "btnReconectar";
            this.btnReconectar.Size = new System.Drawing.Size(90, 35);
            this.btnReconectar.TabIndex = 11;
            this.btnReconectar.Text = "Conectar";
            this.btnReconectar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReconectar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnReconectar.UseVisualStyleBackColor = true;
            this.btnReconectar.Click += new System.EventHandler(this.btnReconectar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = global::CROM.Seguridad.Login.Properties.Resources.SSI_Logout;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(173, 135);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 35);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ucAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnReconectar);
            this.Controls.Add(this.pHost);
            this.Name = "ucAddress";
            this.Size = new System.Drawing.Size(290, 219);
            this.Load += new System.EventHandler(this.ucAddress_Load);
            this.pHost.ResumeLayout(false);
            this.pHost.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pHost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Button btnReconectar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
