namespace CROM.Seguridad.Login
{
    using System;
    using System.Windows.Forms;

    public partial class ucAddress : UserControl
    {
        public ucAddress()
        {
            InitializeComponent();
        }

        private void ucAddress_Load(object sender, EventArgs e)
        {
            txtHost.Text = ConfigServiceModel();
        }

        private void btnReconectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿ Esta Seguro de cambiar el Host de Seguridad?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ConfigServiceModel(txtHost.Text);
                    if (MessageBox.Show("Se Grabo la Configuración, Salir Ahora para Efectuar los CAMBIOS [Si] [No]??", "Por Favor Salir del Sistema para Actualizar los Cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        Application.Exit();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Address", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private static string ConfigServiceModel()
        {
            string serverName = "";
            //Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //ServiceModelSectionGroup serviceModel = ServiceModelSectionGroup.GetSectionGroup(appConfig);
            //BindingsSection bindings = serviceModel.Bindings;
            //ChannelEndpointElementCollection endpoints = serviceModel.Client.Endpoints;
            //for (int i = 0; i < endpoints.Count; i++)
            //{
            //    ChannelEndpointElement endpointElement = endpoints[i];
            //    if (endpointElement.Contract.ToUpper() == "wcfAccess.IAccess".ToUpper())
            //    {
            //        serverName = endpointElement.Address.Authority;
            //    }
            //}
            return serverName;
        }
        private static void ConfigServiceModel(string Host)
        {

            //StringBuilder serverName = new StringBuilder();
            //Configuration appConfig = ConfigurationManager.OpenExeConfiguration(System.Windows.Forms.Application.ExecutablePath);

            ////Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //ServiceModelSectionGroup serviceModel = ServiceModelSectionGroup.GetSectionGroup(appConfig);
            //BindingsSection bindings = serviceModel.Bindings;
            //ChannelEndpointElementCollection endpoints = serviceModel.Client.Endpoints;
            //for (int i = 0; i < endpoints.Count; i++)
            //{
            //    ChannelEndpointElement endpointElement = endpoints[i];
            //    if (endpointElement.Contract.ToUpper() == "WCFAccess.IAccess".ToUpper())
            //    {
            //        serverName.Append(endpointElement.Address.ToString());
            //        serverName.Replace(endpointElement.Address.Authority.ToString(), Host);
            //        Uri url = new Uri(serverName.ToString());

            //        endpointElement.Address = url;

            //    }
            //}
            //appConfig.Save();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

       

    }
}
