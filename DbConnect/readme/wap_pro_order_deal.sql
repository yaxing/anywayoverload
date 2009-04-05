use shanzhai
go
CREATE PROCEDURE pro_deal_orders
	@counter int=0,
	@orderID int =-1,
	@orderID_new int=-1
AS
BEGIN
	/*����ɶ���������*/
	select @counter=count(*)  from orders where pay!=1
	/*�ӱ�orders,orderDetail�����ȡ��������orders_done,orderDetail_done��*/
	while(@counter>0)
	begin
		select top 1 @orderID=ID from orders where pay!=1
		/*ת��orders�е�һ����¼*/
		insert into orders_done select userID,orderdatetime,amount,trueName,address,postcode,tel,email,dealMethod,pay from orders where ID=@orderID
		/*ת����Ӧ��orderDetail�еļ�¼*/
		select @orderID_new=max(ID) from orders_done
		insert into orderDetail_done select @orderID_new,bookID,price,number,discount from orderDetail where orderID=@orderID
		delete orderDetail where orderID=@orderID
		delete orders where ID=@orderID
		/*@counter �� 1*/
		set @counter=@counter-1
	end
END
GO