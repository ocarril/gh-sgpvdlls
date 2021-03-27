using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using CROM.Tools.Comun.settings;

namespace CROM.Seguridad.Login
{
    public partial class IniciarSesion : Form
    {


        
        private string msSistema = string.Empty;
        private ucIniciarSesion moucIniciarSesion;
        private ucPassword moucPassword;
        private ucAddress moucAddress;

        #region "/--- Eventos de la Pagina  ---/"
        /**************************************************************************/
        /**************************************************************************/
        public IniciarSesion()
        {
            if (GlobalSettings.GetDEFAULT_SistemaInicio() != null)
                msSistema = GlobalSettings.GetDEFAULT_SistemaInicio();
            else
                MessageBox.Show("error SistemaInicio");

            InitializeComponent();
        }

        public IniciarSesion(string pSistemaInicio)
        {
            msSistema = pSistemaInicio;
            InitializeComponent();

        }

        #endregion

        private void IniciarSesion_Load(object sender, EventArgs e)
        {
            string Path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Resources\\SSI_Accesos.JPG");
            if (System.IO.File.Exists(Path))
                ptbCabecera.ImageLocation = Path;
           
            moucIniciarSesion = new ucIniciarSesion(msSistema);

            moucPassword = new ucPassword(msSistema);
            moucAddress = new ucAddress();
            pnCuerpo.Controls.Add(moucIniciarSesion);
            if (!moucIniciarSesion.ServicioConectado)
            {
                pnCuerpo.Controls.Clear();
                pnCuerpo.Controls.Add(moucAddress);
                ckbOpciones.Visible = false;
            }
        }

        private void ckbOpciones_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbOpciones.Checked)
            {
                ckbOpciones.Image = Properties.Resources.SSI_forward;
                moucPassword.propUsuario = moucIniciarSesion.propUsuario;
                pnCuerpo.Controls.Clear();
                pnCuerpo.Controls.Add(moucPassword); 
            }
            else 
            { 
                ckbOpciones.Image = Properties.Resources.SSI_back;
                pnCuerpo.Controls.Clear();
                pnCuerpo.Controls.Add(moucIniciarSesion); 
            }
        }
    }
}
