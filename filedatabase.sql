-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Vært: 127.0.0.1
-- Genereringstid: 21. 12 2017 kl. 10:41:21
-- Serverversion: 10.1.28-MariaDB
-- PHP-version: 7.1.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `filedatabase`
--

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `files`
--

CREATE TABLE `files` (
  `ID` int(11) NOT NULL,
  `Uploader` text NOT NULL,
  `FileName` text NOT NULL,
  `Url` text NOT NULL,
  `Downloads` int(11) NOT NULL DEFAULT '0',
  `Created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `Modified` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00' ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Data dump for tabellen `files`
--

INSERT INTO `files` (`ID`, `Uploader`, `FileName`, `Url`, `Downloads`, `Created`, `Modified`) VALUES
(13, 'R5th', 'test1.txt', 'Dokumenter', 0, '2017-12-20 12:25:14', '0000-00-00 00:00:00'),
(14, 'R5th', 'test2 - Kopi (2).txt', 'Dokumenter', 0, '2017-12-20 12:25:16', '0000-00-00 00:00:00'),
(15, 'R5th', 'test2 - Kopi (3).txt', 'Dokumenter', 0, '2017-12-20 12:25:19', '0000-00-00 00:00:00'),
(16, 'R5th', 'test2 - Kopi.txt', 'Dokumenter', 0, '2017-12-20 12:25:23', '0000-00-00 00:00:00'),
(17, 'R5th', 'test2.txt', 'Dokumenter', 0, '2017-12-20 12:25:26', '0000-00-00 00:00:00'),
(18, 'R5th', 'Udklip.JPG', 'Billeder', 0, '2017-12-20 12:25:30', '0000-00-00 00:00:00'),
(19, 'R5th', 'Udklip1.JPG', 'Billeder', 0, '2017-12-20 12:25:33', '0000-00-00 00:00:00'),
(20, 'R5th', 'Klippekort.JPG', 'Billeder', 0, '2017-12-20 12:25:36', '0000-00-00 00:00:00'),
(21, 'R5th', 'cnjxv4.txt', 'Dokumenter', 0, '2017-12-20 12:47:57', '0000-00-00 00:00:00');

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `log`
--

CREATE TABLE `log` (
  `ID` int(11) NOT NULL,
  `UserName` text NOT NULL,
  `Status` text NOT NULL,
  `Created` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `Modifyed` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00' ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Data dump for tabellen `log`
--

INSERT INTO `log` (`ID`, `UserName`, `Status`, `Created`, `Modifyed`) VALUES
(57, 'R5th', 'Upload', '2017-12-20 12:25:10', '0000-00-00 00:00:00'),
(58, 'R5th', 'Upload', '2017-12-20 12:25:15', '0000-00-00 00:00:00'),
(59, 'R5th', 'Upload', '2017-12-20 12:25:17', '0000-00-00 00:00:00'),
(60, 'R5th', 'Upload', '2017-12-20 12:25:21', '0000-00-00 00:00:00'),
(61, 'R5th', 'Upload', '2017-12-20 12:25:24', '0000-00-00 00:00:00'),
(62, 'R5th', 'Upload', '2017-12-20 12:25:27', '0000-00-00 00:00:00'),
(63, 'R5th', 'Upload', '2017-12-20 12:25:31', '0000-00-00 00:00:00'),
(64, 'R5th', 'Upload', '2017-12-20 12:25:34', '0000-00-00 00:00:00'),
(65, 'R5th', 'Upload', '2017-12-20 12:47:34', '0000-00-00 00:00:00'),
(66, 'R5th', 'Upload', '2017-12-20 12:48:02', '0000-00-00 00:00:00');

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `users`
--

CREATE TABLE `users` (
  `ID` int(11) NOT NULL,
  `FirstName` text NOT NULL,
  `UserName` text NOT NULL,
  `Password` text NOT NULL,
  `Created` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `Modified` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Data dump for tabellen `users`
--

INSERT INTO `users` (`ID`, `FirstName`, `UserName`, `Password`, `Created`, `Modified`) VALUES
(7, 'Richard', 'R5th', 'kqa35tra', '2017-12-20 13:19:23', '2017-12-20 13:19:23'),
(8, 'Kurt', 'Ktho', 'kulida', '2017-12-20 13:19:23', '2017-12-20 13:19:23'),
(9, 'Ulla', 'Ussk', 'hu54mi', '2017-12-20 13:19:23', '2017-12-20 13:19:23');

--
-- Begrænsninger for dumpede tabeller
--

--
-- Indeks for tabel `files`
--
ALTER TABLE `files`
  ADD PRIMARY KEY (`ID`);

--
-- Indeks for tabel `log`
--
ALTER TABLE `log`
  ADD PRIMARY KEY (`ID`);

--
-- Indeks for tabel `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`ID`);

--
-- Brug ikke AUTO_INCREMENT for slettede tabeller
--

--
-- Tilføj AUTO_INCREMENT i tabel `files`
--
ALTER TABLE `files`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- Tilføj AUTO_INCREMENT i tabel `log`
--
ALTER TABLE `log`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=67;

--
-- Tilføj AUTO_INCREMENT i tabel `users`
--
ALTER TABLE `users`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
