using System.Collections.Generic;
using LyonPalme.DataAccess;

namespace LyonPalme.Models
{
    /// <summary>
    /// Auteur      : R. Fonseca
    /// Date        : 11/03/2026
    /// Description : Fournit la vue inventaire du stock (regroupement par type et taille).
    /// </summary>
    public class Inventaire
    {
        /// <summary>Retourne l'inventaire complet regroupé par type et taille/pointure.</summary>
        public List<InventaireDTO> GetInventaireComplet()
        {
            return DBInterface.GetInventaire();
        }
    }
}