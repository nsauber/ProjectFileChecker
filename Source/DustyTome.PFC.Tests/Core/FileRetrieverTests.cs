using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using DustyTome.PFC.Core;

namespace DustyTome.PFC.Tests.Core
{
    [TestFixture]
    public class FileRetrieverTests
    {
        private TestHelper _helper;

        [SetUp]
        public void SetUp()
        {
            _helper = new TestHelper();
        }

        [Test]
        public void GetFiles_WhenPassedCollectionOfFilePaths_ShouldReturnCollectionOfMatchingFiles()
        {
            // Arrange
            var filePaths = new List<string>
            {
                @"C:\folder\fileName1.txt",
                @"C:\folder\fileName2.txt",
                @"C:\folder\fileName3.txt",
                @"C:\folder\fileName4.txt",
                @"C:\folder\fileName5.txt"
            };
            var retriever = new FileRetriever(filePaths);

            // Act
            var files = retriever.GetFiles();

            // Assert
            Assert.That(_helper.NumberOfItemsIn(files), Is.EqualTo(filePaths.Count));
            foreach (var file in files)
            {
                Assert.That(filePaths, Contains.Item(file.FilePath));
            }
        }
    }
}
