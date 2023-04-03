using api.common;
using api.common.Models;
using api.common.Models.Identity;
using api.common.Shared;
using api.domain.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.common.Commands;
using Xunit;
using Xunit.Abstractions;

namespace api.unit_test
{
    public class MongoDbTest
    {
        private readonly ITestOutputHelper testOutputHelper;
        private readonly IMongoDatabase database;
        private readonly IServiceProvider serviceProvider;

        public MongoDbTest(ITestOutputHelper testOutputHelper)
        {
            this.serviceProvider = RegisterServices.CreateServices().WithCurrentUser().BuildServiceProvider();
            this.testOutputHelper = testOutputHelper;
            this.database = new MongoClient("mongodb://localhost:27017").GetDatabase("meeting_online");
        }

        [Fact]
        public void Query()
        {
            var filter = Builders<Meeting>.Filter.Eq(x => x.Id, "5ead1b7a5c3f9a32fc78c46f");
            var collection =  database.GetCollection<Meeting>("meetings");

            Builders<Meeting>.Filter.And(
                Builders<Meeting>.Filter.Eq(x => x.Id, "5ead1b7a5c3f9a32fc78c46f"),
                Builders<Meeting>.Filter.Eq(x => x.DeletedDate, null),
                Builders<Meeting>.Filter.ElemMatch(x => x.ElectionMatters, x => x.Name.StartsWith("Noi", StringComparison.OrdinalIgnoreCase)) // search here not work!
                );

            var result = collection
                .Find(filter)
                .Project(Builders<Meeting>.Projection.Expression(x => x.ElectionMatters.Skip(1).Take(5)))
                .FirstOrDefault();

            testOutputHelper.WriteLine(JsonConvert.SerializeObject(result));
        }

        [Fact]
        public void UpdateAndReturn()
        {
            var collection = database.GetCollection<MeetingRole>(ProviderConstants.MeetingRoleCollectionName);

            var permissions = new List<MeetingPermission>
            {
                //MeetingPermission.meeting_access_edit,
                MeetingPermission.meeting_holder_email
               // MeetingPermission.meeting_access_remove,
               // MeetingPermission.meeting_document_edit,
            };
            var filter = Builders<MeetingRole>.Filter.And(
                Builders<MeetingRole>.Filter.Eq(x => x.DisabledDate, null),
                Builders<MeetingRole>.Filter.AnyIn(x => x.Permissions, permissions.Select(x => x.ToString()))
            );
            var cursor = collection.Distinct(x => x.Id, filter);
            var roleIds = cursor.ToList();
            testOutputHelper.WriteLine(JsonConvert.SerializeObject(roleIds));

            var meetingId = "5eb3abb4b321904308d9650d";
            var userCollection = database.GetCollection<IdentityUser>(ProviderConstants.UserCollectionName);
            var filters = new List<FilterDefinition<IdentityUser>>
            {
                Builders<IdentityUser>.Filter.Eq(x => x.DeletedDate, null),
                Builders<IdentityUser>.Filter.ElemMatch(x => x.MeetingAccesses,
                    x => x.MeetingId.Equals(meetingId) && x.IsViewer == false && x.MeetingRoles.Any(r => roleIds.Contains( r)))
            };

            var query = Builders<IdentityUser>.Filter.And(filters);
            var userQuery = userCollection
                .Find(query)
                .Project<Account>(
                    Builders<IdentityUser>.Projection.IncludeMany(
                        x => x.DisplayName, x => x.UserName, x => x.Email));

            var result = userQuery.ToList();

            testOutputHelper.WriteLine(JsonConvert.SerializeObject(result));

        }

        [Fact]
        public void FindAndDelete()
        {
            var filter = Builders<Meeting>.Filter.And(
                Builders<Meeting>.Filter.Eq(x => x.Id, "5eb57d7e766ba730508216d7")
            );
            var update = Builders<Meeting>.Update.PullFilter(x => x.Holders, x => x.NormalizeIdentityNumber.Equals("025875199"));
            var option = new FindOneAndUpdateOptions<Meeting, Holder>
            {
                ReturnDocument = ReturnDocument.Before,
                Projection = Builders<Meeting>.Projection.Expression(x => x.Holders.FirstOrDefault(x => x.NormalizeIdentityNumber.Equals("025875199")))
            };

            var collection = database.GetCollection<Meeting>("meetings");
            var result = collection.FindOneAndUpdate(filter, update, option);

            testOutputHelper.WriteLine(JsonConvert.SerializeObject(result));

        }

        [Fact]
        public async Task ExecutedTest()
        {
            //var command = new MeetingRoleFilterCommand(MeetingType.GeneralMeeting, MeetingPermission.meeting_holder_email);
            var mediator = serviceProvider.GetService<IMediator>();
            //var result = await mediator.Send(command);

            //testOutputHelper.WriteLine(JsonConvert.SerializeObject(result));

            var meetingId = "5eb3f488cd10f1040c09782e";
            var appvover =
                await mediator.Send(new GetUsersAccessToMeeting(meetingId, isMemberOnly: true, isRoleDetail: true)); //{Roles = result.Value});

            var holderId = "";
            await mediator.Send(new UpdateByIdCommand<Meeting, Holder>(meetingId, holderId, x => x.Holders,
                x => x.Holders[-1].ConfirmedDate, new Occurrence()));

            appvover.Value.ForEach(a => testOutputHelper.WriteLine(JsonConvert.SerializeObject(a)));
        }

        [Fact]
        public void UpdateManyFieldsWithManyFilters()
        {
            var meetingId = "5ec5dc35bd41f05818c4a3f2";
            var holderId = "5ec5dc47bd41f05818c4a3fa";
            var mandatorId = "5ec5dc47bd41f05818c4a3f8";
            var filter = Builders<Meeting>.Filter.And(
                Builders<Meeting>.Filter.Eq(x => x.Id, meetingId));
                //,Builders<Meeting>.Filter.ElemMatch(x => x.Attendees, x => x.Id.Equals(holderId))
                //,Builders<Meeting>.Filter.ElemMatch(x => x.Attendees[-1].Mandators, x => x.Id.Equals(mandatorId))
                //,Builders<Meeting>.Filter.ElemMatch(x => x.Holders, x => x.Id.Equals(holderId)));

            var update = Builders<Meeting>.Update
                //.Inc(x => x.Summary.OnlineCheckIn, -1)
                .Set(x => x.Holders.First(a => a.Id.Equals(mandatorId)).Address, "Test + " + DateTime.Now.Ticks)
                .Set(x => x.Holders.First(a => a.Id.Equals(holderId)).Address, "Test + " + DateTime.Now.Ticks);
                //.Set(x => x.Attendees[-1].Mandators[-1], new Delegation(mandatorId, 2000));

            var result =  database.GetCollection<Meeting>("meetings")
                
                .FindOneAndUpdate(filter, update, new FindOneAndUpdateOptions<Meeting>{ ReturnDocument =  ReturnDocument.After });
            testOutputHelper.WriteLine(JsonConvert.SerializeObject(new { a = result.Attendees.Select(x => new { x.DisplayName, x.Address }), h = result.Holders.Select(x => new { x.DisplayName, x.Address })}));
        }

        [Fact]
        public async Task TestSearch()
        {
            var meetingId = "5ec1f9c3693b411d8873cb6c";
            //var filter = Builders<Meeting>.Filter.And(
            //    Builders<Meeting>.Filter.Eq(x => x.Id, meetingId),
            //    Builders<Meeting>.Filter.ElemMatch(x => x.Attendees,
            //        x => x.Id != "5ec0dcdf458ee33f94ef2b5f" &&
            //             (x.NormalizeIdentityNumber.Equals("025875199") ||
            //              (x.Email != null && x.Email.NormalizedValue.Equals("5ec0dcdf458ee33f94ef2b5f"))))

            //        //x => x.Id != "5ec0dcdf458ee33f94ef2b5f" && x.Email != null &&
            //        //     x.Email.NormalizedValue.Equals("baoanh2005hoa@gmail.com"))
            //);
            //var list = database.GetCollection<Meeting>("meetings")
            //    .Find(filter)
            //    .Any();
                //.Project(
                //    Builders<Meeting>.Projection.Expression(x => x.Attendees.FirstOrDefault()))
                //.FirstOrDefault();
                
                
            //testOutputHelper.WriteLine(JsonConvert.SerializeObject(list));

            var query = new MeetingAttendeeDelegatedQuery(meetingId);
            var mediator = serviceProvider.GetService<IMediator>();
            var result = await mediator.Send(query);

            testOutputHelper.WriteLine(JsonConvert.SerializeObject(result));
        }
    }
}
