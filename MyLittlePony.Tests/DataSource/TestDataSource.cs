using MyLittlePony.AT.Framework.Models;
using NUnit.Framework;
using System.Collections;

namespace MyLittlePony.Tests.DataSource
{
    public static class TestDataSource
    {
        public static IEnumerable ChromeTestCases
        {
            get
            {
                yield return new TestCaseData(new ChromeInfo() { SearchText = "Selenium IDE export to C#" });
            }
        }
    }
}
