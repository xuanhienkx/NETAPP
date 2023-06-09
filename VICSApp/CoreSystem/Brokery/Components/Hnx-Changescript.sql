-- =============================================
-- Author:		Vinh
-- Create date: 11.05.2010
-- Description:	Dang ky huy lenh
-- =============================================
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HNX_VicsAgency_CancelOrder]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[HNX_VicsAgency_CancelOrder]
GO
CREATE PROCEDURE HNX_VicsAgency_CancelOrder 
	@orderNumber NVARCHAR(50)
AS
BEGIN
	DECLARE @orderQuantity NUMERIC(18,0)
	DECLARE @clOrderId NVARCHAR(50)
	
	SELECT @orderQuantity = OrderQty, @clOrderId = ClOrdID FROM dbo.Msg_NewSingleOrder WHERE OrderID = @orderNumber
	IF @orderQuantity IS NULL
	BEGIN
		RAISERROR(N'Lệnh hủy không tồn tại',16,1)
		RETURN
	END
	
	IF EXISTS (SELECT * FROM dbo.Msg_OrderCancelRequest WHERE ClOrdID = @clOrderId)
	BEGIN
		RAISERROR(N'Không thể thực hiện vì đã có lệnh hủy',16,1)
		RETURN
	END
	
	IF @orderQuantity = (SELECT SUM(OrderQty) FROM dbo.Msg_ExecutionReport WHERE ExecType = '3' AND OrdStatus = '2' AND OrderID = @orderNumber)
	BEGIN
		RAISERROR(N'Không thể hủy được vì lệnh đã khớp hết',16,1)
		RETURN
	END
	-- ok, now insert
	INSERT INTO [dbo].[Msg_OrderCancelRequest] (SendingTime,TransactTime,MsgType,SenderCompID,ClOrdID,OrigClOrdID,Status)
    VALUES(GETDATE(),GETDATE(),'F','076', @clOrderId, @orderNumber, 'S')
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HNX_VicsAgency_ModifyOrder]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[HNX_VicsAgency_ModifyOrder]
GO
CREATE PROCEDURE [HNX_VicsAgency_ModifyOrder]
	@orderNumber NVARCHAR(50),
	@newPrice DECIMAL
AS
BEGIN
	DECLARE @clOrderId NVARCHAR(50)
	
	SELECT @clOrderId = ClOrdID FROM dbo.Msg_NewSingleOrder WHERE OrderID = @orderNumber
	IF @clOrderId IS NULL
	BEGIN
		RAISERROR(N'Lệnh sửa không tồn tại',16,1)
		RETURN
	END
	IF EXISTS (SELECT * FROM dbo.Msg_OrderCancelRequest WHERE ClOrdID = @clOrderId)
	BEGIN
		RAISERROR(N'Không thể thực hiện vì lệnh đã hủy',16,1)
		RETURN
	END
	
	INSERT INTO dbo.Msg_OrderReplaceRequest( MsgType ,SenderCompID ,SendingTime ,ClOrdID ,OrigClOrdID ,TransactTime ,Status, Price )
	VALUES ('G', '076', GETDATE(),@clOrderId, @orderNumber, GETDATE(), 'S', @newPrice)
END
	