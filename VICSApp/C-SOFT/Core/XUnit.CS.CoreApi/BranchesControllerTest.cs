using CS.Common.Contract.Models;
using System.Collections.Generic;
using Xunit.Abstractions;

namespace XUnit.CS.CoreApi
{
    public class BranchesControllerTest : BaseControllerTest
    {

        public BranchesControllerTest(CoreApiFixtureSetup fixtureSetup, ITestOutputHelper output)
            : base(fixtureSetup, output)
        {
           
        }
        private IEnumerable<BranchModel> Branches()
        {
            var branches = new List<BranchModel>
            {
                new BranchModel
                {
                    Id = 1,
                    BranchCode = "100",
                    BranchName = "HA NOI",
                    Address = "Ha noi"
                },
                new BranchModel
                {
                    Id = 2,
                    BranchCode = "200",
                    BranchName = "HCM",
                    Address = "2bis Nguyen Thi Minh Khai Q1"
                },
                new BranchModel
                {
                    Id = 3,
                    BranchCode = "300",
                    BranchName = "HUE",
                    Address = "HUE"
                }
            };
            return branches;
        }


        //[Fact]
        //public void GetAllBranchReturnsOk()
        //{
        //    var sut = Fixture.Resolve<IServiceProvider>();
        //    var mockService = new Mock<IBranchService>();
        //    mockService.Setup(r => r.GetAll()).Returns(Branches());
        //    var controller = new BranchesController(Logger, sut, mockService.Object);
        //    var result = controller.Get();
        //    // Assert
        //    var viewResult = Assert.IsType<OkObjectResult>(result);
        //    var model = Assert.IsAssignableFrom<List<Branch>>(
        //        viewResult.Value);
        //    Assert.Equal(3, model.Count);
        //}
        //[Fact]
        //public void GetBranchReturnsOk()
        //{
        //    var sut = Fixture.Resolve<IServiceProvider>();
        //    var mockService = new Mock<IBranchService>();
        //    mockService.Setup(r => r.Get(1)).Returns(Branches().First());
        //    var controller = new BranchesController(Logger, sut, mockService.Object);
        //    var result = controller.Get(1);
        //    // Assert
        //    var viewResult = Assert.IsType<OkObjectResult>(result);
        //    var model = Assert.IsAssignableFrom<Branch>(
        //        viewResult.Value);
        //    Assert.Equal(Branches().First().Id, model.Id);
        //}
        //[Fact]
        //public void PostBranchReturnsOk()
        //{
        //    // setup 
        //    var sut = Fixture.Resolve<IServiceProvider>();
        //    var mockService = new Mock<IBranchService>();
        //    var branch = Branches().Single(x => x.Id == 1);
        //    mockService.Setup(r => r.Insert(branch));
        //    var controller = new BranchesController(Logger, sut, mockService.Object);
        //    var result = controller.Post(branch);
        //    // Assert
        //    var viewResult = Assert.IsType<OkObjectResult>(result); 
        //    Assert.True(viewResult.StatusCode == 200); 
        //}
        //[Fact]
        //public void PostDataBranchReturnsOk()
        //{
        //    var sut = Fixture.Resolve<IServiceProvider>();
        //    // setup 
        //    var mockService = Fixture.Resolve<IBranchService>();
        //    var branch = Branches().Single(x => x.Id == 1);
        //    var controller = new BranchesController(Logger, sut, mockService);
        //    branch.Id = 0;
        //    var result = controller.Post(branch);
        //    // Assert
        //    var viewResult = Assert.IsType<OkObjectResult>(result); 
        //    Assert.True(viewResult.StatusCode == 200); 
        //}
        //[Fact]
        //public void PutBranchReturnsOk()
        //{
        //    // fixture 
        //    var sut = Fixture.Resolve<IServiceProvider>();
        //    // setup 
        //    var mockService = new Mock<IBranchService>();
        //    var branch = Branches().Single(x => x.Id == 1);
        //    branch.Address = "Ha noi 2";
        //    mockService.Setup(r => r.Update(branch));
        //    var controller = new BranchesController(Logger, sut, mockService.Object);
        //    var result = controller.Delete(1);
        //    // Assert
        //    var viewResult = Assert.IsType<OkObjectResult>(result);
        //    Assert.True(viewResult.StatusCode == 200);
        //    var model = Assert.IsAssignableFrom<bool>(
        //        viewResult.Value);
        //    Assert.True(model);
        //}
    }

}