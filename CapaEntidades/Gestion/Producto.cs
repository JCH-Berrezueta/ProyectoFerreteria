using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Gestion
{
    public class Producto
    {
        private int idProducto;
        private int idCategoriaProducto;
        private string nombre;
        private decimal precio;
        private int stock;
        private string estado;
        private string icono;
        private string descripcion;

        public Producto(int idProducto, int idCategoriaProducto, string nombre, decimal precio, int stock, string estado, string icono, string descripcion)
        {
            IdProducto = idProducto;
            IdCategoriaProducto = idCategoriaProducto;
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
            Estado = estado;
            Icono = icono;
            Descripcion = descripcion;
        }

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public int IdCategoriaProducto { get => idCategoriaProducto; set => idCategoriaProducto = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public int Stock { get => stock; set => stock = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Icono { get => icono; set => icono = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
