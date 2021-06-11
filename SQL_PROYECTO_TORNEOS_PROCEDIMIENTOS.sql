USE	PROYECTO_TORNEOS;
GO
---------------------------------Procedimiento de Torneo Julio Garcia
CREATE PROC JCGO_SELEC_TORNEO @Id_Torneo INT
	AS
	SELECT * FROM torneo WHERE Id_Torneo = @Id_Torneo
GO

CREATE PROC JCGO_SELEC_TORNEOS 
	AS
	SELECT * FROM torneo
GO

go
CREATE PROC JCGO_INSERT_TORNEO @Nombre varchar(200), @FechaInicio date , @FechaFinal	date ,@Tipo	varchar(200) ,@NumeroMaximoDeJugadores int, @EdadMinima int ,@EdadMaxima	int ,@PuntosVictoria int,@PuntosEmpate int ,@PuntosDerrota int ,@tipoFutbolTorneo varchar(200),@Costo float
	AS INSERT INTO torneo (Nombre, FechaInicio, FechaFinal, Tipo, NumeroMaximoDeJugadores,EdadMinima ,EdadMaxima ,PuntosVictoria ,PuntosEmpate  ,PuntosDerrota, tipoFutbolTorneo,Costo) VALUES(@Nombre, @FechaInicio, @FechaFinal, @Tipo, @NumeroMaximoDeJugadores,@EdadMinima ,@EdadMaxima ,@PuntosVictoria ,@PuntosEmpate  ,@PuntosDerrota, @tipoFutbolTorneo,@Costo)
go 

CREATE PROC JCGO_UPDATE_TORNEO  @Id_Torneo INT, @Nombre varchar(200), @FechaInicio date , @FechaFinal	date ,@Tipo	varchar(200) ,@NumeroMaximoDeJugadores int, @EdadMinima int ,@EdadMaxima	int ,@PuntosVictoria int,@PuntosEmpate int ,@PuntosDerrota int, @tipoFutbolTorneo varchar(200),@Costo float, @En_Proceso  bit
	AS	UPDATE torneo SET Nombre = @Nombre,FechaInicio = @FechaInicio, FechaFinal = @FechaFinal, Tipo = @Tipo, NumeroMaximoDeJugadores = @NumeroMaximoDeJugadores,EdadMinima = @EdadMinima ,EdadMaxima = @EdadMaxima,PuntosVictoria = @PuntosVictoria ,PuntosEmpate = @PuntosEmpate  ,PuntosDerrota = @PuntosDerrota, tipoFutbolTorneo = @tipoFutbolTorneo, Costo=@Costo, En_Proceso = @En_Proceso WHERE Id_Torneo = @Id_Torneo
go
CREATE PROC JCGO_DELETE_TORNEO @Id_Torneo INT
	AS DELETE FROM torneo WHERE Id_Torneo = @Id_Torneo
go

---************************************************************PROCEDIMIENTOS ALMACENADOS DE AMONESTACION 22/04/2021 Julio Garcia*******************************************--
----Insertar Amonestacion
CREATE PROC JCGO_INSERT_AMONESTACION @ColorTarjeta varchar(200), @Valor_multa decimal(8,2),@Comentario varchar(200) 
	AS INSERT INTO amonestacion (ColorTarjeta,Valor_multa,Comentario) VALUES (@ColorTarjeta,@Valor_multa,@Comentario)
go
----Modificar Amonestacion
CREATE PROC JCGO_UPDATE_AMONESTACION @Id_Tarjeta int, @ColorTarjeta varchar(200), @Valor_multa decimal(8,2),@Comentario varchar(200) 
	AS UPDATE amonestacion SET ColorTarjeta=@ColorTarjeta,Valor_multa=@Valor_multa,Comentario=@Comentario where Id_Tarjeta =@Id_Tarjeta
go
----Eliminar Amonestacion
CREATE PROC JCGO_DELETE_AMONESTACION @Id_Tarjeta int
	AS DELETE FROM amonestacion WHERE Id_Tarjeta = @Id_Tarjeta
go

-----***************************************************************ENFRENTAMIENTOS JULIO GARCIA, JOSE CURTIDOR, STEVE GILL 23/04/2021********************************************--
-------PROCEDIMIENTO QUE TRAE EQUIPO POR ID
create proc J_J_S_getEquipos @id int
	as
	select * from TORNEO_EQUIPO
	where Id_Torneo=@id
go

-------PROCEDIMIENTO QUE GUARDA ENFRENTAMIENTO
CREATE PROC JCGO_JORNADAS @Id_Torneo int, @Id_EquipoLocal int, @Id_EquipoVisita int
	AS 
	INSERT INTO partido (Id_Torneo, Id_EquipoLocal, Id_EquipoVisita) VALUES(@Id_Torneo, @Id_EquipoLocal, @Id_EquipoVisita)
go

---------------------Actualiza el torneo a en PROCESO
CREATE PROC JCGO_UPDATE_TORNEO_PROCESO @Id_Torneo INT
	AS
	UPDATE torneo SET En_Proceso = 1 WHERE Id_Torneo = @Id_Torneo
GO

------------------------------------------------Registro de Amonestacion JULIO GARCIA----------------------------------
---------Procedimientos de Partido a Amonestacion
CREATE PROC JCGO_GET_AMONESTACION @Id_Juego INT, @DPI_Jugador INT, @Id_Tarjeta INT 
	AS
	SELECT * FROM registro_amonestacion WHERE Id_Juego = @Id_Juego AND DPI_Jugador = @DPI_Jugador AND Id_Tarjeta = @Id_Tarjeta 
GO

CREATE PROC JCGO_GET_TARJETAS
	AS
	SELECT A.Id_Tarjeta, A.ColorTarjeta FROM amonestacion A
GO

-------------Trae el nombre de los equipos que jugaron en el partido
CREATE PROC JCGO_Equipos_Partido @Id_Juego INT
	AS
	SELECT p.Id_EquipoLocal, E.Nombre AS Equipo_Local, p.Id_EquipoVisita, EQ.Nombre AS Equipo_Visita FROM partido P INNER JOIN equipo E ON P.Id_EquipoLocal = E.Id_Equipo INNER JOIN equipo EQ ON P.Id_EquipoVisita = EQ.Id_Equipo WHERE P.Id_Juego = @Id_Juego
GO

---------------------Obtiene los jugadores del equipo
CREATE PROC JCGO_Jugadores_Equipo @Id_Equipo INT
	AS
	SELECT J.DPI_Jugador, J.Nombres, J.Apellidos FROM jugador J INNER JOIN posicion_jugador P ON  P.DPI_Jugador = J.DPI_Jugador WHERE P.Id_Equipo = @Id_Equipo
GO

---------------------Obtiene DPI de Jugador
CREATE PROC JCGO_DPI_Jugador @Nombres varchar(200), @Apellidos varchar(200)
	AS
	SELECT J.DPI_Jugador FROM jugador J WHERE J.Nombres = @Nombres and J.Apellidos = @Apellidos
GO

----------------------Guardar Regostro de Amonestacion
CREATE PROC JCGO_Insert_registro_amonestacion   @Id_Juego int, @DPI_Jugador bigInt, @Id_Tarjeta  int, @Tiempo varchar(200)
	AS
	INSERT INTO registro_amonestacion(Id_Juego,DPI_Jugador,Id_Tarjeta,Tiempo)VALUES(@Id_Juego,@DPI_Jugador,@Id_Tarjeta,@Tiempo)
GO

----------------------Actualizar Registro de Amonestacion
CREATE PROC JCGO_Updatet_registro_amonestacion @Id_Juego int, @DPI_Jugador bigInt, @Id_Tarjeta  int, @Tiempo varchar(200), @Buscar_DPI_Jugador bigInt, @Buscar_Id_Tarjeta int
	AS 
	UPDATE registro_amonestacion SET DPI_Jugador=@DPI_Jugador,Id_Tarjeta=@Id_Tarjeta, Tiempo=@Tiempo where  Id_Juego=@Id_Juego AND DPI_Jugador = @Buscar_DPI_Jugador AND Id_Tarjeta = @Buscar_Id_Tarjeta
GO

----------------------Eliminar Registro de Amonestacion
CREATE PROC JCGO_Delete_Registro_amonestacion @Id_Juego int, @DPI_Jugador bigInt, @Id_Tarjeta  int
	AS DELETE FROM registro_amonestacion WHERE Id_Juego = @Id_Juego AND DPI_Jugador = @DPI_Jugador AND Id_Tarjeta = @Id_Tarjeta
GO

----------------------Procedimiento Arbitro Partido JULIO GARCIA
---------------------Obtiene DPI de arbitro
CREATE PROC JCGO_GET_DPI_ARBITRO @Nombres varchar(200), @Apellidos varchar(200)
	AS
	SELECT A.DPI FROM arbitro A WHERE A.Nombres = @Nombres AND A.Apellidos = @Apellidos
GO
--------------------Guardar Arbitro_Partido
CREATE PROC JCGO_Insert_Arbitro_Partido @DPI_Arbitro bigint,@Id_Juego int,@Pago Decimal
	AS
	INSERT INTO arbitro_partido(DPI_Arbitro,Id_Juego,Pago)VALUES(@DPI_Arbitro,@Id_Juego,@Pago)
GO

--------------------Modificar Arbitro_Partido
CREATE PROC JCGO_Update_Arbitro_Partido @DPI_Arbitro bigint,@Id_Juego int,@Pago Decimal,  @DPI_Arbitro_Buscar bigint
	AS
	UPDATE arbitro_partido SET DPI_Arbitro = @DPI_Arbitro,Pago = @Pago WHERE DPI_Arbitro = @DPI_Arbitro_Buscar AND Id_Juego = @Id_Juego
GO

-- ##################################################################################################################
--									PROCEDIMIENTOS Erick Echeverria
-- ##################################################################################################################
create proc proc_erick_cargar_idYnombresDeEquipo
as
	select Id_Equipo,Nombre from equipo;
go
create proc proc_erick_cargar_idYnombresDeTorneo
as
	select Id_Torneo,Nombre from torneo;
go
create proc proc_erick_obtener_costoDeTorneo @Id_Torneo int
as
	select Costo
	from torneo
	where Id_Torneo = @Id_Torneo
go
create proc proc_erick_cargar_equiposEnTorneo @Id_Torneo int
as
	select *
	from torneo_equipo
	where Id_Torneo = @Id_Torneo;
go
create proc proc_erick_contarJugadoresEnElEquipoMismoTorneo @Id_Torneo int, @Id_Equipo int
as
	select COUNT(*)
	from torneo_equipo
	WHERE Id_Torneo = @Id_Torneo
	and Id_Equipo = @Id_Equipo;
go
create proc proc_erick_obtenerTorneoComenzado @Id_Torneo int
as
	select	torneo.En_Proceso
	from torneo
	where Id_Torneo = @Id_Torneo;
go
create proc proc_erick_obtenerEquiposMismoTorneo @Id_Torneo int
as
	select *
	from equipo
	WHERE Id_Equipo IN (SELECT Id_Equipo FROM torneo_equipo WHERE Id_Torneo = @Id_Torneo);
go
create proc proc_erick_obtenerJugadoresDelEquipo @Id_Torneo int, @Id_Equipo int
as
	SELECT posicion_jugador.Id_Torneo, torneo.Nombre, posicion_jugador.Id_Equipo, equipo.Nombre, posicion_jugador.DPI_Jugador, jugador.Nombres, jugador.Apellidos, posicion_jugador.Posicion, posicion_jugador.NumeroCamisola
	FROM posicion_jugador
	INNER JOIN jugador on jugador.DPI_Jugador = posicion_jugador.DPI_Jugador
	INNER JOIN torneo on torneo.Id_Torneo = posicion_jugador.Id_Torneo
	INNER JOIN equipo on equipo.Id_Equipo = posicion_jugador.Id_Equipo
	WHERE posicion_jugador.Id_Torneo = @Id_Torneo
	and posicion_jugador.Id_Equipo = @Id_Equipo;
go
create proc proc_erick_obtenerEdadDeJugador @DPI bigInt
as
	Select floor(
	(cast(convert(varchar(8),getdate(),112) as int)-
	cast(convert(varchar(8),jugador.Fecha_nac,112) as int) ) / 10000
	) as Edad from jugador where DPI_Jugador = @DPI;
go
create proc proc_erick_obtenerEdadMinimaTorneo @Id_Torneo int
as
	SELECT EdadMinima
	FROM torneo WHERE Id_Torneo = @Id_Torneo;
go
create proc proc_erick_obtenerEdadMaximaTorneo @Id_Torneo int
as
	SELECT EdadMaxima
	FROM torneo WHERE Id_Torneo = @Id_Torneo;
go
create proc proc_erick_obtenerMaximoJugadores @Id_Torneo int
as
	SELECT NumeroMaximoDeJugadores
	FROM torneo WHERE Id_Torneo = @Id_Torneo;
go
create proc proc_erick_obtenerCantidadJugadoresEnEquipo @Id_Torneo int, @Id_Equipo int
as
	SELECT COUNT(*) 
	FROM jugador
	WHERE DPI_Jugador IN(
		SELECT DPI_Jugador FROM posicion_jugador
		WHERE Id_Torneo = @Id_Torneo and Id_Equipo = @Id_Equipo);
go
create proc proc_erick_cargar_DPI_Nombres_deJugadores
as
	SELECT DPI_Jugador,Nombres + Apellidos As NombreCompleto
	FROM jugador;
go
create proc proc_erick_obtenerCantidadJugadoresConNumeroDeCamiseta @Id_Torneo int, @Id_Equipo int, @NumeroCamisola int
as
	SELECT COUNT(*)
	FROM posicion_jugador
	WHERE Id_Torneo = @Id_Torneo
	AND Id_Equipo = @Id_Equipo
	AND NumeroCamisola = @NumeroCamisola;
go
create proc proc_erick_obtenerJugadorDiferenteEquipoMismoTorneo @Id_Torneo int, @DPI_Jugador bigInt
as
	SELECT COUNT(*)
	FROM posicion_jugador
	WHERE Id_Torneo = @Id_Torneo
	AND DPI_Jugador = @DPI_Jugador;
go
create proc proc_erick_obtenerPartidosDeTorneo @id_torneo int
as
	select  p.Id_Juego,e.Nombre equipo_local ,ee.Nombre equipo_visita,p.Fecha, p.HoraInicio, p.HoraFinal from partido p 
	inner join equipo e
	on p.Id_EquipoLocal=e.Id_Equipo  
	inner join equipo ee 
	on p.Id_EquipoVisita=ee.Id_Equipo
	inner join torneo t
	on t.Id_Torneo=p.Id_Torneo
	where p.Id_Torneo = @id_torneo
go
create proc proc_erick_obtenerPunteoYaRealizado @Id_Juego int
as
	SELECT COUNT(*)
	FROM punteo
	where Id_Juego = @Id_Juego;
go
create proc proc_erick_obtenerPunteoEquipoLocal @Id_Juego int
as
	SELECT PunteoEquipoLocal
	FROM punteo
	where Id_Juego = @Id_Juego;
go
create proc proc_erick_obtenerPunteoEquipoVisita @Id_Juego int
as
	SELECT PunteoEquipoVisita
	FROM punteo
	where Id_Juego = @Id_Juego;
go
create proc proc_erick_obtenerIdLocal @Id_Juego int
as
	Select Id_EquipoLocal
	from punteo
	where Id_Juego = @Id_Juego;
go
create proc proc_erick_obtenerGolesJuego @Id_Juego int
as
	select gol.IdGol, gol.Id_Juego,gol.DPI_Jugador,jugador.Nombres+jugador.Apellidos AS NombreJugador ,gol.Tipo,gol.Tiempo
	from gol, jugador
	where gol.DPI_Jugador = jugador.DPI_Jugador
	and Id_Juego = @Id_Juego;
go
create proc proc_erick_obtenerGolesDeEquipoTorneo @Id_Equipo int, @Id_Torneo int
as
	select count(*)
	from gol
	where EXISTS(select * from posicion_jugador
				where gol.DPI_Jugador = posicion_jugador.DPI_Jugador
				and posicion_jugador.Id_Equipo = @Id_Equipo
				and posicion_jugador.Id_Torneo = @Id_Torneo);
go
create proc proc_erick_obtenerJugadoresDeEquipos @Id_Torneo int, @Id_Equipo1 int, @Id_Equipo2 int
as
	SELECT posicion_jugador.Id_Torneo, torneo.Nombre, posicion_jugador.Id_Equipo, equipo.Nombre, posicion_jugador.DPI_Jugador, jugador.Nombres, jugador.Apellidos, posicion_jugador.Posicion, posicion_jugador.NumeroCamisola
	FROM posicion_jugador
	INNER JOIN jugador on jugador.DPI_Jugador = posicion_jugador.DPI_Jugador
	INNER JOIN torneo on torneo.Id_Torneo = posicion_jugador.Id_Torneo
	INNER JOIN equipo on equipo.Id_Equipo = posicion_jugador.Id_Equipo
	WHERE posicion_jugador.Id_Torneo = @Id_Torneo
	and posicion_jugador.Id_Equipo = @Id_Equipo1
	or posicion_jugador.Id_Equipo = @Id_Equipo2;
go
create proc proc_erick_obtenerIdEquipoSeleccionado @Nombre varchar(200)
as
	SELECT Id_Equipo
	FROM equipo WHERE Nombre = @Nombre;
go


-- ##################################################################################################################
--									PROCEDIMIENTOS Bryan Steve
-- ##################################################################################################################

--Muestras las canchas 

create Proc BG_Muestra_Cancha
as
select * From cancha
go

--Insertar Cancha 

CREATE PROC BG_Insertar_Cancha  @Nombre varchar(100),@TipoCancha varchar(50),@Disponibilidad varchar(50), @Precio_hora decimal
AS
insert into cancha(Nombre,TipoCancha,Disponibilidad, Precio_hora)values(@Nombre,@TipoCancha,@Disponibilidad, @Precio_hora);
go


--modifica Cancha
create proc  BG_Editar_Cancha @NumeroCancha int,@Nombre varchar(100),@TipoCancha varchar(50),@Disponibilidad varchar(50), @Precio_hora decimal
as
update cancha set Nombre=@Nombre,TipoCancha=@TipoCancha,Disponibilidad=@Disponibilidad, Precio_hora=@Precio_hora where NumeroCancha =@NumeroCancha
go


--eliminar cancha
create proc BG_eliminar_Cancha  @NumeroCancha int
as
delete from cancha where NumeroCancha=@NumeroCancha
go

--Mostrar Equipos
create proc BG_Mostrar_Equipos
as
select*from equipo;
go



-- Insertar un equipo 
CREATE PROC BG_Insertar_Equipo @Nombre varchar(100),@Representante varchar(100),@DPI_Entrenador Bigint
AS
insert into Equipo(Nombre,Representante,DPI_Entrenador)values(@Nombre,@Representante,@DPI_Entrenador);
go


--Actualizar Equipo

create proc BG_Editar_Equipo  @Id_Equipo int,@Nombre varchar(100),@Representante varchar(100),@DPI_Entrenador Bigint
as
update equipo set Nombre=@Nombre,Representante=@Representante,DPI_Entrenador=@DPI_Entrenador where Id_Equipo =@Id_Equipo
go


create proc BG_eliminar_equipo  @Id_equipo int
as
delete from equipo where Id_Equipo=@Id_equipo
go



-- ##################################################################################################################
--									PROCEDIMIENTOS JOSE CURTIDOR
-- ##################################################################################################################

go
--*************Tabla jugadores ********* Jose brayan curtidot 
--BUSCAR JUGADORES
create proc J_C_getalljugadores
as
select*from jugador;

--exec J_C_getalljugadores
GO
--INSERTAR

CREATE PROC J_C_INSETAR_JUGADOR @DPI_Jugador bigint,@Nombres varchar(100),@Apellidos varchar(100),@Fecha_nac date,@Direccion varchar(100),@Nacionalidad varchar (100),@Correo varchar(100),@Telefono varchar(100)
AS
insert into jugador(DPI_Jugador,Nombres,Apellidos,Fecha_nac,Direccion,Nacionalidad,Correo,Telefono)values(@DPI_Jugador,@Nombres,@Apellidos,@Fecha_nac,@Direccion,@Nacionalidad,@Correo,@Telefono);
--exec J_C_INSETAR_JUGADOR 111111111,'lurdes','perez','2001/01/01','zona 15','jutiapa','@lurdes','1234567899871231'
go

--buscar jugador por su id
create proc J_C_buscar_jugador_por_id @dpi_jugador bigint
as
select*from jugador where DPI_Jugador=@dpi_jugador
--exec J_C_buscar_jugador_por_id '1'

go
--UPDATE JUGADORES 
create proc J_C_editar_jugadores  @DPI_Jugador bigint,@Nombres varchar(100),@Apellidos varchar(100),@Fecha_nac date,@Direccion varchar(100),@Nacionalidad varchar(100),@Correo varchar(100),@Telefono varchar(100)
as
update jugador set Nombres=@Nombres,Apellidos=@Apellidos,Fecha_nac=@Fecha_nac,Direccion=@Direccion, Nacionalidad=@Nacionalidad,Correo=@Correo, Telefono=@Telefono where DPI_Jugador=@DPI_Jugador
--exec J_C_editar_jugadores '8','LEO','DAN','01/02/2025','Mexicana 15 av','Mexicana','@leodan','13825'
go

--delete jugadores
create proc J_B_eliminar_jugador  @dpi bigint
as
delete from jugador where DPI_Jugador=@dpi
--exec J_B_eliminar_jugador '1'
go



--***************procedimientos para la vista Encuentros DB*************** jose brayan curtidor
create proc J_C_vista_de_los_encuentros @id_torneo int
as
select  p.Id_Torneo,t.Nombre Nombre_torneo,e.Nombre equipo_local ,ee.Nombre equipo_visita from partido p 
inner join equipo e
on p.Id_EquipoLocal=e.Id_Equipo  
inner join equipo ee 
on p.Id_EquipoVisita=ee.Id_Equipo
inner join torneo t
on t.Id_Torneo=p.Id_Torneo
where p.Id_Torneo=@id_torneo 
go


--exec J_C_vista_de_los_encuentros @id_torneo

go



--***************PROCEDIMITNOS PARA ELPAGO DE AMONESTACIONES*********** JOSE BRAYAN CURTIDOR
--buscar tods los registros de la tbala registro amonestacion
create proc J_B_get_all_registro_amonestacion
as
select*from registro_amonestacion
--exec J_B_get_all_registro_amonestacion
go

--buscar un registro a traves de el codigo juego
create proc J_B_busqueda_registro_pago_id_codigo @Id_Juego int
as			

select*from registro_amonestacion where Id_Juego=@Id_Juego
--exec J_B_busqueda_registro_pago_id_codigo @Id_Juego=2
go

--actualizar el registro_targetas
create proc J_C_actualizar_pagos @Id_Juego int,@dpi bigint,@id_tarjeta int,@Pagada varchar(100),@Fecha_Pago date
as
update registro_amonestacion set Pagada=@Pagada,Fecha_Pago= @Fecha_Pago where Id_Juego=@Id_Juego and DPI_Jugador=@dpi and Id_Tarjeta=@id_tarjeta
go




--*************PROCESOS PARA LA TABLA CAMBIOS***********JOSE BRAYAN CURTIDOR
--BUSCAR CAMBIOS
create proc J_Cgetall_cambios
as
select*from cambio
--exec J_Cgetall_cambios
go



--buscar solo un registro de la tabla partido para mostrar info en los labels
create proc J_B_busqueda_solo_un_registr_tabla_partido @id_juego int
as
select*from partido  where Id_Juego=@id_juego
--exec J_B_busqueda_solo_un_registr_tabla_partido @id_juego=2
go



--buscar el registro de solo un equipo para mostrar al usuario en los labels
create proc J_B_buscar_soloun_equipo @id_equipo int
as
select*from equipo where Id_Equipo=@id_equipo;
--exec J_B_buscar_soloun_equipo @id_equipo=1
go




create proc J_B_Jugadores_de_equipos_enfrentamiento @id_juego int
as
select j2.Nombres from jugador j2
where j2.DPI_Jugador =any
(
select j.DPI_Jugador from posicion_jugador j
where Id_Equipo =any(select p.Id_EquipoLocal  from partido p 
where p.Id_Juego=@id_juego)
or Id_Equipo =any ( select p.Id_EquipoVisita  from partido p 
where p.Id_Juego=@id_juego)
)
--exec J_B_Jugadores_de_equipos_enfrentamiento @id_juego=2

go

--BUSCAR DPI  del jugador a travez del nombre
create proc J_B_buscar_jugador_por_nombre @nombres varchar(100)
as
select pj.DPI_Jugador,pj.Id_Equipo from posicion_jugador pj where pj.DPI_Jugador=(
select j.DPI_Jugador from jugador j where j.Nombres=@nombres)
--exec J_B_buscar_jugador_por_nombre @nombres=cristiano
go



--BUSQUEDA DE NOMBRE DE EQUIPOS POR codifo de equipo
create proc J_B_buscar_nombre_equipo_codigo_equipo @id_equipo int
as
select Nombre from equipo where Id_Equipo = @id_equipo
--exec J_B_buscar_nombre_equipo_codigo_equipo @id_equipo=4

go



create proc J_C_Agregar_cambio @Id_Juego int,@DPI_JugadorEntra bigint,@DPI_JugadorSALE bigint,@TiempoEntrada varchar(100),@TiempoSalida varchar(100)
as
insert into cambio(Id_Juego,DPI_JugadorEntra,DPI_JugadorSALE,TiempoEntrada,TiempoSalida)values(@Id_Juego,@DPI_JugadorEntra,@DPI_JugadorSALE,@TiempoEntrada,@TiempoSalida)
--exec J_C_Agregar_cambio @Id_Juego,@DPI_JugadorEntra,@DPI_JugadorSALE,@TiempoEntrada,@TiempoSalida
go



create proc J_C_buscar_editar_cambio @Id_Cambio int 
as
SELECT*FROM cambio  WHERE Id_Cambio=@Id_Cambio
--exec J_C_buscar_editar_cambio  @Id_Cambio=2
go



--ACTUALIZAR LA TABLA CAMBIOS 

create proc J_C_actualizar_cambios @Id_Cambio int,@DPI_JugadorEntra bigint,@DPI_JugadorSALE bigint,@TiempoEntrada varchar(100),@TiempoSalida varchar(100)
as
update cambio set DPI_JugadorEntra=@DPI_JugadorEntra,DPI_JugadorSALE=@DPI_JugadorSALE,TiempoEntrada=@TiempoEntrada,TiempoSalida=@TiempoSalida where Id_Cambio=@Id_Cambio
--exec J_C_actualizar_cambios @Id_Cambio,@DPI_JugadorEntra,@DPI_JugadorSALE,@TiempoEntrada,@TiempoSalida
go

create proc J_C_eliminar_sustitucion @Id_Cambio int
as
delete from cambio where Id_Cambio=@Id_Cambio
--exec J_C_eliminar_sustitucion @Id_Cambio

go


-- ##################################################################################################################
--									PROCEDIMIENTOS LOURDES AGUIRRE
-- ##################################################################################################################

--Arbitro 

create proc LA_insertar_Arbitro @DPI bigint, @nombre varchar(100), @apellido varchar(100), 
@direccion varchar(100), @telefono varchar(100), @nacionalidad varchar(100), @fechaNac date, 
@email varchar(100), @rol varchar(100), @precio_hora decimal
as insert into arbitro(DPI, Nombres, Apellidos, Direccion, Telefono, Nacionalidad, FechaNac, Correo, Rol, Precio_hora) values(@DPI, @nombre, @apellido,
@direccion, @telefono, @nacionalidad, @fechaNac, @email, @rol, @precio_hora);
go

create proc LA_actualizar_Arbitro @DPI bigint, @nombre varchar(100), @apellido varchar(100), 
@direccion varchar(100), @telefono varchar(100), @nacionalidad varchar(100), @fechaNac date, 
@email varchar(100), @rol varchar(100), @precio_hora decimal
as update arbitro set Nombres = @nombre, Apellidos = @apellido, Direccion = @direccion, Telefono = @telefono, Nacionalidad = @nacionalidad,
FechaNac = @fechaNac, Correo = @email, Rol = @rol, Precio_hora = @precio_hora where DPI = @DPI;
go

create proc LA_eliminar_Arbitro @DPI bigint 
as delete from arbitro where DPI = @DPI;
go

create proc LA_obtener_Arbitros as 
select * from arbitro
go

create proc LA_obtener_arbitro_por_dpi @DPI bigint
as select * from arbitro where DPI = @DPI;
go

create proc LA_agregar_Entrenador @DPI bigint, @nombre varchar(100), @apellido varchar(100), @telefono varchar(100), 
@fecha_Nacimineto date, @correo varchar(100), @tiempo varchar(100), @salario decimal 
as insert into entrenador(DPI, Nombre, Apellidos, Telefono, FechaNac, Correo, Tiempo, Salario) 
values(@DPI, @nombre, @apellido, @telefono, @fecha_Nacimineto, @correo, @tiempo, @salario);
go

--Entrenador 

create proc LA_actualizar_Entrenador @DPI bigint, @nombre varchar(100), @apellido varchar(100), @telefono varchar(100), 
@fecha_Nacimiento date, @correo varchar(100), @tiempo varchar(100), @salario decimal 
as update entrenador set Nombre = @nombre, Apellidos = @apellido, Telefono = @telefono, FechaNac = @fecha_Nacimiento,
Correo = @correo, Tiempo = @tiempo, Salario = @salario where DPI = @DPI;
go

create proc LA_eliminar_Entrenador @DPI bigint
as delete from entrenador where DPI = @DPI;
go

create proc LA_obtner_Entrenadores 
as select * from entrenador;
go

create proc LA_obtner_Entrenador_Por_DPI @DPI bigint 
as select * from entrenador where DPI = @DPI;
go

create proc LA_obtener_dpi_entrenadores @nombre varchar(100), @apellido varchar(100)
as 
select DPI
from entrenador where Nombre = @nombre and Apellidos = @apellido
go

create proc LA_odpie @apellido varchar(100)
as select DPI
from entrenador
where Apellidos = @apellido;
GO

create proc LA_obtener_Apellido_Entrenadores @nombre varchar(100)
as select Apellidos from entrenador where Nombre = @nombre
go

create proc LA_obtner_Nombre_Entrenadores as
select distinct nombre from entrenador
go

---------------------------------Lourdes Aguirre

create proc LA_buscarIdCanchaPorNombre @nombre varchar(100) as
select NumeroCancha
from cancha where Nombre = @nombre  
go

create proc LA_obtenerFechaInicioTornero @id int as
select FechaInicio
from torneo where Id_Torneo = @id
go

create proc LA_obtenerFechaFinTorneo @id int as 
select FechaFinal
from torneo where Id_Torneo = @id;
go

create proc LA_actualizarDetallesPartido @idPartido int, @idCancha int, @fecha date, @horaInicio time, @horafin time
as 
update partido set Id_Cancha = @idCancha, Fecha = @fecha, HoraInicio = @horaInicio, HoraFinal = @horafin where Id_Juego = @idPartido
go

--****arreglos sprint 2   AGREGAR A LA BASES DE DATOS************************************************************jose brayan curtidor agregar a la base de datos 28/04/2021

create proc J_C_buscar_nombre_jugador_apellido_segun_dpi @DPI_Jugador bigint
as
select CONCAT(Nombres,CONCAT(' ',apellidos)) from jugador where DPI_Jugador=@DPI_Jugador
--exec J_C_buscar_nombre_jugador_apellido_segun_dpi @DPI_Jugador=123

--procedimientos para mejorasr la vista de cambios
go

create proc J_C_busqueda_equipos_id_juego_nombresss @Id_Juego int,@id_torneo int
as
select e.Nombre,ee.Nombre from partido p
inner join equipo e
on p.Id_EquipoLocal=e.Id_Equipo
inner join equipo ee 
on p.Id_EquipoVisita=ee.Id_Equipo
where Id_Juego=@Id_Juego  and p.Id_Torneo=@id_torneo;

--exec J_C_busqueda_equipos_id_juego_nombresss  @Id_Juego=2,@id_torneo=1
go
--buscar los jugadores segun el equipo

create proc J_C_buscar_los_nombres__juga_de_equipoosssss @nombre_equipo varchar(100),@id_torneo int
as
select DISTINCT  j.Nombres from posicion_jugador pj
inner join jugador j
on j.DPI_Jugador=pj.DPI_Jugador
inner join equipo e
on pj.Id_Equipo=e.Id_Equipo
inner join torneo_equipo te
on pj.Id_Torneo=te.Id_Torneo
where e.Nombre=@nombre_equipo and  te.Id_Torneo=@id_torneo

--exec J_C_buscar_los_nombres__juga_de_equipoosssss @nombre_equipo=chelsea,@id_torneo=1
go

--LA OBTENCION DE HORAS DE LOS PARTIDOS

create proc J_C_obtener_horas_de_partido  @Id_Juego int
as
select HoraInicio,HoraFinal from partido where Id_Juego=@Id_Juego;
--exec J_C_obtener_horas_de_partido @Id_Juego=3

go


create proc obtner_Nombre_Entrenadores
as 
Select Nombre
FROM entrenador;
go

create proc obtener_Apellido_Entrenadores @Nombre varchar(200)
as 
Select Apellidos
FROM entrenador
Where Nombre = @Nombre;
go


--REporete targetas por quipos------------------------------------------------------
go

create view registr_targetas_rojas
as
select pj.Id_Equipo,COUNT(pj.Id_Equipo) targetas_rojas
from registro_amonestacion ram
right join posicion_jugador pj
on ram.DPI_Jugador=pj.DPI_Jugador
right join amonestacion a
on ram.Id_Tarjeta=a.Id_Tarjeta

where a.ColorTarjeta='roja'
group by pj.Id_Equipo


go

create view registr_targetas_amariilas
as
select pj.Id_Equipo,COUNT(pj.Id_Equipo) targetas_amarillas
from registro_amonestacion ram
right join posicion_jugador pj
on ram.DPI_Jugador=pj.DPI_Jugador
right join amonestacion a
on ram.Id_Tarjeta=a.Id_Tarjeta

where a.ColorTarjeta='amarilla'
group by pj.Id_Equipo

go


create proc J_B_total_targetas_Por_equipos @id_torneo int
as
select e.Nombre,isnull(ta.targetas_amarillas,0)total_amarillas,isnull(tr.targetas_rojas,0)total_rojas from equipo e
full join registr_targetas_amariilas ta
on e.Id_Equipo=ta.Id_Equipo
full join registr_targetas_rojas tr
on e.Id_Equipo=tr.Id_Equipo
full join torneo_equipo tore
on e.Id_Equipo=tore.Id_Equipo
where Id_Torneo=@id_torneo
go

--------------Procedimiento de Tabla Visitante
create Function total_datos_parcial(@id_torneo int)
returns table
as
return(
select (select e.Nombre from EQUIPO e where pr.Id_EquipoVisita=e.Id_Equipo) as Nombres   ,  count(p.Id_EquipoVisita)  as J , 
case when  (select  case when count(pr2.Id_EquipoVisita) is null then 0 else count(pr2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id_torneo and pr2.Id_EquipoVisita=pr.Id_EquipoVisita and p2.PunteoEquipoLocal < p2.PunteoEquipoVisita  group by p2.Id_EquipoVisita) is null
then 0   else (select  case when count(pr2.Id_EquipoVisita) is null then 0 else count(pr2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id_torneo and pr2.Id_EquipoVisita=pr.Id_EquipoVisita and p2.PunteoEquipoLocal < p2.PunteoEquipoVisita  group by p2.Id_EquipoVisita) end as G
,case when  (select  case when count(pr2.Id_EquipoVisita) is null then 0 else count(pr2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id_torneo and pr2.Id_EquipoVisita=pr.Id_EquipoVisita and p2.PunteoEquipoLocal > p2.PunteoEquipoVisita  group by p2.Id_EquipoVisita) is null
then 0   else (select  case when count(pr2.Id_EquipoVisita) is null then 0 else count(pr2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id_torneo and pr2.Id_EquipoVisita=pr.Id_EquipoVisita and p2.PunteoEquipoLocal > p2.PunteoEquipoVisita  group by p2.Id_EquipoVisita) end as P
,case when  (select  case when count(pr2.Id_EquipoVisita) is null then 0 else count(pr2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id_torneo and pr2.Id_EquipoVisita=pr.Id_EquipoVisita and p2.PunteoEquipoLocal = p2.PunteoEquipoVisita  group by p2.Id_EquipoVisita) is null
then 0   else (select  case when count(pr2.Id_EquipoVisita) is null then 0 else count(pr2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id_torneo and pr2.Id_EquipoVisita=pr.Id_EquipoVisita and p2.PunteoEquipoLocal = p2.PunteoEquipoVisita  group by p2.Id_EquipoVisita) end as E,
sum(p.PunteoEquipoVisita) as GF  ,  sum(p.PunteoEquipoLocal) as GC , sum(p.PunteoEquipoVisita)-sum(p.PunteoEquipoLocal) as DG , case  when sum(p.PunteoEquipoVisita) is null then 0 else sum(p.PunteoEquipoVisita) end as PTS ,tt.Id_Torneo
from PUNTEO p right join PARTIDO pr on  p.Id_Juego= pr.Id_Juego
inner join torneo tt on
pr.Id_Torneo=tt.Id_Torneo

where pr.Id_Torneo=@id_torneo
group by  pr.Id_EquipoVisita,tt.Id_Torneo

)
go


create proc tabla_general_seleccionando_datos @id_torneo int
as
select pts.Nombres,isnull(pts.J,0) as part_jugados,isnull(pts.G,0) as Part_ganados ,isnull(pts.E,0) as empatados,isnull(pts.P,0) as P_perdidos,isnull(pts.GF,0) Goles_favor,isnull(pts.GC,0) Goles_contra,isnull(pts.DG,0) Diff_goles,isnull((pts.G*tor.PuntosVictoria),0)puntos_vistoria,isnull((pts.E*tor.PuntosEmpate),0)puntos_empate,isnull((pts.P*tor.PuntosDerrota),0)_puntos_derrota,isnull(((pts.G*tor.PuntosVictoria)+(pts.E*tor.PuntosEmpate)+(pts.P*tor.PuntosDerrota)),0)total_puntos from total_datos_parcial(@id_torneo) pts inner join torneo tor
on pts.Id_Torneo=tor.Id_Torneo
group by  pts.Id_Torneo,pts.Nombres,pts.J,pts.G,pts.E,pts.P,pts.GF,pts.GC,pts.DG,(pts.G*tor.PuntosVictoria),(pts.E*tor.PuntosEmpate),(pts.P*tor.PuntosDerrota
)

go



--------------------------------Procedimientos de Reporte Cancha
create proc LA_tiempoUsoCanchasPorFecha @fechaInicio date, @fechaFin date as
select c.Nombre, t.Nombre, sum(DATEDIFF(minute, p.HoraInicio, p.HoraFinal)) as total_minutos_usada
from cancha c, partido p, torneo t 
where c.NumeroCancha = p.Id_Cancha and p.Id_Torneo = t.Id_Torneo and p.Fecha between @fechaInicio and @fechaFin
group by c.Nombre, t.Nombre
GO

create proc LA_tiempoUsoPorNombreCancha @nombreCancha varchar(100) as
select c.Nombre, t.Nombre, sum(DATEDIFF(minute, p.HoraInicio, p.HoraFinal)) as total_minutos_usada
from cancha c, partido p, torneo t 
where c.NumeroCancha = p.Id_Cancha and p.Id_Torneo = t.Id_Torneo and c.Nombre = @nombreCancha
group by c.Nombre, t.Nombre
GO

create proc LA_tiempoUsoCanchaPorNombreTorneo @nombreTorneo varchar(100) as
select c.Nombre, t.Nombre, sum(DATEDIFF(minute, p.HoraInicio, p.HoraFinal)) as total_horas_usada
from cancha c, partido p, torneo t 
where c.NumeroCancha = p.Id_Cancha and p.Id_Torneo = t.Id_Torneo and t.Nombre = @nombreTorneo
group by c.Nombre, t.Nombre
GO

create proc LA_pagoArbitrosPorFecha @fechaInicio date, @fechaFin date as
select a.Nombres, a.Apellidos, a.Nacionalidad, a.Telefono, sum(ap.pago)as total_recibido_por_torneo, t.Nombre
from arbitro a, arbitro_partido ap, partido p, torneo t 
where a.DPI = ap.DPI_Arbitro and ap.Id_Juego = p.Id_Juego and p.Id_Torneo = t.Id_Torneo
and p.Fecha between @fechaInicio and @fechaFin
group by a.Nombres, a.Apellidos, a.Nacionalidad, a.Telefono, t.Nombre 
GO

create view LA_partidosAfectadosPorCancha as
select P.Id_Juego, P.Fecha, P.HoraInicio, P.HoraFinal, C.Nombre AS Cancha_No_Disponible 
from partido p, cancha c 
where p.Id_Cancha = c.NumeroCancha and c.Disponibilidad = 'No Disponible';
go

--equipo local reporte ´procedimientos jose curtidor
create Function total_datos_parcialss(@id_torneo int)
returns table
as
return(
select (select e.Nombre from EQUIPO e where pr.Id_EquipoLocal=e.Id_Equipo) as Nombres   ,  count(p.Id_EquipoLocal)  as J , 
case when  (select  case when count(pr2.Id_EquipoLocal) is null then 0 else count(pr2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id_torneo and pr2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.PunteoEquipoVisita < p2.PunteoEquipoLocal  group by p2.Id_EquipoLocal) is null
then 0   else (select  case when count(pr2.Id_EquipoLocal) is null then 0 else count(pr2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id_torneo and pr2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.PunteoEquipoVisita < p2.PunteoEquipoLocal  group by p2.Id_EquipoLocal) end as G
,case when  (select  case when count(pr2.Id_EquipoLocal) is null then 0 else count(pr2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id_torneo and pr2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.PunteoEquipoVisita > p2.PunteoEquipoLocal  group by p2.Id_EquipoLocal) is null
then 0   else (select  case when count(pr2.Id_EquipoLocal) is null then 0 else count(pr2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id_torneo and pr2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.PunteoEquipoVisita > p2.PunteoEquipoLocal  group by p2.Id_EquipoLocal) end as P
,case when  (select  case when count(pr2.Id_EquipoLocal) is null then 0 else count(pr2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id_torneo and pr2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.PunteoEquipoVisita = p2.PunteoEquipoLocal  group by p2.Id_EquipoLocal) is null
then 0   else (select  case when count(pr2.Id_EquipoLocal) is null then 0 else count(pr2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego  where   pr2.Id_Torneo=@id_torneo and pr2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.PunteoEquipoVisita = p2.PunteoEquipoLocal  group by p2.Id_EquipoLocal) end as E,
sum(p.PunteoEquipoLocal)as Goles_Favor,sum(p.PunteoEquipoVisita) as goles_encontra , (sum(p.PunteoEquipoLocal)-sum(p.PunteoEquipoVisita))Dif_goles , case  when sum(p.PunteoEquipoLocal) is null then 0 else sum(p.PunteoEquipoLocal) end as PTS ,tt.Id_Torneo
from PUNTEO p right join PARTIDO pr on  p.Id_Juego= pr.Id_Juego
inner join torneo tt on
pr.Id_Torneo=tt.Id_Torneo

where pr.Id_Torneo=@id_torneo
group by  pr.Id_EquipoLocal,tt.Id_Torneo

)
--select*from total_datos_parcialss (1)
go


create proc tabla_general_seleccionando_datoss @id_torneo int
as
select isnull(pts.Nombres,0),pts.J as part_jugados,isnull(pts.G,0) as Part_ganados ,isnull(pts.E,0) as empatados,isnull(pts.P,0) as P_perdidos,isnull(pts.Goles_Favor,0) Goles_favor,isnull(pts.goles_encontra,0) Goles_contra,isnull(pts.Dif_goles,0) Diff_goles,isnull((pts.G*tor.PuntosVictoria),0)puntos_vistoria,isnull((pts.E*tor.PuntosEmpate),0)puntos_empate,isnull((pts.P*tor.PuntosDerrota),0)_puntos_derrota,isnull(((pts.G*tor.PuntosVictoria)+(pts.E*tor.PuntosEmpate)+(pts.P*tor.PuntosDerrota)),0)total_puntos from total_datos_parcialss(@id_torneo) pts inner join torneo tor
on pts.Id_Torneo=tor.Id_Torneo
group by  pts.Id_Torneo,pts.Nombres,pts.J,pts.G,pts.E,pts.P,pts.Goles_Favor,pts.goles_encontra,pts.Dif_goles,(pts.G*tor.PuntosVictoria),(pts.E*tor.PuntosEmpate),(pts.P*tor.PuntosDerrota
)


go

----------------portero menos vencio----------------------------

create view goles_porteo_local
as
select Id_EquipoLocal,sum(PunteoEquipoVisita) goles_a_portero
from punteo
group by Id_EquipoLocal
go
create view goles_portero2
as
select Id_EquipoVisita,sum(PunteoEquipoLocal) goles_a_portero
from punteo
group by Id_EquipoVisita
go

create proc Portero_menos_vencido @id_torneo int
as
select top 1 gp1.Id_EquipoLocal,e.Nombre,pj.DPI_Jugador,j.Nombres,j.Apellidos,(gp1.goles_a_portero+gp2.goles_a_portero)Goles_a_porteros
from goles_porteo_local gp1
inner join  goles_portero2 gp2
on gp1.Id_EquipoLocal=gp2.Id_EquipoVisita
inner join torneo_equipo te
on gp1.Id_EquipoLocal= te.Id_Equipo
inner join equipo e
on e.Id_Equipo=te.Id_Equipo
inner join posicion_jugador pj
on te.Id_Equipo=pj.Id_Equipo
inner join jugador j
on pj.DPI_Jugador=j.DPI_Jugador
where te.Id_Torneo=@id_torneo and pj.DPI_Jugador in (select pj2.DPI_Jugador from posicion_jugador pj2 where pj2.Posicion='portero') 
group by gp1.Id_EquipoLocal,e.Nombre,pj.DPI_Jugador,j.Nombres,j.Apellidos,(gp1.goles_a_portero+gp2.goles_a_portero)
order by Goles_a_porteros asc
go

CREATE FUNCTION IngresosPorTarjetas(@FechaIncio date,@FechaFinal date)
returns table
as
return(
	SELECT torneo.Nombre,amonestacion.ColorTarjeta,ISNULL(COUNT(*)*amonestacion.Valor_multa,0) AS GananciasPorTarjeta
	FROM amonestacion
	INNER JOIN registro_amonestacion ON registro_amonestacion.Id_Tarjeta = amonestacion.Id_Tarjeta
	INNER JOIN partido ON partido.Id_Juego = registro_amonestacion.Id_Juego
	INNER JOIN torneo ON torneo.Id_Torneo = partido.Id_Torneo
	WHERE partido.Fecha between @FechaIncio and @FechaFinal
	GROUP BY torneo.Nombre,amonestacion.ColorTarjeta,amonestacion.Valor_multa
);
go
CREATE FUNCTION PagosArbitros(@FechaIncio date,@FechaFinal date)
returns table
as
return(
	SELECT torneo.Nombre,ISNULL(SUM(arbitro_partido.Pago),0) AS pagoArbitro
	FROM torneo
	INNER JOIN partido ON partido.Id_Torneo = torneo.Id_Torneo
	INNER JOIN arbitro_partido ON arbitro_partido.Id_Juego = partido.Id_Juego
	WHERE partido.Fecha between @FechaIncio and @FechaFinal
	GROUP BY torneo.Nombre
);

go
CREATE FUNCTION SinUtilidad(@FechaIncio date,@FechaFinal date)
returns table
as
return(
	SELECT torneo.Nombre,ISNULL((COUNT(*)*torneo.Costo),0) AS IngresosPorInscripciones,(
		SELECT ISNULL(SUM(IngresosPorTarjetas.GananciasPorTarjeta),0)
		FROM IngresosPorTarjetas(@FechaIncio,@FechaFinal)
		WHERE IngresosPorTarjetas.Nombre = torneo.Nombre
	) AS IngresosPorTarjetas,(
		SELECT ISNULL(SUM(PagosArbitros.pagoArbitro),0)
		FROM PagosArbitros(@FechaIncio,@FechaFinal)
		WHERE PagosArbitros.Nombre = torneo.Nombre
	) AS PagosArbitros
	FROM torneo_equipo
	left JOIN torneo ON torneo_equipo.Id_Torneo = torneo.Id_Torneo
	GROUP BY torneo.Nombre,torneo.Costo
);
go
create proc proc_erickecheverria_Utilidades @FechaInicio date, @FechaFinal date
as
	SELECT *,(ISNULL(SinUtilidad.IngresosPorInscripciones,0)+
	ISNULL(SinUtilidad.IngresosPorTarjetas,0)-
	ISNULL(SinUtilidad.PagosArbitros,0)
	) AS UtilidadTotal
	FROM SinUtilidad(@FechaInicio,@FechaFinal);
GO



--Reporte goleadores por torneo

create proc J_C_goleadores_equipos @id_torneo int
as

select  e.Nombre,g.DPI_Jugador,j.Nombres,j.Apellidos,pj.NumeroCamisola,count(g.DPI_Jugador)cantidad_de_goles_anotados
from gol g
inner join jugador j
on g.DPI_Jugador=j.DPI_Jugador
inner join posicion_jugador pj
on j.DPI_Jugador=pj.DPI_Jugador
inner join equipo e 
on pj.Id_Equipo=e.Id_Equipo
where pj.Id_Torneo=@id_torneo
group by e.Nombre,pj.Id_Equipo,g.DPI_Jugador,j.Nombres,j.Apellidos,pj.NumeroCamisola
order by cantidad_de_goles_anotados desc 
go

CREATE FUNCTION erick_tablaSinPunteo(@Id_Torneo int)
returns table
as
return(
	SELECT e.Nombre,(
		SELECT COUNT(*) FROM punteo
		Where punteo.Id_EquipoLocal = e.Id_Equipo
		or punteo.Id_EquipoVisita = e.Id_Equipo
	) AS J,(
		SELECT COUNT(*) FROM punteo
		Where (punteo.Id_EquipoLocal = e.Id_Equipo
		and PunteoEquipoLocal > PunteoEquipoVisita)
		or (punteo.Id_EquipoVisita = e.Id_Equipo
		and PunteoEquipoVisita > PunteoEquipoLocal)		
	) AS G, (
		SELECT COUNT(*) FROM punteo
		Where (punteo.Id_EquipoLocal = e.Id_Equipo
		and PunteoEquipoLocal = PunteoEquipoVisita)
		or (punteo.Id_EquipoVisita = e.Id_Equipo
		and PunteoEquipoLocal = PunteoEquipoVisita)		
	) AS E,
	(
		SELECT COUNT(*) FROM punteo
		Where (punteo.Id_EquipoLocal = e.Id_Equipo
		and PunteoEquipoLocal < PunteoEquipoVisita)
		or (punteo.Id_EquipoVisita = e.Id_Equipo
		and PunteoEquipoVisita < PunteoEquipoLocal)		
	) AS P
	FROM equipo e
	inner join torneo_equipo on torneo_equipo.Id_Equipo = e.Id_Equipo
	WHERE torneo_equipo.Id_Torneo = @Id_Torneo
);
go
CREATE FUNCTION erick_tablaConPunteo(@Id_Torneo int)
returns table
as
return(
	select *,G*(Select PuntosVictoria from torneo where Id_Torneo = @Id_Torneo) + 
	P*(Select PuntosDerrota from torneo where Id_Torneo = @Id_Torneo) +
	E*(Select PuntosEmpate from torneo where Id_Torneo = @Id_Torneo) AS PTS
	from erick_tablaSinPunteo(@Id_Torneo)
);
go
CREATE FUNCTION erick_tablaCompleta(@Id_Torneo int)
returns table
as
return(
	Select ROW_NUMBER() OVER (ORDER BY erick_tablaConPunteo.PTS DESC ) as POS,* from erick_tablaConPunteo(@Id_Torneo)
);
go
create proc proc_erickecheverria_estadisticasDelEquipo @Nombre_Equipo varchar(200), @Id_Torneo int
as
	SELECT * FROM erick_tablaCompleta(@Id_Torneo)
	WHERE erick_tablaCompleta.Nombre = @Nombre_Equipo;
go
create proc proc_erick_cargar_NombreDeEquipoEnTorneo @Id_Torneo int
as
	select Nombre
	from equipo
	WHERE Id_Equipo in (
		SELECT Id_Equipo
		FROM torneo_equipo
		WHERE Id_Torneo = @Id_Torneo
);
--procedimientos recuperados----- Jose curtidor
go
create proc BG_Obtener_Id_toreo @Nombre_Torneo varchar(100)
as
select Id_Torneo from torneo
where Nombre=@Nombre_Torneo


--exec BG_Obtener_Id_toreo @Nombre_Torneo='patsy'


--tabla general Jose Curtidor-- Agragando procedimientos extras

go

create function mostrar_tabla_parcial(@id_torneo int)
returns table
 as 
 return(
 
select (select e.Nombre from EQUIPO e where pr.Id_EquipoLocal=e.Id_Equipo) as Nombres   , count(p.Id_EquipoLocal)+ (
 select   count(pun2.Id_EquipoVisita)   from PUNTEO pun2 right join PARTIDO part1 on  pun2.Id_Juego= part1.Id_Juego
where part1.Id_Torneo=@id_torneo
and part1.Id_EquipoVisita=pr.Id_EquipoLocal
group by  part1.Id_EquipoVisita
) as PJ, 
case when  (select  case when count(part2.Id_EquipoLocal) is null then 0 else count(part2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO part2 on  p2.Id_Juego= part2.Id_Juego  where   part2.Id_Torneo=@id_torneo and part2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.PunteoEquipoLocal > p2.PunteoEquipoVisita  group by p2.Id_EquipoLocal) is null
then 0   else (select  case when count(part2.Id_EquipoLocal) is null then 0 else count(part2.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO part2 on  p2.Id_Juego= part2.Id_Juego  where   part2.Id_Torneo=@id_torneo and part2.Id_EquipoLocal=pr.Id_EquipoLocal and p2.PunteoEquipoLocal > p2.PunteoEquipoVisita  group by p2.Id_EquipoLocal) end  
+case when  (select  case when count(part2.Id_EquipoVisita) is null then 0 else count(part2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO part2 on  p2.Id_Juego= part2.Id_Juego  where   part2.Id_Torneo=@id_torneo and part2.Id_EquipoVisita=pr.Id_EquipoLocal and p2.PunteoEquipoLocal < p2.PunteoEquipoVisita  group by p2.Id_EquipoVisita) is null
then 0   else (select  case when count(part2.Id_EquipoVisita) is null then 0 else count(part2.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO part2 on  p2.Id_Juego= part2.Id_Juego  where   part2.Id_Torneo=@id_torneo and part2.Id_EquipoVisita=pr.Id_EquipoLocal and p2.PunteoEquipoLocal < p2.PunteoEquipoVisita  group by p2.Id_EquipoVisita) end as PG
,
case when  (select  case when count(part3.Id_EquipoLocal) is null then 0 else count(part3.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO part3 on  p2.Id_Juego= part3.Id_Juego  where   part3.Id_Torneo=@id_torneo and part3.Id_EquipoLocal=pr.Id_EquipoLocal and p2.PunteoEquipoLocal < p2.PunteoEquipoVisita  group by p2.Id_EquipoLocal) is null
then 0   else (select  case when count(part3.Id_EquipoLocal) is null then 0 else count(part3.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO part3 on  p2.Id_Juego= part3.Id_Juego  where   part3.Id_Torneo=@id_torneo and part3.Id_EquipoLocal=pr.Id_EquipoLocal and p2.PunteoEquipoLocal < p2.PunteoEquipoVisita  group by p2.Id_EquipoLocal) end  
+case when  (select  case when count(part3.Id_EquipoVisita) is null then 0 else count(part3.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO part3 on  p2.Id_Juego= part3.Id_Juego  where   part3.Id_Torneo=@id_torneo and part3.Id_EquipoVisita=pr.Id_EquipoLocal and p2.PunteoEquipoLocal > p2.PunteoEquipoVisita  group by p2.Id_EquipoVisita) is null
then 0   else (select  case when count(part3.Id_EquipoVisita) is null then 0 else count(part3.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO part3 on  p2.Id_Juego= part3.Id_Juego  where   part3.Id_Torneo=@id_torneo and part3.Id_EquipoVisita=pr.Id_EquipoLocal and p2.PunteoEquipoLocal > p2.PunteoEquipoVisita  group by p2.Id_EquipoVisita) end as PP
,
case when  (select  case when count(part4.Id_EquipoLocal) is null then 0 else count(part4.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO part4 on  p2.Id_Juego= part4.Id_Juego  where   part4.Id_Torneo=@id_torneo and part4.Id_EquipoLocal=pr.Id_EquipoLocal and p2.PunteoEquipoLocal = p2.PunteoEquipoVisita  group by p2.Id_EquipoLocal) is null
then 0   else (select  case when count(part4.Id_EquipoLocal) is null then 0 else count(part4.Id_EquipoLocal) end as t from PUNTEO p2 right join PARTIDO part4 on  p2.Id_Juego= part4.Id_Juego  where   part4.Id_Torneo=@id_torneo and part4.Id_EquipoLocal=pr.Id_EquipoLocal and p2.PunteoEquipoLocal = p2.PunteoEquipoVisita  group by p2.Id_EquipoLocal) end  
+case when  (select  case when count(part4.Id_EquipoVisita) is null then 0 else count(part4.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO part4 on  p2.Id_Juego= part4.Id_Juego  where   part4.Id_Torneo=@id_torneo and part4.Id_EquipoVisita=pr.Id_EquipoLocal and p2.PunteoEquipoLocal = p2.PunteoEquipoVisita  group by p2.Id_EquipoVisita) is null
then 0   else (select  case when count(part4.Id_EquipoVisita) is null then 0 else count(part4.Id_EquipoVisita) end as t from PUNTEO p2 right join PARTIDO part4 on  p2.Id_Juego= part4.Id_Juego  where   part4.Id_Torneo=@id_torneo and part4.Id_EquipoVisita=pr.Id_EquipoLocal and p2.PunteoEquipoLocal = p2.PunteoEquipoVisita  group by p2.Id_EquipoVisita) end as PE


, case when sum(p.PunteoEquipoVisita) is null then 0  else sum(p.PunteoEquipoLocal) end + (
 select  case when  sum(p2.PunteoEquipoVisita) is null then 0 else  sum(p2.PunteoEquipoVisita) end  from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego
where pr2.Id_Torneo=@id_torneo
and pr2.Id_EquipoVisita=pr.Id_EquipoLocal
group by  pr2.Id_EquipoVisita
)  as GF ,
 case when sum(p.PunteoEquipoVisita) is null then 0  else sum(p.PunteoEquipoVisita) end + (
 select  case when  sum(p2.PunteoEquipoLocal) is null then 0 else  sum(p2.PunteoEquipoLocal) end  from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego
where pr2.Id_Torneo=@id_torneo
and pr2.Id_EquipoVisita=pr.Id_EquipoLocal
group by  pr2.Id_EquipoVisita
)  as GC,
case when sum(p.PunteoEquipoLocal) is null then 0  else sum(p.PunteoEquipoLocal) end + (
 select  case when  sum(p2.PunteoEquipoVisita) is null then 0 else  sum(p2.PunteoEquipoVisita) end  from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego
where pr2.Id_Torneo=@id_torneo
and pr2.Id_EquipoVisita=pr.Id_EquipoLocal
group by  pr2.Id_EquipoVisita)  - ( case when sum(p.PunteoEquipoVisita) is null then 0  else sum(p.PunteoEquipoVisita) end + (
 select  case when  sum(p2.PunteoEquipoLocal) is null then 0 else  sum(p2.PunteoEquipoLocal) end  from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego
where pr2.Id_Torneo=@id_torneo
and pr2.Id_EquipoVisita=pr.Id_EquipoLocal
group by  pr2.Id_EquipoVisita
) )as DF,

case when sum(p.PunteoEquipoLocal) is null then 0  else sum(p.PunteoEquipoLocal) end + (
 select  case when  sum(p2.PunteoEquipoVisita) is null then 0 else  sum(p2.PunteoEquipoVisita) end  from PUNTEO p2 right join PARTIDO pr2 on  p2.Id_Juego= pr2.Id_Juego
where pr2.Id_Torneo=@id_torneo
and pr2.Id_EquipoVisita=pr.Id_EquipoLocal
group by  pr2.Id_EquipoVisita
)  as PTS,tt.Id_Torneo

from PUNTEO p right join PARTIDO pr on  p.Id_Juego= pr.Id_Juego
inner join torneo tt
on pr.Id_Torneo=tt.Id_Torneo
where pr.Id_Torneo=@id_torneo
group by  pr.Id_EquipoLocal,tt.Id_Torneo
)

--select*from mostrar_tabla_parcial(1)


--creando procedimientos para la tabla general y tambien se unio con la tabla torneo
go
create proc Posiciones_generales @id_torneo int
as
select isnull(mtp.Nombres,'vacio')nombre_equipo,isnull(mtp.PJ,0) partidos_jugados,isnull(mtp.PG,0) Partidos_ganados,isnull(mtp.PE,0) Partidos_empatados,isnull(mtp.PP,0) partidos_perdidos,isnull(mtp.GF,0) Goles_favor,isnull(mtp.GC,0) Goles_contra,isnull(mtp.DF,0) diferencia_goles,isnull((mtp.PG*tor.PuntosVictoria),0)puntos_victoria_total,isnull((mtp.PE*tor.PuntosEmpate),0)puntos_empate_total,isnull((mtp.PP*tor.PuntosDerrota),0) puntos_derrota_total,isnull(((mtp.PG*tor.PuntosVictoria)+(mtp.PE*tor.PuntosEmpate)+(mtp.PP*tor.PuntosDerrota)),0)total_puntos
from  mostrar_tabla_parcial(@id_torneo) mtp inner join torneo tor
on mtp.Id_Torneo=tor.Id_Torneo
where tor.Id_Torneo=@id_torneo
group  by  mtp.Nombres,mtp.PJ,mtp.PG,mtp.PE,mtp.PP,mtp.GF,mtp.GC,mtp.DF,(mtp.PG*tor.PuntosVictoria),(mtp.PE*tor.PuntosEmpate),(mtp.PP*tor.PuntosDerrota),((mtp.PG*tor.PuntosVictoria)+(mtp.PE*tor.PuntosEmpate)+(mtp.PP*tor.PuntosDerrota))
order by total_puntos desc
--exec Posiciones_generales @id_torneo=1
GO
create view Reporte_Uso_canchas 
as
select c.NumeroCancha, c.Nombre, c.Disponibilidad, p.Id_Juego, p.HoraInicio, p.HoraFinal
from cancha c, partido p where p.Id_Cancha = c.NumeroCancha;
GO

create proc obtener_dpi_entrenadores @nombre varchar(100), @apellido varchar(100)
as 
select DPI
from entrenador where Nombre = @nombre and Apellidos = @apellido
GO
create proc LA_obtenerNombreCanchas as
select Nombre
from cancha
GO

CREATE PROC SP_ADD_CLIENTE @DPI VARCHAR(30) , @Nombres VARCHAR (200), @Apellidos VARCHAR (200),@Telefono VARCHAR (30) ,@Correo VARCHAR (30)
AS BEGIN
    INSERT INTO Cliente(DPI, Nombres, Apellidos, Telefono, Correo) VALUES(@DPI, @Nombres, @Apellidos, @Telefono, @Correo)
END
GO 

CREATE PROC SP_UPDATE_CLIENTE  @ID INT, @DPI VARCHAR(30) , @Nombres VARCHAR (200), @Apellidos VARCHAR (200),@Telefono VARCHAR (30) ,@Correo VARCHAR (30)
AS BEGIN
    UPDATE Cliente SET DPI = @DPI, Nombres = @Nombres, Apellidos = @Apellidos, Telefono = @Telefono, Correo = @Correo WHERE ID = @ID
END
GO

CREATE PROC SP_DELETE_CLIENTE @ID INT
AS BEGIN
    DELETE FROM Cliente WHERE ID = @ID;
END
GO

CREATE PROC SP_ADD_USUARIO 
	@DPI VARCHAR(30),
	@Nombres VARCHAR (200) ,
	@Apellidos VARCHAR (200),
	@Usuario  VARCHAR (200),
	@Contrasena VARCHAR (200),
	@Telefono VARCHAR (30),
	@Direccion VARCHAR (100),
	@Correo VARCHAR (30),
	@Puesto VARCHAR (30),
	@Rol VARCHAR (30) 
AS BEGIN
	INSERT INTO USUARIOS(DPI, Nombres, Apellidos,Usuario ,Contrasena, Telefono, Direccion, Correo,Puesto, Rol) VALUES(@DPI, @Nombres, @Apellidos,@Usuario,@Contrasena, @Telefono, @Direccion, @Correo,@Puesto, @Rol)
END
GO 

CREATE PROC SP_DESACTIVAR_USER @ID INT, @Estado BIT
AS BEGIN
	IF @Estado = 1
	BEGIN
		UPDATE USUARIOS SET Estado = 0 WHERE ID = @ID;
	END
	ELSE
	BEGIN
		UPDATE USUARIOS SET Estado = 1 WHERE ID = @ID;
	END
END
GO

CREATE PROC SP_UPDATE_USUARIO  
	@ID INT,
	@DPI VARCHAR(30),
	@Nombres VARCHAR (200) ,
	@Apellidos VARCHAR (200),
	@Usuario  VARCHAR (200),
	@Contrasena VARCHAR (200),
	@Telefono VARCHAR (30) ,
	@Direccion VARCHAR (100) ,
	@Correo VARCHAR (30),
	@Puesto VARCHAR (30),
	@Rol VARCHAR (30) 
AS BEGIN
	UPDATE USUARIOS SET DPI = @DPI, Nombres = @Nombres,  Apellidos = @Apellidos,Usuario=@Usuario,Contrasena=@Contrasena, Telefono = @Telefono,Direccion=@Direccion, Correo = @Correo, Puesto=@Puesto,Rol = @Rol WHERE ID= @ID
END
GO

CREATE PROC estadoid @User VARCHAR (200), @Contrasena VARCHAR (200)
AS BEGIN
	SELECT  U.ID FROM USUARIOS U WHERE U.Usuario = @User AND U.Contrasena = @Contrasena
END
GO

CREATE PROC SP_ESTADOUSUARIO @User  VARCHAR (200), @Contrasena VARCHAR (200)
AS BEGIN
	SELECT  U.Estado FROM USUARIOS U WHERE  U.Usuario = @User AND U.Contrasena = @Contrasena
END
GO

CREATE PROC SP_ROLUSER @ID INT
AS BEGIN
	SELECT  U.Rol FROM USUARIOS U WHERE U.ID = @ID
END
GO

CREATE PROC SP_INSERT_HORARIO @Dia VARCHAR(50),
	@HoraApertura TIME ,
	@HoraCierre TIME
AS BEGIN
	INSERT INTO HORARIO(Dia, HoraApertura,HoraCierre)VALUES(@Dia,@HoraApertura,@HoraCierre)
END
GO

CREATE PROC SP_UPDATE_HORARIO @Dia VARCHAR(50),
	@HoraApertura TIME ,
	@HoraCierre TIME 
AS BEGIN
	UPDATE HORARIO SET HoraApertura = @HoraApertura, HoraCierre = @HoraCierre  WHERE Dia = @Dia;
END
GO

CREATE PROC SP_INSERT_BITACORA @IdUsuario INT,
	@ACCION VARCHAR(25) ,
	@FECHA VARCHAR (20),
	@HORA VARCHAR (20)
AS BEGIN
	INSERT INTO BITACORA(IdUsuario, ACCION, FECHA, HORA)VALUES(@IdUsuario,@ACCION,CONVERT(DATE, @FECHA), CONVERT(TIME, @HORA))
END
GO

CREATE PROCEDURE SP_VIEW_ALQUILER
AS BEGIN
	SELECT A.ID, A.NumeroCancha, A.IDCLIENTE, AA.DPIArbitro, A.FechaApartada, A.HoraInicio, A.HoraFinal, A.TotalPrecio TotalPrecioCancha, AA.TotalPrecioArbitro, (AA.TotalPrecioArbitro + A.TotalPrecio) PrecioTotal FROM ALQUILER_CANCHA A LEFT JOIN ALQUILER_ARBITRO AA ON A.ID = AA.IDALQUILER
END
GO

CREATE PROCEDURE SP_DELETE_ALQUILER_CANCHA @ID INT
AS BEGIN
	DELETE FROM ALQUILER_CANCHA WHERE ID = @ID
END
GO

CREATE PROCEDURE SP_DELETE_ALQUILER_ARBITRO @ID INT
AS BEGIN
	DELETE FROM ALQUILER_ARBITRO WHERE IDAlquiler = @ID
END
GO

CREATE PROC SP_CANCHA_DISPONIBLE @Fecha_Apartada DATE,  @Hora_Inicio TIME, @Hora_Final TIME
AS BEGIN
	SELECT C.NumeroCancha, C.Nombre  FROM  CANCHA C 
	WHERE NOT (C.NumeroCancha = ANY(
		SELECT AC.NumeroCancha FROM ADMINISTRACION_CANCHA AC INNER JOIN PARTIDO P ON
		AC.Id_Juego = P.Id_Juego WHERE  P.Fecha = @Fecha_Apartada AND P.HoraInicio = @Hora_Inicio AND P.HoraFinal = @Hora_Final
	)
	OR C.NumeroCancha = ANY(
		SELECT AC.NumeroCancha FROM CANCHA C INNER JOIN ALQUILER_CANCHA AC ON C.NumeroCancha = AC.NumeroCancha
		WHERE  AC.FechaApartada = @Fecha_Apartada  AND AC.HoraInicio = @Hora_Inicio AND AC.HoraFinal = @Hora_Final
	))
END
GO


CREATE PROC SP_ADD_AlQUILER @NumeroCancha INT ,@IDCLIENTE INT,  @Fecha_Apartada DATE ,@Hora_Inicio TIME ,@Hora_Final TIME ,@Total_Precio decimal(8,2)
AS BEGIN 
	INSERT INTO ALQUILER_CANCHA (NumeroCancha, IDCLIENTE, FechaApartada, HoraInicio, HoraFinal,TotalPrecio) VALUES(@NumeroCancha , @IDCLIENTE, @Fecha_Apartada, @Hora_Inicio, @Hora_Final,@Total_Precio)
END
GO


CREATE PROC SP_ID_CLIENTE @Nombres VARCHAR (200), @Apellidos VARCHAR (200)
AS BEGIN
	SELECT C.ID FROM CLIENTE C WHERE Nombres = @Nombres and Apellidos = @Apellidos
END
GO


CREATE PROC SP_PRECIO_CANCHA @NumeroCancha INT 
AS BEGIN
	SELECT C.Precio_hora FROM CANCHA C WHERE  C.NumeroCancha = @NumeroCancha
END
GO


CREATE PROC SP_PRECIO_TOTAL @Hora_Inicio TIME, @Hora_Final TIME, @NOCANCHA INT
AS BEGIN
	SELECT  C.Precio_hora * DATEDIFF(HOUR,@Hora_Inicio, @Hora_Final) FROM  CANCHA C  WHERE C.NumeroCancha = @NOCANCHA
END
GO


CREATE PROC SP_PRECIO_TOTAL_ARBITRAJE @Hora_Inicio TIME, @Hora_Final TIME, @DPI_ARBITRO  BIGINT
AS BEGIN
	SELECT A.Precio_hora * DATEDIFF(HOUR,@Hora_Inicio,@Hora_Final) FROM ARBITRO A WHERE A.DPI = @DPI_ARBITRO
END
GO


CREATE PROC SP_ARBITRO_DISPONIBLE @Fecha_Apartada DATE,  @Hora_Inicio TIME, @Hora_Final TIME
AS BEGIN
	SELECT A.DPI, A.Nombres, A.Apellidos  FROM  ARBITRO A 
	WHERE NOT (A.DPI = ANY(
		SELECT AP.DPI_Arbitro FROM ARBITRO_PARTIDO AP INNER JOIN PARTIDO P ON
		AP.Id_Juego = P.Id_Juego WHERE  P.Fecha = @Fecha_Apartada AND P.HoraInicio = @Hora_Inicio AND P.HoraFinal = @Hora_Final
	)
	OR A.DPI = ANY(
		SELECT AC.DPIArbitro FROM ARBITRO A INNER JOIN ALQUILER_ARBITRO AC ON A.DPI = AC.DPIArbitro
		WHERE  AC.FechaApartado = @Fecha_Apartada  AND AC.HoraInicio = @Hora_Inicio AND AC.HoraFinal = @Hora_Final
	))
END
GO

CREATE PROC SP_INSERT_ARBITRAJE_ALQUILADO @Fecha_Apartado DATE ,
    @Hora_Inicio TIME ,
    @Hora_Final TIME ,
    @DPI_Arbitro BIGINT ,
    @ID_ALQUILER INT ,
    @Total_Precio_Arbitro decimal(8,2) 
AS BEGIN
	INSERT INTO ALQUILER_ARBITRO(FechaApartado,HoraInicio,HoraFinal,DPIArbitro,IDALQUILER,TotalPrecioArbitro)VALUES(@Fecha_Apartado,@Hora_Inicio,@Hora_Final,@DPI_Arbitro,@ID_ALQUILER,@Total_Precio_Arbitro)
END
GO


CREATE PROC SP_REPORTE_INGRESO_CANCHA @FECHA_INICIO DATE,@FECHA_FINAL DATE
AS BEGIN
	SET Language 'Spanish';
    SELECT C.Nombre NombreCancha, DATENAME(WEEKDAY, AC.FechaApartada) Dia, 
		AC.FechaApartada Fecha,
		SUM(AC.TotalPrecio) Ingresos
	FROM ALQUILER_CANCHA AC INNER JOIN cancha C
	ON C.NumeroCancha = AC.NumeroCancha
	WHERE AC.FechaApartada BETWEEN @FECHA_INICIO AND @FECHA_FINAL
	GROUP BY AC.FechaApartada, C.NOMBRE
END
GO

CREATE PROC SP_REPORTE_INGRESOS_ARBITROS @FECHA_INICIO DATE, @FECHA_FINAL DATE
AS BEGIN
	SET Language 'Spanish';
    SELECT A.Nombres, 
		A.Apellidos, 
		DATENAME(WEEKDAY, AA.FechaApartado) Dia, 
		AA.FechaApartado Fecha, 
		SUM(AA.TotalPrecioArbitro) Ingresos 
		FROM ALQUILER_ARBITRO AA INNER JOIN ARBITRO A 
		ON A.DPI = AA.DPIArbitro 
		WHERE AA.FechaApartado BETWEEN @FECHA_INICIO AND @FECHA_FINAL 
	GROUP BY AA.FechaApartado, A.Nombres, A.Apellidos
END
GO

CREATE PROC SP_REPORTE_BITACORA @FECHA_INICIO DATE, @FECHA_FINAL DATE, @IdUsuario INT
AS BEGIN
    SELECT * FROM BITACORA B WHERE B.FECHA BETWEEN @FECHA_INICIO AND @FECHA_FINAL AND B.IdUsuario = @IdUsuario
END
GO

CREATE PROC SP_REPORTE_DISPONIBILIDAD_CANCHA @Fecha DATE, @HoraInicio TIME, @HoraFinal TIME, @NumeroCancha INT
AS BEGIN
    SELECT * FROM ALQUILER_CANCHA AC 
	WHERE AC.NumeroCancha = @NumeroCancha 
	AND AC.FechaApartada = @Fecha 
	AND AC.HoraInicio <= @HoraInicio 
	AND AC.HoraFinal >= @HoraFinal
END

create proc obtenerJugadoresDelEquipo @Id_Torneo int, @Id_Equipo int
as
	SELECT posicion_jugador.Id_Torneo, torneo.Nombre, posicion_jugador.Id_Equipo, equipo.Nombre, posicion_jugador.DPI_Jugador, jugador.Nombres, jugador.Apellidos, posicion_jugador.Posicion, posicion_jugador.NumeroCamisola
	FROM posicion_jugador
	INNER JOIN jugador on jugador.DPI_Jugador = posicion_jugador.DPI_Jugador
	INNER JOIN torneo on torneo.Id_Torneo = posicion_jugador.Id_Torneo
	INNER JOIN equipo on equipo.Id_Equipo = posicion_jugador.Id_Equipo
	WHERE posicion_jugador.Id_Torneo = @Id_Torneo
	and posicion_jugador.Id_Equipo = @Id_Equipo;

CREATE PROCEDURE verusers
AS BEGIN
	SELECT * FROM Usuario
END