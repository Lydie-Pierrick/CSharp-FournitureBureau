BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS `SousFamilles` (
	`RefSousFamille`	Int ( 11 ) NOT NULL,
	`RefFamille`	Int ( 11 ) NOT NULL,
	`Nom`	Varchar ( 50 ) NOT NULL,
	PRIMARY KEY(`RefSousFamille`)
);
INSERT INTO `SousFamilles` (RefSousFamille,RefFamille,Nom) VALUES (1,'','');
CREATE TABLE IF NOT EXISTS `Marques` (
	`RefMarque`	Int ( 11 ) NOT NULL,
	`Nom`	Varchar ( 50 ) NOT NULL,
	PRIMARY KEY(`RefMarque`)
);
INSERT INTO `Marques` (RefMarque,Nom) VALUES (1,''),
 (2,''),
 (3,''),
 (4,''),
 (5,''),
 (6,'');
CREATE TABLE IF NOT EXISTS `Familles` (
	`RefFamille`	Int ( 11 ) NOT NULL,
	`Nom`	Varchar ( 50 ) NOT NULL,
	PRIMARY KEY(`RefFamille`)
);
INSERT INTO `Familles` (RefFamille,Nom) VALUES (1,'');
CREATE TABLE IF NOT EXISTS `Articles` (
	`RefArticle`	Varchar ( 8 ) NOT NULL,
	`Description`	Varchar ( 150 ) NOT NULL,
	`RefSousFamille`	Int ( 11 ) NOT NULL,
	`RefMarque`	Int ( 11 ) NOT NULL,
	`PrixHT`	float NOT NULL,
	`Quantite`	Int ( 11 ) NOT NULL,
	PRIMARY KEY(`RefArticle`)
);
INSERT INTO `Articles` (RefArticle,Description,RefSousFamille,RefMarque,PrixHT,Quantite) VALUES ('1','','','','','');
COMMIT;
