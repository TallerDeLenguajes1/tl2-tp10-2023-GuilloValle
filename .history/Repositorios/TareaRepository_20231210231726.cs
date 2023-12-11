namespace ConjuntoDeInterfacesRepo;
using tl2_tp10_2023_GuilloValle.Models;
using System.Data.SQLite;

public class TareaRepository : ITareaRepository
{   

    private string cadenaConexion = "Data Source=db/Kanban.db;Cache=Shared";


     public List<Tarea> GetAllTareas(){

            var queryString = @"SELECT * FROM Tareas;";
            List<Tarea> Tareas = new List<Tarea>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(queryString, connection);
                connection.Open();
            
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tarea = new Tarea();
                        tarea.Id = Convert.ToInt32(reader["id"]);
                        tarea.IdUsuarioAsingnado = Convert.ToInt32(reader["id_usuario_asignado"]);
                        tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                        tarea.Nombre = reader["Nombre"].ToString();
                        tarea.Descripcion = reader["descripcion"].ToString();
                        tarea.Color = reader["color"].ToString();
                        tarea.Estado = (Estado)Convert.ToInt32(reader["estado"]);
                        Tareas.Add(tarea);
                    }
                }
                connection.Close();
            }
            return Tareas;
    }





    public Tarea GetTareaById(int id){
        
            var queryString = @"SELECT * FROM Tareas WHERE id = @idTarea;";
            Tarea Tarea = new Tarea();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(queryString, connection);
                command.Parameters.Add(new SQLiteParameter("@idTarea", id));
                connection.Open();
            
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {                     
                        Tarea.Id = Convert.ToInt32(reader["id"]);
                        Tarea.IdUsuarioAsingnado = Convert.ToInt32(reader["id_usuario_asignado"]);
                        Tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                        Tarea.Nombre = reader["Nombre"].ToString();
                        Tarea.Descripcion = reader["descripcion"].ToString();
                        Tarea.Color = reader["color"].ToString();
                        Tarea.Estado = (Estado)Convert.ToInt32(reader["estado"]);
                        
                    }
                connection.Close();
            }
            return Tarea;

            }
        }

    public List<Tarea> GetAllTareasDeUnUsuario(int idUsuario){

            var queryString = @"SELECT * FROM Tareas WHERE id_usuario_asignado = @idUsuario;";
            List<Tarea> Tareas = new List<Tarea>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(queryString, connection);
                command.Parameters.Add(new SQLiteParameter("@idUsuario", idUsuario));
                connection.Open();
            
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tarea = new Tarea();
                        tarea.Id = Convert.ToInt32(reader["id"]);
                        tarea.IdUsuarioAsingnado = Convert.ToInt32(reader["id_usuario_asignado"]);
                        tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                        tarea.Nombre = reader["Nombre"].ToString();
                        tarea.Descripcion = reader["descripcion"].ToString();
                        tarea.Color = reader["color"].ToString();
                        tarea.Estado = (Estado)Convert.ToInt32(reader["estado"]);
                        Tareas.Add(tarea);
                    }
                }
                connection.Close();
            }
            return Tareas;
    }

    public List<Tarea> GetAllTareasDeUnUsuario1(int idUsuario){

            SQLiteConnection connection = new SQLiteConnection(cadenaConexion);  //Me conecto con la base de datos (en este caso Kanban.db)
            var tareas = new List<Tarea>();
            SQLiteCommand command = connection.CreateCommand();  //creo un comando para poder hacer una consulta SQL
            command.CommandText = "SELECT * FROM Tareas WHERE id_usuario_asignado = @id_usuario_asignado;";
            command.Parameters.Add(new SQLiteParameter("@id_usuario_asignado",idUsuario));    // Lo que esta en @idUsu se reemplaza por lo que esta en id, se usa para evitar inyeccion de sql para no usar {}
            connection.Open();
            using(SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())  //tiene sentido si solo trae un solo usuario la funcion?
                {   
                    var tarea = new Tarea();
                    tarea.Id = Convert.ToInt32(reader["id"]);
                    tarea.IdUsuarioAsingnado = Convert.ToInt32(reader["id_usuario_asignado"]);
                    tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                    tarea.Nombre = reader["Nombre"].ToString();
                    tarea.Descripcion = reader["descripcion"].ToString();
                    tarea.Color = reader["color"].ToString();
                    tarea.Estado = (Estado)Convert.ToInt32(reader["estado"]);
                    tareas.Add(tarea);
                }
            }
            connection.Close();

            return (tareas);
    }

    


    public List<Tarea> GetAllTareasDeUnTablero(int idTablero){
        var queryString = @"SELECT * FROM Tareas WHERE id_tablero = @idTablero;";
        List<Tarea> Tareas = new List<Tarea>();
        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {

            SQLiteCommand command = new SQLiteCommand(queryString, connection);
            command.Parameters.Add(new SQLiteParameter("@idTablero", idTablero));
            connection.Open();
            using(SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var tarea = new Tarea();
                    tarea.Id = Convert.ToInt32(reader["id"]);
                    tarea.IdUsuarioAsingnado = Convert.ToInt32(reader["id_usuario_asignado"]);
                    tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                    tarea.Nombre = reader["Nombre"].ToString();
                    tarea.Descripcion = reader["descripcion"].ToString();
                    tarea.Color = reader["color"].ToString();
                    tarea.Estado = (Estado)Convert.ToInt32(reader["estado"]);
                    Tareas.Add(tarea);
                }

            }
            connection.Close();
        }
        return Tareas;
 
 }

    public List<Tarea> CantidadTareasDeUnEstado(Estado estado1){
        
            var queryString = @"SELECT * FROM Tareas WHERE estado = @estadoElegido;";
            List<Tarea> Tareas = new List<Tarea>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(queryString, connection);
                command.Parameters.Add(new SQLiteParameter("@estadoElegido", estado1));
                connection.Open();
            
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tarea = new Tarea();
                        tarea.Id = Convert.ToInt32(reader["id"]);
                        tarea.IdUsuarioAsingnado = Convert.ToInt32(reader["id_usuario_asignado"]);
                        tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                        tarea.Nombre = reader["Nombre"].ToString();
                        tarea.Descripcion = reader["descripcion"].ToString();
                        tarea.Color = reader["color"].ToString();
                        tarea.Estado = (Estado)Convert.ToInt32(reader["estado"]);
                        Tareas.Add(tarea);
                    }
                }
                connection.Close();
            }
            return Tareas;
    }

    public void CrearNuevaTarea(Tarea tarea){

            var query = $"INSERT INTO Tareas (id_tablero,Nombre,estado,descripcion,color,id_usuario_asignado) VALUES (@id_tablero,@nombre,@estado,@Descp,@color,@id_usu_asignado)";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                //SQLiteCommand command = connection.CreateCommand(); Por que no puedo usar esta linea en bez de la de arriba, linea 62, como uso en ObtenerUsuarioPorId???

                command.Parameters.Add(new SQLiteParameter("@id_tablero", tarea.IdTablero));
                command.Parameters.Add(new SQLiteParameter("@nombre", tarea.Nombre));
                command.Parameters.Add(new SQLiteParameter("@estado", tarea.Estado));
                command.Parameters.Add(new SQLiteParameter("@Descp", tarea.Descripcion));
                command.Parameters.Add(new SQLiteParameter("@color", tarea.Color));
                command.Parameters.Add(new SQLiteParameter("@id_usu_asignado", tarea.IdUsuarioAsingnado));

                command.ExecuteNonQuery();

                connection.Close();   
            }
        
    }

    public void ModificarTarea(Tarea tarea){

         using( SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = connection.CreateCommand();
                // usar AddParameter
                command.CommandText = $"UPDATE Tareas SET id_tablero = @id_tablero, Nombre = @nombre, estado = @estado, descripcion = @Descp, color = @color, id_usuario_asignado = @id_usu_asignado  WHERE id = @idAActualizar;";
                command.Parameters.Add(new SQLiteParameter("@idAActualizar",tarea.Id));
                command.Parameters.Add(new SQLiteParameter("@id_tablero", tarea.IdTablero));
                command.Parameters.Add(new SQLiteParameter("@nombre", tarea.Nombre));
                command.Parameters.Add(new SQLiteParameter("@estado", tarea.Estado));
                command.Parameters.Add(new SQLiteParameter("@Descp", tarea.Descripcion));
                command.Parameters.Add(new SQLiteParameter("@color", tarea.Color));
                command.Parameters.Add(new SQLiteParameter("@id_usu_asignado", tarea.IdUsuarioAsingnado));
                     
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
    }

     public void ModificarEstadoDeTarea(int id,Estado nuevoEstado){

         using( SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = connection.CreateCommand();
                // usar AddParameter
                command.CommandText = $"UPDATE Tareas SET estado = @nuevoEstado  WHERE id = @idAActualizar;";
                command.Parameters.Add(new SQLiteParameter("@idAActualizar",id));
                command.Parameters.Add(new SQLiteParameter("@nuevoEstado", (int)nuevoEstado));
                     
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
    }

     public void EliminarTarea(int id){          
           // usar using
            using( SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = connection.CreateCommand();
                // usar AddParameter
                command.CommandText = $"DELETE FROM Tareas WHERE id = @idAeliminar;";
                command.Parameters.Add(new SQLiteParameter("@idAeliminar",id));    
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            
    }


}