﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using CS.Common.Contract;
using CS.Common.Contract.Models;
using CS.Common.Extensions;
using CS.Common.Std.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace xUnit.CSCommon
{
    public class CommonTest : TestBase<CommonFixtureSetup>
    {
        public CommonTest(CommonFixtureSetup fixtureSetup, ITestOutputHelper output) : base(fixtureSetup, output)
        {
        }

        [Fact]
        public void CircuitThrowsException()
        {
            // setup
            var exceptionMethod = new Func<bool>(() => throw new Exception("Testing"));

            // exercise
            var attempt = 0;
            exceptionMethod.CircuitBreakerExecute(options =>
            {
                options.MaxAttemptFailure = 2;
                options.BreakerOpened = exception =>
                {
                    Logger.WriteLine("BreakerOpened");
                    attempt = options.Attempt;
                };
                options.UnkownException = exception => Logger.WriteLine("UnkownException");
            });

            // assert
            Assert.Equal(2, attempt);
        }

        [Fact]
        public void CircuitTimeout()
        {
            // setup
            var exceptionMethod = new Func<bool>(() =>
            {
                Thread.Sleep(20);
                return true;
            });

            // exercise
            var attempt = 0;
            exceptionMethod.CircuitBreakerExecute(options =>
            {
                options.MaxAttemptFailure = 2;
                options.ExecuteTimeOut = TimeSpan.FromMilliseconds(10);
                options.BreakerOpened = exception =>
                {
                    Logger.WriteLine("BreakerOpened");
                    attempt = options.Attempt;
                };
                options.UnkownException = exception => Logger.WriteLine("UnkownException");
                options.BreakerTimeout = exception => Logger.WriteLine("BreakerTimeout");
            });

            // assert
            Assert.Equal(2, attempt);
        }

        [Fact]
        public void CircuitFullTest()
        {
            var attempt = 0;

            // setup
            var exceptionMethod = new Func<string>(() =>
            {
                if (attempt < 2)
                    throw new Exception($"Testing {attempt}");

                Logger.WriteLine($"...attempt: {attempt}");
                if (attempt < 4)
                    Thread.Sleep(TimeSpan.FromMilliseconds(500));

                Logger.WriteLine($"oop! return at: {attempt}");
                return "Testing";
            });

            // exercise
            var result = exceptionMethod.CircuitBreakerExecute(options =>
            {
                options.MaxAttemptFailure = 5;
                options.ExecuteTimeOut = TimeSpan.FromMilliseconds(200);
                options.ResetTimeOut = TimeSpan.FromMilliseconds(300);
                options.BreakerOpened = exception =>
                {
                    Logger.WriteLine($"BreakerOpened: {options.Attempt} - {exception.Message}");
                    attempt = options.Attempt;
                };
                options.BreakerTimeout = exception =>
                {
                    Logger.WriteLine($"BreakerTimeout: {options.Attempt} - {exception.Message}");
                    attempt = options.Attempt;
                };
                options.UnkownException = exception =>
                {
                    Logger.WriteLine($"UnkownException: {options.Attempt} - {exception.Message}");
                    attempt = options.Attempt;
                };
            });
            Logger.WriteLine("-------");
            Logger.WriteLine($"Result with {attempt} attempt: {result}");

            // assert
            Assert.Equal("Testing", result);
            Assert.Equal(4, attempt);
        }

        [Fact]
        public void SelectParent()
        {
            //setup
            var all = new List<BranchModel>
            {
                new BranchModel{Id = 1, BranchName = "Branch1"},
                new BranchModel{Id = 2, BranchName = "Branch2"},
                new BranchModel
                {
                    Id = 3, BranchName = "Branch3",
                    Parent = new BranchModel{Id = 2, BranchName = "Branch2"}
                },
                new BranchModel
                {
                    Id = 4, BranchName = "Branch4",
                    Parent = new BranchModel{Id = 3, BranchName = "Branch3"}
                },
            };

            
            var lookup = all.ToLookup(x => x.Parent?.Id);
            
            Logger.WriteLine("-----------------");
            foreach (var grouping in lookup)
            {
                Logger.WriteLine("Parent: " + $"ID: {grouping.Key?? 0}");
                foreach (var parent in grouping.SelectRecursive(x => lookup[x.Id]))
                {
                    Logger.WriteLine($"ID: {parent.Id} - {parent.BranchName}");
                }
            }

            var model = all.Single(x => x.Id == 2);
            Logger.WriteLine($"{model.BranchName}-----------------");

            var allParent = lookup[2].SelectRecursive(x => lookup[x.Id]);
            foreach (var parent in allParent)
            {
                Logger.WriteLine($"ID: {parent.Id} - {parent.BranchName}");
            }

            model = all.Single(x => x.Id == 3);
            Logger.WriteLine($"{model.BranchName}-----------------");

            allParent = lookup[2].SelectRecursive(x => lookup[x.Id]);
            foreach (var parent in allParent)
            {
                Logger.WriteLine($"ID: {parent.Id} - {parent.BranchName}");
            }
        }

        [Fact]
        public void TestLookup()
        {
            // Create an array of strings.
            string[] array = { "cat", "dog", "horse", "abc", "cat" };

            // Generate a lookup structure,
            // ... where the lookup is based on the key length.
            var lookup = array.ToLookup(item => item.Length);

            // Enumerate strings of length 3.
            foreach (string item in lookup[3])
            {
                Logger.WriteLine("3 = " + item);
            }

            // Enumerate strings of length 5.
            foreach (string item in lookup[5])
            {
                Logger.WriteLine("5 = " + item);
            }

            // Enumerate groupings.
            foreach (var grouping in lookup)
            {
                Logger.WriteLine("Grouping: " + grouping.Key);
                foreach (var item in grouping)
                {
                    Logger.WriteLine(item);
                }
            }

        }

        private static void BuildParents<TKey, T>(ObservableCollection<T> observableResult, T model, IList<T> allModels, Func<T, TKey> parentLookup, T defaultModel = null)
            where T : class, IResource<TKey>
        {
            if (model == null)
                return;

            observableResult.Clear();

            var lookup = allModels.ToLookup(parentLookup);
            var allChildren = lookup[model.Id].SelectRecursive(x => lookup[x.Id]);

            var parents = new List<T>();
            if (defaultModel != null)
                parents.Add(defaultModel);

            parents.AddRange(allModels.Except(allChildren).ToList());
            parents.Remove(model);
        }
    }
}
