use shanzhai
go
CREATE PROCEDURE pro_deal_orders
	@counter int=0,
	@orderID int =-1,
	@orderID_new int=-1
AS
BEGIN
	/*已完成订单的数量*/
	select @counter=count(*)  from orders where pay!=1
	/*从表orders,orderDetail中逐个取出，放入orders_done,orderDetail_done中*/
	while(@counter>0)
	begin
		select top 1 @orderID=ID from orders where pay!=1
		/*转移orders中的一个记录*/
		insert into orders_done select userID,orderdatetime,amount,trueName,address,postcode,tel,email,dealMethod,pay from orders where ID=@orderID
		/*转移相应的orderDetail中的记录*/
		select @orderID_new=max(ID) from orders_done
		insert into orderDetail_done select @orderID_new,bookID,price,number,discount from orderDetail where orderID=@orderID
		delete orderDetail where orderID=@orderID
		delete orders where ID=@orderID
		/*@counter 减 1*/
		set @counter=@counter-1
	end
END
GO