using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejer18__InventarioListasDobles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Inventario inventario = new Inventario();

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(txtCodigo.Text);
            float precio = Convert.ToSingle(txtPrecio.Text);
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            Producto producto = new Producto(codigo, txtNombre.Text, precio, cantidad);
            inventario.agregarProducto(producto);
        }

        private void btnAgregarInicio_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(txtCodigo.Text);
            float precio = Convert.ToSingle(txtPrecio.Text);
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            Producto producto = new Producto(codigo, txtNombre.Text, precio, cantidad);

            inventario.agregarProductoInicio(producto);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool productoEliminado = inventario.eliminarProducto(Convert.ToInt32(txtCodigo.Text));
            if (productoEliminado)
                txtInformacion.Text = "Producto eliminado";
            else
                txtInformacion.Text = "El producto no existe";
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(txtCodigo.Text);
            float precio = Convert.ToSingle(txtPrecio.Text);
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            Producto producto = new Producto(codigo, txtNombre.Text, precio, cantidad);

            bool productoInsertado = inventario.insertarProducto(producto, Convert.ToInt32(txtPosicion.Text));
            if (productoInsertado)
                txtInformacion.Text = "Se insertó correctamente el producto en la posición";
            else
                txtInformacion.Text = "Posición no disponible";
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            string texto = inventario.reporte();
            if (texto == "")
                txtInformacion.Text = "No hay productos.";
            else
                txtInformacion.Text = texto;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Producto producto = inventario.buscarProducto(Convert.ToInt32(txtCodigo.Text));
            if (producto != null)
                txtInformacion.Text = producto.ToString();
            else
                txtInformacion.Text = "El producto no existe";
        }

        private void btnReporteInverso_Click(object sender, EventArgs e)
        {
            string texto = inventario.reporteInverso();
            if (texto == "")
                txtInformacion.Text = "No hay productos.";
            else
                txtInformacion.Text = texto;
        }

        private void btnEliminarPrimerobtnEliminarPrimero_Click(object sender, EventArgs e)
        {
            bool productoEliminado = inventario.eliminarPrimero();
            if (productoEliminado)
                txtInformacion.Text = "Producto eliminado";
            else
                txtInformacion.Text = "El producto no existe";
        }

        private void btnEliminarUltimo_Click(object sender, EventArgs e)
        {
            bool productoEliminado = inventario.eliminarUltimo();
            if (productoEliminado)
                txtInformacion.Text = "Producto eliminado";
            else
                txtInformacion.Text = "El producto no existe";
        }
    }
}
