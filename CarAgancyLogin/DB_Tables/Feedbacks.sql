CREATE TABLE Feedbacks (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ReservationId INT NOT NULL,
    Rating INT NOT NULL,
    FeedbackDate DATETIME NOT NULL,
    CONSTRAINT FK_Feedbacks_Reservations FOREIGN KEY (ReservationId)
        REFERENCES Reservations(Id)
);
