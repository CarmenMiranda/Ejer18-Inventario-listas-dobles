using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer18__InventarioListasDobles
{
    class Inventario
    {
        private int _numeroProductos;
        public int numeroProductos { get { return _numeroProductos; } }
        public Producto _inicio;
        public Producto _ultimo;

        public Inventario()
        {
            _numeroProductos = 0;
            _inicio = null;
            _ultimo = null;
        }

        public void agregarProducto(Producto nuevo)
        {
            if (_inicio == null)
                _inicio = nuevo;
            else
                agregar(_inicio, nuevo);
            _ultimo = nuevo;
            _numeroProductos++;
        }

        private void agregar(Producto ultimo, Producto nuevo)
        {
            if (ultimo.productoSiguiente == null) {
                ultimo.productoSiguiente = nuevo;
                nuevo.productoAnterior = ultimo;
            }
            else
                agregar(ultimo.productoSiguiente, nuevo);
        }

        public void agregarProductoInicio(Producto nuevo)
        {
            if (_inicio == null)
                _inicio = nuevo;
            else{
                nuevo.productoSiguiente = _inicio;
                nuevo.productoSiguiente.productoAnterior = nuevo;
                _inicio = nuevo;
            }
            _numeroProductos++;
        }

        public Producto buscarProducto(int codigo)
        {
            Producto actual = _inicio;
            bool productoEncontrado = false;
            while (actual != null && productoEncontrado == false){
                if (actual.codigo == codigo)
                    productoEncontrado = true;
                else
                    actual = actual.productoSiguiente;
            }

            return actual;
        }

        public bool eliminarProducto(int codigo)
        {
            bool productoEncontrado = false;
            if (numeroProductos != 0){
                Producto actual = _inicio;
                while (actual.productoSiguiente != null && productoEncontrado == false){
                    if (actual.codigo == codigo) {
                        eliminarPrimero();
                        productoEncontrado = true;
                    }
                    else{
                        if (actual.productoSiguiente.codigo == codigo){
                            if (actual.productoSiguiente != _ultimo){
                                actual.productoSiguiente.productoSiguiente.productoAnterior = actual.productoSiguiente;
                                actual.productoSiguiente = actual.productoSiguiente.productoSiguiente;
                                _numeroProductos--;
                            }
                            else
                                eliminarUltimo();
                            productoEncontrado = true;
                        }
                        else
                            actual = actual.productoSiguiente;
                    }
                }
            }
            return productoEncontrado;
        }

        public bool eliminarPrimero() {
            bool productoEncontrado = false;
            if (numeroProductos != 0 && _inicio != null) {
                if (numeroProductos != 1){
                    _inicio = _inicio.productoSiguiente;
                    _inicio.productoAnterior = null;
                }
                else
                    _inicio = null;
                _numeroProductos--;
                productoEncontrado = true;
            }
            return productoEncontrado;
        }

        public bool eliminarUltimo() {
            bool productoEncontrado = false;
            if (numeroProductos != 0 && _ultimo != null) {
                if (numeroProductos != 1)
                {
                    _ultimo = _ultimo.productoAnterior;
                    _ultimo.productoSiguiente = null;
                }
                else {
                    _ultimo = null;
                    _inicio = null;
                }
                _numeroProductos--;
                productoEncontrado = true;
            }
            return productoEncontrado;
        }

        public string reporte()
        {
            string texto = "";
            if (numeroProductos != 0)
                return texto = crearReporte(_inicio);
            else
                return texto;
        }

        public string crearReporte(Producto actual)
        {
            string texto = "";
            if (actual.productoSiguiente == null)
                return texto + actual.ToString();
            else
                return texto = actual.ToString() + Environment.NewLine + crearReporte(actual.productoSiguiente);
        }

        public string reporteInverso()
        {
            string texto = "";
            if (numeroProductos != 0)
                return texto = crearReporteInverso(/*_inicio*/_ultimo); //Puede ser utilizado con _inicio o con _ultimo
            else
                return texto;
        }

        private string crearReporteInverso(Producto actual)
        {
            string texto = "";
            /* Código para utilizar con _inicio
            if (actual.productoSiguiente == null)
                return texto + actual.ToString();
            else
                return texto = crearReporteInverso(actual.productoSiguiente) + Environment.NewLine + actual.ToString();
            */
            //Código para utlizar con _ultimo
            if (actual.productoAnterior == null)
                return texto + actual.ToString();
            else
                return texto = actual.ToString()+Environment.NewLine+ crearReporteInverso(actual.productoAnterior);
        }

        public bool insertarProducto(Producto nuevo, int posicion)
        {
            Producto actual = _inicio;
            bool posicionDisponible = false;

            if (posicion >= 0 && posicion <=numeroProductos ){
                    if (posicion == 0)
                        agregarProductoInicio(nuevo);
                    else{
                        for (int contador1 = 0; (posicion - 1) > contador1 && actual != null; contador1++)
                            actual = actual.productoSiguiente;

                        nuevo.productoSiguiente = actual.productoSiguiente;
                        nuevo.productoAnterior = actual;
                        actual.productoSiguiente = nuevo;
                        _numeroProductos++;
                    }

                    if ((posicion + 1) == _numeroProductos)
                        _ultimo = nuevo;
                        
                    posicionDisponible = true;
            }
            return posicionDisponible;
        }
    }
}
