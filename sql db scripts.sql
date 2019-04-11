CREATE DATABASE [TestDB_Nomthi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TestDB_Nomthi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TestDB_Nomthi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TestDB_Nomthi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TestDB_Nomthi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

create table Employee
(
	EmployeeID int not null identity (1,1),
	FirstName varchar(64) not null,
	LastName varchar (64) not null,
	Email varchar(25) not null,
	CellNumber varchar(25) not null,
	LandLine varchar (25),
	AddressLine1 varchar(64) not null,
	AddressLine2 varchar(64) not null,
	PostalCode varchar(10) not null,
	Facebook varchar(64),
	LinkedIn varchar(64),
	TwitterHandle varchar(64),
	InstagramHandle varchar(64),
	Active bit not null constraint DF_Employee_Active default (1), 
	constraint PK_Employee primary key clustered (EmployeeID)	
)
go
create procedure [dbo].prcGet_Employee
(
	@pEmployeeID int
)
as
select
	Employee.EmployeeID,
	Employee.FirstName,
	Employee.LastName,
	Employee.Email,
	Employee.CellNumber,
	Employee.LandLine,
	Employee.AddressLine1,
	Employee.AddressLine2,
	Employee.PostalCode,
	Employee.Facebook,
	Employee.LinkedIn,
	Employee.TwitterHandle,
	Employee.InstagramHandle,
	Employee.Active
from
	[dbo].Employee as Employee
where
	Employee.EmployeeID = @pEmployeeID
go
create procedure [dbo].prcList_Employee
as
select
	Employee.EmployeeID,
	Employee.FirstName,
	Employee.LastName,
	Employee.Email,
	Employee.CellNumber,
	Employee.LandLine,
	Employee.AddressLine1,
	Employee.AddressLine2,
	Employee.PostalCode,
	Employee.Facebook,
	Employee.LinkedIn,
	Employee.TwitterHandle,
	Employee.InstagramHandle,
	Employee.Active
from
	[dbo].Employee as Employee
order by
	Employee.EmployeeID
go
create procedure [dbo].prcInsert_Employee
(
	@pFirstName varchar(64),
	@pLastName varchar(64),
	@pEmail varchar(25),
	@pCellNumber varchar(25),
	@pLandLine varchar(25),
	@pAddressLine1 varchar(64),
	@pAddressLine2 varchar(64),
	@pPostalCode varchar(10),
	@pFacebook varchar(64),
	@pLinkedIn varchar(64),
	@pTwitterHandle varchar(64),
	@pInstagramHandle varchar(64)
)
as
insert into [dbo].Employee (FirstName,LastName,Email,CellNumber,LandLine,AddressLine1,AddressLine2,PostalCode,Facebook,LinkedIn,TwitterHandle,InstagramHandle) 
select
	@pFirstName,
	@pLastName,
	@pEmail,
	@pCellNumber,
	@pLandLine,
	@pAddressLine1,
	@pAddressLine2,
	@pPostalCode,
	@pFacebook,
	@pLinkedIn,
	@pTwitterHandle,
	@pInstagramHandle
--return new employee id
select scope_identity()
go
create procedure [dbo].prcUpdate_Employee
(
	@pEmployeeID int,
	@pFirstName varchar(64),
	@pLastName varchar(64),
	@pEmail varchar(25),
	@pCellNumber varchar(25),
	@pLandLine varchar(25),
	@pAddressLine1 varchar(64),
	@pAddressLine2 varchar(64),
	@pPostalCode varchar(10),
	@pFacebook varchar(64),
	@pLinkedIn varchar(64),
	@pTwitterHandle varchar(64),
	@pInstagramHandle varchar(64),
	@pCreatedBy varchar(64),
	@pActive bit
)
as
update
	[dbo].Employee
set
	Employee.FirstName = @pFirstName,
	Employee.LastName = @pLastName,
	Employee.Email = @pEmail,
	Employee.CellNumber = @pCellNumber,
	Employee.LandLine = @pLandLine,
	Employee.AddressLine1 = @pAddressLine1,
	Employee.AddressLine2 = @pAddressLine2,
	Employee.PostalCode = @pPostalCode,
	Employee.Facebook = @pFacebook,
	Employee.LinkedIn = @pLinkedIn,
	Employee.TwitterHandle = @pTwitterHandle,
	Employee.InstagramHandle = @pInstagramHandle,
	Employee.Active = @pActive
where	
	Employee.EmployeeID = @pEmployeeID

--return success/failure indicator
select
	case	
		when @@ROWCOUNT > 0 then 'true'
		else 'false'
	end as Success
go
create procedure [dbo].prcDelete_Employee
(
	@pEmployeeID int,
	@pHardDelete bit = 0
)
as
begin try
	--update to inactive (always do this so the history trigger knows who deleted the record)
	update
		[dbo].Employee
	set
		Employee.Active = 0
	where
		    Employee.EmployeeID = @pEmployeeID

	-- delete row from table
	delete from
		[dbo].Employee
	where
		    Employee.EmployeeID = @pEmployeeID
		and @pHardDelete = 1
	
	select 'true'

end try
begin catch

	select 'false'

end catch
go