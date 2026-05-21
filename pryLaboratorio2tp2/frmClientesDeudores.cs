using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace pryLaboratorio2tp2
{
    public partial class frmClientesDeudores : Form
    {
        public frmClientesDeudores()
        {
            InitializeComponent();
        }

        private void btnListarDeudores_Click(object sender, EventArgs e)
        {
            clsClientes x = new clsClientes();
            x.ListarDeudores(dgvConsultaDatos);
            lblCantC.Text = x.CantidadDeudores.ToString();
            lblTot.Text = x.TotalDeuda.ToString();
           // lblProm.Text = (x.TotalDeuda / x.CantidadDeudores).ToString();
        }

        private void btnReportar_Click(object sender, EventArgs e)
        {
            clsClientes x = new clsClientes();
            x.ReporteCliente();
            MessageBox.Show("Reporte generado con exito");
        }
    }
}
