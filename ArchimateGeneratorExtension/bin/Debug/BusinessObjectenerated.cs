



using System.Collections.Generic;

namespace MyProject
{
	/// <summary>  </summary>
	partial class Aspect {}

	/// <summary> défini une autorisation CRUD pour utilisateur sur une entité ou un élément d'une entité ou une fonction </summary>
	partial class Autorisation {}

	/// <summary> un composant implèmente complètement une fonctionnalité métier ou technique il expose des interfaces d'utilisation pour pouvoir être intégré au sein d'une application il est composé de modules selon leur spécificités techniques </summary>
	partial class Composant {}

	/// <summary>  </summary>
	partial class Contexte_de_session {}

	/// <summary> container d'objets associé à l'utilisateur courant </summary>
	partial class Contexte_utilisateur {}

	/// <summary> template instancié intégrant des données métier est utilisé de manière atomique sans avoir la connaissance de sa structure interne </summary>
	partial class Document {}

	/// <summary> regroupe un ensemble d'objets métier, leurs workflows et leurs services associés, correspondant à une fonctionnalité applicative comme par exemple la prescription. Les domaines fonctionnels ont les propriétés suivantes: - ils sont associés à des autorisations pour des rôles et des utilisateurs - ils définissent des règles de dépendances entre eux: chaque fonctionnalité dépend d'une ou plusieurs autres fonctionnalités - ils servent de connecteurs dans les tools pour définir les dépendances entre tools: un tool est activé en fonction de la fonctionnalité qu'il implémente et charge les tools gérant les fonctionnalités nécessaires. - ils délimitent les schémas de base en terme de contraintes d'intégrité référentielle et de sous-schéma combinable avec d'autres sous-schémas - ils limitent la recherche des données de traitement des services applicatifs associés: en général, un service de traitement métier va charger pour un objet raçine tout les objets connectés du même domaine fonctionnel. Les autres objets nécessaires dans un autre domaine seront chargés dans une autre requête la détermination des domaines fonctionnels peut être complexe. Une approche possible et de rechercher pour une entité du domaine métier de trouver toutes ses entités en relation 1-n ou n-m sur plusieurs niveaux. cette règle pourrait être utilisé de manière automatique dans le cas où l'on veut accéder à une entité qui n'est pas affectée à un domaine métier </summary>
	partial class Domaine_fonctionnel {}

	/// <summary> propriétés communes à toutes les entités métier comme par exemple des champs partagés tel que la clé Id, la date de création (les champs techniques) </summary>
	partial class Entité {}

	/// <summary> état présentant des informations métiers pouvant être imprimé </summary>
	partial class Etat {}

	/// <summary>  </summary>
	partial class Exception {}

	/// <summary>  </summary>
	partial class Exception_technique {}

	/// <summary>  </summary>
	partial class Factory {}

	/// <summary> les fonctionalités techniques sont des classes internes avec moins de contraintes de format que les services métiers (non SOA) elles sont appelables depuis n'importe quel couche applicative elle intègrent un état et peuvent appeler des services (au sens SOA du terme) elles peuvent être implémentées différemment selon l'environnement d'exécution. Par exemple, une fonction de log en local sera différente sur le serveur. </summary>
	partial class Fonctionalité_technique {}

	/// <summary> Une fonctionnalité expose un workflow métier d'un composant métier qui peut être appelée par d'autres fonctionnalités </summary>
	partial class Fonctionnalité {}

	/// <summary> encapsulation d'une machine à état qui défini un ensemble d'état avec un ensemble de traitements associés selon des conditions de déclenchement </summary>
	partial class Machine_à_état {}

	/// <summary> un texte traduisible en plusieurs langues </summary>
	partial class Message {}

	/// <summary> ensemble d'artefacts exécutables assurant une fonctionnalité spécifique d'un composant (en général associé à une couche) un module correspond par exemple à l'ensemble des workflows d'un composant un module dépend d'autres modules d'un même composant un module s'implémente sous la forme d'un ensemble d'assemblies avec leurs dépendances un module peut être réutilisé entre plusieurs composants </summary>
	partial class Module {}

	/// <summary>  </summary>
	partial class Moteur_IOC {}

	/// <summary> permet d'ajouter une information de méta-modèle à n'importe élément, comme par exemple: - une référence à une exigence - une propriété d'un élément qui peut influer l'exécution dans l'infrastructure, comme par exemple un service stateful </summary>
	partial class Métainformation {}

	/// <summary>  </summary>
	partial class Notification {}

	/// <summary> modélise la relation de type 1-1 ou 1-n entre 2 types d'entités est implémenté sous la forme de collection gère le lazy-loading </summary>
	partial class Relation {}

	/// <summary> défini les éléments d'une requête de recherche d'un ensemble de données </summary>
	partial class Requete {}

	/// <summary> regroupe un ensemble d'utilisateurs associés à des domaines métier les droits d'accès sont gérés en fonction des rôles, pas en fonction d'un utilisateur un rôle peut être une extension et/ou une fusion d'autres rôles </summary>
	partial class Role {}

	/// <summary> structure générale d'une règle qui sera spécialisée selon le métier intègre les liens pour gérer des combinaisons de règles </summary>
	partial class Règle {}

	/// <summary> trace intégrant des informations métier </summary>
	partial class Trace {}

	/// <summary>  </summary>
	partial class Transaction {}

	/// <summary> traitement de tout type peut être décomposé en autres tâches peut être déclenchée en traitement de fond, à une heure particulière peut être défini de manière statique par du code ou de manière dynamique par un langage compréhensible par l'utilisateur </summary>
	partial class Tâche {}

	/// <summary> information sur un utilisateur réel un utilisateur est associé à un rôle à un instant donné mais il peut changer de rôle </summary>
	partial class Utilisateur {}

	/// <summary> gestion de contraintes sur des champs implémenté sous la forme d'un attribut associé à un champ peut être combinable entre eux exemple de validateur: champ numérique, champ obligatoire, taille du champ </summary>
	partial class Validateur {}

	/// <summary> verrou d'accès à une ressource ou un objet de manière générale </summary>
	partial class Verrou {}

	/// <summary>  </summary>
	partial class Accéléromètre {}

	/// <summary> une aide contextuelle modélise un élément d'aide (texte) affichable associée à un élément graphique </summary>
	partial class Aide_contextuelle {}

	/// <summary> gère l'ensemble des informations d'aide de l'application, sous la forme d'un dictionnaire de texte peut être associé à un élément graphique que l'utilisateur peut activer </summary>
	partial class Aide_application {}

	/// <summary>  </summary>
	partial class Appareil_photo {}

	/// <summary> propriétés de l'application, ensemble de fonctionnalités exposés sur le client </summary>
	partial class Application {}

	/// <summary>  </summary>
	partial class Application_Web {}

	/// <summary> propriété d'un composant de code s'exécutant sur le poste de travail de l'utilisateur implémenté sous la forme d'un exécutable ou d'une dll (windows) </summary>
	partial class Composant_client {}

	/// <summary> composant graphique container pouvant être associé à un identifiant de contexte </summary>
	partial class Container_graphique {}

	/// <summary> container des objets métier au niveau application </summary>
	partial class Contexte_dapplication {}

	/// <summary> gère le lancement de l'application, avec toutes les problématiques de déploiement </summary>
	partial class Lanceur {}

	/// <summary>  </summary>
	partial class Gesture {}

	/// <summary>  </summary>
	partial class GPS {}

	/// <summary>  </summary>
	partial class Périphérique_mobile {}

	/// <summary> Un tool est un composant de code livrable il correspond à une demande client Il est composé d'un ensemble de composants métier </summary>
	partial class Tool {}

	/// <summary> le tool externe s'exécute dans un espace d'adressage différent de celui du container il peut faire un appel direct aux fonctionnalités du container en passant par un mécanisme de communication externe </summary>
	partial class Tool_externe {}

	/// <summary> structure commune à toutes les vues </summary>
	partial class Vue {}

	/// <summary> composant graphique élémentaire gérant une information </summary>
	partial class Widget {}

	/// <summary> structure partagée par tout les workflows </summary>
	partial class Workflow {}

	/// <summary>  </summary>
	partial class Reconnaissance_vocale {}

	/// <summary> widget dont le traitement est en dehors de l'espace d'adressage de l'application (intégration par COM par exemple) correspond aux composants graphiques existants </summary>
	partial class Widget_externe {}

	/// <summary> vue dont le traitement est en dehors de l'espace d'adressage de l'application (intégration par COM par exemple) correspond aux fenêtres graphiques existants </summary>
	partial class Vue_externe {}

	/// <summary> peripherique pilotable par l'application est associé au poste de travail dans le cas des objets connectés, peut être associé à un composant serveur externe qui récupérera les informations et qui les fournira à l'application sous forme de service (cas de l'utilisation pour le big data): dans ce cas, le périphérique n'apparaît pas comme tel dans l'architecture de l'application a voir: faut-il inclure les périphériques intégrés aux fonctionnalités transverses tel que l'impression au travers de l'imprimante? </summary>
	partial class Périphérique {}

	/// <summary> Objet d'accès au données standard, qui intègre des mécanismes CRUD réutilisables </summary>
	partial class ADO {}

	/// <summary>  </summary>
	partial class Composant_serveur {}

	/// <summary>  </summary>
	partial class Contrat_de_service {}

	/// <summary> gestionnaire de mapping objet<->table </summary>
	partial class ORM {}

	/// <summary> sous-ensemble des entités métier associé à un domaine métier. Sera implémenté sous la forme d'un schéma dans la base de données </summary>
	partial class Schema {}

	/// <summary>  </summary>
	partial class Serveur {}

	/// <summary> service métier un service n'a normalement pas de traitement avec des effets de bord </summary>
	partial class Service {}

	/// <summary> structure standard d'un service CRUD: référence à l'ADO associé... </summary>
	partial class Service_CRUD {}

	/// <summary>  </summary>
	partial class Fichier {}

	/// <summary> données d'une réservation intégrant des liens à toutes les entités associés à cette réservation qui peut être validé (avec ses entités) ou pas </summary>
	partial class Reservation {}

	/// <summary> accès à une ressource partagé avec contrainte, tel qu'un fichier </summary>
	partial class Ressource {}

	/// <summary> une transformation gère un ensemble d'objets métier pivot pour transformer un ensemble d'objets d'entrée en objets de sortie une transformation est un service sans état </summary>
	partial class Transformation {}

	/// <summary> représente l'ensemble des entités en cours de traitement pour gérer un scénario de travail (implémentation du pattern Unit of work) en cas de persistance des données, correspond à la notion de une ou plusieurs sessions dans un ORM cependant, comme un service peut accéder à plusieurs autres services gérant des schémas de données différents, une unité de travail peut gérer plusieurs sessions ORM en même temps. s'implémente avec le pattern repository qui gère chaque espace de persistance https://msdn.microsoft.com/en-us/library/ff649690.aspx </summary>
	partial class Unité_de_travail {}

	/// <summary> document type word </summary>
	partial class Document_texte {}

	/// <summary> modèle de transformation de données métier en document d'un type spécifique </summary>
	partial class Template {}

	/// <summary> document de type tableau Excel </summary>
	partial class Document_tableau {}

	/// <summary> document de type image par exemple une image bmp </summary>
	partial class Image {}

	/// <summary>  </summary>
	partial class Entité_métier {}

	/// <summary>  </summary>
	partial class Exception_métier {}

	/// <summary> défini un type métier avec ses propres contraintes de valeurs </summary>
	partial class Type_valeur_métier {}

	/// <summary> règle métier combinable </summary>
	partial class Règle_métier {}

	/// <summary> container d'entités métiers associé à l'utilisateur courant </summary>
	partial class Contexte_utilisateur_métier {}

	/// <summary>  </summary>
	partial class Contexte_de_session_métier {}

	/// <summary> une classe métier modélisant une structure </summary>
	partial class Classe_métier {}

	/// <summary>  </summary>
	partial class Aspect_métier {}

	/// <summary> un domaine fonctionnel spécifique à un domaine métier particulier </summary>
	partial class Domaine_fonctionnel_métier {}

	/// <summary>  </summary>
	partial class Notification_métier {}

	/// <summary>  </summary>
	partial class Etat_métier {}

	/// <summary>  </summary>
	partial class Tâche_métier {}

	/// <summary>  </summary>
	partial class Application_métier {}

	/// <summary> Un composant métier regroupe un ensemble de workflows métier avec leurs dépendances </summary>
	partial class Composant_client_métier {}

	/// <summary> défini la collection des entités métiers globale spécifique à l'application </summary>
	partial class Contexte_dapplication_métier {}

	/// <summary> Un tool externe regroupe un ensemble de composants métier livrable qui ne s'appuie pas nécessairement sur le framework de développement standard </summary>
	partial class Tool_externe_métier {}

	/// <summary>  </summary>
	partial class Vue_métier {}

	/// <summary>  </summary>
	partial class Widget_métier {}

	/// <summary>  </summary>
	partial class Workflow_métier {}

	/// <summary>  </summary>
	partial class Widget_externe_métier {}

	/// <summary>  </summary>
	partial class Vue_externe_métier {}

	/// <summary> Un tool regroupe un ensemble de composants métier livrable </summary>
	partial class Tool_métier {}

	/// <summary> classe de persistance spécifique à une entité métier implémente les fonctions de persistance associée à une entité métier et à ses entités connectées via des jointures </summary>
	partial class ADO_métier {}

	/// <summary>  </summary>
	partial class Composant_serveur_métier {}

	/// <summary>  </summary>
	partial class Contrat_de_service_métier {}

	/// <summary> schéma de la base de données associé à un ensemble d'objets métier </summary>
	partial class Schéma_métier {}

	/// <summary> un serveur métier regroupe l'ensemble des services métier associé à un ou plusieurs schémas </summary>
	partial class Serveur_métier {}

	/// <summary> un service métier pilotant des traitements de persistance service à effet de bord pour les traitements CUD n'appelle pas d'autres services mais peut appeler plusieurs traitements de persistance </summary>
	partial class Service_CRUD_métier {}

	/// <summary> un service définissant essentiellement des traitements métiers sur plusieurs entités métier peut appeler des services CRUD </summary>
	partial class Service_métier {}

	/// <summary> une transformation métier s'appuie sur un ensemble d'entités métier qui sont impactés par la transformation une transformation permet par exemple d'implémenter un traitement d'import, qui est une association entre une ou plusieurs transformations et une ou plusieurs liaisons </summary>
	partial class Transformation_métier {}

	/// <summary>  </summary>
	partial class ADO_générique {}

	/// <summary> informations associées à une alerte une alerte est crée lors de la réception de notification validant certains critères </summary>
	partial class Alerte {}

	/// <summary> informations associés à une application externe: localisation (url...), description, version associée, etc... </summary>
	partial class Application_externe {}

	/// <summary> container de résultats de méthodes temporaire </summary>
	partial class Cache_appel {}

	/// <summary> container d'objets métier temporaire </summary>
	partial class Cache_dobjet {}

	/// <summary> entreprise utilisatrice de l'application </summary>
	partial class Client {}

	/// <summary>  </summary>
	partial class Deployeur {}

	/// <summary> défini le sous-ensemble du schéma de données selon différents critères: - date de l'extraction - ensemble des objets métiers (schéma) - critères de recherche additionnel (par exemple, nom commençant par P) est associé aux traitements d'import-export, de synchronisation </summary>
	partial class Extraction {}

	/// <summary> ensemble de fonctionnalités autorisés pour un client avec leur nombre d'utilisateurs simultanés, le nombre d'opérations, </summary>
	partial class Licence {}

	/// <summary>  </summary>
	partial class Périphérique_technique {}

	/// <summary>  </summary>
	partial class Scénario_A_COMPLETER {}

	/// <summary>  </summary>
	partial class Service_générique {}

	/// <summary>  </summary>
	partial class Tool_externe {}

	/// <summary> traitement géré par le planificateur associe un contexte de données, un contexte d'exéctution (quand, où) un contexte de traitement (traitement à lancer) peut être suivi </summary>
	partial class Tâche {}

	/// <summary> mémorise les dépendances de composants associés à une version applicative </summary>
	partial class Version {}

	/// <summary> vue du container </summary>
	partial class Vue_applicatif {}

	/// <summary> container générique de composants graphiques peut contenir un nombre arbitraire de composants de tout type </summary>
	partial class Vue_générique {}

	/// <summary>  </summary>
	partial class Workflow_générique {}

	/// <summary>  </summary>
	partial class Tool_externe_métier {}

	/// <summary>  </summary>
	partial class Alerte_métier {}

	/// <summary>  </summary>
	partial class Tâche_métier {}

	/// <summary>  </summary>
	partial class Péripherique_spécifique {}

	/// <summary> défini un service générique construit par l'utilisateur </summary>
	partial class Scénario_métier {}

	/// <summary>  </summary>
	partial class ADO_Hapicare {}

	/// <summary>  </summary>
	partial class ADO_Nhibernate {}

	/// <summary>  </summary>
	partial class Application_Hapicare {}

	/// <summary>  </summary>
	partial class Aspects_Hapicare {}

	/// <summary>  </summary>
	partial class Entités_Hapicare {}

	/// <summary>  </summary>
	partial class Exceptions_Hapicare {}

	/// <summary>  </summary>
	partial class Services_CRUD_Hapicare {}

	/// <summary>  </summary>
	partial class Services_Métier_Hapicare {}

	/// <summary>  </summary>
	partial class Vue_web {}

	/// <summary>  </summary>
	partial class Vues_Hapicare {}

	/// <summary>  </summary>
	partial class Workflows_Hapicare {}

	/// <summary> Un élément passif d'information qui est pertinent d'un point de vue métier exemple: patient </summary>
	partial class Entité_métier {}

	/// <summary>  </summary>
	partial class EntitéEntité_métier {}

    partial class Application_métier
    {
		//private static string type_ = "BusinessObject";
		List<Composant_client_métier> composant_client_métier_ = 
			new List<Composant_client_métier>();
		public List<Composant_client_métier> Composant_client_métier_ { get => composant_client_métier_; set => composant_client_métier_ = value; }

		List<Tool_externe_métier> tool_externe_métier_ = 
			new List<Tool_externe_métier>();
		public List<Tool_externe_métier> Tool_externe_métier_ { get => tool_externe_métier_; set => tool_externe_métier_ = value; }

	}

    partial class Vue_métier
    {
		//private static string type_ = "BusinessObject";
		List<Container_graphique> container_graphique_ = 
			new List<Container_graphique>();
		public List<Container_graphique> Container_graphique_ { get => container_graphique_; set => container_graphique_ = value; }

	}

    partial class Domaine_fonctionnel_métier
    {
		//private static string type_ = "BusinessObject";
		List<Entité_métier> entité_métier_ = 
			new List<Entité_métier>();
		public List<Entité_métier> Entité_métier_ { get => entité_métier_; set => entité_métier_ = value; }

	}

    partial class Composant_client_métier
    {
		//private static string type_ = "BusinessObject";
		List<Fonctionnalité> fonctionnalité_ = 
			new List<Fonctionnalité>();
		public List<Fonctionnalité> Fonctionnalité_ { get => fonctionnalité_; set => fonctionnalité_ = value; }

	}

    partial class Serveur_métier
    {
		//private static string type_ = "BusinessObject";
		List<Composant_serveur_métier> composant_serveur_métier_ = 
			new List<Composant_serveur_métier>();
		public List<Composant_serveur_métier> Composant_serveur_métier_ { get => composant_serveur_métier_; set => composant_serveur_métier_ = value; }

	}

    partial class Entité_métier
    {
		//private static string type_ = "BusinessObject";
		List<Relation> relation_ = 
			new List<Relation>();
		public List<Relation> Relation_ { get => relation_; set => relation_ = value; }

	}

    partial class Aide_application
    {
		//private static string type_ = "BusinessObject";
		List<Aide_contextuelle> aide_contextuelle_ = 
			new List<Aide_contextuelle>();
		public List<Aide_contextuelle> Aide_contextuelle_ { get => aide_contextuelle_; set => aide_contextuelle_ = value; }

	}

    partial class Lanceur
    {
		//private static string type_ = "BusinessObject";
		List<Composant_client> composant_client_ = 
			new List<Composant_client>();
		public List<Composant_client> Composant_client_ { get => composant_client_; set => composant_client_ = value; }

	}

    partial class Client
    {
		//private static string type_ = "BusinessObject";
		List<Utilisateur> utilisateur_ = 
			new List<Utilisateur>();
		public List<Utilisateur> Utilisateur_ { get => utilisateur_; set => utilisateur_ = value; }

	}

    partial class Container_graphique
    {
		//private static string type_ = "BusinessObject";
		List<Widget_externe> widget_externe_ = 
			new List<Widget_externe>();
		public List<Widget_externe> Widget_externe_ { get => widget_externe_; set => widget_externe_ = value; }

		List<Vue_externe> vue_externe_ = 
			new List<Vue_externe>();
		public List<Vue_externe> Vue_externe_ { get => vue_externe_; set => vue_externe_ = value; }

	}

    partial class Vue_externe
    {
		//private static string type_ = "BusinessObject";
		List<Widget_externe> widget_externe_ = 
			new List<Widget_externe>();
		public List<Widget_externe> Widget_externe_ { get => widget_externe_; set => widget_externe_ = value; }

	}

    partial class Vue_externe_métier
    {
		//private static string type_ = "BusinessObject";
		List<Widget_externe_métier> widget_externe_métier_ = 
			new List<Widget_externe_métier>();
		public List<Widget_externe_métier> Widget_externe_métier_ { get => widget_externe_métier_; set => widget_externe_métier_ = value; }

	}


	partial class GPS : Périphérique_mobile {}
	partial class Exception_technique : Exception {}
	partial class Exception_métier : Exception {}
	partial class Tool_externe : Tool {}
	partial class Tool_externe : Tool {}
	partial class Composant_client : Composant {}
	partial class Tool : Composant_client {}
	partial class Composant_serveur : Composant {}
	partial class Reservation : Transaction {}
	partial class Appareil_photo : Périphérique_mobile {}
	partial class Gesture : Périphérique_mobile {}
	partial class Accéléromètre : Périphérique_mobile {}
	partial class Reconnaissance_vocale : Périphérique_mobile {}
	partial class Service_métier : Service {}
	partial class Workflow_métier : Workflow {}
	partial class Workflows_Hapicare : Workflow {}
	partial class Vue_web : Vue {}
	partial class Vues_Hapicare : Vue_web {}
	partial class Services_Métier_Hapicare : Service {}
	partial class ADO_Hapicare : ADO_Nhibernate {}
	partial class ADO_Nhibernate : ADO {}
	partial class Services_CRUD_Hapicare : Service_CRUD {}
	partial class Entités_Hapicare : Entité_métier {}
	partial class Exceptions_Hapicare : Exception_métier {}
	partial class Aspects_Hapicare : Aspect {}
	partial class Application_Hapicare : Application_Web {}
	partial class Application_Web : Application {}
	partial class Application_métier : Application {}
	partial class Tool_externe_métier : Tool_externe {}
	partial class Composant_client_métier : Composant_client {}
	partial class Contexte_dapplication_métier : Contexte_dapplication {}
	partial class ADO_métier : ADO {}
	partial class Schéma_métier : Schema {}
	partial class Entité_métier : Entité {}
	partial class Vue_métier : Vue {}
	partial class Service_CRUD : Service {}
	partial class Service_CRUD_métier : Service_CRUD {}
	partial class Règle_métier : Règle {}
	partial class Contexte_utilisateur_métier : Contexte_utilisateur {}
	partial class Contexte_de_session_métier : Contexte_de_session {}
	partial class Type_valeur_métier : Classe_métier {}
	partial class Vue_générique : Vue {}
	partial class Vue_applicatif : Vue {}
	partial class Domaine_fonctionnel_métier : Domaine_fonctionnel {}
	partial class Contrat_de_service_métier : Contrat_de_service {}
	partial class Aspect_métier : Aspect {}
	partial class Tool_externe_métier : Tool_externe {}
	partial class Alerte_métier : Alerte {}
	partial class Notification_métier : Notification {}
	partial class Widget_métier : Widget {}
	partial class Serveur_métier : Serveur {}
	partial class Composant_serveur_métier : Composant_serveur {}
	partial class Tâche_métier : Tâche {}
	partial class Péripherique_spécifique : Périphérique_technique {}
	partial class Scénario_métier : Scénario_A_COMPLETER {}
	partial class Etat_métier : Etat {}
	partial class Widget_externe_métier : Widget_externe {}
	partial class Transformation_métier : Transformation {}
	partial class Vue_externe_métier : Vue_externe {}
	partial class Transformation : Service {}
	partial class Périphérique_mobile : Périphérique {}
	partial class Tool_métier : Tool {}
	partial class Tâche_métier : Tâche {}
	partial class Document_texte : Document {}
	partial class Document_tableau : Document {}
	partial class Image : Document {}

    partial class Licence
    {
		//private static string type_ = "BusinessObject";
		List<Composant> composant_ ;
		public List<Composant> Composant_ { get => composant_; set => composant_ = value; }

	}
    partial class Composant
    {
		//private static string type_ = "BusinessObject";
		List<Fichier> fichier_ ;
		public List<Fichier> Fichier_ { get => fichier_; set => fichier_ = value; }

		List<Module> module_ ;
		public List<Module> Module_ { get => module_; set => module_ = value; }

	}
    partial class Transaction
    {
		//private static string type_ = "BusinessObject";
		List<Entité_métier> entité_métier_ ;
		public List<Entité_métier> Entité_métier_ { get => entité_métier_; set => entité_métier_ = value; }

	}
    partial class ORM
    {
		//private static string type_ = "BusinessObject";
		List<Entité_métier> entité_métier_ ;
		public List<Entité_métier> Entité_métier_ { get => entité_métier_; set => entité_métier_ = value; }

	}
    partial class Cache_dobjet
    {
		//private static string type_ = "BusinessObject";
		List<Entité_métier> entité_métier_ ;
		public List<Entité_métier> Entité_métier_ { get => entité_métier_; set => entité_métier_ = value; }

	}
    partial class Entité_métier
    {
		//private static string type_ = "BusinessObject";
		List<Notification> notification_ ;
		public List<Notification> Notification_ { get => notification_; set => notification_ = value; }

		List<Validateur> validateur_ ;
		public List<Validateur> Validateur_ { get => validateur_; set => validateur_ = value; }

		List<Notification_métier> notification_métier_ ;
		public List<Notification_métier> Notification_métier_ { get => notification_métier_; set => notification_métier_ = value; }

	}
    partial class Version
    {
		//private static string type_ = "BusinessObject";
		List<Composant> composant_ ;
		public List<Composant> Composant_ { get => composant_; set => composant_ = value; }

	}
    partial class Workflow_métier
    {
		//private static string type_ = "BusinessObject";
		List<Entité_métier> entité_métier_ ;
		public List<Entité_métier> Entité_métier_ { get => entité_métier_; set => entité_métier_ = value; }

		List<Vue_métier> vue_métier_ ;
		public List<Vue_métier> Vue_métier_ { get => vue_métier_; set => vue_métier_ = value; }

	}
    partial class Contexte_dapplication_métier
    {
		//private static string type_ = "BusinessObject";
		List<Entité_métier> entité_métier_ ;
		public List<Entité_métier> Entité_métier_ { get => entité_métier_; set => entité_métier_ = value; }

	}
    partial class Contexte_de_session_métier
    {
		//private static string type_ = "BusinessObject";
		List<Entité_métier> entité_métier_ ;
		public List<Entité_métier> Entité_métier_ { get => entité_métier_; set => entité_métier_ = value; }

	}
    partial class Contexte_utilisateur_métier
    {
		//private static string type_ = "BusinessObject";
		List<Entité_métier> entité_métier_ ;
		public List<Entité_métier> Entité_métier_ { get => entité_métier_; set => entité_métier_ = value; }

	}
    partial class Composant_client_métier
    {
		//private static string type_ = "BusinessObject";
		List<Classe_métier> classe_métier_ ;
		public List<Classe_métier> Classe_métier_ { get => classe_métier_; set => classe_métier_ = value; }

	}
    partial class Container_graphique
    {
		//private static string type_ = "BusinessObject";
		List<Widget> widget_ ;
		public List<Widget> Widget_ { get => widget_; set => widget_ = value; }

	}
    partial class Contexte_de_session
    {
		//private static string type_ = "BusinessObject";
		List<Entité> entité_ ;
		public List<Entité> Entité_ { get => entité_; set => entité_ = value; }

		List<Entité_métier> entité_métier_ ;
		public List<Entité_métier> Entité_métier_ { get => entité_métier_; set => entité_métier_ = value; }

	}
    partial class Contexte_dapplication
    {
		//private static string type_ = "BusinessObject";
		List<Entité> entité_ ;
		public List<Entité> Entité_ { get => entité_; set => entité_ = value; }

	}
    partial class Domaine_fonctionnel_métier
    {
		//private static string type_ = "BusinessObject";
		List<Autorisation> autorisation_ ;
		public List<Autorisation> Autorisation_ { get => autorisation_; set => autorisation_ = value; }

	}
    partial class Role
    {
		//private static string type_ = "BusinessObject";
		List<Utilisateur> utilisateur_ ;
		public List<Utilisateur> Utilisateur_ { get => utilisateur_; set => utilisateur_ = value; }

		List<Domaine_fonctionnel_métier> domaine_fonctionnel_métier_ ;
		public List<Domaine_fonctionnel_métier> Domaine_fonctionnel_métier_ { get => domaine_fonctionnel_métier_; set => domaine_fonctionnel_métier_ = value; }

		List<Autorisation> autorisation_ ;
		public List<Autorisation> Autorisation_ { get => autorisation_; set => autorisation_ = value; }

	}
    partial class Tool_externe_métier
    {
		//private static string type_ = "BusinessObject";
		List<Composant_client_métier> composant_client_métier_ ;
		public List<Composant_client_métier> Composant_client_métier_ { get => composant_client_métier_; set => composant_client_métier_ = value; }

	}
    partial class Unité_de_travail
    {
		//private static string type_ = "BusinessObject";
		List<Entité_métier> entité_métier_ ;
		public List<Entité_métier> Entité_métier_ { get => entité_métier_; set => entité_métier_ = value; }

	}
    partial class Schéma_métier
    {
		//private static string type_ = "BusinessObject";
		List<Entité_métier> entité_métier_ ;
		public List<Entité_métier> Entité_métier_ { get => entité_métier_; set => entité_métier_ = value; }

	}
    partial class Workflow_générique
    {
		//private static string type_ = "BusinessObject";
		List<Vue_générique> vue_générique_ ;
		public List<Vue_générique> Vue_générique_ { get => vue_générique_; set => vue_générique_ = value; }

	}
    partial class Service_CRUD_métier
    {
		//private static string type_ = "BusinessObject";
		List<ADO_métier> aDO_métier_ ;
		public List<ADO_métier> ADO_métier_ { get => aDO_métier_; set => aDO_métier_ = value; }

	}
    partial class Vue_métier
    {
		//private static string type_ = "BusinessObject";
		List<Widget> widget_ ;
		public List<Widget> Widget_ { get => widget_; set => widget_ = value; }

		List<Entité_métier> entité_métier_ ;
		public List<Entité_métier> Entité_métier_ { get => entité_métier_; set => entité_métier_ = value; }

	}
    partial class Scénario_A_COMPLETER
    {
		//private static string type_ = "BusinessObject";
		List<Service> service_ ;
		public List<Service> Service_ { get => service_; set => service_ = value; }

	}
    partial class Widget_métier
    {
		//private static string type_ = "BusinessObject";
		List<Entité_métier> entité_métier_ ;
		public List<Entité_métier> Entité_métier_ { get => entité_métier_; set => entité_métier_ = value; }

	}
    partial class Contexte_utilisateur
    {
		//private static string type_ = "BusinessObject";
		List<Entité_métier> entité_métier_ ;
		public List<Entité_métier> Entité_métier_ { get => entité_métier_; set => entité_métier_ = value; }

	}
    partial class Fonctionnalité
    {
		//private static string type_ = "BusinessObject";
		List<Autorisation> autorisation_ ;
		public List<Autorisation> Autorisation_ { get => autorisation_; set => autorisation_ = value; }

	}
    partial class Tool
    {
		//private static string type_ = "BusinessObject";
		List<Composant_client> composant_client_ ;
		public List<Composant_client> Composant_client_ { get => composant_client_; set => composant_client_ = value; }

	}
    partial class Service_métier
    {
		//private static string type_ = "BusinessObject";
		List<Règle_métier> règle_métier_ ;
		public List<Règle_métier> Règle_métier_ { get => règle_métier_; set => règle_métier_ = value; }

	}

    partial class Lanceur
    {
		//private static string type_ = "BusinessObject";
		Workflow workflow_ ;
		public Workflow Workflow_ { get => workflow_; set => workflow_ = value; }

	}

    partial class Workflows_Hapicare
    {
		//private static string type_ = "BusinessObject";
	}

    partial class Services_Métier_Hapicare
    {
		//private static string type_ = "BusinessObject";
		Services_CRUD_Hapicare services_CRUD_Hapicare_ ;
		public Services_CRUD_Hapicare Services_CRUD_Hapicare_ { get => services_CRUD_Hapicare_; set => services_CRUD_Hapicare_ = value; }

	}

    partial class Services_CRUD_Hapicare
    {
		//private static string type_ = "BusinessObject";
	}

    partial class Aspects_Hapicare
    {
		//private static string type_ = "BusinessObject";
		Services_Métier_Hapicare services_Métier_Hapicare_ ;
		public Services_Métier_Hapicare Services_Métier_Hapicare_ { get => services_Métier_Hapicare_; set => services_Métier_Hapicare_ = value; }

	}

    partial class Fonctionalité_technique
    {
		//private static string type_ = "BusinessObject";
		Aspects_Hapicare aspects_Hapicare_ ;
		public Aspects_Hapicare Aspects_Hapicare_ { get => aspects_Hapicare_; set => aspects_Hapicare_ = value; }

		Service service_ ;
		public Service Service_ { get => service_; set => service_ = value; }

	}

    partial class Application_Hapicare
    {
		//private static string type_ = "BusinessObject";
	}

    partial class Ressource
    {
		//private static string type_ = "BusinessObject";
		Fichier fichier_ ;
		public Fichier Fichier_ { get => fichier_; set => fichier_ = value; }

	}

    partial class Utilisateur
    {
		//private static string type_ = "BusinessObject";
		Contexte_utilisateur contexte_utilisateur_ ;
		public Contexte_utilisateur Contexte_utilisateur_ { get => contexte_utilisateur_; set => contexte_utilisateur_ = value; }

	}

    partial class Application
    {
		//private static string type_ = "BusinessObject";
		Contexte_dapplication contexte_dapplication_ ;
		public Contexte_dapplication Contexte_dapplication_ { get => contexte_dapplication_; set => contexte_dapplication_ = value; }

		Version version_ ;
		public Version Version_ { get => version_; set => version_ = value; }

		Aide_application aide_application_ ;
		public Aide_application Aide_application_ { get => aide_application_; set => aide_application_ = value; }

	}

    partial class Client
    {
		//private static string type_ = "BusinessObject";
		Licence licence_ ;
		public Licence Licence_ { get => licence_; set => licence_ = value; }

	}

    partial class Factory
    {
		//private static string type_ = "BusinessObject";
		Moteur_IOC moteur_IOC_ ;
		public Moteur_IOC Moteur_IOC_ { get => moteur_IOC_; set => moteur_IOC_ = value; }

	}

    partial class Service
    {
		//private static string type_ = "BusinessObject";
		Transaction transaction_ ;
		public Transaction Transaction_ { get => transaction_; set => transaction_ = value; }

	}

    partial class ADO
    {
		//private static string type_ = "BusinessObject";
		Unité_de_travail unité_de_travail_ ;
		public Unité_de_travail Unité_de_travail_ { get => unité_de_travail_; set => unité_de_travail_ = value; }

		Requete requete_ ;
		public Requete Requete_ { get => requete_; set => requete_ = value; }

	}

    partial class ORM
    {
		//private static string type_ = "BusinessObject";
		Unité_de_travail unité_de_travail_ ;
		public Unité_de_travail Unité_de_travail_ { get => unité_de_travail_; set => unité_de_travail_ = value; }

		ADO aDO_ ;
		public ADO ADO_ { get => aDO_; set => aDO_ = value; }

		Transaction transaction_ ;
		public Transaction Transaction_ { get => transaction_; set => transaction_ = value; }

	}

    partial class Verrou
    {
		//private static string type_ = "BusinessObject";
		ORM oRM_ ;
		public ORM ORM_ { get => oRM_; set => oRM_ = value; }

	}

    partial class Requete
    {
		//private static string type_ = "BusinessObject";
	}

    partial class Deployeur
    {
		//private static string type_ = "BusinessObject";
		Composant composant_ ;
		public Composant Composant_ { get => composant_; set => composant_ = value; }

	}

    partial class Licence
    {
		//private static string type_ = "BusinessObject";
		Version version_ ;
		public Version Version_ { get => version_; set => version_ = value; }

	}

    partial class Version
    {
		//private static string type_ = "BusinessObject";
	}

    partial class Périphérique_technique
    {
		//private static string type_ = "BusinessObject";
	}

    partial class Service_CRUD
    {
		//private static string type_ = "BusinessObject";
		Entité_métier entité_métier_ ;
		public Entité_métier Entité_métier_ { get => entité_métier_; set => entité_métier_ = value; }

	}

    partial class Entité_métier
    {
		//private static string type_ = "BusinessObject";
		Type_valeur_métier type_valeur_métier_ ;
		public Type_valeur_métier Type_valeur_métier_ { get => type_valeur_métier_; set => type_valeur_métier_ = value; }

	}

    partial class Aspect
    {
		//private static string type_ = "BusinessObject";
		Cache_dobjet cache_dobjet_ ;
		public Cache_dobjet Cache_dobjet_ { get => cache_dobjet_; set => cache_dobjet_ = value; }

		Cache_appel cache_appel_ ;
		public Cache_appel Cache_appel_ { get => cache_appel_; set => cache_appel_ = value; }

	}

    partial class Autorisation
    {
		//private static string type_ = "BusinessObject";
	}

    partial class ADO_métier
    {
		//private static string type_ = "BusinessObject";
		Entité_métier entité_métier_ ;
		public Entité_métier Entité_métier_ { get => entité_métier_; set => entité_métier_ = value; }

	}

    partial class Règle_métier
    {
		//private static string type_ = "BusinessObject";
		Entité_métier entité_métier_ ;
		public Entité_métier Entité_métier_ { get => entité_métier_; set => entité_métier_ = value; }

	}

    partial class Service_métier
    {
		//private static string type_ = "BusinessObject";
		Contrat_de_service_métier contrat_de_service_métier_ ;
		public Contrat_de_service_métier Contrat_de_service_métier_ { get => contrat_de_service_métier_; set => contrat_de_service_métier_ = value; }

	}

    partial class Fonctionnalité
    {
		//private static string type_ = "BusinessObject";
		Workflow_métier workflow_métier_ ;
		public Workflow_métier Workflow_métier_ { get => workflow_métier_; set => workflow_métier_ = value; }

	}

    partial class Composant_serveur_métier
    {
		//private static string type_ = "BusinessObject";
		Schéma_métier schéma_métier_ ;
		public Schéma_métier Schéma_métier_ { get => schéma_métier_; set => schéma_métier_ = value; }

	}

    partial class Schéma_métier
    {
		//private static string type_ = "BusinessObject";
		Domaine_fonctionnel_métier domaine_fonctionnel_métier_ ;
		public Domaine_fonctionnel_métier Domaine_fonctionnel_métier_ { get => domaine_fonctionnel_métier_; set => domaine_fonctionnel_métier_ = value; }

	}

    partial class Workflow_générique
    {
		//private static string type_ = "BusinessObject";
		Service_générique service_générique_ ;
		public Service_générique Service_générique_ { get => service_générique_; set => service_générique_ = value; }

	}

    partial class Service_générique
    {
		//private static string type_ = "BusinessObject";
		ADO_générique aDO_générique_ ;
		public ADO_générique ADO_générique_ { get => aDO_générique_; set => aDO_générique_ = value; }

	}

    partial class Aide_contextuelle
    {
		//private static string type_ = "BusinessObject";
		Widget widget_ ;
		public Widget Widget_ { get => widget_; set => widget_ = value; }

	}

    partial class Type_valeur_métier
    {
		//private static string type_ = "BusinessObject";
		Validateur validateur_ ;
		public Validateur Validateur_ { get => validateur_; set => validateur_ = value; }

	}

    partial class Unité_de_travail
    {
		//private static string type_ = "BusinessObject";
		Service service_ ;
		public Service Service_ { get => service_; set => service_ = value; }

	}

    partial class Service_CRUD_métier
    {
		//private static string type_ = "BusinessObject";
		Entité_métier entité_métier_ ;
		public Entité_métier Entité_métier_ { get => entité_métier_; set => entité_métier_ = value; }

	}

    partial class Vue
    {
		//private static string type_ = "BusinessObject";
	}

    partial class Vue_métier
    {
		//private static string type_ = "BusinessObject";
	}

    partial class Tool_externe
    {
		//private static string type_ = "BusinessObject";
	}

    partial class Workflow_métier
    {
		//private static string type_ = "BusinessObject";
	}

    partial class Validateur
    {
		//private static string type_ = "BusinessObject";
	}

    partial class Message
    {
		//private static string type_ = "BusinessObject";
	}

    partial class Notification
    {
		//private static string type_ = "BusinessObject";
	}

    partial class Exception_métier
    {
		//private static string type_ = "BusinessObject";
	}

    partial class Etat_métier
    {
		//private static string type_ = "BusinessObject";
	}

    partial class Etat
    {
		//private static string type_ = "BusinessObject";
	}

    partial class Métainformation
    {
		//private static string type_ = "BusinessObject";
		Relation relation_ ;
		public Relation Relation_ { get => relation_; set => relation_ = value; }

		Entité entité_ ;
		public Entité Entité_ { get => entité_; set => entité_ = value; }

	}

    partial class Périphérique
    {
		//private static string type_ = "BusinessObject";
	}

    partial class Tâche_métier
    {
		//private static string type_ = "BusinessObject";
		Workflow_métier workflow_métier_ ;
		public Workflow_métier Workflow_métier_ { get => workflow_métier_; set => workflow_métier_ = value; }

		Service_métier service_métier_ ;
		public Service_métier Service_métier_ { get => service_métier_; set => service_métier_ = value; }

	}

    partial class Template
    {
		//private static string type_ = "BusinessObject";
		Document document_ ;
		public Document Document_ { get => document_; set => document_ = value; }

	}

    partial class Workflow
    {
		//private static string type_ = "BusinessObject";
		Machine_à_état machine_à_état_ ;
		public Machine_à_état Machine_à_état_ { get => machine_à_état_; set => machine_à_état_ = value; }

	}

    partial class Machine_à_état
    {
		//private static string type_ = "BusinessObject";
		Workflow_métier workflow_métier_ ;
		public Workflow_métier Workflow_métier_ { get => workflow_métier_; set => workflow_métier_ = value; }

	}

}