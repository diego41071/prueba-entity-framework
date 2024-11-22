using EmpresaApp.Data;
using EmpresaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EmpresaApp
{
    public partial class FormCompanyList : Form
    {
        private List<Empresa> companies; // Declarar la lista de empresas

        public FormCompanyList()
        {
            InitializeComponent();
            this.Load += FormCompanyList_Load;
        }

        // Este evento se ejecuta cuando se escribe en el TextBox para filtrar empresas
        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.ToLower();

            using (var context = new EmpresaContext())
            {
                var resultados = context.Empresas
                    .Where(empresa => empresa.Nombre.ToLower().Contains(filtro))
                    .ToList();
                dgvEmpresas.DataSource = resultados;
            }
        }

        // Este evento se ejecuta cuando el usuario hace clic en el botón Añadir
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            FormCompanyEditor formCompanyEditor = new FormCompanyEditor();
            formCompanyEditor.ShowDialog(); // Abre el formulario para agregar una nueva empresa
            LoadCompanies(); // Recarga los datos después de añadir una nueva empresa
        }

        // Este evento se ejecuta cuando el usuario hace clic en el botón Editar
        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (dgvEmpresas.SelectedRows.Count == 1)
            {
                int empresaID = Convert.ToInt32(dgvEmpresas.SelectedRows[0].Cells[0].Value);
                FormCompanyEditor formCompanyEditor = new FormCompanyEditor(empresaID); // Pasa el ID de la empresa a editar
                formCompanyEditor.ShowDialog();
                LoadCompanies(); // Recarga los datos después de editar la empresa
            }
            else
            {
                MessageBox.Show("Seleccione una empresa para editar.");
            }
        }

        // Este evento se ejecuta cuando el usuario hace clic en el botón Eliminar
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmpresas.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvEmpresas.SelectedRows)
                {
                    int empresaID = Convert.ToInt32(row.Cells[0].Value);
                    btnDelete_Click_1(empresaID); // Elimina la empresa seleccionada
                }
                LoadCompanies(); // Recarga los datos después de eliminar las empresas
            }
            else
            {
                MessageBox.Show("Seleccione al menos una empresa para eliminar.");
            }
        }

        // Este evento se ejecuta cuando el formulario carga
        private void FormCompanyList_Load(object sender, EventArgs e)
        {
            LoadCompanies(); // Carga los datos al cargar el formulario
        }

        // Función para cargar las empresas desde la base de datos
        private void LoadCompanies()
        {
            using (var context = new EmpresaContext())
            {
                companies = context.Empresas.ToList(); // Asigna los datos a la lista companies
                dgvEmpresas.DataSource = companies;    // Establece la lista como fuente de datos del DataGridView
            }
        }

        // Función para eliminar una empresa de la base de datos
        private void btnDelete_Click_1(int empresaID)
        {
            using (var context = new EmpresaContext())
            {
                var company = context.Empresas.Find(empresaID); // Busca la empresa por ID
                if (company != null)
                {
                    context.Empresas.Remove(company); // Elimina la empresa
                    context.SaveChanges(); // Guarda los cambios en la base de datos
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
