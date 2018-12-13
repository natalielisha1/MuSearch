-- MySQL dump 10.13  Distrib 8.0.13, for Win64 (x86_64)
--
-- Host: localhost    Database: musearch
-- ------------------------------------------------------
-- Server version	8.0.13
DROP DATABASE IF EXISTS musearch;
CREATE DATABASE musearch;
USE musearch;
/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `albums`
--

DROP TABLE IF EXISTS `albums`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `albums` (
  `albumId` varchar(255) NOT NULL,
  `albumName` varchar(255) NOT NULL,
  `year` int(11) NOT NULL,
  PRIMARY KEY (`albumId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `albums`
--

LOCK TABLES `albums` WRITE;
/*!40000 ALTER TABLE `albums` DISABLE KEYS */;
/*!40000 ALTER TABLE `albums` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `decades`
--

DROP TABLE IF EXISTS `decades`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `decades` (
  `decadeId` int(11) NOT NULL AUTO_INCREMENT,
  `decadeName` varchar(255) NOT NULL,
  PRIMARY KEY (`decadeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `decades`
--

LOCK TABLES `decades` WRITE;
/*!40000 ALTER TABLE `decades` DISABLE KEYS */;
/*!40000 ALTER TABLE `decades` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `decadestoyears`
--

DROP TABLE IF EXISTS `decadestoyears`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `decadestoyears` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `decadeId` int(11) NOT NULL,
  `year` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `decadeId` (`decadeId`),
  CONSTRAINT `decadestoyears_ibfk_1` FOREIGN KEY (`decadeId`) REFERENCES `decades` (`decadeid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `decadestoyears`
--

LOCK TABLES `decadestoyears` WRITE;
/*!40000 ALTER TABLE `decadestoyears` DISABLE KEYS */;
/*!40000 ALTER TABLE `decadestoyears` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `games`
--

DROP TABLE IF EXISTS `games`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `games` (
  `gameId` int(11) NOT NULL AUTO_INCREMENT,
  `userId` int(11) NOT NULL,
  `points` int(11) NOT NULL,
  `date` date DEFAULT NULL,
  PRIMARY KEY (`gameId`),
  KEY `userId` (`userId`),
  CONSTRAINT `games_ibfk_1` FOREIGN KEY (`userId`) REFERENCES `users` (`userid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `games`
--

LOCK TABLES `games` WRITE;
/*!40000 ALTER TABLE `games` DISABLE KEYS */;
/*!40000 ALTER TABLE `games` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `genres`
--

DROP TABLE IF EXISTS `genres`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `genres` (
  `genreId` varchar(255) NOT NULL,
  `genreName` varchar(255) NOT NULL,
  PRIMARY KEY (`genreId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `genres`
--

LOCK TABLES `genres` WRITE;
/*!40000 ALTER TABLE `genres` DISABLE KEYS */;
/*!40000 ALTER TABLE `genres` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shortsongcsv`
--

DROP TABLE IF EXISTS `shortsongcsv`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `shortsongcsv` (
  `SongNumber` int(11) DEFAULT NULL,
  `SongID` text,
  `AlbumID` int(11) DEFAULT NULL,
  `AlbumName` text,
  `ArtistID` text,
  `ArtistHotttnesss` double DEFAULT NULL,
  `ArtistFamiliarity` double DEFAULT NULL,
  `ArtistLatitude` text,
  `ArtistLocation` text,
  `ArtistLongitude` text,
  `ArtistName` text,
  `Danceability` int(11) DEFAULT NULL,
  `Duration` double DEFAULT NULL,
  `KeySignature` int(11) DEFAULT NULL,
  `KeySignatureConfidence` double DEFAULT NULL,
  `Tempo` double DEFAULT NULL,
  `TimeSignature` int(11) DEFAULT NULL,
  `TimeSignatureConfidence` double DEFAULT NULL,
  `Title` text,
  `SongHotttnesss` double DEFAULT NULL,
  `Loudness` double DEFAULT NULL,
  `Energy` int(11) DEFAULT NULL,
  `Year` int(11) DEFAULT NULL,
  `SimilarArtists` text,
  `Genre` text,
  `Audio` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shortsongcsv`
--

LOCK TABLES `shortsongcsv` WRITE;
/*!40000 ALTER TABLE `shortsongcsv` DISABLE KEYS */;
INSERT INTO `shortsongcsv` VALUES (1,'SOMZWCG12A8C13C480',300848,'Fear Itself','ARD7TVE1187B99BFB1',0.401997543,0.581793766,'','California - LA','','Casual',0,218.93179,1,0.736,92.198,4,0.778,'bI Didn\'t Mean To\"\"',0.60211999,-11.197,0,0,'\"ARV4KO21187FB38008\'\"','\"hip hop\'\"','a222795e07cd65b7a530f1346f520649\''),(2,'SOCIWDW12A8C13D406',300822,'Dimensions','ARMJAGH1187FB546F3',0.417499645,0.630630038,'35.14968','Memphis TN','-90.04892','The Box Tops',0,148.03546,6,0.169,121.274,4,0.384,'Soul Deep',0,-9.843,0,1969,'\"ARSZWK21187B9B26D7\'\"','\"blue-eyed soul\'\"','60s\'\"\"'),(3,'SOXVLOJ12AB0189215',514953,'Las Numero 1','ARKRRTF1187B9984DA',0.343428378,0.487356791,'','','','Sonora Santanera',0,177.47546,8,0.643,100.07,1,0,'Amor De Cabaret',0,-9.689,0,0,'\"ARFSJUG11C8A421AAD\'\"','\"salsa\'\"','fa329738005ca53715d9f7381a0d1fe3\''),(4,'SONHOTT12A8C13493C',287650,'Friend Or Foe','AR7G5I41187FB4CE6C',0.454231157,0.630382334,'','London England','','Adam Ant',0,233.40363,0,0.751,119.293,4,0,'Something Girls',0,-9.013,0,1982,'\"AR4R0741187FB39AF2\'\"','\"pop rock\'\"','43cd1abd45d5a2dda16a3c65b4963bd4\''),(5,'SOFSOCN12A8C143F5D',611336,'Muertos Vivos','ARXR32B1187FB57099',0.401723686,0.651045661,'','','','Go',0,209.60608,2,0.092,129.738,4,0.562,'Face the Ashes',0.604500739,-4.501,0,2007,'\"ARUA62A1187B99D9B0\'\"','\"pop punk\'\"','580a8fe08ef0f1c7734b84547d7a8bc7\''),(6,'SOYMRWW12A6D4FAB14',41838,'Ordinary Day','ARKFYS91187B98E58F',0.385470551,0.535292736,'','','','Jeff And Sheri Easter',0,267.7024,5,0.635,147.782,3,0.454,'The Moon And I (Ordinary Day Album Version)',0,-9.323,0,0,'\"ARHNMEZ11F50C4706C\'\"','\"southern gospel\'\"','8ee90e90bb8714300574486f379effb5\''),(7,'SOMJBYD12A6D4F8557',25824,'Da Ghetto Psychic','ARD0S291187B9B7BF5',0.261941177,0.556495602,'','Ohio','','Rated R',0,114.78159,1,0,111.787,1,0,'Keepin It Real (Skit)',0,-17.302,0,0,'\"ARF93II1187B99F981\'\"','\"breakbeat\'\"','0e574964bf7a546a39e039f6e35aa48a\''),(8,'SOHKNRJ12A6701D1F8',8876,'Gin & Phonic','AR10USD1187B99F3F1',0.605507136,0.801136447,'','Burlington Ontario Canada','','Tweeterfriendly Music',0,189.57016,4,0,101.43,3,0.408,'Drop of Rain',0,-11.642,0,0,'\"ARJXL4Z1187B9A5920\'\"','\"post-hardcore\'\"','1741d2c1bd271f10e783634f286746e2\''),(9,'SOIAZJW12AB01853F1',358182,'Pink World','AR8ZCNI1187B9A069',0.332275747,0.426667857,'','','','Planet P Project',0,269.81832,4,0.717,86.643,4,0.487,'Pink World',0.265861049,-13.496,0,1984,'\"ARWVP631187FB4D016\'\"','\"new wave\'\"','eda960ea61211d980653d589e8e74c1d\''),(10,'SOUDSGM12AC9618304',692313,'Superinstrumental','ARNTLGG11E2835DDB9',0.422705641,0.550513698,'','','','Clp',0,266.39628,7,0.053,114.041,4,0.878,'Insatiable (Instrumental Version)',0,-6.697,0,0,'\"ARAR1XA11C8A415BE5\'\"','\"breakcore\'\"','c76afe800148e674a30629a4686d7f9f\'');
/*!40000 ALTER TABLE `shortsongcsv` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `songs`
--

DROP TABLE IF EXISTS `songs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `songs` (
  `songId` varchar(255) NOT NULL,
  `songName` varchar(255) NOT NULL,
  `albumId` varchar(255) NOT NULL,
  `artistId` varchar(255) NOT NULL,
  `year` int(11) NOT NULL,
  PRIMARY KEY (`songId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `songs`
--

LOCK TABLES `songs` WRITE;
/*!40000 ALTER TABLE `songs` DISABLE KEYS */;
/*!40000 ALTER TABLE `songs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `songscsvsongscsv`
--

DROP TABLE IF EXISTS `songscsvsongscsv`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `songscsvsongscsv` (
  `SongNumber` varchar(255) DEFAULT NULL,
  `SongID` varchar(255) DEFAULT NULL,
  `AlbumID` varchar(255) DEFAULT NULL,
  `AlbumName` varchar(255) DEFAULT NULL,
  `ArtistID` varchar(255) DEFAULT NULL,
  `ArtistHotttnesss` varchar(255) DEFAULT NULL,
  `ArtistFamiliarity` varchar(255) DEFAULT NULL,
  `ArtistLatitude` varchar(255) DEFAULT NULL,
  `ArtistLocation` varchar(255) DEFAULT NULL,
  `ArtistLongitude` varchar(255) DEFAULT NULL,
  `ArtistName` varchar(255) DEFAULT NULL,
  `Danceability` varchar(255) DEFAULT NULL,
  `Duration` varchar(255) DEFAULT NULL,
  `KeySignature` varchar(255) DEFAULT NULL,
  `KeySignatureConfidence` varchar(255) DEFAULT NULL,
  `Tempo` varchar(255) DEFAULT NULL,
  `TimeSignature` varchar(255) DEFAULT NULL,
  `TimeSignatureConfidence` varchar(255) DEFAULT NULL,
  `Title` varchar(255) DEFAULT NULL,
  `SongHotttnesss` varchar(255) DEFAULT NULL,
  `Loudness` varchar(255) DEFAULT NULL,
  `Energy` varchar(255) DEFAULT NULL,
  `Year` varchar(255) DEFAULT NULL,
  `SimilarArtists` varchar(255) DEFAULT NULL,
  `Genre` varchar(255) DEFAULT NULL,
  `Audio` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `songscsvsongscsv`
--

LOCK TABLES `songscsvsongscsv` WRITE;
/*!40000 ALTER TABLE `songscsvsongscsv` DISABLE KEYS */;
INSERT INTO `songscsvsongscsv` VALUES ('1','b\'SOMZWCG12A8C13C480\'','300848','b\'Fear Itself\'','b\'ARD7TVE1187B99BFB1\'','0.401997543','0.581793766','','b\'California - LA\'','','b\'Casual\'','0','218.93179','1','0.736','92.198','4','0.778','bI Didn\'t Mean To\"\"','0.60211999','-11.197','0','0','\"b\'ARV4KO21187FB38008\'\"','\"b\'hip hop\'\"','b\'a222795e07cd65b7a530f1346f520649\''),('2','b\'SOCIWDW12A8C13D406\'','300822','b\'Dimensions\'','b\'ARMJAGH1187FB546F3\'','0.417499645','0.630630038','35.14968','b\'Memphis TN\'','-90.04892','b\'The Box Tops\'','0','148.03546','6','0.169','121.274','4','0.384','b\'Soul Deep\'','nan','-9.843','0','1969','\"b\'ARSZWK21187B9B26D7\'\"','\"b\'blue-eyed soul\'\"','b\'60s\'\"\"'),('3','b\'SOXVLOJ12AB0189215\'','514953','b\'Las Numero 1 De La Sonora Santanera\'','b\'ARKRRTF1187B9984DA\'','0.343428378','0.487356791','','b\'\'','','b\'Sonora Santanera\'','0','177.47546','8','0.643','100.07','1','0','b\'Amor De Cabaret\'','nan','-9.689','0','0','\"b\'ARFSJUG11C8A421AAD\'\"','\"b\'salsa\'\"','b\'fa329738005ca53715d9f7381a0d1fe3\''),('4','b\'SONHOTT12A8C13493C\'','287650','b\'Friend Or Foe\'','b\'AR7G5I41187FB4CE6C\'','0.454231157','0.630382334','','b\'London England\'','','b\'Adam Ant\'','0','233.40363','0','0.751','119.293','4','0','b\'Something Girls\'','nan','-9.013','0','1982','\"b\'AR4R0741187FB39AF2\'\"','\"b\'pop rock\'\"','b\'43cd1abd45d5a2dda16a3c65b4963bd4\''),('5','b\'SOFSOCN12A8C143F5D\'','611336','b\'Muertos Vivos\'','b\'ARXR32B1187FB57099\'','0.401723686','0.651045661','','b\'\'','','b\'Gob\'','0','209.60608','2','0.092','129.738','4','0.562','b\'Face the Ashes\'','0.604500739','-4.501','0','2007','\"b\'ARUA62A1187B99D9B0\'\"','\"b\'pop punk\'\"','b\'580a8fe08ef0f1c7734b84547d7a8bc7\''),('6','b\'SOYMRWW12A6D4FAB14\'','41838','b\'Ordinary Day\'','b\'ARKFYS91187B98E58F\'','0.385470551','0.535292736','','b\'\'','','b\'Jeff And Sheri Easter\'','0','267.7024','5','0.635','147.782','3','0.454','b\'The Moon And I (Ordinary Day Album Version)\'','nan','-9.323','0','0','\"b\'ARHNMEZ11F50C4706C\'\"','\"b\'southern gospel\'\"','b\'8ee90e90bb8714300574486f379effb5\''),('7','b\'SOMJBYD12A6D4F8557\'','25824','b\'Da Ghetto Psychic\'','b\'ARD0S291187B9B7BF5\'','0.261941177','0.556495602','','b\'Ohio\'','','b\'Rated R\'','0','114.78159','1','0','111.787','1','0','b\'Keepin It Real (Skit)\'','nan','-17.302','0','0','\"b\'ARF93II1187B99F981\'\"','\"b\'breakbeat\'\"','b\'0e574964bf7a546a39e039f6e35aa48a\''),('8','b\'SOHKNRJ12A6701D1F8\'','8876','b\'Gin & Phonic\'','b\'AR10USD1187B99F3F1\'','0.605507136','0.801136447','','b\'Burlington Ontario Canada\'','','b\'Tweeterfriendly Music\'','0','189.57016','4','0','101.43','3','0.408','b\'Drop of Rain\'','nan','-11.642','0','0','\"b\'ARJXL4Z1187B9A5920\'\"','\"b\'post-hardcore\'\"','b\'1741d2c1bd271f10e783634f286746e2\''),('9','b\'SOIAZJW12AB01853F1\'','358182','b\'Pink World\'','b\'AR8ZCNI1187B9A069B\'','0.332275747','0.426667857','','b\'\'','','b\'Planet P Project\'','0','269.81832','4','0.717','86.643','4','0.487','b\'Pink World\'','0.265861049','-13.496','0','1984','\"b\'ARWVP631187FB4D016\'\"','\"b\'new wave\'\"','b\'eda960ea61211d980653d589e8e74c1d\''),('10','b\'SOUDSGM12AC9618304\'','692313','b\'Superinstrumental\'','b\'ARNTLGG11E2835DDB9\'','0.422705641','0.550513698','','b\'\'','','b\'Clp\'','0','266.39628','7','0.053','114.041','4','0.878','b\'Insatiable (Instrumental Version)\'','nan','-6.697','0','0','\"b\'ARAR1XA11C8A415BE5\'\"','\"b\'breakcore\'\"','b\'c76afe800148e674a30629a4686d7f9f\'');
/*!40000 ALTER TABLE `songscsvsongscsv` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `songtogenre`
--

DROP TABLE IF EXISTS `songtogenre`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `songtogenre` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `songId` varchar(255) NOT NULL,
  `genreId` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `songId` (`songId`),
  KEY `genreId` (`genreId`),
  CONSTRAINT `songtogenre_ibfk_1` FOREIGN KEY (`songId`) REFERENCES `songs` (`songid`),
  CONSTRAINT `songtogenre_ibfk_2` FOREIGN KEY (`genreId`) REFERENCES `genres` (`genreid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `songtogenre`
--

LOCK TABLES `songtogenre` WRITE;
/*!40000 ALTER TABLE `songtogenre` DISABLE KEYS */;
/*!40000 ALTER TABLE `songtogenre` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `users` (
  `userId` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `password` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`userId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;


---
--- Function that gets the three best scores of a user
---

CREATE DEFINER=`root`@`localhost` PROCEDURE `getTopThreeGames`(IN userid1 INT(11))
BEGIN
	SELECT gameId, points, date FROM musearch.games WHERE userId = userId1;
END

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (4,'ifat','ifat1'),(5,'gili','gili');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'musearch'
--
/*!50003 DROP PROCEDURE IF EXISTS `checkUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `checkUser`(IN username1 VARCHAR(255), password1 VARCHAR(255))
BEGIN
	SELECT userId FROM musearch.users WHERE username = username1 and password = password1;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `getSongs` */;
ALTER DATABASE `musearch` CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getSongs`()
BEGIN
	SELECT AlbumName FROM musearch.shortsongcsv;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
ALTER DATABASE `musearch` CHARACTER SET utf8 COLLATE utf8_general_ci ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-12-12 11:19:38
