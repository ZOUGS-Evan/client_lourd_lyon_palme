using System;

namespace LyonPalme.Models
{
    /// <summary>
    /// Auteur      : Copilot
    /// Date        : 04/06/2026
    /// Description : Représente une marque de matériel.
    /// </summary>
    public class Marque
    {
        // Identifiant (PK) — int NOT NULL
        public int Id { get; private set; }

        // Libellé — varchar(50) NOT NULL (représenté par string côté application)
        public string Libelle { get; set; }

        public Marque() { }

        public Marque(int id, string libelle)
        {
            Id = id;
            Libelle = libelle;
        }

        public override string ToString()
        {
            return Libelle ?? string.Empty;
        }
    }
}
