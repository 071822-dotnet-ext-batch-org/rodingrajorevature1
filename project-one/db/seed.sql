INSERT INTO [dbo].[Employee] (Username, Password, Fname, Lname, Role, Address, Phone)
VALUES ('testuser1', 'password', 'Nick', 'Mullen', 'Manager', '123 Lemon Ave.', '123-349-4920');

INSERT INTO [dbo].[Employee] (Username, Password, Fname, Lname, Role, Address, Phone, ManagerID)
-- add manager id
VALUES ('testuser2', 'password', 'Adam', 'Friedland', 'Employee', '345 Grove St.', '678-867-5309');

INSERT INTO [dbo].[Employee] (Username, Password, Fname, Lname, Role, Address, Phone, ManagerID)
-- add manager id
VALUES ('testuser3', 'password', 'Stavros', 'Halkias', 'Employee', '492 Orange Ln.', '225-588-6654');

INSERT INTO [dbo].[Ticket] (Amount, Description, Status, Type, FK_EmployeeID, FK_ProcessingManagerID)
-- add employee id and manager id
VALUES (100.23, 'Bowling', 'Pending', 'Schmoozing with Client');

INSERT INTO [dbo].[Ticket] (Amount, Description, Status, Type, FK_EmployeeID, FK_ProcessingManagerID)
-- add employee id and manager id
VALUES (2000, 'Car Down Payment', 'Denied', 'Travel');

INSERT INTO [dbo].[Ticket] (Amount, Description, Status, Type, FK_EmployeeID, FK_ProcessingManagerID)
-- add employee id and manager id
VALUES (20.45, 'Gas', 'Approved', 'Travel');