using System;
using System.Collections.Generic;
using CS.Common.Contract.Models;
using Xunit.Abstractions;

namespace XUnit.CS.CoreApi
{
    public class BrokersControllerTest: BaseControllerTest
    {
        public BrokersControllerTest(CoreApiFixtureSetup fixtureSetup, ITestOutputHelper output)
            : base(fixtureSetup, output)
        {
        }
        private IEnumerable<UserModel> Brokers()
        {
            var brokers = new List<UserModel>
            {
                new UserModel
                {
                    Id =new Guid("6EB32BDE-29B8-4DBF-81D4-30ED8DBA20FB"),
                    CreatedDate = DateTime.Now,
                    Branch = new BranchModel{Id = 1},
                    Email = "phapht@gmail.com",
                    FullName = "Nguyễn Xuân Pháp",
                    IsActive = true,                
                },
                new UserModel
                {
                    Id = new Guid("B78BCF45-FF70-4B35-891A-798A47B6C038"),
                    CreatedDate = DateTime.Now,
                    Branch = new BranchModel{Id = 1},
                    FullName = "Nguyễn Xuân Pháp2",
                    IsActive = true,                 
                },
                new UserModel
                {
                    Id = new Guid("71DEB9AE-8343-4BB7-AF31-A9E6A36BB248"),
                    CreatedDate = DateTime.Now,
                    Branch = new BranchModel{Id = 1},
                    FullName = "Nguyễn Xuân Pháp2",
                    IsActive = true,                
                }
            };
            return brokers;
        }


        //[Fact]
        //public void GetAllBrokersReturnsOk()
        //{
        //    var sut = Fixture.Resolve<IServiceProvider>();
        //    var mockService = new Mock<IBrokerService>();
        //    mockService.Setup(r => r.GetAll()).Returns(Brokers());
        //    var controller = new BrokersController(Logger, sut, mockService.Object);
        //    var result = controller.Get();
        //    // Assert
        //    var viewResult = Assert.IsType<OkObjectResult>(result);
        //    var model = Assert.IsAssignableFrom<List<Broker>>(
        //        viewResult.Value);
        //    Assert.Equal(3, model.Count);
        //}
        //[Fact]
        //public void GetBrokerReturnsOk()
        //{
        //    var sut = Fixture.Resolve<IServiceProvider>();
        //    var mockService = new Mock<IBrokerService>();
        //    mockService.Setup(r => r.Get(new Guid("6EB32BDE-29B8-4DBF-81D4-30ED8DBA20FB"))).Returns(Brokers().First());
        //    var controller = new BrokersController(Logger, sut, mockService.Object);
        //    var result = controller.Get(new Guid("6EB32BDE-29B8-4DBF-81D4-30ED8DBA20FB"));
        //    // Assert
        //    var viewResult = Assert.IsType<OkObjectResult>(result);
        //    var model = Assert.IsAssignableFrom<Broker>(
        //        viewResult.Value);
        //    Assert.Equal(Brokers().First().Id, model.Id);
        //}
        //[Fact]
        //public void CreatePasswordTest()
        //{
        //    var service = Fixture.Resolve<IPasswordSalter>();
        //    var user = new User()
        //    {
        //        Id = Guid.NewGuid(),
        //        Password = "1234"
        //    };
        //    var hashPwd = service.HashPassword(user,user.Password);
        //    Logger.LogDebug($"[Password]:[{hashPwd}]==>[Salt]:[{user.PasswordSalt}]");
        //    user.Password = hashPwd;
        //    Assert.False(string.IsNullOrEmpty(user.PasswordSalt));
        //    Assert.True(service.VerifyHashedPassword(hashPwd, "1234"));
        //}
        //[Fact]
        //public void PostBrokerReturnsOk()
        //{
        //    // setup 
        //    var sut = Fixture.Resolve<IServiceProvider>();
        //    var mockService = new Mock<IBrokerService>();
        //    var broker = Brokers().Single(x => x.Id == new Guid("6EB32BDE-29B8-4DBF-81D4-30ED8DBA20FB"));
        //    mockService.Setup(r => r.Insert(broker));
        //    var controller = new BrokersController(Logger, sut, mockService.Object);
        //    var result = controller.New(broker);
        //    // Assert
        //    var viewResult = Assert.IsType<OkObjectResult>(result);
        //    Assert.True(viewResult.StatusCode == 200);
        //}
        //[Fact]
        //public void PostDataBrokerReturnsOk()
        //{
        //    var sut = Fixture.Resolve<IServiceProvider>();
        //    // setup 
        //    var mockService = Fixture.Resolve<IBrokerService>();
        //    var broker = Brokers().Single(x => x.Id == new Guid("6EB32BDE-29B8-4DBF-81D4-30ED8DBA20FB"));
        //    var controller = new BrokersController(Logger, sut, mockService); 
        //    Logger.LogDebug(JsonConvert.SerializeObject(broker));
        //    var result = controller.New(broker);
        //    // Assert
        //    var viewResult = Assert.IsType<OkObjectResult>(result);
        //    Assert.True(viewResult.StatusCode == 200);
        //}
    }
}