--create database
Create Database EmployeePayRoleADO
--Create table 
CREATE TABLE employeePayRoleTable(
Id INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(150) NOT NULL,
Salary BIGINT NOT NULL,
Gender Varchar(10) NOT NULL
);
--Insert data
INSERT INTO employeePayRoleTable(Name,Salary,Gender)VALUES
('Snehal',1000000.00,'Female'),
('Mayur',1500000.00,'Male'),
('Vaibhav',2000000.00,'Male'),
('Raju',2000000.00,'Male'),
('Lata',2000000.00,'Female');
SELECT * FROM employeePayRoleTable 
INSERT INTO employeePayRoleTable(Name,Salary,Gender)VALUES
('Terisa',000000.00,'Female');
SELECT * FROM employeePayRoleTable where Name ='Snehal'

-----------------Uc5------------------
Create Procedure fetchGetEmployees
as  
begin  
   select *from employeePayRoleTable
End 
--execute fetchGetEmployees
--Add data
Create procedure spAddNewEmpPayRoll
(  
  @Name VARCHAR(50),
  @Salary BIGINT,
  @Gender Varchar(50)
)  
as  
begin  
   INSERT INTO employeePayRoleTable (Name,Salary,Gender)VALUES(@Name,@Salary,@Gender)
End 

--UpdateData
Create procedure spUpdateEmpDetails  
(  
   @Id int,
   @Name VARCHAR(50),
  @Salary BIGINT,
  @Gender Varchar(50)  
)  
as  
begin  
   Update employeePayRoleTable set Name=@Name,Salary=@Salary,Gender=@Gender where Id=@Id  
End 
--execute spUpdateEmpDetails 8,'Sachin',353255,'Male'

--Delete data
Create procedure spDeleteEmpByIdEmployee 
(  
   @Id int  
)  
as   
begin  
  DELETE FROM employeePayRoleTable WHERE Id = @Id
End 
--execute spDeleteEmpByIdEmployee 8
--------------------------------------------------------
drop table employeePayRoleTable