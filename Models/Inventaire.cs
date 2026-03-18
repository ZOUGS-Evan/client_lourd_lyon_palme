using System;

namespace LyonPalme.Models
{
    /// <summary>
    /// Représente un enregistrement d'inventaire (snapshot) d'un matériel.
    /// </summary>
    public class Inventaire
    {
        public int Id { get; set; }

        public int MaterielId { get; set; }

        public DateTime DateInventaire { get; set; }

        public int QuantiteTheorique { get; set; }

        public int QuantitePhysique { get; set; }

        public string Commentaire { get; set; }

        public int Ecart => QuantitePhysique - QuantiteTheorique;
    }
}
