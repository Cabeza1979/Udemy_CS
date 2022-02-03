using capaEntidad;
using capaDatos;
using System.Data;

namespace capaNegocio
{
    public class CNCliente
    {
        CDCliente cDCliente = new CDCliente();
        public bool validarDatos(CEClientes cliente)
        {
            bool Resultado = true;
            if (cliente.Nombre  == String.Empty )
            {
                Resultado = false;
                MessageBox.Show("El nombre es obligatorio");
            }
            if (cliente.Apellido == String.Empty)
            {
                Resultado = false;
                MessageBox.Show("El apellido es obligatorio");
            }

            if (cliente.Foto  == null)
            {
                Resultado = false;
                MessageBox.Show("La foto es obligatoria");
            }
            return Resultado;
        }

        public void PruebaMySQL()
        {
            cDCliente.PruebaConexion();
        }

        public void CrearCliente(CEClientes cE)
        {
            cDCliente.Crear(cE);
        }

        public void EditarCliente(CEClientes cE)
        {
            cDCliente.Editar(cE);
        }
        public void EliminarCliente(CEClientes cE)
        {
            cDCliente.Eliminar(cE);
        }
        public DataSet ObtenerDatos()
        {
            return cDCliente.Listar();
        }
    }
}