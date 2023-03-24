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