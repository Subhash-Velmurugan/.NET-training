create database assessment;
use assessment;
--create table books

create table Books (
    id int identity(1,1) primary key,
    title nvarchar(200) not null,
    author nvarchar(150) not null,
    isbn nvarchar(20) not null unique,
    published_date date
);
--create table reviews

create table Reviews (
    id int identity(1,1) primary key,
    book_id int not null,
    reviewer_name nvarchar(150) not null,
    content nvarchar(150) not null,
    published_date date,
    constraint FK_Reviews_Books
        foreign key (book_id) references Books(id)
);

ALTER TABLE Reviews
ADD ratings INT
    CONSTRAINT CK_Reviews_Ratings CHECK (ratings BETWEEN 1 AND 5);

--insert values to tables

insert into Books (title, author, isbn, published_date) 
values
('My first Sql book','Mary Parker','981483029127','2012-02-22'),
('My second Sql book','John Mayer','857300923713','1972-07-03'),
('My Third sql book','Cary Flint','523120967812','2015-10-18')
 
insert into Reviews(book_id,reviewer_name,content,ratings,published_date)
values
(1,'John Smith','my first review',4,'2017-12-10'),
(2,'John Smith','my second review',5,'2017-10-13'),
(2,'Alice Walker','another review',1,'2017-10-22')

--customer table
create table Customers(
id int identity primary key,
name varchar(150) not null,
age int not null,
address varchar(150) not null,
salary float not null)

insert into Customers(name,age,address,salary)
values
('ramesh',32,'ahmedabad',2000.00),
('khilan',25,'delhi',1500.00),
('kaushik',23,'delhi',2000.00),
('chaitali',25,'mumbai',6500.00),
('hardik',27,'bhopal',8500.00),
('komal',22,'MP',4500.00),
('muffy',24,'indore',10000.00)
--order table
create table Orders(
oid int primary key,
date date not null,
customer_id int not null,
amount int not null,
constraint FK_Customer_ID
        foreign key (customer_id) references Customers(id))

INSERT INTO Orders (OID, DATE, CUSTOMER_ID, AMOUNT)
VALUES
(102, '2009-10-08 00:00:00', 3, 3000),
(100, '2009-10-08 00:00:00', 3, 1500),
(101, '2009-11-20 00:00:00', 2, 1560),
(103, '2008-05-20 00:00:00', 4, 2060);

--employee
create table employees(
id int identity primary key,
name varchar(150) not null,
age int not null,
address varchar(150) not null,
salary float null )
insert into employees(name,age,address,salary)
values
('ramesh',32,'ahmedabad',2000.00),
('khilan',25,'delhi',1500.00),
('kaushik',23,'delhi',2000.00),
('chaitali',25,'mumbai',6500.00),
('hardik',27,'bhopal',8500.00),
('komal',22,'MP',null),
('muffy',24,'indore',null)

--1. Write a query to fetch the details of the books written by author whose name ends with er

select *
from Books
where author LIKE '%er'
--2.Display the Title ,Author and ReviewerName for all the books from the above table
select
    b.title,
    b.author,
    r.reviewer_name
from Books b
inner join Reviews r
    on b.id = r.book_id;
--3.Display the  reviewer name who reviewed more than one book. 

SELECT
    reviewer_name
FROM Reviews
GROUP BY reviewer_name
HAVING COUNT(DISTINCT book_id) > 1;
--4.Display the Name for the customer from above customer table  who live in same address which has character o anywhere in address 

SELECT name
FROM Customers 
WHERE address LIKE '%o%'
--5.Write a query to display the   Date,Total no of customer  placed order on same Date  

SELECT
    DATE,
    COUNT(DISTINCT CUSTOMER_ID) AS Total_Customers
FROM Orders
GROUP BY DATE;
--6.employees where salary is null 
SELECT LOWER(name) AS employee_name
FROM employees
WHERE SALARY IS NULL;
USE assessment
select * from employees