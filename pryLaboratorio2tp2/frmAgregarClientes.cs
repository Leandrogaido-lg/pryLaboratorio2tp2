using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryLaboratorio2tp2
{
    public partial class frmAgregarClientes : Form
    {
        public frmAgregarClientes()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            clsClientes x = new clsClientes();  
            x.Nombre = txtNombre.Text;
            x.Limite = Convert.ToDecimal(txtLimite.Text);
            x.IDAutomovil = Convert.ToInt32(cmbAuto.SelectedValue);
            x.Agregar();

            MessageBox.Show("Datos Cargados");
            txtNombre.Text = "";
            txtLimite.Text = "";
            cmbAuto.SelectedIndex = 0;
        }

        private void frmAgregarClientes_Load(object sender, EventArgs e)
        {
            clsAutomovil auto = new clsAutomovil();
            auto.ListarAutomoviles(cmbAuto);
        }
    }
}
