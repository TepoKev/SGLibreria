-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 12-08-2019 a las 06:25:45
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
  `Fecha` datetime NOT NULL
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
  `Nombre` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `compania`
--

CREATE TABLE `compania` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `compra`
--

CREATE TABLE `compra` (
  `Id` int(11) NOT NULL,
  `IdEmpleado` int(11) NOT NULL,
  `IdProveedor` int(11) NOT NULL,
  `Fecha` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `configuracion`
--

CREATE TABLE `configuracion` (
  `Id` int(11) NOT NULL,
  `NombreInstitucion` varchar(50) NOT NULL,
  `Logo` text NOT NULL,
  `TiempoSesion` int(11) NOT NULL,
  `Descripcion` varchar(300) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `detallecompra`
--

CREATE TABLE `detallecompra` (
  `Id` int(11) NOT NULL,
  `IdCompra` int(11) NOT NULL,
  `IdProducto` int(11) NOT NULL,
  `Cantidad` int(11) NOT NULL,
  `Precio` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `detalleservicio`
--

CREATE TABLE `detalleservicio` (
  `Id` int(11) NOT NULL,
  `IdVenta` int(11) NOT NULL,
  `Cantidad` int(11) NOT NULL,
  `IdServicio` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `detalletelefonico`
--

CREATE TABLE `detalletelefonico` (
  `Id` int(11) NOT NULL,
  `IdServicioTelefonico` int(11) NOT NULL,
  `Cantidad` int(11) NOT NULL,
  `IdVenta` int(11) NOT NULL
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

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `empleado`
--

CREATE TABLE `empleado` (
  `Id` int(11) NOT NULL,
  `IdPersona` int(11) NOT NULL,
  `FechaNacimiento` date NOT NULL,
  `FechaIngreso` date NOT NULL,
  `DUI` varchar(12) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `kardex`
--

CREATE TABLE `kardex` (
  `Id` int(11) NOT NULL,
  `IdProducto` int(11) NOT NULL,
  `Fecha` datetime NOT NULL,
  `Movimiento` char(1) NOT NULL,
  `Cantidad` int(11) NOT NULL,
  `Total` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `oferta`
--

CREATE TABLE `oferta` (
  `Id` int(11) NOT NULL,
  `Activo` tinyint(1) NOT NULL,
  `Descuento` double NOT NULL,
  `FechaInicio` datetime NOT NULL,
  `FechaFin` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ofertaproducto`
--

CREATE TABLE `ofertaproducto` (
  `Id` int(11) NOT NULL,
  `IdOferta` int(11) NOT NULL,
  `IdProducto` int(11) NOT NULL,
  `Cantidad` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `persona`
--

CREATE TABLE `persona` (
  `Id` int(11) NOT NULL,
  `Nombres` varchar(50) NOT NULL,
  `Apellidos` varchar(50) NOT NULL,
  `Telefono` varchar(9) NOT NULL,
  `Genero` varchar(8) NOT NULL,
  `IdUsuario` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `precioventa`
--

CREATE TABLE `precioventa` (
  `Id` int(11) NOT NULL,
  `IdProducto` int(11) NOT NULL,
  `Precio` float NOT NULL,
  `Estado` tinyint(1) NOT NULL,
  `Fecha` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `producto`
--

CREATE TABLE `producto` (
  `Id` int(11) NOT NULL,
  `Codigo` int(25) NOT NULL,
  `IdCategoria` int(11) NOT NULL,
  `Nombre` varchar(30) NOT NULL,
  `Marca` varchar(30) NOT NULL,
  `Descripcion` varchar(100) NOT NULL,
  `Stock` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `proveedor`
--

CREATE TABLE `proveedor` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(40) NOT NULL,
  `Direccion` varchar(300) NOT NULL,
  `Telefono` varchar(15) NOT NULL,
  `Correo` varchar(50) NOT NULL,
  `Enlace` varchar(256) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `recuperacioncuenta`
--

CREATE TABLE `recuperacioncuenta` (
  `Id` int(11) NOT NULL,
  `IdUsuario` int(11) NOT NULL,
  `FechaEnvio` datetime NOT NULL,
  `Codigo` varchar(8) NOT NULL,
  `FechaRecuperacion` datetime NOT NULL,
  `Estado` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `servicio`
--

CREATE TABLE `servicio` (
  `Id` int(11) NOT NULL,
  `IdTipo` int(11) NOT NULL,
  `Precio` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `serviciotelefonico`
--

CREATE TABLE `serviciotelefonico` (
  `Id` int(11) NOT NULL,
  `IdTipo` int(11) NOT NULL,
  `IdCompania` int(11) NOT NULL,
  `Precio` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipo`
--

CREATE TABLE `tipo` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

CREATE TABLE `usuario` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(20) NOT NULL,
  `Privilegio` int(11) NOT NULL,
  `Correo` varchar(50) NOT NULL,
  `Clave` varchar(300) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `venta`
--

CREATE TABLE `venta` (
  `Id` int(11) NOT NULL,
  `IdEmpleado` int(11) NOT NULL,
  `Fecha` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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
  ADD KEY `IdEmpleado` (`IdEmpleado`),
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
  ADD KEY `IdServicio` (`IdServicio`);

--
-- Indices de la tabla `detalletelefonico`
--
ALTER TABLE `detalletelefonico`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdServicioTelefonico` (`IdServicioTelefonico`),
  ADD KEY `IdVenta` (`IdVenta`);

--
-- Indices de la tabla `detalleventa`
--
ALTER TABLE `detalleventa`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdVenta` (`IdVenta`),
  ADD KEY `IdPrecioVenta` (`IdPrecioVenta`);

--
-- Indices de la tabla `empleado`
--
ALTER TABLE `empleado`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `IdPersona` (`IdPersona`) USING BTREE;

--
-- Indices de la tabla `kardex`
--
ALTER TABLE `kardex`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdProducto` (`IdProducto`);

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
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `IdUsuario` (`IdUsuario`) USING BTREE;

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
  ADD KEY `IdCategoria` (`IdCategoria`);

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
-- Indices de la tabla `servicio`
--
ALTER TABLE `servicio`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdTipo` (`IdTipo`);

--
-- Indices de la tabla `serviciotelefonico`
--
ALTER TABLE `serviciotelefonico`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdCompania` (`IdCompania`),
  ADD KEY `IdTipo` (`IdTipo`);

--
-- Indices de la tabla `tipo`
--
ALTER TABLE `tipo`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `venta`
--
ALTER TABLE `venta`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdEmpleado` (`IdEmpleado`);

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
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `compania`
--
ALTER TABLE `compania`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `compra`
--
ALTER TABLE `compra`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `configuracion`
--
ALTER TABLE `configuracion`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `detallecompra`
--
ALTER TABLE `detallecompra`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `detalleservicio`
--
ALTER TABLE `detalleservicio`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `detalletelefonico`
--
ALTER TABLE `detalletelefonico`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `detalleventa`
--
ALTER TABLE `detalleventa`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `empleado`
--
ALTER TABLE `empleado`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `kardex`
--
ALTER TABLE `kardex`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `oferta`
--
ALTER TABLE `oferta`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `ofertaproducto`
--
ALTER TABLE `ofertaproducto`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `persona`
--
ALTER TABLE `persona`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `precioventa`
--
ALTER TABLE `precioventa`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `producto`
--
ALTER TABLE `producto`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `proveedor`
--
ALTER TABLE `proveedor`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `recuperacioncuenta`
--
ALTER TABLE `recuperacioncuenta`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `servicio`
--
ALTER TABLE `servicio`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `serviciotelefonico`
--
ALTER TABLE `serviciotelefonico`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `tipo`
--
ALTER TABLE `tipo`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `usuario`
--
ALTER TABLE `usuario`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `venta`
--
ALTER TABLE `venta`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

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
  ADD CONSTRAINT `compra_ibfk_1` FOREIGN KEY (`IdEmpleado`) REFERENCES `empleado` (`Id`),
  ADD CONSTRAINT `compra_ibfk_2` FOREIGN KEY (`IdProveedor`) REFERENCES `proveedor` (`Id`);

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
  ADD CONSTRAINT `detalleservicio_ibfk_2` FOREIGN KEY (`IdVenta`) REFERENCES `venta` (`Id`),
  ADD CONSTRAINT `detalleservicio_ibfk_3` FOREIGN KEY (`IdServicio`) REFERENCES `servicio` (`Id`);

--
-- Filtros para la tabla `detalletelefonico`
--
ALTER TABLE `detalletelefonico`
  ADD CONSTRAINT `detalletelefonico_ibfk_1` FOREIGN KEY (`IdServicioTelefonico`) REFERENCES `serviciotelefonico` (`Id`),
  ADD CONSTRAINT `detalletelefonico_ibfk_2` FOREIGN KEY (`IdVenta`) REFERENCES `venta` (`Id`);

--
-- Filtros para la tabla `detalleventa`
--
ALTER TABLE `detalleventa`
  ADD CONSTRAINT `detalleventa_ibfk_1` FOREIGN KEY (`IdVenta`) REFERENCES `venta` (`Id`),
  ADD CONSTRAINT `detalleventa_ibfk_2` FOREIGN KEY (`IdPrecioVenta`) REFERENCES `precioventa` (`Id`);

--
-- Filtros para la tabla `empleado`
--
ALTER TABLE `empleado`
  ADD CONSTRAINT `empleado_ibfk_1` FOREIGN KEY (`IdPersona`) REFERENCES `persona` (`Id`);

--
-- Filtros para la tabla `kardex`
--
ALTER TABLE `kardex`
  ADD CONSTRAINT `kardex_ibfk_1` FOREIGN KEY (`IdProducto`) REFERENCES `producto` (`Id`);

--
-- Filtros para la tabla `ofertaproducto`
--
ALTER TABLE `ofertaproducto`
  ADD CONSTRAINT `ofertaproducto_ibfk_1` FOREIGN KEY (`IdProducto`) REFERENCES `producto` (`Id`),
  ADD CONSTRAINT `ofertaproducto_ibfk_2` FOREIGN KEY (`IdOferta`) REFERENCES `oferta` (`Id`);

--
-- Filtros para la tabla `persona`
--
ALTER TABLE `persona`
  ADD CONSTRAINT `persona_ibfk_1` FOREIGN KEY (`IdUsuario`) REFERENCES `usuario` (`Id`);

--
-- Filtros para la tabla `precioventa`
--
ALTER TABLE `precioventa`
  ADD CONSTRAINT `precioventa_ibfk_1` FOREIGN KEY (`IdProducto`) REFERENCES `producto` (`Id`);

--
-- Filtros para la tabla `producto`
--
ALTER TABLE `producto`
  ADD CONSTRAINT `producto_ibfk_1` FOREIGN KEY (`IdCategoria`) REFERENCES `categoria` (`Id`);

--
-- Filtros para la tabla `recuperacioncuenta`
--
ALTER TABLE `recuperacioncuenta`
  ADD CONSTRAINT `recuperacioncuenta_ibfk_1` FOREIGN KEY (`IdUsuario`) REFERENCES `usuario` (`Id`);

--
-- Filtros para la tabla `servicio`
--
ALTER TABLE `servicio`
  ADD CONSTRAINT `servicio_ibfk_1` FOREIGN KEY (`IdTipo`) REFERENCES `tipo` (`Id`);

--
-- Filtros para la tabla `serviciotelefonico`
--
ALTER TABLE `serviciotelefonico`
  ADD CONSTRAINT `serviciotelefonico_ibfk_1` FOREIGN KEY (`IdCompania`) REFERENCES `compania` (`Id`),
  ADD CONSTRAINT `serviciotelefonico_ibfk_2` FOREIGN KEY (`IdTipo`) REFERENCES `tipo` (`Id`);

--
-- Filtros para la tabla `venta`
--
ALTER TABLE `venta`
  ADD CONSTRAINT `venta_ibfk_1` FOREIGN KEY (`IdEmpleado`) REFERENCES `empleado` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
