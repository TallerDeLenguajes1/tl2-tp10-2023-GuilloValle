using tl2_tp10_2023_GuilloValle.Models;
using System.Data.SQLite;


public class UsuarioRepository : IUsuarioRepository
{

    private string cadenaConexion = "Data Source=db/Kanban.db;Cache=Shared";
    public List<Usuario> GetAllUsuarios(){

            var queryString = @"SELECT * FROM Usuario;";
            List<Usuario> usuarios = new List<Usuario>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(queryString, connection);
                connection.Open();
            
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(reader["id"]);
                        usuario.NombreDeUsuario = reader["Nombre_de_usuario"].ToString();
                        usuarios.Add(usuario);
                    }
                }
                connection.Close();
            }
            return usuarios;
    }

    public Usuario ObtenerUsuarioPorId(int id){

            SQLiteConnection connection = new SQLiteConnection(cadenaConexion);  //Me conecto con la base de datos (en este caso Kanban.db)
            var usuario = new Usuario();
            SQLiteCommand command = connection.CreateCommand();  //creo un comando para poder hacer una consulta SQL
            command.CommandText = "SELECT * FROM Usuario WHERE id = @idUsu";
            command.Parameters.Add(new SQLiteParameter("@idUsu",id ));    // Lo que esta en @idUsu se reemplaza por lo que esta en id, se usa para evitar inyeccion de sql para no usar {}
            connection.Open();
            using(SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())  //tiene sentido si solo trae un solo usuario la funcion?
                {
                    usuario.Id = Convert.ToInt32(reader["id"]);
                    usuario.NombreDeUsuario = reader["Nombre_de_usuario"].ToString();

                }
            }
            connection.Close();

            return (usuario);
    }

    public void CrearNuevoUsuario(Usuario usuario){

            var query = $"INSERT INTO Usuario (Nombre_de_usuario) VALUES (@Nombre_de_usuario)";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {

                connection.Open();
                var command = new SQLiteCommand(query, connection);
                //SQLiteCommand command = connection.CreateCommand(); Por que no puedo usar esta linea en vez de la de arriba, linea 62, como uso en ObtenerUsuarioPorId???

                command.Parameters.Add(new SQLiteParameter("@Nombre_de_usuario", usuario.NombreDeUsuario));

                command.ExecuteNonQuery();

                connection.Close();   
            }
    }

    public void EliminarUsuario(int id){          
           // usar using
            using( SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = connection.CreateCommand();
                // usar AddParameter
                command.CommandText = $"DELETE FROM Usuario WHERE id = @idAeliminar;";
                command.Parameters.Add(new SQLiteParameter("@idAeliminar",id ));    
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            
    }

    public void ModificarUsuario(Usuario usuario){

         using( SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = connection.CreateCommand();
                // usar AddParameter
                command.CommandText = $"UPDATE Usuario SET Nombre_de_usuario = @nombreDeUsuario WHERE id = @idAActualizar;";
                command.Parameters.Add(new SQLiteParameter("@idAActualizar",usuario.Id));
                command.Parameters.Add(new SQLiteParameter("@nombreDeUsuario",usuario.NombreDeUsuario));     
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
    }

}