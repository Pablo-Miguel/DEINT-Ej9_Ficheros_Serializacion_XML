using DEINT_Ej9_Ficheros_Serializacion_XML.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEINT_Ej9_Ficheros_Serializacion_XML
{
    public partial class FormSelect : Form
    {
        private Form1 frm;
        public FormSelect(Form1 frm)
        {
            InitializeComponent();

            this.frm = frm;

            cbClientes.Items.Clear();
            foreach (Cliente cli in frm.banco.clientes)
            {
                cbClientes.Items.Add(cli.dni);
            }
            cbClientes.SelectedIndex = 0;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!cbClientes.Text.Equals(String.Empty))
            {
                frm.dni = cbClientes.Text;
                this.Close();
            }
            else {
                MessageBox.Show("Seleccione un DNI");
            }
            
        }
    }
}
