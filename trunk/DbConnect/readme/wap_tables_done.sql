use shanzhai
go
CREATE TABLE orders_done (
	ID int primary key IDENTITY (1, 1) NOT NULL ,
	userID int NOT NULL,
	orderdatetime datetime DEFAULT getdate() ,
	amount money DEFAULT 0,
	trueName varchar (128) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	address varchar (300) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	postcode varchar (30) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	tel varchar (30) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	email varchar (128) NOT NULL ,
	dealMethod varchar (128) NOT NULL , --运送方式
	pay int DEFAULT 0, --是否付款
) 
GO

CREATE TABLE orderDetail_done (
	ID int primary key IDENTITY (1, 1) NOT NULL ,
	orderID int NOT NULL ,
	bookID int NOT NULL ,
	price money NOT NULL ,
	number int DEFAULT 1 ,
	discount float DEFAULT 1,
	constraint fk_orders_done foreign key(orderID) references orders_done(ID),
	constraint fk_bookDetail_done foreign key(bookID) references bookInfo(ID),
)
GO