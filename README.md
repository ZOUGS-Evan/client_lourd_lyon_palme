# LyonPalme — Gestion du matériel

Application desktop Windows Forms (.NET Framework 4.8) pour la gestion des équipements du club de plongée Lyon Palme. Elle permet au responsable matériel de gérer le stock, les prêts, les retours et d'identifier les retards.

---

## Prérequis

- Windows (exécution) / Visual Studio 2019+ ou MSBuild (compilation)
- .NET Framework 4.8
- Accès réseau au serveur SQL Server `192.168.100.236` (base `LPMateriel`)

---

## Configuration

Renseigner les identifiants de base de données dans `App.config` :

```xml
<add name="sqlserver_LPMateriel"
     connectionString="Data Source=192.168.100.236;Initial Catalog=LPMateriel;User ID=<login>;Password=<mdp>"
     providerName="System.Data.SqlClient" />
```

---

## Compilation & lancement

**Visual Studio** : ouvrir `client_lourd_lyonpalme.sln`, puis `Ctrl+F5`.

**MSBuild** :
```
msbuild client_lourd_lyonpalme.sln /p:Configuration=Release
bin\Release\client_lourd_lyonpalme.exe
```

Les logs d'erreurs sont écrits dans `<répertoire exe>\Logs\logerror.txt`.

---

## Fonctionnalités

| Fonctionnalité | Description |
|---|---|
| Connexion sécurisée | Authentification (3 tentatives max) ; hachage SHA-256 côté SQL Server |
| Tableau de bord | Stock, prêts en cours, retards et KPIs en un coup d'œil |
| Gestion du stock | Ajout, modification, suppression de matériel (monopalme, tuba, combinaison, lunette) |
| Prêts | Enregistrement d'un prêt avec date de fin prévue optionnelle |
| Retours | Clôture d'un prêt avec état du matériel au retour |
| Inventaire | Vue agrégée par type et taille/pointure (total / disponibles / prêtés) |
| Alertes retards | Détection des prêts dépassant 30 jours ou leur date de fin prévue |

---

## Architecture

```
Program.cs
└── Forms/ConnexionForm          ← point d'entrée UI
    └── Forms/GestionForm        ← tableau de bord principal
        ├── Forms/MaterielAddForm
        ├── Forms/MaterielEditForm
        ├── Forms/MaterielDetailsForm
        ├── Forms/PretForm
        ├── Forms/RetourForm
        ├── Forms/InventaireForm
        └── Forms/AlertForm

Models/Gestion (singleton)       ← coordinateur métier unique
├── Models/Materiel
├── Models/Pret / Retour / Adherent
├── Models/Inventaire
└── Models/Historique

DataAccess/DBInterface (static)  ← toutes les requêtes SQL (procédures stockées)
DataAccess/Connection (singleton)← SqlConnection partagée
Tools/Log                        ← journalisation fichier
```

Toutes les interactions entre les Forms et la base de données passent par `Gestion.getInstance()` → `DBInterface` → procédures stockées. Il n'y a aucun SQL inline dans le code client.

---

## Diagramme de classes

```mermaid
classDiagram
    %% ── Couche Modèle ────────────────────────────────────────────
    class Gestion {
        <<singleton>>
        -Gestion _instance$
        +UtilisateurDTO UtilisateurConnecte
        +bool EstConnecte
        +Inventaire Inventaire
        +Historique Historique
        +getInstance()$ Gestion
        +Connecter(login, mdp) bool
        +Deconnecter()
        +AjouterMateriel(Materiel)
        +ModifierMateriel(Materiel)
        +SupprimerMateriel(Materiel)
        +EnregistrerPret(Pret)
        +EnregistrerRetour(Retour)
        +AjouterAdherent(Adherent)
    }

    class Materiel {
        +int Id
        +string Code
        +string Marque
        +string Etat
        +string TypeMateriel
        +string TailleOuPointure
        +string Materiaux
        +string TenuSaison
        +string Disponibilite
        +int NbPretsEnCours
        +Ajouter()
        +Modifier()
        +Supprimer()
        +EstDisponible() bool
        +EstHorsService() bool
    }

    class Pret {
        +int Id
        +int IdMateriel
        +int IdAdherent
        +DateTime DateDebut
        +DateTime DateFin
        +bool EstEnCours
        +bool EstEnRetard
        +Enregistrer()
    }

    class Retour {
        +int Id
        +int IdPret
        +string Etat
        +DateTime DateRetour
        +string[] EtatsPossibles$
        +Enregistrer()
    }

    class Adherent {
        +int Id
        +string Nom
        +string Prenom
        +string Role
        +DateTime DateDeNaissance
        +string NomComplet
        +Ajouter()
        +GetHistoriquePrets() List~HistoriqueDTO~
    }

    class Inventaire {
        +GetInventaireComplet() List~InventaireDTO~
    }

    class Historique {
        +GetHistoriqueMateriel(id) List~HistoriqueDTO~
        +GetRetards() List~RetardDTO~
    }

    %% ── Couche DataAccess ────────────────────────────────────────
    class DBInterface {
        <<static>>
        +Authentifier(login, mdp)$ UtilisateurDTO
        +GetNextId(nomTable)$ int
        +GetStock()$ List~MaterielDTO~
        +AjouterMateriel(...)$ int
        +ModifierMateriel(...)$
        +SupprimerMateriel(id)$
        +EnregistrerPret(...)$ int
        +GetPretsEnCours()$ List~PretEnCoursDTO~
        +EnregistrerRetour(...)$ int
        +GetHistoriqueMateriel(id)$ List~HistoriqueDTO~
        +GetRetards()$ List~RetardDTO~
        +GetAdherents()$ List~AdherentDTO~
        +AjouterAdherent(...)$ int
        +GetInventaire()$ List~InventaireDTO~
    }

    class Connection {
        <<singleton>>
        -Connection instance$
        -SqlConnection sqlConnection
        +getInstance()$ Connection
        +GetConnection() SqlConnection
    }

    %% ── DTOs ─────────────────────────────────────────────────────
    class MaterielDTO {
        +int Id
        +string Code
        +string TypeMateriel
        +string Disponibilite
    }

    class PretEnCoursDTO {
        +int IdPret
        +string Nom
        +DateTime DateDebut
        +int JoursEnPret
    }

    class AdherentDTO {
        +int Id
        +string Nom
        +string Prenom
        +string Role
    }

    class UtilisateurDTO {
        +int Id
        +string Login
        +string Nom
        +string Prenom
    }

    class HistoriqueDTO {
        +int IdPret
        +DateTime DateDebut
        +string EtatRetour
    }

    class RetardDTO {
        +int IdPret
        +string Code
        +int JoursRetard
    }

    class InventaireDTO {
        +string TypeMateriel
        +int Total
        +int Disponibles
        +int Pretes
    }

    %% ── Relations ────────────────────────────────────────────────
    Gestion "1" *-- "1" Inventaire : contient
    Gestion "1" *-- "1" Historique : contient
    Gestion ..> Materiel : crée / valide
    Gestion ..> Pret : crée / valide
    Gestion ..> Retour : crée / valide
    Gestion ..> Adherent : crée / valide
    Gestion ..> DBInterface : délègue

    Materiel ..> DBInterface : appelle
    Pret ..> DBInterface : appelle
    Retour ..> DBInterface : appelle
    Adherent ..> DBInterface : appelle
    Inventaire ..> DBInterface : appelle
    Historique ..> DBInterface : appelle

    DBInterface ..> Connection : utilise
    DBInterface ..> MaterielDTO : produit
    DBInterface ..> PretEnCoursDTO : produit
    DBInterface ..> AdherentDTO : produit
    DBInterface ..> UtilisateurDTO : produit
    DBInterface ..> HistoriqueDTO : produit
    DBInterface ..> RetardDTO : produit
    DBInterface ..> InventaireDTO : produit
```

---

## Diagrammes de séquence

### 1 — Authentification

```mermaid
sequenceDiagram
    actor R as Responsable
    participant CF as ConnexionForm
    participant G as Gestion
    participant DB as DBInterface
    participant SQL as SQL Server

    R->>CF: Saisit login + mot de passe
    CF->>G: Connecter(login, mdp)
    G->>DB: Authentifier(login, mdp)
    DB->>SQL: EXEC sp_authentifier<br/>(HASHBYTES SHA-256 côté serveur)
    SQL-->>DB: UtilisateurDTO (ou rien)
    DB-->>G: UtilisateurDTO / null
    alt Identifiants valides
        G-->>CF: true → UtilisateurConnecte défini
        CF->>CF: Ouvre GestionForm
    else Échec (max 3 tentatives)
        G-->>CF: false
        CF-->>R: Message d'erreur / blocage
    end
```

### 2 — Enregistrement d'un prêt

```mermaid
sequenceDiagram
    actor R as Responsable
    participant GF as GestionForm
    participant PF as PretForm
    participant DB as DBInterface
    participant SQL as SQL Server

    R->>GF: Clique "Nouveau prêt"
    GF->>PF: ShowDialog()
    PF->>DB: GetAdherents()
    PF->>DB: GetStock()
    DB->>SQL: sp_get_adherents / sp_get_stock
    SQL-->>DB: listes
    DB-->>PF: adhérents + matériels disponibles

    R->>PF: Sélectionne adhérent, matériel, dates
    PF->>DB: GetNextId("Pret")
    DB->>SQL: sp_next_id
    SQL-->>DB: prochain ID
    PF->>DB: EnregistrerPret(id, idMateriel, idAdherent, dateDebut, dateFin?)
    DB->>SQL: sp_enregistrer_pret
    Note over SQL: Trigger empecher_pret_en_double<br/>bloque si matériel déjà prêté
    SQL-->>DB: id_pret_cree + disponibilité → "Prete"
    DB-->>PF: succès
    PF-->>GF: fermeture dialog
    GF->>DB: GetStock() + GetPretsEnCours()
    GF-->>R: Tableaux rafraîchis
```

### 3 — Enregistrement d'un retour

```mermaid
sequenceDiagram
    actor R as Responsable
    participant GF as GestionForm
    participant RF as RetourForm
    participant DB as DBInterface
    participant SQL as SQL Server

    R->>GF: Clique "Nouveau retour"
    GF->>RF: ShowDialog()
    RF->>DB: GetPretsEnCours()
    DB->>SQL: sp_get_prets_en_cours
    SQL-->>DB: prêts actifs
    DB-->>RF: liste des prêts en cours

    R->>RF: Sélectionne prêt + état du matériel
    RF->>DB: GetNextId("Retour")
    DB->>SQL: sp_next_id
    SQL-->>DB: prochain ID
    RF->>DB: EnregistrerRetour(id, idPret, etat, dateRetour)
    DB->>SQL: sp_enregistrer_retour
    Note over SQL: Trigger trg_retour_cloture_pret<br/>clôture Pret.dateFin<br/>disponibilité → "Disponible"
    SQL-->>DB: id_retour_cree
    DB-->>RF: succès
    RF-->>GF: fermeture dialog
    GF->>DB: GetStock() + GetPretsEnCours() + GetRetards()
    GF-->>R: Tableaux rafraîchis
```
