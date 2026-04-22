using System.Collections.Generic;
using LyonPalme.DataAccess;

namespace LyonPalme.Models
{
    /// <summary>
    /// Auteur      : R. Fonseca
    /// Date        : 11/03/2026
    /// Description : Fournit l'historique des prêts et la liste des retards.
    /// </summary>
    public class Historique
    {
        /// <summary>Retourne l'historique complet des prêts d'un matériel.</summary>
        public List<HistoriqueDTO> GetHistoriqueMateriel(int idMateriel)
        {
            return DBInterface.GetHistoriqueMateriel(idMateriel);
        }

        /// <summary>Retourne les prêts en retard (actifs > 30j ou retours tardifs).</summary>
        public List<RetardDTO> GetRetards()
        {
            return DBInterface.GetRetards();
        }
    }
}