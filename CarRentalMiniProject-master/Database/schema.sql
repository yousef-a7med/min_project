CREATE DATABASE CarRentalDB;
GO

USE CarRentalDB;
GO

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Phone_Num NVARCHAR(30),
    Customer_Type NVARCHAR(20) NOT NULL,
    License_Num NVARCHAR(50) NOT NULL,
    IsStudent BIT NOT NULL DEFAULT 0
);

CREATE TABLE Vehicles (
    VehicleID INT PRIMARY KEY,
    Brand NVARCHAR(100) NOT NULL,
    License_Plate NVARCHAR(50) NOT NULL UNIQUE,
    Status NVARCHAR(30) NOT NULL,
    VehicleType NVARCHAR(30) NOT NULL,
    DailyPrice DECIMAL(10,2) NOT NULL
);

CREATE TABLE Discounts (
    DiscountID INT PRIMARY KEY,
    DiscountName NVARCHAR(100) NOT NULL,
    Percentage DECIMAL(5,2) NOT NULL
);

CREATE TABLE Bookings (
    BookingID INT PRIMARY KEY,
    CustomerID INT NOT NULL,
    VehicleID INT NOT NULL,
    DiscountID INT NULL,
    RentalDays INT NOT NULL,
    BaseTotal DECIMAL(10,2) NOT NULL,
    DiscountAmount DECIMAL(10,2) NOT NULL,
    FinalTotal DECIMAL(10,2) NOT NULL,
    BookingDate DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (VehicleID) REFERENCES Vehicles(VehicleID),
    FOREIGN KEY (DiscountID) REFERENCES Discounts(DiscountID)
);

CREATE TABLE Invoices (
    InvoiceID INT PRIMARY KEY,
    BookingID INT NOT NULL,
    Amount DECIMAL(10,2) NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (BookingID) REFERENCES Bookings(BookingID)
);

CREATE TABLE Logs (
    LogID INT PRIMARY KEY,
    BookingID INT NULL,
    Message NVARCHAR(500) NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (BookingID) REFERENCES Bookings(BookingID)
);
