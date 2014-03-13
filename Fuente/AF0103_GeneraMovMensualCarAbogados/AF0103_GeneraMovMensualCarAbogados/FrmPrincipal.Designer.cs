namespace AF0103_GeneraMovMensualCarAbogados
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.gbPrincipal = new System.Windows.Forms.GroupBox();
            this.gbRendimiento = new System.Windows.Forms.GroupBox();
            this.lbTimeTranscurridoUsuario = new System.Windows.Forms.Label();
            this.lbTimeTranscurrido = new System.Windows.Forms.Label();
            this.lbHoraFinalUsuario = new System.Windows.Forms.Label();
            this.lbHoraInicialUsuario = new System.Windows.Forms.Label();
            this.lbHoraFinal = new System.Windows.Forms.Label();
            this.lbHoraInicial = new System.Windows.Forms.Label();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bIniciar = new System.Windows.Forms.Button();
            this.ssBarraEstatus = new System.Windows.Forms.StatusStrip();
            this.tsslbEstatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.gbPrincipal.SuspendLayout();
            this.gbRendimiento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ssBarraEstatus.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPrincipal
            // 
            this.gbPrincipal.Controls.Add(this.groupBox1);
            this.gbPrincipal.Controls.Add(this.gbRendimiento);
            this.gbPrincipal.Controls.Add(this.lbTitulo);
            this.gbPrincipal.Controls.Add(this.pictureBox1);
            this.gbPrincipal.Controls.Add(this.bIniciar);
            this.gbPrincipal.Location = new System.Drawing.Point(12, 12);
            this.gbPrincipal.Name = "gbPrincipal";
            this.gbPrincipal.Size = new System.Drawing.Size(398, 377);
            this.gbPrincipal.TabIndex = 0;
            this.gbPrincipal.TabStop = false;
            // 
            // gbRendimiento
            // 
            this.gbRendimiento.Controls.Add(this.lbTimeTranscurridoUsuario);
            this.gbRendimiento.Controls.Add(this.lbTimeTranscurrido);
            this.gbRendimiento.Controls.Add(this.lbHoraFinalUsuario);
            this.gbRendimiento.Controls.Add(this.lbHoraInicialUsuario);
            this.gbRendimiento.Controls.Add(this.lbHoraFinal);
            this.gbRendimiento.Controls.Add(this.lbHoraInicial);
            this.gbRendimiento.Location = new System.Drawing.Point(10, 234);
            this.gbRendimiento.Name = "gbRendimiento";
            this.gbRendimiento.Size = new System.Drawing.Size(378, 107);
            this.gbRendimiento.TabIndex = 3;
            this.gbRendimiento.TabStop = false;
            this.gbRendimiento.Text = "Rendimiento";
            // 
            // lbTimeTranscurridoUsuario
            // 
            this.lbTimeTranscurridoUsuario.AutoSize = true;
            this.lbTimeTranscurridoUsuario.Location = new System.Drawing.Point(180, 78);
            this.lbTimeTranscurridoUsuario.Name = "lbTimeTranscurridoUsuario";
            this.lbTimeTranscurridoUsuario.Size = new System.Drawing.Size(13, 13);
            this.lbTimeTranscurridoUsuario.TabIndex = 11;
            this.lbTimeTranscurridoUsuario.Text = "--";
            // 
            // lbTimeTranscurrido
            // 
            this.lbTimeTranscurrido.AutoSize = true;
            this.lbTimeTranscurrido.Location = new System.Drawing.Point(111, 78);
            this.lbTimeTranscurrido.Name = "lbTimeTranscurrido";
            this.lbTimeTranscurrido.Size = new System.Drawing.Size(45, 13);
            this.lbTimeTranscurrido.TabIndex = 12;
            this.lbTimeTranscurrido.Text = "Tiempo:";
            // 
            // lbHoraFinalUsuario
            // 
            this.lbHoraFinalUsuario.AutoSize = true;
            this.lbHoraFinalUsuario.Location = new System.Drawing.Point(180, 53);
            this.lbHoraFinalUsuario.Name = "lbHoraFinalUsuario";
            this.lbHoraFinalUsuario.Size = new System.Drawing.Size(13, 13);
            this.lbHoraFinalUsuario.TabIndex = 4;
            this.lbHoraFinalUsuario.Text = "--";
            // 
            // lbHoraInicialUsuario
            // 
            this.lbHoraInicialUsuario.AutoSize = true;
            this.lbHoraInicialUsuario.Location = new System.Drawing.Point(180, 29);
            this.lbHoraInicialUsuario.Name = "lbHoraInicialUsuario";
            this.lbHoraInicialUsuario.Size = new System.Drawing.Size(13, 13);
            this.lbHoraInicialUsuario.TabIndex = 3;
            this.lbHoraInicialUsuario.Text = "--";
            // 
            // lbHoraFinal
            // 
            this.lbHoraFinal.AutoSize = true;
            this.lbHoraFinal.Location = new System.Drawing.Point(111, 53);
            this.lbHoraFinal.Name = "lbHoraFinal";
            this.lbHoraFinal.Size = new System.Drawing.Size(58, 13);
            this.lbHoraFinal.TabIndex = 1;
            this.lbHoraFinal.Text = "Hora Final:";
            // 
            // lbHoraInicial
            // 
            this.lbHoraInicial.AutoSize = true;
            this.lbHoraInicial.Location = new System.Drawing.Point(111, 29);
            this.lbHoraInicial.Name = "lbHoraInicial";
            this.lbHoraInicial.Size = new System.Drawing.Size(63, 13);
            this.lbHoraInicial.TabIndex = 0;
            this.lbHoraInicial.Text = "Hora Inicial:";
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Location = new System.Drawing.Point(6, 16);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(382, 20);
            this.lbTitulo.TabIndex = 2;
            this.lbTitulo.Text = "Movimientos Mensuales de Abogados Internos";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(156, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(89, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // bIniciar
            // 
            this.bIniciar.Location = new System.Drawing.Point(156, 347);
            this.bIniciar.Name = "bIniciar";
            this.bIniciar.Size = new System.Drawing.Size(89, 23);
            this.bIniciar.TabIndex = 1;
            this.bIniciar.Text = "Iniciar";
            this.bIniciar.UseVisualStyleBackColor = true;
            this.bIniciar.Click += new System.EventHandler(this.bIniciar_Click);
            // 
            // ssBarraEstatus
            // 
            this.ssBarraEstatus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ssBarraEstatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslbEstatus});
            this.ssBarraEstatus.Location = new System.Drawing.Point(0, 397);
            this.ssBarraEstatus.Name = "ssBarraEstatus";
            this.ssBarraEstatus.Size = new System.Drawing.Size(422, 22);
            this.ssBarraEstatus.TabIndex = 2;
            this.ssBarraEstatus.Text = "statusStrip1";
            // 
            // tsslbEstatus
            // 
            this.tsslbEstatus.Name = "tsslbEstatus";
            this.tsslbEstatus.Size = new System.Drawing.Size(142, 17);
            this.tsslbEstatus.Text = "Presiona ESC para salir";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.lbFecha);
            this.groupBox1.Location = new System.Drawing.Point(10, 144);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 79);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fecha";
            // 
            // lbFecha
            // 
            this.lbFecha.AutoSize = true;
            this.lbFecha.Location = new System.Drawing.Point(111, 31);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(40, 13);
            this.lbFecha.TabIndex = 7;
            this.lbFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Checked = false;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(157, 27);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(94, 20);
            this.dtpFecha.TabIndex = 8;
            this.dtpFecha.Value = new System.DateTime(2014, 1, 20, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(17, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nota: a la fecha seleccionada se le resta un mes para usarla en el ODS";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(422, 419);
            this.Controls.Add(this.ssBarraEstatus);
            this.Controls.Add(this.gbPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AF0103_GeneraMovMensualCarAbogados";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmPrincipal_KeyUp);
            this.gbPrincipal.ResumeLayout(false);
            this.gbPrincipal.PerformLayout();
            this.gbRendimiento.ResumeLayout(false);
            this.gbRendimiento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ssBarraEstatus.ResumeLayout(false);
            this.ssBarraEstatus.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPrincipal;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bIniciar;
        private System.Windows.Forms.StatusStrip ssBarraEstatus;
        private System.Windows.Forms.ToolStripStatusLabel tsslbEstatus;
        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.GroupBox gbRendimiento;
        private System.Windows.Forms.Label lbTimeTranscurridoUsuario;
        private System.Windows.Forms.Label lbTimeTranscurrido;
        private System.Windows.Forms.Label lbHoraFinalUsuario;
        private System.Windows.Forms.Label lbHoraInicialUsuario;
        private System.Windows.Forms.Label lbHoraFinal;
        private System.Windows.Forms.Label lbHoraInicial;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lbFecha;
        private System.Windows.Forms.Label label1;
    }
}

