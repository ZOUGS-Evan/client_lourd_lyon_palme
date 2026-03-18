using System;

namespace LyonPalme.Models
{
    /// <summary>
    /// Table SQL: Pret(id, id_materiel, id_adherent, dateDebut, dateFin)
    /// </summary>
    public class Pret
    {
        public int Id { get; set; }

        public int MaterielId { get; set; }

        public int AdherentId { get; set; }

        public DateTime DateDebut { get; set; }

        public DateTime? DateFin { get; set; }

        public bool EstClos => DateFin.HasValue;
    }
}
