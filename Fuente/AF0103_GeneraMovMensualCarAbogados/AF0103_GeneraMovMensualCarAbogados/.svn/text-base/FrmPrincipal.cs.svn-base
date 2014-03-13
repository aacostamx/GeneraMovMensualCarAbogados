using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Threading;
using System.Diagnostics;

///////////////////////////////////////////////////////////////////////////////////////////////////////////
// Elaboro : Antonio Acosta Murillo
// Objetivo: Se modificó al momento de generar el reporte, ahora genera un reporte excel y uno pdf
// Fecha   : 21/Ene/2014
///////////////////////////////////////////////////////////////////////////////////////////////////////////
// Elaboro : Antonio Acosta Murillo
// Objetivo: Generar reporte mensual de los movimientos de la cartera asignada a los abogados internos
// Fecha   : 15/Ene/2014
///////////////////////////////////////////////////////////////////////////////////////////////////////////


namespace AF0103_GeneraMovMensualCarAbogados
{
    public partial class FrmPrincipal : Form
    {
        #region variables globales
        ConexionSQL con = new ConexionSQL();
        ReportDocument rptAbogados = new ReportDocument();
        //declaras los BackgroundWorkers y el delegado
        private BackgroundWorker Worker = new BackgroundWorker();
        private BackgroundWorker Worker2 = new BackgroundWorker();
        public delegate void Fhandler();

        #endregion

        #region constructor
        public FrmPrincipal()
        {
            InitializeComponent();            
            //Inicias el backgoundWorker y asignas verdadero el soporte de cancelacion
            InitializeBackgoundWorker();
            Worker.WorkerSupportsCancellation = true;
            Worker2.WorkerSupportsCancellation = true;
            //Se cancela los llamados por cruce de hilos
            CheckForIllegalCrossThreadCalls = false; 
        }
        #endregion

        #region eventos
        private void FrmPrincipal_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Dispose();
                    this.Close();
                    break;
            }
        }

        private void bIniciar_Click(object sender, EventArgs e)
        {
            //Se desactivan los componentes y limpia las label
            bIniciar.Enabled = false;
            dtpFecha.Enabled = false;
            lbHoraInicialUsuario.Text = "--";
            lbHoraFinalUsuario.Text = "--";
            tsslbEstatus.Text = "--";
            Cursor = Cursors.WaitCursor;
            tsslbEstatus.Text = "Proceso en ejecución";
            Refresh();

            //aquí debes de asignar la hora a la hora de inicio 
            lbHoraInicialUsuario.Text = DateTime.Now.ToLongTimeString();
            Refresh();

            //corres los workers
            Worker2.RunWorkerAsync();
            Worker.RunWorkerAsync();
        }

        #endregion

        #region logica
        public void GeneraMovMEnsualCarAbogados()
        {
            //es importante que el worker este dentro de un try catch
            try
            {
                //Se declaran las variables a utilizar
                DateTime dtFecha;
                String sFecha, sFechaArchivo, sConexion, sentencia;
                DataTable dtaAbogados = new DataTable();

                //Selecciona el valor del dtpFecha en una variable de tipo fecha
                dtFecha = dtpFecha.Value.Date;
                //Se resta un mes a la fecha para que funcione con el ODS
                dtFecha = dtFecha.AddMonths(-1);

                //Se crea unaq cadena para enviarlo en el procedimiento y una cadena para pegarlo al nombre del pdf
                sFecha = dtFecha.ToString("yyyyMMdd");
                sFechaArchivo = dtFecha.ToString("dd-MM-yyyy");

                //Se forma la sentencia
                sentencia = "EXEC AF0103_GeneraMovMensualCarAbogados " + "'" + sFecha + "'";

                //Verifica que exista el archivo de conexion
                if (!File.Exists("C:\\Sys\\Exe\\Conexion\\Conexion123Carteras.txt"))
                {
                    MessageBox.Show("El archivo de texto de la conexión no existe", "Advertencia");
                    bIniciar.Enabled = true;
                    Cursor = Cursors.Default;
                    MessageBox.Show("Por favor revisa que el archivo de conexio Conexion123Carteras exista", "Aviso");
                    //Se cierra la aplicacion
                    Application.Exit();

                }

                //Se conecta a la base de datos
                sConexion = con.LeeArchivo("C:\\Sys\\Exe\\Conexion\\Conexion123Carteras.txt");
                //Instancia un objecto de la clase Conexion y ejecuta la sentencia
                Conexion objConexion = new Conexion(sConexion);
                objConexion.EjecutarSentencia(sentencia);

                //Llena la tabla de datos con la informacion para generar el reporte
                objConexion.LlenarDataTable(ref dtaAbogados, "select * from CarteraAbogados_FINAL");

                //Genera reporte total
                rptAbogados.FileName = @"rassdk://C:\sys\crystal\AF0103_GeneraMovMensualCarAbogados.rpt";
                rptAbogados.DataSourceConnections[0].SetConnection(con.IP, con.DB, con.USER, con.PASS);
                rptAbogados.Refresh();
                rptAbogados.SetDataSource(dtaAbogados);
                rptAbogados.SetDatabaseLogon(con.USER, con.PASS);
                rptAbogados.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA3;
                rptAbogados.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
                //rptAbogados.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "MensualMovCarAbogados_" + sFechaArchivo + ".pdf");
                rptAbogados.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, "MensualMovCarAbogados_" + sFechaArchivo + ".xls");


                //se limpia el la tabla de datos
                dtaAbogados.Clear();

                //para finalizar se utiliza el delegado
                BeginInvoke((Delegate)new FrmPrincipal.Fhandler(Finaliza));
                //para cancelar los workers
                Worker.CancelAsync();
                Worker2.CancelAsync();
            }
            catch (Exception ex)
            {
                //finaliza el worker
                BeginInvoke((Delegate)new FrmPrincipal.Fhandler(this.Finaliza));
                //para cancelar el worker
                Worker.CancelAsync();
                Worker2.CancelAsync();
                int num = (int)MessageBox.Show("Error: " + ((object)ex.Message).ToString() + "\nSource: " + ((object)ex.Source).ToString() + "\nMetodo: " + ex.TargetSite.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        #endregion

        #region metodos
        //metodo para inicializar el backgroundworker 
        private void InitializeBackgoundWorker()
        {
            Worker.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            Worker2.DoWork += new DoWorkEventHandler(backgroundWorker2_DoWork);
            Worker2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker2_RunWorkerCompleted);
        }

        //metodo de la interfaz del worker 1
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Transcurrido();
        }

        //metodo que llama el procedimiento del worker 2
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            GeneraMovMEnsualCarAbogados();
        }

        //si el worker 1 termina revisa que no tenga errores
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
                return;
            int num = (int)MessageBox.Show(e.Error.Message);
        }

        //si el worker dos termina revisa que no tenga erroes
        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
                return;
            int num = (int)MessageBox.Show(e.Error.Message);
        }

        //Metodo que invoca el metodo tiempo transcurrido
        public void Transcurrido()
        {
            try
            {
                MethodInvoker methodInvoker = new MethodInvoker(TiempoTranscurrido);
                while (!Worker.CancellationPending)
                {
                    BeginInvoke((Delegate)methodInvoker);
                    Thread.Sleep(500);
                }
            }
            catch (ThreadInterruptedException ex)
            {
                MessageBox.Show(ex.ToString(), "Aviso");
            }
        }

        //Calcula el tiempo transcurrido 
        private void TiempoTranscurrido()
        {
            //lbTime.Text = ("Transcurrido " + Convert.ToString((object)(DateTime.Now - Convert.ToDateTime(lbHoraInicio.Text)))).Substring(0, 21);
            //lbTimeTranscurrido.Text = Convert.ToString(((object)(DateTime.Now - Convert.ToDateTime(lbHoraInicialUsuario.Text)))).Substring(0, 21);
            lbTimeTranscurridoUsuario.Text = Convert.ToString(DateTime.Now - Convert.ToDateTime(lbHoraInicialUsuario.Text)).Substring(0, 8);
            //lbTimeTranscurrido.Text = DateTime.Now.Second.ToString();
            Refresh();
        }

        //si se cierra la forma principal se cancelan los workers
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Worker.CancelAsync();
            Worker2.CancelAsync();
        }

        public void Finaliza()
        {
            Cursor = Cursors.Default;
            lbHoraFinalUsuario.Text = DateTime.Now.ToLongTimeString();
            tsslbEstatus.Text = "Proceso Finalizado";
            bIniciar.Enabled = true;
            dtpFecha.Enabled = true;

            Refresh();
            Worker2.CancelAsync();
        }
        #endregion

    }
}
