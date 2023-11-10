

CREATE TABLE Employee (
    empno INT PRIMARY KEY,
    empname VARCHAR(255),
    salary DECIMAL(10, 2),
    bossno INT null
    FOREIGN KEY (bossno) REFERENCES Employee(empno) 
	)

create table Department1
(deptname varchar(50)  primary key,floor int,phone varchar(10),empno int not null foreign key (empno) references Employee(empno));

alter table Employee
add deptname varchar(50) null foreign key (deptname) references Department1(deptname)
 
 create table item
 (itemname int constraint pk_itemname primary key,itemtype varchar(50),itemcolor varchar(30));
 sp_help Employee
 
create table sales 
(salesno int constraint pk_salesno primary key ,saleqty int,itemname int not null foreign key (itemname) references item(itemname));
 alter table sales
 add deptname varchar(50) not null foreign key (deptname) references Department1(deptname)
 
insert into Employee values(1,'Alice', 75000 ,'Management'),(2 ,'Ned', 45000,'Marketing', 1),(3, 'Andrew', 25000 ,'Marketing', 2),(4, 'Clare', 22000,'Marketing', 2)
insert into Employee values(5,'Todd', 38000,1, 'Accounting'),(6,'Nancy', 22000 ,'Accounting', 5),(7, 'Brier', 43000, 'Purchasing', 1),(8 ,'Sarah', 56000, 'Purchasing', 7)
insert into Employee values(9,'Sophile', 35000 ,'Personnel', 1),(10,' Sanjay', 15000, 'Navigation;, 3),(11, 'Rita', 15000, 'Books' 4),(12,'Gigi' ,16000,'Clothes', 4)
insert into  Employee values(13, 'Maggie', 11000, 'Clothes', 4),(14,'Paul' ,15000,'Equipment', 3),(15, 'James' ,15000, 'Equipment', 3),(16, 'Pat' ,15000, 'Furniture' ,3)
insert into Employee values(17, 'Mark' ,15000, 'Recreation' ,3)

insert into Department1 values('Management', 5, 34, 1),('Books', 1, 81, 4),('Clothes', 2, 24, 4),('Equipment', 3, 57, 3),('Furniture' ,4 ,14 ,3),('Navigation', 1, 41, 3)
insert into Department1 values('Recreation', 2, 29, 4),('Accounting', 5, 35, 5),('Purchasing' ,5 ,36, 7),('Personnel', 5, 37, 9),('Marketing' ,5, 38, 2)

insert into sales values(101, 2, 'Boots-snake proof',' Clothes'),(102, 1, 'Pith Helmet' 'Clothes'),(103, 1, 'Sextant' 'Navigation'),(104, 3, 'Hat-polar Explorer' 'Clothes'),(105, 5, 'Pith Helmet' 'Equipment)
insert into sales values(106, 2, 'Pocket Knife-Nile', 'Clothes'),(107, 3, 'Pocket Knife-Nile', 'Recreation'),(108, 1, 'Compass',' Navigation'),(109, 2, 'Geo positioning system', 'Navigation'),(110, 5 ,'Map Measure', 'Navigation')

insert into ITEM(itemname,itemtype,itemcolor) values('Pocket Knife-Nile','E','Brown')
insert into ITEM(itemname,itemtype,itemcolor) values ('Pocket KnifAvon','E','Brown'),('Compass','E',null),('Geopositioningsystem','N',null),('Elephant Polo stick ','R','Bamboo'),('Camel Saddle','R',' Brown'),('Sextant',' N',null),
insert into ITEM(itemname,itemtype,itemcolor) values('Map Measure',' N',null),('Boots-snake proof',' C',' Green'),('Pith Helmet',' C',' Khaki'),('Hat-polar Explorer',' C',' White'),('Exploring in 10 Easy Lessons','B',null),('Hammock ','F',' Khaki'),
insert into ITEM(itemname,itemtype,itemcolor) values('How to win Foreign Friends',' B',null),('Map case ','E',' Brown'),('Safari Chair',' F',' Khaki'),('Safari cooking kit',' F',' Khaki'),('Stetson',' C',' Black'),('Tent - 2 person ','F',' Khaki'),('Tent -8 person','F' ,'Khaki');

