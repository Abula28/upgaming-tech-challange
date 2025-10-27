CREATE TABLE Authors(
	id SERIAL primary key,
	name varchar(250)
);

CREATE TABLE Books (
 id SERIAL primary key,
title varchar(250),
authorId int,
publicationYear int,
foreign key (authorId) references Authors(id)
);

Insert into Authors (name) values('Robert C. Martin'),('Jeffrey Richter');


insert into Books (title, authorId, publicationYear) 
values('Clean Code', 1, 2008),
('CLR via C#', 2, 2012),
('The Clean Coder', 1, 2011 );

update Books set publicationYear = 2013 where id = 2;

delete from Books where id = 3;


select * from Authors;
select * from Books;

select
    b.title as "Book Title",
    a.name as "Author Name",
    b.publicationYear as "Published Year"
from
    Books b
join
    Authors a on b.authorId = a.id
where
    b.publicationYear > 2010;

