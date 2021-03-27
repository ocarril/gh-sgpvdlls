namespace CROM.TablasMaestras.Interface
{
    using CROM.BusinessEntities.Maestros;
    using CROM.BusinessEntities.Maestros.DTO;
    using CROM.TablasMaestras.BussinesLogic;
    using CROM.Tools.Comun;
    using CROM.Tools.Comun.entities;
    using CROM.Tools.Windows;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;

    public partial class frmPersonaNueva : frm_Plantilla
    {
        public int prm_codEmpresa { get; set; }
        public string prm_desLogin { get; set; }
        public string prm_DEFAULT_PersonaNatural { get; set; }
        public string prm_DEFAULT_PersonaJuridica { get; set; }
        public string prm_DEFAULT_Domicilio_Fiscal { get; set; }
        public string prm_DEFAULT_DocumenPerNatural { get; set; }
        public string prm_DEFAULT_DocumenPerFiscal { get; set; }
        public string prm_DEFAULT_TablaRubrosComerciales { get; set; }
        public string prm_DEFAULT_PersonaClientes { get; set; }

        public string prm_TipoPersona;

        private BEPersona itemPersonas;
        private BEPersonaDato itemPersonasDatosAdicionales = new BEPersonaDato();

        private PersonasLogic oPersonasLogic = new PersonasLogic();
        private string J_TEXTO_BUSCAR = string.Empty;

        public frmPersonaNueva()
        {
            InitializeComponent();
        }

        private void frmPersonaNueva_Load(object sender, EventArgs e)
        {
            try
            {
                CargarPagina();
                PresentarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, HelpWindows.MessageBoxCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void PresentarFormulario()
        {
            itemPersonas = new BEPersona();
            if (prm_TipoPersona == prm_DEFAULT_PersonaNatural)
            {

                textBoxEMPRESA.Visible = true;
                groupBox2.Visible = true;

                comboBoxEmpresas.Visible = true;
                apellidoPaternoLabel.Visible = true;
                apellidoPaternoTextBox.Visible = true;
                apellidoMaternoLabel.Visible = true;
                apellidoMaternoTextBox.Visible = true;
                nombre1Label.Visible = true;
                nombre1TextBox.Visible = true;
                nombre2Label.Visible = true;
                nombre2TextBox.Visible = true;
            }
            else if (prm_TipoPersona == prm_DEFAULT_PersonaJuridica)
            {
                Text = "Empresa Nueva";
                lblTitulo.Text = "Registro: Empresa Nueva";
                razonSocialLabel.Visible = true;
                razonSocialTextBox.Visible = true;
                nombreComercialLabel.Visible = true;
                nombreComercialTextBox.Visible = true;
                codArguRubroComercialComboBox.Visible = true;
                codArguRubroComercialLabel.Visible = true;
            }
            BEPersonaAtributo itemPersonasAtributos = new BEPersonaAtributo();
            itemPersonasAtributos.CodigoArguTipoAtributo = null;
            itemPersonasAtributos.SegUsuarioCrea = prm_desLogin;
            itemPersonasAtributos.SegUsuarioEdita = prm_desLogin;
            itemPersonas.listaPersonasAtributos.Add(itemPersonasAtributos);
            itemPersonasDatosAdicionales.SegUsuarioCrea = prm_desLogin;
            itemPersonasDatosAdicionales.SegUsuarioEdita = prm_desLogin;
            itemPersonas.CodigoArguRubroComercial = null;
            itemPersonas.Estado = true;
            itemPersonas.CodigoArguTipoEntidad = prm_TipoPersona;
            itemPersonas.SegUsuarioCrea = prm_desLogin;
            itemPersonas.SegUsuarioEdita = prm_desLogin;
        }

        private void CargarPagina()
        {
            HelpMaestras.CargarListadoGenerico(codi_arguTipoAtributoComboBox, prm_DEFAULT_DocumenPerFiscal.Substring(0, 5), 
                                               prm_DEFAULT_DocumenPerFiscal.Substring(0, 8), 2, 
                                               MaestroLogic.EstadoDetalle.Habilitado, MaestroLogic.TipoLongitudDetalle.Corta, 
                                               string.Empty, Helper.ComboBoxText.Select, prm_codEmpresa, prm_desLogin);

            HelpMaestras.CargarListadoGenerico(codArguRubroComercialComboBox, prm_DEFAULT_TablaRubrosComerciales, 
                                               string.Empty, 1, MaestroLogic.EstadoDetalle.Habilitado, 
                                               MaestroLogic.TipoLongitudDetalle.Corta, string.Empty, Helper.ComboBoxText.Select,
                                               prm_codEmpresa, prm_desLogin);

            btnValidar.Image = ResourceIconos.OKChecked;
            buttonAceptar.Image = ResourceIconos.Ok;
            buttonSalir.Image = ResourceIconos.Exit;
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            if (validarDatos())
                buttonAceptar.Enabled = true;
        }

        private bool validarDatos()
        {
            bool bStatus = true;

            if (prm_TipoPersona == prm_DEFAULT_PersonaNatural)
            {

                if (apellidoPaternoTextBox.Text == string.Empty)
                {
                    errorProvider1.SetError(apellidoPaternoTextBox, "¡ Ingresar apellido paterno !");
                    bStatus = false;
                }
                else
                    errorProvider1.SetError(apellidoPaternoTextBox, string.Empty);
                if (apellidoMaternoTextBox.Text == string.Empty)
                {
                    errorProvider1.SetError(apellidoMaternoTextBox, "¡ Ingresar apellido materno !");
                    bStatus = false;
                }
                else
                    errorProvider1.SetError(apellidoMaternoTextBox, string.Empty);
                if (nombre1TextBox.Text == string.Empty)
                {
                    errorProvider1.SetError(nombre1TextBox, "¡ Ingresar primer nombre como mínimo !");
                    bStatus = false;
                }
            }
            else
            {
                if (razonSocialTextBox.Text == string.Empty)
                {
                    errorProvider1.SetError(razonSocialTextBox, "¡ Ingresar RAZON SOCIAL de la Empresa !");
                    bStatus = false;
                }
                else if (nombreComercialTextBox.Text == string.Empty)
                {
                    errorProvider1.SetError(nombreComercialTextBox, "¡ Ingresar NOMBRE COMERCIAL de la Empresa !");
                    bStatus = false;
                }
                else if (codArguRubroComercialComboBox.SelectedValue.ToString() == string.Empty)
                {
                    errorProvider1.SetError(codArguRubroComercialComboBox, "¡ Seleccionar RUBRO COMERCIAL de la Empresa !");
                    bStatus = false;
                }
            }
            return bStatus;
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ReturnValor oReturnValor = new ReturnValor();
                itemPersonasDatosAdicionales.ApellidoMaterno = apellidoMaternoTextBox.Text;
                itemPersonasDatosAdicionales.ApellidoPaterno = apellidoPaternoTextBox.Text;
                itemPersonasDatosAdicionales.Nombre1 = nombre1TextBox.Text;
                itemPersonasDatosAdicionales.Nombre2 = nombre2TextBox.Text;
                itemPersonasDatosAdicionales.CodigoArguAreaEmpleado = null;
                itemPersonasDatosAdicionales.SegUsuarioCrea = prm_desLogin;
                itemPersonasDatosAdicionales.SegUsuarioEdita = prm_desLogin;

                itemPersonas.RazonSocial = itemPersonasDatosAdicionales.ApellidoPaterno.Trim() + " " +
                                                (itemPersonasDatosAdicionales.ApellidoMaterno != null ? 
                                                    itemPersonasDatosAdicionales.ApellidoMaterno.Trim() : string.Empty) + ", " +
                                                (itemPersonasDatosAdicionales.Nombre1 != null ? 
                                                    itemPersonasDatosAdicionales.Nombre1.Trim() : string.Empty) + " " +
                                                (itemPersonasDatosAdicionales.Nombre2 != null ? 
                                                    itemPersonasDatosAdicionales.Nombre2.Trim() : string.Empty);
                itemPersonas.Observaciones = observacionesTextBox.Text;
                itemPersonas.CodigoArguRubroComercial = codArguRubroComercialComboBox.SelectedValue.ToString();
                if (prm_TipoPersona == prm_DEFAULT_PersonaNatural)
                {
                    itemPersonasDatosAdicionales.Nombre2 = itemPersonasDatosAdicionales.Nombre2 != null ? itemPersonasDatosAdicionales.Nombre2 : string.Empty;
                    itemPersonasDatosAdicionales.ApellidoMaterno = itemPersonasDatosAdicionales.ApellidoMaterno != null ? 
                                                                    itemPersonasDatosAdicionales.ApellidoMaterno : string.Empty;
                    itemPersonas.CodigoPersonaEmpresa = comboBoxEmpresas.SelectedValue == null ? null : comboBoxEmpresas.SelectedValue.ToString();
                    itemPersonas.itemDatoAdicional = itemPersonasDatosAdicionales;
                }
                else if (prm_TipoPersona == prm_DEFAULT_PersonaJuridica)
                {
                    itemPersonasDatosAdicionales.ApellidoMaterno = string.Empty;
                    itemPersonasDatosAdicionales.ApellidoPaterno = string.Empty;
                    itemPersonasDatosAdicionales.Nombre1 = string.Empty;
                    itemPersonasDatosAdicionales.Nombre2 = string.Empty;
                }

                itemPersonas.listaPersonasAtributos[0].CodigoArguTipoAtributo = codi_arguTipoAtributoComboBox.SelectedValue.ToString();
                itemPersonas.listaPersonasAtributos[0].DescripcionAtributo = descripcionAtributoTextBox.Text;
                itemPersonas.listaPersonasAtributos.Add(new BEPersonaAtributo
                {
                    CodigoArguTipoAtributo = prm_DEFAULT_Domicilio_Fiscal,
                    DescripcionAtributo = textBoxDomicilio.Text,
                    Estado = true,
                    SegUsuarioCrea = prm_desLogin,
                    SegUsuarioEdita = prm_desLogin,
                });

                itemPersonas.listaPersonasAsignaciones.Add(new BEPersonasAsignacion
                {
                    CodigoArguAsignacion = prm_DEFAULT_PersonaClientes,
                    Estado = true,
                    SegUsuarioEdita = prm_desLogin,
                    SegUsuarioCrea = prm_desLogin,
                });
                oReturnValor = oPersonasLogic.Insert(itemPersonas);
                if (oReturnValor.Exitosa)
                {
                    ESTADO_CONTROLES(false);
                    MessageBox.Show(oReturnValor.Message, HelpWindows.MessageBoxCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(oReturnValor.Message, HelpWindows.MessageBoxCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, HelpWindows.MessageBoxCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ESTADO_CONTROLES(bool ESTADO)
        {
            codi_personaTextBox.ReadOnly = !ESTADO;
            textBoxEMPRESA.ReadOnly = !ESTADO;
            codArguRubroComercialComboBox.Enabled = ESTADO;
            apellidoMaternoTextBox.ReadOnly = !ESTADO;
            apellidoPaternoTextBox.ReadOnly = !ESTADO;
            nombre1TextBox.ReadOnly = !ESTADO;
            nombre2TextBox.ReadOnly = !ESTADO;
            razonSocialTextBox.ReadOnly = !ESTADO;
            nombreComercialTextBox.ReadOnly = !ESTADO;
            codi_arguTipoAtributoComboBox.Enabled = ESTADO;
            descripcionAtributoTextBox.ReadOnly = !ESTADO;
            observacionesTextBox.ReadOnly = !ESTADO;
            buttonAceptar.Enabled = ESTADO;
            btnValidar.Enabled = ESTADO;

        }

        private void textBoxEMPRESA_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    BuscarPersonasEmpresa();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, HelpWindows.MessageBoxCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BuscarPersonasEmpresa()
        {

            if (textBoxEMPRESA.Text.Trim().Length > 2)
            {
                J_TEXTO_BUSCAR = textBoxEMPRESA.Text.Trim();

                List<DTOPersonaResponse> listaPersonas = new List<DTOPersonaResponse>();
                listaPersonas = oPersonasLogic.List(new BaseFiltroPersona
                {
                    codEmpresa= prm_codEmpresa,
                    codRegTipoEntidad = prm_DEFAULT_PersonaJuridica,
                    desNombre = J_TEXTO_BUSCAR,
                    indActivo = true
                }, Helper.ComboBoxText.Select);
                comboBoxEmpresas.DataSource = listaPersonas;
                comboBoxEmpresas.ValueMember = "CodigoPersona";
                comboBoxEmpresas.DisplayMember = "RazonSocial";
            }
        }

        private void codi_personaTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (oPersonasLogic.Find(prm_codEmpresa,codi_personaTextBox.Text, prm_desLogin) != null)
                {
                    MessageBox.Show("¡ CODIGO DE PERSONA YA EXISTE !", HelpWindows.MessageBoxCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
                else
                    e.Cancel = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, HelpWindows.MessageBoxCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void textBoxEMPRESA_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                BuscarPersonasEmpresa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, HelpWindows.MessageBoxCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
