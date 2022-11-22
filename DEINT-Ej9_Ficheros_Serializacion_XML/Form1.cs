using DEINT_Ej9_Ficheros_Serializacion_XML.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEINT_Ej9_Ficheros_Serializacion_XML
{
    public partial class Form1 : Form
    {
        private Banco banco;
        public Form1()
        {
            InitializeComponent();
            banco = new Banco();
        }

        private void txtDNI_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(txtDNI.Text, @"^\d{8}[A-Z]$") || String.IsNullOrEmpty(txtDNI.Text))
            {
                this.errorProvider.SetError(this.txtDNI, "El formato del NIF es incorrecto.");
                e.Cancel = true;
            }
            else
            {
                this.errorProvider.SetError(this.txtDNI, String.Empty);
                e.Cancel = false;
            }
        }

        private void txtNombre_Validating(object sender, CancelEventArgs e)
        {
            if (txtNombre.Text.Equals(String.Empty))
            {
                this.errorProvider.SetError(this.txtNombre, "El nombre no puede estar vacío.");
                e.Cancel = true;
            }
            else
            {
                this.errorProvider.SetError(this.txtNombre, String.Empty);
                e.Cancel = false;
            }
        }

        private void txtDireccion_Validating(object sender, CancelEventArgs e)
        {
            if (txtDireccion.Text.Equals(String.Empty))
            {
                this.errorProvider.SetError(this.txtDireccion, "La dirección no puede estar vacía.");
                e.Cancel = true;
            }
            else
            {
                this.errorProvider.SetError(this.txtDireccion, String.Empty);
                e.Cancel = false;
            }
        }

        private void txtEdad_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(txtEdad.Text, @"^[0-9]+$") || String.IsNullOrEmpty(txtEdad.Text))
            {
                this.errorProvider.SetError(this.txtEdad, "Solo se admiten letras, solo números.");
                e.Cancel = true;
            }
            else
            {
                this.errorProvider.SetError(this.txtEdad, String.Empty);
                e.Cancel = false;
            }
        }

        private void txtTelefono_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(txtTelefono.Text, @"^\+?(00)?(34)?-?\d{3}-?\d{2}-?\d{2}-?\d{2}$") || String.IsNullOrEmpty(txtTelefono.Text))
            {
                this.errorProvider.SetError(this.txtTelefono, "Formato del telefono incorrecto.");
                e.Cancel = true;
            }
            else
            {
                this.errorProvider.SetError(this.txtTelefono, String.Empty);
                e.Cancel = false;
            }
        }

        private void txtNumCuentaCorriente_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(txtNumCuentaCorriente.Text, @"^(ES[0-9]{2})?[0-9]{20}$") || String.IsNullOrEmpty(txtNumCuentaCorriente.Text))
            {
                this.errorProvider.SetError(this.txtNumCuentaCorriente, "Formato del numero de cuenta es incorrecto.");
                e.Cancel = true;
            }
            else
            {
                this.errorProvider.SetError(this.txtNumCuentaCorriente, String.Empty);
                e.Cancel = false;
            }
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                banco.clientes.Add(new Cliente(txtDNI.Text, txtNombre.Text, txtDireccion.Text,
                    Int32.Parse(txtEdad.Text), Int32.Parse(txtTelefono.Text), 
                    txtNumCuentaCorriente.Text));

                txtDNI.Clear();
                txtNombre.Clear();
                txtDireccion.Clear();
                txtEdad.Clear();
                txtTelefono.Clear();
                txtNumCuentaCorriente.Clear();
            }
            else
            {
                MessageBox.Show("Algún campo es incorrecto");
            }
        }
    }
}
