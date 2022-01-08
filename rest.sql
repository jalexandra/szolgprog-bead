-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 08, 2022 at 06:24 PM
-- Server version: 10.4.17-MariaDB
-- PHP Version: 8.0.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `rest`
--

-- --------------------------------------------------------

--
-- Table structure for table `authors`
--

CREATE TABLE `authors` (
  `id` bigint(20) NOT NULL,
  `name` varchar(255) NOT NULL,
  `created_at` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `authors`
--

INSERT INTO `authors` (`id`, `name`, `created_at`) VALUES
(1, 'Syman Aiton', '2021-12-22 21:46:32'),
(2, 'Barton Foyle', '2021-12-22 21:46:32'),
(3, 'Abbot Chowne', '2021-12-22 21:46:32'),
(4, 'Georgeanna Hanham', '2021-12-22 21:46:32'),
(5, 'Betsey Remington', '2021-12-22 21:46:32'),
(6, 'Malanie Enrich', '2021-12-22 21:46:32'),
(7, 'Mahalia Sharper', '2021-12-22 21:46:32'),
(8, 'Isabelle Fearnside', '2021-12-22 21:46:32'),
(9, 'Haily Chainey', '2021-12-22 21:46:32'),
(10, 'Ursola Fouracres', '2021-12-22 21:46:32');

-- --------------------------------------------------------

--
-- Table structure for table `authors_books`
--

CREATE TABLE `authors_books` (
  `author_id` bigint(20) NOT NULL,
  `book_id` bigint(20) NOT NULL,
  `created_at` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `authors_books`
--

INSERT INTO `authors_books` (`author_id`, `book_id`, `created_at`) VALUES
(10, 2, '2021-12-22 21:47:03'),
(4, 5, '2021-12-22 21:47:03'),
(5, 1, '2021-12-22 21:47:03'),
(10, 1, '2021-12-22 21:47:03'),
(1, 5, '2021-12-22 21:47:03'),
(6, 6, '2021-12-22 21:47:03'),
(7, 9, '2021-12-22 21:47:03'),
(4, 9, '2021-12-22 21:47:03'),
(8, 1, '2021-12-22 21:47:03'),
(7, 8, '2021-12-22 21:47:03'),
(9, 2, '2021-12-22 21:47:03'),
(2, 7, '2021-12-22 21:47:03'),
(5, 6, '2021-12-22 21:47:03'),
(6, 5, '2021-12-22 21:47:03'),
(3, 4, '2021-12-22 21:47:03'),
(6, 2, '2021-12-22 21:47:03'),
(10, 2, '2021-12-22 21:47:03'),
(6, 6, '2021-12-22 21:47:03'),
(1, 10, '2021-12-22 21:47:03'),
(9, 9, '2021-12-22 21:47:03'),
(1, 6, '2021-12-22 21:47:03'),
(1, 8, '2021-12-22 21:47:03'),
(3, 5, '2021-12-22 21:47:03'),
(9, 6, '2021-12-22 21:47:03'),
(9, 5, '2021-12-22 21:47:03'),
(5, 4, '2021-12-22 21:47:03'),
(4, 1, '2021-12-22 21:47:03'),
(3, 2, '2021-12-22 21:47:03'),
(2, 3, '2021-12-22 21:47:03'),
(8, 9, '2021-12-22 21:47:03'),
(2, 9, '2021-12-22 21:47:03'),
(10, 4, '2021-12-22 21:47:03'),
(4, 3, '2021-12-22 21:47:03'),
(6, 3, '2021-12-22 21:47:03'),
(10, 1, '2021-12-22 21:47:03'),
(10, 6, '2021-12-22 21:47:03'),
(2, 9, '2021-12-22 21:47:03'),
(1, 1, '2021-12-22 21:47:03'),
(7, 3, '2021-12-22 21:47:03'),
(6, 1, '2021-12-22 21:47:03'),
(3, 6, '2021-12-22 21:47:03'),
(6, 10, '2021-12-22 21:47:03'),
(2, 1, '2021-12-22 21:47:03'),
(1, 6, '2021-12-22 21:47:03'),
(4, 5, '2021-12-22 21:47:03'),
(2, 1, '2021-12-22 21:47:03'),
(9, 5, '2021-12-22 21:47:03'),
(4, 6, '2021-12-22 21:47:03'),
(3, 8, '2021-12-22 21:47:03'),
(2, 5, '2021-12-22 21:47:03'),
(3, 10, '2021-12-22 21:47:03'),
(2, 7, '2021-12-22 21:47:03'),
(8, 2, '2021-12-22 21:47:03'),
(4, 6, '2021-12-22 21:47:03'),
(9, 7, '2021-12-22 21:47:03'),
(7, 4, '2021-12-22 21:47:03'),
(10, 6, '2021-12-22 21:47:03'),
(8, 2, '2021-12-22 21:47:03'),
(3, 5, '2021-12-22 21:47:03'),
(1, 3, '2021-12-22 21:47:03'),
(10, 7, '2021-12-22 21:47:03'),
(9, 1, '2021-12-22 21:47:03'),
(5, 8, '2021-12-22 21:47:03'),
(10, 7, '2021-12-22 21:47:03'),
(4, 8, '2021-12-22 21:47:03'),
(4, 4, '2021-12-22 21:47:03'),
(8, 6, '2021-12-22 21:47:03'),
(4, 3, '2021-12-22 21:47:03'),
(7, 10, '2021-12-22 21:47:03'),
(2, 1, '2021-12-22 21:47:03');

-- --------------------------------------------------------

--
-- Table structure for table `books`
--

CREATE TABLE `books` (
  `id` bigint(20) NOT NULL,
  `title` varchar(255) NOT NULL,
  `release_year` year(4) DEFAULT NULL,
  `rented_by` bigint(20) DEFAULT NULL,
  `created_at` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `books`
--

INSERT INTO `books` (`id`, `title`, `release_year`, `rented_by`, `created_at`) VALUES
(1, 'Morbi vel lectus in quam fringilla rhoncus.', 2005, NULL, '2021-12-22 21:47:41'),
(2, 'Nullam molestie nibh in lectus.', 1993, 3, '2021-12-22 21:47:41'),
(3, 'Duis ac nibh.', 1990, NULL, '2021-12-22 21:47:41'),
(4, 'Cras mi pede, malesuada in, imperdiet et, commodo vulputate, justo.', 1986, 1, '2021-12-22 21:47:41'),
(5, 'Phasellus id sapien in sapien iaculis congue.', 2009, 9, '2021-12-22 21:47:41'),
(6, 'Morbi non quam nec dui luctus rutrum.', 1996, NULL, '2021-12-22 21:47:41'),
(7, 'Suspendisse potenti.', 1996, NULL, '2021-12-22 21:47:41'),
(8, 'Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh.', 1997, NULL, '2021-12-22 21:47:41'),
(9, 'Nam ultrices, libero non mattis pulvinar, nulla pede ullamcorper augue, a suscipit nulla elit ac nulla.', 1992, 4, '2021-12-22 21:47:41'),
(10, 'Ut tellus.', 2003, NULL, '2021-12-22 21:47:41');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` bigint(20) NOT NULL,
  `name` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `phone` varchar(255) DEFAULT NULL,
  `email` varchar(255) NOT NULL,
  `is_admin` tinyint(4) NOT NULL DEFAULT 0,
  `api_key` varchar(255) NOT NULL,
  `created_at` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `name`, `password`, `phone`, `email`, `is_admin`, `api_key`, `created_at`) VALUES
(1, 'Patrice Lorkings', '$2y$12$qMUoD0pw.shay3v91yfXvuS7uL3rp.vNyyAUW5J4n4fVSsu/xsdUa', NULL, 'plorkings0@blogger.com', 1, '27516676-240d-4b5a-8eda-022225abf310', '2021-12-22 21:48:11'),
(2, 'Gus Barnicott', '$2y$12$qMUoD0pw.shay3v91yfXvuS7uL3rp.vNyyAUW5J4n4fVSsu/xsdUa', '+86 177 695 7917', 'gbarnicott1@yolasite.com', 0, '27516676-240d-4b5a-8eda-022225abf310', '2021-12-22 21:48:11'),
(3, 'Allys Audry', '$2y$12$qMUoD0pw.shay3v91yfXvuS7uL3rp.vNyyAUW5J4n4fVSsu/xsdUa', NULL, 'aaudry2@whitehouse.gov', 0, '27516676-240d-4b5a-8eda-022225abf310', '2021-12-22 21:48:11'),
(4, 'Jannel Keedy', '$2y$12$qMUoD0pw.shay3v91yfXvuS7uL3rp.vNyyAUW5J4n4fVSsu/xsdUa', '+55 450 811 7451', 'jkeedy3@amazon.de', 0, '27516676-240d-4b5a-8eda-022225abf310', '2021-12-22 21:48:11'),
(5, 'Morten Tonn', '$2y$12$qMUoD0pw.shay3v91yfXvuS7uL3rp.vNyyAUW5J4n4fVSsu/xsdUa', '+57 901 837 2713', 'mtonn4@google.ca', 0, '27516676-240d-4b5a-8eda-022225abf310', '2021-12-22 21:48:11'),
(6, 'Crysta Zorzi', '$2y$12$qMUoD0pw.shay3v91yfXvuS7uL3rp.vNyyAUW5J4n4fVSsu/xsdUa', NULL, 'czorzi5@vinaora.com', 0, '27516676-240d-4b5a-8eda-022225abf310', '2021-12-22 21:48:11'),
(7, 'Alicia Whitecross', '$2y$12$qMUoD0pw.shay3v91yfXvuS7uL3rp.vNyyAUW5J4n4fVSsu/xsdUa', '+7 644 305 5329', 'awhitecross6@is.gd', 0, '27516676-240d-4b5a-8eda-022225abf310', '2021-12-22 21:48:11'),
(8, 'Lanna Spender', '$2y$12$qMUoD0pw.shay3v91yfXvuS7uL3rp.vNyyAUW5J4n4fVSsu/xsdUa', '+7 558 643 3307', 'lspender7@auda.org.au', 0, '27516676-240d-4b5a-8eda-022225abf310', '2021-12-22 21:48:11'),
(9, 'Auroora Blakeborough', '$2y$12$qMUoD0pw.shay3v91yfXvuS7uL3rp.vNyyAUW5J4n4fVSsu/xsdUa', '+63 745 275 4429', 'ablakeborough8@tiny.cc', 0, '27516676-240d-4b5a-8eda-022225abf310', '2021-12-22 21:48:11'),
(10, 'Ronnica O\'Glassane', '$2y$12$qMUoD0pw.shay3v91yfXvuS7uL3rp.vNyyAUW5J4n4fVSsu/xsdUa', NULL, 'roglassane9@adobe.com', 0, '27516676-240d-4b5a-8eda-022225abf310', '2021-12-22 21:48:11');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `authors`
--
ALTER TABLE `authors`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `books`
--
ALTER TABLE `books`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `users_e-mail_uindex` (`email`),
  ADD UNIQUE KEY `users_email_uindex` (`email`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `authors`
--
ALTER TABLE `authors`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `books`
--
ALTER TABLE `books`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
