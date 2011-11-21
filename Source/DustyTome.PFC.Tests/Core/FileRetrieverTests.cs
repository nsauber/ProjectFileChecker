using System.Collections.Generic;
using DustyTome.PFC.Core;
using NUnit.Framework;

namespace DustyTome.PFC.Tests.Core
{
    [TestFixture]
    public class FileRetrieverTests
    {
        private EnumerableHelper _helper;

        [SetUp]
        public void SetUp()
        {
            _helper = new EnumerableHelper();
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
