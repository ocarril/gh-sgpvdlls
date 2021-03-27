namespace CROM.Seguridad.Login
{
    partial class IniciarSesion
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pnCuerpo = new System.Windows.Forms.Panel();
            this.ckbOpciones = new System.Windows.Forms.CheckBox();
            this.ptbLateral = new System.Windows.Forms.PictureBox();
            this.ptbCabecera = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLateral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCabecera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 302);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(455, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pnCuerpo
            // 
            this.pnCuerpo.Location = new System.Drawing.Point(153, 79);
            this.pnCuerpo.Name = "pnCuerpo";
            this.pnCuerpo.Size = new System.Drawing.Size(290, 219);
            this.pnCuerpo.TabIndex = 10;
            // 
            // ckbOpciones
            // 
            this.ckbOpciones.Appearance = System.Windows.Forms.Appearance.Button;
            this.ckbOpciones.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckbOpciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ckbOpciones.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.ckbOpciones.Image = global::CROM.Seguridad.Login.Properties.Resources.SSI_back;
            this.ckbOpciones.Location = new System.Drawing.Point(443, 242);
            this.ckbOpciones.Name = "ckbOpciones";
            this.ckbOpciones.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ckbOpciones.Size = new System.Drawing.Size(25, 35);
            this.ckbOpciones.TabIndex = 11;
            this.ckbOpciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckbOpciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ckbOpciones.UseVisualStyleBackColor = true;
            this.ckbOpciones.CheckedChanged += new System.EventHandler(this.ckbOpciones_CheckedChanged);
            // 
            // ptbLateral
            // 
            this.ptbLateral.Image = global::CROM.Seguridad.Login.Properties.Resources.Usuarios;
            this.ptbLateral.Location = new System.Drawing.Point(12, 79);
            this.ptbLateral.Name = "ptbLateral";
            this.ptbLateral.Size = new System.Drawing.Size(128, 84);
            this.ptbLateral.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbLateral.TabIndex = 8;
            this.ptbLateral.TabStop = false;
            // 
            // ptbCabecera
            // 
            this.ptbCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.ptbCabecera.Image = global::CROM.Seguridad.Login.Properties.Resources.SSI_CabeceraCROM;
            this.ptbCabecera.Location = new System.Drawing.Point(0, 0);
            this.ptbCabecera.Name = "ptbCabecera";
            this.ptbCabecera.Size = new System.Drawing.Size(455, 75);
            this.ptbCabecera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbCabecera.TabIndex = 9;
            this.ptbCabecera.TabStop = false;
            this.toolTip1.SetToolTip(this.ptbCabecera, "Desarrollo de sistemas a medida Cel.997405565 - Orlando Carril Ramírez");
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(146, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2, 169);
            this.label1.TabIndex = 12;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CROM.Seguridad.Login.Properties.Resources.SSI_Key;
            this.pictureBox1.Location = new System.Drawing.Point(12, 166);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 131);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // IniciarSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(455, 324);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ckbOpciones);
            this.Controls.Add(this.pnCuerpo);
            this.Controls.Add(this.ptbLateral);
            this.Controls.Add(this.ptbCabecera);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IniciarSesion";
            this.Opacity = 0.8;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar sesión";
            this.Load += new System.EventHandler(this.IniciarSesion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbLateral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCabecera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbLateral;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.PictureBox ptbCabecera;
        private System.Windows.Forms.Panel pnCuerpo;
        private System.Windows.Forms.CheckBox ckbOpciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}