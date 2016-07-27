using System;
using NUnit.Framework;
using HP.LFT.SDK;
using HP.LFT.Verifications;
using HP.LFT.Report;

namespace PassingArgs
{
    [TestFixture]
    public class LeanFtTest : UnitTestClassBase
    {
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            // Setup once per fixture
        }

        [SetUp]
        public void SetUp()
        {
            // Before each test
        }

        public void CheckAsserts(string value)
        {
            Assert.IsTrue(Verify.IsMatch(value, "(?i)pass.*?(?-i)"));
            
        }

        [TestCase("pass1")]
        [TestCase("waffle")]
        [TestCase("fail3")]
        [TestCase("pass4")]
        [TestCase("pass5")]
        [TestCase("fail6")]
        [TestCase("pass7")]
        public void MyTest(string value)
        {
            //Simple comment to show link to defect number in Octane
            //more comments
            //Forces a normal failure to pass based on if the seconds is odd or even
            //int s = Int32.Parse(Environment.GetEnvironmentVariable("BUILD_NBR"));
            int s = int.Parse(DateTime.Now.Second.ToString());
            if (value.Equals("waffle"))
            {
                Reporter.ReportEvent("Waffle", "Seconds " + s + " -- Odd will fail, Even will pass");
                if ((s % 2) == 0)
                    value = "pass";
            }
            CheckAsserts(value);
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up after each test
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            // Clean up once per fixture
        }
    }
}
