using System;

namespace LyonPalme.Models
{
    /// <summary>
    /// Modèle métier de "gestion" (paramètres/état global).
    /// </summary>
    public class Gestion
    {
        public int Id { get; set; }

        public DateTime DateMiseAJour { get; set; }

        public string Responsable { get; set; }

        public string Commentaire { get; set; }

        public bool ModeMaintenance { get; set; }
    }
}
