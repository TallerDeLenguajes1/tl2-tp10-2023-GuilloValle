namespace ConjuntoDeInterfacesRepo;
using System.Data.SQLite;
using tl2_tp10_2023_GuilloValle.Models;
public class TableroRepository : ITableroRepository
{   

     private string cadenaConexion;
    public TableroRepository(string cc){

        this.cadenaConexion = cc;

    }

    public List<Tablero> GetAllTableros(){

            var queryString = @"SELECT * FROM Tablero;";
            List<Tablero> tableros = new List<Tablero>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(queryString, connection);
                connection.Open();
            
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tablero = new Tablero();
                        tablero.Id = Convert.ToInt32(reader["id"]);
                        tablero.Id_propietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                        tablero.Nombre = reader["Nombre"].ToString();
                        tablero.Descripcion = reader["Descripcion"].ToString();
                        tableros.Add(tablero);
                    }
                }
                connection.Close();
            }
            return tableros;
    }



    public Tablero GetTableroById(int id){


            SQLiteConnection connection = new SQLiteConnection(cadenaConexion);  //Me conecto con la base de datos (en este caso Kanban.db)
            var tablero = new Tablero();
            SQLiteCommand command = connection.CreateCommand();  //creo un comando para poder hacer una consulta SQL
            command.CommandText = "SELECT * FROM Tablero WHERE id = @idtablero";
            command.Parameters.Add(new SQLiteParameter("@idtablero",id ));    // Lo que esta en @idUsu se reemplaza por lo que esta en id, se usa para evitar inyeccion de sql para no usar {}
            connection.Open();
            using(SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())  //tiene sentido si solo trae un solo usuario la funcion?
                {   
                    
                    tablero.Id = Convert.ToInt32(reader["id"]);
                    tablero.Nombre = reader["Nombre"].ToString();
                    tablero.Descripcion = reader["Descripcion"].ToString();
                    tablero.Id_propietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                }
            }
            connection.Close();

            return (tablero);
    }

      public List<Tablero> GetTableroByIdPropietario(int id_propietario){

            SQLiteConnection connection = new SQLiteConnection(cadenaConexion);  //Me conecto con la base de datos (en este caso Kanban.db)
            var tableros = new List<Tablero>();
            SQLiteCommand command = connection.CreateCommand();  //creo un comando para poder hacer una consulta SQL
            command.CommandText = "SELECT * FROM Tablero WHERE id_usuario_propietario = @idtablero_prop";
            command.Parameters.Add(new SQLiteParameter("@idtablero_prop",id_propietario));    // Lo que esta en @idUsu se reemplaza por lo que esta en id, se usa para evitar inyeccion de sql para no usar {}
            connection.Open();
            using(SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())  //tiene sentido si solo trae un solo usuario la funcion?
                {   
                    var tablero = new Tablero();
                    tablero.Id = Convert.ToInt32(reader["id"]);
                    tablero.Nombre = reader["Nombre"].ToString();
                    tablero.Descripcion = reader["Descripcion"].ToString();
                    tablero.Id_propietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                    tableros.Add(tablero);
                }
            }
            connection.Close();

            return (tableros);
      }
    


    public void CrearNuevoTablero(Tablero tablero){

            var query = $"INSERT INTO Tablero (id_usuario_propietario,Nombre,Descripcion) VALUES (@id_usuario_propietario,@Nombre,@Descp)";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                //SQLiteCommand command = connection.CreateCommand(); Por que no puedo usar esta linea en bez de la de arriba, linea 62, como uso en ObtenerUsuarioPorId???

                command.Parameters.Add(new SQLiteParameter("@id_usuario_propietario", tablero.Id_propietario));
                command.Parameters.Add(new SQLiteParameter("@Nombre", tablero.Nombre));
                command.Parameters.Add(new SQLiteParameter("@Descp", tablero.Descripcion));

                command.ExecuteNonQuery();

                connection.Close();   
            }
        
    }

    public void ModificarTablero(Tablero tablero){

        using( SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = connection.CreateCommand();
                // usar AddParameter
                command.CommandText = $"UPDATE Tablero SET Nombre = @nombre, Descripcion = @desc,id_usuario_propietario = @idUsuProp WHERE id = @idAActualizar;";
                command.Parameters.Add(new SQLiteParameter("@idAActualizar",tablero.Id));
                command.Parameters.Add(new SQLiteParameter("@nombre",tablero.Nombre));
                command.Parameters.Add(new SQLiteParameter("@desc",tablero.Descripcion));
                command.Parameters.Add(new SQLiteParameter("@idUsuProp",tablero.Id_propietario));    
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
    }

    public void EliminarTablero(int id){
        // usar using
            using( SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = connection.CreateCommand();
                // usar AddParameter
                command.CommandText = $"DELETE FROM Tablero WHERE id = @idAeliminar;";
                command.Parameters.Add(new SQLiteParameter("@idAeliminar",id ));    
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
    }

}