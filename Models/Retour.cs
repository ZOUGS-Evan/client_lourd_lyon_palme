using System;

namespace LyonPalme.Models
{
    /// <summary>
    /// Table SQL: Retour(id, id_pret, etat, dateRetour)
    /// </summary>
    public class Retour
    {
        public int Id { get; set; }

        public int PretId { get; set; }

        public string Etat { get; set; }

        public DateTime DateRetour { get; set; }
    }
}
