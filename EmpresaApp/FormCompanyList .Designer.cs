namespace EmpresaApp
{
    partial class FormCompanyList
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se están utilizando.
        /// </summary>
        /// <param name="disposing">Indica si se deben liberar los recursos administrados.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.dgvEmpresas = new System.Windows.Forms.DataGridView();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            // Inicializar otros controles aquí...

            // 
            // dgvEmpresas
            // 
            this.dgvEmpresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpresas.Location = new System.Drawing.Point(12, 12);
            this.dgvEmpresas.Name = "dgvEmpresas";
            this.dgvEmpresas.Size = new System.Drawing.Size(776, 426);
            this.dgvEmpresas.TabIndex = 0;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(12, 444);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(200, 20);
            this.txtBuscar.TabIndex = 1;

            // Inicializa otros controles, como botones...

            // 
            // FormCompanyList
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvEmpresas);
            this.Controls.Add(this.txtBuscar);
            // Agregar otros controles aquí...
            this.Name = "FormCompanyList";
            this.Load += new System.EventHandler(this.FormCompanyList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpresas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
