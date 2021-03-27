namespace CROM.Seguridad.Login
{
    partial class ucPassword
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
            this.components = new System.ComponentModel.Container();
            this.txtPasswordActual = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtPasswordNuevo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPasswordConfirmar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnMail = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkEnviarCorreo = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPasswordActual
            // 
            this.txtPasswordActual.Location = new System.Drawing.Point(109, 59);
            this.txtPasswordActual.Name = "txtPasswordActual";
            this.txtPasswordActual.PasswordChar = '*';
            this.txtPasswordActual.Size = new System.Drawing.Size(158, 20);
            this.txtPasswordActual.TabIndex = 9;
            this.txtPasswordActual.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Contraseña Anterior:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Usuario:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(109, 35);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(158, 20);
            this.txtLogin.TabIndex = 7;
            // 
            // txtPasswordNuevo
            // 
            this.txtPasswordNuevo.Location = new System.Drawing.Point(109, 83);
            this.txtPasswordNuevo.Name = "txtPasswordNuevo";
            this.txtPasswordNuevo.PasswordChar = '*';
            this.txtPasswordNuevo.Size = new System.Drawing.Size(158, 20);
            this.txtPasswordNuevo.TabIndex = 11;
            this.txtPasswordNuevo.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "Nueva Contraseña:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPasswordConfirmar
            // 
            this.txtPasswordConfirmar.Location = new System.Drawing.Point(109, 107);
            this.txtPasswordConfirmar.Name = "txtPasswordConfirmar";
            this.txtPasswordConfirmar.PasswordChar = '*';
            this.txtPasswordConfirmar.Size = new System.Drawing.Size(158, 20);
            this.txtPasswordConfirmar.TabIndex = 13;
            this.txtPasswordConfirmar.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-4, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "Confirmar Contraseña:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnAceptar
            // 
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.Location = new System.Drawing.Point(66, 162);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 35);
            this.btnAceptar.TabIndex = 14;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Image = global::CROM.Seguridad.Login.Properties.Resources.SSI_Logout;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(173, 162);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 35);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnMail
            // 
            this.btnMail.Image = global::CROM.Seguridad.Login.Properties.Resources.SSI_Mail;
            this.btnMail.Location = new System.Drawing.Point(21, 162);
            this.btnMail.Name = "btnMail";
            this.btnMail.Size = new System.Drawing.Size(39, 35);
            this.btnMail.TabIndex = 16;
            this.btnMail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMail.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolTip1.SetToolTip(this.btnMail, "Enviar Contraseña por correo electronico");
            this.btnMail.UseVisualStyleBackColor = true;
            this.btnMail.Click += new System.EventHandler(this.btnMail_Click);
            // 
            // chkEnviarCorreo
            // 
            this.chkEnviarCorreo.AutoSize = true;
            this.chkEnviarCorreo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEnviarCorreo.Checked = true;
            this.chkEnviarCorreo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnviarCorreo.Location = new System.Drawing.Point(18, 133);
            this.chkEnviarCorreo.Name = "chkEnviarCorreo";
            this.chkEnviarCorreo.Size = new System.Drawing.Size(104, 17);
            this.chkEnviarCorreo.TabIndex = 18;
            this.chkEnviarCorreo.Text = "¿Enviar correo?:";
            this.chkEnviarCorreo.UseVisualStyleBackColor = true;
            // 
            // ucPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkEnviarCorreo);
            this.Controls.Add(this.btnMail);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtPasswordConfirmar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPasswordNuevo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPasswordActual);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLogin);
            this.Name = "ucPassword";
            this.Size = new System.Drawing.Size(290, 219);
            this.Load += new System.EventHandler(this.ucPassword_Load);
            this.VisibleChanged += new System.EventHandler(this.ucPassword_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPasswordActual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtPasswordNuevo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPasswordConfirmar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnMail;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkEnviarCorreo;
    }
}
