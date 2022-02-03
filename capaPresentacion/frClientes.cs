using capaEntidad;
using capaNegocio;
using System.Data;
namespace capaPresentacion
{
    public partial class frClientes : Form
    {
        CNCliente cNCliente = new CNCliente();
        CEClientes cEClientes = new CEClientes();
        public frClientes()
        {
            InitializeComponent();
        }

        private void frClientes_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtApellido.Text = string.Empty;
            txtId.Value = 0;
            picFoto.Image = null;
            CargarDatos();
        }

        private void lnkFoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ofdFoto.FileName = string.Empty;
           
            if (ofdFoto.ShowDialog()==DialogResult.OK)
            {
                picFoto.Load(ofdFoto.FileName);
            }
            {
                ofdFoto.FileName = String.Empty;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool Resultado;
           
            cEClientes.Id = (int)txtId.Value ;
            cEClientes.Nombre = txtNombre.Text ;
            cEClientes.Apellido = txtApellido.Text ;
            cEClientes.Foto = picFoto.ImageLocation ;

           Resultado = cNCliente.validarDatos(cEClientes);
            if (Resultado== false)
            {
                return;
            }

            if (cEClientes.Id==0)
            {
                cNCliente.CrearCliente(cEClientes);
            }
            else
            {
                cNCliente.EditarCliente(cEClientes);
            }
            
            CargarDatos();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Value == 0)
            {
                MessageBox.Show("Seleccione un registro");
            }
            else
            {
                if (MessageBox.Show("Desea eliminar el registro?", "Titulo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cEClientes.Id = (int)txtId.Value;
                    cNCliente.EliminarCliente(cEClientes);
                }
                else return;
                
            }
         
            CargarDatos();
        }

        private void CargarDatos()
        {
            gridDatos.DataSource = cNCliente.ObtenerDatos().Tables["tbl"];
        }

        private void gridDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Value= (int)gridDatos.CurrentRow.Cells["id"].Value;
            txtNombre.Text= gridDatos.CurrentRow.Cells["nombre"].Value.ToString();
            txtApellido.Text = gridDatos.CurrentRow.Cells["apellido"].Value.ToString();
            picFoto.Load(gridDatos.CurrentRow.Cells["foto"].Value.ToString())  ;
        }
    }
}