USE Carteras
GO

-- =============================================
-- Autor: Antonio Acosta Murillo
-- Fecha: 15 Enero 2014
-- Descripción General: Movimientos de la Cartera de Abogados Internos de la Cobranza
-- =============================================
-- =============================================

DECLARE @fActual SMALLDATETIME
DECLARE @fAnterior SMALLDATETIME
DECLARE @mesActual VARCHAR(12)
DECLARE @mesAnterior VARCHAR(12)
DECLARE @Consulta VARCHAR(8000)

SET @fActual = (SELECT Fecha FROM CatFechas)
SET @fAnterior = DATEADD(MONTH, -1, @fActual)
SET @mesActual = dbo.fnCalculaNombreMes(@fActual)
SET @mesAnterior = dbo.fnCalculaNombreMes(@fAnterior)

SELECT @fActual, @mesActual, @fAnterior, @mesAnterior

SET @Consulta = ''
EXECUTE @Consulta


--Seleccionas los abogados que existan en la tabla temporal "ListaAbogados" de la Cartera de abogados
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'CarteraAbogados_Dic2013') DROP TABLE CarteraAbogados_Dic2013
SELECT numerodeCliente,nombredelcliente,abogadoInterno,saldoropa,SaldoTiempoAire,saldoMuebles,saldoPrestamos
INTO CarteraAbogados_Dic2013
FROM ODS.Dic2013.dbo.MaeCarteradeAbogados
WHERE AbogadoInterno in (SELECT Num_Empleado FROM dbo.ListaAbogados)

--Se le pega el nombre a los abogados internos
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'CarteraAbogados_FINAL_Dic2013') DROP TABLE CarteraAbogados_FINAL_Dic2013
SELECT numerodeCliente,nombredelcliente,abogadoInterno,saldoropa,SaldoTiempoAire,saldoMuebles,saldoPrestamos, b.*
INTO CarteraAbogados_FINAL_Dic2013
FROM CarteraAbogados a
LEFT JOIN dbo.ListaAbogados b
ON (a.abogadoInterno=b.Num_Empleado)

select Nom_Abogado,Num_Empleado, NumeroDelCliente,NombredelCliente from CarteraAbogados_FINAL_Dic2013

GO


--Seleccionas los abogados que existan en la tabla temporal "ListaAbogados" de la Cartera de abogados
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'CarteraAbogados_Nov2013') DROP TABLE CarteraAbogados_Nov2013
SELECT *
INTO CarteraAbogados_Nov2013
FROM ODS.Nov2013.dbo.MaeCarteradeAbogados
WHERE AbogadoInterno in (SELECT Num_Empleado FROM dbo.ListaAbogados)

--Se le pega el nombre a los abogados internos
IF EXISTS(SELECT * FROM SYSOBJECTS WHERE name = 'CarteraAbogados_FINAL_Nov2013') DROP TABLE CarteraAbogados_FINAL_Nov2013
SELECT *
INTO CarteraAbogados_FINAL_Nov2013
FROM CarteraAbogados a
LEFT JOIN dbo.ListaAbogados b
ON (a.abogadoInterno=b.Num_Empleado)

select top 10 * from CarteraAbogados_FINAL_Dic2013


select count(*) from CarteraAbogados_FINAL_Dic2013
go
select count(*) from CarteraAbogados_FINAL_Nov2013
go

select *
from CarteraAbogados_FINAL_Nov2013 a 
full join CarteraAbogados_FINAL_Dic2013 b
on (a.NumerodeCliente=b.NumerodeCliente and a.AbogadoInterno=b.AbogadoInterno)