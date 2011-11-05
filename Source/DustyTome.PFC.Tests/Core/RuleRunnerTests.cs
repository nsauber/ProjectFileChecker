using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using DustyTome.PFC.Core;
using Rhino.Mocks;

namespace DustyTome.PFC.Tests.Core
{
    [TestFixture]
    public class RuleRunnerTests
    {
        [Test]
        public void Run_WhenGivenFilesAndRules_ShouldRunEachRuleOnEachFile()
        {
            var mocks = new MockRepository();

            // Arrange
            var file1 = mocks.Stub<IFile>();
            var file2 = mocks.Stub<IFile>();
            var files = new List<IFile> { file1, file2 };

            var rule1 = mocks.StrictMock<IRule>();
            var rule2 = mocks.StrictMock<IRule>();
            var rule3 = mocks.StrictMock<IRule>();
            var rules = new List<IRule> { rule1, rule2, rule3 };

            var results = new IResult[6];
            for (int i = 0; i < 6; i++)
            {
                results[i] = mocks.Stub<IResult>();
            }

            using (mocks.Record())
            {
                Expect.Call(rule1.Run(file1)).Return(results[0]);
                Expect.Call(rule1.Run(file2)).Return(results[1]);
                Expect.Call(rule2.Run(file1)).Return(results[2]);
                Expect.Call(rule2.Run(file2)).Return(results[3]);
                Expect.Call(rule3.Run(file1)).Return(results[4]);
                Expect.Call(rule3.Run(file2)).Return(results[5]);
            }

            // Act
            var ruleRunner = new RuleRunner();
            IEnumerable<IResult> actualResults;
            using (mocks.Playback())
            {
                actualResults = ruleRunner.Run(files, rules);
            }

            // Assert
            foreach (var result in results)
            {
                Assert.That(actualResults, Contains.Item(result));
            }
        }
    }
}
