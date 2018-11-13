CREATE TABLE `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `Users` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Username` longtext NULL,
    `PaswordHash` longblob NULL,
    `PaswordSalt` longblob NULL,
    `LastActive` datetime(6) NOT NULL,
    `KnownAs` longtext NULL,
    `Name` longtext NULL,
    `Forename` longtext NULL,
    CONSTRAINT `PK_Users` PRIMARY KEY (`Id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20181108121123_mysqlinitial', '2.1.4-rtm-31024');

