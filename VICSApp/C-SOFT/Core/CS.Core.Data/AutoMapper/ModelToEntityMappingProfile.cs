using AutoMapper;
using CS.Common.Contract.Models;
using CS.Common.Contract.VsdModels;
using CS.Domain.Data.Entities;

namespace CS.Domain.Data.AutoMapper
{
    public class ModelToEntityMappingProfile : Profile
    {
        public ModelToEntityMappingProfile()
        {
            CreateMap<BranchModel, Branch>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Parent, opt => opt.Ignore())
                .ForMember(x => x.ParentId, opt => opt.MapFrom(s => s.Parent.Id))
                .ForMember(x => x.Children, opt => opt.Ignore())
                .ForMember(x => x.Users, opt => opt.Ignore())
                .ForMember(x => x.Settings, opt => opt.Ignore());
            CreateMap<BranchSettingModel, BranchSetting>();

            CreateMap<GroupModel, Group>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Parent, opt => opt.Ignore())
                .ForMember(x => x.ParentId, opt => opt.MapFrom(s => s.Parent.Id))
                .ForMember(x => x.Branch, opt => opt.Ignore())
                .ForMember(x => x.BranchId, opt => opt.MapFrom(s => s.Branch.Id));

            CreateMap<DepartmentModel, Department>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Branch, opt => opt.Ignore())
                .ForMember(x => x.BranchId, opt => opt.MapFrom(s => s.Branch.Id));

            CreateMap<CustomerModel, Customer>()
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.ModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.Branch, opt => opt.Ignore())
                .ForMember(x => x.ModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Broker, opt => opt.Ignore())
                .ForMember(x => x.BrokerId, opt => opt.MapFrom(s => s.Broker.Id));

            CreateMap<UserModel, User>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.CreatedByUserId, opt => opt.MapFrom(s => s.CreatedBy.Id))
                .ForMember(x => x.ModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.ModifiedByUserId, opt => opt.MapFrom(s => s.ModifiedBy.Id))
                .ForMember(x => x.Branch, opt => opt.Ignore())
                .ForMember(x => x.BranchId, opt => opt.MapFrom(s => s.Branch.Id))
                .ForMember(x => x.Groups, opt => opt.Ignore())
                .ForMember(x => x.Department, opt => opt.Ignore())   
                .ForMember(x => x.DepartmentId, opt => opt.MapFrom(s => s.Department.Id));   

            CreateMap<ContactModel, Contact>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Customer, opt => opt.Ignore());
            //
            CreateMap<AccountModel, Account>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.AccountBalances, opt => opt.Ignore())
                .ForMember(x => x.Asset, opt => opt.Ignore())
                .ForMember(x => x.Settlements, opt => opt.Ignore());

            CreateMap<AssetModel, Asset>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<AccountBalanceModel, AccountBalance>()
                .ForMember(x => x.Account, opt => opt.Ignore());

            CreateMap<AccountTransactionModel, AccountTransaction>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Source, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.ApproveBy, opt => opt.Ignore());

            CreateMap<SettlementModel, BusinessAccountSetting>()
                .ForMember(x => x.Account, opt => opt.Ignore())
                .ForMember(x => x.BusinessUnit, opt => opt.Ignore());

            CreateMap<BusinessUnitModel, BusinessUnit>()
                .ForMember(x => x.Settlements, opt => opt.Ignore());

            CreateMap<SourceModel, Source>()
                .ForMember(x => x.AccountTransactions, opt => opt.Ignore());   
             

            CreateMap<StockPriceModel, StockPrice>();
            CreateMap<RightInformationModel, RightInformation>()
            .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<CustodyRequestModel, CustodyRequest>()
			.ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<BankModel, Bank>()
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<ExchangeStockModel, ExchangeStock>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<FileActModel, FileAct>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}