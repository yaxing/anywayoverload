use shanzhai
create view v_orderManage
as
select orders.*,users.userName from orders
inner join users on orders.userID=users.ID
go
select * from v_orderManage
select * from orders