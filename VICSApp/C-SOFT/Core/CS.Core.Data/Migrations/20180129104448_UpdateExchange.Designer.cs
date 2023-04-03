﻿// <auto-generated />
using CS.Common.Contract.Enums;
using CS.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CS.Domain.Data.Migrations
{
    [DbContext(typeof(CSoftDataContext))]
    [Migration("20180129104448_UpdateExchange")]
    partial class UpdateExchange
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CS.Domain.Data.Entities.Account", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AssetId");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<byte>("Status");

                    b.Property<byte>("Type");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.HasIndex("AssetId");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.AccountBalance", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AccountId");

                    b.Property<decimal>("Available")
                        .HasColumnType("decimal");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal");

                    b.Property<decimal?>("Block")
                        .HasColumnType("decimal");

                    b.Property<Guid>("CustomerAccountId");

                    b.Property<DateTime>("LastBalancedDate");

                    b.Property<int>("Version");

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("AccountId");

                    b.HasIndex("CustomerAccountId");

                    b.HasIndex("LastBalancedDate")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("AccountBalance");
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.AccountBlockTransaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AccountBlanceId");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Note")
                        .HasMaxLength(50);

                    b.Property<string>("ReferenceCode")
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("AccountBlanceId");

                    b.ToTable("AccountBlockTransaction");
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.AccountTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AcountBalanceId");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal");

                    b.Property<Guid?>("ApproveById");

                    b.Property<Guid?>("CreatedById");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("ReferenceCode")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<long?>("SourceId");

                    b.Property<byte>("Status");

                    b.Property<DateTime>("TransactionDate");

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("AcountBalanceId");

                    b.HasIndex("ApproveById");

                    b.HasIndex("CreatedById");

                    b.HasIndex("SourceId");

                    b.HasIndex("TransactionDate")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("AccountTransaction");
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.Asset", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BoardName")
                        .HasMaxLength(30);

                    b.Property<byte>("BoardType");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(35)")
                        .HasMaxLength(35);

                    b.Property<string>("CountryCode")
                        .HasColumnType("varchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("Fax");

                    b.Property<decimal>("ForginRate")
                        .HasColumnType("decimal");

                    b.Property<bool>("IsActive");

                    b.Property<string>("IsinCode")
                        .HasColumnType("varchar(12)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(350);

                    b.Property<string>("NameLocal")
                        .HasMaxLength(350);

                    b.Property<decimal>("ParValue")
                        .HasColumnType("decimal");

                    b.Property<string>("Phone");

                    b.Property<decimal>("Rational")
                        .HasColumnType("decimal");

                    b.Property<byte>("SubType");

                    b.Property<decimal>("TotalIssue")
                        .HasColumnType("decimal");

                    b.Property<DateTime?>("TradeDate");

                    b.Property<byte>("Type");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.Bank", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BankCode")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<string>("BankPlRlCode")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("FullName")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.Branch", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(200);

                    b.Property<string>("BranchCode")
                        .IsRequired()
                        .HasColumnType("varchar(3)");

                    b.Property<string>("BranchName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("CustomerAccountCurrent");

                    b.Property<int>("CustomerAccountFrom");

                    b.Property<int>("CustomerAccountTo");

                    b.Property<string>("Fax")
                        .HasColumnType("varchar(15)");

                    b.Property<long?>("ParentId");

                    b.Property<string>("Tel")
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("BranchCode")
                        .IsUnique();

                    b.HasIndex("ParentId");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.BusinessAccountSetting", b =>
                {
                    b.Property<long>("AccountId");

                    b.Property<long>("BusinessId");

                    b.Property<byte>("Type");

                    b.Property<string>("XmlSetting");

                    b.HasKey("AccountId", "BusinessId");

                    b.HasIndex("BusinessId");

                    b.ToTable("BusinessAccountSetting");
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.BusinessUnit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<byte>("Type");

                    b.HasKey("Id");

                    b.ToTable("BusinessUnits");
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.Contact", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CustomerId");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<bool>("IsDefault");

                    b.Property<byte>("Type");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.CustodyRequest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BusinessId")
                        .HasMaxLength(125);

                    b.Property<string>("Content");

                    b.Property<string>("ContentClrType");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Notes");

                    b.Property<byte>("Priority");

                    b.Property<byte>("RequestType");

                    b.Property<byte>("Status");

                    b.Property<string>("VsdBicCode")
                        .HasMaxLength(8);

                    b.HasKey("Id");

                    b.ToTable("CustodyRequests");
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountLogin")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(65);

                    b.Property<DateTime?>("BirthDay");

                    b.Property<long>("BranchId");

                    b.Property<Guid?>("BrokerId");

                    b.Property<string>("CardIdentity")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("CardIssuedDate");

                    b.Property<string>("CardIssuer")
                        .IsRequired()
                        .HasMaxLength(65);

                    b.Property<byte>("CardType");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(35);

                    b.Property<string>("CountryCode")
                        .HasMaxLength(2);

                    b.Property<Guid?>("CreatedByUserId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CustomerNumber")
                        .HasColumnType("varchar(10)");

                    b.Property<Guid?>("DelegatedCustomerId");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(140);

                    b.Property<string>("FullNameLocal")
                        .IsRequired()
                        .HasMaxLength(140);

                    b.Property<byte>("Genere");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LanguageCode")
                        .HasMaxLength(2);

                    b.Property<byte>("Level");

                    b.Property<Guid?>("ModifiedByUserId");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("NationalityCode")
                        .HasMaxLength(2);

                    b.Property<string>("Notes")
                        .HasMaxLength(350);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("PinCode")
                        .HasColumnType("varchar(max)");

                    b.Property<byte[]>("SignatureImage1");

                    b.Property<byte[]>("SignatureImage2");

                    b.Property<byte>("Status");

                    b.Property<string>("TaxCode")
                        .HasMaxLength(50);

                    b.Property<byte>("Type");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("BrokerId");

                    b.HasIndex("CardIdentity");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("CustomerNumber")
                        .IsUnique()
                        .HasFilter("[CustomerNumber] IS NOT NULL");

                    b.HasIndex("DelegatedCustomerId");

                    b.HasIndex("ModifiedByUserId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.CustomerAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("ContractNumber")
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<Guid>("CreatedByBrockerId");

                    b.Property<Guid>("CustomerId");

                    b.Property<DateTime?>("ExpiredDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive");

                    b.Property<byte>("Type");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByBrockerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerAccounts");
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.Department", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("BranchId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.ExchangeStock", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte>("BoardType");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("VsdBoardCode")
                        .IsRequired()
                        .HasColumnType("varchar(4)");

                    b.HasKey("Id");

                    b.HasIndex("BoardType")
                        .IsUnique();

                    b.HasIndex("VsdBoardCode")
                        .IsUnique();

                    b.ToTable("ExchangeStocks");
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.FileAct", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BusinessId")
                        .HasMaxLength(256);

                    b.Property<string>("DeliveryTime")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("FileDescription")
                        .HasMaxLength(600);

                    b.Property<string>("FileInfo")
                        .HasMaxLength(600);

                    b.Property<string>("LogicalName")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("OrigTransferRef")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("ReportCode")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<byte>("ReportStatus");

                    b.Property<byte>("ReportType");

                    b.Property<string>("RequestRef")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("SwiftTime")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("TransferDescription")
                        .HasMaxLength(300);

                    b.Property<string>("TransferInfo")
                        .HasMaxLength(256);

                    b.Property<string>("TransferRef")
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("FileActs");
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("BranchId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<Guid?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("ParentId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.Permission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedById");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<Guid>("GroupId");

                    b.Property<int>("Name");

                    b.Property<byte>("Type");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("GroupId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.RightInformation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountType")
                        .HasColumnType("varchar(4)");

                    b.Property<byte>("ActivityType");

                    b.Property<long>("Amount");

                    b.Property<string>("BalanceElig")
                        .HasColumnType("varchar(4)");

                    b.Property<string>("BalanceOptionFlag")
                        .HasColumnType("varchar(1)");

                    b.Property<string>("BalanceUnit")
                        .HasColumnType("varchar(4)");

                    b.Property<DateTime?>("ClosingBalanceDate");

                    b.Property<DateTime?>("CompulsoryPurchaseFrom");

                    b.Property<DateTime?>("CompulsoryPurchaseTo");

                    b.Property<string>("CountryCode")
                        .HasColumnType("varchar(2)");

                    b.Property<string>("CurrencyCode")
                        .HasColumnType("varchar(3)");

                    b.Property<DateTime?>("DeadlinePassOwnershipList");

                    b.Property<DateTime?>("DeadlinePayment");

                    b.Property<string>("DefaultProcessingFlag")
                        .HasColumnType("varchar(1)");

                    b.Property<decimal>("Denominations");

                    b.Property<string>("Description")
                        .HasMaxLength(350);

                    b.Property<DateTime?>("EffectiveDate");

                    b.Property<DateTime?>("ExecutionDate");

                    b.Property<DateTime?>("ExpirationDateSubscription");

                    b.Property<string>("IdentificationNumber")
                        .HasColumnType("varchar(3)");

                    b.Property<long>("IntermediateSecurities");

                    b.Property<string>("IsinCode")
                        .HasColumnType("varchar(12)");

                    b.Property<DateTime?>("LastDateRegister");

                    b.Property<string>("Market")
                        .HasColumnType("varchar(4)");

                    b.Property<long>("MarketPrice");

                    b.Property<string>("MedialCountryCode")
                        .HasColumnType("varchar(2)");

                    b.Property<string>("MedialIsinCode")
                        .HasColumnType("varchar(12)");

                    b.Property<byte>("MedialRightBuyType");

                    b.Property<byte>("MedialRoundType");

                    b.Property<string>("MedialStockCode")
                        .HasColumnType("varchar(35)");

                    b.Property<DateTime?>("MeetingDate");

                    b.Property<string>("MeetingPlace")
                        .HasMaxLength(100);

                    b.Property<string>("Narrative")
                        .HasMaxLength(350);

                    b.Property<DateTime?>("NoticeDate");

                    b.Property<string>("OptionNarrative")
                        .HasMaxLength(100);

                    b.Property<long>("OptionQuantity");

                    b.Property<byte>("OptionRightBuyType");

                    b.Property<byte>("OptionRoundType");

                    b.Property<byte>("OptionUnitType");

                    b.Property<string>("OwnerPartyBicode")
                        .HasColumnType("varchar(12)");

                    b.Property<string>("PageCodeInfo")
                        .HasColumnType("varchar(4)");

                    b.Property<long>("PageNumber");

                    b.Property<DateTime?>("PaymentDate");

                    b.Property<byte>("PriceRateType");

                    b.Property<long>("Quantity");

                    b.Property<byte>("RateOptionType");

                    b.Property<string>("RateOptionTypeFlag")
                        .HasColumnType("varchar(1)");

                    b.Property<string>("RateValue")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("ReferenceNumber")
                        .HasColumnType("varchar(16)");

                    b.Property<string>("RightCode")
                        .HasColumnType("varchar(4)");

                    b.Property<byte>("SecurityType");

                    b.Property<string>("Status")
                        .HasColumnType("varchar(4)");

                    b.Property<string>("StockCode")
                        .HasColumnType("varchar(35)");

                    b.Property<DateTime?>("TradingPriodFrom");

                    b.Property<DateTime?>("TradingPriodTo");

                    b.Property<int>("TypeOfRight");

                    b.Property<long>("Underlying");

                    b.Property<byte>("UnitType");

                    b.HasKey("Id");

                    b.ToTable("RightInformations");
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.Source", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(512);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<byte>("Type");

                    b.HasKey("Id");

                    b.ToTable("Sources");
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.StockPrice", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("AveragePrice")
                        .HasColumnType("decimal");

                    b.Property<decimal>("BasicPrice")
                        .HasColumnType("decimal");

                    b.Property<decimal>("CeilingPrice")
                        .HasColumnType("decimal");

                    b.Property<decimal>("ClosePrice")
                        .HasColumnType("decimal");

                    b.Property<decimal>("FloorPrice")
                        .HasColumnType("decimal");

                    b.Property<decimal>("OpenPrice")
                        .HasColumnType("decimal");

                    b.Property<int>("Status");

                    b.Property<int>("StockNo");

                    b.Property<byte>("StockType");

                    b.Property<DateTime>("TradingDate");

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("Id");

                    b.HasIndex("TradingDate")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("StockPrices");
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.TradingDate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("NextTransactionDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("PreviousTransactionDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("TradingDates");
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountLogin")
                        .HasColumnType("varchar(30)");

                    b.Property<long>("BranchId");

                    b.Property<Guid?>("CreatedByUserId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long?>("DepartmentId");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<bool>("IsActive");

                    b.Property<string>("LanguageCode")
                        .HasMaxLength(2);

                    b.Property<byte>("Level");

                    b.Property<Guid?>("ModifiedByUserId");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("varchar(15)");

                    b.Property<byte>("UserType");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("ModifiedByUserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.UserGroup", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("GroupId");

                    b.HasKey("UserId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("UserGroup");
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.Account", b =>
                {
                    b.HasOne("CS.Domain.Data.Entities.Asset", "Asset")
                        .WithMany("Accounts")
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.AccountBalance", b =>
                {
                    b.HasOne("CS.Domain.Data.Entities.Account", "Account")
                        .WithMany("AccountBalances")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CS.Domain.Data.Entities.CustomerAccount", "CustomerAccount")
                        .WithMany()
                        .HasForeignKey("CustomerAccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.AccountBlockTransaction", b =>
                {
                    b.HasOne("CS.Domain.Data.Entities.AccountBalance", "AccountBlance")
                        .WithMany("AccountBlockTransactions")
                        .HasForeignKey("AccountBlanceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.AccountTransaction", b =>
                {
                    b.HasOne("CS.Domain.Data.Entities.AccountBalance", "AcountBalance")
                        .WithMany("AccountTransactions")
                        .HasForeignKey("AcountBalanceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CS.Domain.Data.Entities.User", "ApproveBy")
                        .WithMany()
                        .HasForeignKey("ApproveById");

                    b.HasOne("CS.Domain.Data.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("CS.Domain.Data.Entities.Source", "Source")
                        .WithMany("AccountTransactions")
                        .HasForeignKey("SourceId");
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.Branch", b =>
                {
                    b.HasOne("CS.Domain.Data.Entities.Branch", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.BusinessAccountSetting", b =>
                {
                    b.HasOne("CS.Domain.Data.Entities.Account", "Account")
                        .WithMany("Settlements")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CS.Domain.Data.Entities.BusinessUnit", "BusinessUnit")
                        .WithMany("Settlements")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.Contact", b =>
                {
                    b.HasOne("CS.Domain.Data.Entities.Customer", "Customer")
                        .WithMany("Contacts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.Customer", b =>
                {
                    b.HasOne("CS.Domain.Data.Entities.Branch", "Branch")
                        .WithMany("Customers")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CS.Domain.Data.Entities.User", "Broker")
                        .WithMany()
                        .HasForeignKey("BrokerId");

                    b.HasOne("CS.Domain.Data.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId");

                    b.HasOne("CS.Domain.Data.Entities.Customer", "DelegatedCustomer")
                        .WithMany("RepresentativeCustomers")
                        .HasForeignKey("DelegatedCustomerId");

                    b.HasOne("CS.Domain.Data.Entities.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedByUserId");
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.CustomerAccount", b =>
                {
                    b.HasOne("CS.Domain.Data.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByBrockerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CS.Domain.Data.Entities.Customer", "Customer")
                        .WithMany("CustomerAccounts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.Department", b =>
                {
                    b.HasOne("CS.Domain.Data.Entities.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.Group", b =>
                {
                    b.HasOne("CS.Domain.Data.Entities.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CS.Domain.Data.Entities.Group", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.Permission", b =>
                {
                    b.HasOne("CS.Domain.Data.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("CS.Domain.Data.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.User", b =>
                {
                    b.HasOne("CS.Domain.Data.Entities.Branch", "Branch")
                        .WithMany("Users")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CS.Domain.Data.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId");

                    b.HasOne("CS.Domain.Data.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("CS.Domain.Data.Entities.User", "ModifiedBy")
                        .WithMany()
                        .HasForeignKey("ModifiedByUserId");
                });

            modelBuilder.Entity("CS.Domain.Data.Entities.UserGroup", b =>
                {
                    b.HasOne("CS.Domain.Data.Entities.Group", "Group")
                        .WithMany("Users")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CS.Domain.Data.Entities.User", "User")
                        .WithMany("Groups")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
