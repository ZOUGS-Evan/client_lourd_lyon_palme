using System;
using System.IO;

namespace LyonPalme.Tools
{
    /// <summary>
    /// Auteur      : R. Fonseca
    /// Date        : 11/03/2026
    /// Description : Utilitaire de journalisation des erreurs et événements.
    /// </summary>
    public static class Log
    {
        /// <summary>
        /// Écrit un message horodaté dans le fichier de log.
        /// </summary>
        public static void WriteLog(string message, StreamWriter writer)
        {
            writer.WriteLine("[{0}] {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), message);
        }
    }
}