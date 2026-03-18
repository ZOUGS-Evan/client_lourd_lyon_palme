using System;
using System.Collections.Generic;
using System.Linq;
using LyonPalme.DataAccess;

namespace LyonPalme.Models
{
    /// <summary>
    /// Auteur      : R. Fonseca
    /// Date        : 11/03/2026
    /// Description : Gère la consultation et l'analyse de l'inventaire du stock.
    /// </summary>
    public class Inventaire
    {
        private readonly DBInterface _db;

        public Inventaire()
        {
            _db = new DBInterface();
        }

        // ── Méthodes ─────────────────────────────────────────────────

        /// <summary>
        /// Retourne l'inventaire complet groupé par type et taille/pointure.
        /// </summary>
        public List<InventaireDTO> GetInventaireComplet()
        {
            return _db.GetInventaire();
        }

        /// <summary>
        /// Retourne le nombre total de matériels disponibles (tous types).
        /// </summary>
        public int GetTotalDisponibles()
        {
            List<InventaireDTO> inventaire = _db.GetInventaire();
            int total = 0;
            foreach (InventaireDTO ligne in inventaire)
                total += ligne.Disponibles;
            return total;
        }

        /// <summary>
        /// Retourne le nombre total de matériels actuellement prêtés.
        /// </summary>
        public int GetTotalPretes()
        {
            List<InventaireDTO> inventaire = _db.GetInventaire();
            int total = 0;
            foreach (InventaireDTO ligne in inventaire)
                total += ligne.Pretes;
            return total;
        }

        /// <summary>
        /// Retourne l'inventaire filtré pour un type de matériel donné.
        /// Ex : "Monopalme", "Tuba_frontal", "Combinaison", "Lunette"
        /// </summary>
        public List<InventaireDTO> GetParType(string typeMateriel)
        {
            List<InventaireDTO> inventaire = _db.GetInventaire();
            List<InventaireDTO> resultat = new List<InventaireDTO>();

            foreach (InventaireDTO ligne in inventaire)
            {
                if (string.Equals(ligne.TypeMateriel, typeMateriel,
                                  StringComparison.OrdinalIgnoreCase))
                    resultat.Add(ligne);
            }
            return resultat;
        }

        /// <summary>
        /// Retourne true si au moins un matériel du type donné est disponible.
        /// </summary>
        public bool ADisponibilite(string typeMateriel)
        {
            List<InventaireDTO> lignes = GetParType(typeMateriel);
            foreach (InventaireDTO ligne in lignes)
                if (ligne.Disponibles > 0) return true;
            return false;
        }
    }
}