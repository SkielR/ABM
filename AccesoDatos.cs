using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;//crear
using System.Data.OleDb;//crear para cobectar base de datos


namespace ABM1w1
{
    class AccesoDatos
    {
        //atributos
        OleDbConnection conexion;
        OleDbCommand comando;
        OleDbDataReader lector;
        DataTable tabla;
        string cadenaConexion = "";

        public string pCadenaConexion //property que me conecta a una cadena
        {
            get { return cadenaConexion; }
            set { cadenaConexion = value; }
        }

        public OleDbDataReader pLector 
        {
            get { return lector; }
            set { lector = value; }
        }

        
        public AccesoDatos()
        {
            //los instancio
            conexion = new OleDbConnection();
            comando = new OleDbCommand();
            tabla = new DataTable();
            lector = null;
            cadenaConexion = "";

        }
        public AccesoDatos(string cadenaConexion) //constructor con parametros pasamos cadenaConexion
        {
            conexion = new OleDbConnection();
            comando = new OleDbCommand();
            tabla = new DataTable();
            lector = null;
            this.cadenaConexion = cadenaConexion;
        }

        public void conectar()//metodo que no devuelve nada o sea el void
        {
            conexion.ConnectionString = cadenaConexion;
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;//aca te deja escribir un comando de texto

        }
        public void desconectar()
        {
            conexion.Close();//cierra la conexion 
            conexion.Dispose();//elimina la conexion de new oldbconnection
        }
        public DataTable consultarTabla(string nombreTabla)//aca busca conectar a la bd con el nombre de la tabla
        {
            this.tabla = new DataTable();  //4/11
            this.conectar(); //a este metodo lo podemos hacer privados
            comando.CommandText = "SELECT * FROM " + nombreTabla;//dejar espacio en blanco a la hora de concatenar 
            tabla.Load(comando.ExecuteReader());
            this.desconectar(); //a este metodo lo podemos hacer privados
            return tabla;//retorna la tabla que seleccionamos recien
        }
        
        public void leerTabla(string nombreTabla)//me sirve para conectar a la base de datos. 
        {
            this.conectar();
            comando.CommandText = "SELECT * FROM " + nombreTabla;
            lector = comando.ExecuteReader();// lo q ejecutamos lo mandamos a un datareader - lo usamos con pLector - aca luego nos tenemos q desconectar - "datareader es solo de lectura". 
        }

        public DataTable consultarSQL(string consultaSQL)//aca busca conectar a la bd SIN nombre de la tabla
        {
            this.conectar(); //a este metodo lo podemos hacer privados
            comando.CommandText = consultaSQL;//dejar espacio en blanco a la hora de concatenar 
            tabla.Load(comando.ExecuteReader());
            this.desconectar(); //a este metodo lo podemos hacer privados
            return tabla;//retorna la tabla que seleccionamos recien
        }

        public void actualizaBD(string consultaSQL)
        {
            this.conectar();
            comando.CommandText = consultaSQL;
            comando.ExecuteNonQuery();
            this.desconectar();

        }
    }
}
