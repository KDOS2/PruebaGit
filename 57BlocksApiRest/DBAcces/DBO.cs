
namespace _57BlocksApiRest.DBAcces
{
    using _57BlocksApiRest.Entities;
    using Microsoft.Data.Sqlite;
    using System;
    using System.Data;
    using System.IO;

    public static class DBO
    {
        #region "variables privadas"
        
        private static SqliteConnection connection = null;

        #endregion

        #region "metodos publicos"

        /// <summary>
        /// Genera todas las consultas que retornan data en la base datos
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static DataTable Select(EntitySql query)
        {
            try
            {
                SqliteDataReader dataReader = null;
                DataTable dataTable = new DataTable();
                AbrirConexion();
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = query.query;
                dataReader = command.ExecuteReader();
                dataTable.Load(dataReader);
                CerrarConexion();
                return dataTable;
            }
            catch (Exception ex)
            {
                if (connection != null && connection.State.Equals(ConnectionState.Open))
                    CerrarConexion();

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// realiza todas las operaciones que se encargan de insertar y actualizar datos
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static bool Insert(EntitySql query)
        {
            try
            {
                DataTable dataTable = new DataTable();
                AbrirConexion();
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = query.query;
                command.ExecuteNonQuery();                
                CerrarConexion();
                return true;
            }
            catch (Exception ex)
            {
                if (connection != null && connection.State.Equals(ConnectionState.Open))
                    CerrarConexion();

                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region "metodos privados"

        /// <summary>
        /// metodo que abre la conexion a la base de datos
        /// </summary>
        private static void AbrirConexion()
        {
            string ruta = Path.GetFullPath("..\\57BlocksApiRest\\BD\\Movies.db");
            ruta = ruta.Replace('\\', '/');
            connection = new SqliteConnection("Data Source=" + ruta);
            connection.Open();
        }

        /// <summary>
        /// metodo que cierra la conexion a base de datos
        /// </summary>
        private static void CerrarConexion()
        {
            connection.Close();
        }

        #endregion

    }
}
