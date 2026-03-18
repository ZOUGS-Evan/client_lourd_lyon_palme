using System;
using System.Collections.Generic;
using LyonPalme.DataAccess;

namespace LyonPalme.Models
{
    /// <summary>
    /// Auteur      : R. Fonseca
    /// Date        : 11/03/2026
    /// Description : Représente un adhérent du club pouvant emprunter du matériel.
    /// </summary>
    public class Adherent
    {
        // ── Propriétés ───────────────────────────────────────────────

        public int Id { get; private set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Role { get; set; }
        public DateTime DateDeNaissance { get; set; }

        /// <summary>Nom complet formaté : "Nom Prénom".</summary>
        public string NomComplet
        {
            get { return Nom + " " + Prenom; }
        }

        private readonly DBInterface _db;

        // ── Constructeurs ────────────────────────────────────────────

        public Adherent()
        {
            _db = new DBInterface();
        }

        public Adherent(AdherentDTO dto)
        {
            _db = new DBInterface();
            Id = dto.Id;
            Nom = dto.Nom;
            Prenom = dto.Prenom;
            Role = dto.Role;
            DateDeNaissance = dto.DateDeNaissance;
        }

        // ── Méthodes métier ──────────────────────────────────────────

        /// <summary>
        /// Ajoute cet adhérent en base. Calcule l'ID automatiquement.
        /// </summary>
        public void Ajouter()
        {
            int nextId = _db.GetNextId("Adherent");
            Id = _db.AjouterAdherent(nextId, Nom, Prenom, Role, DateDeNaissance);
        }

        /// <summary>
        /// Retourne l'historique de tous les prêts de cet adhérent.
        /// </summary>
        public List<HistoriqueDTO> GetHistoriquePrets()
        {
            return _db.GetPretsAdherent(Id);
        }

        /// <summary>Retourne une représentation lisible de l'adhérent.</summary>
        public override string ToString()
        {
            return string.Format("{0} {1} ({2})", Nom, Prenom, Role ?? "—");
        }
    }
}