namespace RT_Customer_MyFirstRegressionTest_1
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	using Library.Tests.TestCases;

	using QAPortalAPI.Models.ReportingModels;

	using Skyline.DataMiner.Automation;
	using Skyline.DataMiner.Core.DataMinerSystem.Automation;
	using Skyline.DataMiner.Core.DataMinerSystem.Common;

	public class LoadSchedules : ITestCase
	{
		private const string MaskingServicesName = "Skyline Masking Services";
		private const int ExcelPathPID = 3;
		public LoadSchedules(string name)
		{
			if (String.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("name");
			}

			Name = name;
		}

		public string Name { get; set; }

		public TestCaseReport TestCaseReport { get; private set; }

		public PerformanceTestCaseReport PerformanceTestCaseReport { get; private set; }

		public void Execute(IEngine engine)
		{
		
			var isSuccess = true;

			var dms = engine.GetDms();
			var elements = dms.GetElements();

			StringBuilder failedExamples = new StringBuilder();

			var maskingElements = elements.Where(element => string.Equals(element.Protocol.Name, MaskingServicesName, StringComparison.CurrentCultureIgnoreCase));

			foreach (var element in maskingElements)
			{
				var path = element.GetStandaloneParameter<string>(ExcelPathPID).GetValue();
				if (!String.IsNullOrEmpty(path))
				{

					if (!File.Exists(path))
					{
						isSuccess = false;
						failedExamples.AppendLine($"Element {element.Name} Path: {path}");
					}
				}
				else
				{
					isSuccess = false;
					failedExamples.AppendLine($"Element {element.Name} Path is null or empty");
				}
			}

			if (isSuccess)
			{
				TestCaseReport = TestCaseReport.GetSuccessTestCase(Name);
			}
			else
			{
				TestCaseReport = TestCaseReport.GetFailTestCase(Name, failedExamples.ToString());
			}
		}
	}
}
