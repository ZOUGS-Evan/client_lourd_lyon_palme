using System;
using LyonPalme.DataAccess;

namespace LyonPalme.Models
{
    /// <summary>
    /// Auteur      : R. Fonseca
    /// Date        : 11/03/2026
    /// Description : Représente un prêt de matériel à un adhérent.
    ///               Un prêt est actif tant que dateFin est null.
    /// </summary>
    public class Pret
    {
        // ── Propriétés ───────────────────────────────────────────────

        public int Id { get; private set; }
        public int IdMateriel { get; set; }
        public int IdAdherent { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }   // Date de retour prévue (optionnelle)

        // Données dénormalisées pour affichage (issues de la vue)
        public string NomAdherent { get; set; }
        public string PrenomAdherent { get; set; }
        public string CodeMateriel { get; set; }
        public string MarqueMateriel { get; set; }
        public int JoursEnPret { get; set; }

        /// <summary>Indique si le prêt est toujours en cours (pas encore retourné).</summary>
        public bool EstEnCours => DateFin == null || DateFin > DateTime.Today;

        /// <summary>
        /// Indique si le prêt est en retard :
        /// - Si une date de fin prévue est définie : dépassement de cette date.
        /// - Sinon : plus de 30 jours sans retour (règle par défaut).
        /// </summary>
        public bool EstEnRetard
        {
            get
            {
                if (DateFin.HasValue)
                    return DateTime.Today > DateFin.Value;
                return (DateTime.Today - DateDebut).TotalDays > 30;
            }
        }

        // ── Constructeurs ────────────────────────────────────────────

        public Pret()
        {
            DateDebut = DateTime.Today;
        }

        public Pret(PretEnCoursDTO dto)
        {
            Id = dto.IdPret;
            DateDebut = dto.DateDebut;
            DateFin = dto.DateFin;
            NomAdherent = dto.Nom;
            PrenomAdherent = dto.Prenom;
            CodeMateriel = dto.Code;
            MarqueMateriel = dto.Marque;
            JoursEnPret = dto.JoursEnPret;
        }

        // ── Méthodes métier ──────────────────────────────────────────

        /// <summary>
        /// Enregistre ce prêt en base. Calcule l'ID automatiquement.
        /// Lève une exception si le matériel est déjà prêté (trigger SQL).
        /// </summary>
        public void Enregistrer()
        {
            if (IdMateriel <= 0) throw new ArgumentException("IdMateriel non renseigné.");
            if (IdAdherent <= 0) throw new ArgumentException("IdAdherent non renseigné.");

            int nextId = DBInterface.GetNextId("Pret");
            Id = DBInterface.EnregistrerPret(nextId, IdMateriel, IdAdherent, DateDebut, DateFin);
        }

        public override string ToString()
        {
            return string.Format("Prêt #{0} à {1} {2} / {3} depuis le {4:dd/MM/yyyy}",
                Id, NomAdherent, PrenomAdherent, CodeMateriel, DateDebut);
        }
    }
}