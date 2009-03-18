CREATE DATABASE shanzhai
GO

use shanzhai


CREATE TABLE users (
	ID int primary key IDENTITY (1, 1) NOT NULL ,
	username varchar (128) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	password varchar (128) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	TrueName varchar (128) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	address varchar (300) COLLATE Chinese_PRC_CI_AS NULL,
	postcode varchar (30) COLLATE Chinese_PRC_CI_AS NULL,
	tel varchar (30) COLLATE Chinese_PRC_CI_AS NULL ,
	email varchar (128) COLLATE Chinese_PRC_CI_AS NULL ,
	grade int DEFAULT 0,
	freeze int DEFAULT 0
)
GO

CREATE TABLE bookClass (
	ID int primary key IDENTITY (1, 1) NOT NULL,
	className varchar (128) NOT NULL,
	bookCount int DEFAULT 0
)
GO

CREATE TABLE bookInfo (
	ID int primary key IDENTITY (1, 1) NOT NULL ,
	ISBN varchar (15) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	classID int NULL,
	bookName varchar (128) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	publisher varchar (128) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	author varchar (128) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	introduce text COLLATE Chinese_PRC_CI_AS NULL ,
	price money NOT NULL ,
	pubdatetime datetime ,
	indatetime datetime NOT NULL ,
	coverPath varchar (128) COLLATE Chinese_PRC_CI_AS NULL ,--图片路径
	available int NULL ,
	sale int NULL ,--销量
	good int NULL ,--好评
	middle int NULL ,
	bad int NULL ,
	discount float DEFAULT 1 ,
	constraint fk_classID foreign key(classID) references bookClass(ID)
)
GO

CREATE TABLE comment (
	ID int primary key IDENTITY (1, 1) NOT NULL ,
	bookID int NOT NULL,
	userID int NOT NULL,
	comment text COLLATE Chinese_PRC_CI_AS NULL ,
	commdatetime datetime DEFAULT getdate() ,
	score int DEFAULT 0 ,
	constraint fk_bookInfo foreign key(bookID) references bookInfo(ID),
	constraint fk_users foreign key(userID) references users(ID),
)
GO

CREATE TABLE admin (
	ID int primary key IDENTITY (1, 1) NOT NULL ,
	userName varchar (128) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	passWord varchar (128) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	email varchar (128) NULL,
	level int DEFAULT 0
)
GO


CREATE TABLE orders (
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

CREATE TABLE orderDetail (
	ID int primary key IDENTITY (1, 1) NOT NULL ,
	orderID int NOT NULL ,
	bookID int NOT NULL ,
	price money NOT NULL ,
	number int DEFAULT 1 ,
	discount float DEFAULT 1,
	constraint fk_orders foreign key(orderID) references orders(ID),
	constraint fk_bookDetail foreign key(bookID) references bookInfo(ID),
)
GO

CREATE TABLE bbs (
	ID int primary key IDENTITY (1, 1) NOT NULL ,
	content text COLLATE Chinese_PRC_CI_AS NOT NULL ,
	postTime datetime DEFAULT getdate() ,
)
GO


CREATE TABLE poll (
	ID int primary key IDENTITY (1, 1) NOT NULL ,
	theme varchar (128) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	introduce text COLLATE Chinese_PRC_CI_AS NULL ,
	available int DEFAULT 0
)
GO

CREATE TABLE pollDetail (
	ID int primary key IDENTITY (1, 1) NOT NULL ,
	pollID int NOT NULL ,
	optionName varchar (128) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	counts int DEFAULT 0,
	constraint fk_poll foreign key(pollID) references poll(ID),
)
GO