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
    public partial class frmBusquedaCliente : Form
    {
        public frmBusquedaCliente()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Int32 IDCliente = Convert.ToInt32(txtCodigo.Text);
            clsClientes x = new clsClientes();
            x.Buscar(IDCliente);

            if (x.IDCliente != 0)
            {
                lblNombre1.Text = x.Nombre;
                lblDeuda1.Text = x.Deuda.ToString();
                lblLimite1.Text = x.Limite.ToString();
                txtCodigo.Text = "";

            }
            else
            {

                lblNombre1.Text = "";
                lblDeuda1.Text = "";
                lblLimite1.Text = "";
                MessageBox.Show("Cliente no existente");
            }
        }
    }
}
