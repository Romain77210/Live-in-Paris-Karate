INSERT INTO Ingrédient (Nom, Origine, Régime_alimentaire, certification) VALUES
('Tomate', 'Espagne', 'Végétarien', 'Bio'),
('Poulet', 'France', 'Omnivore', 'Label Rouge'),
('Saumon', 'Norvège', 'Pescetarien', 'ASC'),
('Fromage', 'Italie', 'Végétarien', 'AOP'),
('Basilic', 'France', 'Végétarien', 'Bio'),
('Ail', 'Chine', 'Végétarien', 'Non certifié'),
('Oignon', 'Espagne', 'Végétarien', 'Bio'),
('Pomme de terre', 'Allemagne', 'Végétarien', 'Bio'),
('Carotte', 'Pays-Bas', 'Végétarien', 'Bio'),
('Courgette', 'Italie', 'Végétarien', 'AOP'),
('Thon', 'Japon', 'Pescetarien', 'MSC'),
('Boeuf', 'Argentine', 'Omnivore', 'Label Rouge'),
('Lait', 'France', 'Végétarien', 'AB'),
('Beurre', 'Belgique', 'Végétarien', 'AOP'),
('Oeuf', 'France', 'Omnivore', 'Bio');

INSERT INTO utilisateur (id_utilisateur, Prénom, Nom, Statue, Téléphone, Mail, Mot_de_passe, Adresse_postale) VALUES
(3745352, 'Jean', 'Dupont', 'Client', 123456789, 'jean.dupont@mail.com', 'mdp123', '10 rue de Paris, France'),
(4892034, 'Marie', 'Curie', 'Client', 987654321, 'marie.curie@mail.com', 'radioactif', '15 avenue Einstein, France'),
(5928473, 'Paul', 'Bocuse', 'Cuisinier/client', 111222333, 'paul.bocuse@mail.com', 'gastronomie', '5 place des Chefs, France');

INSERT INTO Cuisinier (Id_Cuisinier, id_utilisateur) VALUES
(7839456, 5928473);

INSERT INTO Client (Id_Client, id_utilisateur) VALUES
(666,5928473),
(6738291, 3745352),
(9823745, 4892034);

INSERT INTO Plat (Nom_plat, Prix, Photo, Nationalité, Date_de_fabrication, Date_de_péremption, Nbr_part, Id_Cuisinier) VALUES
('Ratatouille', 15, NULL, 'Française', '2025-02-25 12:00:00', '2025-03-01 12:00:00', 2, 7839456),
('Sushi', 20, NULL, 'Japonaise', '2025-02-25 12:00:00', '2025-02-27 12:00:00', 4, 7839456);

INSERT INTO Commande (Id_Commande, Date_commande, Prix, Temps, Statut, Id_Cuisinier, Id_Client) VALUES
(8237465, '2025-02-25 13:00:00', 35, '2025-02-25 13:30:00', 'En cours', 7839456, 6738291);

INSERT INTO avis (Id_avis, Titre, Commentaire, Note, Photo, Id_Client, Id_Cuisinier) VALUES
(3748293, 'Délicieux', 'Le plat était excellent, bien préparé.', 5, NULL, 6738291, 7839456);

INSERT INTO exemp_plat (id, adresse_liv, Nom_plat, Id_Commande) VALUES
(9283746, '10 rue de Paris, France', 'Ratatouille', 8237465);