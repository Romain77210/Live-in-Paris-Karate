CREATE DATABASE IF NOT EXISTS Projet;
USE Projet;

CREATE TABLE Ingrédient(
   Nom VARCHAR(50),
   Origine VARCHAR(50),
   Régime_alimentaire VARCHAR(50),
   certification VARCHAR(50),
   PRIMARY KEY(Nom)
);

CREATE TABLE utilisateur(
   id_utilisateur INT,
   Prénom VARCHAR(50),
   Nom VARCHAR(50),
   Statue VARCHAR(50),
   Téléphone INT,
   Mail VARCHAR(50),
   Mot_de_passe VARCHAR(50),
   Adresse_postale VARCHAR(255),
   PRIMARY KEY(id_utilisateur)
);

CREATE TABLE Cuisinier(
   Id_Cuisinier INT,
   id_utilisateur INT NOT NULL,
   PRIMARY KEY(Id_Cuisinier),
   UNIQUE(id_utilisateur),
   FOREIGN KEY(id_utilisateur) REFERENCES utilisateur(id_utilisateur)
);

CREATE TABLE Client(
   Id_Client INT,
   id_utilisateur INT NOT NULL,
   PRIMARY KEY(Id_Client),
   UNIQUE(id_utilisateur),
   FOREIGN KEY(id_utilisateur) REFERENCES utilisateur(id_utilisateur)
);

CREATE TABLE Plat(
   Nom_plat VARCHAR(50),
   Prix INT,
   Photo BLOB,
   Nationalité VARCHAR(50),
   Date_de_fabrication DATETIME,
   Date_de_péremption DATETIME,
   Nbr_part INT,
   Id_Cuisinier INT NOT NULL,
   PRIMARY KEY(Nom_plat),
   FOREIGN KEY(Id_Cuisinier) REFERENCES Cuisinier(Id_Cuisinier)
);

CREATE TABLE Commande(
   Id_Commande INT,
   Date_commande DATETIME,
   Prix INT,
   Temps DATETIME,
   Statut VARCHAR(50),
   Id_Cuisinier INT NOT NULL,
   Id_Client INT NOT NULL,
   PRIMARY KEY(Id_Commande),
   FOREIGN KEY(Id_Cuisinier) REFERENCES Cuisinier(Id_Cuisinier),
   FOREIGN KEY(Id_Client) REFERENCES Client(Id_Client)
);

CREATE TABLE avis(
   Id_avis INT,
   Titre VARCHAR(50),
   Commentaire TEXT,
   Note INT,
   Photo BLOB,
   Id_Client INT NOT NULL,
   Id_Cuisinier INT NOT NULL,
   PRIMARY KEY(Id_avis),
   FOREIGN KEY(Id_Client) REFERENCES Client(Id_Client),
   FOREIGN KEY(Id_Cuisinier) REFERENCES Cuisinier(Id_Cuisinier)
);

CREATE TABLE exemp_plat(
   id INT,
   adresse_liv VARCHAR(50),
   Nom_plat VARCHAR(50) NOT NULL,
   Id_Commande INT,
   PRIMARY KEY(id),
   FOREIGN KEY(Nom_plat) REFERENCES Plat(Nom_plat),
   FOREIGN KEY(Id_Commande) REFERENCES Commande(Id_Commande)
);