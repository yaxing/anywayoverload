use shanzhai
create view v_orderDetailManage
as
select orderDetail.*,
		bookInfo.ISBN,
		bookInfo.bookName,
		bookInfo.publisher
from orderDetail inner join bookInfo on bookInfo.ID=orderDetail.bookID
go
select * from v_orderDetailManage

