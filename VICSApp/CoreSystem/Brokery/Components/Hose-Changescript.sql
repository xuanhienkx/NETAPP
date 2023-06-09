-- 12/04/2010, Vinh: them store de lay ra cac lenh co the huy
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HOGW_GetOrderListForCancel]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[HOGW_GetOrderListForCancel]
GO
-- Author : Hung SHS
-- Luantx: 15/03/2009 Chuyen sang su dung cho Charly cuc cu
-- Vinhnt: Chinh lai vi lenh liet ke sai va opitmize I/0 dung trong store. Va chuyen sang su dung cho hosewebservice
CREATE procedure [dbo].[HOGW_GetOrderListForCancel]
@customerid varchar(10),
@stockcode varchar(10),
@orderside char(1)
as
begin
DECLARE @HOGW_1I TABLE (TRADER_ID varchar(4),ORDER_NUMBER numeric(8, 0),CLIENT_ID varchar(10),
SECURITY_SYMBOL varchar(8),SIDE char(1),VOLUME numeric(8, 0),PRICE varchar(6),ORDER_SESSION varchar(5))

declare @TRADER_ID varchar(4)
declare @ORDER_NUMBER numeric(8, 0)
declare @CLIENT_ID varchar(10)
declare @SECURITY_SYMBOL varchar(8)
declare @SIDE char(1)
declare @VOLUME numeric(8, 0)
declare @PRICE varchar(6)
declare @ORDER_SESSION varchar(5)
declare @SUM_VOLUME numeric(8, 0)

set @SIDE = @orderside
declare @SYSTEM_CONTROL_CODE varchar(1);
set @SYSTEM_CONTROL_CODE= (SELECT top 1 [SYSTEM_CONTROL_CODE]  FROM [dbo].[HOSE_SC] order by ID desc)

-- SYSTEM_CONTROL_CODE='P': Phien 1
-- SYSTEM_CONTROL_CODE='O': Phien 2
-- SYSTEM_CONTROL_CODE='A': Phien 3

if @SYSTEM_CONTROL_CODE='O'
declare Order_Cursor CURSOR for	
	SELECT [TRADER_ID],[ORDER_NUMBER],[CLIENT_ID],[SECURITY_SYMBOL],[SIDE], [VOLUME],[PRICE],[ORDER_SESSION] 
		from HOGW_1I
		 where PRICE not in ('ATO')
		 and ORDER_NUMBER not in (Select ORDER_NUMBER from HOGW_1D)
		 and ORDER_NUMBER not in (Select ORDER_NUMBER from HOGW_1C)
		and ORDER_NUMBER not in (Select ORDER_NUMBER from HOGW_2D)
		and ORDER_NUMBER not in (Select ORDER_NUMBER from HOGW_2C)
		and (@orderside = '' or SIDE = @orderside)
		and (@stockcode = '' or Security_symbol = @stockcode)
		and (@customerid = '' or client_id like '%'+@customerid)

else if @SYSTEM_CONTROL_CODE='A'
declare Order_Cursor CURSOR for	
	SELECT [TRADER_ID],[ORDER_NUMBER],[CLIENT_ID],[SECURITY_SYMBOL],[SIDE], [VOLUME],[PRICE],[ORDER_SESSION] 
		from HOGW_1I
		 where PRICE not in ('ATC','ATO')
		 and ORDER_NUMBER not in (Select ORDER_NUMBER from HOGW_1D)
		 and ORDER_NUMBER not in (Select ORDER_NUMBER from HOGW_1C)
		and ORDER_NUMBER not in (Select ORDER_NUMBER from HOGW_2D)
		and ORDER_NUMBER not in (Select ORDER_NUMBER from HOGW_2C)
		and ORDER_SESSION <> 'A'
		and (@orderside = '' or SIDE = @orderside)
		and (@stockcode = '' or Security_symbol = @stockcode)
		and (@customerid = '' or client_id like '%'+@customerid)
else if @SYSTEM_CONTROL_CODE='P'
begin
	RAISERROR(N'Không lấy được danh sách lệnh có thể hủy, đang ở phiên xác định giá mở cửa',16,1)
	return
end
else 
begin
	RAISERROR(N'Không lấy được danh sách lệnh có thể hủy, thị trường đóng cửa',16,1)
	return
end


OPEN Order_Cursor

FETCH NEXT FROM Order_Cursor
INTO @TRADER_ID,@ORDER_NUMBER,@CLIENT_ID,@SECURITY_SYMBOL,@SIDE, @VOLUME,@PRICE,@ORDER_SESSION

WHILE @@FETCH_STATUS = 0
BEGIN
	-- search in 2E
	SELECT @SUM_VOLUME=sum(VOLUME) from HOGW_2E where ORDER_NUMBER=@ORDER_NUMBER
	if @SUM_VOLUME = @VOLUME goto NEXT
	else if @SUM_VOLUME is null set @SUM_VOLUME = 0
	
	-- search in 2I
	if @SIDE='B'
	begin
		SELECT @SUM_VOLUME=sum(VOLUME) + @SUM_VOLUME from HOGW_2I where BUYER_ORDER_NUMBER=@ORDER_NUMBER
		if @SUM_VOLUME<@VOLUME
			insert into @HOGW_1I values(@TRADER_ID,@ORDER_NUMBER,@CLIENT_ID,@SECURITY_SYMBOL,@SIDE, @VOLUME,@PRICE,@ORDER_SESSION)
	end
	else if @SIDE='S'
	begin
		SELECT @SUM_VOLUME=sum(VOLUME)+ @SUM_VOLUME from HOGW_2I where SELLER_ORDER_NUMBER=@ORDER_NUMBER
		if @SUM_VOLUME<@VOLUME
			insert into @HOGW_1I values(@TRADER_ID,@ORDER_NUMBER,@CLIENT_ID,@SECURITY_SYMBOL,@SIDE, @VOLUME,@PRICE,@ORDER_SESSION)
	end
	-- search in 2B
	if @SUM_VOLUME is null and exists (SELECT ORDER_NUMBER from HOGW_2B where ORDER_NUMBER=@ORDER_NUMBER)
		insert into @HOGW_1I values(@TRADER_ID,@ORDER_NUMBER,@CLIENT_ID,@SECURITY_SYMBOL,@SIDE, @VOLUME,@PRICE,@ORDER_SESSION)

NEXT:
FETCH NEXT FROM Order_Cursor 
INTO @TRADER_ID,@ORDER_NUMBER,@CLIENT_ID,@SECURITY_SYMBOL,@SIDE, @VOLUME,@PRICE,@ORDER_SESSION

END
CLOSE  Order_Cursor
DEALLOCATE Order_Cursor

select * from @HOGW_1I
end
