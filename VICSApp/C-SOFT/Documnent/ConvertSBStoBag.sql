-- insert branch
select * from Branch
insert into Branch(BranchCode,BranchName,Address,Tel,Fax, BankAccount, BankName, BankLocation)
select * from  [10.10.5.230].SBSTEST3.dbo.Branch
update Branch set BranchMaster=1 where Id<>1
-- insert group 
SET IDENTITY_INSERT [dbo].UserGroups ON 
insert into UserGroups(Id,GroupName)
select GroupId, GroupName from [10.10.5.230].SBSTEST3.dbo.UserGroups 
SET IDENTITY_INSERT [dbo].UserGroups OFF 
-- insert user tu user sbs
insert into Users(Id, UserName, Password, FullName, GroupId,Status,BranchId)
select NEWID(),UserName,Password, FullName,GroupId,1, case BranchCode when '200' then 2 else 1 end from [10.10.5.230].SBSTEST3.dbo.Users where Status<>'C'
select * from Users where UserName='hueadmin'

-- insert user tu Customer sbs 
insert into Users(Id, UserName, Password, Email, FullName, GroupId,Status,BranchId)
select   * from Users
select NEWID(),CustomerId,'D8F4B00530E38C5A90ECF8384EE1B02C', email, CustomerName,3,1, case BranchCode when '200' then 2 else 1 end 
from [10.10.5.230].SBSTEST3.dbo.Customers where AccountStatus<>'C'


-- insert Customer tu Customer sbs 
insert into Customers(Id, CustomerNumber, FullName, FullNameVn,Type,BirthDay,Genere, IsActivate,CreatedDate,CardType,CardIdentity,CardDate,CardIssuer, SignatureImage2, SignatureImage1,TaxCode)
 
select  u.Id, CustomerId,CustomerName,CustomerNameViet,
case 
when CustomerType='I' and DomesticForeign='D' then 0
when CustomerType='E' and DomesticForeign='D' then 1
when CustomerType='I' and DomesticForeign='F' then 2 
when CustomerType='E' and DomesticForeign='F' then 3
end as CustomerType ,  Dob,
case Sex
when 'M' then 1
when 'F' then 2
else  0  
end as Genere,1 as IsActivate, CAST(OpenDate as datetime),CardType,CardIdentity,CAST(CardDate as datetime),CardIssuer, SignatureImage1, SignatureImage2,TaxCode

from Users u join  [10.10.5.230].SBSTEST3.dbo.Customers c on u.UserName= c.CustomerId where c.AccountStatus<>'C'


-- insert Contacts Customer tu Customer sbs 
