-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 11, 2023 at 05:48 PM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `ethereum-future`
--
CREATE DATABASE IF NOT EXISTS `ethereum-future` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `ethereum-future`;

-- --------------------------------------------------------

--
-- Table structure for table `futureprices`
--

DROP TABLE IF EXISTS `futureprices`;
CREATE TABLE `futureprices` (
  `id` int(11) NOT NULL,
  `date` varchar(45) NOT NULL,
  `price` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `futureprices`
--

INSERT INTO `futureprices` (`id`, `date`, `price`) VALUES
(2, '12.06.2023', '1759.45'),
(3, '13.06.2023', '1764.22'),
(4, '14.06.2023', '1800.45'),
(5, '15.06.2023', '2200.12');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `futureprices`
--
ALTER TABLE `futureprices`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `futureprices`
--
ALTER TABLE `futureprices`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
