
DECLARE @freT3 SMALLDATETIME
SET @freT3 = dbo.TransDateMinus(CAST('2010-01-12 00:00:00' AS DATETIME),3,0)
select 
c.customerid, c.customernameviet,
b.currentbalance, 
isnull(s.currentstock, 0) as ckhientai, isnull(s.pendingstock, 0) as ckmuachove, isnull(s.sellingstock,0) as tienbanckchove
,vc.duedate, vc.ExpiredDate, notronghan, noquahan,tienbanungtruoc,tienmuachuahachtoan
from customers c
join vrm_customer v on c.customerid = v.customerid
join vrm_contract vc on c.customerid = vc.customerid
-- so du hien tai
left join balance b on c.customerid = b.accountid and b.bankgl = '324111'
-- chung khoan: hien tai, cho ve
left join 
(
	select tp.accountid, SUM(price * quantity) as currentstock, SUM(price * buyquantity) as pendingstock, SUM(sell) as sellingstock
	from
	(	select scur.accountid, scur.stockcode, sum(scur.quantity) as quantity, sum(scur.buyquantity) as buyquantity, SUM(sell) as sell
		from (select s.accountid, s.stockcode, s.quantity, buyquantity,  sell
			  from securities s 
			  left join (select customerid, stockcode, case when orderside = 's' then sum(matchedvolume * matchedprice) end as sell, case when orderside = 'b' then sum(matchedvolume) end as buyquantity
				         from tradingresult group by customerid, stockcode, orderside) t
			  on s.accountid = t.customerid and s.stockcode = t.stockcode
			  where s.bankgl = '012121' -- so du hien tai con '012521' cho xuat
			  union all 
			  select customerid, stockcode, 0, case when orderside = 'b' then sum(matchedvolume) end as buyquantity, case when orderside = 's' then sum(matchedvolume * matchedprice) end as sell
					from tradingresulthist where transactiondate >= @freT3  group by customerid, stockcode, OrderSide
		) scur group by accountid, stockcode
	) tp
	join 
	(	select vs.stockcode, case when cellingfixedprice < price then cellingfixedprice else price end * valuerate /100 as price 
		from vrm_stock vs
		join (select stockcode, case boardtype when 'S' then averageprice else case closeprice when 0 then basicprice else closeprice end end as price 
			  from stockprice ) x on vs.stockcode = x.stockcode
		where vs.branchcode = '200'
	) sp on tp.stockcode = sp.stockcode GROUP BY tp.AccountId
) s on c.customerid = s.accountid
-- no
left join
(
	select x.customerid, 
		sum(case when getdate() <= expireddate then case when x.contracttype = 1 and x.status = 2 then currentdebit else amount end end) as notronghan,
		sum(case when getdate() > expireddate then case when x.contracttype = 1 and x.status = 2 then currentdebit else amount end end) as noquahan
	from vrm_contract x left join deferredbalance b on x.customerid = b.customerid
	where x.status in (2,3)
	group by x.customerid
) d1 on c.customerid  = d1.customerid

--- TIEN UNG TRUOC ---
left JOIN(
	select customerid, sum(advanceamount + advancefee) as tienbanungtruoc
	FROM
	(
		SELECT customerid, advanceamount, advancefee FROM BuyCashContract WHERE Status = 'T'
		union
		SELECT customerid, advanceamount, advancefee FROM advancecontractall WHERE Status = 'T'
	)x 
	group by customerid
) ung on c.customerid = ung.customerid

-- SO TIEN MUA CHUNG KHOAN CHUA DUOC HACH TOAN ---
left join(
	select customerid, sum(matchedvalue + feerate*matchedvalue) as tienmuachuahachtoan
	from tradingresult where orderside = 'B' and dayid = 0
	group by customerid
) nab on c.customerid = nab.customerid