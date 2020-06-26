-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 18, 2020 at 02:03 PM
-- Server version: 10.4.6-MariaDB
-- PHP Version: 7.3.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `weerstation`
--
CREATE DATABASE IF NOT EXISTS `weerstation` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `weerstation`;

-- --------------------------------------------------------

--
-- Table structure for table `afgelopendagen2`
--

CREATE TABLE `afgelopendagen2` (
  `id` int(11) NOT NULL,
  `day` int(11) NOT NULL,
  `month` int(11) NOT NULL,
  `temp` int(11) NOT NULL,
  `place` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `afgelopendagen2`
--

INSERT INTO `afgelopendagen2` (`id`, `day`, `month`, `temp`, `place`) VALUES
(1, 18, 6, 17, 'Veenoord'),
(2, 18, 6, 17, 'Veenoord'),
(3, 18, 6, 17, 'Veenoord'),
(4, 17, 6, 25, 'Veenoord'),
(6, 18, 6, 17, 'Veenoord'),
(7, 18, 6, 17, 'Veenoord'),
(8, 18, 6, 11, 'Sydney'),
(9, 18, 6, 11, 'Sydney'),
(10, 18, 6, 17, 'Veenoord'),
(11, 18, 6, 11, 'Sydney'),
(12, 18, 6, 26, 'Oslo'),
(13, 18, 6, 18, 'new york'),
(14, 18, 6, 29, 'moskou'),
(15, 18, 6, 29, 'moskou'),
(16, 18, 6, 29, 'moskou'),
(17, 18, 6, 29, 'moskou'),
(18, 18, 6, 18, 'trondheim'),
(19, 18, 6, 18, 'trondheim'),
(20, 18, 6, 17, 'Veenoord'),
(21, 18, 6, 17, 'Veenoord'),
(22, 18, 6, 17, 'Veenoord'),
(23, 18, 6, 17, 'Veenoord'),
(24, 18, 6, 17, 'Veenoord'),
(25, 18, 6, 17, 'Veenoord'),
(26, 18, 6, 17, 'Veenoord'),
(27, 18, 6, 17, 'Veenoord'),
(28, 18, 6, 17, 'Veenoord'),
(29, 18, 6, 17, 'Veenoord'),
(30, 18, 6, 17, 'Veenoord'),
(31, 18, 6, 27, 'oslo'),
(32, 18, 6, 23, 'melbourne'),
(33, 18, 6, 17, 'Veenoord'),
(34, 18, 6, 17, 'emmen'),
(35, 18, 6, 17, 'emmen');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `afgelopendagen2`
--
ALTER TABLE `afgelopendagen2`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `afgelopendagen2`
--
ALTER TABLE `afgelopendagen2`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
