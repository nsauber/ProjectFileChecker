using System.Collections;
using System.Collections.Generic;
using DustyTome.PFC.Core;
using NUnit.Framework;
using Rhino.Mocks;

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

            var errors = new List<IError>();
            using (_mocks.Record())
            {
                Expect.Call(_fileRetriever.GetFiles()).Return(files);
                Expect.Call(_ruleRetriever.GetRules()).Return(rules);
                Expect.Call(rule1.Check(file1)).Return(errors);
                Expect.Call(rule1.Check(file2)).Return(errors);
                Expect.Call(rule2.Check(file1)).Return(errors);
                Expect.Call(rule2.Check(file2)).Return(errors);
                Expect.Call(rule3.Check(file1)).Return(errors);
                Expect.Call(rule3.Check(file2)).Return(errors);
            }

            // Act
            IEnumerable<IFileResults> results;
            using (_mocks.Playback())
            {
                results = _ruleRunner.Run();
            }

            // Assert
            Assert.That(_helper.NumberOfItemsIn(results), Is.EqualTo(_helper.NumberOfItemsIn(files)));
            foreach (var result in results)
            {
                Assert.That(files, Contains.Item(result.File));
            }
        }
    }
}
