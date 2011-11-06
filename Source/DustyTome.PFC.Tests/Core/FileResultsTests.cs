using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using DustyTome.PFC.Core;

namespace DustyTome.PFC.Tests.Core
{
    [TestFixture]
    public class FileResultsTests
    {
        private EnumerableHelper _helper;
        private MockRepository _mocks;

        private IFile _file;
        private FileResults _fileResults;
            
        const string path = "path to a file";

        [SetUp]
        public void SetUp()
        {
            _helper = new EnumerableHelper();
            _mocks = new MockRepository();

            _file = _mocks.Stub<IFile>();
            _fileResults = new FileResults(_file);
        }

        [Test]
        public void FilePath_InitializedWithAFile_ShouldReturnMatchingFilePath()
        {
            // Arrange
            using (_mocks.Record())
            {
                Expect.Call(_file.FilePath).Return(path);
            }

            // Act
            string actualPath;
            using (_mocks.Playback())
            {
                actualPath = _fileResults.FilePath;
            }

            // Assert
            Assert.That(actualPath, Is.EqualTo(path));
        }

        [Test]
        public void HasErrors_WhenFirstInitialized_ShouldNotHaveErrors()
        {
            Assert.That(_fileResults.HasErrors, Is.False);
        }

        [Test]
        public void GetErrors_WhenFirstInitialized_ShouldBeEmpty()
        {
            var errors = _fileResults.GetErrors();
            Assert.That(_helper.NumberOfItemsIn(errors), Is.EqualTo(0));
        }

        [Test]
        public void Merge_WhenAddingErrors_ShouldBeIncludedInGetErrors()
        {
            var errors = new List<IError>();
            for (int i = 0; i < 5; i++)
            {
                errors.Add(_mocks.Stub<IError>());
            }

            _fileResults.Merge(errors);
            var actualErrors = _fileResults.GetErrors();

            foreach (var error in errors)
            {
                Assert.That(actualErrors, Contains.Item(error));
            }
        }
    }
}
