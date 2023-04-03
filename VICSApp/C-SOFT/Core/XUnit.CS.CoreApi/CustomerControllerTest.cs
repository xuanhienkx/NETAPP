using CS.CoreApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CS.Common.Contract.Enums;
using CS.Common.Contract.Models;
using Xunit;
using Xunit.Abstractions;

namespace XUnit.CS.CoreApi
{
    public class CustomerControllerTest : BaseControllerTest
    {
        public CustomerControllerTest(CoreApiFixtureSetup fixture, ITestOutputHelper output) : base(fixture, output)
        {   // fixture
            fixture.Register(s =>
            {
                //All
                RegisterAll(s);
                // controler

                s.AddScoped<CustomersController>();
            });
        }

        [Fact]
        public void AddCustomerTest()
        {
            // fixture setup                               
            var customerModel = new CustomerModel()
            {
                BirthDay = DateTime.ParseExact("18/09/1986", "dd/MM/yyyy", CultureInfo.CurrentUICulture),
                CardIdentity = "183522862",
                CardIssuer = "Ha Tinh",
                CountryCode = "VN",
                CardIssuedDate = DateTime.ParseExact("18/09/2016", "dd/MM/yyyy", CultureInfo.CurrentUICulture),
                CardType = CardType.DomesticIdentity,
                Email = "Phapht@gmail.com",
                CustomerNumber = "076C066788",
                Genere = GenereType.Male,
                FullNameLocal = "Nguyen Xuan Phap",
                FullName = "Nguyen Xuan Phap",
                Broker = new UserModel()
                {
                    Email = "phapht@live.com",
                    FullName = "Nguyen xuan Phap"
                }
            };
            // exercice
            var sut = Fixture.Resolve<CustomersController>();
            var result = sut.PostInsert(customerModel).Result;

            if (((ObjectResult)result).StatusCode == 200)
            {
                // assert
                Assert.IsType<OkObjectResult>(result);
                var model = Assert.IsAssignableFrom<CustomerModel>(((OkObjectResult)result).Value);
                var dbModel = sut.GetById(model.Id).Result;
                 /*dbModel.AsSource().OfLikeness<CustomerModel>()
                     .WithInnerLikeness(s => s.CreatedBy, d => d.CreatedBy)
                     .WithInnerLikeness(s => s.ModefiledBy, d => d.ModefiledBy)
                     .ShouldEqual(result);*/
            }
            else
            {
                Assert.IsType<BadRequestObjectResult>(result);
                var model = ((BadRequestObjectResult)result).Value;
                //  var model = Assert.IsAssignableFrom<IDictionary<string, object>>(((BadRequestObjectResult)result).Value);
                var data = (from x in model.GetType().GetProperties() select x).ToDictionary(x => x.Name, x => (x.GetGetMethod().Invoke(model, null) == null ? "" : x.GetGetMethod().Invoke(model, null)));
                var error = (List<string>)data["error"];
                Logger.WriteLine(string.Join("\n", error));

            }
        }

    }
}