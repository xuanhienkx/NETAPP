using DSoft.Common.Settings;
using DSoft.Common.Shared.Base;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using Xunit.Abstractions;

namespace xUnit.DSoft.CommonTest
{
    public class MongoDbConnectTest : TestBase<CommonFixtureSetup>
    {
        public MongoDbConnectTest(CommonFixtureSetup fixtureSetup, ITestOutputHelper output) : base(fixtureSetup, output)
        {
        }

        [Fact]
        //mongodb://mongoadmin:Admin@1234@localhost:27017/?authSource=admin
        public async void ConnectDbTest()
        {
            //mongodb://mongoadmin:Admin%401234@localhost:27017/?serverSelectionTimeoutMS=5000&connectTimeoutMS=10000&authSource=admin&authMechanism=SCRAM-SHA-1

            var client = new MongoClient("mongodb://mongoadmin:Admin%401234@localhost:27017/?serverSelectionTimeoutMS=5000&connectTimeoutMS=10000&authSource=admin&authMechanism=SCRAM-SHA-1");
            var database = client.GetDatabase("foo");
            var collection = database.GetCollection<BsonDocument>("bar");
            var documents = Enumerable.Range(0, 100).Select(i => new BsonDocument("counter", i));
            //collection.InsertMany(documents);
            //await collection.InsertManyAsync(documents);
            var count = await collection.CountDocumentsAsync(new BsonDocument());
            Logger.WriteLine(count.ToString());
            var document = await collection.Find(new BsonDocument()).FirstOrDefaultAsync();
            Logger.WriteLine(document.ToString());

            Assert.Equal<long>(count, 201);

        }
        [Fact]
        public async void ConnectionStringDbTest()
        {

            var dbsetting = Fixture.Configuration.GetSection(ProviderConstants.DomainDatabaseSettings).Get<DatabaseSettings>();
            Logger.WriteLine(dbsetting.ConnectionString);
            var str = "mongodb://mongoadmin:Admin%401234@localhost:27017/?serverSelectionTimeoutMS=5000&connectTimeoutMS=10000&authSource=admin&authMechanism=SCRAM-SHA-1";
            Assert.Equal(dbsetting.ConnectionString, str);
            var url = new MongoUrl(dbsetting.ConnectionString);
            var client = new MongoClient(url);
            var database = client.GetDatabase("foo");
            var collection = database.GetCollection<BsonDocument>("bar");
            var count = await collection.CountDocumentsAsync(new BsonDocument());
            Logger.WriteLine(count.ToString());
            var document = await collection.Find(new BsonDocument()).FirstOrDefaultAsync();
            Logger.WriteLine(document.ToString());
            Assert.Equal(dbsetting.DatabaseName, "dsoft");
            Assert.Equal<long>(count, 201);

        }

    }
}


