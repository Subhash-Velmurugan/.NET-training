CREATE DATABASE TrainReservationDB;
USE TrainReservationDB;
CREATE TABLE Users (
    UserId INT IDENTITY PRIMARY KEY,
    Username VARCHAR(50) UNIQUE,
    Password VARCHAR(100),
    UserType VARCHAR(10) CHECK (UserType IN ('admin','user'))
);
INSERT INTO Users (Username, Password, UserType)
VALUES ('admin', 'admin@123', 'admin');
CREATE TABLE Train (
    TrainNo INT PRIMARY KEY,
    TrainName VARCHAR(50),
    FromStation VARCHAR(50),
    ToStation VARCHAR(50),
    Class VARCHAR(10),
    Availability INT,
    Charges DECIMAL(10,2),
    IsDeleted BIT DEFAULT 0
);
CREATE TABLE Booking (
    BookingId INT IDENTITY PRIMARY KEY,
    BookDate DATETIME DEFAULT GETDATE(),
    TravelDate DATE,
    TrainNo INT,
    TravelClass VARCHAR(10),
    Passengers INT CHECK (Passengers <= 3),
    Amount DECIMAL(10,2),
    FOREIGN KEY (TrainNo) REFERENCES Train(TrainNo)
);

CREATE TABLE Cancellation (
    CId INT IDENTITY PRIMARY KEY,
    BookingId INT,
    NoTickets INT DEFAULT 1,
    RefundAmt DECIMAL(10,2) DEFAULT 900,
    FOREIGN KEY (BookingId) REFERENCES Booking(BookingId)
);
