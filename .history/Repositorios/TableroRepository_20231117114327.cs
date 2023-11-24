
using System.Data.SQLite;
using tl2_tp10_2023_GuilloValle.Models;
public class TableroRepository : ITableroReposirory
{   

    private string cadenaConexion = "Data Source=db/Kanban.db;Cache=Shared";
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

    public void ModificarTablero(int id,Tablero tablero){

        using( SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = connection.CreateCommand();
                // usar AddParameter
                command.CommandText = $"UPDATE Usuario SET Nombre = @nombre, Descripcion = @desc WHERE id = @idAActualizar;";
                command.Parameters.Add(new SQLiteParameter("@idAActualizar",id));
                command.Parameters.Add(new SQLiteParameter("@nombre",tablero.Nombre));
                command.Parameters.Add(new SQLiteParameter("@desc",tablero.Descripcion));     
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
    }

}