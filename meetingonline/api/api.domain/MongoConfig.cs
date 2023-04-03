//using api.common.Shared;
//using Microsoft.AspNetCore.Identity;
//using MongoDB.Bson;
//using MongoDB.Bson.Serialization;
//using MongoDB.Bson.Serialization.Conventions;
//using MongoDB.Bson.Serialization.Serializers;
//using System;
//using System.Threading;
//using CommonModels = api.common.Models.Identity;

//namespace api.domain
//{
//    internal static class MongoConfig
//    {
//        private static bool _initialized = false;
//        private static object _initializationLock = new object();
//        private static object _initializationTarget;

//        public static void EnsureConfigured()
//        {
//            EnsureConfiguredImpl();
//        }

//        private static void EnsureConfiguredImpl()
//        {
//            LazyInitializer.EnsureInitialized(ref _initializationTarget, ref _initialized, ref _initializationLock, () =>
//            {
//                Configure();
//                return null;
//            });
//        }

//        private static void Configure()
//        {
//            RegisterConventions();

//            BsonClassMap.RegisterClassMap<CommonModels.IdentityUser>(cm =>
//            {
//                cm.AutoMap();
//                //cm.MapIdMember(c => c.Id)
//                //    .SetSerializer(new StringSerializer(BsonType.ObjectId))
//                //    .SetIdGenerator(StringObjectIdGenerator.Instance);

//                cm.MapCreator(user => new CommonModels.IdentityUser(user.UserName, user.Email));
//            });

//            BsonClassMap.RegisterClassMap<CommonModels.IdentityUserClaim>(cm =>
//            {
//                cm.AutoMap();
//                cm.MapCreator(c => new CommonModels.IdentityUserClaim(c.ClaimType, c.ClaimValue));
//            });

//            BsonClassMap.RegisterClassMap<CommonModels.IdentityUserEmail>(cm =>
//            {
//                cm.AutoMap();
//                cm.MapCreator(cr => new CommonModels.IdentityUserEmail(cr.Value));
//            });

//            BsonClassMap.RegisterClassMap<CommonModels.IdentityUserContactRecord>(cm =>
//            {
//                cm.AutoMap();
//            });

//            BsonClassMap.RegisterClassMap<CommonModels.IdentityUserPhoneNumber>(cm =>
//            {
//                cm.AutoMap();
//                cm.MapCreator(cr => new CommonModels.IdentityUserPhoneNumber(cr.Value));
//            });

//            BsonClassMap.RegisterClassMap<CommonModels.IdentityUserLogin>(cm =>
//            {
//                cm.AutoMap();
//                cm.MapCreator(l => new CommonModels.IdentityUserLogin(new UserLoginInfo(l.LoginProvider, l.ProviderKey, l.ProviderDisplayName)));
//            });

//            BsonClassMap.RegisterClassMap<Occurrence>(cm =>
//            {
//                cm.AutoMap();
//                cm.MapCreator(cr => new Occurrence(cr.Instant));
//                cm.MapMember(x => x.Instant).SetSerializer(new DateTimeSerializer(DateTimeKind.Utc, BsonType.Document));
//            });
//        }

//        private static void RegisterConventions()
//        {
//            var pack = new ConventionPack
//            {
//                new IgnoreIfNullConvention(false),
//                new CamelCaseElementNameConvention(),
//            };

//            ConventionRegistry.Register("AspNetCore.Identity.MongoDB", pack, IsConventionApplicable);
//        }

//        private static bool IsConventionApplicable(Type type)
//        {
//            return type == typeof(CommonModels.IdentityUser)
//                || type == typeof(CommonModels.IdentityUserClaim)
//                || type == typeof(CommonModels.IdentityUserContactRecord)
//                || type == typeof(CommonModels.IdentityUserEmail)
//                || type == typeof(CommonModels.IdentityUserLogin)
//                || type == typeof(CommonModels.IdentityUserPhoneNumber)
//                || type == typeof(Occurrence);
//        }
//    }
//}