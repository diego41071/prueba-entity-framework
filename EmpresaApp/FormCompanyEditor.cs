using EmpresaApp.Data;
using EmpresaApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpresaApp
{
    public partial class FormCompanyEditor : Form
    {
        private readonly EmpresaContext _context; // Contexto de la base de datos
        public int? EmpresaId { get; set; } // ID de la empresa (nulo si es creación)

        public FormCompanyEditor(int? empresaId = null)
        {
            InitializeComponent();
            _context = new EmpresaContext();
            EmpresaId = empresaId;

            // Configura el título del formulario
            lblTitulo.Text = EmpresaId.HasValue ? "Editando Empresa" : "Creando nueva Empresa";

            // Si es edición, cargar los datos de la empresa
            if (EmpresaId.HasValue)
            {
                CargarDatosEmpresa(EmpresaId.Value);
            }
        }

        private void CargarDatosEmpresa(int empresaId)
        {
            // Busca la empresa en la base de datos
            var empresa = _context.Empresas.FirstOrDefault(e => e.EmpresaID == empresaId);
            if (empresa == null)
            {
                MessageBox.Show("Empresa no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            // Carga los datos en los campos
            txtNombre.Text = empresa.Nombre;
            txtCodigo.Text = empresa.Codigo.ToString();
            txtDireccion.Text = empresa.Direccion;
            txtTelefono.Text = empresa.Telefono;
            txtCiudad.Text = empresa.Ciudad;
            txtDepartamento.Text = empresa.Departamento;
            txtNombre.Text = empresa.Pais;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("El nombre y el código son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (EmpresaId.HasValue)
            {
                // Editar empresa existente
                var empresa = _context.Empresas.FirstOrDefault(ev => ev.EmpresaID == EmpresaId.Value);
                if (empresa == null)
                {
                    MessageBox.Show("Empresa no encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                empresa.Nombre = txtNombre.Text;
                empresa.Codigo = int.Parse(txtCodigo.Text);
                empresa.Direccion = txtDireccion.Text;
                empresa.Telefono = txtTelefono.Text;
                empresa.Ciudad = txtCiudad.Text;
                empresa.Departamento = txtDepartamento.Text;
                empresa.Pais = txtNombre.Text;
                empresa.FechaModificacion = DateTime.Now;
            }
            else
            {
                // Crear nueva empresa
                var nuevaEmpresa = new Empresa
                {
                    Nombre = txtNombre.Text,
                    Codigo = int.Parse(txtCodigo.Text),
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    Ciudad = txtCiudad.Text,
                    Departamento = txtDepartamento.Text,
                    Pais = txtNombre.Text,
                    FechaCreacion = DateTime.Now,
                    FechaModificacion = DateTime.Now
                };

                _context.Empresas.Add(nuevaEmpresa);
            }

            // Guardar cambios en la base de datos
            _context.SaveChanges();
            MessageBox.Show("Empresa guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close(); // Cierra el formulario
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario sin guardar
            Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormCompanyEditor_Load(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtDepartamento = new System.Windows.Forms.TextBox();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.txtPais = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(99, 34);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(99, 67);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(99, 93);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(100, 20);
            this.txtDireccion.TabIndex = 2;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(99, 119);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(100, 20);
            this.txtTelefono.TabIndex = 3;
            // 
            // txtDepartamento
            // 
            this.txtDepartamento.Location = new System.Drawing.Point(99, 171);
            this.txtDepartamento.Name = "txtDepartamento";
            this.txtDepartamento.Size = new System.Drawing.Size(100, 20);
            this.txtDepartamento.TabIndex = 4;
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(99, 145);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(100, 20);
            this.txtCiudad.TabIndex = 5;
            // 
            // txtPais
            // 
            this.txtPais.Location = new System.Drawing.Point(99, 197);
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(100, 20);
            this.txtPais.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Código";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Dirección";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Teléfono";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Ciudad";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Departamento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "País";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(54, 226);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 14;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(135, 226);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(96, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(35, 13);
            this.lblTitulo.TabIndex = 16;
            this.lblTitulo.Text = "label8";
            // 
            // FormCompanyEditor
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPais);
            this.Controls.Add(this.txtCiudad);
            this.Controls.Add(this.txtDepartamento);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.txtNombre);
            this.Name = "FormCompanyEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
