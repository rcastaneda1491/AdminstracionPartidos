-------------------------------ULTIMA MODIFICACION 28/04/2021
Create database PROYECTO_TORNEOS
go

USE	PROYECTO_TORNEOS
go
-- ---------------------- TABLA jugador ---------------
CREATE TABLE jugador(
	DPI_Jugador		bigint NOT NULL,
	Nombres			varchar(200) NOT NULL,
	Apellidos		varchar(200) NOT NULL,
	Fecha_nac		date NOT NULL,
	Direccion		varchar(250) NOT NULL,
	Nacionalidad	varchar(200) NOT NULL,
	Correo			varchar(200) NOT NULL,
	Telefono		varchar(200) NOT NULL,
	PRIMARY KEY(DPI_Jugador)
);

go
-- ---------------------- TABLA entrenador ---------------
CREATE TABLE entrenador(
	DPI				bigint NOT NULL,
	Nombre			varchar(200) NOT NULL,
	Apellidos		varchar(200) NOT NULL,
	Telefono		varchar(200) NOT NULL,
	FechaNac		date NOT NULL,
	Correo			varchar(200) NOT NULL,
	Tiempo			varchar(200) NOT NULL,
	Salario			decimal(8,2) NOT NULL,
	PRIMARY KEY(DPI)
);
go
-- ---------------------- TABLA equipo -------------
CREATE TABLE equipo(
	Id_Equipo		int NOT NULL IDENTITY(1,1),
	Nombre			varchar(200) NOT NULL,
	Representante	varchar(200) NOT NULL,
	DPI_Entrenador	bigint NOT NULL
	PRIMARY KEY(Id_Equipo)
);
go
ALTER TABLE equipo
	ADD CONSTRAINT fk_equipo_entrenador FOREIGN KEY (DPI_Entrenador)
	REFERENCES entrenador (DPI);
go
-- ---------------------- TABLA torneo ---------------
CREATE TABLE torneo(
	Id_Torneo		int NOT NULL IDENTITY(1,1),
	Nombre			varchar(200) NOT NULL,
	FechaInicio		date NOT NULL,
	FechaFinal		date NOT NULL,
	Tipo			varchar(200) NOT NULL,
	NumeroMaximoDeJugadores int NOT NULL,
	EdadMinima		int NOT NULL,
	EdadMaxima		int NOT NULL,
	PuntosVictoria	int NOT NULL,
	PuntosEmpate	int NOT NULL,
	PuntosDerrota	int NOT NULL,
	tipoFutbolTorneo varchar(200) NOT NULL,
	Costo          Float NOT NULL,
	En_Proceso     bit DEFAULT 0 NOT NULL,
	PRIMARY KEY(Id_Torneo)
);
go
-- ---------------------- TABLA torneo_equipo ---------------
CREATE TABLE torneo_equipo(
	Id_Torneo		int NOT NULL,
	Id_Equipo		int NOT NULL,
	CostoInscripcion decimal(8,2) NOT NULL,
	PRIMARY KEY(Id_Torneo,Id_Equipo)
);
go
ALTER TABLE torneo_equipo
	ADD CONSTRAINT fk_torneoEquipo_torneo FOREIGN KEY (Id_Torneo)
	REFERENCES torneo (Id_Torneo);
go
ALTER TABLE torneo_equipo
	ADD CONSTRAINT fk_torneoEquipo_equipo FOREIGN KEY (Id_Equipo)
	REFERENCES equipo (Id_Equipo);
go
-- ---------------------- TABLA posicion_jugador ---------------
CREATE TABLE posicion_jugador(
	Id_Torneo		int NOT NULL,
	Id_Equipo		int NOT NULL,
	DPI_Jugador		bigint NOT NULL,
	Posicion		varchar(200),
	NumeroCamisola	int NOT NULL,
	PRIMARY KEY(Id_Torneo,Id_Equipo,DPI_Jugador)
);
go
ALTER TABLE posicion_jugador
	ADD CONSTRAINT fk_posicion_jugador_torneo FOREIGN KEY (Id_Torneo)
	REFERENCES torneo (Id_Torneo);
go
ALTER TABLE posicion_jugador
	ADD CONSTRAINT fk_posicion_jugador_equipo FOREIGN KEY (Id_Equipo)
	REFERENCES equipo (Id_Equipo);
go
ALTER TABLE posicion_jugador
	ADD CONSTRAINT fk_posicion_jugador_jugador FOREIGN KEY (DPI_Jugador)
	REFERENCES jugador (DPI_Jugador);
go
-- ---------------------- TABLA cancha ---------------
CREATE TABLE cancha(
	NumeroCancha	int NOT NULL IDENTITY (1,1),
	Nombre			varchar(200) NOT NULL,
	TipoCancha		varchar(50) NOT NULL,
	Disponibilidad	varchar(50)NOT NULL,
	Precio_hora		decimal not null,
	PRIMARY KEY(NumeroCancha)
);
go
-- ---------------------- TABLA partido ---------------
CREATE TABLE partido(
	Id_Juego		int NOT NULL IDENTITY(1,1),
	Id_Torneo		int NOT NULL,
	Id_Cancha       int DEFAULT 1 NOT NULL,
	Id_EquipoLocal	int NOT NULL,
	Id_EquipoVisita	int NOT NULL,
	Fecha			date DEFAULT '01/01/2000' NOT NULL,
	HoraInicio		TIME DEFAULT '00:00' NOT NULL,
	HoraFinal		TIME DEFAULT '00:00' NOT NUll
	PRIMARY KEY(Id_Juego)
);

ALTER TABLE partido
	ADD CONSTRAINT fk_partido_torneo FOREIGN KEY (Id_Torneo)
	REFERENCES torneo (Id_Torneo);
go

go
ALTER TABLE partido
	ADD CONSTRAINT fk_partido_equipoLocal FOREIGN KEY (Id_EquipoLocal)
	REFERENCES equipo (Id_Equipo);
go
ALTER TABLE partido
	ADD CONSTRAINT fk_partido_equipoVisita FOREIGN KEY (Id_EquipoVisita)
	REFERENCES equipo (Id_Equipo);
go

ALTER TABLE partido
	ADD CONSTRAINT fk_partido_cancha FOREIGN KEY (Id_Cancha)
	REFERENCES cancha (NumeroCancha);
go
-- ---------------------- TABLA punteo ---------------
CREATE TABLE punteo(
	Id_Punteo		int NOT NULL IDENTITY(1,1),
	Id_Juego		int NOT NULL,
	Id_EquipoLocal	int NOT NULL,
	Id_EquipoVisita	int NOT NULL,
	PunteoEquipoLocal	int NOT NULL,
	PunteoEquipoVisita	int NOT NULL,
	PRIMARY KEY(Id_Punteo)
);
go
ALTER TABLE punteo
	ADD CONSTRAINT fk_punteo_partido FOREIGN KEY (Id_Juego)
	REFERENCES partido (Id_Juego);
go
ALTER TABLE punteo
	ADD CONSTRAINT fk_punteo_equipoLocal FOREIGN KEY (Id_EquipoLocal)
	REFERENCES equipo (Id_Equipo);
go
ALTER TABLE punteo
	ADD CONSTRAINT fk_punteo_equipoVisita FOREIGN KEY (Id_EquipoVisita)
	REFERENCES equipo (Id_Equipo);
go
-- ---------------------- TABLA punteo ---------------
CREATE TABLE cambio(
	Id_Cambio		int NOT NULL IDENTITY(1,1),
	Id_Juego		int NOT NULL,
	DPI_JugadorEntra bigint NOT NULL,
	DPI_JugadorSALE	bigint NOT NULL,
	TiempoEntrada	int default 0,
	TiempoSalida	int default 0,
	PRIMARY KEY(Id_Cambio)
);
go
ALTER TABLE cambio
	ADD CONSTRAINT fk_cambio_partido FOREIGN KEY (Id_Juego)
	REFERENCES partido (Id_Juego);
go
ALTER TABLE cambio
	ADD CONSTRAINT fk_cambio_jugadorEntra FOREIGN KEY (DPI_JugadorEntra)
	REFERENCES jugador (DPI_Jugador);
go
ALTER TABLE cambio
	ADD CONSTRAINT fk_cambio_jugadorSale FOREIGN KEY (DPI_JugadorSALE)
	REFERENCES jugador (DPI_Jugador);
go
-- ---------------------- TABLA gol ---------------
CREATE TABLE gol(
	IdGol			int NOT NULL IDENTITY(1,1),
	Id_Juego		int NOT NULL,
	DPI_Jugador		bigint NOT NULL,
	Tipo			varchar(200),
	Tiempo			varchar(200),
	PRIMARY KEY(IdGol)
);
go
ALTER TABLE gol
	ADD CONSTRAINT fk_gol_partido FOREIGN KEY (Id_Juego)
	REFERENCES partido (Id_Juego);
go
ALTER TABLE gol
	ADD CONSTRAINT fk_gol_jugador FOREIGN KEY (DPI_Jugador)
	REFERENCES jugador (DPI_Jugador);
go
-- ---------------------- TABLA arbitro ---------------
CREATE TABLE arbitro(
	DPI				bigint NOT NULL,
	Nombres			varchar(200) NOT NULL,
	Apellidos		varchar(200) NOT NULL,
	Direccion		varchar(250) NOT NULL,
	Telefono		varchar(200) NOT NULL,
	Nacionalidad	varchar(200) NOT NULL,
	FechaNac		date NOT NULL,
	Correo			varchar(200) NOT NULL,
	Rol				varchar(200) NOT NULL,
	Precio_hora		decimal not null
	PRIMARY KEY(DPI)
);
go
-- ---------------------- TABLA arbitro_partido ---------------
CREATE TABLE arbitro_partido(
	DPI_Arbitro		bigint NOT NULL,
	Id_Juego		int NOT NULL,
	Pago			decimal NOT NULL,
	PRIMARY KEY(DPI_Arbitro,Id_Juego)
);
go
ALTER TABLE arbitro_partido
	ADD CONSTRAINT fk_arbitro_partido_arbitro FOREIGN KEY (DPI_Arbitro)
	REFERENCES arbitro (DPI);
go
ALTER TABLE arbitro_partido
	ADD CONSTRAINT fk_arbitro_partido_partido FOREIGN KEY (Id_Juego)
	REFERENCES partido (Id_Juego);
go
-- ---------------------- TABLA administracion_cancha ---------------
CREATE TABLE administracion_cancha(
	Id_Status		int NOT NULL IDENTITY(1,1),
	Status_Cancha	varchar(200) NOT NULL,
	NumeroCancha	int NOT NULL,
	Id_Juego		int NOT NULL,
	PRIMARY KEY(Id_Status)
);
go
ALTER TABLE administracion_cancha
	ADD CONSTRAINT fk_administracion_cancha_cancha FOREIGN KEY (NumeroCancha)
	REFERENCES cancha (NumeroCancha);
go
ALTER TABLE administracion_cancha
	ADD CONSTRAINT fk_administracion_cancha_partido FOREIGN KEY (Id_Juego)
	REFERENCES partido (Id_Juego);
go
-- ---------------------- TABLA amonestacion ---------------
CREATE TABLE amonestacion(
	Id_Tarjeta      int NOT NULL IDENTITY(1,1), 
	ColorTarjeta	varchar(200) NOT NULL,
	Valor_multa		decimal(8,2) NOT NULL,
	Comentario		varchar(200) NOT NULL
	PRIMARY KEY(Id_Tarjeta)
);
go

-- ---------------------- TABLA registro_amonestacion ---------------
CREATE TABLE registro_amonestacion(
	id				int not null identity(1,1),
	Id_Juego		int NOT NULL,
	DPI_Jugador		bigInt NOT NULL,
	Id_Tarjeta  	int NOT NULL,
	Tiempo			varchar(200) NOT NULL,
	Pagada          varchar(2) DEFAULT 'NO'	NOT NULL,
	Fecha_Pago		varchar(200) DEFAULT 'NULL'
	PRIMARY KEY(id)
);
go
ALTER TABLE registro_amonestacion
	ADD CONSTRAINT fk_registro_amonestacion_partido FOREIGN KEY (Id_Juego)
	REFERENCES partido (Id_Juego);
go
ALTER TABLE registro_amonestacion
	ADD CONSTRAINT fk_registro_amonestacion_jugador FOREIGN KEY (DPI_Jugador)
	REFERENCES jugador (DPI_Jugador);
go
ALTER TABLE registro_amonestacion
	ADD CONSTRAINT fk_registro_amonestacion_colorTarjeta FOREIGN KEY (Id_Tarjeta)
	REFERENCES amonestacion (Id_Tarjeta);
go
-- ---------------------- TABLA registroDePartidosPorEquipoEnTorneo ---------------
CREATE TABLE registroDePartidosPorEquipoEnTorneo(
	Id_Torneo		int NOT NULL,
	Id_Equipo		int NOT NULL,
	cantidadVictoriasLocal	int NOT NULL,
	cantidadDerrotasLocal	int NOT NULL,
	cantidadEmpatesLocal	int NOT NULL,
	cantidadVictoriasVisitante	int NOT NULL,
	cantidadDerrotasVisitante	int NOT NULL,
	cantidadEmpatesVisitante	int NOT NULL,
	PRIMARY KEY(Id_Torneo,Id_Equipo)
);
go
ALTER TABLE registroDePartidosPorEquipoEnTorneo
	ADD CONSTRAINT fk_registroDePartidosPorEquipoEnTorneo_Torneo FOREIGN KEY (Id_Torneo)
	REFERENCES torneo (Id_Torneo);
go
ALTER TABLE registroDePartidosPorEquipoEnTorneo
	ADD CONSTRAINT fk_registroDePartidosPorEquipoEnTorneo_Equipo FOREIGN KEY (Id_Equipo)
	REFERENCES equipo (Id_Equipo);
go

-------------------- CLIENTE ------------------------------------
CREATE TABLE Cliente
(
	ID INT NOT NULL IDENTITY(1,1),
	DPI VARCHAR(30) NOT NULL,
	Nombres VARCHAR (200) NOT NULL,
	Apellidos VARCHAR (200) NOT NULL,
	Telefono VARCHAR (30) NOT NULL,
	Correo VARCHAR (30) NOT NULL,
	PRIMARY KEY(ID)
);
GO

-------------------- USUARIOS ------------------------------------
CREATE TABLE USUARIOS
(
	ID INT NOT NULL IDENTITY  (1,1),
	DPI VARCHAR(30) NOT NULL,
	Nombres VARCHAR (200) NOT NULL,
	Apellidos VARCHAR (200) NOT NULL,
	Usuario  VARCHAR (200) NOT NULL,
	Contrasena VARCHAR (200) NOT NULL,
	Telefono VARCHAR (30) NOT NULL,
	Direccion VARCHAR (100) NOT NULL,
	Correo VARCHAR (30) NOT NULL,
	Puesto VARCHAR (30) NOT NULL,
	Rol VARCHAR (30) NOT NULL,
	Estado BIT DEFAULT 1 NOT NULL,
	PRIMARY KEY (ID)
);
GO

-------------------- HORARIO ------------------------------------
CREATE TABLE HORARIO(
	Dia VARCHAR(20),
	HoraApertura TIME NOT NULL,
	HoraCierre TIME NOT NULL
);
GO

-------------------- BITACORA ------------------------------------
CREATE TABLE BITACORA(
	ID INT NOT NULL IDENTITY(1,1),
	IdUsuario INT  NOT NULL,
	ACCION VARCHAR(25) NOT NULL,
	FECHA DATE NOT NULL,
	HORA TIME NOT NULL
	PRIMARY KEY (ID),
	CONSTRAINT FK_ID_USUARIO FOREIGN KEY (IdUsuario) REFERENCES USUARIOS (ID),
);
GO

CREATE TABLE ALQUILER_CANCHA
(
    ID INT NOT NULL IDENTITY (1,1),
    NumeroCancha INT NOT NULL,
    IDCliente INT NOT NULL,
    FechaApartada DATE NOT NULL,
    HoraInicio TIME NOT NULL,
    HoraFinal TIME NOT NULL,
    TotalPrecio decimal(8,2) Not NULL,
    PRIMARY KEY (ID),
    CONSTRAINT FK_NumeroCancha FOREIGN KEY (NumeroCancha) REFERENCES CANCHA (NumeroCancha),
    CONSTRAINT FK_IDCliente FOREIGN KEY (IDCliente) REFERENCES CLIENTE (ID)
);
GO

CREATE TABLE ALQUILER_ARBITRO
(
    ID INT NOT NULL IDENTITY (1,1),
    FechaApartado DATE NOT NULL,
    HoraInicio TIME NOT NULL,
    HoraFinal TIME NOT NULL,
    DPIArbitro BIGINT NOT NULL ,
    IDAlquiler INT NOT NULL,
    TotalPrecioArbitro decimal(8,2) DEFAULT 0,
    PRIMARY KEY (ID),
    CONSTRAINT FK_DPIARBITRO FOREIGN KEY (DPIArbitro) REFERENCES ARBITRO (DPI),
    CONSTRAINT FK_IDALQUILER FOREIGN KEY (IDAlquiler) REFERENCES ALQUILER_CANCHA (ID)
);
GO
