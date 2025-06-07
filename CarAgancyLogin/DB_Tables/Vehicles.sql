
CREATE TABLE Vehicles (
    VehicleID INT PRIMARY KEY IDENTITY,
    VehicleType NVARCHAR(20),             
    PlateNumber NVARCHAR(20) NOT NULL,
    Model NVARCHAR(50),
    Color NVARCHAR(20),
    ManufactureYear INT,
    FuelType NVARCHAR(20),
    InsuranceExpiryDate DATE,
    DriverUsername NVARCHAR(50) NOT NULL,
    FOREIGN KEY (DriverUsername) REFERENCES Users(Username)
);
