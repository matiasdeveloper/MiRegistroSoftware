using LayerData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CDataTramite
{
    private protected MySqlConnect _mySqlConnect;
    SqlDataReader _read;
    SqlCommand _command;
    DataTable _table;

    public CDataTramite()
    {
        Initialize();
    }

    private protected void Initialize()
    {
        _mySqlConnect = new MySqlConnect();
        _command = new SqlCommand();
    }

    public void InsertTramite()
    {
        string q = @"";

        _command.Connection = _mySqlConnect.OpenConnection();
        _command.CommandText = q;
        _command.CommandType = CommandType.Text;
        _command.ExecuteNonQuery();

        _mySqlConnect.CloseConnection();
    }
    public void UpdateTramite()
    {
        string q = @"";

        _command.Connection = _mySqlConnect.OpenConnection();
        _command.CommandText = q;
        _command.CommandType = CommandType.Text;
        _command.ExecuteNonQuery();

        _mySqlConnect.CloseConnection();
    }
    public void DeleteTramite()
    {
        string q = @"";

        _command.Connection = _mySqlConnect.OpenConnection();
        _command.CommandText = q;
        _command.CommandType = CommandType.Text;
        _command.ExecuteNonQuery();

        _mySqlConnect.CloseConnection();
    }

    public void AddErrorInTramite(int idTramite, string observaciones, int error, int codError)
    {
        string q = @"";

        _command.Connection = _mySqlConnect.OpenConnection();
        _command.CommandText = q;
        _command.CommandType = CommandType.Text;
        _command.ExecuteNonQuery();

        _mySqlConnect.CloseConnection();
    }
    public void AddEtapaInTramite(int idTramite, int idEtapa, int idEmpleado)
    {
        string q = @"";

        _command.Connection = _mySqlConnect.OpenConnection();
        _command.CommandText = q;
        _command.CommandType = CommandType.Text;
        _command.ExecuteNonQuery();

        _mySqlConnect.CloseConnection();
    }

    public DataTable GetTramites(DateTime fechaInicio, DateTime fechaFin)
    {
        string q = @"SELECT T.IdTramite AS ID, T.Dominio AS Dominio, Ct.Nombre AS Categoria, T.Fecha AS Fecha, T.Observaciones AS Observaciones,
		                Et.Nombre AS 'Proceso', P.Nick AS 'Quien Proceso', 
		                (SELECT Et1.Nombre FROM tramite T1 JOIN tramite_proceso Tp1 ON Tp1.IdTramite = T1.IdTramite
			                JOIN etapatramite Et1 ON Et1.IdEtapaTramite = Tp1.IdEtapaTramite WHERE T1.IdTramite = T.IdTramite AND Et1.IdEtapaTramite = '1') AS Inscripcion,
                        (SELECT P2.Nick FROM tramite_proceso Tp2 
		                JOIN empleado E2 ON E2.IdEmpleado = Tp2.FkIdEmpleado
		                JOIN usuario U2 ON U2.IdUsuario = E2.FkIdUsuario
		                JOIN perfil P2 ON P2.IdPerfil = U2.FkIdPerfil
                    WHERE Tp2.IdTramite = T.IdTramite AND Tp2.IdEtapaTramite = 2 LIMIT 1) AS 'Quien Inscribio'
                    FROM tramite T
	                    JOIN categoriatramite Ct ON Ct.IdCategoriaTramite = T.FkIdCategoria
	                    JOIN tramite_proceso Tp ON Tp.IdTramite = T.IdTramite
	                    JOIN etapatramite Et ON Et.IdEtapaTramite = Tp.IdEtapaTramite
	                    JOIN empleado E ON E.IdEmpleado = Tp.FkIdEmpleado
	                    JOIN usuario U ON U.IdUsuario = E.FkIdUsuario
	                    JOIN perfil P ON P.IdPerfil = U.FkIdPerfil
                    GROUP BY T.IdTramite;";

        _command.Connection = _mySqlConnect.OpenConnection();
        _command.CommandText = q;

        _read = _command.ExecuteReader();

        _table.Clear();
        _table.Load(_read);
        _mySqlConnect.CloseConnection();

        return _table;
    }
}
