using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using CROM.Tools.Config;
using CROM.Tools.Comun.Web;

namespace CROM.Tools.Windows
{
    public partial class frm_Acceso : Form
    {
        public string prm_Usuario;
        public Image prm_Aceptar;
        public Image prm_Cancelar;
        public bool SUCEDE_OK = false;
        public bool ACTIVAR_CLIENTE_OK = false;
        public bool HABILITA_TEXBOX1 = false;
        public string PASSWORD;
        public string ENTIDAD;

        public frm_Acceso()
        {
            InitializeComponent();
        }

        private void frm_Acceso_Load(object sender, EventArgs e)
        {
            buttonAceptar.Image = prm_Aceptar;
            buttonCancelar.Image = prm_Cancelar;
            textBoxUsuario.ReadOnly = !HABILITA_TEXBOX1;
            textBoxUsuario.Text = prm_Usuario;
            if (!textBoxUsuario.ReadOnly)
                label1.Text = "Entidad: ";
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (!HABILITA_TEXBOX1)
            {
                if (textBoxClave.Text == WebConstants.DEFAULT_Clave)
                {
                    SUCEDE_OK = true;
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                if (textBoxClave.Text == WebConstants.DEFAULT_Clave)
                {
                    //if (ConfigCROM.AppConfig(ConfigTool.DEFAULT_Owner) == "OMGC$")
                    //{
                        SUCEDE_OK = true;
                        ACTIVAR_CLIENTE_OK = checkBox1.Checked;
                        PASSWORD = WebConstants.DEFAULT_Owner;
                        ENTIDAD = textBoxUsuario.Text;
                    //}
                }
            }
        }
    }
}
