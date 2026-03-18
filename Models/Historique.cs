using System;

namespace LyonPalme.Models
{
    /// <summary>
    /// Trace un événement métier (audit léger).
    /// </summary>
    public class Historique
    {
        public int Id { get; set; }

        public DateTime DateEvenement { get; set; }

        public string TypeEvenement { get; set; }

        public string Message { get; set; }

        /// <summary>
        /// Identifiant de l'entité concernée (ex: MaterielId/PretId...), si applicable.
        /// </summary>
        public int? EntiteId { get; set; }

        public string Auteur { get; set; }
    }
}
