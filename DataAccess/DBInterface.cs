using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using LyonPalme.Tools;

namespace LyonPalme.DataAccess
{
    // ================================================================
    // DBInterface.cs
    // Auteur      : R. Fonseca
    // Date        : 11/03/2026
    // Description : Couche d'accès aux données — classe 100 % statique.
    //               Toutes les interactions avec SQL Server passent
    //               par cette classe via des procédures stockées.
    //               Appel : DBInterface.NomDeLaMethode(...)
    // ================================================================

    // ── DTOs ─────────────────────────────────────────────────────────

    public class MaterielDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        // Maintenant stocke l'ID de la marque (clé étrangère)
        public int Marque { get; set; }
        public string Etat { get; set; }
        public string TypeMateriel { get; set; }
        public string TailleOuPointure { get; set; }
        public string Materiaux { get; set; }   // Monopalme
        public string TenuSaison { get; set; }   // Combinaison
        public string Disponibilite { get; set; }
        public int NbPretsEnCours { get; set; }
    }

    public class PretEnCoursDTO
    {
        public int IdPret { get; set; }
        public string Code { get; set; }
        public string Marque { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public DateTime? DateRetour { get; set; }
        public int JoursEnPret { get; set; }
    }

    public class HistoriqueDTO
    {
        public int IdPret { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Code { get; set; }
        public string Marque { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public DateTime? DateRetour { get; set; }
        public string EtatRetour { get; set; }
    }

    public class RetardDTO
    {
        public int IdPret { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int IdMateriel { get; set; }
        public string Code { get; set; }
        public string Marque { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public DateTime? DateRetour { get; set; }
        public int JoursDepuisDebut { get; set; }
        public int JoursRetard { get; set; }
    }

    public class InventaireDTO
    {
        public string TypeMateriel { get; set; }
        public string TailleOuPointure { get; set; }
        public int Total { get; set; }
        public int Disponibles { get; set; }
        public int Pretes { get; set; }
    }

    public class AdherentDTO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Role { get; set; }
        public DateTime DateDeNaissance { get; set; }
    }

    public class UtilisateurDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
    }

    public class MarqueDTO
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
    }

    // ── DBInterface (classe statique) ────────────────────────────────

    public static class DBInterface
    {
        // ── Helpers privés ───────────────────────────────────────────

        /// <summary>
        /// Ouvre une connexion via le singleton Connection.
        /// Lève une exception si la connexion échoue.
        /// </summary>
        private static SqlConnection OpenConnection()
        {
            SqlConnection conn = Connection.getInstance().GetConnection();
            if (conn == null)
                throw new Exception("Impossible d'établir la connexion à la base de données.");
            return conn;
        }

        /// <summary>Crée une SqlCommand de type procédure stockée.</summary>
        private static SqlCommand Proc(SqlConnection conn, string nomProc)
        {
            return new SqlCommand(nomProc, conn)
            {
                CommandType = CommandType.StoredProcedure
            };
        }

        /// <summary>Paramètre nullable : passe DBNull si la valeur est null.</summary>
        private static SqlParameter Nullable(string nom, object valeur, SqlDbType type)
        {
            return new SqlParameter(nom, type)
            {
                Value = valeur ?? (object)DBNull.Value
            };
        }

        private static string NullStr(SqlDataReader r, string col)
        {
            int o = r.GetOrdinal(col);
            return r.IsDBNull(o) ? null : r.GetString(o);
        }

        private static DateTime? NullDate(SqlDataReader r, string col)
        {
            int o = r.GetOrdinal(col);
            return r.IsDBNull(o) ? (DateTime?)null : r.GetDateTime(o);
        }

        private static bool HasCol(SqlDataReader r, string col)
        {
            for (int i = 0; i < r.FieldCount; i++)
                if (string.Equals(r.GetName(i), col, StringComparison.OrdinalIgnoreCase))
                    return true;
            return false;
        }

        private static string GetLogPath()
        {
            string logPath = System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "Logs", "logerror.txt");
            string logDir = System.IO.Path.GetDirectoryName(logPath);
            if (!System.IO.Directory.Exists(logDir))
                System.IO.Directory.CreateDirectory(logDir);
            return logPath;
        }

        private static void LogErreur(string message)
        {
            try
            {
                using (StreamWriter w = File.AppendText(GetLogPath()))
                    Log.WriteLog(message, w);
            }
            catch { /* Ne pas lever d'exception dans le gestionnaire d'erreurs */ }
        }

        // ── Marques ─────────────────────────────────────────────────

        /// <summary>
        /// Retourne le libellé d'une marque à partir de son id.
        /// </summary>
        public static string GetMarqueLibelle(int id)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                using (SqlCommand cmd = new SqlCommand("SELECT libelle FROM Marque WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    object o = cmd.ExecuteScalar();
                    return (o == null || o == DBNull.Value) ? string.Empty : o.ToString();
                }
            }
            catch (Exception ex)
            {
                LogErreur("DBInterface.GetMarqueLibelle : " + ex.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// Recherche l'id d'une marque à partir de son libellé.
        /// Retourne null si introuvable.
        /// </summary>
        public static int? GetMarqueIdByLibelle(string libelle)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                using (SqlCommand cmd = new SqlCommand("SELECT id FROM Marque WHERE libelle = @libelle", conn))
                {
                    cmd.Parameters.AddWithValue("@libelle", libelle ?? string.Empty);
                    object o = cmd.ExecuteScalar();
                    return (o == null || o == DBNull.Value) ? (int?)null : Convert.ToInt32(o);
                }
            }
            catch (Exception ex)
            {
                LogErreur("DBInterface.GetMarqueIdByLibelle : " + ex.Message);
                return null;
            }
        }

        // ── CRUD Marques via procédures stockées ────────────────────

        /// <summary>
        /// Retourne la liste complète des marques (procédure sp_GetMarquesMateriel).
        /// </summary>
        public static List<MarqueDTO> GetMarques()
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                using (SqlCommand cmd = Proc(conn, "sp_GetMarquesMateriel"))
                {
                    List<MarqueDTO> list = new List<MarqueDTO>();
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new MarqueDTO
                            {
                                Id = r.GetInt32(r.GetOrdinal("id")),
                                Libelle = r.GetString(r.GetOrdinal("libelle"))
                            });
                        }
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                LogErreur("DBInterface.GetMarques : " + ex.Message);
                return new List<MarqueDTO>();
            }
        }

        /// <summary>
        /// Ajoute une marque via procédure stockée sp_AjouterMarque.
        /// Retourne l'id créé.
        /// </summary>
        public static int AjouterMarque(int id, string libelle)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                using (SqlCommand cmd = Proc(conn, "sp_AjouterMarque"))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@libelle", libelle);
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (!r.Read()) throw new Exception("sp_AjouterMarque n'a retourné aucun résultat.");
                        return r.GetInt32(r.GetOrdinal("id_cree"));
                    }
                }
            }
            catch (Exception ex)
            {
                LogErreur("DBInterface.AjouterMarque : " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Modifie une marque via procédure stockée sp_ModifierMarque.
        /// </summary>
        public static void ModifierMarque(int id, string libelle)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                using (SqlCommand cmd = Proc(conn, "sp_ModifierMarque"))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@libelle", libelle);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                LogErreur("DBInterface.ModifierMarque : " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Supprime une marque via procédure stockée sp_SupprimerMarque.
        /// </summary>
        public static void SupprimerMarque(int id)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                using (SqlCommand cmd = Proc(conn, "sp_SupprimerMarque"))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                LogErreur("DBInterface.SupprimerMarque : " + ex.Message);
                throw;
            }
        }

        // ── Authentification ─────────────────────────────────────────

        /// <summary>
        /// Authentifie le responsable matériel.
        /// Le mot de passe est passé EN CLAIR : SQL Server applique
        /// HASHBYTES('SHA2_256') avant comparaison. Ne jamais hasher côté client.
        /// </summary>
        /// <returns>L'utilisateur connecté, ou null si identifiants incorrects.</returns>
        public static UtilisateurDTO Authentifier(string login, string motDePasseClair)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                using (SqlCommand cmd = Proc(conn, "sp_authentifier"))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@mdp", motDePasseClair);

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (!r.Read()) return null;
                        return new UtilisateurDTO
                        {
                            Id = r.GetInt32(r.GetOrdinal("id")),
                            Login = r.GetString(r.GetOrdinal("login")),
                            Nom = r.GetString(r.GetOrdinal("nom")),
                            Prenom = r.GetString(r.GetOrdinal("prenom"))
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                LogErreur("DBInterface.Authentifier : " + ex.Message);
                return null;
            }
        }

        // ── Gestion des IDs ──────────────────────────────────────────

        /// <summary>
        /// Retourne MAX(id)+1 pour une table donnée.
        /// Les PKs sont sans IDENTITY : appeler avant chaque insertion.
        /// Tables valides : Materiel, Adherent, Pret, Retour.
        /// </summary>
        public static int GetNextId(string nomTable)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                using (SqlCommand cmd = Proc(conn, "sp_next_id"))
                {
                    cmd.Parameters.AddWithValue("@table_name", nomTable);
                    SqlParameter p = new SqlParameter("@next_id", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(p);
                    cmd.ExecuteNonQuery();
                    return (int)p.Value;
                }
            }
            catch (Exception ex)
            {
                LogErreur("DBInterface.GetNextId(" + nomTable + ") : " + ex.Message);
                throw;
            }
        }

        // ── Stock ────────────────────────────────────────────────────

        /// <summary>Retourne tout le stock avec disponibilité.</summary>
        public static List<MaterielDTO> GetStock()
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                using (SqlCommand cmd = Proc(conn, "sp_get_stock"))
                {
                    List<MaterielDTO> list = new List<MaterielDTO>();
                    using (SqlDataReader r = cmd.ExecuteReader())
                        while (r.Read()) list.Add(MapMateriel(r));
                    return list;
                }
            }
            catch (Exception ex)
            {
                LogErreur("DBInterface.GetStock : " + ex.Message);
                return new List<MaterielDTO>();
            }
        }

        /// <summary>Recherche un matériel par code, type ou marque.</summary>
        public static List<MaterielDTO> RechercherMateriel(string recherche)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                using (SqlCommand cmd = Proc(conn, "sp_rechercher_materiel"))
                {
                    cmd.Parameters.AddWithValue("@recherche", recherche);
                    List<MaterielDTO> list = new List<MaterielDTO>();
                    using (SqlDataReader r = cmd.ExecuteReader())
                        while (r.Read()) list.Add(MapMateriel(r));
                    return list;
                }
            }
            catch (Exception ex)
            {
                LogErreur("DBInterface.RechercherMateriel : " + ex.Message);
                return new List<MaterielDTO>();
            }
        }

        /// <summary>Retourne les détails complets d'un matériel.</summary>
        public static MaterielDTO GetDetailsMateriel(int idMateriel)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                using (SqlCommand cmd = Proc(conn, "sp_get_details_materiel"))
                {
                    cmd.Parameters.AddWithValue("@id_materiel", idMateriel);
                    using (SqlDataReader r = cmd.ExecuteReader())
                        return r.Read() ? MapMateriel(r) : null;
                }
            }
            catch (Exception ex)
            {
                LogErreur("DBInterface.GetDetailsMateriel : " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Ajoute un matériel (table mère + spécialisation).
        /// Appeler GetNextId("Materiel") avant.
        /// Pour une Monopalme, materiaux est obligatoire.
        /// </summary>
        public static int AjouterMateriel(int id, string code, int marque, string etat,
                                          string typeMateriel, int? pointure = null,
                                          string materiaux = null, string taille = null,
                                          string tenuSaison = null)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                using (SqlCommand cmd = Proc(conn, "sp_ajouter_materiel"))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters.AddWithValue("@marque", marque);
                    cmd.Parameters.AddWithValue("@etat", etat);
                    cmd.Parameters.AddWithValue("@type_materiel", typeMateriel);
                    cmd.Parameters.Add(Nullable("@pointure", pointure, SqlDbType.Int));
                    cmd.Parameters.Add(Nullable("@materiaux", materiaux, SqlDbType.VarChar));
                    cmd.Parameters.Add(Nullable("@taille", taille, SqlDbType.VarChar));
                    cmd.Parameters.Add(Nullable("@tenu_saison", tenuSaison, SqlDbType.VarChar));

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (!r.Read())
                            throw new Exception("sp_ajouter_materiel n'a retourné aucun résultat.");
                        return r.GetInt32(r.GetOrdinal("id_cree"));
                    }
                }
            }
            catch (Exception ex)
            {
                LogErreur("DBInterface.AjouterMateriel : " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Modifie un matériel existant.
        /// Les champs null dans les tables filles ne sont pas écrasés (ISNULL côté SQL).
        /// </summary>
        public static void ModifierMateriel(int idMateriel, string code, int marque, string etat,
                                            int? pointure = null, string materiaux = null,
                                            string taille = null, string tenuSaison = null)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                using (SqlCommand cmd = Proc(conn, "sp_modifier_materiel"))
                {
                    cmd.Parameters.AddWithValue("@id_materiel", idMateriel);
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters.AddWithValue("@marque", marque);
                    cmd.Parameters.AddWithValue("@etat", etat);
                    cmd.Parameters.Add(Nullable("@pointure", pointure, SqlDbType.Int));
                    cmd.Parameters.Add(Nullable("@materiaux", materiaux, SqlDbType.VarChar));
                    cmd.Parameters.Add(Nullable("@taille", taille, SqlDbType.VarChar));
                    cmd.Parameters.Add(Nullable("@tenu_saison", tenuSaison, SqlDbType.VarChar));
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                LogErreur("DBInterface.ModifierMateriel : " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Supprime un matériel.
        /// Bloqué par trigger si le matériel est actuellement prêté.
        /// ON DELETE CASCADE supprime les tables filles automatiquement.
        /// </summary>
        public static void SupprimerMateriel(int idMateriel)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                using (SqlCommand cmd = Proc(conn, "sp_supprimer_materiel"))
                {
                    cmd.Parameters.AddWithValue("@id_materiel", idMateriel);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                LogErreur("DBInterface.SupprimerMateriel : " + ex.Message);
                throw;
            }
        }

        // ── Inventaire ───────────────────────────────────────────────

        /// <summary>Retourne l'inventaire regroupé par type et taille/pointure.</summary>
        public static List<InventaireDTO> GetInventaire()
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                using (SqlCommand cmd = Proc(conn, "sp_get_inventaire"))
                {
                    List<InventaireDTO> list = new List<InventaireDTO>();
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new InventaireDTO
                            {
                                TypeMateriel = r.GetString(r.GetOrdinal("type_materiel")),
                                TailleOuPointure = NullStr(r, "taille_ou_pointure"),
                                Total = r.GetInt32(r.GetOrdinal("total")),
                                Disponibles = r.GetInt32(r.GetOrdinal("disponibles")),
                                Pretes = r.GetInt32(r.GetOrdinal("pretes"))
                            });
                        }
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                LogErreur("DBInterface.GetInventaire : " + ex.Message);
                return new List<InventaireDTO>();
            }
        }

        // ── Prêts ────────────────────────────────────────────────────

        /// <summary>
        /// Enregistre un prêt.
        /// Appeler GetNextId("Pret") avant.
        /// Disponibilité vérifiée par le trigger empecher_pret_en_double.
        /// dateFin est optionnelle : si renseignée, elle définit la date de retour prévue
        /// et permet de distinguer les vrais retards (dépassement) des prêts sans échéance.
        /// </summary>
        public static int EnregistrerPret(int id, int idMateriel, int idAdherent,
                                          DateTime dateDebut, DateTime? dateFin = null)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                using (SqlCommand cmd = Proc(conn, "sp_enregistrer_pret"))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@id_materiel", idMateriel);
                    cmd.Parameters.AddWithValue("@id_adherent", idAdherent);
                    cmd.Parameters.AddWithValue("@dateDebut", dateDebut.Date);
                    cmd.Parameters.Add(Nullable("@dateFin", dateFin.HasValue ? (object)dateFin.Value.Date : null, SqlDbType.Date));

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (!r.Read())
                            throw new Exception("sp_enregistrer_pret n'a retourné aucun résultat.");
                        return r.GetInt32(r.GetOrdinal("id_pret_cree"));
                    }
                }
            }
            catch (Exception ex)
            {
                LogErreur("DBInterface.EnregistrerPret : " + ex.Message);
                throw;
            }
        }

        /// <summary>Retourne tous les prêts en cours (dateFin IS NULL).</summary>
        public static List<PretEnCoursDTO> GetPretsEnCours()
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                using (SqlCommand cmd = Proc(conn, "sp_get_prets_en_cours"))
                {
                    List<PretEnCoursDTO> list = new List<PretEnCoursDTO>();
                    using (SqlDataReader r = cmd.ExecuteReader())
                        while (r.Read()) list.Add(MapPretEnCours(r));
                    return list;
                }
            }
            catch (Exception ex)
            {
                LogErreur("DBInterface.GetPretsEnCours : " + ex.Message);
                return new List<PretEnCoursDTO>();
            }
        }

        /// <summary>Retourne tous les prêts (passés et en cours) d'un adhérent.</summary>
        public static List<HistoriqueDTO> GetPretsAdherent(int idAdherent)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                using (SqlCommand cmd = Proc(conn, "sp_prets_adherent"))
                {
                    cmd.Parameters.AddWithValue("@id_adherent", idAdherent);
                    List<HistoriqueDTO> list = new List<HistoriqueDTO>();
                    using (SqlDataReader r = cmd.ExecuteReader())
                        while (r.Read()) list.Add(MapHistorique(r));
                    return list;
                }
            }
            catch (Exception ex)
            {
                LogErreur("DBInterface.GetPretsAdherent : " + ex.Message);
                return new List<HistoriqueDTO>();
            }
        }

        // ── Retours ──────────────────────────────────────────────────

        /// <summary>
        /// Enregistre un retour.
        /// Appeler GetNextId("Retour") avant.
        /// Le trigger trg_retour_cloture_pret met Pret.dateFin à jour automatiquement.
        /// </summary>
        public static int EnregistrerRetour(int id, int idPret, string etat, DateTime dateRetour)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                using (SqlCommand cmd = Proc(conn, "sp_enregistrer_retour"))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@id_pret", idPret);
                    cmd.Parameters.AddWithValue("@etat", etat);
                    cmd.Parameters.AddWithValue("@dateRetour", dateRetour.Date);

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (!r.Read())
                            throw new Exception("sp_enregistrer_retour n'a retourné aucun résultat.");
                        return r.GetInt32(r.GetOrdinal("id_retour_cree"));
                    }
                }
            }
            catch (Exception ex)
            {
                LogErreur("DBInterface.EnregistrerRetour : " + ex.Message);
                throw;
            }
        }

        // ── Historique ───────────────────────────────────────────────

        /// <summary>Retourne l'historique complet des prêts d'un matériel.</summary>
        public static List<HistoriqueDTO> GetHistoriqueMateriel(int idMateriel)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                using (SqlCommand cmd = Proc(conn, "sp_get_historique_materiel"))
                {
                    cmd.Parameters.AddWithValue("@id_materiel", idMateriel);
                    List<HistoriqueDTO> list = new List<HistoriqueDTO>();
                    using (SqlDataReader r = cmd.ExecuteReader())
                        while (r.Read()) list.Add(MapHistorique(r));
                    return list;
                }
            }
            catch (Exception ex)
            {
                LogErreur("DBInterface.GetHistoriqueMateriel : " + ex.Message);
                return new List<HistoriqueDTO>();
            }
        }

        // ── Retards ──────────────────────────────────────────────────

        /// <summary>Retourne les prêts en retard (> 30j actifs ou retours tardifs).</summary>
        public static List<RetardDTO> GetRetards()
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                using (SqlCommand cmd = Proc(conn, "sp_get_retards"))
                {
                    List<RetardDTO> list = new List<RetardDTO>();
                    using (SqlDataReader r = cmd.ExecuteReader())
                        while (r.Read()) list.Add(MapRetard(r));
                    return list;
                }
            }
            catch (Exception ex)
            {
                LogErreur("DBInterface.GetRetards : " + ex.Message);
                return new List<RetardDTO>();
            }
        }

        // ── Adhérents ────────────────────────────────────────────────

        /// <summary>Retourne la liste complète des adhérents.</summary>
        public static List<AdherentDTO> GetAdherents()
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                using (SqlCommand cmd = Proc(conn, "sp_get_adherents"))
                {
                    List<AdherentDTO> list = new List<AdherentDTO>();
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new AdherentDTO
                            {
                                Id = r.GetInt32(r.GetOrdinal("id")),
                                Nom = r.GetString(r.GetOrdinal("nom")),
                                Prenom = r.GetString(r.GetOrdinal("prenom")),
                                Role = NullStr(r, "role"),
                                DateDeNaissance = r.GetDateTime(r.GetOrdinal("dateDeNaissance"))
                            });
                        }
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                LogErreur("DBInterface.GetAdherents : " + ex.Message);
                return new List<AdherentDTO>();
            }
        }

        /// <summary>
        /// Ajoute un adhérent.
        /// Appeler GetNextId("Adherent") avant.
        /// La dateDeNaissance est chiffrée côté SQL Server (AES-256).
        /// </summary>
        public static int AjouterAdherent(int id, string nom, string prenom,
                                          string role = null, DateTime? dateDeNaissance = null)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                using (SqlCommand cmd = Proc(conn, "sp_ajouter_adherent"))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nom", nom);
                    cmd.Parameters.AddWithValue("@prenom", prenom);
                    cmd.Parameters.Add(Nullable("@role", role, SqlDbType.VarChar));
                    cmd.Parameters.Add(Nullable("@dateDeNaissance", dateDeNaissance, SqlDbType.Date));

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (!r.Read())
                            throw new Exception("sp_ajouter_adherent n'a retourné aucun résultat.");
                        return r.GetInt32(r.GetOrdinal("id_adherent_cree"));
                    }
                }
            }
            catch (Exception ex)
            {
                LogErreur("DBInterface.AjouterAdherent : " + ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Crée ou met à jour un utilisateur.
        /// Mot de passe EN CLAIR : SQL Server applique SHA-256 via HASHBYTES.
        /// </summary>
        public static void SetUtilisateur(int id, string login, string motDePasseClair,
                                          string nom = null, string prenom = null)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                using (SqlCommand cmd = Proc(conn, "sp_set_utilisateur"))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@mdp", motDePasseClair);
                    cmd.Parameters.Add(Nullable("@nom", nom, SqlDbType.VarChar));
                    cmd.Parameters.Add(Nullable("@prenom", prenom, SqlDbType.VarChar));
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                LogErreur("DBInterface.SetUtilisateur : " + ex.Message);
                throw;
            }
        }

        // ── Mappers privés ───────────────────────────────────────────

        private static MaterielDTO MapMateriel(SqlDataReader r)
        {
            return new MaterielDTO
            {
                Id = r.GetInt32(r.GetOrdinal("id")),
                Code = r.GetString(r.GetOrdinal("code")),
                // Depuis la modification SMMS, la colonne 'marque' dans la vue Materiel
                // est désormais un identifiant (int) référant à la table Marque.
                Marque = r.GetInt32(r.GetOrdinal("marque")),
                Etat = r.GetString(r.GetOrdinal("etat")),
                TypeMateriel = HasCol(r, "type_materiel") ? NullStr(r, "type_materiel") : string.Empty,
                TailleOuPointure = HasCol(r, "taille_ou_pointure") ? NullStr(r, "taille_ou_pointure") : null,
                Materiaux = HasCol(r, "materiaux") ? NullStr(r, "materiaux") : null,
                TenuSaison = HasCol(r, "tenu_saison") ? NullStr(r, "tenu_saison") : null,
                Disponibilite = HasCol(r, "disponibilite") && !r.IsDBNull(r.GetOrdinal("disponibilite"))
                                       ? r.GetString(r.GetOrdinal("disponibilite")) : string.Empty,
                NbPretsEnCours = HasCol(r, "nb_prets_en_cours") && !r.IsDBNull(r.GetOrdinal("nb_prets_en_cours"))
                                       ? r.GetInt32(r.GetOrdinal("nb_prets_en_cours")) : 0
            };
        }

        private static PretEnCoursDTO MapPretEnCours(SqlDataReader r)
        {
            return new PretEnCoursDTO
            {
                IdPret = r.GetInt32(r.GetOrdinal("id_pret")),
                Code = r.GetString(r.GetOrdinal("code")),
                Marque = r.GetString(r.GetOrdinal("marque")),
                Nom = HasCol(r, "nom") ? r.GetString(r.GetOrdinal("nom")) : string.Empty,
                Prenom = HasCol(r, "prenom") ? r.GetString(r.GetOrdinal("prenom")) : string.Empty,
                DateDebut = r.GetDateTime(r.GetOrdinal("dateDebut")),
                DateFin = NullDate(r, "dateFin"),
                DateRetour = NullDate(r, "dateRetour"),
                JoursEnPret = HasCol(r, "jours_en_pret") && !r.IsDBNull(r.GetOrdinal("jours_en_pret"))
                              ? r.GetInt32(r.GetOrdinal("jours_en_pret")) : 0
            };
        }

        private static HistoriqueDTO MapHistorique(SqlDataReader r)
        {
            return new HistoriqueDTO
            {
                IdPret = r.GetInt32(r.GetOrdinal("id_pret")),
                Nom = r.GetString(r.GetOrdinal("nom")),
                Prenom = r.GetString(r.GetOrdinal("prenom")),
                Code = r.GetString(r.GetOrdinal("code")),
                Marque = r.GetString(r.GetOrdinal("marque")),
                DateDebut = r.GetDateTime(r.GetOrdinal("dateDebut")),
                DateFin = NullDate(r, "dateFin"),
                DateRetour = NullDate(r, "dateRetour"),
                EtatRetour = NullStr(r, "etatRetour")
            };
        }

        private static RetardDTO MapRetard(SqlDataReader r)
        {
            return new RetardDTO
            {
                IdPret = r.GetInt32(r.GetOrdinal("id_pret")),
                Nom = r.GetString(r.GetOrdinal("nom")),
                Prenom = r.GetString(r.GetOrdinal("prenom")),
                IdMateriel = r.GetInt32(r.GetOrdinal("id_materiel")),
                Code = r.GetString(r.GetOrdinal("code")),
                Marque = r.GetString(r.GetOrdinal("marque")),
                DateDebut = r.GetDateTime(r.GetOrdinal("dateDebut")),
                DateFin = NullDate(r, "dateFin"),
                DateRetour = NullDate(r, "dateRetour"),
                JoursDepuisDebut = r.GetInt32(r.GetOrdinal("jours_depuis_debut")),
                JoursRetard = r.GetInt32(r.GetOrdinal("jours_retard"))
            };
        }
    }
}