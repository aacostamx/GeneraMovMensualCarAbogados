USE Abogados
GO
IF OBJECT_ID ('Abogados.dbo.fnCalculaNombreMes ','FN') IS NOT NULL DROP 
FUNCTION  fnCalculaNombreMes
GO
-- =============================================  
-- Autor: Antonio Acosta Murillo  
-- Fecha: 17 Enero 2014  
-- Descripción General: Recibe la fecha en formato smalldatetime y la regresa en una cadena con el nombre y el año ejemplo: Ene2015  
-- =============================================    
CREATE FUNCTION fnCalculaNombreMes(@FechaActual AS SMALLDATETIME)      
RETURNS CHAR(12)    
AS      
BEGIN    
 DECLARE @Mes AS CHAR(12)    
 SELECT @Mes =     
    CASE MONTH(@FechaActual)    
    WHEN 1  THEN 'Ene'+CAST(YEAR(@FechaActual) AS CHAR(4))    
    WHEN 2  THEN 'Feb'+CAST(YEAR(@FechaActual) AS CHAR(4))    
    WHEN 3  THEN 'Mar'+CAST(YEAR(@FechaActual) AS CHAR(4))    
    WHEN 4  THEN 'Abr'+CAST(YEAR(@FechaActual) AS CHAR(4))    
    WHEN 5  THEN 'May'+CAST(YEAR(@FechaActual) AS CHAR(4))    
    WHEN 6  THEN 'Jun'+CAST(YEAR(@FechaActual) AS CHAR(4))    
    WHEN 7  THEN 'Jul'+CAST(YEAR(@FechaActual) AS CHAR(4))    
    WHEN 8  THEN 'Ago'+CAST(YEAR(@FechaActual) AS CHAR(4))    
    WHEN 9  THEN 'Sep'+CAST(YEAR(@FechaActual) AS CHAR(4))    
    WHEN 10 THEN 'Oct'+CAST(YEAR(@FechaActual) AS CHAR(4))    
    WHEN 11 THEN 'Nov'+CAST(YEAR(@FechaActual) AS CHAR(4))    
    WHEN 12 THEN 'Dic'+CAST(YEAR(@FechaActual) AS CHAR(4))    
    END     
 RETURN(@Mes)    
END 
GO

USE Abogados
GO
IF OBJECT_ID ('Abogados.dbo.AF0103_GeneraMovMensualCarAbogados ','P') IS NOT NULL 
DROP PROCEDURE  AF0103_GeneraMovMensualCarAbogados
GO
CREATE PROCEDURE AF0103_GeneraMovMensualCarAbogados(@fActual SMALLDATETIME)
AS
-- =============================================
-- Autor: Antonio Acosta Murillo
-- Fecha: 16 Enero 2014
-- Descripción General: Movimientos de la Cartera de Abogados Internos de la Cobranza
-- =============================================
BEGIN
--Variables que se utilizaran durante el proceso
--DECLARE @fActual SMALLDATETIME
DECLARE @fAnterior SMALLDATETIME
DECLARE @mesActual VARCHAR(7)
DECLARE @mesAnterior VARCHAR(7)
DECLARE @Consulta VARCHAR(8000)

--Se asigna la fecha de la tabla CatFechas
--SET @fActual = (SELECT Fecha FROM CatFechas)
--Se asigna la fecha anterior
SET @fAnterior = (DATEADD(MONTH, -1, @fActual))
--Se asigna el nombre del mes actual, ejemplo: Ene2014
SET @mesActual = RTRIM(dbo.fnCalculaNombreMes(@fActual))
--Se asigna el nombre del mes anterior, ejemplo: Dic2013
SET @mesAnterior = RTRIM(dbo.fnCalculaNombreMes(@fAnterior))

--Se seleccionan los clientes de la Cartera de Abogados que existan en la tabla ListaAbogados del mes anterior
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE name = 'tmpAbogados_MesAnterior')DROP TABLE tmpAbogados_MesAnterior 
SET @Consulta = '
SELECT NumerodeCliente,NombredelCliente,AbogadoInterno,SaldoRopa SaldoRopaInicial,SaldoTiempoAire SaldoTiempoAireInicial,SaldoMuebles SaldoMueblesInicial,SaldoPrestamos SaldoPrestamosInicial
INTO tmpAbogados_MesAnterior 
FROM ods.'+@mesAnterior+'.dbo.MaeCarteradeAbogados
WHERE AbogadoInterno in (SELECT Num_Empleado FROM dbo.ListaAbogados)'
EXEC (@Consulta)

--Se seleccionan los clientes de la Cartera de Abogados que existan en la tabla ListaAbogados del mes actual
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE name = 'tmpAbogados_MesActual')DROP TABLE tmpAbogados_MesActual
SET @Consulta = '
SELECT NumerodeCliente,NombredelCliente,AbogadoInterno,SaldoRopa SaldoRopaFinal,SaldoTiempoAire SaldoTiempoAireFinal,SaldoMuebles SaldoMueblesFinal,SaldoPrestamos SaldoPrestamosFinal
INTO tmpAbogados_MesActual 
FROM ods.'+@mesActual+'.dbo.MaeCarteradeAbogados
WHERE AbogadoInterno in (SELECT Num_Empleado FROM dbo.ListaAbogados)'
EXEC (@Consulta)

--Se le pega el nombre y numero del empleado a la tabla de los abogados del mes anterior
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE name = 'Abogados_MesAnterior')DROP TABLE Abogados_MesAnterior
SELECT * 
INTO Abogados_MesAnterior
FROM tmpAbogados_MesAnterior a
LEFT JOIN ListaAbogados b
ON (a.AbogadoInterno=b.Num_Empleado)

--Se le pega el nombre y numero del empleado a la tabla de los abogados del mes actual
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE name = 'Abogados_MesActual')DROP TABLE Abogados_MesActual
SELECT * 
INTO Abogados_MesActual
FROM tmpAbogados_MesActual a
LEFT JOIN ListaAbogados b
ON (a.AbogadoInterno=b.Num_Empleado)

--Se cruzan las tablas de izquierda a derecha de abogadoanterios con la de abogadoactual y se asignan cero los campos nulos
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE name = 'CarAbogados')DROP TABLE CarAbogados
SELECT a.NumerodeCliente,a.NombredelCliente,ISNULL(SaldoRopaInicial,0)SaldoRopaInicial,ISNULL(SaldoRopaFinal,0)SaldoRopaFinal,ISNULL(SaldoTiempoAireInicial,0)SaldoTiempoAireInicial,ISNULL(SaldoTiempoAireFinal,0)SaldoTiempoAireFinal,ISNULL(SaldoMueblesInicial,0)SaldoMueblesInicial,ISNULL(SaldoMueblesFinal,0)SaldoMueblesFinal,ISNULL(SaldoPrestamosInicial,0)SaldoPrestamosInicial,ISNULL(SaldoPrestamosFinal,0)SaldoPrestamosFinal,a.Num_Empleado,a.nom_Abogado
INTO CarAbogados
FROM Abogados_MesAnterior a
LEFT JOIN Abogados_MesActual b
ON (a.NumerodeCliente=b.NumerodeCliente and a.Num_Empleado=b.Num_Empleado)

--Se calcula el Saldo Ropa+TiempoAire anterior y actual
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE name = 'CarAbogadosFINAL')DROP TABLE CarAbogadosFINAL
SELECT NumerodeCliente,NombredelCliente,(SaldoRopaInicial+SaldoTiempoAireInicial)SaldoRTAInicial,(SaldoRopaFinal+SaldoTiempoAireFinal)SaldoRTAFinal,SaldoMueblesInicial,SaldoMueblesFinal,
SaldoPrestamosInicial,SaldoPrestamosFinal,Num_Empleado,nom_Abogado
INTO CarAbogadosFINAL
FROM CarAbogados

--Se seleccionan solo los renglones que tengan un valor mayor a cero
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE name = 'CarteraAbogados')DROP TABLE CarteraAbogados
SELECT *--, 'ABOGADO: '+Nom_Abogado+' NUMERO EMPLEADO: '+CAST(Num_Empleado as VARCHAR(15))Abogado
INTO CarteraAbogados
FROM CarAbogadosFINAL
WHERE SaldoRTAInicial>0 or SaldoRTAFinal>0 or SaldoMueblesInicial>0 or SaldoMueblesFinal>0 or SaldoPrestamosInicial>0 or SaldoPrestamosFinal>0

--Se borra donde el saldo inicial es mayor a cero y el saldo final es igual a cero (Ropa y Tiempo Aire)
DELETE FROM CarteraAbogados
WHERE SaldoRTAInicial>0 and SaldoRTAFinal=0 

--Se borra donde el saldo inicial es mayor a cero y el saldo final es igual a cero (Muebles)
DELETE FROM CarteraAbogados
WHERE SaldoMueblesInicial>0 and SaldoMueblesFinal=0

--Se borra donde el saldo inicial es mayor a cero y el saldo final es igual a cero (Prestamos)
DELETE FROM CarteraAbogados
WHERE SaldoPrestamosInicial>0 and SaldoPrestamosFinal=0

--Se calcula el numero de clientes de la cartera de abogados
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE name = 'NumeroClientes') DROP TABLE NumeroClientes
SELECT Num_Empleado,nom_Abogado,COUNT(*)NumeroClientes
INTO NumeroClientes
FROM CarteraAbogados
GROUP BY Num_Empleado,nom_Abogado
ORDER BY NumeroClientes DESC

--Se une a la tabla CarteraAbogado para crear la tabla final (se le pega el numero de clientes por abogado)
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE name = 'CarteraAbogados_FINAL') DROP TABLE CarteraAbogados_FINAL
SELECT NumerodeCliente,NombredelCliente,SaldoRTAInicial,SaldoRTAFinal,SaldoMueblesInicial,SaldoMueblesFinal,SaldoPrestamosInicial,SaldoPrestamosFinal,a.Num_Empleado,a.nom_Abogado, 'ABOGADO: ' + a.Nom_Abogado + '   NUMERO EMPLEADO: ' +CAST(a.Num_Empleado AS VARCHAR(15))+
'   CARTERA ASIGNADA (# de CTES): '+CAST(b.NumeroClientes AS VARCHAR(7))Abogado  
INTO CarteraAbogados_FINAL
FROM CarteraAbogados a
LEFT JOIN NumeroClientes b
 ON (a.Num_Empleado=b.Num_Empleado)
 
END
GO