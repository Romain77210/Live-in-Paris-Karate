SELECT * FROM utilisateur;
SELECT * FROM Cuisinier;
SELECT * FROM Commande;
SELECT nom FROM Client;
SELECT * FROM Avis;
SELECT nom FROM Plat;
SELECT * FROM Ingrédient;
SELECT * FROM avis WHERE Note BETWEEN 4 AND 5;
SELECT count(*) FROM Ingrédient WHERE certification = 'aop' ;
SELECT * FROM Ingrédient WHERE certification = 'Bio' ;
SELECT * FROM Ingrédient WHERE origine = 'france' ;
SELECT nom FROM utilisateur ORDER BY nom;
SELECT Nom_plat, Prix FROM Plat where Prix=( select max(Prix) from Plat);
 
