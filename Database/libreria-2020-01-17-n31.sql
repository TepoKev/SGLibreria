-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 18-01-2020 a las 12:04:51
-- Versión del servidor: 10.4.11-MariaDB
-- Versión de PHP: 7.4.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `libreria`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `accion`
--

CREATE TABLE `accion` (
  `Id` int(11) NOT NULL,
  `IdBitacora` int(11) NOT NULL,
  `Descripcion` varchar(70) NOT NULL,
  `Hora` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `bitacora`
--

CREATE TABLE `bitacora` (
  `Id` int(11) NOT NULL,
  `IdUsuario` int(11) NOT NULL,
  `InicioSesion` datetime NOT NULL,
  `CierreSesion` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `bitacora`
--

INSERT INTO `bitacora` (`Id`, `IdUsuario`, `InicioSesion`, `CierreSesion`) VALUES
(22, 17, '2020-01-18 03:35:27', '2020-01-18 03:35:56'),
(23, 17, '2020-01-18 03:36:46', '0001-01-01 00:00:00'),
(24, 17, '2020-01-18 04:55:44', '0001-01-01 00:00:00'),
(25, 17, '2020-01-18 04:57:22', '0001-01-01 00:00:00');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `categoria`
--

CREATE TABLE `categoria` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(25) NOT NULL,
  `Estado` tinyint(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `categoria`
--

INSERT INTO `categoria` (`Id`, `Nombre`, `Estado`) VALUES
(1, 'Cuadernos', 1),
(3, 'Utileria', 1),
(4, 'Pegamento', 1),
(6, 'Colores', 0),
(10, 'Papeleria', 1),
(11, 'Libros', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `compania`
--

CREATE TABLE `compania` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(20) NOT NULL,
  `Estado` tinyint(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `compania`
--

INSERT INTO `compania` (`Id`, `Nombre`, `Estado`) VALUES
(8, 'Local', 1),
(9, 'Claro', 1),
(10, 'Movistar', 1),
(11, 'Tigo', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `compra`
--

CREATE TABLE `compra` (
  `Id` int(11) NOT NULL,
  `IdUsuario` int(11) NOT NULL,
  `IdProveedor` int(11) NOT NULL,
  `Fecha` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `compra`
--

INSERT INTO `compra` (`Id`, `IdUsuario`, `IdProveedor`, `Fecha`) VALUES
(58, 15, 63, '2020-01-13 00:00:00'),
(59, 15, 64, '2020-01-14 00:00:00'),
(60, 15, 64, '2020-01-14 00:00:00'),
(61, 15, 62, '2020-01-16 00:00:00'),
(62, 15, 62, '2020-01-16 00:00:00'),
(63, 15, 63, '2020-01-16 00:00:00'),
(64, 15, 63, '2020-01-16 00:00:00'),
(65, 15, 63, '2020-01-16 00:00:00'),
(66, 15, 63, '2020-01-16 00:00:00'),
(67, 15, 63, '2020-01-16 00:00:00'),
(68, 15, 63, '2020-01-16 00:00:00'),
(69, 15, 63, '2020-01-16 00:00:00'),
(70, 15, 63, '2020-01-16 00:00:00'),
(71, 15, 63, '2020-01-16 00:00:00'),
(72, 15, 63, '2020-01-16 00:00:00'),
(73, 15, 63, '2020-01-16 00:00:00'),
(74, 15, 63, '2020-01-16 00:00:00'),
(75, 15, 62, '2020-01-17 00:00:00'),
(76, 15, 62, '2020-01-16 00:00:00'),
(77, 15, 68, '2020-01-16 00:00:00'),
(78, 15, 65, '2020-01-17 00:00:00'),
(79, 15, 65, '2020-01-17 00:00:00'),
(80, 15, 68, '2020-01-17 00:00:00'),
(81, 15, 63, '2020-01-18 00:00:00'),
(82, 15, 62, '2020-01-18 00:00:00');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `configuracion`
--

CREATE TABLE `configuracion` (
  `Id` int(11) NOT NULL,
  `NombreInstitucion` varchar(50) NOT NULL,
  `Logo` text NOT NULL,
  `TiempoSesion` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `detallecompra`
--

CREATE TABLE `detallecompra` (
  `Id` int(11) NOT NULL,
  `IdCompra` int(11) NOT NULL,
  `Cantidad` int(11) NOT NULL,
  `IdProducto` int(11) NOT NULL,
  `PrecioCompra` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `detallecompra`
--

INSERT INTO `detallecompra` (`Id`, `IdCompra`, `Cantidad`, `IdProducto`, `PrecioCompra`) VALUES
(1, 78, 5, 1, '3.00'),
(2, 79, 5, 1, '3.00'),
(3, 78, 6, 2, '4.50'),
(4, 79, 6, 2, '4.50'),
(5, 80, 12, 1, '8.00'),
(7, 80, 16, 5, '12.00'),
(8, 81, 50, 1, '50.00'),
(9, 81, 25, 2, '10.00'),
(11, 81, 120, 4, '24.00'),
(12, 81, 25, 5, '5.00'),
(13, 81, 25, 7, '5.00'),
(14, 82, 10000, 10, '200.00'),
(15, 82, 15, 11, '3.00'),
(16, 82, 30, 12, '5.00'),
(18, 82, 50, 14, '5.00');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `detalleservicio`
--

CREATE TABLE `detalleservicio` (
  `Id` int(11) NOT NULL,
  `IdVenta` int(11) NOT NULL,
  `Cantidad` int(11) NOT NULL,
  `IdTipoServicio` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `detalleventa`
--

CREATE TABLE `detalleventa` (
  `Id` int(11) NOT NULL,
  `IdVenta` int(11) NOT NULL,
  `Cantidad` int(11) NOT NULL,
  `IdPrecioVenta` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `detalleventa`
--

INSERT INTO `detalleventa` (`Id`, `IdVenta`, `Cantidad`, `IdPrecioVenta`) VALUES
(1, 6, 2, 62),
(2, 6, 2, 63),
(3, 7, 3, 43),
(4, 7, 4, 42),
(5, 8, 10, 62),
(6, 9, 10, 74),
(7, 10, 15, 75);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `documento`
--

CREATE TABLE `documento` (
  `Id` int(11) NOT NULL,
  `IdRuta` int(11) NOT NULL,
  `IdCompra` int(11) NOT NULL,
  `Nombre` varchar(256) COLLATE utf8_spanish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `documento`
--

INSERT INTO `documento` (`Id`, `IdRuta`, `IdCompra`, `Nombre`) VALUES
(6, 4, 58, 'fact-billin.jpg'),
(7, 4, 59, 'lw34016625.png'),
(8, 4, 60, 'modelo-factura-es-puro-750px.png'),
(9, 4, 61, 'libreria-2019-09-10-n10.sql'),
(10, 4, 62, 'libreria-2019-09-10-n10.sql'),
(11, 4, 63, 'libreria-2019-09-10-n10.sql'),
(12, 4, 64, 'libreria-2019-09-10-n10.sql'),
(13, 4, 65, 'libreria-2019-09-10-n10.sql'),
(14, 4, 66, 'libreria-2019-09-10-n10.sql'),
(15, 4, 67, 'libreria-2019-09-10-n10.sql'),
(16, 4, 68, 'libreria-2019-09-10-n10.sql'),
(17, 4, 69, 'libreria-2019-09-10-n10.sql'),
(18, 4, 70, 'libreria-2019-09-10-n10.sql'),
(19, 4, 71, 'libreria-2019-09-10-n10.sql'),
(20, 4, 72, 'libreria-2019-09-10-n10.sql'),
(21, 4, 73, 'libreria-2019-09-10-n10.sql'),
(22, 4, 74, 'libreria-2019-09-10-n10.sql'),
(23, 4, 75, 'proxy.duckduckgo.com.jfif'),
(24, 4, 76, 'africa-animal-animals-417142.jpg'),
(25, 4, 77, 'analisis-financiero.png'),
(26, 4, 78, 'background.png'),
(27, 4, 79, 'background.png'),
(28, 4, 80, 'analisis-financiero.png'),
(29, 4, 81, 'fact-billin.jpg'),
(30, 4, 82, 'lw34016625.png');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `empleado`
--

CREATE TABLE `empleado` (
  `Id` int(11) NOT NULL,
  `IdPersona` int(11) NOT NULL,
  `FechaNacimiento` date NOT NULL,
  `FechaIngreso` date DEFAULT NULL,
  `DUI` varchar(12) NOT NULL,
  `FechaSalida` date DEFAULT NULL,
  `IdUsuario` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `empleado`
--

INSERT INTO `empleado` (`Id`, `IdPersona`, `FechaNacimiento`, `FechaIngreso`, `DUI`, `FechaSalida`, `IdUsuario`) VALUES
(16, 17, '1996-10-24', '2015-04-01', '23435489-8', NULL, 15),
(18, 19, '1997-01-15', '2019-09-06', '32653578-9', NULL, 17),
(19, 20, '1997-01-14', '2019-12-24', '23456537-5', NULL, 18),
(20, 21, '1996-10-16', '2019-11-03', '12903454-6', NULL, 19);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `imagen`
--

CREATE TABLE `imagen` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(256) COLLATE utf8_spanish_ci NOT NULL,
  `IdRuta` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `imagen`
--

INSERT INTO `imagen` (`Id`, `Nombre`, `IdRuta`) VALUES
(70, 'melissa.jpg', 3),
(71, 'ernesto.jpg', 3),
(72, 'img1.jpg', 3),
(73, 'diego.jpg', 3),
(74, '11053.webp', 1),
(75, 'RESISTOL-ESC-850-35-G-BLANCO.jpg', 1),
(76, 'colores.jpg', 1),
(77, 'lapicerobic.jpg', 1),
(78, 'zacapuntas.jpg', 1),
(79, 'borradores.jpg', 1),
(80, 'impresion.jpg', 2),
(81, 'fotocopia.jpg', 2),
(82, 'cuaderno.jpg', 2),
(83, 'claro.jpg', 2),
(84, 'dt.common.streams.StreamServer.cls.jpg', 2),
(85, '31292.jpg-1200ftw.jpg', 1),
(86, 'ian.jpg', 3),
(87, 'tijeras.jpg', 1),
(88, '38375_1_xnl.jpg', 1),
(89, 'lapiceros.jpg', 1),
(90, 'Cartulina-iris-A-4-surtido-X-10.jpg', 1),
(91, 'cervantes-quijote1.jpg', 1),
(92, '1466092263_832532_1466092430_noticia_normal.jpg', 1),
(93, 'claro.jpg', 2),
(94, '11053.webp', 1),
(95, 'fotocopia.jpg', 2),
(96, 'dt.common.streams.StreamServer.cls.jpg', 2),
(97, 'dt.common.streams.StreamServer.cls.jpg', 2),
(98, 'dt.common.streams.StreamServer.cls.jpg', 2),
(99, 'impresion.jpg', 2),
(100, 'fotocopia.jpg', 2),
(101, 'unnamed.jpg', 2),
(102, 'unnamed.jpg', 2),
(103, 'unnamed.jpg', 2),
(104, 'unnamed.jpg', 2),
(105, 'fotocopia.jpg', 2),
(106, 'fotocopia.jpg', 2),
(107, 'claro.jpg', 2),
(108, 'claro.jpg', 2),
(109, 'claro.jpg', 2),
(110, 'dt.common.streams.StreamServer.cls.jpg', 2),
(111, '11053.webp', 1),
(112, 'B3FD3505-D8EC-4556-80C6-E0FB1A94FFD1_1280x1280.jpeg.webp', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `kardex`
--

CREATE TABLE `kardex` (
  `Id` int(11) NOT NULL,
  `Existencia` int(11) NOT NULL,
  `IdDetalleCompra` int(11) DEFAULT NULL,
  `IdDetalleVenta` int(11) DEFAULT NULL,
  `IdProducto` int(11) NOT NULL,
  `Fecha` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `kardex`
--

INSERT INTO `kardex` (`Id`, `Existencia`, `IdDetalleCompra`, `IdDetalleVenta`, `IdProducto`, `Fecha`) VALUES
(1, 12, 5, NULL, 1, '2001-01-01 00:00:00'),
(3, 16, 7, NULL, 5, '0001-01-01 00:00:00'),
(4, 2, NULL, 5, 1, '2020-01-18 02:49:53'),
(6, 1, NULL, 7, 5, '2020-01-18 02:58:36'),
(7, 52, 8, NULL, 1, '2020-01-18 00:00:00'),
(8, 25, 9, NULL, 2, '2020-01-18 00:00:00'),
(10, 120, 11, NULL, 4, '2020-01-18 00:00:00'),
(11, 26, 12, NULL, 5, '2020-01-18 00:00:00'),
(12, 25, 13, NULL, 7, '2020-01-18 00:00:00'),
(13, 10000, 14, NULL, 10, '2020-01-18 00:00:00'),
(14, 15, 15, NULL, 11, '2020-01-18 00:00:00'),
(15, 30, 16, NULL, 12, '2020-01-18 00:00:00'),
(17, 50, 18, NULL, 14, '2020-01-18 00:00:00');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `marca`
--

CREATE TABLE `marca` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(25) COLLATE utf8_spanish_ci NOT NULL,
  `Estado` tinyint(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `marca`
--

INSERT INTO `marca` (`Id`, `Nombre`, `Estado`) VALUES
(1, 'Facela', 1),
(2, 'Norma', 1),
(3, 'Scribe', 1),
(9, 'Bic', 1),
(11, 'KYG', 1),
(12, 'Holman', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `oferta`
--

CREATE TABLE `oferta` (
  `Id` int(11) NOT NULL,
  `Descuento` double NOT NULL,
  `FechaInicio` datetime NOT NULL,
  `FechaFin` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `oferta`
--

INSERT INTO `oferta` (`Id`, `Descuento`, `FechaInicio`, `FechaFin`) VALUES
(9, 50, '2020-01-12 00:00:00', '2020-01-13 00:00:00'),
(10, 25, '2020-01-16 00:00:00', '2020-01-18 00:00:00'),
(11, 25, '2020-01-16 00:00:00', '2020-01-18 00:00:00'),
(12, 25, '2020-01-16 00:00:00', '2020-01-18 00:00:00');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ofertaproducto`
--

CREATE TABLE `ofertaproducto` (
  `Id` int(11) NOT NULL,
  `IdOferta` int(11) NOT NULL,
  `IdProducto` int(11) NOT NULL,
  `Cantidad` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `ofertaproducto`
--

INSERT INTO `ofertaproducto` (`Id`, `IdOferta`, `IdProducto`, `Cantidad`) VALUES
(19, 9, 1, 1),
(20, 9, 4, 1),
(21, 9, 10, 1),
(22, 10, 1, 1),
(23, 10, 2, 1),
(24, 11, 1, 1),
(25, 11, 2, 1),
(26, 12, 1, 1),
(27, 12, 2, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `persona`
--

CREATE TABLE `persona` (
  `Id` int(11) NOT NULL,
  `Nombres` varchar(50) NOT NULL,
  `Apellidos` varchar(50) NOT NULL,
  `Telefono` varchar(9) NOT NULL,
  `Genero` int(11) NOT NULL,
  `Direccion` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `persona`
--

INSERT INTO `persona` (`Id`, `Nombres`, `Apellidos`, `Telefono`, `Genero`, `Direccion`) VALUES
(17, 'Melissa Esmeralda', 'Duran Cordova', '7143-4354', 0, 'San Lorenzo, Canton San Francisco, Caserio los cordova'),
(19, 'Kevin Eduardo', 'Duran Portillo', '6123-0987', 1, 'col san francisco, Apastepeque'),
(20, 'Diego Antonio', 'Palacios Menjivar', '6678-5654', 1, 'Col San francisco, frente al cementerio, apastepeque'),
(21, 'Ian Nicolas', 'Martínez Duran', '6154-5432', 1, 'Caserio los cordova, San Francisco, San Lorenzo');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `precioventa`
--

CREATE TABLE `precioventa` (
  `Id` int(11) NOT NULL,
  `Fecha` date NOT NULL,
  `Valor` decimal(10,2) NOT NULL,
  `IdProducto` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `precioventa`
--

INSERT INTO `precioventa` (`Id`, `Fecha`, `Valor`, `IdProducto`) VALUES
(35, '2020-01-13', '3.00', 1),
(36, '2020-01-13', '1.00', 2),
(37, '2020-01-13', '1.50', 3),
(38, '2020-01-13', '0.50', 4),
(39, '2020-01-13', '0.35', 5),
(40, '2020-01-13', '0.35', 7),
(41, '2020-01-14', '0.02', 10),
(42, '2020-01-14', '1.50', 11),
(43, '2020-01-14', '0.60', 12),
(44, '2020-01-14', '0.30', 13),
(45, '2020-01-14', '0.50', 14),
(46, '2020-01-14', '5.00', 15),
(47, '2020-01-14', '0.35', 16),
(48, '2020-01-14', '1.50', 1),
(49, '2020-01-14', '0.70', 2),
(50, '2020-01-14', '1.50', 3),
(51, '2020-01-14', '0.50', 4),
(58, '2020-01-16', '5.00', 15),
(59, '2020-01-16', '5.00', 15),
(60, '2020-01-16', '5.00', 15),
(61, '2020-01-16', '5.00', 15),
(62, '2020-01-17', '1.00', 1),
(63, '2020-01-17', '0.75', 2),
(64, '2020-01-16', '1.00', 1),
(65, '2020-01-16', '1.25', 2),
(66, '2020-01-16', '1.25', 1),
(67, '2020-01-16', '1.00', 2),
(68, '2020-01-16', '1.10', 3),
(69, '2020-01-17', '1.10', 1),
(70, '2020-01-17', '1.10', 1),
(71, '2020-01-17', '1.13', 2),
(72, '2020-01-17', '1.13', 2),
(73, '2020-01-17', '1.00', 1),
(74, '2020-01-17', '1.25', 3),
(75, '2020-01-17', '1.35', 5),
(76, '2020-01-18', '3.00', 1),
(77, '2020-01-18', '0.90', 2),
(78, '2020-01-18', '1.50', 3),
(79, '2020-01-18', '0.50', 4),
(80, '2020-01-18', '0.40', 5),
(81, '2020-01-18', '0.35', 7),
(82, '2020-01-18', '5.00', 10),
(83, '2020-01-18', '1.25', 11),
(84, '2020-01-18', '0.50', 12),
(85, '2020-01-18', '0.60', 13),
(86, '2020-01-18', '0.50', 14),
(87, '2020-01-18', '4.00', 15);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `producto`
--

CREATE TABLE `producto` (
  `Id` int(11) NOT NULL,
  `Codigo` varchar(25) DEFAULT NULL,
  `IdCategoria` int(11) NOT NULL,
  `IdImagen` int(11) DEFAULT NULL,
  `Nombre` varchar(30) NOT NULL,
  `IdMarca` int(11) DEFAULT NULL,
  `Descripcion` varchar(100) DEFAULT NULL,
  `StockMinimo` int(11) NOT NULL,
  `Estado` tinyint(3) NOT NULL,
  `FechaVencimiento` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `producto`
--

INSERT INTO `producto` (`Id`, `Codigo`, `IdCategoria`, `IdImagen`, `Nombre`, `IdMarca`, `Descripcion`, `StockMinimo`, `Estado`, `FechaVencimiento`) VALUES
(1, '202000001', 1, 111, 'Cuaderno', 3, 'Cuaderno rayado', 10, 0, '2020-02-21'),
(2, '202000002', 4, 75, 'Resistol', 1, 'Resistol', 10, 0, '2019-10-29'),
(3, '202000003', 6, 76, 'Colores', 1, 'Colores', 5, 0, NULL),
(4, NULL, 3, 77, 'Lapicero', 1, 'Lapicero', 24, 0, NULL),
(5, NULL, 3, 78, 'Zacapunta', 1, 'Zacapunta', 10, 0, NULL),
(7, NULL, 3, 79, 'Borrador', 1, 'Borrador', 10, 0, NULL),
(10, NULL, 3, 85, 'Papel bond', 1, 'resma de papel bond tipo carta', 2500, 0, NULL),
(11, NULL, 3, 87, 'Tijera', 11, 'tijera tamaño grande', 5, 0, NULL),
(12, NULL, 3, 88, 'Correptor', 9, 'Correptor de 5 oz', 5, 0, NULL),
(13, NULL, 3, 89, 'Lapicero', 9, 'Lapiceros de todos colores', 5, 0, NULL),
(14, NULL, 10, 90, 'Cartulina', 2, 'cartulina de 1x1m', 5, 0, NULL),
(15, NULL, 11, 91, 'Don Quijote de la mancha', 12, 'obra llamada don quijote de la mancha', 3, 0, NULL),
(16, NULL, 3, 92, 'Borrador', 1, 'Borrador de 2 colores', 4, 0, NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `proveedor`
--

CREATE TABLE `proveedor` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(40) NOT NULL,
  `Direccion` varchar(300) DEFAULT NULL,
  `Correo` varchar(50) DEFAULT NULL,
  `Enlace` varchar(256) DEFAULT NULL,
  `Estado` tinyint(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `proveedor`
--

INSERT INTO `proveedor` (`Id`, `Nombre`, `Direccion`, `Correo`, `Enlace`, `Estado`) VALUES
(62, 'Libreria Rosa Maria', '1ra Av Norte Bo el centro casa #25, San Esteban Catarina', 'rosmary@gmail.com', 'http://www.rosamaria.com', 1),
(63, 'Libreria Miriam', '1ra calle poniente, Bo el centro, frente el pollo campero, San vicente', 'libreriamiriam@gmail.com', 'http://www.miriamlibreria.com', 1),
(64, 'Libreria Latinoamericana', '3ra calle oriente, Bo el calvario, San Vicente', 'latinoamericana@hotmail.com', 'http://latinoamericanalibreria.com.sv', 1),
(65, 'Libreria Emma', '4ta Av Norte, Bo el centro, San Esteban Catarina', 'emmanuelLib@hotmail.com', 'http://emmanuelLib.com.sv', 1),
(66, 'Libreria papel y lapiz', 'Blvd. el Hipodromo col. san benito local #3, San Salvador', 'papelylapiz@gmail.com', 'http://www.libreriapapel.com.sv', 1),
(67, 'libreria  aranda', 'san vicente', 'aranda@gmail.com', NULL, 1),
(68, 'Librería don Diego', '4ta avenida norte, Apastecuba', 'diego@gmail.com', NULL, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `recuperacioncuenta`
--

CREATE TABLE `recuperacioncuenta` (
  `Id` int(11) NOT NULL,
  `IdUsuario` int(11) NOT NULL,
  `FechaEnvio` datetime NOT NULL,
  `Codigo` varchar(8) NOT NULL,
  `FechaRecuperacion` datetime DEFAULT NULL,
  `Estado` tinyint(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ruta`
--

CREATE TABLE `ruta` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(128) COLLATE utf8_spanish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `ruta`
--

INSERT INTO `ruta` (`Id`, `Nombre`) VALUES
(1, 'Productos'),
(2, 'Servicios'),
(3, 'Empleados'),
(4, 'Comprobantes');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `servicio`
--

CREATE TABLE `servicio` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(20) NOT NULL,
  `Estado` tinyint(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `servicio`
--

INSERT INTO `servicio` (`Id`, `Nombre`, `Estado`) VALUES
(4, 'Copias', 1),
(5, 'Impresion', 1),
(6, 'Telefonico', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `telefono`
--

CREATE TABLE `telefono` (
  `Id` int(11) NOT NULL,
  `IdProveedor` int(11) NOT NULL,
  `Numero` varchar(15) COLLATE utf8_spanish_ci NOT NULL,
  `Principal` tinyint(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `telefono`
--

INSERT INTO `telefono` (`Id`, `IdProveedor`, `Numero`, `Principal`) VALUES
(67, 62, '2334-5654', 1),
(68, 63, '2333-1540', 1),
(69, 63, '2333-0155', 0),
(70, 64, '2515-3692', 1),
(71, 64, '2500-1218', 0),
(72, 62, '7123-5666', 0),
(73, 65, '2390-9876', 1),
(74, 66, '6011-4252', 1),
(76, 67, '2222-2345', 1),
(77, 68, '76768989', 1),
(78, 68, '76768983', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tiposervicio`
--

CREATE TABLE `tiposervicio` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(50) NOT NULL,
  `IdServicio` int(11) NOT NULL,
  `Precio` decimal(10,2) NOT NULL,
  `IdCompania` int(11) NOT NULL,
  `IdImagen` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `tiposervicio`
--

INSERT INTO `tiposervicio` (`Id`, `Nombre`, `IdServicio`, `Precio`, `IdCompania`, `IdImagen`) VALUES
(3, 'A Color', 4, '0.10', 8, 80),
(4, 'A Color', 5, '0.15', 8, 81),
(5, 'Recarga', 6, '1.05', 9, 93),
(6, 'Recarga', 6, '2.10', 9, 83),
(7, 'Recarga', 6, '1.05', 10, 84),
(8, 'Miniatura', 4, '0.05', 8, 105),
(9, 'Recarga', 6, '2.10', 10, 96),
(12, 'Fotografia', 5, '0.50', 8, 99),
(13, 'Blanco-Negro', 4, '0.02', 8, 106),
(14, 'Recarga', 6, '1.05', 11, 101),
(15, 'Recarga', 6, '2.10', 11, 102);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

CREATE TABLE `usuario` (
  `Id` int(11) NOT NULL,
  `IdImagen` int(11) DEFAULT NULL,
  `Nombre` varchar(20) NOT NULL,
  `Privilegio` int(11) NOT NULL,
  `Correo` varchar(50) DEFAULT NULL,
  `Clave` varchar(300) NOT NULL,
  `Estado` tinyint(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `usuario`
--

INSERT INTO `usuario` (`Id`, `IdImagen`, `Nombre`, `Privilegio`, `Correo`, `Clave`, `Estado`) VALUES
(15, 70, 'melyEsme', 1, 'tetoymely030915@gmail.com', '156912c3ccd315b8b0904a0c19dd08c920af37c32c1950f31036bf298660acba', 1),
(16, 71, 'vernesto', 1, 'vacevedo242@gmail.com', '0f5741f4135e6274400c83e5f45fd8cebf6d1e9a496f3a41fee91d1b8321506f', 1),
(17, 72, 'TepoKev', 1, 'tepokev@gmail.com', '3f962ebfc273e56c8147c5ae51b546cc72cad513d5cde0d9addcccb5ae16078c', 1),
(18, 73, 'diegon', 1, 'palaciosdiego759@gmail.com', 'd68089c77e65ee87eb9504f68212289f6dcb758fae1955a824018a67c5cb2e2f', 1),
(19, 86, 'Ian.Duran', 0, 'melyyteto030915@gmail.com', 'b1d096f1bb57e734f8362fa66fcea92860ee9213012005ee5d7f6505de98d861', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `venta`
--

CREATE TABLE `venta` (
  `Id` int(11) NOT NULL,
  `IdUsuario` int(11) NOT NULL,
  `Fecha` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `venta`
--

INSERT INTO `venta` (`Id`, `IdUsuario`, `Fecha`) VALUES
(3, 15, '2020-01-14 09:52:31'),
(4, 15, '2020-01-14 09:52:51'),
(5, 15, '2020-01-14 09:53:04'),
(6, 15, '2020-01-17 04:02:58'),
(7, 15, '2020-01-17 04:09:52'),
(8, 16, '2020-01-18 02:49:53'),
(9, 16, '2020-01-18 02:57:15'),
(10, 16, '2020-01-18 02:58:36');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `accion`
--
ALTER TABLE `accion`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdBitacora` (`IdBitacora`);

--
-- Indices de la tabla `bitacora`
--
ALTER TABLE `bitacora`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdUsuario` (`IdUsuario`);

--
-- Indices de la tabla `categoria`
--
ALTER TABLE `categoria`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `compania`
--
ALTER TABLE `compania`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `compra`
--
ALTER TABLE `compra`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdEmpleado` (`IdUsuario`),
  ADD KEY `IdProveedor` (`IdProveedor`);

--
-- Indices de la tabla `configuracion`
--
ALTER TABLE `configuracion`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `detallecompra`
--
ALTER TABLE `detallecompra`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdCompra` (`IdCompra`),
  ADD KEY `IdProducto` (`IdProducto`);

--
-- Indices de la tabla `detalleservicio`
--
ALTER TABLE `detalleservicio`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdVenta` (`IdVenta`),
  ADD KEY `IdTipoServicio` (`IdTipoServicio`);

--
-- Indices de la tabla `detalleventa`
--
ALTER TABLE `detalleventa`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdVenta` (`IdVenta`),
  ADD KEY `IdPrecioVenta` (`IdPrecioVenta`);

--
-- Indices de la tabla `documento`
--
ALTER TABLE `documento`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdCompra` (`IdCompra`),
  ADD KEY `IdRuta` (`IdRuta`);

--
-- Indices de la tabla `empleado`
--
ALTER TABLE `empleado`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `IdPersona` (`IdPersona`) USING BTREE,
  ADD UNIQUE KEY `IdUsuario` (`IdUsuario`);

--
-- Indices de la tabla `imagen`
--
ALTER TABLE `imagen`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdRuta` (`IdRuta`);

--
-- Indices de la tabla `kardex`
--
ALTER TABLE `kardex`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `fk_IdDetalleVenta` (`IdDetalleVenta`),
  ADD KEY `fk_IdDetalleCompra` (`IdDetalleCompra`) USING BTREE,
  ADD KEY `IdProducto` (`IdProducto`);

--
-- Indices de la tabla `marca`
--
ALTER TABLE `marca`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `oferta`
--
ALTER TABLE `oferta`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `ofertaproducto`
--
ALTER TABLE `ofertaproducto`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdProducto` (`IdProducto`),
  ADD KEY `IdOferta` (`IdOferta`);

--
-- Indices de la tabla `persona`
--
ALTER TABLE `persona`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `precioventa`
--
ALTER TABLE `precioventa`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdProducto` (`IdProducto`);

--
-- Indices de la tabla `producto`
--
ALTER TABLE `producto`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdCategoria` (`IdCategoria`),
  ADD KEY `IdImagen` (`IdImagen`),
  ADD KEY `IdMarca` (`IdMarca`);

--
-- Indices de la tabla `proveedor`
--
ALTER TABLE `proveedor`
  ADD PRIMARY KEY (`Id`) USING BTREE;

--
-- Indices de la tabla `recuperacioncuenta`
--
ALTER TABLE `recuperacioncuenta`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdUsuario` (`IdUsuario`);

--
-- Indices de la tabla `ruta`
--
ALTER TABLE `ruta`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `servicio`
--
ALTER TABLE `servicio`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `telefono`
--
ALTER TABLE `telefono`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `fk_idProveedor` (`IdProveedor`);

--
-- Indices de la tabla `tiposervicio`
--
ALTER TABLE `tiposervicio`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdCompania` (`IdCompania`),
  ADD KEY `IdServicio` (`IdServicio`),
  ADD KEY `IdImagen` (`IdImagen`);

--
-- Indices de la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdImagen` (`IdImagen`);

--
-- Indices de la tabla `venta`
--
ALTER TABLE `venta`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdEmpleado` (`IdUsuario`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `accion`
--
ALTER TABLE `accion`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT de la tabla `bitacora`
--
ALTER TABLE `bitacora`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- AUTO_INCREMENT de la tabla `categoria`
--
ALTER TABLE `categoria`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT de la tabla `compania`
--
ALTER TABLE `compania`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT de la tabla `compra`
--
ALTER TABLE `compra`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=83;

--
-- AUTO_INCREMENT de la tabla `configuracion`
--
ALTER TABLE `configuracion`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `detallecompra`
--
ALTER TABLE `detallecompra`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT de la tabla `detalleservicio`
--
ALTER TABLE `detalleservicio`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `detalleventa`
--
ALTER TABLE `detalleventa`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT de la tabla `documento`
--
ALTER TABLE `documento`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT de la tabla `empleado`
--
ALTER TABLE `empleado`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT de la tabla `imagen`
--
ALTER TABLE `imagen`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=113;

--
-- AUTO_INCREMENT de la tabla `kardex`
--
ALTER TABLE `kardex`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT de la tabla `marca`
--
ALTER TABLE `marca`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT de la tabla `oferta`
--
ALTER TABLE `oferta`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT de la tabla `ofertaproducto`
--
ALTER TABLE `ofertaproducto`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- AUTO_INCREMENT de la tabla `persona`
--
ALTER TABLE `persona`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT de la tabla `precioventa`
--
ALTER TABLE `precioventa`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=88;

--
-- AUTO_INCREMENT de la tabla `producto`
--
ALTER TABLE `producto`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT de la tabla `proveedor`
--
ALTER TABLE `proveedor`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=69;

--
-- AUTO_INCREMENT de la tabla `recuperacioncuenta`
--
ALTER TABLE `recuperacioncuenta`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT de la tabla `ruta`
--
ALTER TABLE `ruta`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `servicio`
--
ALTER TABLE `servicio`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de la tabla `telefono`
--
ALTER TABLE `telefono`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=79;

--
-- AUTO_INCREMENT de la tabla `tiposervicio`
--
ALTER TABLE `tiposervicio`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT de la tabla `usuario`
--
ALTER TABLE `usuario`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT de la tabla `venta`
--
ALTER TABLE `venta`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `accion`
--
ALTER TABLE `accion`
  ADD CONSTRAINT `accion_ibfk_1` FOREIGN KEY (`IdBitacora`) REFERENCES `bitacora` (`Id`);

--
-- Filtros para la tabla `bitacora`
--
ALTER TABLE `bitacora`
  ADD CONSTRAINT `bitacora_ibfk_1` FOREIGN KEY (`IdUsuario`) REFERENCES `usuario` (`Id`);

--
-- Filtros para la tabla `compra`
--
ALTER TABLE `compra`
  ADD CONSTRAINT `compra_ibfk_2` FOREIGN KEY (`IdProveedor`) REFERENCES `proveedor` (`Id`),
  ADD CONSTRAINT `compra_ibfk_3` FOREIGN KEY (`IdUsuario`) REFERENCES `usuario` (`Id`);

--
-- Filtros para la tabla `detallecompra`
--
ALTER TABLE `detallecompra`
  ADD CONSTRAINT `detallecompra_ibfk_1` FOREIGN KEY (`IdCompra`) REFERENCES `compra` (`Id`),
  ADD CONSTRAINT `detallecompra_ibfk_2` FOREIGN KEY (`IdProducto`) REFERENCES `producto` (`Id`);

--
-- Filtros para la tabla `detalleservicio`
--
ALTER TABLE `detalleservicio`
  ADD CONSTRAINT `detalleservicio_ibfk_4` FOREIGN KEY (`IdVenta`) REFERENCES `venta` (`Id`),
  ADD CONSTRAINT `detalleservicio_ibfk_5` FOREIGN KEY (`IdTipoServicio`) REFERENCES `tiposervicio` (`Id`);

--
-- Filtros para la tabla `detalleventa`
--
ALTER TABLE `detalleventa`
  ADD CONSTRAINT `detalleventa_ibfk_1` FOREIGN KEY (`IdVenta`) REFERENCES `venta` (`Id`),
  ADD CONSTRAINT `detalleventa_ibfk_2` FOREIGN KEY (`IdPrecioVenta`) REFERENCES `precioventa` (`Id`);

--
-- Filtros para la tabla `documento`
--
ALTER TABLE `documento`
  ADD CONSTRAINT `Documento_ibfk_2` FOREIGN KEY (`IdCompra`) REFERENCES `compra` (`Id`),
  ADD CONSTRAINT `documento_ibfk_1` FOREIGN KEY (`IdRuta`) REFERENCES `ruta` (`Id`);

--
-- Filtros para la tabla `empleado`
--
ALTER TABLE `empleado`
  ADD CONSTRAINT `empleado_ibfk_1` FOREIGN KEY (`IdPersona`) REFERENCES `persona` (`Id`),
  ADD CONSTRAINT `empleado_ibfk_2` FOREIGN KEY (`IdUsuario`) REFERENCES `usuario` (`Id`);

--
-- Filtros para la tabla `imagen`
--
ALTER TABLE `imagen`
  ADD CONSTRAINT `imagen_ibfk_1` FOREIGN KEY (`IdRuta`) REFERENCES `ruta` (`Id`);

--
-- Filtros para la tabla `kardex`
--
ALTER TABLE `kardex`
  ADD CONSTRAINT `fk_IdDetalleCompra` FOREIGN KEY (`IdDetalleCompra`) REFERENCES `detallecompra` (`Id`),
  ADD CONSTRAINT `fk_IdDetalleVenta` FOREIGN KEY (`IdDetalleVenta`) REFERENCES `detalleventa` (`Id`),
  ADD CONSTRAINT `kardex_ibfk_1` FOREIGN KEY (`IdProducto`) REFERENCES `producto` (`Id`);

--
-- Filtros para la tabla `ofertaproducto`
--
ALTER TABLE `ofertaproducto`
  ADD CONSTRAINT `ofertaproducto_ibfk_1` FOREIGN KEY (`IdProducto`) REFERENCES `producto` (`Id`),
  ADD CONSTRAINT `ofertaproducto_ibfk_2` FOREIGN KEY (`IdOferta`) REFERENCES `oferta` (`Id`);

--
-- Filtros para la tabla `precioventa`
--
ALTER TABLE `precioventa`
  ADD CONSTRAINT `precioventa_ibfk_1` FOREIGN KEY (`IdProducto`) REFERENCES `producto` (`Id`);

--
-- Filtros para la tabla `producto`
--
ALTER TABLE `producto`
  ADD CONSTRAINT `producto_ibfk_1` FOREIGN KEY (`IdCategoria`) REFERENCES `categoria` (`Id`),
  ADD CONSTRAINT `producto_ibfk_2` FOREIGN KEY (`IdImagen`) REFERENCES `imagen` (`Id`),
  ADD CONSTRAINT `producto_ibfk_3` FOREIGN KEY (`IdMarca`) REFERENCES `marca` (`Id`);

--
-- Filtros para la tabla `recuperacioncuenta`
--
ALTER TABLE `recuperacioncuenta`
  ADD CONSTRAINT `recuperacioncuenta_ibfk_1` FOREIGN KEY (`IdUsuario`) REFERENCES `usuario` (`Id`);

--
-- Filtros para la tabla `telefono`
--
ALTER TABLE `telefono`
  ADD CONSTRAINT `fk_idProveedor` FOREIGN KEY (`IdProveedor`) REFERENCES `proveedor` (`Id`);

--
-- Filtros para la tabla `tiposervicio`
--
ALTER TABLE `tiposervicio`
  ADD CONSTRAINT `tiposervicio_ibfk_1` FOREIGN KEY (`IdCompania`) REFERENCES `compania` (`Id`),
  ADD CONSTRAINT `tiposervicio_ibfk_2` FOREIGN KEY (`IdServicio`) REFERENCES `servicio` (`Id`),
  ADD CONSTRAINT `tiposervicio_ibfk_3` FOREIGN KEY (`IdImagen`) REFERENCES `imagen` (`Id`);

--
-- Filtros para la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD CONSTRAINT `usuario_ibfk_1` FOREIGN KEY (`IdImagen`) REFERENCES `imagen` (`Id`);

--
-- Filtros para la tabla `venta`
--
ALTER TABLE `venta`
  ADD CONSTRAINT `venta_ibfk_1` FOREIGN KEY (`IdUsuario`) REFERENCES `usuario` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
