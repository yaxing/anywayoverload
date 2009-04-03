use shanzhai
go
create view v_orderDetailManage_done
as
select orderDetail_done.*,
		bookInfo.ISBN,
		bookInfo.bookName,
		bookInfo.publisher
from orderDetail_done inner join bookInfo on bookInfo.ID=orderDetail_done.bookID
go
select * from v_orderDetailManage_done