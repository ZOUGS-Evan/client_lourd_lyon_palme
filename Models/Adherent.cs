using System;
using System.Linq;

namespace LyonPalme.Models
{
    /// <summary>
    /// Table SQL: Adherent(id, nom, prenom, role, dateDeNaissance)
    /// </summary>
    public class Adherent
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Role { get; set; }

        public DateTime? DateDeNaissance { get; set; }

        public string NomComplet
            => string.Join(" ", new[] { Prenom, Nom }.Where(s => !string.IsNullOrWhiteSpace(s)));

        public override string ToString() => NomComplet;
    }
}
