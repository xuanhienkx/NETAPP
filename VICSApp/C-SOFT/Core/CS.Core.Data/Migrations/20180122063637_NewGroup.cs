using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CS.Domain.Data.Migrations
{
    public partial class NewGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BoardName = table.Column<string>(maxLength: 30, nullable: true),
                    BoardType = table.Column<byte>(nullable: false),
                    Code = table.Column<string>(type: "varchar(35)", maxLength: 35, nullable: false),
                    CountryCode = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    ForginRate = table.Column<decimal>(type: "decimal", nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsinCode = table.Column<string>(type: "varchar(12)", nullable: true),
                    Name = table.Column<string>(maxLength: 350, nullable: false),
                    NameLocal = table.Column<string>(maxLength: 350, nullable: true),
                    ParValue = table.Column<decimal>(type: "decimal", nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Rational = table.Column<decimal>(type: "decimal", nullable: false),
                    SubType = table.Column<byte>(nullable: false),
                    TotalIssue = table.Column<decimal>(type: "decimal", nullable: false),
                    TradeDate = table.Column<DateTime>(nullable: true),
                    Type = table.Column<byte>(nullable: false),
                    Value = table.Column<decimal>(type: "decimal", nullable: false),
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BankCode = table.Column<string>(type: "varchar(5)", nullable: false),
                    BankPlRlCode = table.Column<string>(type: "varchar(15)", nullable: false),
                    FullName = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 200, nullable: true),
                    BranchCode = table.Column<string>(type: "varchar(3)", nullable: false),
                    BranchName = table.Column<string>(maxLength: 100, nullable: false),
                    Fax = table.Column<string>(type: "varchar(15)", nullable: true),
                    ParentId = table.Column<long>(nullable: true),
                    Tel = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_Branches_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessUnits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Type = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustodyRequests",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusinessId = table.Column<string>(maxLength: 125, nullable: true),
                    Content = table.Column<string>(nullable: true),
                    ContentClrType = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Priority = table.Column<byte>(nullable: false),
                    RequestType = table.Column<byte>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    VsdBicCode = table.Column<string>(maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustodyRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExchangeStocks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BoardType = table.Column<byte>(nullable: false),
                    FullNameName = table.Column<string>(maxLength: 256, nullable: false),
                    ShortName = table.Column<string>(type: "varchar(10)", nullable: false),
                    VsdBoardCode = table.Column<string>(type: "varchar(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeStocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileActs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusinessId = table.Column<string>(maxLength: 256, nullable: true),
                    DeliveryTime = table.Column<string>(type: "varchar(30)", nullable: true),
                    FileDescription = table.Column<string>(maxLength: 600, nullable: true),
                    FileInfo = table.Column<string>(maxLength: 600, nullable: true),
                    LogicalName = table.Column<string>(maxLength: 300, nullable: false),
                    OrigTransferRef = table.Column<string>(type: "varchar(30)", nullable: false),
                    ReportCode = table.Column<string>(type: "varchar(10)", nullable: false),
                    ReportStatus = table.Column<byte>(nullable: false),
                    ReportType = table.Column<byte>(nullable: false),
                    RequestRef = table.Column<string>(type: "varchar(30)", nullable: true),
                    SwiftTime = table.Column<string>(type: "varchar(30)", nullable: true),
                    TransferDescription = table.Column<string>(maxLength: 300, nullable: true),
                    TransferInfo = table.Column<string>(maxLength: 256, nullable: true),
                    TransferRef = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileActs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RightInformations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountType = table.Column<string>(type: "varchar(4)", nullable: true),
                    ActivityType = table.Column<byte>(nullable: false),
                    Amount = table.Column<long>(nullable: false),
                    BalanceElig = table.Column<string>(type: "varchar(4)", nullable: true),
                    BalanceOptionFlag = table.Column<string>(type: "varchar(1)", nullable: true),
                    BalanceUnit = table.Column<string>(type: "varchar(4)", nullable: true),
                    ClosingBalanceDate = table.Column<DateTime>(nullable: true),
                    CompulsoryPurchaseFrom = table.Column<DateTime>(nullable: true),
                    CompulsoryPurchaseTo = table.Column<DateTime>(nullable: true),
                    CountryCode = table.Column<string>(type: "varchar(2)", nullable: true),
                    CurrencyCode = table.Column<string>(type: "varchar(3)", nullable: true),
                    DeadlinePassOwnershipList = table.Column<DateTime>(nullable: true),
                    DeadlinePayment = table.Column<DateTime>(nullable: true),
                    DefaultProcessingFlag = table.Column<string>(type: "varchar(1)", nullable: true),
                    Denominations = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(maxLength: 350, nullable: true),
                    EffectiveDate = table.Column<DateTime>(nullable: true),
                    ExecutionDate = table.Column<DateTime>(nullable: true),
                    ExpirationDateSubscription = table.Column<DateTime>(nullable: true),
                    IdentificationNumber = table.Column<string>(type: "varchar(3)", nullable: true),
                    IntermediateSecurities = table.Column<long>(nullable: false),
                    IsinCode = table.Column<string>(type: "varchar(12)", nullable: true),
                    LastDateRegister = table.Column<DateTime>(nullable: true),
                    Market = table.Column<string>(type: "varchar(4)", nullable: true),
                    MarketPrice = table.Column<long>(nullable: false),
                    MedialCountryCode = table.Column<string>(type: "varchar(2)", nullable: true),
                    MedialIsinCode = table.Column<string>(type: "varchar(12)", nullable: true),
                    MedialRightBuyType = table.Column<byte>(nullable: false),
                    MedialRoundType = table.Column<byte>(nullable: false),
                    MedialStockCode = table.Column<string>(type: "varchar(35)", nullable: true),
                    MeetingDate = table.Column<DateTime>(nullable: true),
                    MeetingPlace = table.Column<string>(maxLength: 100, nullable: true),
                    Narrative = table.Column<string>(maxLength: 350, nullable: true),
                    NoticeDate = table.Column<DateTime>(nullable: true),
                    OptionNarrative = table.Column<string>(maxLength: 100, nullable: true),
                    OptionQuantity = table.Column<long>(nullable: false),
                    OptionRightBuyType = table.Column<byte>(nullable: false),
                    OptionRoundType = table.Column<byte>(nullable: false),
                    OptionUnitType = table.Column<byte>(nullable: false),
                    OwnerPartyBicode = table.Column<string>(type: "varchar(12)", nullable: true),
                    PageCodeInfo = table.Column<string>(type: "varchar(4)", nullable: true),
                    PageNumber = table.Column<long>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: true),
                    PriceRateType = table.Column<byte>(nullable: false),
                    Quantity = table.Column<long>(nullable: false),
                    RateOptionType = table.Column<byte>(nullable: false),
                    RateOptionTypeFlag = table.Column<string>(type: "varchar(1)", nullable: true),
                    RateValue = table.Column<string>(type: "varchar(15)", nullable: true),
                    ReferenceNumber = table.Column<string>(type: "varchar(16)", nullable: true),
                    RightCode = table.Column<string>(type: "varchar(4)", nullable: true),
                    SecurityType = table.Column<byte>(nullable: false),
                    Status = table.Column<string>(type: "varchar(4)", nullable: true),
                    StockCode = table.Column<string>(type: "varchar(35)", nullable: true),
                    TradingPriodFrom = table.Column<DateTime>(nullable: true),
                    TradingPriodTo = table.Column<DateTime>(nullable: true),
                    TypeOfRight = table.Column<int>(nullable: false),
                    Underlying = table.Column<long>(nullable: false),
                    UnitType = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RightInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sources",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Type = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockPrices",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AveragePrice = table.Column<decimal>(type: "decimal", nullable: false),
                    BasicPrice = table.Column<decimal>(type: "decimal", nullable: false),
                    CeilingPrice = table.Column<decimal>(type: "decimal", nullable: false),
                    ClosePrice = table.Column<decimal>(type: "decimal", nullable: false),
                    FloorPrice = table.Column<decimal>(type: "decimal", nullable: false),
                    OpenPrice = table.Column<decimal>(type: "decimal", nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StockNo = table.Column<int>(nullable: false),
                    StockType = table.Column<byte>(nullable: false),
                    TradingDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockPrices", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "TradingDates",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NextTransactionDate = table.Column<DateTime>(type: "date", nullable: false),
                    PreviousTransactionDate = table.Column<DateTime>(type: "date", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradingDates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssetId = table.Column<long>(nullable: false),
                    Code = table.Column<string>(type: "varchar(50)", nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    Type = table.Column<byte>(nullable: false),
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BranchId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    ParentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Groups_Groups_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessAccountSetting",
                columns: table => new
                {
                    AccountId = table.Column<long>(nullable: false),
                    BusinessId = table.Column<long>(nullable: false),
                    Type = table.Column<byte>(nullable: false),
                    XmlSetting = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessAccountSetting", x => new { x.AccountId, x.BusinessId });
                    table.ForeignKey(
                        name: "FK_BusinessAccountSetting_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessAccountSetting_BusinessUnits_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "BusinessUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccountLogin = table.Column<string>(type: "varchar(30)", nullable: true),
                    BranchId = table.Column<long>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DepartmentId = table.Column<long>(nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    FullName = table.Column<string>(maxLength: 256, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    LanguageCode = table.Column<string>(maxLength: 2, nullable: true),
                    Level = table.Column<byte>(nullable: false),
                    ModifiedByUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", nullable: true),
                    UserType = table.Column<byte>(nullable: false),
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccountLogin = table.Column<string>(type: "varchar(30)", nullable: true),
                    Address = table.Column<string>(maxLength: 65, nullable: false),
                    BirthDay = table.Column<DateTime>(nullable: true),
                    BranchId = table.Column<long>(nullable: false),
                    BrokerId = table.Column<Guid>(nullable: true),
                    CardIdentity = table.Column<string>(type: "varchar(50)", nullable: false),
                    CardIssuedDate = table.Column<DateTime>(nullable: false),
                    CardIssuer = table.Column<string>(maxLength: 65, nullable: false),
                    CardType = table.Column<byte>(nullable: false),
                    City = table.Column<string>(maxLength: 35, nullable: false),
                    CountryCode = table.Column<string>(maxLength: 2, nullable: true),
                    CreatedByUserId = table.Column<Guid>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CustomerNumber = table.Column<string>(type: "varchar(10)", nullable: false),
                    DelegatedCustomerId = table.Column<Guid>(nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    FullName = table.Column<string>(maxLength: 140, nullable: false),
                    FullNameLocal = table.Column<string>(maxLength: 140, nullable: false),
                    Genere = table.Column<byte>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    LanguageCode = table.Column<string>(maxLength: 2, nullable: true),
                    Level = table.Column<byte>(nullable: false),
                    ModifiedByUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    NationalityCode = table.Column<string>(maxLength: 2, nullable: true),
                    Notes = table.Column<string>(maxLength: 350, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", nullable: true),
                    PinCode = table.Column<string>(type: "varchar(max)", nullable: true),
                    SignatureImage1 = table.Column<byte[]>(nullable: true),
                    SignatureImage2 = table.Column<byte[]>(nullable: true),
                    Status = table.Column<byte>(nullable: false),
                    TaxCode = table.Column<string>(maxLength: 50, nullable: true),
                    Type = table.Column<byte>(nullable: false),
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Users_BrokerId",
                        column: x => x.BrokerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Customers_DelegatedCustomerId",
                        column: x => x.DelegatedCustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Users_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedById = table.Column<Guid>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    GroupId = table.Column<Guid>(nullable: false),
                    Name = table.Column<int>(nullable: false),
                    Type = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Permissions_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroup",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    GroupId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroup", x => new { x.UserId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_UserGroup_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserGroup_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<Guid>(nullable: false),
                    Detail = table.Column<string>(maxLength: 500, nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    Type = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    ContractNumber = table.Column<string>(type: "varchar(10)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedByBrockerId = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    ExpiredDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Type = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerAccounts_Users_CreatedByBrockerId",
                        column: x => x.CreatedByBrockerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAccounts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountBalance",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<long>(nullable: false),
                    Available = table.Column<decimal>(type: "decimal", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal", nullable: false),
                    Block = table.Column<decimal>(type: "decimal", nullable: true),
                    CustomerAccountId = table.Column<Guid>(nullable: false),
                    LastBalancedDate = table.Column<DateTime>(nullable: false),
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountBalance", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_AccountBalance_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountBalance_CustomerAccounts_CustomerAccountId",
                        column: x => x.CustomerAccountId,
                        principalTable: "CustomerAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountBlockTransaction",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountBlanceId = table.Column<long>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Note = table.Column<string>(maxLength: 50, nullable: true),
                    ReferenceCode = table.Column<string>(type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountBlockTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountBlockTransaction_AccountBalance_AccountBlanceId",
                        column: x => x.AccountBlanceId,
                        principalTable: "AccountBalance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountTransaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AcountBalanceId = table.Column<long>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal", nullable: false),
                    ApproveById = table.Column<Guid>(nullable: true),
                    CreatedById = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(maxLength: 256, nullable: false),
                    ReferenceCode = table.Column<string>(maxLength: 20, nullable: false),
                    SourceId = table.Column<long>(nullable: true),
                    Status = table.Column<byte>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTransaction", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_AccountTransaction_AccountBalance_AcountBalanceId",
                        column: x => x.AcountBalanceId,
                        principalTable: "AccountBalance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountTransaction_Users_ApproveById",
                        column: x => x.ApproveById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountTransaction_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountTransaction_Sources_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Sources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountBalance_AccountId",
                table: "AccountBalance",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountBalance_CustomerAccountId",
                table: "AccountBalance",
                column: "CustomerAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountBalance_LastBalancedDate",
                table: "AccountBalance",
                column: "LastBalancedDate")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountBlockTransaction_AccountBlanceId",
                table: "AccountBlockTransaction",
                column: "AccountBlanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AssetId",
                table: "Accounts",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Code",
                table: "Accounts",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransaction_AcountBalanceId",
                table: "AccountTransaction",
                column: "AcountBalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransaction_ApproveById",
                table: "AccountTransaction",
                column: "ApproveById");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransaction_CreatedById",
                table: "AccountTransaction",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransaction_SourceId",
                table: "AccountTransaction",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransaction_TransactionDate",
                table: "AccountTransaction",
                column: "TransactionDate")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_Assets_Code",
                table: "Assets",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branches_BranchCode",
                table: "Branches",
                column: "BranchCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branches_ParentId",
                table: "Branches",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessAccountSetting_BusinessId",
                table: "BusinessAccountSetting",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CustomerId",
                table: "Contacts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccounts_CreatedByBrockerId",
                table: "CustomerAccounts",
                column: "CreatedByBrockerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccounts_CustomerId",
                table: "CustomerAccounts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BranchId",
                table: "Customers",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BrokerId",
                table: "Customers",
                column: "BrokerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CardIdentity",
                table: "Customers",
                column: "CardIdentity");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CreatedByUserId",
                table: "Customers",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerNumber",
                table: "Customers",
                column: "CustomerNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_DelegatedCustomerId",
                table: "Customers",
                column: "DelegatedCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ModifiedByUserId",
                table: "Customers",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_BranchId",
                table: "Departments",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeStocks_BoardType",
                table: "ExchangeStocks",
                column: "BoardType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeStocks_VsdBoardCode",
                table: "ExchangeStocks",
                column: "VsdBoardCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_BranchId",
                table: "Groups",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ParentId",
                table: "Groups",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_CreatedById",
                table: "Permissions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_GroupId",
                table: "Permissions",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StockPrices_Id",
                table: "StockPrices",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StockPrices_TradingDate",
                table: "StockPrices",
                column: "TradingDate")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_GroupId",
                table: "UserGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BranchId",
                table: "Users",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedByUserId",
                table: "Users",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId",
                table: "Users",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ModifiedByUserId",
                table: "Users",
                column: "ModifiedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountBlockTransaction");

            migrationBuilder.DropTable(
                name: "AccountTransaction");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "BusinessAccountSetting");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "CustodyRequests");

            migrationBuilder.DropTable(
                name: "ExchangeStocks");

            migrationBuilder.DropTable(
                name: "FileActs");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "RightInformations");

            migrationBuilder.DropTable(
                name: "StockPrices");

            migrationBuilder.DropTable(
                name: "TradingDates");

            migrationBuilder.DropTable(
                name: "UserGroup");

            migrationBuilder.DropTable(
                name: "AccountBalance");

            migrationBuilder.DropTable(
                name: "Sources");

            migrationBuilder.DropTable(
                name: "BusinessUnits");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "CustomerAccounts");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Branches");
        }
    }
}
