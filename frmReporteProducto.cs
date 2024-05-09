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
    public partial class frmReporteProducto : Form
    {
        AccesoDatos oDato = new AccesoDatos(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\DBFProducto.mdb");

        public frmReporteProducto()
        {
            InitializeComponent();
        }

        private void btnImpimirTodo_Click(object sender, EventArgs e)
        {
            rptproducto reporte = new rptproducto();
            crystalReportViewer1.ReportSource = reporte; //lo mismo q en el diseño del reporte con el asistente
            crystalReportViewer1.Refresh();
            crystalReportViewer1.Show();        
        }

        private void btnImpimirAlgo_Click(object sender, EventArgs e) //aqui hacemnos consulta con filtro o parametro de busqueda
        {
            rptproducto reporte = new rptproducto();

            string consultasql = "select * from Producto"
                + " where detalle like'" + txtImprimirFiltro.Text + "%'";

            reporte.SetDataSource(oDato.consultarSQL(consultasql));

            crystalReportViewer1.ReportSource = reporte; //lo mismo q en el diseño del reporte con el asistente
            crystalReportViewer1.Refresh();
            crystalReportViewer1.Show();
        }

    }

}
