use Carteras
go

select Num_Empleado,nom_Abogado,count(*)Total
from CarteraAbogados
group by Num_Empleado,nom_Abogado
order by Total desc

select count(*) 
from ODS.Dic2013.dbo.MaeCarteradeAbogados
where AbogadoInterno=95554882
--1,879

select * 
from ListaAbogados
where Num_Empleado=95554882
--95554882	BRENDA JANETTE OSORIO ESPINOSA

select count(*) 
from CarteraAbogados
--56,637
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
select count(*) 
from ODS.Dic2013.dbo.MaeCarteradeAbogados
where AbogadoInterno=92551963
--15

select * 
from ListaAbogados
where Num_Empleado=92551963
--92551963	MARIA LUISA RODRIGUEZ BADILLO

select Num_Empleado,nom_Abogado,count(*)Total
from CarteraAbogados
group by Num_Empleado,nom_Abogado
having Num_Empleado=92551963
order by Total desc