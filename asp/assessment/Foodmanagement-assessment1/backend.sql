
create database foodmanagement
use foodmanagement
CREATE TABLE MenuItems (
    MenuId INT PRIMARY KEY IDENTITY(1,1),
    ItemName NVARCHAR(100),
    Category NVARCHAR(50),
    FoodType NVARCHAR(20),
    Price DECIMAL(10,2),
    AvailableQuantity INT,
    IsAvailable BIT,
    CreatedDate DATETIME DEFAULT GETDATE()
);
INSERT INTO MenuItems(ItemName, Category, FoodType, Price, AvailableQuantity, IsAvailable)
VALUES ('pizza', 'Fast Food', 'Veg', 120, 10, 1)
select * from MenuItems