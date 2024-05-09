using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABM1w1
{
    class Producto
    {
        int codigo;
        string detalle;
        int tipo;
        int marca;
        double precio;
        DateTime fecha;

        public Producto()
        {
            this.codigo = 0;
            this.detalle = "";
            this.tipo = 0;
            this.marca = 0;
            this.precio = 0;
            this.fecha = DateTime.Today;
        }
        public Producto(int codigo, string detalle, int tipo, int marca, double precio, DateTime fecha)
        {
            this.codigo = codigo;
            this.detalle = detalle;
            this.marca = marca;
            this.tipo = tipo;
            this.precio = precio;
            this.fecha = fecha;

        }



        public int pCodigo {
            get { return codigo; }
            set { codigo = value; }
        }

        public string pDetalle {
            get { return detalle; }
            set { detalle = value; }
        }
        public int pTipo {
            get { return tipo; }
            set { tipo = value; }
        }
        public int pMarca {
            get { return marca; }
            set { marca = value; }
        }
        public double pPrecio {
            get { return precio; }
            set { precio = value; }
        }
        public DateTime pFecha {
            get { return fecha; }
            set { fecha = value; }
        }

        public string toString()
        {
            return "" + codigo + "| " + detalle; 
        }

        //clase: "marca" no se hace porque no es trancendente se lo toma como foranea y lo hacemos em un combo box











    }
}
