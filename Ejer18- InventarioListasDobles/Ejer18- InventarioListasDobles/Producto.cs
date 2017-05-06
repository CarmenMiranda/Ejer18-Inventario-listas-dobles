using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer18__InventarioListasDobles
{
    class Producto
    {
        private int _codigo;
        public int codigo { get { return _codigo; } }

        private string _nombre;
        public string nombre { get { return _nombre; } }

        private float _precio;
        public float precio { get { return _precio; } }

        private int _cantidad;
        public int cantidad { get { return _cantidad; } }

        private Producto _productoSiguiente;
        public Producto productoSiguiente
        {
            get { return _productoSiguiente; }
            set { _productoSiguiente = value; }
        }

        private Producto _productoAnterior;
        public Producto productoAnterior
        {
            get { return _productoAnterior; }
            set { _productoAnterior = value; }
        }

        public Producto(int codigo, string nombre, float precio, int cantidad)
        {
            _codigo = codigo;
            _nombre = nombre;
            _precio = precio;
            _cantidad = cantidad;
            _productoSiguiente = null;
            _productoAnterior = null;
        }

        public override string ToString()
        {
            string texto = "Producto" + Environment.NewLine;
            texto += "Código: " + codigo + Environment.NewLine + "Nombre: " + nombre + Environment.NewLine;
            texto += "Precio: $" + precio + Environment.NewLine + "Cantidad: " + cantidad + Environment.NewLine;
            return texto;
        }
    }
}
