using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ABM1w1
{
    public partial class frmProducto : Form

    {//instanciamos objetos para la conexion con la base de datos 

        AccesoDatos oDato = new AccesoDatos(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\DBFProducto.mdb"); //esto fue lo tercero para acceder y lo dejamos asi
        const int tam = 10; //creamos un arreglo para los productos q tenemos en la base de datos, el arreglo es estatico
        Producto[] ap = new Producto[tam]; //creamos nuevo objeto
        int c; //para cargar arreglo de a uno
        bool nuevo; //el criterio es el 
        


        public frmProducto()
        {
            InitializeComponent();
            c = 0; //inicializamos el arreglo
            nuevo = false;
            for (int i = 0; i < tam; i++)
            {
                ap[i] = null;
            }
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            
            //hacer un metodo antes de esto
            this.Habilitar(false);
            //oDato.pCadenaConexion = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\el eze\ABM1w1\DBFProducto.mdb"; esto hicimos segundo para acceder base 
            //conexion.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\el eze\ABM1w1\DBFProducto.mdb"; esto hicimos primero para acceder a la base
            //conexion.Open(); //abro conexion con la base de dato
            //comando.Connection = conexion; //me conecto
            //comando.CommandType = CommandType.Text;
            //comando.CommandText = "SELECT * FROM Marca ORDER BY 2"; //traigo * de la tabla marca
            //tabla.Load(comando.ExecuteReader());

            //conexion.Close();//cierro conexion

            //cboMarca.DataSource = oDato.consultarTabla("Marca");//carga en el combobox lo que hay en la tabla Marca de la base de dato
            //cboMarca.DisplayMember = "n_tipo_marca";             //para que muestre un valor
            //cboMarca.ValueMember = "id_tipo_marca";              //para que se capture o guarde el valor

            cargarCombo(cboMarca, "Marca"); //Usamos el metodo cargarCombo
            cargarLista("Producto");//creamos un metodo para esto

            //crear clase para el manejo de base de datos
        }
        private void cargarLista(string nombreTabla)
        {
            c = 0; //pone la lista a cero 
            oDato.leerTabla(nombreTabla);//mi producto es nombreTabla, si andubo bien se cargo datareader, aca se hace como un select. el datareader es el producto
            while(oDato.pLector.Read())//pregunta si datareader tiene datos, es el lector
            {

                Producto p = new Producto();//hago un producto p
                if (!oDato.pLector.IsDBNull(0))
                    p.pCodigo = oDato.pLector.GetInt32(0);//aca ponemos el valor de la prinera columna, sacamos datos del datareader,
                if (!oDato.pLector.IsDBNull(1))
                    p.pDetalle = oDato.pLector["Detalle"].ToString(); //sacamos datos del datareader
                if (!oDato.pLector.IsDBNull(2))
                    p.pTipo=Convert.ToInt32(oDato.pLector.GetValue(2)); //sacamos datos del datareader
                                                               //arriba son 3 formas
                if (!oDato.pLector.IsDBNull(3))
                    p.pMarca =oDato.pLector.GetInt32(3);
                if(!oDato.pLector.IsDBNull(4))// esto se hace con todos los campos
                    p.pPrecio = oDato.pLector.GetDouble(4);
                if (!oDato.pLector.IsDBNull(5))
                    p.pFecha = oDato.pLector.GetDateTime(5);
                ap[c] = p;
                c++;
                   
            }
            oDato.pLector.Close();//cierro datareader
            oDato.desconectar();//me desconecto
            lstProducto.Items.Clear();//limpia la lista

            for (int i = 0; i < c; i++)
            {
                lstProducto.Items.Add(ap[i].toString());
            }
            lstProducto.SelectedIndex = 0;//se posiciona en el producto inicial

        }

        private void cargarCombo(ComboBox combo,string nombreTabla) //metodo para el combobox
        {
            DataTable tabla = new DataTable();
            tabla = oDato.consultarTabla(nombreTabla);
            combo.DataSource =tabla;
            combo.DisplayMember = tabla.Columns[1].ColumnName; // es la primer columna luego de la que es pk
            combo.ValueMember = tabla.Columns[0].ColumnName; //es el pk de la columna
            //Que hacer con un combo siempre? Respuesta: No puede estar editable
            combo.DropDownStyle = ComboBoxStyle.DropDownList; // deja no editable el combo
            combo.SelectedIndex = -1; //no de ja ninguno seleccionado en el combo
        }

        private void Habilitar(bool habilitador) //esto es un metodo que habilita activa y desactiva botones para navegar y con bool le metemos un parametro
        {
            txtCodigo.Enabled = habilitador;
            txtDetalle.Enabled = habilitador;
            txtPrecio.Enabled = habilitador;
            cboMarca.Enabled = habilitador;
            dtpFecha.Enabled = habilitador;
            rbtNetbook.Enabled = habilitador;
            rbtNotebook.Enabled = habilitador;
            btnGrabar.Enabled = habilitador;
            btnCancelar.Enabled = habilitador;


            btnNuevo.Enabled = !habilitador; //
            btnEditar.Enabled = !habilitador;
            btnBorrar.Enabled = !habilitador;
            btnSalir.Enabled = !habilitador;
            lstProducto.Enabled = !habilitador;
        }
        private void limpiar() //limpia todo
        {
            txtCodigo.Text = "";
            txtDetalle.Clear();
            txtPrecio.Clear();
            cboMarca.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Today;//limpia el datepicker
            rbtNetbook.Checked = false; //podemos poner false en uno true en otro para q quede seleccionado por defecto
            rbtNotebook.Checked = false;

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.limpiar();
            this.nuevo = true;
            this.Habilitar(true);
            this.txtCodigo.Focus();//te lleva al primer txt que es codigo


            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.Habilitar (true);
            this.txtCodigo.Enabled = false;
            this.txtDetalle.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //VALIDAR EN EL PEOR DE LOS ESCENARIOS, si no lo hicimos antes.
            //pk y fk no se pueden editar, el resto si
            string consultaSQL = "";
            Producto p = new Producto(); //creamos nuevo producto
            p.pCodigo = Convert.ToInt32(txtCodigo.Text);//lo ponemos porque hay q cargarlo no es identity, si es modificado no se puede cambiar. Tengo q ver que no exista.
            p.pDetalle = txtDetalle.Text;
            p.pMarca = Convert.ToInt32(cboMarca.SelectedValue);
            if (rbtNotebook.Checked)
                p.pTipo = 1;
            else
                p.pTipo = 2;
            p.pPrecio = Convert.ToDouble(txtPrecio.Text);
            p.pFecha = dtpFecha.Value;

            if(nuevo)
                if (!existe(p.pCodigo))

            {
                    //insert....
                    consultaSQL = "INSERT INTO Producto (codigo,detalle,tipo,marca,precio,fecha) VALUES ( " +
                        + p.pCodigo + ",'"
                        + p.pDetalle + "',"
                        + p.pTipo + ","
                        + p.pMarca + ","
                        + p.pPrecio + ",'"
                        + p.pFecha + "')";
                    oDato.actualizaBD(consultaSQL);
                    cargarLista("Producto");
                    
            }
            else
                {
                    MessageBox.Show("este producto ya esta registrado...");
                }

            else
            {
                //update....
                consultaSQL="UPDATE Producto SET detalle='" + p.pDetalle+"',"  
                    + "tipo=" + p.pTipo + ","
                    + "Marca=" + p.pMarca +"," 
                    + "Precio=" + p.pPrecio + ","
                    + "fecha=" + p.pFecha + "',"
                    + "WHERE codigo=" + p.pCodigo;
                oDato.actualizaBD(consultaSQL);
                cargarLista("Producto");


            }
            this.Habilitar(false);
            this.nuevo = false;
        }

        private bool existe(int pk)
        {
            for (int i = 0; i < c; i++)
            {
                if (ap[1].pCodigo == pk)
                    return true;
            }
            return false;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.limpiar();
            this.Habilitar(false);
            this.nuevo = false;

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //this.Habilitar(true);
            this.Close();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Esta seguro de eliminar este prducto"
                ,"ELIMINADO"
                ,MessageBoxButtons.YesNo
                ,MessageBoxIcon.Warning
                ,MessageBoxDefaultButton.Button2)
                == DialogResult.Yes)
            {
                string consultaSQL = "DELETE FROM Producto WHERE codigo="
                    + ap[lstProducto.SelectedIndex].pCodigo;
                oDato.actualizaBD(consultaSQL);
                cargarLista("Producto");

            }

        }

        private void frmProducto_FormClosing(object sender, FormClosingEventArgs e)//esto es un evento para ver si sale o no del form
        {
            if (MessageBox.Show("seguro que desea salir?", "salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }

        private void lstProducto_SelectedIndexChanged(object sender, EventArgs e)//este evento es cuabdo cambia indice posicion de la lista
        {
            this.cargarCampo(lstProducto.SelectedIndex);
        }

        private void cargarCampo(int posicion)
        {
            txtCodigo.Text = ap[posicion].pCodigo.ToString();
            txtDetalle.Text = ap[posicion].pDetalle;
            cboMarca.SelectedValue = ap[posicion].pMarca;
            if (ap[posicion].pTipo==1)       
                rbtNotebook.Checked = true;                          
                else
                 rbtNetbook.Checked = true;
                txtPrecio.Text = ap[posicion].pPrecio.ToString();
                dtpFecha.Value = ap[posicion].pFecha;                 
            
        }



        //private void label4_Click(object sender, EventArgs e)
        //{

        //}





    }
}
