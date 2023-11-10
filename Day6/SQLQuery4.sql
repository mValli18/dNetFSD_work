use pubs
sp_help titles
select *from titles

select title as title_name from titles

select title as title_name from titles where pub_id=1389;

select notes as books from titles where price between 10 and 15

select notes as books from titles where  price is NULL ;

select * from titles where notes  like 'The%';

select notes as books from titles where notes NOT like '%V%'

select notes from titles 
order by royalty ASC

select notes as books from titles 
order by pub_id DESC, type ASC,price DESC;

select type, avg(price) as avg_price
from titles
group by type

select title,price from titles 
order by price DESC
LIMIT 2;

select DISTINCT type from titles


select notes as books from titles
where type='business' and price <20 and advance >7000;

select count(*)notes from titles

select pub_id, count(*)as notes_count from titles 
where  price between 15 and 25 
and title like '%it%'
group by pub_id 
having count(*)>2
order by notes_count ASC;


select au_lname as Authors_name from authors
where state='CA'


select state, count(*) as author_name
from authors 
group by state

sp_help sales
1. select stor_id 'store id',count(*) 'Number of orders' from sales group by stor_id


2.select title_id, count(*) as No_of_Orders from sales group by title_id

3.select p.pub_name as 'Publisher Name',t.title as 'Book Name' from publishers p inner join titles t on p.pub_id=t.pub_id

4. select concat(au_fname, ' ', au_lname) as 'Authors Full Name' from authors

5. select title,Price, (Price + (Price * 12.36/100)) as PriceWithTax from titles


6.select concat(A.au_fname, ' ', A.au_lname) as AuthorName, T.title as Title from Authors A, Titles T


7.select concat(a.au_fname, ' ', a.au_lname) as AuthorName, t.title,p.pub_name
FROM titleauthor ta
JOIN authors a ON ta.au_id = a.au_id
JOIN titles t ON ta.title_id = t.title_id
JOIN publishers p ON p.pub_id=t.pub_id


8. select p.pub_name as 'Publisher Name',avg(t.price) as 'Average Price' from publishers p 
inner join titles t  on p.pub_id=t.pub_id group by p.pub_name   


9.select a.au_fname+' '+au_lname as Author, t.title
FROM authors a
JOIN titleauthor ta ON a.au_id = ta.au_id
JOIN titles t ON ta.title_id = t.title_id
WHERE a.au_fname ='Marjorie';, t.title
FROM authors a
JOIN titleauthor ta ON a.au_id = ta.au_id
JOIN titles t ON ta.title_id = t.title_id
WHERE a.au_fname ='Marjorie';


 10.SELECT a.pub_name, t.title,ta.ord_num
FROM publishers a
JOIN titles t ON a.pub_id = t.pub_id
JOIN sales ta ON t.title_id = ta.title_id
where pub_name='New Moon Books'


11.select P.pub_name as PublisherName, count(S.ord_num) as NumberOfOrders
from Publishers P
left join Titles T on P.pub_id = T.pub_id
left join Sales S on T.title_id = S.title_id
group by P.pub_name
order by PublisherName;


12.select s.ord_num as OrderNumber, t.title as BookName, s.qty as Quantity, t.price as Price,
(s.qty * t.price) as TotalPrice
from Sales s
inner join Titles t on s.title_id = t.title_id;



13.select T.title as BookName, sum(S.qty) as TotalQuantity
from Titles T
left join Sales S on T.title_id = S.title_id
group by T.title
order by TotalQuantity desc


14.select t.title as BookName, sum(s.qty * t.price) as TotalOrderValue
from Titles t
left join Sales s on t.title_id = s.title_id
group by t.title
order by totalOrderValue desc


15.SELECT s.ord_num
FROM titles AS t
JOIN sales AS s ON t.title_id = s.title_id
JOIN publishers AS p ON t.pub_id = p.pub_id
JOIN employee AS e ON p.pub_id = e.pub_id
WHERE e.fname = 'Paolo';