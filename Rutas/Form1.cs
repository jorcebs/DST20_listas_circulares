using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rutas
{
    public partial class Form1 : Form
    {
        Ruta ruta = new Ruta();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregarFinal_Click(object sender, EventArgs e)
        {
            ruta.agregarAlFinal(new Base(txtNombre.Text, Convert.ToInt32(txtMinutos.Text)));
            txtNombre.Text = (Convert.ToInt32(txtNombre.Text) + 1).ToString();
            txtMinutos.Text = (Convert.ToInt32(txtMinutos.Text) + 1).ToString();
            btnReporte_Click(sender, e);
        }

        private void btnAgregarInicio_Click(object sender, EventArgs e)
        {
            ruta.agregarAlInicio(new Base(txtNombre.Text, Convert.ToInt32(txtMinutos.Text)));
            txtNombre.Text = (Convert.ToInt32(txtNombre.Text) + 1).ToString();
            txtMinutos.Text = (Convert.ToInt32(txtMinutos.Text) + 1).ToString();
            btnReporte_Click(sender, e);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (ruta.buscar(txtNombre.Text) != null)
            {
                txtNombre.Text = ruta.buscar(txtNombre.Text).nombre;
                txtMinutos.Text = ruta.buscar(txtNombre.Text).minutos.ToString();
                MessageBox.Show("¡Base encontrada!");
            }
            else
                MessageBox.Show("Base no encontrada.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ruta.eliminar(txtNombre.Text))
                MessageBox.Show("Base eliminada.");
            else
                MessageBox.Show("No se pudo eliminar la base.");
        }

        private void btnEliminarÚltimo_Click(object sender, EventArgs e)
        {
            if (ruta.eliminarÚltimo())
                MessageBox.Show("Base eliminada.");
            else
                MessageBox.Show("No se pudo eliminar la base.");
        }

        private void btnInsertarDespuésDe_Click(object sender, EventArgs e)
        {
            if (ruta.insertarDespuésDe(txtInsertar.Text, new Base(txtNombre.Text, Convert.ToInt32(txtMinutos.Text))))
                MessageBox.Show("Base insertada.");
            else
                MessageBox.Show("No se pudo insertar la base.");
        }

        private void btnEliminarPrimero_Click(object sender, EventArgs e)
        {
            if (ruta.eliminarInicio())
                MessageBox.Show("Base eliminada.");
            else
                MessageBox.Show("No se pudo eliminar la base.");
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            txtResultado.Text = ruta.ToString();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            txtResultado.Text = ruta.recorrido(txtBase.Text, Convert.ToDateTime(txtHoraInicio.Text), Convert.ToDateTime(txtHoraFin.Text));
        }
    }
}