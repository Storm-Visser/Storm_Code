-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 15, 2020 at 11:00 AM
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

-- --------------------------------------------------------

--
-- Table structure for table `afgelopendagen`
--

CREATE TABLE `afgelopendagen` (
  `id` int(11) NOT NULL,
  `temp` int(11) NOT NULL,
  `day` int(11) NOT NULL,
  `month` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `afgelopendagen`
--

INSERT INTO `afgelopendagen` (`id`, `temp`, `day`, `month`) VALUES
(1, 22, 10, 6),
(2, 22, 10, 6),
(6, 15, 11, 6),
(7, 20, 11, 6),
(8, 20, 12, 6),
(9, 28, 12, 6),
(10, 15, 13, 6),
(11, 22, 13, 6),
(12, 26, 13, 6),
(13, 26, 13, 6),
(14, 26, 13, 6),
(15, 25, 13, 6),
(16, 27, 13, 6),
(17, 27, 13, 6),
(18, 27, 13, 6),
(19, 27, 13, 6),
(21, 27, 13, 6),
(22, 27, 13, 6),
(23, 27, 13, 6),
(24, 27, 13, 6),
(25, 27, 13, 6),
(28, 27, 13, 6),
(29, 27, 13, 6),
(32, 10, 12, 6),
(33, 27, 13, 6),
(34, 27, 13, 6),
(35, 27, 13, 6),
(36, 27, 13, 6),
(37, 27, 13, 6),
(38, 27, 13, 6),
(39, 27, 13, 6),
(40, 27, 13, 6),
(41, 27, 13, 6),
(42, 27, 13, 6),
(43, 27, 13, 6),
(44, 27, 13, 6),
(47, 27, 13, 6),
(48, 27, 13, 6),
(49, 27, 13, 6),
(50, 27, 13, 6),
(51, 27, 13, 6),
(53, 26, 13, 6),
(54, 26, 13, 6),
(55, 26, 13, 6),
(56, 26, 13, 6),
(57, 26, 13, 6),
(58, 17, 15, 6),
(59, 17, 15, 6),
(60, 17, 15, 6),
(61, 17, 15, 6),
(62, 17, 15, 6),
(63, 17, 15, 6),
(64, 17, 15, 6),
(65, 17, 15, 6),
(66, 17, 15, 6),
(67, 17, 15, 6),
(68, 17, 15, 6),
(69, 27, 14, 6),
(70, 25, 14, 6);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `afgelopendagen`
--
ALTER TABLE `afgelopendagen`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `afgelopendagen`
--
ALTER TABLE `afgelopendagen`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=71;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
