using BEUEjercicio;
using BEUEjercicio.Transactions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIEjercicio
{
    public partial class frmAlumno : Form
    {
        public frmAlumno()
        {
            InitializeComponent();
        }

        private void cargarListado()
        {
            this.lstAlumnos.DataSource = null;
            List<Alumno> alumnos = AlumnoBLL.List();
            this.lstAlumnos.DataSource = alumnos;
        }

        private void frmAlumno_Load(object sender, EventArgs e)
        {
            cargarListado();
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Alumno alumno = new Alumno();
                alumno.nombre = txtNombre.Text.Trim();
                alumno.apellidos = txtApellido.Text.Trim();
                alumno.cedula = txtCedula.Text.Trim();
                alumno.lugar_nacimiento = txtLugar.Text.Trim();
                alumno.sexo = rbMasculino.Checked ? "M" : "F";
                alumno.fecha_nacimiento = dtpFecha.Value;

                AlumnoBLL.Create(alumno);
                cargarListado();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
