using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using DustyTome.PFC.Core;
using Rhino.Mocks;
using System.Collections;

namespace DustyTome.PFC.Tests.Core
{
    [TestFixture]
    public class RuleRunnerTests
    {
        private EnumerableHelper _helper;

        private MockRepository _mocks;
        
        private IFileRetriever _fileRetriever;
        private IRuleRetriever _ruleRetriever;
        private IRuleRunner _ruleRunner;

        [SetUp]
        public void SetUp()
        {
            _helper = new EnumerableHelper();

            _mocks = new MockRepository();

            _fileRetriever = _mocks.StrictMock<IFileRetriever>();
            _ruleRetriever = _mocks.StrictMock<IRuleRetriever>();
            _ruleRunner = new RuleRunner(_fileRetriever, _ruleRetriever);
        }

        [Test]
        public void Run_WhenGivenFilesAndRules_ShouldRunEachRuleOnEachFile()
        {
            // Arrange
            var file1 = _mocks.Stub<IFile>();
            var file2 = _mocks.Stub<IFile>();
            var files = new List<IFile> { file1, file2 };

            var rule1 = _mocks.StrictMock<IRule>();
            var rule2 = _mocks.StrictMock<IRule>();
            var rule3 = _mocks.StrictMock<IRule>();
            var rules = new List<IRule> { rule1, rule2, rule3 };

            var results = new IResult[6];
            for (int i = 0; i < 6; i++)
            {
                results[i] = _mocks.Stub<IResult>();
            }

            using (_mocks.Record())
            {
                Expect.Call(_fileRetriever.GetFiles()).Return(files);
                Expect.Call(_ruleRetriever.GetRules()).Return(rules);
                Expect.Call(rule1.Run(file1)).Return(results[0]);
                Expect.Call(rule1.Run(file2)).Return(results[1]);
                Expect.Call(rule2.Run(file1)).Return(results[2]);
                Expect.Call(rule2.Run(file2)).Return(results[3]);
                Expect.Call(rule3.Run(file1)).Return(results[4]);
                Expect.Call(rule3.Run(file2)).Return(results[5]);
            }

            // Act
            IEnumerable<IResult> actualResults;
            using (_mocks.Playback())
            {
                actualResults = _ruleRunner.Run();
            }

            // Assert
            Assert.That(_helper.NumberOfItemsIn(actualResults), Is.EqualTo(6));
            foreach (var result in results)
            {
                Assert.That(actualResults, Contains.Item(result));
            }
        }
    }
}
