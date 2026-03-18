using System;
using LyonPalme.DataAccess;

namespace LyonPalme.Models
{
    /// <summary>
    /// Auteur      : R. Fonseca
    /// Date        : 11/03/2026
    /// Description : Représente un matériel du club (monopalme, tuba, combinaison, lunette).
    ///               Encapsule les données et délègue les opérations CRUD au DBInterface.
    /// </summary>
    public  class Materiel
    {
        // ── Propriétés ───────────────────────────────────────────────

        public int    Id               { get; private set; }
        public string Code             { get; set; }
        public string Marque           { get; set; }
        public string Etat             { get; set; }
        public string TypeMateriel     { get; private set; }
        public string TailleOuPointure { get; set; }
        public string Materiaux        { get; set; }   // Monopalme uniquement
        public string TenuSaison       { get; set; }   // Combinaison uniquement
        public string Disponibilite    { get; private set; }
        public int    NbPretsEnCours   { get; private set; }

        // ── Référence DBInterface ────────────────────────────────────

        private readonly DBInterface _db;

        // ── Constructeurs ────────────────────────────────────────────

        public Materiel()
        {
            _db = new DBInterface();
        }

        /// <summary>Construit un Materiel depuis un DTO (issu de la BDD).</summary>
        public Materiel(MaterielDTO dto)
        {
            _db              = new DBInterface();
            Id               = dto.Id;
            Code             = dto.Code;
            Marque           = dto.Marque;
            Etat             = dto.Etat;
            TypeMateriel     = dto.TypeMateriel;
            TailleOuPointure = dto.TailleOuPointure;
            Materiaux        = dto.Materiaux;
            TenuSaison       = dto.TenuSaison;
            Disponibilite    = dto.Disponibilite;
            NbPretsEnCours   = dto.NbPretsEnCours;
        }

        // ── Méthodes métier ──────────────────────────────────────────

        /// <summary>
        /// Indique si le matériel est actuellement disponible au prêt.
        /// </summary>
        public bool EstDisponible()
        {
            return string.Equals(Disponibilite, "Disponible",
                                 StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Indique si le matériel est hors service.
        /// </summary>
        public bool EstHorsService()
        {
            return string.Equals(Etat, "Hors service",
                                 StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Ajoute ce matériel en base. Calcule l'ID automatiquement.
        /// </summary>
        /// <exception cref="Exception">Si le type est invalide ou le code déjà existant.</exception>
        public void Ajouter()
        {
            int nextId = _db.GetNextId("Materiel");

            int? pointure = null;
            if (!string.IsNullOrEmpty(TailleOuPointure) &&
                string.Equals(TypeMateriel, "Monopalme", StringComparison.OrdinalIgnoreCase))
            {
                if (int.TryParse(TailleOuPointure, out int p))
                    pointure = p;
            }

            string taille = string.Equals(TypeMateriel, "Monopalme",
                                           StringComparison.OrdinalIgnoreCase)
                            ? null : TailleOuPointure;

            Id = _db.AjouterMateriel(nextId, Code, Marque, Etat, TypeMateriel,
                                     pointure, Materiaux, taille, TenuSaison);
        }

        /// <summary>
        /// Modifie ce matériel en base.
        /// </summary>
        public void Modifier()
        {
            int? pointure = null;
            string taille = null;

            if (string.Equals(TypeMateriel, "Monopalme", StringComparison.OrdinalIgnoreCase))
            {
                if (int.TryParse(TailleOuPointure, out int p))
                    pointure = p;
            }
            else
            {
                taille = TailleOuPointure;
            }

            _db.ModifierMateriel(Id, Code, Marque, Etat,
                                 pointure, Materiaux, taille, TenuSaison);
        }

        /// <summary>
        /// Supprime ce matériel de la base.
        /// Lève une exception si le matériel est actuellement prêté.
        /// </summary>
        public void Supprimer()
        {
            if (!EstDisponible())
                throw new InvalidOperationException(
                    "Impossible de supprimer le matériel " + Code +
                    " : il est actuellement prêté.");

            _db.SupprimerMateriel(Id);
        }

        /// <summary>
        /// Recharge les données de ce matériel depuis la base.
        /// </summary>
        public void Rafraichir()
        {
            MaterielDTO dto = _db.GetDetailsMateriel(Id);
            if (dto == null)
                throw new Exception("Matériel introuvable (id=" + Id + ").");

            Code             = dto.Code;
            Marque           = dto.Marque;
            Etat             = dto.Etat;
            TypeMateriel     = dto.TypeMateriel;
            TailleOuPointure = dto.TailleOuPointure;
            Materiaux        = dto.Materiaux;
            TenuSaison       = dto.TenuSaison;
            Disponibilite    = dto.Disponibilite;
            NbPretsEnCours   = dto.NbPretsEnCours;
        }

        /// <summary>Retourne une représentation lisible du matériel.</summary>
        public override string ToString()
        {
            return string.Format("[{0}] {1} - {2} ({3}) — {4}",
                Code, TypeMateriel, Marque,
                TailleOuPointure ?? "—",
                Disponibilite ?? Etat);
        }
    }
}
