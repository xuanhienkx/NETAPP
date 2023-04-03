
--============================================
-- Description: Truy v?n Danh sách l?nh
-- 20080105 Haids: update OrderSide (Mua, Bán)
-- 20080201 TriDM: TradeCode 30
-- 20080703	TuanLN: Them van tin tu doanh
-- 20090920 Luantx : chuyen sang charly
--============================================
--------------------------
ALTER PROCEDURE [dbo].[Luantx_charly_Order_List_4cancelchange]
	@BranchCode varchar(3),
	@StockCode varchar(10),
	@CustomerID varchar(10),
	@OrderStatus char(1) = 'A',
	@BoardType char(1),
	@AgencyTradecode varchar(20) = '',
	@orderside char(1) = ''
	--WITH ENCRYPTION
AS
BEGIN

	
		SELECT 	
				[StockOrder].[OrderSeq]							[OrderSeq],
				Case [StockOrder].[OrderSide]
					When 'B' then N'Mua'
					When 'S' then N'Bán'
					Else 'N/A'
				End as											[OrderSideViet],
				[StockOrder].[BoardType]						[BoardType],
				[StockOrder].[StockCode]						[StockCode],
				[StockOrder].[OrderVolume]						[OrderVolume],
				[StockOrder].[OrderPrice]*1000						[OrderPrice],
				[StockOrder].[OrderValue]						[OrderValue],
				[StockOrder].[OrderFee]							[OrderFee],
				[StockOrder].[CustomerID]						[CustomerID],
				[StockOrder].[BranchCode]						[BranchCode],
				[StockOrder].[TradeCode]						[TradeCode],
				ISNULL([TradingOrder].[MatchedVolume], 0)		[MatchedVolume],
				case when [TradingOrder].[MatchedVolume] > 0 then ISNULL(([TradingOrder].[MatchedValue]/[TradingOrder].[MatchedVolume]), 0) else 0 end		[MatchedPrice],
				ISNULL([TradingOrder].[PublishedVolume], 0)		[PublishedVolume],
				ISNULL([TradingOrder].[PublishedPrice]*1000, 0)		[PublishedPrice],
				ISNULL([TradingOrder].[CancelledVolume], 0)		[CancelledVolume],
				ISNULL([TradingOrder].[OrderStatus], [StockOrder].[OrderStatus]) [OrderStatus]
		FROM	[StockOrder] LEFT JOIN [TradingOrder] ON [StockOrder].[OrderNo] = [TradingOrder].[OrderNo]							
		WHERE 	(@BranchCode = '' OR [StockOrder].[BranchCode] = @BranchCode)
     			AND  ([StockOrder].[CustomerID] LIKE '%' + @CustomerID)
      			AND (ISNULL([TradingOrder].[OrderStatus], [StockOrder].[OrderStatus]) = @OrderStatus OR @OrderStatus = 'A')
				And (@OrderSide  = '' OR [StockOrder].[OrderSide] = @OrderSide)
				And (@BoardType = ''  OR [StockOrder].[BoardType] = @BoardType)
				And (@StockCode  = ''  OR ([StockOrder].[StockCode]=@StockCode))
				AND (@AgencyTradecode = '' OR [StockOrder].[CustomerID] IN (SELECT CustomerID FROM AgencyCustomer WHERE AgencyTradecode=@AgencyTradecode))
	order by orderseq
	
END




GO




ALTER PROCEDURE [dbo].[Luantx_charly_UPCOMOrderCancelChangeReq_getlist]
	@RequirementType char(1),
	@BranchCode varchar(3),
	@Customerid varchar(10),
	@Stockcode varchar(10),
	@transactiondate smalldatetime,
	@status char(1),
	@AgencyTradecode VARCHAR(20) = '',
	@outputcode int = 1 -- 1: cho Babetta, 2 : cho Charly
	--WITH ENCRYPTION
AS
begin
SET NOCOUNT ON
if @outputcode = 1
select
	case RequirementType when 'D' then N'Hủy' else N'Sửa'end as RequirementType, 
	Branchcode,
	Orderseq,
	CustomerID,
	StockCode,
	case Orderside when 'B' then N'Mua' else N'Bán' end as Orderside,
	Ordervolume,
	OrderPrice,
	ExchangeOrderseq,
	SBSStatus,
	RequestedBy
From
	Luantx_charly_UPCOM_OrderCancelChange_requirement
Where
	(@RequirementType = '' or RequirementType = @RequirementType)
	AND (@Branchcode ='' or Branchcode = @Branchcode)
	And (@stockcode = '' or stockcode=@stockcode)
	AND (@CustomerID='' or CustomerID like '%'+@CustomerID)
	and (transactiondate = @transactiondate)
	And (@Status = '' or Status=@Status)
else if @outputcode = 2
	select
	case RequirementType when 'D' then N'Hủy' else N'Sửa'end as RequirementType, 
	Branchcode,
	Orderseq,
	CustomerID,
	StockCode,
	case Orderside when 'B' then N'Mua' else N'Bán' end as Orderside,
	Ordervolume,
	OrderPrice,
	Status,
	SBSStatus,
	RequestedBy,
	Insertedtime
From
	Luantx_charly_UPCOM_OrderCancelChange_requirement
Where
	(@RequirementType = '' or RequirementType = @RequirementType)
	AND (@Branchcode ='' or Branchcode = @Branchcode)
	And (@stockcode = '' or stockcode=@stockcode)
	AND (@CustomerID='' or CustomerID like '%'+@CustomerID)
	and (transactiondate = @transactiondate)
	And (@Status = '' or Status=@Status)
	AND (@AgencyTradecode = '' OR CustomerID IN (SELECT CustomerID FROM AgencyCustomer WHERE AgencyTradecode=@AgencyTradecode))
end
GO



SET QUOTED_IDENTIFIER ON
SET ANSI_NULLS ON
GO
--============================================
-- Description: Truy v?n Danh sách l?nh
-- 20080105 Haids: update OrderSide (Mua, Bán)
-- 20080201 TriDM: TradeCode 30
-- 20080703	TuanLN: Them van tin tu doanh
-- 20101806 Minhns: Join them AgencyCustomer de loc theo AgencyTradeCode
--============================================
--------------------------
ALTER PROCEDURE [dbo].[Agency_Order_List] @OrderDate varchar(10),
	@BranchCode varchar(3) = NULL,
	@TradeCode varchar(30) = NULL,
	@StockCode varchar(10)=NULL,
	@CustomerID varchar(10),
	@OrderStatus char(1) = 'A',
	@ReceivedBy varchar(20) = NULL,
	@OrderSide char(1) = NULL,
	@Session int=NULL,
	@BoardType char(1) = NULL,
	@BankCode varchar(10)='',
	@IsPrivate bit =0
AS
BEGIN

	IF @ReceivedBy IS NULL
	BEGIN
SELECT     StockOrder.OrderDate, StockOrder.OrderTime, StockOrder.OrderSeq, StockOrder.OrderNo, StockOrder.OrderType, StockOrder.OrderSide, 
                      CASE [StockOrder].[OrderSide] WHEN 'B' THEN N'Mua' WHEN 'S' THEN N'Bán' ELSE 'N/A' END AS OrderSideViet, StockOrder.BoardType, 
                      StockOrder.StockCode, StockOrder.OrderVolume, StockOrder.OrderPrice, StockOrder.OrderValue, StockOrder.OrderFee, 
                      StockOrder.CustomerId AS CustomerID, StockOrder.BranchCode, StockOrder.TradeCode, StockOrder.CustomerBranchCode, 
                      StockOrder.CustomerTradeCode, StockOrder.ReceivedBy, StockOrder.ApprovedBy, StockOrder.Session, StockOrder.Notes, 
                      ISNULL(TradingOrder.MatchedVolume, 0) AS MatchedVolume, ISNULL(TradingOrder.MatchedValue, 0) AS MatchedValue, 
                      ISNULL(TradingOrder.PublishedVolume, 0) AS PublishedVolume, ISNULL(TradingOrder.PublishedPrice, 0) AS PublishedPrice, 
                      ISNULL(TradingOrder.CancelledVolume, 0) AS CancelledVolume, ISNULL(TradingOrder.OrderStatus, StockOrder.OrderStatus) AS OrderStatus
FROM         StockOrder LEFT OUTER JOIN
                      AgencyCustomer ON StockOrder.CustomerId = AgencyCustomer.CustomerId LEFT OUTER JOIN
                      TradingOrder ON StockOrder.OrderNo = TradingOrder.OrderNo
WHERE     (StockOrder.OrderDate = @OrderDate) AND (@BranchCode IS NULL OR
                      StockOrder.BranchCode = @BranchCode) AND (@TradeCode IS NULL OR
                      AgencyCustomer.AgencyTradeCode = @TradeCode) AND (StockOrder.CustomerId LIKE '%' + @CustomerID + '%') AND (@IsPrivate = 0 AND 
                      StockOrder.CustomerId NOT LIKE '___P%' OR
                      @IsPrivate = 1 AND StockOrder.CustomerId LIKE '___P%') AND (ISNULL(TradingOrder.OrderStatus, StockOrder.OrderStatus) = @OrderStatus OR
                      @OrderStatus = 'A') AND (@OrderSide IS NULL OR
                      StockOrder.OrderSide = @OrderSide) AND (@Session IS NULL OR
                      StockOrder.Session = @Session) AND (@BoardType IS NULL OR
                      StockOrder.BoardType = @BoardType) AND (@StockCode IS NULL OR
                      StockOrder.StockCode = @StockCode) AND (@BankCode IS NULL OR
                      StockOrder.CustomerId IN
                          (SELECT     CustomerId
                            FROM          CustomerBank
                            WHERE      (BankCode = @BankCode) AND (Activate = 1)))
ORDER BY dbo.StockOrder.OrderTime ASC
                            
	END
	ELSE
	BEGIN

		SELECT 	[StockOrder].[OrderDate]						[OrderDate],
				[StockOrder].[OrderTime]						[OrderTime],
				[StockOrder].[OrderSeq]							[OrderSeq],
				[StockOrder].[OrderNo]							[OrderNo],
				[StockOrder].[OrderType]						[OrderType],
				[StockOrder].[OrderSide]						[OrderSide],
				Case [StockOrder].[OrderSide]
					When 'B' then N'Mua'
					When 'S' then N'Bán'
					Else 'N/A'
				End as											[OrderSideViet],
				[StockOrder].[BoardType]						[BoardType],
				[StockOrder].[StockCode]						[StockCode],
				[StockOrder].[OrderVolume]						[OrderVolume],
				[StockOrder].[OrderPrice]						[OrderPrice],
				[StockOrder].[OrderValue]						[OrderValue],
				[StockOrder].[OrderFee]							[OrderFee],
				[StockOrder].[CustomerID]						[CustomerID],
				[StockOrder].[BranchCode]						[BranchCode],
				[StockOrder].[TradeCode]						[TradeCode],
				[StockOrder].[CustomerBranchCode]				[CustomerBranchCode],
				[StockOrder].[CustomerTradeCode]				[CustomerTradeCode],
				[StockOrder].[ReceivedBy]						[ReceivedBy],
				[StockOrder].[ApprovedBy]						[ApprovedBy],
				[StockOrder].[Session]							[Session],
				[StockOrder].[Notes]							[Notes],
				ISNULL([TradingOrder].[MatchedVolume], 0)		[MatchedVolume],
				ISNULL([TradingOrder].[MatchedValue], 0)		[MatchedValue],
				ISNULL([TradingOrder].[PublishedVolume], 0)		[PublishedVolume],
				ISNULL([TradingOrder].[PublishedPrice], 0)		[PublishedPrice],
				ISNULL([TradingOrder].[CancelledVolume], 0)		[CancelledVolume],
				ISNULL([TradingOrder].[OrderStatus], [StockOrder].[OrderStatus]) [OrderStatus]
		FROM	StockOrder LEFT OUTER JOIN
                      AgencyCustomer ON StockOrder.CustomerId = AgencyCustomer.CustomerId LEFT OUTER JOIN
                      TradingOrder ON StockOrder.OrderNo = TradingOrder.OrderNo
		WHERE 	[StockOrder].[OrderDate] = @OrderDate
				AND (@BranchCode IS NULL OR [StockOrder].[BranchCode] = @BranchCode)
      			AND (@TradeCode IS NULL OR AgencyCustomer.AgencyTradeCode = @TradeCode)
      			AND [StockOrder].[CustomerID] LIKE '%' + @CustomerID + '%' AND ((@IsPrivate=0 AND [StockOrder].[CustomerID] NOT LIKE '___P%') OR (@IsPrivate=1 AND [StockOrder].[CustomerID] LIKE '___P%'))
      			AND (ISNULL([TradingOrder].[OrderStatus], [StockOrder].[OrderStatus]) = @OrderStatus OR @OrderStatus = 'A')
      			AND [ReceivedBy] LIKE @ReceivedBy + '%'
				And (@OrderSide IS NULL OR [StockOrder].[OrderSide] = @OrderSide)
				And (@Session IS NULL OR [StockOrder].[Session]=@Session)
				And (@BoardType IS NULL OR [StockOrder].[BoardType] = @BoardType)
				And (@StockCode IS NULL OR [StockOrder].[StockCode]=@StockCode)
				AND (@BankCode IS NULL OR [StockOrder].[CustomerID] IN (SELECT CustomerID FROM [CustomerBank] WHERE [BankCode]=@BankCode AND [Activate]=1))
		ORDER BY dbo.StockOrder.OrderTime ASC
	END
END



GO
