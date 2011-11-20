using System;
using System.Collections.Generic;
using System.Text;
using DustyTome.PFC.Core;
using System.IO;

namespace DustyTome.PFC.UI.Console
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var program = new Program();
            return program.Execute(args);
        }

        public int Execute(string[] args)
        {
            int errorCode = 0;

            try
            {
                foreach(var arg in args)
                {
                    System.Console.WriteLine(arg);
                }

                var ruleRunner = BuildRuleRunner(args);
                var results = ruleRunner.Run();

                foreach (var result in results)
                {
                    if (result.HasErrors)
                    {
                        errorCode = 1;

                        foreach (var error in result.GetErrors())
                        {
                            System.Console.WriteLine(result.FilePath + ": " + error.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorCode = 1;
                System.Console.WriteLine("Unexpected Exception!");
                System.Console.WriteLine(ex);
            }

            System.Console.WriteLine("Exiting with error code " + errorCode);
            System.Console.WriteLine("Press any key...");
            System.Console.ReadKey();
            return errorCode;
        }

        private static RuleRunner BuildRuleRunner(string[] args)
        {
            var fileRetriever = new FileRetriever(args);
            var ruleRetriever = new HardCodedRuleRetriever();
            var ruleRunner = new RuleRunner(fileRetriever, ruleRetriever);
            return ruleRunner;
        }
    }
}
