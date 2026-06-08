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
    public partial class frmEditarCliente : Form
    {
        public frmEditarCliente()
        {
            InitializeComponent();
        }

        private void frmEditarCliente_Load(object sender, EventArgs e)
        {
            btnBuscar.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            clsClientes x = new clsClientes();
            Int32 IDCliente = Convert.ToInt32(txtCodigo.Text);
            x.Buscar(IDCliente);

            if (x.IDCliente != 0)
            {
                lblNombre1.Text = x.Nombre;
                lblDeuda1.Text = x.Deuda.ToString();
                txtLimite.Text = x.Limite.ToString();
            }
            else
            {
                lblNombre1.Text = "";
                lblDeuda1.Text = "";
                txtLimite.Text = "";
                MessageBox.Show("Dato no encontrado!!");
            }
            txtLimite.ReadOnly = true;//solo de lectura para que no se pueda editar
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
            btnGuardar.Enabled = false;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                btnBuscar.Enabled = true;
            }
            else
            {
                btnBuscar.Enabled = false;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
            txtLimite.ReadOnly = false;
        }

        private void limpiar()
        {
            txtLimite.Text = "";
            lblNombre1.Text = "";
            lblDeuda1.Text = "";
            txtLimite.ReadOnly = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clsClientes x = new clsClientes();
            Int32 id = Convert.ToInt32(txtCodigo.Text);
            x.Limite = Convert.ToDecimal(txtLimite.Text);
            x.Modificar(id);
            MessageBox.Show("El dato fue actualizado correctamente");
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            clsClientes x = new clsClientes();
            Int32 id = Convert.ToInt32(txtCodigo.Text);

            x.Eliminar(id);
            MessageBox.Show("Cliente Eliminado");
            limpiar();
        }
    }
}
