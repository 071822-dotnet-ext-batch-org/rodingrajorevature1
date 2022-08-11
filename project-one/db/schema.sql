DROP TABLE IF EXISTS Employee;
DROP TABLE IF EXISTS Ticket;

CREATE TABLE Employee(
    EmployeeID INT NOT NULL PRIMARY KEY IDENTITY(1000, 1),
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(50) NOT NULL,
    Fname NVARCHAR(50) NOT NULL,
    Lname NVARCHAR(50) NOT NULL,
    Role NVARCHAR(50) NOT NULL,
    Address NVARCHAR(50) NOT NULL,
    Phone NVARCHAR(50) NOT NULL,
    Photo VARBINARY(MAX) NOT NULL,
    ManagerID INT FOREIGN KEY REFERENCES Employee (EmployeeID),
    DateCreated DATETIME2 NOT NULL DEFAULT (GETDATE()),
    DateModified DATETIME2 NOT NULL DEFAULT (GETDATE())
);

CREATE TABLE Ticket(
    TicketID INT NOT NULL PRIMARY KEY IDENTITY(100, 1)
    Amount MONEY NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
    Status NVARCHAR(50) NOT NULL,
    Type NVARCHAR(100) NOT NULL,
    Receipt VARBINARY,
    FK_EmployeeID INT NOT NULL FOREIGN KEY REFERENCES Employee (EmployeeID),
    DateCreated DATETIME2 NOT NULL DEFAULT (GETDATE()),
    DateModified DATETIME2 NOT NULL DEFAULT(GETDATE())
)