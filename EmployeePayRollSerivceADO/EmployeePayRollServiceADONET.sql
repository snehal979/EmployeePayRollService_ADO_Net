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
-------------------------------------------------------
--Uc8
--EMPLOYEE TABLE
CREATE TABLE EmployeeDetail_ado(
EmpId INT PRIMARY KEY IDENTITY(1,1),
EmpName VARCHAR(150) NOT NULL,
Gender VARCHAR(10) NOT NULL,
);
------------Data insert Uc 8----------------
INSERT INTO EmployeeDetail_ado(EmpName,Gender)VALUES('Snehal','Female');
INSERT INTO EmployeeDetail_ado(EmpName,Gender)VALUES('Mayur','Male');
INSERT INTO EmployeeDetail_ado(EmpName,Gender)VALUES('Raju','Male');
INSERT INTO EmployeeDetail_ado(EmpName,Gender)VALUES('Lata','Female');
INSERT INTO EmployeeDetail_ado(EmpName,Gender)VALUES('Vaibhav','Male');
---Display---
SELECT *FROM EmployeeDetail_ado;
-- Salary Table
CREATE TABLE Salary_ado(
BasicPay BIGINT DEFAULT(000),
Deduction BIGINT DEFAULT(000),
Tax BIGINT DEFAULT(000),
EmpId INT FOREIGN KEY REFERENCES EmployeeDetail_ado(EmpId),
NetPay Bigint 
);
INSERT INTO Salary_ado(BasicPay,Deduction,Tax,EmpId) VALUES(10000000,2000,34333,1);
INSERT INTO Salary_ado(BasicPay,Deduction,Tax,EmpId) VALUES(20000000,5000,3435,2);

INSERT INTO Salary_ado(BasicPay,Deduction,Tax,EmpId) VALUES(1000000,4000,31333,3);

INSERT INTO Salary_ado(BasicPay,Deduction,Tax,EmpId) VALUES(10000000,2000,34333,4);
UPDATE Salary_ado SET NetPay = (BasicPay-Tax-Deduction);
SELECT *FROM Salary_ado;
SELECT EmpName,NetPay FROM EmployeeDetail_ado AS C
inner join Salary_ado AS D ON C.EmpId=D.EmpId; 