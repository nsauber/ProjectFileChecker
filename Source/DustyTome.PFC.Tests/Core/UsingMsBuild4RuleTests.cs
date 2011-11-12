using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using DustyTome.PFC.Core;
using NUnit.Framework;
using Rhino.Mocks;

namespace DustyTome.PFC.Tests.Core
{
    [TestFixture]
    public class UsingMsBuild4RuleTests
    {
        private EnumerableHelper _helper;

        private MockRepository _mocks;
        private IFile _file;

        private UsingMsBuild4Rule _rule;

        [SetUp]
        public void SetUp()
        {
            _helper = new EnumerableHelper();

            _mocks = new MockRepository();
            _file = _mocks.StrictMock<IFile>();

            _rule = new UsingMsBuild4Rule();
        }

        [Test]
        public void Check_ToolsVersionIs4_ShouldReturnNoErrors()
        {
            var fileStream = GetProjectFileForToolsVersion4();
            using (_mocks.Record())
            {
                Expect.Call(_file.GetStream()).Return(fileStream);
            }

            IEnumerable<IError> errors = null;
            using (_mocks.Playback())
            {                
                errors = _rule.Check(_file);
            }

            Assert.That(_helper.NumberOfItemsIn(errors), Is.EqualTo(0));
        }

        [Test]
        public void Check_ToolsVersionIsNot4_ShouldReturnAnError()
        {
            var fileStream = GetProjectFileForToolsVersion35();
            using (_mocks.Record())
            {
                Expect.Call(_file.GetStream()).Return(fileStream);
            }

            IEnumerable<IError> errors = null;
            using (_mocks.Playback())
            {
                errors = _rule.Check(_file);
            }

            Assert.That(_helper.NumberOfItemsIn(errors), Is.EqualTo(1));
        }

        [Test]
        public void Check_ToolsVersionDoesNotExist_ShouldReturnAnError()
        {
            var fileStream = GetProjectFileWithoutToolsVersion();
            using (_mocks.Record())
            {
                Expect.Call(_file.GetStream()).Return(fileStream);
            }

            IEnumerable<IError> errors = null;
            using (_mocks.Playback())
            {
                errors = _rule.Check(_file);
            }

            Assert.That(_helper.NumberOfItemsIn(errors), Is.EqualTo(1));
        }


        private Stream GetProjectFileForToolsVersion4()
        {
            return GetStreamFromResource("DustyTome.PFC.Tests.ProjectFiles.ProjectFileUsingMsBuild4.xml");
        }

        private Stream GetProjectFileForToolsVersion35()
        {
            return GetStreamFromResource("DustyTome.PFC.Tests.ProjectFiles.ProjectFileUsingMsBuild35.xml");
        }

        private Stream GetProjectFileWithoutToolsVersion()
        {
            return GetStreamFromResource("DustyTome.PFC.Tests.ProjectFiles.ProjectFileWithoutToolsVersion.xml");
        }

        private string GetStringFromResource(string resourceName)
        {
            using (Stream stream = GetStreamFromResource(resourceName))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Error retrieving from Resources. Tried '" + resourceName + "'\r\n" + e.ToString());
                }
            }
        }

        private Stream GetStreamFromResource(string resourceName)
        {
            Assembly assem = this.GetType().Assembly;
            return assem.GetManifestResourceStream(resourceName);
        }
    }
}
