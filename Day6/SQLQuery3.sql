
1) print the store name, title name,, quantity, sale amount, pulisher name, author name for all the sales. Also print those books which have not been sold and authors who have not written.
use pubs
sp_help titles
select * from sales
select * from publishers
select * from titles
select *from authors
select *from stores
select *from titleauthor

1.select stor_name,title as title_name,qty as Quantity,pub_name as Publisher_name,au_fname as Author,(select sum(s.qty) * sum(t.price) from sales s join titles t 
						on s.title_id=t.title_id where s.ord_num in
						(select ord_num from sales group by ord_num)) as sale_amount FROM
    stores s 
    CROSS JOIN titles t
    LEFT JOIN sales sl ON s.stor_id = sl.stor_id AND t.title_id = sl.title_id
    LEFT JOIN publishers p ON t.pub_id = p.pub_id
	LEFT JOIN titleauthor ta ON ta.title_id = t.title_id
    LEFT JOIN Authors a ON ta.au_id = a.au_id 
    

4.SELECT a.au_fname, AVG(t.price) AS average_price
FROM authors a
JOIN titleauthor ta ON a.au_id = ta.au_id
JOIN titles t ON ta.title_id = t.title_id
GROUP BY a.au_fname;

2.alter PROC CalculateTotalsales_ByAuthor(@au_name VARCHAR(100),@total_sales float out)
as
BEGIN
    
    
    set @total_sales =(select sum(s.qty) * sum(t.price) from sales s join titles t 
						on s.title_id=t.title_id
						where t.title_id in
						(select title_id from titleauthor where au_id= 
						(select au_id from authors where au_fname = @au_name)))
    
    IF @total_sales IS NULL
        print 'Sale yet to gear up';
   
END
select * from authors

declare @amt float
begin
exec CalculateTotalsales_ByAuthor 'Cheryl',@amt out
print @amt
end

3.SELECT s1.*
FROM sales s1
WHERE s1.qty > ALL (SELECT s2.qty FROM Sales s2 WHERE s2.title_id = s1.title_id AND s2.stor_id = s1.stor_id);

5.sp_help titles

6.alter PROC CountBooks_pricedLess(@price float,@book_count int out)
as
BEGIN
    
    set @book_count = (SELECT COUNT(*)
    FROM titles
    WHERE price < @price);
    
END
declare @cnt float
begin
exec CountBooks_pricedLess 100,@cnt out
print @cnt
end

8.SELECT title
FROM titles
WHERE title LIKE '%e%' AND title LIKE '%a%';

7.CREATE TRIGGER PreventPriceUpdateBelow7
ON Titles
INSTEAD OF UPDATE
AS
BEGIN
    
    IF UPDATE(price)  
    BEGIN
        IF EXISTS (SELECT * FROM inserted WHERE price < 7)
        BEGIN
           
            print 'Price cannot be updated below 7.'
        END
        ELSE
        BEGIN
           
            UPDATE titles
            SET titles.price = inserted.price
            FROM titles
            INNER JOIN inserted ON titles.title_id = inserted.title_id;
        END
    END
END;
use dbShopping03Nov2023
sp_help Products
select * from Cart
insert into categories(name) values('ABC')
insert into categories(name) values('BBB')