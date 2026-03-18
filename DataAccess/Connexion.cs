using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using LyonPalme.Tools;

namespace LyonPalme.DataAccess
{
    /// <summary>
    /// Auteur : R. Fonseca
    /// Date de création : 11/03/2026.
    /// Date de modification : 11/03/2026.
    /// Gère la connexion à la base de données, par un singleton (une seule instance d'une classe).
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// Instance SqlConnection : persiste la connexion au serveur.
        /// </summary>
        private static SqlConnection sqlConnection = null;

        /// <summary>
        /// Singleton : instance unique de la classe Connexion.
        /// </summary>
        private static Connection instance;

        /// <summary>
        /// Constructeur privé, pour créer le singleton.
        /// </summary>
        private Connection() { }

        /// <summary>
        /// Obtient le chemin complet du fichier de log et crée le dossier si nécessaire.
        /// </summary>
        private static string GetLogPath()
        {
            string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "logerror.txt");
            string logDir = Path.GetDirectoryName(logPath);
            if (!Directory.Exists(logDir))
                Directory.CreateDirectory(logDir);
            return logPath;
        }

        /// <summary>
        /// Connexion à SQL Server.
        /// </summary>
        /// <returns>Un SqlConnection non null si connexion réussie.</returns>
        public SqlConnection GetConnection()
        {
            string connectionString;
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["sqlserver_lyonpalme"].ConnectionString;

                if (string.IsNullOrEmpty(connectionString))
                {
                    using (StreamWriter w = File.AppendText(GetLogPath()))
                    {
                        Log.WriteLog("Connection : chaîne de connexion introuvable dans App.config", w);
                    }
                    return null;
                }

                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                using (StreamWriter w = File.AppendText(GetLogPath()))
                {
                    Log.WriteLog("Connection : connexion établie avec succès", w);
                }
            }
            catch (SqlException sqlEx)
            {
                using (StreamWriter w = File.AppendText(GetLogPath()))
                {
                    Log.WriteLog("Connection : erreur de connexion au serveur - " + sqlEx.Message + " | Number: " + sqlEx.Number, w);
                }
                return null;
            }
            catch (Exception ex)
            {
                using (StreamWriter w = File.AppendText(GetLogPath()))
                {
                    Log.WriteLog("Connection : exception - " + ex.Message, w);
                }
                return null;
            }
            return sqlConnection;
        }

        /// <summary>
        /// Crée le singleton s'il n'existe pas.
        /// </summary>
        /// <returns>L'instance de Connection</returns>
        public static Connection getInstance()
        {
            if (Connection.instance == null)
                Connection.instance = new Connection();
            return Connection.instance;
        }
    }
}
