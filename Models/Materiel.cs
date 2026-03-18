using System;

namespace LyonPalme.Models
{
    /// <summary>
    /// Table SQL: Materiel(id, code, marque, etat)
    /// 
    /// Note: les tables de spécialisation (Monopalme, Tuba_frontal, Lunette, Combinaison)
    /// sont représentées ici par des champs optionnels dans ce modèle.
    /// </summary>
    public class Materiel
    {
        public int Id { get; set; }

        /// <summary>
        /// Correspond à Materiel.code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Correspond à Materiel.marque
        /// </summary>
        public string Marque { get; set; }

        /// <summary>
        /// Correspond à Materiel.etat
        /// </summary>
        public string Etat { get; set; }

        /// <summary>
        /// Typage métier (dérivé des tables Monopalme/Tuba_frontal/Lunette/Combinaison).
        /// </summary>
        public MaterielType Type { get; set; }

        // --- Champs spécifiques (optionnels) ---

        // Monopalme
        public int? Pointure { get; set; }
        public string Materiaux { get; set; }

        // Tuba_frontal / Combinaison
        public string Taille { get; set; }

        // Combinaison
        public string TenuEnFonctionSaison { get; set; }

        public override string ToString()
            => string.IsNullOrWhiteSpace(Code) ? $"Materiel #{Id}" : $"{Code} ({Marque})";
    }

    public enum MaterielType
    {
        Inconnu = 0,
        Monopalme = 1,
        TubaFrontal = 2,
        Lunette = 3,
        Combinaison = 4
    }
}
