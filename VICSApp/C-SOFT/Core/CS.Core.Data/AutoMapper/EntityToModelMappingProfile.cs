using System.Linq;
using AutoMapper;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using CS.Common.Contract.VsdModels;
using CS.Common.Std.Extensions;
using CS.Domain.Data.Entities;

namespace CS.Domain.Data.AutoMapper
{
    public class EntityToModelMappingProfile : Profile
    {
        public EntityToModelMappingProfile()
        {
            CreateMap<Branch, BranchModel>();
            CreateMap<BranchSetting, BranchSettingModel>();

            CreateMap<Group, GroupModel>();
            CreateMap<Group, GroupMemberModel>()
                .ForMember(d => d.MemberType, opt => opt.MapFrom(s => MemberType.Group))
                .ForMember(d => d.FullName, opt => opt.MapFrom(s => s.Name));

            CreateMap<Department, DepartmentModel>();
            CreateMap<Customer, CustomerModel>();
            
            CreateMap<User, UserModel>();

            CreateMap<User, GroupMemberModel>()
                .ForMember(d => d.MemberType, opt => opt.MapFrom(s => MemberType.User));

            CreateMap<UserGroup, GroupModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.GroupId));
            CreateMap<UserGroup, UserModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.UserId));

            CreateMap<Contact, ContactModel>();
            //
            CreateMap<Account, AccountModel>();

            CreateMap<Asset, AssetModel>();

            CreateMap<AccountBalance, AccountBalanceModel>();

            CreateMap<AccountTransaction, AccountTransactionModel>();

            CreateMap<BusinessAccountSetting, SettlementModel>();

            CreateMap<BusinessUnit, BusinessUnitModel>();

            CreateMap<Source, SourceModel>();

            CreateMap<StockPrice, StockPriceModel>();
            CreateMap<CustodyRequest, CustodyRequestModel>();
            CreateMap<RightInformation, RightInformationModel>();
            CreateMap<Bank, BankModel>();
            CreateMap<ExchangeStock, ExchangeStockModel>();
            CreateMap<FileAct, FileActModel>();
            CreateMap<Permission, PermissionAccess>();

            //            CreateMap<AccessRight, AccessRightModel>()
            //                .ForMember(d => d.Name, o => o.MapFrom(s => s.AccessName.AsEnum<AccessPermission>()));
        }
    }
}