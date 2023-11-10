use pubs

select * from publishers

select * from titles
--select publisher name and the title name
select pub_name 'Publisher Name', title 'Book Name' from publishers join titles
on publishers.pub_id = titles.pub_id

select pub_name 'Publisher Name', title 'Book Name' 
from publishers p join titles t
on p.pub_id = t.pub_id

select p.pub_id 'Publisher Id', pub_name 'Publisher Name', title 'Book Name' 
from publishers p join titles t
on p.pub_id = t.pub_id
order by [Publisher Name]

--outer JOin
select pub_name 'Publisher Name', title 'Book Name' 
from publishers left outer join titles
on publishers.pub_id = titles.pub_id

select t.title Book_Name, s.qty Quantity_Sold
from sales s right outer join titles t
on s.title_id = t.title_id

--Publisher name and the count of book published
select pub_name 'Publisher Name', count(p.pub_id) 'Number of books published'
from publishers p join titles t
on p.pub_id = t.pub_id
group by pub_name
order by [Publisher Name]


--print the publisher name and employee name
select * from authors
select * from titles
select * from titleauthor

select title 'Book Name', CONCAT(au_fname,' ',au_lname) 'Author Name'
from titles t join titleauthor ta
on t.title_id = ta.title_id 
join authors a on ta.au_id = a.au_id

--Select the publisher name, title name and the sold quantity

select pub_name 'Publisher_Name',title 'title_name',qty 'Sold_qty'
from publishers p join titles t
on p.pub_id = t.pub_id
join sales s on t.title_id = s.title_id
--cross join
select * from sales cross join employee


create table tbl1
(f1 int,
f2 varchar(20))

insert into tbl1 values(1,'abc'),(2,'efg'),(3,'klj'),(4,'jjj')
--data injection
select * from tbl1 where f1=1;delete  from tbl1;

create procedure proc_First
as
begin
    select * from authors
end

execute proc_First

create proc proc_InsertSample(@f1 int, @f2 varchar(20))
as
begin
   insert into tbl1 values(@f1,@f2)
end

exec proc_InsertSample 5,'GYH'
exec proc_InsertSample 5,'GYH;delete from tbl1'

create proc proc_select(@f2 varchar(20))
as
begin
   
end
alter proc proc_Select(@f2 varchar(20))
as
begin
   select * from tbl1 where f2=@f2
end

exec proc_Select '1;delete from tbl1'

create function AuthorName(@fname varchar(50),@lname varchar(50))
returns varchar
as
begin
    declare @fullname varchar(100)
	set @fullname =concat(@fname, ' ', @lname)
	return @fullname
end
exec AuthorName 'ravi','sarma'
sp_help publishers
CREATE PROCEDURE GetTotalSalesByPublisher
    @PublisherName NVARCHAR(255)
AS
BEGIN
    SELECT
        SUM(S.qty * T.price) AS TotalSales
    FROM
        SALES S
    INNER JOIN TITLES T ON S.title_id = T.title_id
    INNER JOIN PUBLISHERS P ON T.pub_id = P.pub_id
    WHERE
        P.pub_name = @PublisherName;
END
 

EXEC GetTotalSalesByPublisher @PublisherName = 'New Moon Books'

--create a function that will take the author's first name and last name and 
--give back the full name separated by space
create view vwPublisher
as
select pub_id 'Publisher Id', pub_name 'Publisher Name'  from Publishers

select * from vwPublisher