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
SET Address = '234 Train St.'
-- EmployeeID is a GUID
WHERE EmployeeID = ;

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
-- TicketID is a GUID
WHERE TicketID = ;

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
-- TicketID is a GUID
WHERE TicketID = ;

UPDATE [dbo].[Ticket]
SET Status = "Approved"
-- TicketID is a GUID
WHERE TicketID = ;