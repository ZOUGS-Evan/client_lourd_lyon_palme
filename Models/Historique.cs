using System;
using System.Collections.Generic;
using LyonPalme.DataAccess;

namespace LyonPalme.Models
{
    /// <summary>
    /// Auteur      : R. Fonseca
    /// Date        : 11/03/2026
    /// Description : Gère la consultation de l'historique des prêts
    ///               pour un matériel donné ou un adhérent donné.
    /// </summary>
    public class Historique
    {
        private readonly DBInterface _db;

        public Historique()
        {
            _db = new DBInterface();
        }

        // ── Méthodes ─────────────────────────────────────────────────

        /// <summary>
        /// Retourne l'historique complet des prêts d'un matériel.
        /// </summary>
        /// <param name="idMateriel">ID du matériel concerné.</param>
        public List<HistoriqueDTO> GetParMateriel(int idMateriel)
        {
            if (idMateriel <= 0)
                throw new ArgumentException("idMateriel invalide.");

            return _db.GetHistoriqueMateriel(idMateriel);
        }

        /// <summary>
        /// Retourne tous les prêts (passés et en cours) d'un adhérent.
        /// </summary>
        /// <param name="idAdherent">ID de l'adhérent concerné.</param>
        public List<HistoriqueDTO> GetParAdherent(int idAdherent)
        {
            if (idAdherent <= 0)
                throw new ArgumentException("idAdherent invalide.");

            return _db.GetPretsAdherent(idAdherent);
        }

        /// <summary>
        /// Retourne les prêts en retard :
        /// - prêts actifs depuis plus de 30 jours
        /// - retours effectués après la date de fin prévue
        /// </summary>
        public List<RetardDTO> GetRetards()
        {
            return _db.GetRetards();
        }
    }
}