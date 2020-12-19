using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_de_Registro_de_Ventas
{
    public partial class Form1 : Form
    {
        double precio = 0;
        public Form1()
        {
            InitializeComponent();
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Today.Date.ToString("d");
            lblFecha.Text = (0).ToString("C");
        }

        private void cboProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string producto = cboProductos.Text;

            if (producto.Equals("Coleccion Escolar")) precio = 250;
            if (producto.Equals("Coleccion PreUniversitaria")) precio = 150;
            if (producto.Equals("Coleccion Profesional")) precio = 350;

            lblPrecio.Text = precio.ToString("C");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Validando
            if (cboProductos.SelectedIndex == -1)
                Message.Show("Debe seleccionar un producto...!!!");
            else if (txtCantidad.Text == "")
                Message.Show("Debe ingresar una cantidad...!!!");
            else if (cboTipo.SelectedIndex == -1)
                Message.Show("Debe seleccionar un tipo...!!!");
            else
            {
                //Capturando datos
                string producto = cboProductos.Text;
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                string tipo = cboTipo.Text;

                //Procesar calculos
                double subtotal = cantidad * precio;

                double descuento = 0, recargo = 0;
                if (tipo.Equals("Contado"))
                    descuento = 0.05 * subtotal;
                else
                    recargo = 0.1 * subtotal;
                double precioFinal = subtotal - descuento + recargo;

                //Impresion de resultados
                ListViewItem fila = new ListViewItem(producto);
                fila.SubItems.Add(cantidad.ToString());
                fila.SubItems.Add(precio.ToString());
                fila.SubItems.Add(tipo);
                fila.SubItems.Add(descuento.ToString());
                fila.SubItems.Add(recargo.ToString());
                fila.SubItems.Add(precioFinal.ToString());

                lvVenta.Items.Add(fila);
                btnCancelar_Click(sender, e);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
