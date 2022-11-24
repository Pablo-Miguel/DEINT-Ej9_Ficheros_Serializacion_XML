using DEINT_Ej9_Ficheros_Serializacion_XML.Modelo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DEINT_Ej9_Ficheros_Serializacion_XML
{
    public partial class Form1 : Form
    {
        private FormSelect frm;
        public String dni { get; set; } = String.Empty;
        public Banco banco { get; set; }
        public Form1()
        {
            InitializeComponent();
            banco = new Banco();
            this.ActiveControl = label1;
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

                dgCliente.DataSource = null;
                dgCliente.DataSource = banco.clientes;

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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (btnModificar.Text.Equals("Modificar cliente"))
            {
                frm = new FormSelect(this);
                frm.ShowDialog();

                if (!dni.Equals(String.Empty))
                {

                    Cliente cliente = banco.clientes.Find(cli => cli.Equals(new Cliente(dni)));

                    if (cliente != null)
                    {
                        txtDNI.Text = cliente.dni;
                        txtNombre.Text = cliente.nombre;
                        txtDireccion.Text = cliente.direccion;
                        txtEdad.Text = cliente.edad.ToString();
                        txtTelefono.Text = cliente.telefono.ToString();
                        txtNumCuentaCorriente.Text = cliente.num_cuenta_corriente;
                    }

                }
                btnModificar.Text = "Guardar cambios";
                btnAnadir.Enabled = false;
                btnEliminar.Enabled = false;
            }
            else {
                if (this.ValidateChildren())
                {
                    Cliente cliente = banco.clientes.Find(cli => cli.Equals(new Cliente(dni)));

                    if (cliente != null)
                    {
                        int index = banco.clientes.IndexOf(cliente);

                        if (index != -1)
                        {
                            banco.clientes[index] = new Cliente(txtDNI.Text, txtNombre.Text, txtDireccion.Text,
                                Int32.Parse(txtEdad.Text), Int32.Parse(txtTelefono.Text),
                                txtNumCuentaCorriente.Text);

                            dgCliente.DataSource = null;
                            dgCliente.DataSource = banco.clientes;
                        }

                    }
                    btnModificar.Text = "Modificar cliente";
                    btnAnadir.Enabled = true;
                    btnEliminar.Enabled = true;
                    txtDNI.Clear();
                    txtNombre.Clear();
                    txtDireccion.Clear();
                    txtEdad.Clear();
                    txtTelefono.Clear();
                    txtNumCuentaCorriente.Clear();
                }
                else {
                    MessageBox.Show("Algún campo es incorrecto");
                }
            }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (btnEliminar.Text.Equals("Eliminar cliente"))
            {
                frm = new FormSelect(this);
                frm.ShowDialog();

                if (!dni.Equals(String.Empty))
                {
                    Cliente cliente = banco.clientes.Find(cli => cli.Equals(new Cliente(dni)));

                    if (cliente != null)
                    {
                        txtDNI.Text = cliente.dni;
                        txtNombre.Text = cliente.nombre;
                        txtDireccion.Text = cliente.direccion;
                        txtEdad.Text = cliente.edad.ToString();
                        txtTelefono.Text = cliente.telefono.ToString();
                        txtNumCuentaCorriente.Text = cliente.num_cuenta_corriente;

                        txtDNI.Enabled = false;
                        txtNombre.Enabled = false;
                        txtDireccion.Enabled = false;
                        txtEdad.Enabled = false;
                        txtTelefono.Enabled = false;
                        txtNumCuentaCorriente.Enabled = false;
                    }

                }

                btnEliminar.Text = "Confirmar borrado";
                btnCancelar.Visible = true;
                btnAnadir.Enabled = false;
                btnModificar.Enabled = false;
            }
            else {
                Cliente cliente = banco.clientes.Find(cli => cli.Equals(new Cliente(dni)));

                if (cliente != null)
                {

                    banco.clientes.Remove(cliente);

                    dgCliente.DataSource = null;
                    dgCliente.DataSource = banco.clientes;
                }

                btnEliminar.Text = "Eliminar cliente";
                txtDNI.Enabled = true;
                txtNombre.Enabled = true;
                txtDireccion.Enabled = true;
                txtEdad.Enabled = true;
                txtTelefono.Enabled = true;
                txtNumCuentaCorriente.Enabled = true;
                btnAnadir.Enabled = true;
                btnModificar.Enabled = true;
                btnCancelar.Visible = false;
                txtDNI.Clear();
                txtNombre.Clear();
                txtDireccion.Clear();
                txtEdad.Clear();
                txtTelefono.Clear();
                txtNumCuentaCorriente.Clear();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnEliminar.Text = "Eliminar cliente";
            txtDNI.Enabled = true;
            txtNombre.Enabled = true;
            txtDireccion.Enabled = true;
            txtEdad.Enabled = true;
            txtTelefono.Enabled = true;
            txtNumCuentaCorriente.Enabled = true;
            btnAnadir.Enabled = true;
            btnModificar.Enabled = true;
            btnCancelar.Visible = false;
            txtDNI.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            txtEdad.Clear();
            txtTelefono.Clear();
            txtNumCuentaCorriente.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(Banco));

            using (var stream = new FileStream("banco.xml", FileMode.Create))
            {
                serializer.Serialize(stream, banco);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Banco));

                using (var stream = new FileStream("banco.xml", FileMode.Open))
                {
                    Banco b = (Banco)serializer.Deserialize(stream);

                    banco = b;

                    dgCliente.DataSource = banco.clientes;
                }
            }
            catch { 
            
            }
        }
    }
}
