using System.Collections.Generic;
using System.Xml;
using System;

namespace DustyTome.PFC.Core
{
    public class UsingMsBuild4Rule : IRule
    {
        public IEnumerable<IError> Check(IFile file)
        {
            var errors = new List<IError>();

            var xmlDocument = new XmlDocument();
            xmlDocument.Load(file.GetStream());

            var node = xmlDocument.DocumentElement.SelectSingleNode("@ToolsVersion");
            if (node == null)
            {
                var message = "Doesn't specify which version of MSBuild to use";
                var error = new Error()
                {
                    Message = message
                };
                errors.Add(error);
            }
            else
            {
                var value = node.Value;
                if (value != "4.0")
                {
                    var message = string.Format("Should be using MSBuild 4.0, but is using {0}", value);
                    var error = new Error()
                    {
                        Message = message
                    };
                    errors.Add(error);
                }
            }

            return errors;
        }
    }
}
