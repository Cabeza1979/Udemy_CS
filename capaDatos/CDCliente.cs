using MySql.Data.MySqlClient;
using capaEntidad;
using System.Data;

namespace capaDatos
{
    public class CDCliente
    {
        string cadenaConexion = "Server=localhost;User=root;Password=123456;Port=3306;database=curso_cs";

        public void PruebaConexion()
        {
            MySqlConnection connectionSql = new MySqlConnection(cadenaConexion);

            try
            {
                connectionSql.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectarse " + ex.Message);
                return;
            }
            connectionSql.Close();
            MessageBox.Show("Conectado");
        }

        public void Crear(CEClientes cE)
        {
            MySqlConnection connectionSql = new MySqlConnection(cadenaConexion);
            connectionSql.Open();

            string Query = "INSERT INTO `clientes` (`nombre`, `apellido`, `foto`) VALUES ('" + cE.Nombre + "', '" + cE.Apellido + "', '" + MySql.Data.MySqlClient.MySqlHelper.EscapeString(cE.Foto) + "');"; //
            MySqlCommand commandSql = new MySqlCommand(Query, connectionSql);
            commandSql.ExecuteNonQuery();
            connectionSql.Close();
            MessageBox.Show("Registro creado");
        }
        public DataSet Listar()
                {
            MySqlConnection connectionSql = new MySqlConnection(cadenaConexion);
            connectionSql.Open();

            string Query = "SELECT * FROM `clientes` LIMIT 1000;"; //
            MySqlDataAdapter Adaptador;
            DataSet ds = new();
            Adaptador = new MySqlDataAdapter(Query, connectionSql);
            Adaptador.Fill(ds,"tbl");

            return ds;
        }

        public void Editar(CEClientes cE)
        {
            MySqlConnection connectionSql = new MySqlConnection(cadenaConexion);
            connectionSql.Open();

            string Query = "UPDATE `clientes` SET `nombre`='" + cE.Nombre + "', `apellido`='" + cE.Apellido + "', `foto`='" + MySql.Data.MySqlClient.MySqlHelper.EscapeString(cE.Foto) + "' WHERE  `id`=" + cE.Id +";"; //
            MySqlCommand commandSql = new MySqlCommand(Query, connectionSql);
            commandSql.ExecuteNonQuery();
            connectionSql.Close();
            MessageBox.Show("Registro actualizado");
        }

        public void Eliminar(CEClientes cE)
        {
            MySqlConnection connectionSql = new MySqlConnection(cadenaConexion);
            connectionSql.Open();

            string Query = "DELETE FROM `clientes` WHERE  `id`=" + cE.Id +";"; //
            MySqlCommand commandSql = new MySqlCommand(Query, connectionSql);
            commandSql.ExecuteNonQuery();
            connectionSql.Close();
            MessageBox.Show("Registro eliminado");
        }
    }
}