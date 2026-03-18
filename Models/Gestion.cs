using System;
using System.Collections.Generic;
using LyonPalme.DataAccess;

namespace LyonPalme.Models
{
    /// <summary>
    /// Auteur      : R. Fonseca
    /// Date        : 11/03/2026
    /// Description : Point d'entrée central de la logique métier.
    ///               Fait le lien entre les Forms et les autres Models.
    ///               Gère l'authentification et expose les opérations
    ///               principales de l'application (stock, prêts, retours).
    /// </summary>
    public class Gestion
    {
        // ── Singleton ────────────────────────────────────────────────

        private static Gestion _instance;

        public static Gestion getInstance()
        {
            if (_instance == null)
                _instance = new Gestion();
            return _instance;
        }

        // ── État de session ──────────────────────────────────────────

        /// <summary>Utilisateur actuellement connecté. Null si non connecté.</summary>
        public UtilisateurDTO UtilisateurConnecte { get; private set; }

        /// <summary>Indique si un responsable est actuellement connecté.</summary>
        public bool EstConnecte
        {
            get { return UtilisateurConnecte != null; }
        }

        // ── Références ───────────────────────────────────────────────

        private readonly DBInterface _db;
        public readonly Inventaire Inventaire;
        public readonly Historique Historique;

        // ── Constructeur privé (singleton) ───────────────────────────

        private Gestion()
        {
            _db = new DBInterface();
            Inventaire = new Inventaire();
            Historique = new Historique();
        }

        // ── Authentification ─────────────────────────────────────────

        /// <summary>
        /// Tente de connecter un responsable.
        /// </summary>
        /// <returns>True si les identifiants sont corrects.</returns>
        public bool Connecter(string login, string motDePasse)
        {
            UtilisateurDTO user = _db.Authentifier(login, motDePasse);
            if (user != null)
            {
                UtilisateurConnecte = user;
                return true;
            }
            return false;
        }

        /// <summary>Déconnecte l'utilisateur courant.</summary>
        public void Deconnecter()
        {
            UtilisateurConnecte = null;
        }

        // ── Stock ────────────────────────────────────────────────────

        /// <summary>Retourne tout le stock avec disponibilité.</summary>
        public List<MaterielDTO> GetStock()
        {
            return _db.GetStock();
        }

        /// <summary>Recherche un matériel par code, type ou marque.</summary>
        public List<MaterielDTO> RechercherMateriel(string recherche)
        {
            if (string.IsNullOrWhiteSpace(recherche))
                return GetStock();
            return _db.RechercherMateriel(recherche);
        }

        /// <summary>Retourne les détails d'un matériel.</summary>
        public MaterielDTO GetDetailsMateriel(int idMateriel)
        {
            return _db.GetDetailsMateriel(idMateriel);
        }

        /// <summary>
        /// Ajoute un nouveau matériel via le Model Materiel.
        /// </summary>
        public void AjouterMateriel(Materiel materiel)
        {
            if (materiel == null)
                throw new ArgumentNullException("materiel");
            if (string.IsNullOrWhiteSpace(materiel.Code))
                throw new ArgumentException("Le code du matériel est obligatoire.");
            if (string.IsNullOrWhiteSpace(materiel.TypeMateriel))
                throw new ArgumentException("Le type du matériel est obligatoire.");

            materiel.Ajouter();
        }

        /// <summary>Modifie un matériel existant.</summary>
        public void ModifierMateriel(Materiel materiel)
        {
            if (materiel == null)
                throw new ArgumentNullException("materiel");

            materiel.Modifier();
        }

        /// <summary>Supprime un matériel disponible.</summary>
        public void SupprimerMateriel(Materiel materiel)
        {
            if (materiel == null)
                throw new ArgumentNullException("materiel");

            materiel.Supprimer();
        }

        // ── Prêts ────────────────────────────────────────────────────

        /// <summary>Retourne tous les prêts en cours.</summary>
        public List<PretEnCoursDTO> GetPretsEnCours()
        {
            return _db.GetPretsEnCours();
        }

        /// <summary>
        /// Enregistre un nouveau prêt.
        /// Lève une exception si le matériel est déjà prêté.
        /// </summary>
        public void EnregistrerPret(Pret pret)
        {
            if (pret == null)
                throw new ArgumentNullException("pret");
            if (pret.IdMateriel <= 0)
                throw new ArgumentException("Matériel non sélectionné.");
            if (pret.IdAdherent <= 0)
                throw new ArgumentException("Adhérent non sélectionné.");
            if (pret.DateDebut == DateTime.MinValue)
                throw new ArgumentException("Date de début invalide.");

            pret.Enregistrer();
        }

        // ── Retours ──────────────────────────────────────────────────

        /// <summary>
        /// Enregistre le retour d'un matériel.
        /// Clôture automatiquement le prêt (trigger SQL).
        /// </summary>
        public void EnregistrerRetour(Retour retour)
        {
            if (retour == null)
                throw new ArgumentNullException("retour");
            if (retour.IdPret <= 0)
                throw new ArgumentException("Prêt non sélectionné.");
            if (string.IsNullOrEmpty(retour.Etat))
                throw new ArgumentException("L'état du matériel est obligatoire.");

            retour.Enregistrer();
        }

        // ── Adhérents ────────────────────────────────────────────────

        /// <summary>Retourne la liste de tous les adhérents.</summary>
        public List<AdherentDTO> GetAdherents()
        {
            return _db.GetAdherents();
        }

        /// <summary>Ajoute un adhérent.</summary>
        public void AjouterAdherent(Adherent adherent)
        {
            if (adherent == null)
                throw new ArgumentNullException("adherent");
            if (string.IsNullOrWhiteSpace(adherent.Nom))
                throw new ArgumentException("Le nom est obligatoire.");
            if (string.IsNullOrWhiteSpace(adherent.Prenom))
                throw new ArgumentException("Le prénom est obligatoire.");

            adherent.Ajouter();
        }
    }
}