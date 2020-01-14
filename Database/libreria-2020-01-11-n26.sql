-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 12-01-2020 a las 03:26:17
-- Versión del servidor: 10.1.35-MariaDB
-- Versión de PHP: 7.2.9

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
(8, 'Adhesivoss', 0),
(9, 'Categoría XYZ', 1);

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
(1, 'Movistar', 1),
(7, 'Local', 1);

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
(1, 1, 63, '2019-10-01 00:00:00'),
(2, 1, 62, '2019-06-12 00:00:00'),
(3, 1, 64, '2019-09-11 00:00:00'),
(4, 1, 60, '2019-10-30 00:00:00'),
(10, 9, 60, '2019-12-02 00:00:00'),
(11, 9, 60, '2019-12-02 00:00:00'),
(12, 9, 60, '2019-12-02 00:00:00'),
(13, 9, 60, '2019-12-02 00:00:00'),
(14, 9, 60, '2019-12-02 00:00:00'),
(15, 9, 60, '2019-12-02 00:00:00'),
(16, 9, 60, '2019-12-02 00:00:00'),
(17, 9, 60, '0001-01-01 00:00:00'),
(18, 9, 60, '2019-12-02 00:00:00'),
(19, 9, 60, '0001-01-01 00:00:00'),
(20, 9, 60, '2019-12-02 00:00:00'),
(21, 9, 60, '2019-12-04 00:00:00');

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
(9, 15, 4, 3, '0.50'),
(10, 15, 3, 4, '1.25'),
(11, 16, 4, 3, '2.00'),
(12, 16, 3, 4, '6.00'),
(13, 16, 3, 8, '1.50'),
(14, 17, 5, 3, '3.00'),
(15, 18, 4, 2, '3.00'),
(16, 19, 5, 1, '10.00'),
(17, 20, 3, 3, '7.00'),
(18, 20, 5, 4, '9.00'),
(19, 21, 3, 9, '4.00');

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

--
-- Volcado de datos para la tabla `detalleservicio`
--

INSERT INTO `detalleservicio` (`Id`, `IdVenta`, `Cantidad`, `IdTipoServicio`) VALUES
(1, 1, 1, 1),
(2, 1, 1, 2);

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
(1, 1, 15, 2),
(2, 1, 1, 5),
(3, 1, 3, 3);

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
(1, 4, 17, 'animal-animal-photography-canidae-45242.jpg'),
(2, 4, 18, 'daweb-NodeJS.pdf'),
(3, 4, 20, 'metodos de analisis financiero.pdf'),
(4, 4, 21, 'Principios de Administracion Financiera.pdf');

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
(1, 2, '1996-10-07', '2012-12-12', '12345678-9', NULL, 1),
(8, 9, '1997-08-17', '2019-10-28', '12115678-9', NULL, 8),
(9, 10, '1996-10-16', '2019-11-03', '12903454-6', NULL, 9),
(10, 11, '1996-07-02', '2019-03-03', '23543212-3', NULL, 10),
(11, 12, '1996-07-02', '2019-03-03', '23543452-4', NULL, 11),
(12, 13, '1996-10-15', '2019-03-03', '76563212-1', NULL, 12),
(13, 14, '1996-12-12', '2018-08-15', '72843665-3', NULL, 13),
(14, 16, '1995-11-08', '2019-11-04', '23456554-4', NULL, 14);

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
(1, 'borradores.jpg', 1),
(2, 'colores.jpg', 1),
(3, 'cuaderno.jpg', 1),
(4, 'lapiceros.jpg', 1),
(5, 'zacapuntas.jpg', 1),
(6, '918hSd0uIxL._SY606_.jpg', 1),
(7, 'reglas-30-cm-personalizada-estampada-con-logo-x-300-u-D_NQ_NP_663509-MLA29866065603_042019-F.jpg', 1),
(8, 'cuaderno.jpg', 1),
(10, 'diego.jpg', 3),
(11, 'Thomas Ian Nicholas-2489968-888894.png.jfif', 3),
(12, '3cb5a588a3a7131ca0dafd6eaabb0164.jpg', 3),
(13, '3cb5a588a3a7131ca0dafd6eaabb0164.jpg', 3),
(14, '3cb5a588a3a7131ca0dafd6eaabb0164.jpg', 3),
(15, '51e527102e94624a959fbed3278351c5--stubble-beard-best-beard-styles.jpg', 3),
(16, '30711_99.jpg', 1),
(17, 'people-2202474_960_720.jpg', 3),
(18, 'copia color.jfif', 2),
(20, '30711_99.jpg', 2),
(21, 'Movistar-1-1024x870.jpg', 2),
(22, '30711_99.jpg', 2),
(23, 'copia color.jfif', 2),
(24, 'Movistar-1-1024x870.jpg', 2),
(25, 'copia color.jfif', 2),
(26, 'Movistar-1-1024x870.jpg', 2),
(27, 'Movistar-1-1024x870.jpg', 2),
(28, 'Movistar-1-1024x870.jpg', 2),
(29, 'Movistar-1-1024x870.jpg', 2),
(30, 'Movistar-1-1024x870.jpg', 2),
(31, 'Movistar-1-1024x870.jpg', 2),
(32, 'Movistar-1-1024x870.jpg', 2),
(33, 'Movistar-1-1024x870.jpg', 2),
(34, 'Movistar-1-1024x870.jpg', 2),
(35, 'Movistar-1-1024x870.jpg', 2),
(36, 'Movistar-1-1024x870.jpg', 2),
(37, 'Movistar-1-1024x870.jpg', 2),
(38, '30711_99.jpg', 1),
(39, 'Movistar-1-1024x870.jpg', 2),
(40, 'Movistar-1-1024x870.jpg', 2),
(41, 'Movistar-1-1024x870.jpg', 2),
(42, 'copia color.jfif', 2),
(43, 'Movistar-1-1024x870.jpg', 2),
(44, 'copia color.jfif', 2),
(45, 'Movistar-1-1024x870.jpg', 2),
(46, 'Digicel News Image Desktop- 395 x 288.jpg', 2),
(47, 'Movistar-1-1024x870.jpg', 2),
(48, 'copia color.jfif', 2),
(49, 'Movistar-1-1024x870.jpg', 2),
(50, 'Movistar-1-1024x870.jpg', 2),
(51, 'Movistar-1-1024x870.jpg', 2),
(52, 'Movistar-1-1024x870.jpg', 2),
(53, 'Movistar-1-1024x870.jpg', 2),
(54, 'Movistar-1-1024x870.jpg', 2),
(55, 'Movistar-1-1024x870.jpg', 2),
(56, 'Movistar-1-1024x870.jpg', 2),
(57, 'Digicel News Image Desktop- 395 x 288.jpg', 2),
(58, 'Movistar-1-1024x870.jpg', 2),
(59, 'Movistar-1-1024x870.jpg', 2),
(60, 'copia color.jfif', 2),
(61, 'Movistar-1-1024x870.jpg', 2),
(62, '30711_99.jpg', 1),
(63, 'Movistar-1-1024x870.jpg', 2),
(64, 'copia color.jfif', 2),
(65, '30711_99.jpg', 1),
(66, 'copia color.jfif', 2),
(67, 'Movistar-1-1024x870.jpg', 2),
(68, 'Movistar-1-1024x870.jpg', 2),
(69, 'Movistar-1-1024x870.jpg', 2);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `kardex`
--

CREATE TABLE `kardex` (
  `Id` int(11) NOT NULL,
  `Existencia` int(11) NOT NULL,
  `idDetalleCompra` int(11) DEFAULT NULL,
  `IdDetalleVenta` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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
(10, 'Marca XYZ', 0);

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
(1, 15, '2019-11-18 00:00:00', '2019-11-22 00:00:00'),
(2, 15, '2019-11-11 00:00:00', '2019-11-22 00:00:00'),
(3, 25, '2019-12-02 00:00:00', '2019-11-08 00:00:00'),
(4, 35, '2019-12-02 00:00:00', '2019-11-08 00:00:00'),
(5, 34, '2019-11-06 00:00:00', '2019-11-27 00:00:00'),
(6, 30, '2019-12-02 00:00:00', '2019-12-04 00:00:00');

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
(1, 1, 1, 3),
(2, 1, 4, 4),
(3, 2, 7, 5),
(4, 2, 5, 5),
(5, 3, 3, 2),
(6, 3, 2, 2),
(7, 4, 1, 5),
(8, 4, 4, 5),
(9, 5, 1, 0),
(10, 5, 3, 0),
(11, 6, 4, 3),
(12, 6, 5, NULL);

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
(2, 'Kevin Eduardo', 'Portillo Duran', '6434-5422', 1, 'Col campos II, Barrio Los Ángeles, Apastepeque, San Vicente'),
(9, 'Diego Antonio', 'Palacios Mejivar', '7111-1111', 1, 'Frente al cementerio'),
(10, 'Ian Nicolas', 'Martínez Duran', '6154-5432', 1, 'Caserio los cordova, San Francisco, San Lorenzo'),
(11, 'Alejandra Parker', 'Smith Jhonson', '6154-0987', 0, 'Blvr san pablo II, San Salvador'),
(12, 'Melissa Esmeralda', 'Duran Cordova', '7154-0932', 0, 'Blvr san pablo II, San Salvador'),
(13, 'Guillermo Carlos', 'Acevedo Cornejo', '7765-2321', 1, 'Blvr san pablo II, San Salvador'),
(14, 'Victor Ernesto', 'Acevedo Cornejo', '7123-4543', 1, '1Av norte Bo el centro casa #12, San Esteban catarina'),
(15, 'Alexander Antonio', 'Acevedo Cornejo', '6123-0987', 1, '1 Av Norte Bo el carmen, San Esteban catarina'),
(16, 'Alexander Alejandro', 'Acevedo Cornejo', '6123-0987', 1, '1 Av norte Bo el carmen, San Esteban Catarina');

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
(1, '2019-11-01', '0.20', 7),
(2, '2019-11-01', '3.25', 3),
(3, '2019-11-01', '1.00', 1),
(4, '2019-11-01', '0.25', 4),
(5, '2019-11-01', '1.00', 2),
(6, '2019-11-01', '0.20', 5),
(16, '2019-12-02', '0.75', 3),
(17, '2019-12-02', '1.25', 4),
(18, '2019-12-02', '0.60', 3),
(19, '2019-12-02', '2.10', 4),
(20, '2019-12-02', '0.75', 8),
(21, '0001-01-01', '0.90', 3),
(22, '2019-12-02', '1.25', 2),
(23, '0001-01-01', '3.00', 1),
(24, '2019-12-02', '3.00', 3),
(25, '2019-12-02', '2.00', 4),
(26, '2019-12-04', '2.50', 9);

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
(1, NULL, 1, NULL, 'Cuaderno', 3, 'Cuaderno rayado', 16, 0, '2020-02-21'),
(2, NULL, 4, NULL, 'Resistol', 1, 'Resistol', 10, 0, '2019-10-29'),
(3, NULL, 6, 2, 'Colores', 1, 'Colores', 12, 1, NULL),
(4, NULL, 3, 4, 'Lapicero', 1, 'Lapicero', 16, 1, NULL),
(5, NULL, 3, 5, 'Zacapunta', 1, 'Zacapunta', 10, 1, NULL),
(7, NULL, 3, 1, 'Borrador', 1, 'Borrador', 23, 1, NULL),
(8, NULL, 3, NULL, 'Lapix', 2, 'Un lapiz lapix', 7, 0, NULL),
(9, NULL, 9, NULL, 'Japix', 10, 'nada importante por ahora', 25, 0, NULL);

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
(60, 'SmellTech', 'Apastepeque, Bario Los angeles, Frente al Estadio Municipal, San Vicente.', 'solutions@smelltech.com', 'https://www.facebook.com/smelltech', 1),
(62, 'Libreria Rosa Maria', '1ra Av Norte Bo el centro casa #25, San Esteban Catarina', 'rosmary@gmail.com', 'http://www.rosamaria.com', 1),
(63, 'Libreria Miriam', '1ra calle poniente, Bo el centro, frente el pollo campero, San vicente', 'libreriamiriam@gmail.com', 'http://www.miriamlibreria.com', 1),
(64, 'Libreria Latinoamericana', '3ra calle oriente, Bo el calvario, San Vicente', 'latinoamericana@hotmail.com', 'http://latinoamericanalibreria.com.sv', 1),
(65, 'Libreria Emma', '4ta Av Norte, Bo el centro, San Esteban Catarina', 'emmanuelLib@hotmail.com', 'http://emmanuelLib.com.sv', 0),
(66, 'Libreria papel y lapiz', 'Blvd. el Hipodromo col. san benito local #3, San Salvador', 'papelylapiz@gmail.com', 'http://www.libreriapapel.com.sv', 0),
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

--
-- Volcado de datos para la tabla `recuperacioncuenta`
--

INSERT INTO `recuperacioncuenta` (`Id`, `IdUsuario`, `FechaEnvio`, `Codigo`, `FechaRecuperacion`, `Estado`) VALUES
(2, 8, '2020-01-10 19:00:04', 'MZYngJk9', NULL, 0),
(3, 8, '2020-01-10 19:45:58', '3UPjiIM0', NULL, 0),
(4, 8, '2020-01-10 19:46:45', 'EydcPyTd', NULL, 0),
(5, 8, '2020-01-10 19:48:24', 'PAl2r10V', NULL, 0),
(6, 8, '2020-01-10 21:15:25', 'SXUpjJnO', NULL, 0),
(7, 8, '2020-01-10 21:23:36', 'tuiDIWqT', NULL, 0),
(8, 8, '2020-01-10 21:27:22', 'LQR097Gv', NULL, 0),
(9, 8, '2020-01-10 21:31:28', '3iRsz1mb', NULL, 0),
(10, 8, '2020-01-10 23:49:29', 'PhEYmlnZ', '2020-01-10 23:50:50', 0),
(11, 8, '2020-01-11 00:08:07', 'O89L9eP8', '2020-01-11 00:09:13', 0),
(12, 8, '2020-01-11 00:14:15', 'MD4Z01dy', '2020-01-11 00:14:44', 0),
(13, 8, '2020-01-11 00:23:39', 'SBKADNdI', '2020-01-11 00:23:59', 0),
(14, 8, '2020-01-11 00:28:30', 'utGvOwaF', '2020-01-11 00:29:12', 0),
(15, 8, '2020-01-11 00:37:40', 'q6Bk2OUp', '2020-01-11 00:37:59', 0),
(16, 8, '2020-01-11 18:25:19', 'x5IDJIFS', '2020-01-11 18:26:36', 0);

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
(1, 'Copias', 1),
(3, 'Telefonia', 1);

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
(62, 60, '7543-6755', 1),
(63, 60, '7543-6750', 1),
(64, 60, '7543-6751', 0),
(65, 60, '7543-6752', 0),
(67, 62, '2334-5654', 1),
(68, 63, '2333-1540', 1),
(69, 63, '2333-0155', 0),
(70, 64, '2515-3692', 1),
(71, 64, '2500-1218', 0),
(72, 62, '7123-5666', 0),
(73, 65, '2390-9876', 1),
(74, 66, '6011-4252', 0),
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
(1, 'A Color', 1, '0.05', 7, NULL),
(2, 'Recarga', 3, '1.05', 1, NULL);

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
(1, NULL, 'TepoKev', 1, 'tepokev@gmail.com', '09876543', 0),
(8, 10, 'hackerman', 1, 'chele503@gmail.com', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1),
(9, 11, 'Ian.Duran', 0, 'IanDuran@gmail.com', 'vernesto2', 1),
(10, 12, 'Alejandra95', 0, 'Alejandra95@hotmail.com', 'Alejandra95', 1),
(11, 13, 'Melissa96', 0, 'Melissa96@hotmail.com', 'Alejandra95', 1),
(12, 14, 'Carlos.Acevedo', 0, 'carlosAce@hotmail.com', 'Alejandra95', 1),
(13, 15, 'ernesto.acevedo', 0, 'ernestoacevedo@gmail.com', 'vernesto2', 1),
(14, 17, 'Alexander.Acevedo', 0, 'AlexaAce@gmail.com', 'Acevedocornejo', 1);

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
(1, 9, '2019-12-01 22:13:47');

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
  ADD KEY `fk_IdDetalleCompra` (`idDetalleCompra`),
  ADD KEY `fk_IdDetalleVenta` (`IdDetalleVenta`);

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
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `bitacora`
--
ALTER TABLE `bitacora`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `categoria`
--
ALTER TABLE `categoria`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT de la tabla `compania`
--
ALTER TABLE `compania`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT de la tabla `compra`
--
ALTER TABLE `compra`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

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
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `detalleventa`
--
ALTER TABLE `detalleventa`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `documento`
--
ALTER TABLE `documento`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `empleado`
--
ALTER TABLE `empleado`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT de la tabla `imagen`
--
ALTER TABLE `imagen`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=70;

--
-- AUTO_INCREMENT de la tabla `kardex`
--
ALTER TABLE `kardex`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `marca`
--
ALTER TABLE `marca`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de la tabla `oferta`
--
ALTER TABLE `oferta`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de la tabla `ofertaproducto`
--
ALTER TABLE `ofertaproducto`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT de la tabla `persona`
--
ALTER TABLE `persona`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT de la tabla `precioventa`
--
ALTER TABLE `precioventa`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- AUTO_INCREMENT de la tabla `producto`
--
ALTER TABLE `producto`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT de la tabla `proveedor`
--
ALTER TABLE `proveedor`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=69;

--
-- AUTO_INCREMENT de la tabla `recuperacioncuenta`
--
ALTER TABLE `recuperacioncuenta`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT de la tabla `ruta`
--
ALTER TABLE `ruta`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `servicio`
--
ALTER TABLE `servicio`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `telefono`
--
ALTER TABLE `telefono`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=79;

--
-- AUTO_INCREMENT de la tabla `tiposervicio`
--
ALTER TABLE `tiposervicio`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `usuario`
--
ALTER TABLE `usuario`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT de la tabla `venta`
--
ALTER TABLE `venta`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

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
  ADD CONSTRAINT `fk_IdDetalleCompra` FOREIGN KEY (`idDetalleCompra`) REFERENCES `detallecompra` (`Id`),
  ADD CONSTRAINT `fk_IdDetalleVenta` FOREIGN KEY (`IdDetalleVenta`) REFERENCES `detalleventa` (`Id`);

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
