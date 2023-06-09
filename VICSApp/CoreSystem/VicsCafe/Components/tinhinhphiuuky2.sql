
ALTER TABLE [dbo].[vrm_SecurityFeeLog] DROP CONSTRAINT [FK_vrm_SecurityFeeLog_vrm_CustomerSecurityFee]
GO
/****** Object:  Table [dbo].[vrm_SecurityFeeLog]    Script Date: 12/29/2015 5:35:49 PM ******/
DROP TABLE [dbo].[vrm_SecurityFeeLog]
GO
/****** Object:  Table [dbo].[vrm_CustomerSecurityFee]    Script Date: 12/29/2015 5:35:49 PM ******/
DROP TABLE [dbo].[vrm_CustomerSecurityFee]
GO
/****** Object:  UserDefinedFunction [dbo].[fc_GetMinDate]    Script Date: 12/29/2015 5:35:49 PM ******/
DROP FUNCTION [dbo].[fc_GetMinDate]
GO
/****** Object:  StoredProcedure [dbo].[vrm_SummaryCustody]    Script Date: 12/29/2015 5:35:49 PM ******/
DROP PROCEDURE [dbo].[vrm_SummaryCustody]
GO
/****** Object:  StoredProcedure [dbo].[Vrm_GetCustomerSecurityFeeDetails]    Script Date: 12/29/2015 5:35:49 PM ******/
DROP PROCEDURE [dbo].[Vrm_GetCustomerSecurityFeeDetails]
GO
/****** Object:  StoredProcedure [dbo].[Vrm_GetCustomerSecurityFeeDetails]    Script Date: 12/29/2015 5:35:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Vrm_GetCustomerSecurityFeeDetails]
 @CallDate datetime,
 @BranchCode varchar(3)='100',
 @FeeRate decimal(4,2)= 0.4 ,
 @AccountId varchar(10)='', 
 @isSellT3 bit=1
as
begin 
 SET NOCOUNT ON;

-- Không tính phí ngày giao dịch hien tại
declare @currenttransdate as datetime  
declare @minDate as  datetime,  @CurrentDate as datetime
set  @minDate ='2016-01-01'
set @CurrentDate =getdate()
set @currenttransdate=(select top 1 currenttransdate from [transdate] where branchcode=@BranchCode)
if (@currenttransdate <= @CallDate)
Begin
	RAISERROR (N'Ngày tính phí phải nhỏ hơn ngày giao dịch hiện tại', 15, 1);		
	return;
End

-- Ma chi nhanh khong duoc de trong
if @BranchCode = ''
Begin
	RAISERROR (N'Mã chi nhánh không được để trống', 15, 1);	
	return	
End
 --Ma chi nhanh khong duoc de trong
if @feeRate = 0
Begin
	RAISERROR (N'Phí lưu ký chưa thiết lập hoặc phí phải lơn hơn 0', 15, 1);	
	return	
End

if(@AccountId<>'')
	begin
	 
		if(LEN(@AccountId)<>10 or (not exists(select 1 from Customers where CustomerId=@AccountId)))
		begin
			RAISERROR (N'Tài khoản %s không tồn tại trong hệ thống. Vui lòng chọn lại.', 15, 1,@AccountId);	
			return	
		end
declare @minDateExist datetime
	set @minDateExist =(select Max(FeeDate) from vrm_CustomerSecurityFee where IsLasted = 1 and FeeDate <= @CallDate and AccountId= @AccountId)

		if(@minDateExist >=@CallDate)
		Begin 
			declare @StartDateText varchar(10)
			set @StartDateText = Convert(varchar(10), @minDateExist, 103)
			RAISERROR (N'Hệ thống đã tính phí cho tài khoản %s đến ngày %s. Vui lòng chọn ngày lớn hơn', 15, 1,@AccountId,@StartDateText);	
			return	
		End
 	end 
-- delete phi chua hoach toan 
delete vrm_SecurityFeeLog where BranchCode=@BranchCode and (@AccountId='' or CustomerId = @AccountId) and AccountRef is null --and CallDate<=@CallDate

declare @dateT3 as datetime
set @dateT3= dbo.fc_GetTDate(@BranchCode,@currenttransdate,0,3)  
	;with #c(customerid,FeeDate, transdate, stockcode,quantity,bankgl)
	as
	(
		select c.CustomerId,isnull(f.FeeDate, @minDate) as FeeDate ,s.TransactionDate, s.StockCode, s.Quantity, s.BankGl from Customers c 
		   left join vrm_CustomerSecurityFee f on c.CustomerId = f.AccountId and f.IsLasted = 1 and f.BranchCode=@BranchCode
		   join SecuritiesHist s on c.CustomerId = s.AccountId and s.TransactionDate <= @CallDate
		where isnull(s.TransactionDate, @CallDate) > isnull(f.FeeDate, @minDate) and isnull(f.FeeDate, @mindate) <= @CallDate
			and (@AccountId='' or c.CustomerId = @AccountId)
			and (@isSellT3= 0 or exists(select top 1 CustomerId from TradingResultHist 
										 where CustomerId = f.AccountId and DayId=2 
											   and OrderSide='S'
										       and TransactionDate =@dateT3)) 
			and c.CustomerId not in ('076P000001')
	)

	insert into vrm_SecurityFeeLog(CustomerId,StockCode,Quantity,FeeRate,DayCount,FeeAmount,BranchCode,CallDate,transactiondate,BeginDate,EndDate)
	select customerid, stockCode, quantity , @FeeRate as FeeRate, dayCount as dayCount,
	Ceiling(sum((dayCount * @FeeRate /30.0) * Quantity) ) as FeeAmount,
	 @BranchCode as BranchCode,@CallDate as CallDate,@CurrentDate as TransactionDate,BeginDate,EndDate
	from
	(
		 --tai khoan ghi co chung khoan liet ke hang ngay
		 select customerid, dbo.fc_GetMinDate(min(transdate),FeeDate) as BeginDate,max(transdate) as EndDate,
		 DATEPART(DAYOFYEAR, max(transdate) -dbo.fc_GetMinDate(min(transdate),FeeDate)) as dayCount
		 , stockCode, quantity, bankgl
		from #c where bankgl in ('012111','012112','012121','012131','012221','012421','012431')
		group by customerid,FeeDate, StockCode, Quantity, BankGl
		union all
		---- tai khoan cho thanh toan bu tru dua vao ngay thanh toan
		 select customerid, dbo.fc_GetMinDate(min(transdate),FeeDate) as beginDate,max(transdate) as endDate,
		 DATEPART(DAYOFYEAR, max(transdate) -dbo.fc_GetMinDate(min(transdate),FeeDate)) as dayCount
		 , stockCode, quantity, bankgl
		from #c where bankgl in ('012122','012511','012521') 
		group by customerid,FeeDate, StockCode, Quantity, BankGl
	) x
	group by customerid, stockcode,quantity,dayCount,BeginDate,EndDate
	order by customerid, stockcode,dayCount
 

select s.id as Id,s.CustomerId,b.AccountName as CustomerName, s.StockCode,s.Quantity,s.FeeRate,s.FeeAmount,s.DayCount,s.CallDate, s.BranchCode, b.CurrentBalance,s.BeginDate,s.EndDate
from vrm_SecurityFeeLog s join Balance b on s.CustomerId= b.AccountId and s.BranchCode=b.BranchCode and b.CurrentBalance > 0  and b.bankgl='324111'
where (@AccountId='' or s.CustomerId = @AccountId) and s.CallDate=@CallDate and s.AccountRef is null
order by CustomerId,s.StockCode,s.Quantity,s.DayCount

end

GO
/****** Object:  StoredProcedure [dbo].[vrm_SummaryCustody]    Script Date: 12/29/2015 5:35:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[vrm_SummaryCustody]
@fromdate as datetime,
@toDate as datetime
as
begin 

declare @datebeforefromdate datetime, @dateaftertodate datetime
set @datebeforefromdate = (select max(transactiondate) from securitieshist where transactiondate <= @fromdate)
set @dateaftertodate = (select isnull(min(transactiondate),@toDate) from securitieshist where transactiondate >= @toDate)

--select @fromDate, @toDate, @datebeforefromdate, @dateaftertodate

declare  @alldates table ([date] smalldatetime);
with alldays(monthdate) AS 
(
  select @fromDate
  union ALL
  select DATEADD(d, 1, monthdate) from alldays where DATEADD(d, 1, monthdate) <= @toDate
)
insert into @alldates select * from alldays;

;with #balance(transactiondate, accountid, accountname, quantity, branchcode, BankGl)
as 
(
	select transactiondate, accountid, accountname, quantity, BranchCode, BankGl
	from SecuritiesHist
	where transactiondate between @datebeforefromdate and @dateaftertodate-- and accountid = '076C001972'
	and BankGl in (
			'012111',
			'012112',
			'012121',
			'012131',
			'012221',
			'012421',
			'012431'
			)
)
select BankGl, sum(quantity) as Total
from 
(
select branchcode, transactiondate, accountid, accountname, quantity, BankGl
from @alldates, #balance
where transactiondate = (select min(transactiondate) from #balance where transactiondate >= date)
) t
group by BankGl
union all
-- chung khoan cho thanh toan bu tru
select BankGl, sum(q) as Total
from (
select bankgl, Quantity * datepart(dayofyear, max(transactiondate) -  min(transactiondate)) as q
	from SecuritiesHist
	where transactiondate between @fromDate and @todate --and accountid = '076C058338'
	and BankGl in (
			'012122',
			'012511',
			'012521'
			)
			group by Quantity, BankGl, StockCode,id
			) t group by BankGl
			--order by TransactionDate
order by BankGl

end

GO
/****** Object:  UserDefinedFunction [dbo].[fc_GetMinDate]    Script Date: 12/29/2015 5:35:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fc_GetMinDate](@trandate datetime, @FeeDate datetime)
RETURNS SMALLDATETIME AS  
BEGIN 
declare @minDate as  datetime, @daycount as int, @dw int
set @dw=datepart(dw,@FeeDate)
set @daycount=DATEPART(DAYOFYEAR, @trandate- @FeeDate)
	 if((@dw in (1,7) and @daycount<=3 ) or (@dw = 6 and @daycount = 4))
	 set @minDate=DateAdd(day,1,@FeeDate)
	 else
	 set @minDate=@trandate
	 return @minDate
END


GO
/****** Object:  Table [dbo].[vrm_CustomerSecurityFee]    Script Date: 12/29/2015 5:35:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[vrm_CustomerSecurityFee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [varchar](10) NOT NULL,
	[FeeAmount] [decimal](18, 0) NOT NULL,
	[FeeDate] [smalldatetime] NOT NULL,
	[Status] [varchar](1) NOT NULL,
	[IsLasted] [bit] NOT NULL,
	[CreatedBy] [varchar](40) NOT NULL,
	[BranchCode] [varchar](3) NOT NULL,
	[TradeCode] [varchar](30) NOT NULL,
	[TransactionDate] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_vrm_CustomerSecurityFee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[vrm_SecurityFeeLog]    Script Date: 12/29/2015 5:35:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[vrm_SecurityFeeLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [varchar](10) NOT NULL,
	[StockCode] [varchar](10) NOT NULL,
	[Quantity] [int] NOT NULL,
	[FeeRate] [decimal](4, 4) NOT NULL,
	[FeeAmount] [decimal](18, 4) NOT NULL,
	[DayCount] [int] NOT NULL,
	[CallDate] [smalldatetime] NOT NULL,
	[TransactionDate] [smalldatetime] NOT NULL,
	[BranchCode] [varchar](3) NOT NULL,
	[AccountRef] [varchar](50) NULL,
	[CustomerSecurityFeeId] [int] NULL,
	[BeginDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
 CONSTRAINT [PK_vrm_SecurityFeeLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[vrm_SecurityFeeLog]  WITH CHECK ADD  CONSTRAINT [FK_vrm_SecurityFeeLog_vrm_CustomerSecurityFee] FOREIGN KEY([CustomerSecurityFeeId])
REFERENCES [dbo].[vrm_CustomerSecurityFee] ([Id])
GO
ALTER TABLE [dbo].[vrm_SecurityFeeLog] CHECK CONSTRAINT [FK_vrm_SecurityFeeLog_vrm_CustomerSecurityFee]
GO
