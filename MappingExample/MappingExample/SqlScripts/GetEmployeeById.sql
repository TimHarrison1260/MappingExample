Use NDbT_Lab1
go

Declare @EmpId int;
Set @EmpId = 2;

Select e.Id as EmployeeId,
	e.Name,
	e.UserName,
	e.PhoneNumber,
	e.SupervisorId,
	e.DeptId,
	e.AddressId,
	e.Type,
	e.PayGrade,
	d.Name as DeptName,
	a.PostCode,
	a.PropertyName,
	a.PropertyNumber
From Employee e
Join Department d on d.Id = e.DeptId
Join Address a on a.Id = e.AddressId
where e.Id = @EmpId