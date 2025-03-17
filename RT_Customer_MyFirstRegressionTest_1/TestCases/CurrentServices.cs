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

	public class CurrentServices :ITestCase
	{
		private const string MaskingServicesName = "Skyline Masking Services";
		public string Name { get; set; }

		public CurrentServices(string name)
		{

		}

		public TestCaseReport TestCaseReport { get; private set; }

		public PerformanceTestCaseReport PerformanceTestCaseReport { get; private set; }

		public void Execute(IEngine engine)
		{

		}
	}
}
