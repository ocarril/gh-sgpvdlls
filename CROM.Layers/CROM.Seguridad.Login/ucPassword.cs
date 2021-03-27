namespace CROM.Seguridad.Login
{
    using CROM.Seguridad.BussinesEntities;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.settings;
    using CROM.Tools.Comun.Web;
    using CROM.Tools.Windows;

    using System;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    public partial class ucPassword : UserControl
    {

        private Accesos oAccessLocal = new Accesos();
        public string propUsuario { get; set; }
        private string msSistema = string.Empty;

        public ucPassword(string pCodSistemaInicio)
        {
            InitializeComponent();
            msSistema = pCodSistemaInicio;
        }

        #region METODOS PRIVADOS

        private bool validarUsuario()
        {
            bool bStatus = true;
            errorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
            errorProvider1.SetError(txtPasswordActual, "");
            errorProvider1.SetError(txtPasswordNuevo, "");
            errorProvider1.SetError(txtPasswordConfirmar, "");

            //if (GlobalSettings.GetDEFAULT_Encriptacion() == WebConstants.TipoEncriptacion.EXTDLL.ToString())
            //{
                string pMessage = string.Empty;
                if (!oAccessLocal.DetectLoginPasswordExterno(propUsuario, txtPasswordActual.Text, out pMessage))
                {
                    errorProvider1.SetError(txtPasswordActual, pMessage);
                    bStatus = false;
                }
            //}
            //else
            //{
                //if (!oAccessLocal.DetectLoginPassword(propUsuario, txtPasswordActual.Text))
                //{
                //    errorProvider1.SetError(txtPasswordActual,
                //                            WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == 2004).Value);
                //    bStatus = false;
                //}
            //}

            if (txtPasswordNuevo.Text == "" && bStatus)
            {
                errorProvider1.SetError(txtPasswordNuevo,
                                        WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == 2018).Value);
                bStatus = false;
            }

            if (txtPasswordConfirmar.Text == "" && bStatus)
            {
                errorProvider1.SetError(txtPasswordConfirmar,
                                        WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == 2019).Value);
                bStatus = false;
            }

            if (txtPasswordNuevo.Text != txtPasswordConfirmar.Text && bStatus)
            {
                errorProvider1.SetError(txtPasswordConfirmar,
                                        WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == 2020).Value);
                bStatus = false;
            }

            return bStatus;
        }

        #endregion

        #region EVENTOS DE CONTROLES

        private void ucPassword_Load(object sender, EventArgs e)
        {
            txtLogin.Text = propUsuario;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarUsuario())
                {
                    if (oAccessLocal.UpdatePasswordRec(txtLogin.Text,
                                                       txtPasswordNuevo.Text, 
                                                       chkEnviarCorreo.Checked,
                                                       Environment.MachineName.ToString(),
                                                       HelpWindows.Usuario(false)))

                        MessageBox.Show(WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == 2021).Value,
                                       "Cambiar Password", MessageBoxButtons.OK, MessageBoxIcon.Information,
                                       MessageBoxDefaultButton.Button1);

                    else

                        MessageBox.Show(WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == 2022).Value,
                                        "Cambiar Password", MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                        MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cambiar Password", MessageBoxButtons.OK, MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);
            }
        }

        private void btnMail_Click(object sender, EventArgs e)
        {
            try
            {


                if (propUsuario != "")
                {

                    string lsPassword = HelpCrypto.GenerarContrasenia();
                    BEUsuario itemUsuario = oAccessLocal.UserRolOptions(txtLogin.Text, string.Empty, msSistema);
                    if (itemUsuario.codUsuario != null)
                    {

                        StringBuilder lsMensaje = new StringBuilder();
                        lsMensaje.AppendLine("El nuevo password para el usuario: " + txtLogin.Text);
                        lsMensaje.AppendLine("se enviara al siguiente correo: " + itemUsuario.desCorreo);
                        lsMensaje.AppendLine("desea continuar");

                        if (MessageBox.Show(lsMensaje.ToString(), "Enviar Password",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {

                            if (oAccessLocal.UpdatePasswordRec(txtLogin.Text,
                                                               lsPassword, true,
                                                               Environment.MachineName.ToString(),
                                                               HelpWindows.Usuario(false)))
                            {
                                MessageBox.Show(WebConstants.ValidacionDatosSEGURIDAD.FirstOrDefault(x => x.Key == 2023).Value,
                                               "Cambiar Password", MessageBoxButtons.OK, MessageBoxIcon.Information,
                                                MessageBoxDefaultButton.Button1);

                                //Mail oMail = new Mail();
                                //List<MailDatos> Lista = new List<MailDatos>();

                                //Lista.Add(new MailDatos { titulo = "User", descripcion = txtLogin.Text });
                                //Lista.Add(new MailDatos { titulo = "Password", descripcion = lsPassword });
                                //Lista.Add(new MailDatos { titulo = "-", descripcion = "-"});
                                //Lista.Add(new MailDatos { titulo = "PC", descripcion =  Environment.MachineName.ToString() });
                                //Lista.Add(new MailDatos { titulo = "PC User", descripcion = HelpWindows.Usuario(true) });


                                //string lsNota = "Nota : El nuevo password se genero de forma aleatoria se recomienda ingresar al sistema y modificalo.";
                                //string lsBody = oMail.CrearBody("Servicio de envio de Password", Lista, lsNota, "Oxinet");
                                //oMail.EnvioCorreo("SSI - Envio de Password", lsBody, itemUsuario.Correo);
                            }
                            else
                                MessageBox.Show("Se produjo un erro al enviar el Password. consulte con el administrador", "Enviar correo electrónico",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El usuario no se encuentra registrado.", "Enviar correo electrónico",
                                         MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Enviar correo electrónico", MessageBoxButtons.OK, MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);
            }
        }

        private void ucPassword_VisibleChanged(object sender, EventArgs e)
        {
            txtLogin.Text = propUsuario;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();

        }

        #endregion
    }
}