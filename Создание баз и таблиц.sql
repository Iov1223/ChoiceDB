USE [master]
GO
CREATE DATABASE exampleDB1;
GO
USE exampleDB1;
GO
CREATE TABLE Users (
   Id INT PRIMARY KEY IDENTITY,
   Name VARCHAR(50) NOT NULL,
   Email VARCHAR(50) NOT NULL
);
GO
INSERT INTO Users
VALUES
('Ваня', 'vaniy@gmail.com'),
('Гена', 'gena@gmail.com'),
('Петя', 'petiy@gmail.com'),
('Дима', 'dima@gmail.com'),
('Веня', 'veniy@gmail.com');
GO
CREATE DATABASE exampleDB2;
GO
USE [master]
GO
USE exampleDB2;
GO
CREATE TABLE Products (
   Id INT PRIMARY KEY IDENTITY,
   Name VARCHAR(50) NOT NULL,
   Price DECIMAL(10,2) NOT NULL
);
GO
INSERT INTO Products
VALUES
('Капюшон Ку-клукс-клана', 15000.00),
('Ежовые рукавицы', 456.98),
('Миноискатель б/у', 1.00),
('Бивень мамонта', 5676.98),
('Лошадь Чапая', 100000.00);
GO