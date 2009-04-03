use shanzhai
go
create view v_orderManage_done
as
select orders_done.*,users.userName from orders_done
inner join users on orders_done.userID=users.ID
go
select * from v_orderManage_done
select * from orders_done