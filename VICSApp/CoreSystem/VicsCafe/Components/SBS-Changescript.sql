IF NOT  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[vrm_Contract]') AND type in (N'U'))
CREATE TABLE [dbo].[vrm_Contract](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContractID] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_vrm_Contract_ContractID]  DEFAULT ('x'),
	[CustomerId] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ContractType] [tinyint] NOT NULL,
	[Status] [tinyint] NOT NULL,
	[DueDate] [smalldatetime] NOT NULL,
	[ExpiredDate] [smalldatetime] NOT NULL,
	[BranchCode] [varchar](3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TradeCode] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CreatedDate] [smalldatetime] NOT NULL,
	[CreatedBy] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ApprovedDate] [smalldatetime] NULL,
	[ApprovedBy] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DisbursedDate] [smalldatetime] NULL,
	[DisbursedBy] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Amount] [money] NULL,
	[WithdrawDate] [smalldatetime] NULL,
	[WithdrawBy] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[InterestAmount] [money] NULL,
 CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
CREATE UNIQUE NONCLUSTERED INDEX [IX_vrm_Contract] ON [dbo].[vrm_Contract] 
(
	[ContractID] ASC
) ON [PRIMARY]
GO
IF NOT  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[vrm_UserAccess]') AND type in (N'U'))
CREATE TABLE [dbo].[vrm_UserAccess](
	[UserId] [int] NOT NULL,
	[AccessRight] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_UserAccess] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[AccessRight] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
IF NOT  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[vrm_Customer]') AND type in (N'U'))
CREATE TABLE [dbo].[vrm_Customer](
	[CustomerId] [varchar](10) NOT NULL,
	[MarginRate] [tinyint] NOT NULL
 CONSTRAINT [PK_MarginSetup] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
IF NOT  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[vrm_Stock]') AND type in (N'U'))
CREATE TABLE [dbo].[vrm_Stock](
	[StockCode] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ValueRate] [int] NOT NULL,
	[CellingFixedPrice] [money] NULL,
	[CreatedBy] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ModifiedBy] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedDate] [smalldatetime] NOT NULL,
	[ModifiedDate] [smalldatetime] NULL,
 CONSTRAINT [PK_vrm_Stock_1] PRIMARY KEY CLUSTERED 
(
	[StockCode] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
IF NOT  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[vrm_InterestDate]') AND type in (N'U'))
CREATE TABLE [dbo].[vrm_InterestDate](
	[Date] [smalldatetime] NOT NULL,
	[CustomerID] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[InterestAmount] [decimal](18, 0) NULL,
	[IsLatest] [bit] NULL,
	[CalculatedBy] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_vrm_InterestDate] PRIMARY KEY CLUSTERED 
(
	[Date] ASC,
	[CustomerID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

---------------User Access

declare @userid int
set @userid = 66 -- hcmvinhnt : 66 is one of general admin
if not exists (select * from vrm_useraccess where userid = @userid and accessright = 'AdminBranch')
insert into vrm_useraccess(userid, [AccessRight]) values (@userid, 'AdminBranch')

set @userid = 213 -- vinhnt
if not exists (select * from vrm_useraccess where userid = @userid and accessright = 'AdminBranch')
insert into vrm_useraccess(userid, [AccessRight]) values (@userid, 'AdminBranch')

-- update interestdate
delete from vrm_interestdate
insert into vrm_interestdate(date, customerid, IsLatest) 
select distinct CAST('2010-05-26 00:00:00' AS smallDATETIME), c.customerid, 1 from customers c
join 
(
	SELECT CustomerId FROM dbo.DeferredTransactionDay WHERE BranchCode = '100'
	UNION all
	SELECT CustomerId FROM deferredtransactiondayhist WHERE BranchCode = '100'
)d on d.customerid = c.customerid

update vrm_interestdate set IsLatest = 0 where CustomerID = '076C016688'
insert into vrm_interestdate(date, customerid, IsLatest, InterestAmount) 
select  CAST('2010-07-1 00:00:00' AS smallDATETIME), '076C016688', 1, 3206020

update vrm_interestdate set IsLatest = 0 where CustomerID = '076C125599'
insert into vrm_interestdate(date, customerid, IsLatest, InterestAmount) 
select  CAST('2010-07-9 00:00:00' AS smallDATETIME), '076C125599', 1, 628680

update vrm_interestdate set IsLatest = 0 where CustomerID = '076C331973'
insert into vrm_interestdate(date, customerid, IsLatest, InterestAmount) 
select  CAST('2010-07-9 00:00:00' AS smallDATETIME), '076C331973', 1, 696960

-- update current margin rate for all customer arcording to the deferring customer in charly
SELECT 
	'if not exists(select * from vrm_customer where customerid = '''+customerid
	+''') INSERT INTO vrm_Customer(CustomerId, MarginRate)VALUES(''' + Customerid  + ''',' 
	+ CAST(DebitPercentLimit AS VARCHAR(10)) + ')'
	 FROM dbo.Luantx_Charly_DeferringCustomers
-- remain customer will be update 50%
SELECT DISTINCT
'if not exists(select * from vrm_customer where customerid = '''+customerid
	+''') INSERT INTO vrm_Customer(CustomerId, MarginRate)VALUES(''' + Customerid  + ''',50)' 
	 FROM dbo.DeferredBalance WHERE CustomerID NOT IN (SELECT CustomerID FROM vrm_customer)

-- update vrm_stock	 
SELECT 
'INSERT INTO dbo.vrm_Stock( StockCode ,ValueRate ,CellingFixedPrice ,CreatedBy ,ModifiedBy ,CreatedDate ,ModifiedDate) ' +
'select '''+StockCode+''',100,'+CONVERT(VARCHAR,OpenPrice*1.5)+',''vinhnt'',null,getdate() ,NULL  ' 
from dbo.StockPrice
where StockCode not in (select StockCode from dbo.Luantx_Charly_NotValuedStockCode)

--- tao hop dong khong ky han voi thoi han hop dong 15 ngay cho cac khach hang dang no cham tien T

delete from dbo.vrm_Contract
declare @day nvarchar(30)
declare @day30 nvarchar(30)
set @day = CONVERT(nvarchar(30),getdate(),23)
set @day30 = CONVERT(nvarchar(30),DATEADD(DAY, 30, getdate()),23)
INSERT INTO dbo.vrm_Contract( CustomerId , ContractID, ContractType ,Status ,DueDate ,ExpiredDate ,BranchCode ,TradeCode ,CreatedDate ,CreatedBy ,ApprovedDate ,ApprovedBy ,DisbursedDate ,DisbursedBy ,Amount ,WithdrawDate ,WithdrawBy ,InterestAmount)
select distinct c.CustomerID, dbo.PADL(cast(row_number() over (order by c.CustomerId) as varchar), 4, '0') + '-' + c.BranchCode + '/' + TradeCode,
 1, 2, @day, @day30, c.BranchCode, c.TradeCode, @day, 'hcmvinhnt', @day, 'hcmvinhnt', NULL, NULL, NULL, NULL, NULL, NULL 
FROM dbo.Customers c
JOIN
(
	select distinct customerid FROM dbo.DeferredBalance 
) x ON x.customerid = c.CustomerId
--where c.BranchCode = '200'

-- Sua lai store procedure cua SBS vi double khoan thu no khi tai khoan chi tiet la ma khach hang
-- Author: Haids 20080916
-- Description: Báo cáo ch?m ti?n ngày T
-- 20081008 Haids: update Phòng giao d?ch
--============================================

ALTER Procedure [dbo].[Report_DeferredBalance]
	@BranchCode varchar(10),
	@TradeCode varchar(30),
	@FromDate smalldatetime,
	@ToDate smalldatetime,
	@CustomerID varchar(10),
	@DeferredType varchar(10),
	@SumDayDebit Decimal OUT,
	@SumCurrentDebit Decimal OUT
	WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @TempDeferrable TABLE
	(
		BranchCode	 varchar(3),
		CustomerID	 varchar(10),
		CustomerName varchar(100),
		DayCredit	 decimal,
		DayDebit	 decimal,
		CurrentDebit decimal,
		TradingDate	 smalldatetime,
		DeferredType varchar(50),
		TradeCode    varchar(30)
	);

	INSERT INTO @TempDeferrable(BranchCode, CustomerID, CustomerName, DayCredit,
								DayDebit, CurrentDebit, TradingDate, DeferredType, TradeCode)
	SELECT a.BranchCode, a.CustomerID, a.CustomerName, a.DayCredit, 
			   a.DayDebit, a.CurrentDebit, a.TradingDate, a.DeferredType,
				Case c.UnitType
					when '3' then c.ParentUnit
					else c.TradeCode
				End
	FROM DeferredBalance a Inner Join Customers b
		ON a.CustomerID = b.CustomerID
		Inner Join UnitTradeCode c
		ON b.TradeCode = c.TradeCode 
	WHERE (@BranchCode = '' Or a.[BranchCode] = @BranchCode)
			AND 
			Case c.UnitType
					when '3' then c.ParentUnit
					else c.TradeCode
			End = @TradeCode
			AND a.[TradingDate] Between @FromDate And @ToDate
			AND (@CustomerID = '' Or a.[CustomerID] like '%' + @CustomerID + '%')
			AND (@DeferredType = '' Or a.[DeferredType] = @DeferredType)
	
	UNION ALL
	SELECT a.BranchCode, a.CustomerID, a.CustomerName, a.DayCredit, 
		   a.DayDebit, a.CurrentDebit, a.TradingDate, a.DeferredType,
		    Case c.UnitType
				when '3' then c.ParentUnit
				else c.TradeCode
			End
	FROM DeferredBalanceHist a Inner Join Customers b
		ON a.CustomerID = b.CustomerID
		Inner Join UnitTradeCode c
		ON b.TradeCode = c.TradeCode
	WHERE (@BranchCode = '' Or a.[BranchCode] = @BranchCode)
			AND 
			Case c.UnitType
					when '3' then c.ParentUnit
					else c.TradeCode
			End = @TradeCode
			AND a.[TradingDate] Between @FromDate And @ToDate
			AND (@CustomerID = '' Or a.[CustomerID] like '%' + @CustomerID + '%')
			AND (@DeferredType = '' Or a.[DeferredType] = @DeferredType)
	
	DECLARE @TempTransaction TABLE
	(
		AccountID	    varchar(10),
		TransactionDate	smalldatetime,
		Amount	        decimal(18, 0),
		Description	    varchar(250)

	);

	INSERT INTO @TempTransaction(AccountID, TransactionDate, Amount, Description)
	SELECT AccountID, TransactionDate, Amount, Description FROM TransactionDay
	WHERE TransactionCode Like 'DEFER%' And Approved <> 'X' and DebitOrCredit = 'D'
	UNION ALL
	SELECT AccountID, TransactionDate, Amount, Description FROM TransactionHist
	WHERE TransactionCode Like 'DEFER%' And Approved <> 'X' and DebitOrCredit = 'D'
	
	SET @SumDayDebit = (Select ISNULL(SUM(DayDebit),0) From @TempDeferrable)
	SET @SumCurrentDebit = (Select ISNULL(SUM(CurrentDebit),0) From @TempDeferrable)
	
	SELECT
		a.TradingDate,  
		a.CustomerID,
		a.CustomerName,
		a.DayCredit,
		a.DayDebit,
		a.CurrentDebit,
		a.DeferredType,
		ISNULL(b.Amount,0) as PaymentAmount,
		b.TransactionDate as PaymentDate
	FROM    @TempDeferrable a LEFT OUTER JOIN @TempTransaction b
			ON a.CustomerID = b.AccountID
				And b.Description Like '%' + CONVERT(varchar(10), a.TradingDate, 103) + '%'
	WHERE a.DayCredit > 0 Or a.DayDebit > 0 Or a.CurrentDebit > 0
	ORDER BY a.TradingDate, a.CustomerID
	
END


-- 2010-09-08
ALTER TABLE dbo.vrm_Customer add IsSpecial bit NULL

-- 2010-09-10
-- =============================================
-- Author:		???
-- Create date: ???
-- Description:	Truy van CK khach hang
-- 20071227 TruongTN refactor
-- 20080118 TruongTN tra ve gia tri Chung khoan dat lenh ban nhung chua hach toan
-- 20080123 TruongTN tra ve gia tri Chung khoan da xuat di nhung chua duoc duyet
-- 20080305 Haids: Tham s? hóa BankGL, SectionGL và s?a l?i các tham s? b? nh?m
-- 20080322 TruongTN: Thay tru?ng Status b?ng các tru?ng m?i Tvalue
--						Dùng 2 function m?i IsPrivateAccount, DomesticForeign
-- 20080328 TruongTN: Ð?i tên tru?ng TValue thành T
-- 20080329 TruongTN: Thay tru?ng TransactionDayEnd b?ng tru?ng MarketStatus
-- 20080330 Haids: update BankGL t? doanh c?a BSC = '012111'
-- 20080403 TruongTN: L?y thêm ch?ng kho?n chuy?n kho?n di @BankGL_CKCK
-- 20080408 TriDM: loai bo cac lenh huy tu dai ly (R)
-- 20080408 Haids: Ð?i SectionGL sang BankGL
-- 20080418 TruongTN: Vi BankGL cua Ch?ng khoán ch? thanh toán trung BankGL cua Ch?ng khoán chuy?n kho?n di
--						nen them dieu kien de lay so tong
-- 20080423 TriDM: isnull
-- 20080509 Haids: update CK ch? GD và Ch?ng khoán l? cho t? doanh
-- 20080514 TruongTn: Tham s? hóa BankGL, SectionGL theo b?ng SecuritiesTypeAccount
-- bo check dieu kien SectionGL : (a.SectionGL != dbo.SecuritiesAccount('P', 'P', 0))
-- 20080612 Haids: Phân tách Ch?ng khoán niêm y?t, chua niêm y?t, c? phi?u, ch?ng ch? qu? và trái phi?u
-- 20080621 TriDM: loai bo dieu kien check sectionGL sai
-- 20080701 TruongTN them dieu kien a.OrderStatus <> 'F' 
-- 20080712 TriDM: bo sung StockTypeOriginal
-- 20080728 Haids: update CK CNY, BoardTypeText
-- 20100910 Vinh: lay dung gia dong cua voi truong hop san Hose
-- =============================================
go
alter PROCEDURE [dbo].[Customer_StockEnquiry]
	@AccountID  		varchar(10),
	@BranchCode 		varchar(3),
	@TradingDate 		smalldatetime

WITH ENCRYPTION	
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @DomesticForeign char(1);
	
	DECLARE @Status char(1);
	SET @Status = dbo.TransDate_Status(@BranchCode, @TradingDate);
					
	DECLARE @Stock TABLE
		(
			MaCK			varchar(10),
			CKGiaoDich		bigint,	
			CKXuatChuaDuyet bigint,			
			CKCamCo			bigint,			
			CKHanChe		bigint,
			CKOTC			bigint,
			CKDatLenhBan	bigint,
			CKBanCHT		bigint,
			CKChuyenKhoan	bigint,
			Tong			bigint,
			CurrentPrice	decimal(18, 1),
			CKChoGiaoDich   bigint, 
			CKle			bigint,
			PRIMARY KEY CLUSTERED (MACK)	
		);
	
	IF @Status = 'Y'		-- Da ket thuc ngay	
		BEGIN			
			-- 20070928 TriDM: kiem tra tu doanh
			IF dbo.IsPrivateAccount(@AccountID) = 1	
				BEGIN
					INSERT INTO @Stock(MaCK, CKCamCo, CKOTC, Tong)
						SELECT a.StockCode, 0, 0, SUM(a.Quantity) 
								FROM SecuritiesHist a
								WHERE a.TransactionDate = @TradingDate AND a.AccountID = @AccountID
									AND (a.BankGL != dbo.SecuritiesAccount('P', 'P', 1))	-- CK cho thanh toan tu doanh
								GROUP BY a.StockCode
								HAVING SUM(a.Quantity) != 0;
						
					UPDATE @Stock
					SET CKGiaoDich = b.SumQuantity,
						CKXuatChuaDuyet = b.SumPendingQuantity
					FROM (SELECT a.StockCode, SUM(a.Quantity) AS SumQuantity, SUM(a.PendingDebitQuantity) AS SumPendingQuantity
							FROM SecuritiesHist a
							WHERE a.TransactionDate = @TradingDate AND a.AccountID = @AccountID 
								AND a.BankGL = dbo.SecuritiesAccount('N', 'P', 1)	-- CK giao dich tu doanh
							GROUP BY a.StockCode) AS b
					WHERE MaCK = b.StockCode;
					
					UPDATE @Stock
					SET CKHanChe = b.SumQuantity
					FROM (SELECT a.StockCode, SUM(a.Quantity) AS SumQuantity
							FROM SecuritiesHist a
							WHERE a.TransactionDate = @TradingDate AND a.AccountID = @AccountID 
								AND a.BankGL = dbo.SecuritiesAccount('L', 'P', 1)	-- CK han che tu doanh
								-------------------------AND a.SectionGL = dbo.SecuritiesAccount('L', 'P', 0)
								-- AND a.BankGL = '013221' AND a.SectionGL = '9999'
							GROUP BY a.StockCode) AS b
					WHERE MaCK = b.StockCode;	
					
					-- update Ch?ng khoán ch? giao d?ch 
					UPDATE @Stock
					SET CKChoGiaoDich = b.SumQuantity
					FROM (SELECT a.StockCode, SUM(a.Quantity) AS SumQuantity
							FROM SecuritiesHist a
							WHERE a.TransactionDate = @TradingDate AND a.AccountID = @AccountID
								AND a.BankGL = dbo.SecuritiesAccount('W', 'P', 1)	-- CK ch? giao d?ch tu doanh
								-----------------AND a.SectionGL = dbo.SecuritiesAccount('W', 'P', 0)
								-- AND a.BankGL = @BankGL_CKCGD_P And a.SectionGL = '9999'
							GROUP BY a.StockCode) as b
					WHERE MaCK = b.StockCode;
					
					-- ch?ng khoán l? t? doanh
					UPDATE @Stock
					SET CKLe = b.SumQuantity
					FROM (SELECT a.StockCode, SUM(a.Quantity) AS SumQuantity
							FROM SecuritiesHist a
							WHERE a.TransactionDate = @TradingDate AND a.AccountID = @AccountID
								AND a.BankGL = dbo.SecuritiesAccount('D', 'P', 1)	-- CK l? tu doanh
								---AND a.SectionGL = dbo.SecuritiesAccount('D', 'P', 0)
								-- AND a.BankGL = @BankGL_CKLe_P And a.SectionGL = '9999'
							GROUP BY a.StockCode) as b
					WHERE MaCK = b.StockCode;
																								
				END			
			ELSE		-- Khong phai tu doanh
				BEGIN
					-- Xem khach hang la trong nuoc hay ngoai nuoc
					IF dbo.DomesticForeign(@AccountID) = 'D' -- Trong nuoc
						BEGIN
							INSERT INTO @Stock(MaCK, Tong)
								SELECT a.StockCode, SUM(a.Quantity)
								FROM SecuritiesHist a
								WHERE a.TransactionDate = @TradingDate AND a.AccountID = @AccountID
									AND a.BankGL != dbo.SecuritiesAccount('P', 'D', 1)	-- CK ch? thanh toán KH trong nu?c
								GROUP BY a.StockCode
								HAVING SUM(a.Quantity) != 0;
								
							UPDATE @Stock
							SET CKGiaoDich = b.SumQuantity,
								CKXuatChuaDuyet = b.SumPendingQuantity
							FROM (SELECT a.StockCode, SUM(a.Quantity) AS SumQuantity, SUM(a.PendingDebitQuantity) AS SumPendingQuantity
									FROM SecuritiesHist a
									WHERE a.TransactionDate = @TradingDate AND a.AccountID = @AccountID 
										AND a.BankGL = dbo.SecuritiesAccount('N', 'D', 1)	-- CK giao d?ch KH trong nu?c
										AND a.SectionGL = dbo.SecuritiesAccount('N', 'D', 0)
										-- AND a.BankGL = @BankGL_CKGD_D --'0121'
									GROUP BY a.StockCode) AS b
							WHERE MaCK = b.StockCode;	
					
							UPDATE @Stock
							SET CKCamCo = b.SumQuantity
							FROM (SELECT a.StockCode, SUM(a.Quantity) AS SumQuantity
									FROM SecuritiesHist a
									WHERE a.TransactionDate = @TradingDate AND a.AccountID = @AccountID 
										AND a.BankGL = dbo.SecuritiesAccount('M', 'D', 1)	-- CK c?m c? KH trong nu?c
										AND a.SectionGL = dbo.SecuritiesAccount('M', 'D', 0)
										-- AND a.BankGL = @BankGL_CKCC_D --'0124'
									GROUP BY a.StockCode) AS b
							WHERE MaCK = b.StockCode;
													
							UPDATE @Stock
							SET CKHanChe = b.SumQuantity
							FROM (SELECT a.StockCode, SUM(a.Quantity) AS SumQuantity
									FROM SecuritiesHist a
									WHERE a.TransactionDate = @TradingDate AND a.AccountID = @AccountID 
										AND a.BankGL = dbo.SecuritiesAccount('L', 'D', 1)	-- CK h?n ch? KH trong nu?c
										AND a.SectionGL = dbo.SecuritiesAccount('L', 'D', 0)
										-- AND a.BankGL = @BankGL_CKHC_D --'0125'
									GROUP BY a.StockCode) AS b
							WHERE MaCK = b.StockCode;
							
							UPDATE @Stock
							SET CKOTC = b.SumQuantity
							FROM (SELECT a.StockCode, SUM(a.Quantity) AS SumQuantity
									FROM SecuritiesHist a
									WHERE a.TransactionDate = @TradingDate AND a.AccountID = @AccountID 
										AND a.BankGL = dbo.SecuritiesAccount('O', 'D', 1)	-- CK OTC KH trong nu?c
										AND a.SectionGL = dbo.SecuritiesAccount('O', 'D', 0)
										-- AND a.BankGL = @BankGL_CKOTC_D --'0123'
									GROUP BY a.StockCode) AS b
							WHERE MaCK = b.StockCode;
							
							UPDATE @Stock
							SET CKChuyenKhoan = b.SumQuantity
							FROM (SELECT a.StockCode, SUM(a.Quantity) AS SumQuantity
									FROM SecuritiesHist a
									WHERE a.TransactionDate = @TradingDate AND a.AccountID = @AccountID 
										AND a.BankGL = dbo.SecuritiesAccount('T', 'D', 1)	-- CK chuy?n kho?n KH trong nu?c
										AND a.SectionGL = dbo.SecuritiesAccount('T', 'D', 0)
										-- AND a.BankGL = @BankGL_CKCK_D AND a.SectionGL = @SectionGL_CKCK_D 
									GROUP BY a.StockCode) AS b
							WHERE MaCK = b.StockCode;
														
						END
						
					ELSE	-- dbo.DomesticForeign(@AccountID) = 'F': Nuoc ngoai
						BEGIN
							INSERT INTO @Stock(MaCK, Tong)
								SELECT a.StockCode, SUM(a.Quantity)
								FROM SecuritiesHist a
								WHERE a.TransactionDate = @TradingDate AND a.AccountID = @AccountID
									AND a.BankGL != dbo.SecuritiesAccount('P', 'F', 1)	-- CK ch? thanh toán KH nu?c ngoài
								GROUP BY a.StockCode
								HAVING SUM(a.Quantity) != 0;
								
							UPDATE @Stock
							SET CKGiaoDich = b.SumQuantity,
								CKXuatChuaDuyet = b.SumPendingQuantity
							FROM (SELECT a.StockCode, SUM(a.Quantity) AS SumQuantity, SUM(a.PendingDebitQuantity) AS SumPendingQuantity
									FROM SecuritiesHist a
									WHERE a.TransactionDate = @TradingDate AND a.AccountID = @AccountID 
										AND a.BankGL = dbo.SecuritiesAccount('N', 'F', 1)	-- CK giao d?ch KH nu?c ngoài
										AND a.SectionGL = dbo.SecuritiesAccount('N', 'F', 0)
										-- AND a.BankGL = @BankGL_CKGD_F --'0131'
									GROUP BY a.StockCode) AS b
							WHERE MaCK = b.StockCode;	
					
							UPDATE @Stock
							SET CKCamCo = b.SumQuantity
							FROM (SELECT a.StockCode, SUM(a.Quantity) AS SumQuantity
									FROM SecuritiesHist a
									WHERE a.TransactionDate = @TradingDate AND a.AccountID = @AccountID 
										AND a.BankGL = dbo.SecuritiesAccount('M', 'F', 1)	-- CK c?m c? KH nu?c ngoài
										AND a.SectionGL = dbo.SecuritiesAccount('M', 'F', 0)
										-- AND a.BankGL = @BankGL_CKCC_F --'0134'
									GROUP BY a.StockCode) AS b
							WHERE MaCK = b.StockCode;
													
							UPDATE @Stock
							SET CKHanChe = b.SumQuantity
							FROM (SELECT a.StockCode, SUM(a.Quantity) AS SumQuantity
									FROM SecuritiesHist a
									WHERE a.TransactionDate = @TradingDate AND a.AccountID = @AccountID 
										AND a.BankGL = dbo.SecuritiesAccount('L', 'F', 1)	-- CK h?n ch? KH nu?c ngoài
										AND a.SectionGL = dbo.SecuritiesAccount('L', 'F', 0)
										-- AND a.BankGL = @BankGL_CKHC_F --'0135'
									GROUP BY a.StockCode) AS b
							WHERE MaCK = b.StockCode;
							
							UPDATE @Stock
							SET CKOTC = b.SumQuantity
							FROM (SELECT a.StockCode, SUM(a.Quantity) AS SumQuantity
									FROM SecuritiesHist a
									WHERE a.TransactionDate = @TradingDate AND a.AccountID = @AccountID 
										AND a.BankGL = dbo.SecuritiesAccount('O', 'F', 1)	-- CK OTC KH nu?c ngoài
										AND a.SectionGL = dbo.SecuritiesAccount('O', 'F', 0)
										-- AND a.BankGL = @BankGL_CKOTC_F --'0133'
									GROUP BY a.StockCode) AS b
							WHERE MaCK = b.StockCode;
							
							UPDATE @Stock
							SET CKChuyenKhoan = b.SumQuantity
							FROM (SELECT a.StockCode, SUM(a.Quantity) AS SumQuantity
									FROM SecuritiesHist a
									WHERE a.TransactionDate = @TradingDate AND a.AccountID = @AccountID 
										AND a.BankGL = dbo.SecuritiesAccount('T', 'F', 1)	-- CK chuy?n kho?n KH nu?c ngoài
										AND a.SectionGL = dbo.SecuritiesAccount('T', 'F', 0)
										-- AND a.BankGL = @BankGL_CKCK_F AND a.SectionGL = @SectionGL_CKCK_F 
									GROUP BY a.StockCode) AS b
							WHERE MaCK = b.StockCode;
							
						END
				END
			
			DECLARE @TradingDateVarchar	varchar(10);
			SET @TradingDateVarchar	=  CONVERT(varchar(10), @TradingDate, 103);
			
			UPDATE @Stock
			SET CKDatLenhBan = b.SumQuantity
			FROM (SELECT a.StockCode, SUM(MatchedVolume) AS SumQuantity
					FROM	TradingOrderHist a						
					WHERE 	a.OrderDate = @TradingDateVarchar
  						AND a.CustomerID = @AccountID    						
						AND a.OrderSide = 'S'
					GROUP BY a.StockCode) AS b
			WHERE MaCK = b.StockCode;
			
			UPDATE @Stock
			SET CKBanCHT = b.SumQuantity
			FROM (SELECT a.StockCode, SUM(MatchedVolume) AS SumQuantity
					FROM	TradingResultHist a						
					WHERE 	a.OrderDate = @TradingDateVarchar
  						AND a.CustomerID = @AccountID    						
						AND a.OrderSide = 'S'
						AND a.T = 0
					GROUP BY a.StockCode) AS b
			WHERE MaCK = b.StockCode;
							
			UPDATE @Stock
			SET CurrentPrice = b.BasicPrice
			FROM (SELECT a.StockCode, a.BasicPrice 
					FROM StockPriceHist a
					WHERE a.TradingDate = @TradingDateVarchar) AS b
			WHERE MaCK = b.StockCode;
			
		END
	
	ELSE -- Chua ket thuc ngay
		BEGIN			
			-- 20070928 TriDM: kiem tra tu doanh
			IF dbo.IsPrivateAccount(@AccountID) = 1	
				BEGIN
					INSERT INTO @Stock(MaCK, CKCamCo, CKOTC, Tong)
						SELECT a.StockCode, 0, 0, SUM(a.Quantity) 
								FROM Securities a
								WHERE a.AccountID = @AccountID
									AND (a.BankGL != dbo.SecuritiesAccount('P', 'P', 1))	-- CK cho thanh toan tu doanh
								GROUP BY a.StockCode
								HAVING SUM(a.Quantity) != 0;
						
					UPDATE @Stock
					SET CKGiaoDich = b.SumQuantity,
						CKXuatChuaDuyet = b.SumPendingQuantity
					FROM (SELECT a.StockCode, SUM(a.Quantity) AS SumQuantity, SUM(a.PendingDebitQuantity) AS SumPendingQuantity
							FROM Securities a
							WHERE a.AccountID = @AccountID 
								AND a.BankGL = dbo.SecuritiesAccount('N', 'P', 1)	-- CK giao dich tu doanh
								--AND a.SectionGL = dbo.SecuritiesAccount('N', 'P', 0)
								-- AND a.BankGL = '012111' AND a.SectionGL = '9999'
							GROUP BY a.StockCode) AS b
					WHERE MaCK = b.StockCode;
					
					UPDATE @Stock
					SET CKHanChe = b.SumQuantity
					FROM (SELECT a.StockCode, SUM(a.Quantity) AS SumQuantity
							FROM Securities a
							WHERE a.AccountID = @AccountID 
								AND a.BankGL = dbo.SecuritiesAccount('L', 'P', 1)	-- CK han che tu doanh
								--AND a.SectionGL = dbo.SecuritiesAccount('L', 'P', 0)
								-- AND a.BankGL = '013221' AND a.SectionGL = '9999'
							GROUP BY a.StockCode) AS b
					WHERE MaCK = b.StockCode;

					-- update Ch?ng khoán ch? giao d?ch và ch?ng khoán l? t? doanh
					UPDATE @Stock
					SET CKChoGiaoDich = b.SumQuantity
					FROM (SELECT a.StockCode, SUM(a.Quantity) AS SumQuantity
							FROM Securities a
							WHERE a.AccountID = @AccountID
								AND a.BankGL = dbo.SecuritiesAccount('W', 'P', 1)	-- CK ch? giao d?ch tu doanh
								--AND a.SectionGL = dbo.SecuritiesAccount('W', 'P', 0)
								-- AND a.BankGL = @BankGL_CKCGD_P And a.SectionGL = '9999'
							GROUP BY a.StockCode) as b
					WHERE MaCK = b.StockCode;

					UPDATE @Stock
					SET CKLe = b.SumQuantity
					FROM (SELECT a.StockCode, SUM(a.Quantity) AS SumQuantity
							FROM Securities a
							WHERE a.AccountID = @AccountID
									AND a.BankGL = dbo.SecuritiesAccount('D', 'P', 1)	-- CK l? tu doanh
								--AND a.SectionGL = dbo.SecuritiesAccount('D', 'P', 0)
								-- AND a.BankGL = @BankGL_CKLe_P And a.SectionGL = '9999'
							GROUP BY a.StockCode) as b
					WHERE MaCK = b.StockCode;
																								
				END			
			ELSE		-- Khong phai tu doanh
				BEGIN
					-- Xem khach hang la trong nuoc hay ngoai nuoc
					IF dbo.DomesticForeign(@AccountID) = 'D' -- Trong nuoc
						BEGIN
							INSERT INTO @Stock(MaCK, Tong)
								SELECT a.StockCode, SUM(a.Quantity)
								FROM Securities a
								WHERE a.AccountID = @AccountID
									AND a.BankGL != dbo.SecuritiesAccount('P', 'D', 1)	-- CK ch? thanh toán KH trong nu?c
								GROUP BY a.StockCode
								HAVING SUM(a.Quantity) != 0;
								
							UPDATE @Stock
							SET CKGiaoDich = b.SumQuantity,
								CKXuatChuaDuyet = b.SumPendingQuantity
							FROM (SELECT a.StockCode, SUM(a.Quantity) AS SumQuantity, SUM(a.PendingDebitQuantity) AS SumPendingQuantity
									FROM Securities a
									WHERE a.AccountID = @AccountID 
										AND a.BankGL = dbo.SecuritiesAccount('N', 'D', 1)	-- CK giao d?ch KH trong nu?c
										AND a.SectionGL = dbo.SecuritiesAccount('N', 'D', 0)
										-- AND a.BankGL = @BankGL_CKGD_D --'0121'
									GROUP BY a.StockCode) AS b
							WHERE MaCK = b.StockCode;	
					
							UPDATE @Stock
							SET CKCamCo = b.SumQuantity
							FROM (SELECT a.StockCode, SUM(a.Quantity) AS SumQuantity
									FROM Securities a
									WHERE a.AccountID = @AccountID 
										AND a.BankGL = dbo.SecuritiesAccount('M', 'D', 1)	-- CK c?m c? KH trong nu?c
										AND a.SectionGL = dbo.SecuritiesAccount('M', 'D', 0)
										-- AND a.BankGL = @BankGL_CKCC_D --'0124'
									GROUP BY a.StockCode) AS b
							WHERE MaCK = b.StockCode;
													
							UPDATE @Stock
							SET CKHanChe = b.SumQuantity
							FROM (SELECT a.StockCode, SUM(a.Quantity) AS SumQuantity
									FROM Securities a
									WHERE a.AccountID = @AccountID 
										AND a.BankGL = dbo.SecuritiesAccount('L', 'D', 1)	-- CK h?n ch? KH trong nu?c
										AND a.SectionGL = dbo.SecuritiesAccount('L', 'D', 0)
										-- AND a.BankGL = @BankGL_CKHC_D --'0125'
									GROUP BY a.StockCode) AS b
							WHERE MaCK = b.StockCode;
							
							UPDATE @Stock
							SET CKOTC = b.SumQuantity
							FROM (SELECT a.StockCode, SUM(a.Quantity) AS SumQuantity
									FROM Securities a
									WHERE a.AccountID = @AccountID 
										AND a.BankGL = dbo.SecuritiesAccount('O', 'D', 1)	-- CK OTC KH trong nu?c
										AND a.SectionGL = dbo.SecuritiesAccount('O', 'D', 0)
										-- AND a.BankGL = @BankGL_CKOTC_D --'0123'
									GROUP BY a.StockCode) AS b
							WHERE MaCK = b.StockCode;
							
							UPDATE @Stock
							SET CKChuyenKhoan = b.SumQuantity
							FROM (SELECT a.StockCode, SUM(a.Quantity) AS SumQuantity
									FROM Securities a
									WHERE a.AccountID = @AccountID 
										AND a.BankGL = dbo.SecuritiesAccount('T', 'D', 1)	-- CK chuy?n kho?n KH trong nu?c
										AND a.SectionGL = dbo.SecuritiesAccount('T', 'D', 0)
										-- AND a.BankGL = @BankGL_CKCK_D AND a.SectionGL = @SectionGL_CKCK_D 
									GROUP BY a.StockCode) AS b
							WHERE MaCK = b.StockCode;							
						END
						
					ELSE	-- dbo.DomesticForeign(@AccountID) = 'F': Nuoc ngoai
						BEGIN
							INSERT INTO @Stock(MaCK, Tong)
								SELECT a.StockCode, SUM(a.Quantity)
								FROM Securities a
								WHERE a.AccountID = @AccountID
									AND a.BankGL != dbo.SecuritiesAccount('P', 'F', 1)	-- CK ch? thanh toán KH nu?c ngoài
								GROUP BY a.StockCode
								HAVING SUM(a.Quantity) != 0;
								
							UPDATE @Stock
							SET CKGiaoDich = b.SumQuantity,
									CKXuatChuaDuyet = b.SumPendingQuantity
							FROM (SELECT a.StockCode, SUM(a.Quantity) AS SumQuantity, SUM(a.PendingDebitQuantity) AS SumPendingQuantity
									FROM Securities a
									WHERE a.AccountID = @AccountID 
										AND a.BankGL = dbo.SecuritiesAccount('N', 'F', 1)	-- CK giao d?ch KH nu?c ngoài
										AND a.SectionGL = dbo.SecuritiesAccount('N', 'F', 0)
										-- AND a.BankGL = @BankGL_CKGD_F --'0131'
									GROUP BY a.StockCode) AS b
							WHERE MaCK = b.StockCode;	
					
							UPDATE @Stock
							SET CKCamCo = b.SumQuantity
							FROM (SELECT a.StockCode, SUM(a.Quantity) AS SumQuantity
									FROM Securities a
									WHERE a.AccountID = @AccountID 
										AND a.BankGL = dbo.SecuritiesAccount('M', 'F', 1)	-- CK c?m c? KH nu?c ngoài
										AND a.SectionGL = dbo.SecuritiesAccount('M', 'F', 0)
										-- AND a.BankGL = @BankGL_CKCC_F --'0134'
									GROUP BY a.StockCode) AS b
							WHERE MaCK = b.StockCode;
													
							UPDATE @Stock
							SET CKHanChe = b.SumQuantity
							FROM (SELECT a.StockCode, SUM(a.Quantity) AS SumQuantity
									FROM Securities a
									WHERE a.AccountID = @AccountID 
										AND a.BankGL = dbo.SecuritiesAccount('L', 'F', 1)	-- CK h?n ch? KH nu?c ngoài
										AND a.SectionGL = dbo.SecuritiesAccount('L', 'F', 0)
										-- AND a.BankGL = @BankGL_CKHC_F --'0135'
									GROUP BY a.StockCode) AS b
							WHERE MaCK = b.StockCode;
							
							UPDATE @Stock
							SET CKOTC = b.SumQuantity
							FROM (SELECT a.StockCode, SUM(a.Quantity) AS SumQuantity
									FROM Securities a
									WHERE a.AccountID = @AccountID 
										AND a.BankGL = dbo.SecuritiesAccount('O', 'F', 1)	-- CK OTC KH nu?c ngoài
										AND a.SectionGL = dbo.SecuritiesAccount('O', 'F', 0)
										-- AND a.BankGL = @BankGL_CKOTC_F --'0133'
									GROUP BY a.StockCode) AS b
							WHERE MaCK = b.StockCode;
							
							UPDATE @Stock
							SET CKChuyenKhoan = b.SumQuantity
							FROM (SELECT a.StockCode, SUM(a.Quantity) AS SumQuantity
									FROM Securities a
									WHERE a.AccountID = @AccountID 
										AND a.BankGL = dbo.SecuritiesAccount('T', 'F', 1)	-- CK chuy?n kho?n KH nu?c ngoài
										AND a.SectionGL = dbo.SecuritiesAccount('T', 'F', 0)
										-- AND a.BankGL = @BankGL_CKCK_F AND a.SectionGL = @SectionGL_CKCK_F 
									GROUP BY a.StockCode) AS b
							WHERE MaCK = b.StockCode;	
						END
				END
			
			IF NOT EXISTS (SELECT 1 FROM OrderSysStat
                        	WHERE OrderDate = CONVERT(varchar(10), @TradingDate, 103) 
                        		AND MarketStatus = 'O')   
            BEGIN                     	
				UPDATE @Stock
				SET CKDatLenhBan = b.SumQuantity
				FROM (SELECT a.StockCode, SUM(MatchedVolume) AS SumQuantity
						FROM	TradingOrder a						
						WHERE a.CustomerID = @AccountID    						
							AND a.OrderSide = 'S'
						GROUP BY a.StockCode) AS b
				WHERE MaCK = b.StockCode;
				
				UPDATE @Stock
				SET CKBanCHT = b.SumQuantity
				FROM (SELECT a.StockCode, SUM(MatchedVolume) AS SumQuantity
						FROM	TradingResult a						
						WHERE a.CustomerID = @AccountID    						
							AND a.OrderSide = 'S'
							AND a.T = 0
						GROUP BY a.StockCode) AS b
				WHERE MaCK = b.StockCode;
			END
			ELSE
			BEGIN
				UPDATE @Stock
				SET CKDatLenhBan = c.SumQuantity
				FROM (SELECT a.StockCode, SUM(a.OrderVolume -  Isnull(b.CancelledVolume,0)) AS SumQuantity
						FROM	StockOrder a
							LEFT JOIN TradingOrder b
							ON a.[OrderNo] = b.[OrderNo] and a.OrderDate = b.OrderDate									
								AND b.OrderSeq IS NOT NULL
						WHERE 	a.CustomerID = @AccountID
      						AND a.OrderStatus <> 'X' AND a.OrderStatus <> 'D' 
      						AND a.OrderStatus <> 'R' AND a.OrderStatus <> 'F' 
							AND a.OrderStatus <> 'C' AND a.OrderSide = 'S'
						GROUP BY a.StockCode) AS c
				WHERE MaCK = c.StockCode;
				
				UPDATE @Stock
				SET CKBanCHT = b.SumQuantity
				FROM (SELECT a.StockCode, SUM(MatchedVolume) AS SumQuantity
						FROM	TradingResult a						
						WHERE a.CustomerID = @AccountID    						
							AND a.OrderSide = 'S'
							AND a.T = 1 				-- Chung Khoan da hach toan
						GROUP BY a.StockCode) AS b
				WHERE MaCK = b.StockCode;
				
				UPDATE @Stock
				SET CKBanCHT = ISNULL(CKDatLenhBan, 0) - ISNULL(CKBanCHT, 0);
			END
							
			UPDATE @Stock
			SET CurrentPrice = b.BasicPrice
			FROM (SELECT a.StockCode,  
                        case boardtype when 'S' then averageprice else case closeprice when 0 then basicprice else closeprice end end as basicprice 
					FROM StockPrice a) AS b
			WHERE MaCK = b.StockCode;
			
		END	
	
	SELECT a.MaCK, 
				CASE b.BoardType
					WHEN 'M' THEN '1M'
					WHEN 'S' THEN '2S'
					WHEN 'O' THEN '3O'
					WHEN 'U' THEN '4U'
				END as BoardType,
				CASE b.BoardType
					WHEN 'M' THEN 'HOSE'
					WHEN 'S' THEN 'HASTC'
					WHEN 'O' THEN 'OTC'
					WHEN 'U' THEN 'CNY'
				END as BoardTypeText,
				CASE b.StockType
					When 'S' Then '1S'
					When 'U' Then '2U'
					Else '3D'
				END	as StockType,
		ISNULL(a.CKGiaoDich, 0) AS CKGD, 
		ISNULL(a.CKXuatChuaDuyet, 0) AS CKXCD, ISNULL(a.CKCamCo, 0) AS CKCC, 
		ISNULL(a.CKHanChe, 0) AS CKHC, ISNULL(a.CKOTC, 0) AS CKOTC, 
		ISNULL(a.CKDatLenhBan, 0) AS CKBan, 
		ISNULL(a.CKBanCHT,0) as CKBanCHT, 
		ISNULL(a.CKChuyenKhoan,0) as CKChuyenKhoan,
		a.Tong, ISNULL(a.CurrentPrice, 0) AS CurrentPrice, 
		a.Tong * ISNULL(a.CurrentPrice, 0) * 1000 as Amount,
		(ISNULL(a.CKGiaoDich, 0) + ISNULL(a.CKCamCo, 0) - ISNULL(a.CKDatLenhBan, 0)) AS CKKD,
		ISNULL(a.CKChoGiaoDich, 0) as CKCGD,
		ISNULL(a.CKLe,0) as CKLe,
		b.StockType as StockTypeOriginal,
		b.StockNameViet
	FROM @Stock a INNER JOIN GLStockCode b
		ON a.MaCK = b.StockCode
	ORDER BY a.MaCK
END
go

-- 2010.12.13: Vinhnt: sua query de lay dung gia tri khach hang can hach toan khi khach hang
ALTER PROCEDURE [dbo].[ClearingTrading_GetCustomer] 
	@OrderDate		varchar(10),
	@StockType		varchar(10),
	@BoardType		char(1),	
	@BranchCode		varchar(3),
	@OrderSide		char(1),
	@IsPrivate		bit,
	@NoPost			bit=1,
	@DayId			int,
	@ClearingCode	varchar(20)
	WITH ENCRYPTION
AS	
	DECLARE @StockFilter varchar(5)
	DECLARE @CurrentDayId int;
	SET @CurrentDayId = (SELECT [Id] FROM [ClearingDay] WHERE [ClearingCode]=@ClearingCode AND [DayIdBefore]=@DayId);

	SET @StockFilter = ''

	IF @StockType = 'S'
		SET @StockFilter = '[SU]'
	IF @StockType = 'D'
		SET @StockFilter = 'D'	
	DECLARE @Status char(1);
	SET @Status = dbo.TransDate_Status('', Convert(smalldatetime,@OrderDate,103));
	IF(@Status='Y')--Ðã k?t thúc ngày
	BEGIN
		SELECT [CustomerID]   [CustomerID],
			   SUM([MatchedValue]) [MatchedValue],
			   SUM([FeeValue])     [FeeValue]
		FROM (SELECT [CustomerID],
					 SUM([MatchedValue]) AS [MatchedValue],
					 ROUND(SUM([MatchedValue] * [FeeRate]), 0) AS [FeeValue]
			  FROM TradingResultHist
			  WHERE [OrderDate] = @OrderDate
					AND [StockType] LIKE @StockFilter
					AND [BoardType] = @BoardType
					AND (@BranchCode ='' OR[CustomerBranchCode] = @BranchCode)
					AND [OrderSide] = @OrderSide
					AND ((@NoPost ='0' AND [NoPost]    = '0') OR @NoPost='1')
					AND ((@IsPrivate = 0 AND NOT [CustomerID] LIKE '___P%') OR (@IsPrivate = 1 AND [CustomerID] LIKE '___P%'))
					AND ([DayId]=@DayId) -- OR ([BranchCode]<>'100' AND [DayId]=@CurrentDayId))
					AND [ClearingCode]=@ClearingCode
			  GROUP BY [OrderNo], [CustomerID]) AS [A]
		GROUP BY [CustomerID];
	END
	ELSE
	BEGIN
		SELECT [CustomerID]   [CustomerID],
			   SUM([MatchedValue]) [MatchedValue],
			   SUM([FeeValue])     [FeeValue]
		FROM (SELECT [CustomerID],
					 SUM([MatchedValue]) AS [MatchedValue],
					 ROUND(SUM([MatchedValue] * [FeeRate]), 0) AS [FeeValue]
			  FROM TradingResult
			  WHERE [OrderDate] = @OrderDate
					AND [StockType] LIKE @StockFilter
					AND [BoardType] = @BoardType
					AND (@BranchCode ='' OR[CustomerBranchCode] = @BranchCode)
					AND [OrderSide] = @OrderSide
					AND ((@NoPost ='0' AND [NoPost]    = '0') OR @NoPost='1')
					AND ((@IsPrivate = 0 AND NOT [CustomerID] LIKE '___P%') OR (@IsPrivate = 1 AND [CustomerID] LIKE '___P%'))
					AND ([DayId]=@DayId) -- OR ([BranchCode]<>'100' AND [DayId]=@CurrentDayId))
				    AND [ClearingCode]=@ClearingCode
			  GROUP BY [OrderNo], [CustomerID]) AS [A]
		GROUP BY [CustomerID];
	END
go

-- Vinh: 5-1-2011
BEGIN TRANSACTION
GO
EXECUTE sp_rename N'dbo.vrm_Contract.Amount', N'Tmp_RegisteredAmount', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.vrm_Contract.Tmp_RegisteredAmount', N'RegisteredAmount', 'COLUMN' 
GO
ALTER TABLE dbo.vrm_Contract ADD
	InterestRatePerDay decimal(4, 4) NULL,
	InterestRatePenalty decimal(4, 4) null,
	DisbursedAmount money NULL,
	ApprovalAmount money NULL,
	WithdrawAmount money null
GO
commit
GO
update [dbo].[vrm_Contract] set  InterestRatePerDay = 0.06, InterestRatePenalty = 0.065, ApprovalAmount = RegisteredAmount  where [ContractType] = 0 and [Status] = 2
update [dbo].[vrm_Contract] set ApprovalAmount = RegisteredAmount, DisbursedAmount = RegisteredAmount where [ContractType] = 0 and [Status] = 3
update [dbo].[vrm_Contract] set ApprovalAmount = RegisteredAmount, DisbursedAmount = RegisteredAmount, WithdrawAmount = RegisteredAmount where [ContractType] = 0 and [Status] = 4
go
CREATE TABLE [dbo].[vrm_Contract_Transaction](
	[ContractId] int not null,
	[TransactionDay] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](20) NOT NULL,
	[Amount] [decimal](18, 0) NULL,
	[TransactionCode] [varchar](2) null,
	[TransactionNumber] [varchar](12) null,
	Notes nchar(500) null,
	IsDeleted bit NULL
) ON [PRIMARY]
go	
ALTER TABLE dbo.vrm_Contract_Transaction ADD CONSTRAINT
	DF_vrm_Contract_Transaction_IsDelete DEFAULT 0 FOR IsDeleted
go
CREATE CLUSTERED INDEX [vrm_Contract_Transaction_TransactionDay] ON [dbo].[vrm_Contract_Transaction] 
(
	[TransactionDay] DESC
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [vrm_Contract_Transaction_ContractID] ON [dbo].[vrm_Contract_Transaction] 
(
	[ContractId] ASC
) ON [PRIMARY]
GO


-- Ngay 01/06 Chang function fc_GetTDate lay numberofday cho chu ky hoach toan t+2
USE [VICS30]
GO
/****** Object:  UserDefinedFunction [dbo].[fc_GetTDate]    Script Date: 1/1/2016 9:39:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		TriDM
-- Create date: 20070908
-- Description:	Thuc hien lay ngay giao dich truoc hoac sau ngay transactionDate
-- 20080512 TriDM: sua cach tinh ngay lam viec
-- =============================================
ALTER FUNCTION [dbo].[fc_GetTDate] 
(
	@BranchCode varchar(3)= null, -- ma chi nhanh (neu =null thi tra ve KQ TDate null)	
	@TransactionDate smalldatetime = NULL, -- gia tri ngay giao dich dua vao
	@GetFutureDate bit = 1, -- Co lay gia tri ngay tiep theo hay khong, neu =1 thi lay theo T + NumberOfDay, neu =0 thi lay theo T - NumberOfDay
	@NumberOfDay int = 2 -- so ngay tiep theo hoac so ngay qua khu (mac dinh la 2, lay ngay T+2)
)
RETURNS smalldatetime
 
AS
BEGIN
-- Doi gia tri ngay @NumberOfDay= 2 cho chu ky hoach toan T2 ke tu ngay 01/06/2016 (SBS hashcode =3)
	IF(@TransactionDate>'2016-01-01' and @NumberOfDay=3)
	set @NumberOfDay=2
	DECLARE @NoTrans int, @Count int, @TDate smalldatetime

	SET @Count = 0

	-- Kiem tra xem ngay giao dich bi null hay khong? 
	IF @TransactionDate IS NULL
	BEGIN
		-- xet @BranchCode co null hay khong de gan ngay giao dich la null hay Ngay giao dich hien tai cua chi nhanh
		if @BranchCode is null
		Begin
			return null			
		End
		else
		begin
			SET @TransactionDate = (SELECT dbo.CurrentTransDate(@BranchCode))
		end
	END

	SET @TDate = @TransactionDate
    -- Thien bo sung them doan nay de tim 
	-- neu so ngay = 0 thi
    IF(@NumberOfDay = 0)
      BEGIN
       WHILE  (SELECT COUNT(*) FROM [NoTransDate]
					WHERE CONVERT(varchar(10), [NoTransDate], 103)
						= CONVERT(varchar(10), @TDate, 103))!=0
         BEGIN
			-- neu lay ngay tuong lai thi cong, con lai thi tru
			if @GetFutureDate=1
			Begin
				SET @TDate = @TDate + 1
			end
			else
			begin
				SET @TDate = @TDate -1
			end
         END
	  END
    ELSE

     -- ngay giao dich gan voi ngay @TradingDate nhat neu no khong phai la ngay giao dich
     -- hoac tra ve chinh ngay @TrandingDate neu no la ngay giao dich
     
     BEGIN
       WHILE @Count < @NumberOfDay    
	     BEGIN

		   if @GetFutureDate=1
			Begin
				SET @TDate = @TDate + 1
			end
			else
			begin
				SET @TDate = @TDate -1
			end

		   SET @NoTrans = (SELECT COUNT(*) FROM [NoTransDate]
					  WHERE CONVERT(varchar(10), [NoTransDate], 103)
						= CONVERT(varchar(10), @TDate, 103))
		
		   SET @NoTrans = ISNULL(@NoTrans, 0)
		   IF @NoTrans = 0
			   SET @Count = @Count + 1
	       END
    END

	RETURN @TDate

END

