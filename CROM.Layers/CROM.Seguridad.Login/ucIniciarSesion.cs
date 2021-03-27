namespace CROM.Seguridad.Login
{
    using CROM.GC.Services.Interfaces.seguridad;
    using CROM.Seguridad.BussinesEntities;
    using CROM.Seguridad.BussinesEntities.acceso;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.security;
    using CROM.Tools.Comun.settings;
    using CROM.Tools.Comun.Web;
    using CROM.Tools.Windows;

    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

    public partial class ucIniciarSesion : UserControl
    {
        public BEUsuarioValidoResponse objUsuarioValidado = new BEUsuarioValidoResponse();
        public List<BEUsuarioPermisoResponse> lstOpcionPermisos = new List<BEUsuarioPermisoResponse>();
       
        public string propUsuario { get; set; }
        public bool ServicioConectado = true;
        public bool prmVisibleAlmacen { get; set; }

        private int CONTADOR_ACCESS = 1;
        private string msSistema = string.Empty;
        private Accesos oAccesos = new Accesos();

        #region ---- Eventos de la Página  ----

        public ucIniciarSesion()
        {
            if (GlobalSettings.GetDEFAULT_SistemaInicio()!= null)
                msSistema = GlobalSettings.GetDEFAULT_SistemaInicio(); 
            else
                MessageBox.Show("Este programa no tiene código de sistema de inicio.");

            InitializeComponent();
        }
        public ucIniciarSesion(string pSistemaInicio)
        {
            msSistema = pSistemaInicio;
            InitializeComponent();
        }
        private void ucIniciarSesion_Load(object sender, EventArgs e)
        {
            try
            {
                if (msSistema != string.Empty)
                {

                    //BESistema itemSistema = new BESistema();
                    //itemSistema = oAccesos.FindSystem(msSistema);
                    lblSistema.Text = "SIST. DE FACTURACIÓN ELECTRONICA";

                    HelpAccesos.Sistema = lblSistema.Text;
                    txtLogin.Text = HelpWindows.Usuario(false);

                    Permisos();
                }
                else
                {
                    MessageBox.Show("Este programa no tiene código de sistema de inicio", "Es Complementario!", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    btnAceptar.Enabled = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Seguridad CROM", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        #endregion

        #region ---- Eventos de los Controles  ----

        private void txtLogin_Validating(object sender, CancelEventArgs e)
        {
            Permisos();
            propUsuario = txtLogin.Text;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            AccederAlSistema();
        }
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        #endregion

        #region ---- Metodos del Desarrollador  ----

        private void RolVisible(bool pVisible)
        {
            cboRoles.Visible = pVisible;
            lblRol.Visible = pVisible;
        }

        private void Permisos()
            {
            try
            {
                RolVisible(false);
                cboRoles.DataSource = null;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Seguridad CROM", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }
        private void keypressed(Object o, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Return)
                {
                    e.Handled = true;
                    AccederAlSistema();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Seguridad CROM", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, 
                                MessageBoxDefaultButton.Button1);
            }
        }

        private void AccederAlSistema()
        {
            try
            {

                if (CONTADOR_ACCESS > 2)
                    this.FindForm().Close();

                BEUsuarioValidoResponse usuarioValido = null;

                if (GlobalSettings.GetDEFAULT_ServicioWEB())
                {
                    usuarioValido = ApiServiceSeguridad.ValidarInicioSesion(txtLogin.Text,
                                                                            txtPassword.Text,
                                                                            GlobalSettings.GetDEFAULT_KEY_SYSTEM());

                }
                else
                {
                    usuarioValido = oAccesos.DetectLoginPasswordValid(txtLogin.Text,
                                                                      txtPassword.Text,
                                                                      GlobalSettings.GetDEFAULT_KEY_SYSTEM(),
                                                                      HelpWindows.Usuario(true));
                }

                if (usuarioValido != null && usuarioValido.ResultIndValido)
                {

                    BEUsuarioValidoResponse ouserValido = new BEUsuarioValidoResponse();
                    ouserValido = JsonConvert.DeserializeObject<BEUsuarioValidoResponse>(JsonConvert.SerializeObject(usuarioValido));

                    List<BEUsuarioPermisoResponse> lstUsuarioPermisos = new List<BEUsuarioPermisoResponse>();
                    List<BEUsuarioPermisoResponse> lstRolOpcion = new List<BEUsuarioPermisoResponse>();

                    if (GlobalSettings.GetDEFAULT_ServicioWEB())
                    {
                        var dataPermiso = new BEUsuarioPermisoRequest
                        {
                            codEmpresa = usuarioValido.codEmpresa,
                            codSistema = usuarioValido.codSistema,
                            desLogin = usuarioValido.desLogin,
                            tipoObjeto = string.Empty,
                            token = usuarioValido.Token
                        };

                        lstUsuarioPermisos = ApiServiceSeguridad.ListUserObjectGrants(dataPermiso);

                    }
                    else
                    {
                        lstUsuarioPermisos = oAccesos.ListUserObjectsGrants(ouserValido.codEmpresa,
                                                                            ouserValido.codSistema,
                                                                            ouserValido.desLogin,
                                                                            string.Empty,
                                                                            string.Empty);
                    }

                    ouserValido.lstObjeto = lstUsuarioPermisos;

                    lstRolOpcion = ouserValido.lstObjeto.ToList<BEUsuarioPermisoResponse>();

                    ouserValido.codRol = ouserValido.codRol;
                    ouserValido.codRolNombre = ouserValido.codRolNombre;
                    ouserValido.codPersonaEmpresa = ouserValido.numRUC;
                    ouserValido.codPersonaEmpresaNombre = ouserValido.codEmpresaNombre;
                    ouserValido.codPersonaEmpresaDomicilio = string.Empty;
                    ouserValido.codPersonaRUCEmpresa = ouserValido.numRUC;

                    if (ptbLogo.Image != null)
                        HelpImages.CrearArchivoDesdeBinario(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                                                        "logo.png"),
                                                            HelpImages.DeImagenBD_aBytes(ptbLogo.Image), false);
                    else
                        if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logo.png")))
                        HelpImages.CrearArchivoDesdeBinario(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                                                        "logo.png"),
                                                            HelpImages.DeImagenBD_aBytes(ResourceIconos.LogoComun), false);

                    HelpAccesos.SerializarUsuario(ouserValido);

                    this.FindForm().DialogResult = DialogResult.OK;
                    objUsuarioValidado = ouserValido;
                    lstOpcionPermisos = lstRolOpcion;

                    Hide();

                }
                else
                {
                    MessageBox.Show(usuarioValido.ResultIMessage, "Verificar Datos!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ++CONTADOR_ACCESS;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

    }
}
