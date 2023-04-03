using AutoMapper;
using CS.Common.Domain.Interfaces;
using CS.Domain.Data;
using CS.Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SemanticComparison.Fluent;
using System;
using System.Globalization;
using System.Linq;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using Xunit;
using Xunit.Abstractions;

namespace XUnit.CS.Domain.Data
{
    public class BranchDataTest : BaseDataTest
    {

        public BranchDataTest(CoreDataFixtureSetup fixtureSetup, ITestOutputHelper output)
            : base(fixtureSetup, output)
        {
        }

        [Fact]
        public void AddBranchTest()
        {
            // fixture setup                               
            var branch = new BranchModel
            {
                BranchCode = "200",
                BranchName = "Ho Chi Minh",
                Address = "2Bis Nguyen Thi Minh Khai, Phuong Dakao, Quan 1, TP HCM"
            };

            // exercice
            var sut = Fixture.Resolve<IDomainService<long, BranchModel, Branch>>();
            var result = sut.Insert(branch).Result;

            // assert
            Assert.IsType<BranchModel>(result);
            Assert.True(result.Id > 0);
            var dbModel = sut.Query.GetAsync(result.Id).Result;
            dbModel.AsSource().OfLikeness<BranchModel>()
                .ShouldEqual(result);

            // teardown
        }

        [Fact]
        public void EditBranchTest()
        {
            // fixture setup
            var context = Fixture.Resolve<CSoftDataContext>();
            context.Set<Branch>().Add(new Branch
            {
                BranchCode = "100",
                BranchName = "HA NOI",
                Address = "Ha noi"
            });

            context.SaveChanges();

            var expectedBranch = new BranchModel
            {
                Id = context.Set<Branch>().First().Id,
                BranchCode = "200",
                BranchName = "Sai Gon",
                Address = "Ho Chi MInh"
            };
            // exercice
            var sut = Fixture.Resolve<IDomainService<long, BranchModel, Branch>>();
            var result = sut.Update(expectedBranch).Result;
            if (DataHandler.HasError(out var errorMessages))
            {
                Logger.WriteLine(string.Join("\n", errorMessages));
            }

            // assert
            Assert.IsType<BranchModel>(result);
            Assert.IsType<BranchModel>(result);
            Assert.True(result.Id > 0);
            var dbModel = sut.Query.GetAsync(result.Id).Result;
            dbModel.AsSource().OfLikeness<BranchModel>()
                .ShouldEqual(result);

            // teardown

        }
        [Fact]
        public void EditBranchUniqueBranchCodeTest()
        {
            // fixture setup
            var context = Fixture.Resolve<CSoftDataContext>();
            context.Set<Branch>().Add(new Branch
            {
                BranchCode = "100",
                BranchName = "HA NOI",
                Address = "Ha noi"
            });
            context.Set<Branch>().Add(new Branch
            {
                BranchCode = "200",
                BranchName = "HCM",
                Address = "HCM"
            });
            context.SaveChanges();

            var expectedBranch = new BranchModel
            {
                Id = context.Set<Branch>().First().Id,
                BranchCode = "200",
                BranchName = "Sai Gon",
                Address = "Ho Chi MInh"
            };
            // exercice
            var sut = Fixture.Resolve<IDomainService<long, BranchModel, Branch>>();
            var result = sut.Update(expectedBranch).Result;
            //expectedBranch.AsSource().OfLikeness<BranchModel>()
            //    .WithCollectionInnerLikeness(s => s.Users, d => d.Users)
            //    .WithCollectionInnerLikeness(s => s.Branches, d => d.Branches)
            //    .ShouldEqual(result);

            // assert

            var hasError = DataHandler.HasError(out var errorMessages);
            Logger.WriteLine(string.Join("\n", errorMessages));

            Assert.True(hasError);
            // teardown

        }
        [Fact]
        public void TestMappingModel()
        {
            var context = Fixture.Resolve<CSoftDataContext>();
            var branch = new Branch() { Address = "Ha Noi", BranchCode = "200", BranchName = "Ha Noi" };
            var broker = new User()
            {
                Id = Guid.NewGuid(),
                FullName = "Broker",
                BranchId = 1,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };
            context.Set<Branch>().Add(branch);
            var entity = new Customer
            {
                Id = Guid.NewGuid(),
                BranchId = 1,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                BrokerId = broker.Id,
                Genere = GenereType.Male,
                FullName = "Nguyen Xuan Phap",
                CardType = CardType.DomesticIdentity,
                BirthDay = DateTime.ParseExact("09/09/1986", "dd/MM/yyyy", CultureInfo.CurrentCulture),
            };

            var dbnew = context.Set<Customer>().Add(entity).Entity;
            context.SaveChanges();

            var db = context.Set<Customer>().AsNoTracking()
                   .Include(x => x.CreatedBy)
                .Include(x => x.Broker).SingleOrDefault(x => x.Id == dbnew.Id);
            var mapper = Fixture.Resolve<IMapper>();
            var model = mapper.Map<CustomerModel>(db);
            var strModel = JsonConvert.SerializeObject(model);
            Logger.WriteLine(strModel);
        }

    }
}
