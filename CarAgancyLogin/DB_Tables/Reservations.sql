CREATE TABLE Reservations (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CustomerName NVARCHAR(255) NOT NULL,
    PhoneNumber NVARCHAR(50) NOT NULL,
    SourceAddress NVARCHAR(255) NOT NULL,
    DestinationAddress NVARCHAR(255) NOT NULL,
    ReservationType NVARCHAR(50) NOT NULL,
    DriverUsername NVARCHAR(50) NOT NULL,
    ReservationDate DATETIME NOT NULL
);
