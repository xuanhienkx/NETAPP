

-------------------------------------------------------------
-- Hopnq
-- Check mua ban cung ngay
-- neu co mua ban cung ngay thi tra ra 1, nguoc lai tra ra 0
-- Vinhnt: sua theo thong tu 74 cho phep mua ban cung chung khoan
-------------------------------------------------------------

ALTER FUNCTION [dbo].[fc_CheckBuySellInSame]
    (
	  @OrderDateVarchar varchar(10),
      @CustomerID VARCHAR(10),
      @StockCode VARCHAR(10),
	  @OrderSideInSame Char(1) -- loai lenh can check
    )
RETURNS int
WITH ENCRYPTION
AS BEGIN
	
	IF EXISTS (SELECT * FROM	[StockOrder] LEFT JOIN [TradingOrder] ON [StockOrder].[OrderNo] = [TradingOrder].[OrderNo]
						WHERE 	[StockOrder].[OrderDate] = @OrderDateVarchar
								AND [StockOrder].[CustomerID] = @CustomerID
								AND [StockOrder].[StockCode] = @StockCode
								AND [StockOrder].[OrderSide] <> @OrderSideInSame
								AND ISNULL(dbo.TradingOrder.OrderStatus, [StockOrder].OrderStatus) NOT IN ('M', 'X', 'C', 'D', 'R', 'F')
								)
	BEGIN
		RETURN 1
	End
	
	RETURN 0
	
	END
GO

-- VanVo update on 20071123: add DealType
-- =============================================
-- Author:		TruongTN
-- Update date: 200701030
-- Description:	Chèn l?nh vào h? th?ng và l?y ra s? th? t? l?nh, th?i gian l?nh nh?p vào h? th?ng
-- 20080201 TriDM TradeCode 30
-- 20080408 TriDM: bo sung lenh huy tu dai ly (trang thai R) vao kiem tra
-- 20080702 TuanLn: Them tham so kiem tra co check mua ban cung ma ck hay khong
-- 20080911 TriDM: chan mua va ban doi voi lenh C nhung khop 1 phan (theo yeu cau cua TAS)
-- 20081106 Haids: update GetOrderFee cách tính phí môi giái m?i
-- 20081222 TriDM: chuyen OrderInsert_GetStockInfor thanh GetCustomerStockDetails
-- 20090119 TriDM: bo sung @OrderStatus
-- 20090407 LUANTX : bo sung kiem tra lenh PT san HOSE va kiem tra lenh ATO san HASE
-- 20100722 DUONGPT: Bo sung kiem tra lenh PT san UPCOM
-- 20100817 DUONGPT: HOSE chua ho tro lenh MP
-- 20110725 DUONGPT: Cho phep cung mua cung ban              
-- =============================================

ALTER	PROCEDURE [dbo].[Order_Insert] 
	@OrderDate 		smalldatetime,
	@OrderSide 		char(1),
	@OrderType 		varchar(5),
	@StockCode 		varchar(10),
	@OrderVolume 	int,
	@OrderPrice 	decimal(18,3),
	@CustomerID 	varchar(10),
	@BranchCode 	varchar(3),
	@TradeCode 		varchar(30),
	@ReceivedBy		varchar(30),
	@AlertCode 		char(1) = 'N',
	@Notes 			varchar(100) = '',
	@OrderTime 		varchar(12) OUT,
	@OrderSeq 		int OUT,
	@Session		int=null,
	@RefNo			int=-999,
	@isAgentOder	bit = 0,
	@OrderStatus	varchar(1) = 'P'
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @OrderDateVarchar	varchar(10);
	SET @OrderDateVarchar = Convert(varchar(10), @OrderDate, 103);
	
	DECLARE @TransDate varchar(10);	
	SET @TransDate = dbo.fc_CurrentTransDateStr(@BranchCode);

	IF @OrderDateVarchar <> @TransDate
	BEGIN
		RAISERROR (N'Ngày đặt lệnh không hợp lệ. Ngày giao dịch hiện tại trên hệ thống là %s', 15, 1, @OrderDateVarchar)
		RETURN
	END
	
	DECLARE @CeilingPrice decimal(18,1), @FloorPrice decimal(18,1);
	DECLARE @BoardType char(1), @BoardName varchar(30), @BoardLot int;	
	EXEC OrderInsert_GetPrice	@StockCode, @OrderDateVarchar
								,@CeilingPrice OUTPUT
								,@FloorPrice OUTPUT
								,@BoardType OUTPUT
								,@BoardName OUTPUT
								,@BoardLot OUTPUT

	IF @@ERROR <> 0 RETURN;
	
	--
	-- Xác d?nh xem h? th?ng có dang ? tr?ng thái nh?n l?nh hay không
	--
	DECLARE @SysAvailable char(1);
	SET @SysAvailable = (SELECT [Status] FROM [OrderSysStat] WHERE [OrderDate] = @OrderDateVarchar AND [BoardType] = @BoardType);

	IF @SysAvailable IS NULL
		BEGIN
			RAISERROR (N'Hệ thống chưa nhận lệnh giao dịch tại %s ngày %s', 15, 1, @BoardName, @OrderDateVarchar)
			RETURN	
		END
	ELSE
		BEGIN		
			IF @SysAvailable <> 'O'
			BEGIN
				RAISERROR (N'Hệ thống đã ngừng nhận lệnh giao dịch tại %s ngày %s', 15, 1, @BoardName, @OrderDateVarchar)
				RETURN
			END
		END	
		
		        -- DUONGPT chua ho tro lenh MP tren SBS
        IF @ordertype='MP' and @boardtype = 'M'
            BEGIN
				RAISERROR (N'Không được đặt lệnh MP sàn HOSE trên SBS, hệ thống chưa hỗ trợ', 15, 1)
				RETURN
			END
                
                -- LUANTX chinh khong cho nhap PT tren SBS
        IF @ordertype='PT' and @receivedby <> 'pt' and @boardtype = 'M'
                	BEGIN
				RAISERROR (N'Không được đặt lệnh PT sàn HOSE trên SBS, đặt trên PT dealer', 15, 1)
				RETURN
			END
                
                --         LUANTX chinh khong cho nhap ATC, ATO tren san HASTC, tranh nhap tu GDTT
                 IF @ordertype IN ('ATO','ATC','MP') and @boardtype IN ('S','O')
                	BEGIN
				RAISERROR (N'Không được đặt lệnh ATO,ATC,MP trên sàn HNX hoặc UPCOM ', 15, 1)
				RETURN
			END	
		--- DUONGPT: Không cho nh?p l?nh UPCOM trên SBS	
		--  IF @ordertype='PT' and @receivedby <> '%fromAgency' and @boardtype = 'O'
		/*
		IF @ordertype='PT' and @boardtype = 'O'
                	BEGIN
				RAISERROR (N'Không du?c d?t l?nh PT sàn UPCOM trên SBS, d?t trên VICS Agency', 15, 1)
				RETURN
			END
                */

---LUANTX chinh khong cho dat sai buoc gia tu gateway

DECLARE @StepValue int;
exec StepPrice_GetStepValue @BoardType,@OrderPrice
, @stepvalue OUTPUT
IF @@ERROR <> 0 RETURN;
if (@OrderPrice*1000)%@StepValue <> 0 
			BEGIN
				RAISERROR (N'Giá đặt không hợp lệ, Bước giá phải là: %d đồng', 15, 1, @StepValue)
				RETURN
			END


	
	-- 20080330 TriDM: n?u là trái phi?u thì ko check giá tr?n sàn
	if not exists (select 1 from GLStockCode where StockCode=@StockCode and StockType='D')
	Begin
		--
		-- Ki?m tra giá d?t có h?p l? hay không
		--
		IF @OrderPrice < @FloorPrice
			BEGIN
				RAISERROR (N'Giá đặt không hợp lệ: Giá đặt nhỏ hơn giá sàn.', 15, 1)
				RETURN
			END

		IF @OrderPrice > @CeilingPrice
			BEGIN
				RAISERROR (N'Giá đặt không hợp lệ: Giá đặt lớn hơn giá trần', 15, 1)
				RETURN
			END
		
	end

	--
	-- Ki?m tra kh?i lu?ng d?t
	--
	IF @OrderVolume < @BoardLot
		BEGIN
			RAISERROR (N'Khối lượng đặt không hợp lệ: Khối lượng tối thiểu phải là %d', 15, 1, @BoardLot)
			RETURN
		END
	---- KIEM TRA XEM  SO LUONG MUA CO TRON LO HAY KHONG  @OrderVolume CO CHIA HET CHO @BoardLot HAY KHONG --
	IF(@OrderType<>'PT')
	BEGIN
		if @OrderVolume%@BoardLot <> 0 
			BEGIN
				RAISERROR (N'Khối lượng đặt không hợp lệ: Khối lượng phải tròn lô là: %d', 15, 1, @BoardLot)
				RETURN
			END
	END
	
	--
	-- Ki?m tra s? du
	--
	DECLARE @BeginStock bigint, @MortageStock bigint, @SoldStock bigint, @PendingStock bigint, @SoldStockNoPost bigint;
	
	EXEC GetCustomerStockDetails	@CustomerID, @StockCode, @OrderDate,							
									@BeginStock OUTPUT,
									@PendingStock output,
									@MortageStock OUTPUT,
									@SoldStock OUTPUT,
									@SoldStockNoPost OUTPUT;

	IF @@ERROR <> 0 RETURN;

	DECLARE @Count int, @StockCredit int;

	IF @OrderSide <> 'S' AND @OrderSide <> 'B'
	BEGIN
		RAISERROR (N'Lệnh đặt không hợp lệ: OrderSide = %s', 15, 1, @OrderSide)
		RETURN
	END

	-- 20080324 TriDM: bo sung check PostType
	declare @PostType int
	set @PostType = (Select PostType From Customers where CustomerId=@CustomerId )
	
	-- 20080702: Ki?m tra có còn check mua bán cùng mã ck
	--declare @SuspendSameStock bit, @SuspendSameBond bit
	--if not exists (select 1 from GLStockCode where StockCode=@StockCode and StockType='D')
	--Begin
	--	Set @SuspendSameStock = isnull((Select [IntValue] From Settings Where [ParaName]='SuspendSameStock'),'1')
	--End
	--Else
	--Begin
	--	Set @SuspendSameBond = isnull((Select [IntValue] From Settings Where [ParaName]='SuspendSameBond'),'1')
	--End
	
	-- Nếu là lệnh BÁN
	IF @OrderSide = 'S'
	BEGIN

		Set @Count = dbo.fc_CheckBuySellInSame(@OrderDateVarchar,@CustomerID,@StockCode,@OrderSide)
		--Edit by DUONGPT
		--IF (@Count > 0 AND (@SuspendSameStock=1 OR @SuspendSameBond=1))
		IF (@Count > 0 )
		BEGIN
			RAISERROR (N'Lệnh BÁN không thực hiện được do đang tồn tại lệnh MUA chưa khớp hoặc mới chỉ khớp được một phần', 15, 1)
			RETURN
		END

		SET @StockCredit = @BeginStock - @SoldStock - @OrderVolume;
		IF @StockCredit < 0
		BEGIN
			-- THem DK check PostType
			IF ( ((@StockCredit + @MortageStock) < 0) and (@PostType<>-1) )
			BEGIN
				RAISERROR (N'Không đủ số dư chứng khoán %s', 15, 1, @StockCode)
				RETURN
			END

			-- Thiếu CK, còn phải làm thủ tục giải tỏa CK cầm cố
			SET @AlertCode = 'S';
		END
	END

	-- Nếu là lệnh MUA
	IF @OrderSide = 'B'
	BEGIN
		Set @Count = dbo.fc_CheckBuySellInSame(@OrderDateVarchar,@CustomerID,@StockCode,@OrderSide)
		--Edit by DUONGPT
		--IF (@Count > 0 AND (@SuspendSameStock=1 OR @SuspendSameBond=1))
		IF (@Count > 0)
		BEGIN
			RAISERROR ('Lệnh MUA không thực hiện được do đang tồn tại lệnh BÁN chưa khớp hoặc mới chỉ khớp được một phần', 15, 1)
			RETURN
		END
		
		-- neu Check DK tien thi 
		if (@PostType=0 or @PostType=1)
		Begin
		
			DECLARE @CurrentLimitValue decimal(18, 0);
			SET @CurrentLimitValue = dbo.fc_CustomerDebitLimit_CurrentLimitValue(@CustomerID);	
			IF @CurrentLimitValue > 0
			BEGIN
				-- Thiếu tiền, cần làm thủ tục nộp tiền
				SET @AlertCode = 'C';
			END
		End
		
	END

	INSERT INTO [OrderSequence] ([OrderDate]) VALUES (@OrderDateVarchar);

	IF @@ERROR <> 0
	BEGIN
		RAISERROR (N'Không xác định được số hiệu lệnh', 15, 1)
		RETURN
	END

	SET @OrderSeq = @@IDENTITY
	SET @OrderTime = CONVERT(varchar(12), GETDATE(), 114)

	DECLARE @OrderValue decimal(28,0), @FeeValue decimal;

	SET @OrderValue = @OrderVolume * @OrderPrice * 1000
	SET @FeeValue = [dbo].[fc_GetOrderFee](@CustomerID, @OrderValue, @StockCode)

	DECLARE @CustomerBranchCode varchar(3), @CustomerTradeCode varchar(30)
	SELECT @CustomerBranchCode = [BranchCode], @CustomerTradeCode = [TradeCode] 
	FROM Customers
	WHERE CustomerID = @CustomerID  
	if (@OrderStatus ='P' or @OrderStatus is null or @OrderStatus='')
	begin
		INSERT INTO [StockOrder]
				([OrderDate], [OrderTime], [OrderSeq], [OrderNo], [OrderType], [OrderSide]
				,[BoardType], [StockCode], [OrderVolume], [OrderPrice], [OrderValue], [OrderFee]
           		,[CustomerID], [BranchCode], [TradeCode]
           		, [CustomerBranchCode], [CustomerTradeCode]
           		, [ReceivedBy], [ApprovedBy], [OrderStatus]
           		,[AlertCode], [Notes],[Session],[TransactionDate],[refNo])
				VALUES
           		(@OrderDateVarchar, @OrderTime, @OrderSeq, NULL, @OrderType, @OrderSide,
           		@BoardType, @StockCode, @OrderVolume, @OrderPrice, @OrderValue, @FeeValue,
				@CustomerID, @CustomerBranchCode, @CustomerTradeCode
				, @CustomerBranchCode, @CustomerTradeCode
				, @ReceivedBy, NULL, 'P', @AlertCode, @Notes,@Session,@OrderDate,@refNo);
	end
	else
	begin
			INSERT INTO [StockOrder]
				([OrderDate], [OrderTime], [OrderSeq], [OrderNo], [OrderType], [OrderSide]
				,[BoardType], [StockCode], [OrderVolume], [OrderPrice], [OrderValue], [OrderFee]
           		,[CustomerID], [BranchCode], [TradeCode]
           		, [CustomerBranchCode], [CustomerTradeCode]
           		, [ReceivedBy], [ApprovedBy], [OrderStatus]
           		,[AlertCode], [Notes],[Session],[TransactionDate],[refNo])
				VALUES
           		(@OrderDateVarchar, @OrderTime, @OrderSeq, NULL, @OrderType, @OrderSide,
           		@BoardType, @StockCode, @OrderVolume, @OrderPrice, @OrderValue, @FeeValue,
				@CustomerID, @CustomerBranchCode, @CustomerTradeCode
				, @CustomerBranchCode, @CustomerTradeCode
				, @ReceivedBy, NULL, @OrderStatus, @AlertCode, @Notes,@Session,@OrderDate,@refNo);
	end
END
GO

-- VanVo update on 20071123: add DealType
-- =============================================
-- Author:		TruongTN
-- Vinh added: Ham nay dung de su dung trong truong hop tradeplus va vics agency dat lenh thoa thuan
-- Update date: 200701030
-- Description:	Chèn lệnh vào hệ thống và lấy ra sẽ thứ tự lệnh, thời gian lệnh nhập vào hệ thống
-- 20080201 TriDM TradeCode 30
-- 20080408 TriDM: bo sung lenh huy tu dai ly (trang thai R) vao kiem tra
-- 20080702 TuanLn: Them tham so kiem tra co check mua ban cung ma ck hay khong
-- 20080911 TriDM: chan mua va ban doi voi lenh C nhung khop 1 phan (theo yeu cau cua TAS)
-- 20081106 Haids: update GetOrderFee cách tính phí môi giái mới
-- 20081222 TriDM: chuyen OrderInsert_GetStockInfor thanh GetCustomerStockDetails
-- 20090119 TriDM: bo sung @OrderStatus
-- 20090407 LUANTX : bo sung kiem tra lenh PT san HOSE va kiem tra lenh ATO san HASE
-- 20100722 DUONGPT: Danh rieng cho dat lenh qua Agency-UPCOM
-- =============================================

ALTER PROCEDURE [dbo].[Order_Insert_Agency] 
	@OrderDate 		smalldatetime,
	@OrderSide 		char(1),
	@OrderType 		varchar(5),
	@StockCode 		varchar(10),
	@OrderVolume 	int,
	@OrderPrice 	decimal(18,3),
	@CustomerID 	varchar(10),
	@BranchCode 	varchar(3),
	@TradeCode 		varchar(30),
	@ReceivedBy		varchar(30),
	@AlertCode 		char(1) = 'N',
	@Notes 			varchar(100) = '',
	@OrderTime 		varchar(12) OUT,
	@OrderSeq 		int OUT,
	@Session		int=null,
	@RefNo			int=-999,
	@isAgentOder	bit = 0,
	@OrderStatus	varchar(1) = 'P'
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @OrderDateVarchar	varchar(10);
	SET @OrderDateVarchar = Convert(varchar(10), @OrderDate, 103);
	
	DECLARE @TransDate varchar(10);	
	SET @TransDate = dbo.fc_CurrentTransDateStr(@BranchCode);

	IF @OrderDateVarchar <> @TransDate
	BEGIN
		RAISERROR (N'Ngày đặt lệnh không hợp lệ. Ngày giao dịch hiện tại trên hệ thống là %s', 15, 1, @OrderDateVarchar)
		RETURN
	END
	
	DECLARE @CeilingPrice decimal(18,1), @FloorPrice decimal(18,1);
	DECLARE @BoardType char(1), @BoardName varchar(30), @BoardLot int;	
	EXEC OrderInsert_GetPrice	@StockCode, @OrderDateVarchar
								,@CeilingPrice OUTPUT
								,@FloorPrice OUTPUT
								,@BoardType OUTPUT
								,@BoardName OUTPUT
								,@BoardLot OUTPUT

	IF @@ERROR <> 0 RETURN;
	
	--
	-- Xác định xem hệ thống có đang ở trạng thái nhận lệnh hay không
	--
	DECLARE @SysAvailable char(1);
	SET @SysAvailable = (SELECT [Status] FROM [OrderSysStat] WHERE [OrderDate] = @OrderDateVarchar AND [BoardType] = @BoardType);

	IF @SysAvailable IS NULL
		BEGIN
			RAISERROR (N'Hệ thống chưa nhận lệnh giao dịch tại %s ngày %s', 15, 1, @BoardName, @OrderDateVarchar)
			RETURN	
		END
	ELSE
		BEGIN		
			IF @SysAvailable <> 'O'
			BEGIN
				RAISERROR (N'Hệ thống đã ngưng nhận lệnh giao dịch tại %s ngày %s', 15, 1, @BoardName, @OrderDateVarchar)
				RETURN
			END
		END	
                
                -- LUANTX chinh khong cho nhap PT tren SBS
        IF @ordertype='PT' and @receivedby <> 'pt' and @boardtype = 'M'
                	BEGIN
				RAISERROR (N'Không được đặt lệnh PT sàn HOSE trên SBS, đặt trên PT dealer', 15, 1)
				RETURN
			END
                
                --         LUANTX chinh khong cho nhap ATC, ATO tren san HASTC, tranh nhap tu GDTT
                 IF @ordertype in ('ATO','ATC') and @boardtype = 'S'
                	BEGIN
				RAISERROR (N'Không được đặt lệnh ATO,ATC trên sàn HASE ', 15, 1)
				RETURN
			END			
                

---LUANTX chinh khong cho dat sai buoc gia tu gateway

DECLARE @StepValue int;
exec StepPrice_GetStepValue @BoardType,@OrderPrice
, @stepvalue OUTPUT
IF @@ERROR <> 0 RETURN;
if (@OrderPrice*1000)%@StepValue <> 0 
			BEGIN
				RAISERROR (N'Giá đặt không hợp lệ, Bước giá phải là: %d đồng', 15, 1, @StepValue)
				RETURN
			END

	-- 20080330 TriDM: nếu là trái phiếu thì ko check giá trần sàn
	if not exists (select 1 from GLStockCode where StockCode=@StockCode and StockType='D')
	Begin
		--
		-- Kiểm tra giá đặt có hợp lệ hay không
		--
		IF @OrderPrice < @FloorPrice
			BEGIN
				RAISERROR (N'Giá đặt không hợp lệ: Giá đặt nhỏ hơn giá sàn.', 15, 1)
				RETURN
			END

		IF @OrderPrice > @CeilingPrice
			BEGIN
				RAISERROR (N'Giá đặt không hợp lệ: Giá đặt lớn hon giá trần', 15, 1)
				RETURN
			END
		
	end

	--
	-- Kiểm tra khối lượng đặt
	--
	IF @OrderVolume < @BoardLot
		BEGIN
			RAISERROR (N'Khối lượng đặt không hợp lý: Khối lượng tối thiểu phải là %d', 15, 1, @BoardLot)
			RETURN
		END
	---- KIEM TRA XEM  SO LUONG MUA CO TRON LO HAY KHONG  @OrderVolume CO CHIA HET CHO @BoardLot HAY KHONG --
	IF(@OrderType<>'PT')
	BEGIN
		if @OrderVolume%@BoardLot <> 0 
			BEGIN
				RAISERROR (N'Khối lượng đặt không hợp lệ: Khối lượng phải tròn lô là: %d', 15, 1, @BoardLot)
				RETURN
			END
	END
	
	--
	-- Kiểm tra số du
	--
	DECLARE @BeginStock bigint, @MortageStock bigint, @SoldStock bigint, @PendingStock bigint, @SoldStockNoPost bigint;
	
	EXEC GetCustomerStockDetails	@CustomerID, @StockCode, @OrderDate,							
									@BeginStock OUTPUT,
									@PendingStock output,
									@MortageStock OUTPUT,
									@SoldStock OUTPUT,
									@SoldStockNoPost OUTPUT;

	IF @@ERROR <> 0 RETURN;

	DECLARE @Count int, @StockCredit int;

	IF @OrderSide <> 'S' AND @OrderSide <> 'B'
	BEGIN
		RAISERROR (N'Lệnh đặt không hợp lệ: OrderSide = %s', 15, 1, @OrderSide)
		RETURN
	END

	-- 20080324 TriDM: bo sung check PostType
	declare @PostType int
	set @PostType = (Select PostType From Customers where CustomerId=@CustomerId )
	
	-- 20080702: Kiểm tra có còn check mua bán cùng mã ck
	--declare @SuspendSameStock bit, @SuspendSameBond bit
	--if not exists (select 1 from GLStockCode where StockCode=@StockCode and StockType='D')
	--Begin
	--	Set @SuspendSameStock = isnull((Select [IntValue] From Settings Where [ParaName]='SuspendSameStock'),'1')
	--End
	--Else
	--Begin
	--	Set @SuspendSameBond = isnull((Select [IntValue] From Settings Where [ParaName]='SuspendSameBond'),'1')
	--End
	
	-- Nếu là lệnh BÁN
	IF @OrderSide = 'S'
	BEGIN

		Set @Count = dbo.fc_CheckBuySellInSame(@OrderDateVarchar,@CustomerID,@StockCode,@OrderSide)
		--Edit by DUONGPT
		IF (@Count > 0)
		BEGIN
			RAISERROR (N'Lệnh BÁN không thực hiện được do đang tồn tại lệnh MUA chưa khớp hoặc mới chỉ khớp được một phần', 15, 1)
			RETURN
		END

		SET @StockCredit = @BeginStock - @SoldStock - @OrderVolume;
		IF @StockCredit < 0
		BEGIN
			-- THem DK check PostType
			IF ( ((@StockCredit + @MortageStock) < 0) and (@PostType<>-1) )
			BEGIN
				RAISERROR (N'Không đủ số dư chứng khoán %s', 15, 1, @StockCode)
				RETURN
			END

			-- Thiếu CK, còn phải làm thủ tục giải tỏa CK cầm cố
			SET @AlertCode = 'S';
		END
	END

	-- Nếu là lệnh MUA
	IF @OrderSide = 'B'
	BEGIN
		Set @Count = dbo.fc_CheckBuySellInSame(@OrderDateVarchar,@CustomerID,@StockCode,@OrderSide)
		--Edit by DUONGPT
		IF (@Count > 0)
		BEGIN
			RAISERROR (N'Lệnh MUA không thực hiện được do đang tồn tại lệnh BÁN chưa khớp hoặc mới chỉ khớp được một phần', 15, 1)
			RETURN
		END
		
		-- neu Check DK tien thi 
		if (@PostType=0 or @PostType=1)
		Begin
		
			DECLARE @CurrentLimitValue decimal(18, 0);
			SET @CurrentLimitValue = dbo.fc_CustomerDebitLimit_CurrentLimitValue(@CustomerID);	
			IF @CurrentLimitValue > 0
			BEGIN
				-- Thiếu tiền, cần làm thủ tục nộp tiền
				SET @AlertCode = 'C';
			END
		End
		
	END

	INSERT INTO [OrderSequence] ([OrderDate]) VALUES (@OrderDateVarchar);

	IF @@ERROR <> 0
	BEGIN
		RAISERROR (N'Không xác định được số hiệu lệnh', 15, 1)
		RETURN
	END

	SET @OrderSeq = @@IDENTITY
	SET @OrderTime = CONVERT(varchar(12), GETDATE(), 114)

	DECLARE @OrderValue decimal(28,0), @FeeValue decimal;

	SET @OrderValue = @OrderVolume * @OrderPrice * 1000
	SET @FeeValue = [dbo].[fc_GetOrderFee](@CustomerID, @OrderValue, @StockCode)

	DECLARE @CustomerBranchCode varchar(3), @CustomerTradeCode varchar(30)
	SELECT @CustomerBranchCode = [BranchCode], @CustomerTradeCode = [TradeCode] 
	FROM Customers
	WHERE CustomerID = @CustomerID  
	if (@OrderStatus ='P' or @OrderStatus is null or @OrderStatus='')
	begin
		INSERT INTO [StockOrder]
				([OrderDate], [OrderTime], [OrderSeq], [OrderNo], [OrderType], [OrderSide]
				,[BoardType], [StockCode], [OrderVolume], [OrderPrice], [OrderValue], [OrderFee]
           		,[CustomerID], [BranchCode], [TradeCode]
           		, [CustomerBranchCode], [CustomerTradeCode]
           		, [ReceivedBy], [ApprovedBy], [OrderStatus]
           		,[AlertCode], [Notes],[Session],[TransactionDate],[refNo])
				VALUES
           		(@OrderDateVarchar, @OrderTime, @OrderSeq, NULL, @OrderType, @OrderSide,
           		@BoardType, @StockCode, @OrderVolume, @OrderPrice, @OrderValue, @FeeValue,
				@CustomerID, @CustomerBranchCode, @CustomerTradeCode
				, @CustomerBranchCode, @CustomerTradeCode
				, @ReceivedBy, NULL, 'P', @AlertCode, @Notes,@Session,@OrderDate,@refNo);
	end
	else
	begin
			INSERT INTO [StockOrder]
				([OrderDate], [OrderTime], [OrderSeq], [OrderNo], [OrderType], [OrderSide]
				,[BoardType], [StockCode], [OrderVolume], [OrderPrice], [OrderValue], [OrderFee]
           		,[CustomerID], [BranchCode], [TradeCode]
           		, [CustomerBranchCode], [CustomerTradeCode]
           		, [ReceivedBy], [ApprovedBy], [OrderStatus]
           		,[AlertCode], [Notes],[Session],[TransactionDate],[refNo])
				VALUES
           		(@OrderDateVarchar, @OrderTime, @OrderSeq, NULL, @OrderType, @OrderSide,
           		@BoardType, @StockCode, @OrderVolume, @OrderPrice, @OrderValue, @FeeValue,
				@CustomerID, @CustomerBranchCode, @CustomerTradeCode
				, @CustomerBranchCode, @CustomerTradeCode
				, @ReceivedBy, NULL, @OrderStatus, @AlertCode, @Notes,@Session,@OrderDate,@refNo);
	end
END
GO

--DUONGPT:Cho phep cung mua cung ban
--Dung cho TradePlus
ALTER PROCEDURE CheckStockOrder
	@CustomerID	varchar(20),
	@StockCode varchar(10),
	@OrderSide char(1)

as
begin
	declare @result int
	set @result =0 
	if exists 
		(
		  select 1 from  
			StockOrder a left join TradingOrder b on a.OrderSeq = b.OrderSeq
			where 
				a.CustomerID = @CustomerID and 
				a.StockCode = @StockCode and
				a.OrderSide = @OrderSide and 
				(
					not (
							a.OrderStatus = 'X' 
							or a.OrderStatus = 'D' 
							or b.OrderStatus = 'M' 
							or ( (b.OrderStatus is not null) and b.OrderStatus = 'C' and b.MatchedVolume = 0 )
						)
				)
		)  
		set @result = 1
		select @result
end
GO