
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    Phonenumber CHAR(11) NOT NULL,
    Role NVARCHAR(20) NOT NULL,
    Address NVARCHAR(255) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    LicenseNumber NVARCHAR(50) NULL,      
    IsAvailable BIT NULL                  
);
