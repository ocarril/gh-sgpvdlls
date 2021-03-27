using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CROM.Tools.Windows
{
    public class HelpDataGridView
    {
        public static void CellStyle(ref DataGridView dgvElegida)
        {
            DataGridViewCellStyle dgvEstiloDeFila = new DataGridViewCellStyle();
            dgvEstiloDeFila.SelectionBackColor = System.Drawing.Color.DarkOrange;
            dgvEstiloDeFila.SelectionForeColor = System.Drawing.Color.White;
            dgvEstiloDeFila.BackColor = System.Drawing.Color.Beige;
            dgvElegida.RowsDefaultCellStyle = dgvEstiloDeFila;
            dgvElegida.BackgroundColor = System.Drawing.Color.Beige;
            dgvElegida.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }
    }
}
