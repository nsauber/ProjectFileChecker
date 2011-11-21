using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using DustyTome.PFC.Configuration;

namespace DustyTome.PFC.Tests.Configuration
{
    [TestFixture]
    public class SerializerManualTestHarness
    {
        [Test, Explicit]
        public void WriteXmlToFile()
        {
            var rules = new Rule[3];
            rules[0] = new Rule { Identifier = "TEMP001", Enabled = true };
            rules[1] = new Rule { Identifier = "TEMP002", Enabled = false };
            rules[2] = new Rule { Identifier = "TEMP003", Enabled = true };
            var configuration = new DustyTome.PFC.Configuration.Configuration();
            configuration.RuleSet = new RuleSet();
            configuration.RuleSet.Rules = rules;

            var serializer = new ConfigurationSerializer();
            serializer.WriteToFile(configuration, @"testFile.xml");
        }

        [Test, Explicit]
        public void ReadXmlFromFile()
        {
            var serializer = new ConfigurationSerializer();
            var configuration = serializer.ReadFromFile(@"testFile.xml");

            var rules = configuration.RuleSet.Rules;
            Assert.That(rules.Length, Is.EqualTo(3));
            Assert.That(rules[0].Identifier, Is.EqualTo("TEMP001"));
            Assert.That(rules[0].Enabled, Is.EqualTo(true));
            Assert.That(rules[1].Identifier, Is.EqualTo("TEMP002"));
            Assert.That(rules[1].Enabled, Is.EqualTo(false));
            Assert.That(rules[2].Identifier, Is.EqualTo("TEMP003"));
            Assert.That(rules[2].Enabled, Is.EqualTo(true));
        }
    }
}
