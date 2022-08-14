DROP TRIGGER EmployeeUpdateDateModified;
DROP TRIGGER TicketUpdateDateModified;
DROP TRIGGER TicketUpdateDateProcessed;

CREATE TRIGGER EmployeeUpdateDateModified
ON [dbo].[Employee]
AFTER UPDATE
AS
BEGIN
    UPDATE [dbo].[Employee]
    SET DateModified = GETDATE()
    WHERE EmployeeID = (SELECT DISTINCT EmployeeID FROM Inserted)
END;

UPDATE [dbo].[Employee]
SET Address = "234 Train St."
WHERE EmployeeID = 1000;

CREATE TRIGGER TicketUpdateDateModified
ON [dbo].[Ticket]
AFTER UPDATE
AS
BEGIN
    UPDATE [dbo].[Ticket]
    SET DateModified = GETDATE()
    WHERE TicketID = (SELECT DISTINCT TicketID FROM Inserted)
END;

UPDATE [dbo].[Ticket]
SET Amount = 150.20
WHERE TicketID = 100;

CREATE TRIGGER TicketUpdateDateProcessed
ON [dbo].[Ticket]
AFTER UPDATE
AS
IF (UPDATE (Status))
BEGIN
    UPDATE [dbo].[Ticket]
    SET DateProcessed = GETDATE()
    WHERE TicketID = (SELECT DISTINCT TicketID FROM Inserted)
END;

UPDATE [dbo].[Ticket]
SET Amount = 125.45
WHERE TicketID = 100;

UPDATE [dbo].[Ticket]
SET Status = "Approved"
WHERE TicketID = 100;