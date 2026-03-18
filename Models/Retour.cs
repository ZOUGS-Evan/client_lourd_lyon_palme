using System;
using LyonPalme.DataAccess;

namespace LyonPalme.Models
{
    /// <summary>
    /// Auteur      : R. Fonseca
    /// Date        : 11/03/2026
    /// Description : Représente la restitution d'un matériel prêté.
    ///               L'enregistrement d'un retour clôture automatiquement
    ///               le prêt associé via le trigger trg_retour_cloture_pret.
    /// </summary>
    public class Retour
    {
        // ── Propriétés ───────────────────────────────────────────────

        public int Id { get; private set; }
        public int IdPret { get; set; }
        public string Etat { get; set; }
        public DateTime DateRetour { get; set; }

        // Données dénormalisées pour affichage
        public string NomAdherent { get; set; }
        public string PrenomAdherent { get; set; }
        public string CodeMateriel { get; set; }

        private readonly DBInterface _db;

        // ── États possibles du matériel au retour ────────────────────

        public static readonly string[] EtatsPossibles =
        {
            "Bon etat",
            "Use",
            "Abime",
            "Hors service"
        };

        // ── Constructeurs ────────────────────────────────────────────

        public Retour()
        {
            _db = new DBInterface();
            DateRetour = DateTime.Today;
            Etat = "Bon etat";
        }

        public Retour(int idPret)
        {
            _db = new DBInterface();
            IdPret = idPret;
            DateRetour = DateTime.Today;
            Etat = "Bon etat";
        }

        // ── Méthodes métier ──────────────────────────────────────────

        /// <summary>
        /// Enregistre ce retour en base.
        /// Calcule l'ID automatiquement.
        /// Le trigger SQL met à jour Pret.dateFin = DateRetour.
        /// Lève une exception si un retour existe déjà pour ce prêt.
        /// </summary>
        public void Enregistrer()
        {
            if (IdPret <= 0)
                throw new ArgumentException("IdPret non renseigné.");
            if (string.IsNullOrEmpty(Etat))
                throw new ArgumentException("L'état du matériel au retour est obligatoire.");

            int nextId = _db.GetNextId("Retour");
            Id = _db.EnregistrerRetour(nextId, IdPret, Etat, DateRetour);
        }

        /// <summary>Retourne une représentation lisible du retour.</summary>
        public override string ToString()
        {
            return string.Format("Retour #{0} — Prêt #{1} / {2} le {3:dd/MM/yyyy} ({4})",
                Id, IdPret, CodeMateriel ?? "?",
                DateRetour, Etat);
        }
    }
}